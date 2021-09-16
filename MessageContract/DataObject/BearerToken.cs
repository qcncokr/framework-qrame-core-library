using System.Collections.Generic;

namespace Qrame.CoreFX.Library.MessageContract.DataObject
{
	public partial class BearerToken
    {
        public string TokenID { get; set; }
        public string IssuerName { get; set; }
        public Claim Claim { get; set; }
        public dynamic Addtional { get; set; }
    }

    public partial class Claim
    {
        public List<string> AllowApplications { get; set; }
        public List<string> AllowProjects { get; set; }
        public string CertificateTokenID { get; set; }
        public string CertificatePinKey { get; set; }
        public List<string> Roles { get; set; }
    }
}
