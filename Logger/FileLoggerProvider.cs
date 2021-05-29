
using Qrame.Core.Library.Logger;

using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Logging
{
    public class FileLoggerProvider : ILoggerProvider
	{
		private readonly string LogFileName;

		private readonly ConcurrentDictionary<string, FileLogger> loggers = new ConcurrentDictionary<string, FileLogger>();
		private readonly BlockingCollection<string> entryQueue = new BlockingCollection<string>(1024);
		private readonly Task processQueueTask;
		private readonly FileWriter fWriter;

		private readonly bool Append = true;
		private readonly long FileSizeLimitBytes = 0;
		private readonly int MaxRollingFiles = 0;

		public LogLevel MinLevel { get; set; } = LogLevel.Debug;

		public Func<LogMessage, string> FormatLogEntry { get; set; }

		public Func<string, string> FormatLogFileName { get; set; }

		public FileLoggerProvider(string fileName) : this(fileName, true)
		{
		}

		public FileLoggerProvider(string fileName, bool append) : this(fileName, new FileLoggerOptions() { Append = append })
		{
		}

		public FileLoggerProvider(string fileName, FileLoggerOptions options)
		{
			LogFileName = Environment.ExpandEnvironmentVariables(fileName);
			Append = options.Append;
			FileSizeLimitBytes = options.FileSizeLimitBytes;
			MaxRollingFiles = options.MaxRollingFiles;
			FormatLogEntry = options.FormatLogEntry;
			FormatLogFileName = options.FormatLogFileName;

			fWriter = new FileWriter(this);
			processQueueTask = Task.Factory.StartNew(ProcessQueue, this, TaskCreationOptions.LongRunning);
		}

		public ILogger CreateLogger(string categoryName)
		{
			return loggers.GetOrAdd(categoryName, CreateLoggerImplementation);
		}

		public void Dispose()
		{
			entryQueue.CompleteAdding();
			try
			{
				processQueueTask.Wait(1500);
			}
			catch (TaskCanceledException) { }
			catch (AggregateException ex) when (ex.InnerExceptions.Count == 1 && ex.InnerExceptions[0] is TaskCanceledException) { }

			loggers.Clear();
			fWriter.Close();
		}

		private FileLogger CreateLoggerImplementation(string name)
		{
			return new FileLogger(name, this);
		}

		internal void WriteEntry(string message)
		{
			if (!entryQueue.IsAddingCompleted)
			{
				try
				{
					entryQueue.Add(message);
					return;
				}
				catch (InvalidOperationException) { }
			}
		}

		private void ProcessQueue()
		{
			foreach (var message in entryQueue.GetConsumingEnumerable())
			{
				fWriter.WriteMessage(message, entryQueue.Count == 0);
			}
		}

		private static void ProcessQueue(object state)
		{
			var fileLogger = (FileLoggerProvider)state;
			fileLogger.ProcessQueue();
		}

		internal class FileWriter
		{

			readonly FileLoggerProvider FileLogPrv;
			string LogFileName;
			Stream LogFileStream;
			TextWriter LogFileWriter;

			internal FileWriter(FileLoggerProvider fileLogPrv)
			{
				FileLogPrv = fileLogPrv;

				DetermineLastFileLogName();
				OpenFile(FileLogPrv.Append);
			}

			string GetBaseLogFileName()
			{
				var fName = FileLogPrv.LogFileName;
				if (FileLogPrv.FormatLogFileName != null)
					fName = FileLogPrv.FormatLogFileName(fName);
				return fName;
			}

			void DetermineLastFileLogName()
			{
				var baseLogFileName = GetBaseLogFileName();
				__LastBaseLogFileName = baseLogFileName;
				if (FileLogPrv.FileSizeLimitBytes > 0)
				{
					// rolling file is used
					var logFileMask = Path.GetFileNameWithoutExtension(baseLogFileName) + "*" + Path.GetExtension(baseLogFileName);
					var logDirName = Path.GetDirectoryName(baseLogFileName);
					if (String.IsNullOrEmpty(logDirName))
						logDirName = Directory.GetCurrentDirectory();
					var logFiles = Directory.Exists(logDirName) ? Directory.GetFiles(logDirName, logFileMask, SearchOption.TopDirectoryOnly) : Array.Empty<string>();
					if (logFiles.Length > 0)
					{
						var lastFileInfo = logFiles
								.Select(fName => new FileInfo(fName))
								.OrderByDescending(fInfo => fInfo.Name)
								.OrderByDescending(fInfo => fInfo.LastWriteTime).First();
						LogFileName = lastFileInfo.FullName;
					}
					else
					{
						LogFileName = baseLogFileName;
					}
				}
				else
				{
					LogFileName = baseLogFileName;
				}
			}

			void OpenFile(bool append)
			{
				var fileInfo = new FileInfo(LogFileName);
				fileInfo.Directory.Create();

				LogFileStream = new FileStream(LogFileName, FileMode.OpenOrCreate, FileAccess.Write);
				if (append)
				{
					LogFileStream.Seek(0, SeekOrigin.End);
				}
				else
				{
					LogFileStream.SetLength(0);
				}
				LogFileWriter = new StreamWriter(LogFileStream);
			}

			string GetNextFileLogName()
			{
				var baseLogFileName = GetBaseLogFileName();
				if (!File.Exists(baseLogFileName) ||
					FileLogPrv.FileSizeLimitBytes <= 0 ||
					new FileInfo(baseLogFileName).Length < FileLogPrv.FileSizeLimitBytes)
					return baseLogFileName;

				int currentFileIndex = 0;
				var baseFileNameOnly = Path.GetFileNameWithoutExtension(baseLogFileName);
				var currentFileNameOnly = Path.GetFileNameWithoutExtension(LogFileName);

				var suffix = currentFileNameOnly.Substring(baseFileNameOnly.Length);
				if (suffix.Length > 0 && int.TryParse(suffix, out var parsedIndex))
				{
					currentFileIndex = parsedIndex;
				}
				var nextFileIndex = currentFileIndex + 1;
				if (FileLogPrv.MaxRollingFiles > 0)
				{
					nextFileIndex %= FileLogPrv.MaxRollingFiles;
				}

				var nextFileName = baseFileNameOnly + (nextFileIndex > 0 ? nextFileIndex.ToString() : "") + Path.GetExtension(baseLogFileName);
				return Path.Combine(Path.GetDirectoryName(baseLogFileName), nextFileName);
			}

			string __LastBaseLogFileName = null;

			void CheckForNewLogFile()
			{
				bool openNewFile = false;
				if (isMaxFileSizeThresholdReached() || isBaseFileNameChanged())
					openNewFile = true;

				if (openNewFile)
				{
					Close();
					LogFileName = GetNextFileLogName();
					OpenFile(false);
				}

				bool isMaxFileSizeThresholdReached()
				{
					return FileLogPrv.FileSizeLimitBytes > 0 && LogFileStream.Length > FileLogPrv.FileSizeLimitBytes;
				}
				bool isBaseFileNameChanged()
				{
					if (FileLogPrv.FormatLogFileName != null)
					{
						var baseLogFileName = GetBaseLogFileName();
						if (baseLogFileName != __LastBaseLogFileName)
						{
							__LastBaseLogFileName = baseLogFileName;
							return true;
						}
						return false;
					}
					return false;
				}
			}

			internal void WriteMessage(string message, bool flush)
			{
				if (LogFileWriter != null)
				{
					CheckForNewLogFile();
					LogFileWriter.WriteLine(message);
					if (flush)
						LogFileWriter.Flush();
				}
			}

			internal void Close()
			{
				if (LogFileWriter != null)
				{
					var logWriter = LogFileWriter;
					LogFileWriter = null;

					logWriter.Dispose();
					LogFileStream.Dispose();
					LogFileStream = null;
				}

			}
		}
	}
}
