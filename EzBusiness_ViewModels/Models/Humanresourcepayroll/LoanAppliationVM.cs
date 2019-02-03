using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class LoanAppliationVM
    {
        public string PRLA001_CODE { get; set; }
        public string COUNTRY { get; set; }
        public string CmpyCode { get; set; }
        public string EmpCode { get; set; }
        public List<SelectListItem> EmpCodeList { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Entry_Date { get; set; }
        public decimal LoanAmount { get; set; }
        public int NoOfInstalments { get; set; }
        public decimal Instalment { get; set; }
        public decimal Deduction { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string AutoDeductionYN { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DeductionStartDate { get; set; }
        public string Act_code { get; set; }
        public string LoanType { get; set; }
        //PRLM001_CODE
        public List<SelectListItem> LoanTypeList { get; set; }

        public string ApprovalYN { get; set; }
        public decimal AppliedAmt { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }

        public string UserName { get; set; }
    }
}
