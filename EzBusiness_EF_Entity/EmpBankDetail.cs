using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class EmpBankDetail
    {
        public string PRBM003_CODE { get; set; }
        public DateTime Entry_Date { get; set; }
        public string CmpyCode { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string PRBM001_code { get; set; }

        public string PRBM002_code { get; set; }
        public string Account_no { get; set; }
        public string EBAN_no { get; set; }
        public string Remarks { get; set; }

    }
}
