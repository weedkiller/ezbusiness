using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public partial class GetEmpBankTrf
    {
        public int SrNo	{ get; set; }
        public string PRSPD001_CODE { get; set; }
        public string EMPCODE { get; set; }
        public string EMPNAME { get; set; }
        public string ACCOUNTNO { get; set; }
        public decimal AMOUNT { get; set; }
        public string BANKCODE { get; set; }
        public string Bank_name { get; set; }
        //public int TMONTH { get; set; }
        //public int TYEAR { get; set; }
        //public string CMPYCODE { get; set; }

    }
}
