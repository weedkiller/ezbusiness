using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class LoanAppliation
    {
        public string PRLA001_CODE { get; set; }
        public string COUNTRY { get; set; }
        public string CmpyCode { get; set; }
        public string EmpCode { get; set; }
      
        public DateTime? Entry_Date { get; set; }
        public decimal LoanAmount { get; set; }
        public int NoOfInstalments { get; set; }
        public decimal Instalment { get; set; }
        public decimal Deduction { get; set; }
        public decimal Balance { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public string AutoDeductionYN { get; set; }
       
        public DateTime? DeductionStartDate { get; set; }
        public string Act_code { get; set; }
        public string LoanType { get; set; }
        public string ApprovalYN { get; set; }
        public decimal AppliedAmt { get; set; }

        public string EmpName { get; set; }

        public DateTime Fdate { get; set; }
        public DateTime Tdate { get; set; }
        
        public Int32 SrNo { get; set; }
    }
}
