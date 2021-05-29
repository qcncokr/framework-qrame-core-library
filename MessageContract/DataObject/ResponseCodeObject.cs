using System.Collections.Generic;
using System.Data;

namespace Qrame.Core.Library.MessageContract.DataObject
{
    public class ResponseCodeObject
    {
        public string Description { get; set; }
        public string CodeColumnID { get; set; }
        public string ValueColumnID { get; set; }
        public string CreateDateTime { get; set; }
        public List<Scheme> Scheme { get; set; }
        public DataTable DataSource { get; set; }
    }

    public class Scheme
    {
        public string ColumnID { get; set; }
        public string ColumnText { get; set; }
        public bool? HiddenYN { get; set; }
    }
}
