using Qrame.CoreFX.Library.MessageContract.DataObject;
using Qrame.CoreFX.Library.MessageContract.Message;
using Qrame.CoreFX.ObjectController;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Qrame.CoreFX.Library
{
    /// <summary>
    /// 플러그인에게 제공해야 할 공통 기능
    /// </summary>
    public interface ITransactionApplication : IPlugInBasedApplication
    {
        Task<ApplicationResponse> CommonTransaction(TransactionObject request, List<ModelOutputContract> outputContracts);

        Task<ApplicationResponse> DynamicTransaction(TransactionObject request, List<ModelOutputContract> outputContracts);
    }
}
