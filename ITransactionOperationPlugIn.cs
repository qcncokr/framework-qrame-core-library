using Qrame.CoreFX.Library.MessageContract.DataObject;
using Qrame.CoreFX.Library.MessageContract.Message;
using Qrame.CoreFX.ObjectController;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qrame.CoreFX.Library
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
