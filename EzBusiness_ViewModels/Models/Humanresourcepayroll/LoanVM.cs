using System.Collections.Generic;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class LoanVM
    {
        public string CmpyCode { get; set; }
        public string PRLM001_CODE { get; set; }
        public string COUNTRY { get; set; }

        public string Name { get; set; }
        public string Act_code { get; set; }
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }
        public List<LoanNew> LoanNew { get; set; }
        public LoanNew LoanDetail { get; set; }

        public List<string> Drecord { get; set; }

        public string UserName { get; set; }
    }
    public class LoanNew
    {
        public string CmpyCode { get; set; }
        public string PRLM001_CODE { get; set; }
        public string COUNTRY { get; set; }

        public string Name { get; set; }
        public string Act_code { get; set; }

    }
}
