using Qrame.Core.Library.MessageContract.DataObject;
using Qrame.Core.Library.MessageContract.Message;
using Qrame.CoreFX.ObjectController;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qrame.Core.Library
{
    public interface ITransactionResponsePlugIn : IPlugIn
    {
        string Description { get; }

        Task<TransactionResponse> Execute(TransactionRequest request);
    }

    public interface ITransactionOperationPlugIn : IPlugIn
    {
        string Description { get; }

        Task<ApplicationResponse> Execute(TransactionObject request, List<ModelOutputContract> outputContract);
    }
}
