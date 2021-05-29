using System.ComponentModel;
using System.Runtime.Serialization;

namespace Qrame.Core.Library.MessageContract.Contract
{
    [DataContract(Namespace = "http://www.tempuri.com/types/")]
    public partial class TH
    {
        [DataMember]
        [Description("회사/부서등 조직ID")]
        public string TRM_BRNO { get; set; }

        [DataMember]
        [Description("사용자ID")]
        public string OPR_NO { get; set; }

        [DataMember]
        [Description("거래차수")]
        public int? RLPE_SQCN { get; set; }

        [DataMember]
        [Description("거래화면번호")]
        public string TRN_SCRN_CD { get; set; }

        [DataMember]
        [Description("프로그램ID")]
        public string PGM_ID { get; set; }

        [DataMember]
        [Description("업무ID")]
        public string BIZ_ID { get; set; }

        [DataMember]
        [Description("명령 구분 C - [Console], D - [DataTransaction], A - [ApiServer], F - [FileServer]")]
        public string CMD_TYPE { get; set; }

        [DataMember]
        [Description("거래코드")]
        public string TRN_CD { get; set; }

        [DataMember]
        [Description("기능코드")]
        public string FUNC_CD { get; set; }

        [DataMember]
        [Description("데이터 포맷 구분")]
        public string DAT_FMT { get; set; }

        [DataMember]
        [Description("대량데이터처리구분")]
        public string LQTY_DAT_PRC_DIS { get; set; }

        [DataMember]
        [Description("시뮬레이션거래구분코드")]
        public string SMLT_TRN_DSCD { get; set; }

        [DataMember]
        [Description("유무통구분코드")]
        public string EXNK_DSCD { get; set; }

        [DataMember]
        [Description("마스킹비대상거래여부")]
        public string MSK_NTGT_TRN_YN { get; set; }

        [DataMember]
        [Description("암호화 구분코드 (P:평문,C:압축,E:암호화,M:압축 및 암호화)")]
        public string CRYPTO_DSCD { get; set; }

        [DataMember]
        [Description("암호화 키수급 코드 3자리, CRYPT_DSCD가 E, M이면 필수")]
        public string CRYPTO_KEY { get; set; }
    }
}
