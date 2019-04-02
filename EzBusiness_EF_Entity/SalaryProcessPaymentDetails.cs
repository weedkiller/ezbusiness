using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public class SalaryProcessPaymentDetails
    {
        public Int64 PRSPD002_UID { get; set; }
        public string PRSPD001_CODE { get; set; }
        public string EMPCODE { get; set; }
        public string EMPNAME { get; set; }
        public string BANKCODE { get; set; }
        public string BRANCHCODE { get; set;}
        public string ACCOUNTNO { get; set; }
        public double AMOUNT { get; set; }
        public string PAID_TYPE { get; set; }
       
        public string CMPYCODE { get; set; }
        public string COUNTRY { get; set; }
        public string DIVISION { get; set; }
        public string WORKLOCATION { get; set; }
        public Int32 TYEAR { get; set; }
        public Int32 TMONTH { get; set; }
        public Int64 PAIDTYPE { get; set; }
    }
}
