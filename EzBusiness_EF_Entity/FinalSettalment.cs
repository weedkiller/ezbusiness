using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class FinalSettalment
    {
        public string Cmpycode { get; set; }
        public string PRFSET001_code { get; set; }
        public string EmpCode { get; set; }
        public Nullable<System.DateTime> Dates { get; set; }
        public string Reason { get; set; }
        public Nullable<System.DateTime> SettledDate { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<System.DateTime> DateofRelease { get; set; }
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
       // public decimal OTWorkedHrs { get; set; }
        public int NoOfDays { get; set; }
        public int LNoOfDaysWkd { get; set; }
        public Nullable<System.DateTime> DutyResume { get; set; }
        public decimal LeaveCF { get; set; }
        public decimal LeaveBF { get; set; }
        public decimal LAppDays { get; set; }
        public decimal LeaveSalary { get; set; }
        public decimal PSalary { get; set; }
        public Nullable<System.DateTime> LLSDate { get; set; }
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
      //  public string NoticeYN { get; set; }
        public string GratuityAc { get; set; }
        public string LeaveAc { get; set; }
        public string UnpaidAc { get; set; }
        public string AccrualAc { get; set; }
       // public string JvNumber { get; set; }
        public decimal LoanDeduction { get; set; }
        public decimal OtherDeduction { get; set; }
        public string EmpName { get; set; }

        public DateTime Fdate { get; set; }
        public DateTime Tdate { get; set; }
    }


    public partial class FinalSettI
    {

        public string Cmpycode { get; set; }       
        public string EmpCode { get; set; }              
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<System.DateTime> LastRetDate { get; set; }
        public Nullable<System.DateTime> LLSDate { get; set; }
        
        public decimal BalLeave { get; set; }


     
        public decimal Basic { get; set; }
        
        public decimal Housing { get; set; }
        public decimal Tele_Allow { get; set; }
        public decimal Other_Allow { get; set; }
        public decimal Food { get; set; }
        public decimal Conveyance { get; set; }
        public decimal LBasic { get; set; }
        
    }


    public partial class FinalSetII
    {
        public double  totaldays { get; set; }
        public double absent { get; set; }
        public double totalnowek { get; set; }
        public double GratuityEntitled { get; set; }
        public double Gratuity { get; set; }
		 public double loanamt { get; set; }
        public double deduct { get; set; }
        public double lTotalnoday { get; set; }
        public double labsentday { get; set; }
        public double lTotalnoWeekday { get; set; }
        public double TotalEntiled { get; set; }
        
        public double LAppDays { get; set; }
        public double TransportL { get; set; }
		 public double TeleL { get; set; }
        public double FoodL { get; set; }
        public double HousingL { get; set; }
        public double BasicL { get; set; }
         public double Other_AllowL { get; set; }
        public double LeaveSalary { get; set; }
        public double NetAmount { get; set; }
    }
    }

