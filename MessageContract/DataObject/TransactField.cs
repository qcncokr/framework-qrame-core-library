using System;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    [Serializable]
    public class TransactField
    {
        public string FieldID;
        public int Length;
        public string DataType;
        public object Value;
    }
}
