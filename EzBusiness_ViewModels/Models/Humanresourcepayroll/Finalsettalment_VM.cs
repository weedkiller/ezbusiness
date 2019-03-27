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
    public class Finalsettalment_VM
    {
        public bool EditFlag { get; set; }
        public bool SaveFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string Cmpycode { get; set; }
        public string PRFSET001_code { get; set; }
        public string EmpCode { get; set; }

        public string EmpName { get; set; }

        public List<SelectListItem> EmpCodeList { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Dates { get; set; }
        public string Reason { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? SettledDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? JoiningDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateofRelease { get; set; }
        public int NoOfDaysSuspended { get; set; }
        public int TotalNoOfDays { get; set; }
        public int NoOfDaysWkd { get; set; }
        public int GratuityEntitled { get; set; }
        public decimal Gratuity { get; set; }
        public decimal Addition { get; set; }
        public decimal Deduction { get; set; }
        public decimal NetAmount { get; set; }
        public string Status { get; set; }
        public string Stype { get; set; }
        public string TerType { get; set; }
        public decimal Basic { get; set; }
        public string SalType { get; set; }
        public string Remarks { get; set; }
        public decimal Absent { get; set; }
        public decimal DeductionDays { get; set; }
        public string UserCode { get; set; }
        public decimal Housing { get; set; }
        public decimal Tele_Allow { get; set; }
        public decimal Other_Allow { get; set; }
        public decimal Food { get; set; }
        public decimal Conveyance { get; set; }
      //  public decimal OTWorkedHrs { get; set; }
        public int NoOfDays { get; set; }
        public int LNoOfDaysWkd { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DutyResume { get; set; }
        public decimal LeaveCF { get; set; }
        public decimal LeaveBF { get; set; }
        public decimal LAppDays { get; set; }
        public decimal LeaveSalary { get; set; }
        public decimal PSalary { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LLSDate { get; set; }
        public decimal LBasic { get; set; }
        public decimal LeaveEntiled { get; set; }
        public decimal TotalEntiled { get; set; }
        public int LDeductionDays { get; set; }
        public int LAbsent { get; set; }
        public string ApprovalYN { get; set; }
        public string PostYN { get; set; }
        public decimal BasicL { get; set; }
        public decimal HousingL { get; set; }
        public decimal Tele_AllowL { get; set; }
        public decimal Other_AllowL { get; set; }
        public decimal FoodL { get; set; }
        public decimal ConveyanceL { get; set; }
       // public string NoticeYN { get; set; }
        public string GratuityAc { get; set; }
        public string LeaveAc { get; set; }
        public string UnpaidAc { get; set; }
        public string AccrualAc { get; set; }
     //   public string JvNumber { get; set; }
        public decimal LoanDeduction { get; set; }
        public decimal OtherDeduction { get; set; }

        public string UserName { get; set; }
    }
}
