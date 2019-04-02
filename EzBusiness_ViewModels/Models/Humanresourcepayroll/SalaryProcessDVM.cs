using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
   public class SalaryProcessDVM
    {
        public Int64 PRSPD001_UID { get; set; }
        public string PRSPD001_CODE { get; set; }
        public string UserName { get; set; }
        public string CMPYCODE { get; set; }
        public string COUNTRY { get; set; }
        public string DIVISION { get; set; }
        public DateTime SalProcess_Date { get; set; }
        public List<SelectListItem> DivisionList { get; set; }
        public string DivisionName { get; set; }
        public string WORKLOCATION { get; set; }
        public Int32 TYEAR { get; set; }
        public Int32 TMONTH { get; set; }
        public Int64 PAIDTYPE { get; set; }
        public bool Flag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public bool SaveFlag { get; set; }
        public List<SalaryprocesspaymentDetails> salaryList { get; set; }
        public SalaryprocesspaymentDetails salarypayListItems { get; set; }
    }
   public class SalaryprocesspaymentDetails
    {
        public Int64 PRSPD002_UID { get; set; }
        public string PRSPD001_CODE { get; set; }
        public string EMPCODE { get; set; }
        public string EMPNAME { get; set; }
        public string BANKCODE { get; set; }
        public string BANKName { get; set; }
        public string BRANCHCODE { get; set; }
        public string BANkBrachName { get; set; }
        public string ACCOUNTNO { get; set; }
        public double AMOUNT { get; set; }
        public string PAID_TYPE { get; set; }
        public Int64 srno { get; set; }
        public bool Flag { get; set; }

    }

}
