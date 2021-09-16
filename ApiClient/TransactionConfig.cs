using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;

namespace Qrame.CoreFX.Library.ApiClient
{
    public static class TransactionConfig
    {
        public static int TransactionTimeout = 0;
        public static string ApiFindUrl = "";
        public static string DomainServerType = "";

        public static class Program
        {
            public static string ProgramVersion = "";
            public static string LanguageID = "";
            public static string TerminalBranchCode = "";
            public static string IPAddress = GetIPAddress();
            public static string MacAddress = GetMacAddress();
            public static string NetworkInterfaceType = GetNetworkInterfaceType();
        }

        public static class Transaction
        {
            public static string SystemID = "";
            public static string ProtocolVersion = "";
            public static string RunningEnvironment = "";
            public static string MachineName = "";
            public static string SystemCode = "";
            public static string SystemInterfaceID = "";
            public static string MachineTypeID = "";
            public static string DataEncryptionYN = "";
            public static string DataFormat = "J";
            public static string CryptoCode = "P";
            public static string CryptoKey = "";
        }

        public static class OperatorUser
        {
            public static string UserID = "";
        }

        public static string GetIPAddress()
        {
            string ip = "127.0.0.1";
            IPAddress[] host = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var item in host)
            {
                if (item.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip = item.ToString();
                }
            }
            return ip;
        }

        public static string GetMacAddress()
        {
            NetworkInterface[] NetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            return NetworkInterfaces.Length > 0 ? NetworkInterfaces[0].GetPhysicalAddress().ToString() : "";
        }

        public static string GetNetworkInterfaceType()
        {
            NetworkInterface[] NetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            return NetworkInterfaces.Length > 0 ? ((int)NetworkInterfaces[0].NetworkInterfaceType).ToString().PadLeft(3, '0') : "001";
        }
    }
}
