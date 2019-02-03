using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
  public partial class SalaryProcessDetails
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string BranchCode { get; set; }
        public int Sno { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public DateTime Dates { get; set; }
        public decimal WorkingDay { get; set; }
        public decimal Present { get; set; }
        public decimal LossDays { get; set; }
        public decimal Absent { get; set; }
        public decimal Leaves { get; set; }
        public decimal WeeklyOff { get; set; }
        public decimal Holiday { get; set; }
        public decimal NormalOTHrs { get; set; }
        public decimal NormalOTRate { get; set; }
        public decimal HolidayOTHrs { get; set; }
        public decimal HolidayOTRate { get; set; }
        public decimal WeeklyOffOTHrs { get; set; }
        public decimal WeeklyOffOTRate { get; set; }
        public decimal ExtraOTHrs { get; set; }
        public decimal ExtraOTRate { get; set; }
        public decimal TotalEarning { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetSalary { get; set; }
        public decimal PFAmountOn { get; set; }
        public decimal Emp_PFPerc { get; set; }
        public decimal Emp_PFAmount { get; set; }
        public decimal Empr_PFPerc { get; set; }
        public decimal Empr_PFAmount { get; set; }
        public decimal PTAmountOn { get; set; }
        public decimal PTPerc { get; set; }
        public decimal PTAmount { get; set; }
        public decimal ESICAmountOn { get; set; }
        public decimal Emp_ESICPerc { get; set; }
        public decimal Emp_ESICAmount { get; set; }
        public decimal Empr_ESICPerc { get; set; }
        public decimal Empr_ESICAmount { get; set; }
        public decimal LWFAmountOn { get; set; }
        public decimal LWFPerc { get; set; }
        public decimal LWFAmount { get; set; }
        public decimal IncomeTax { get; set; }
        public decimal SalaryPaidOn { get; set; }
        public int SalaryProcessed { get; set; }
        public decimal LoanDeduction { get; set; }
        public int ESICPaid { get; set; }
        public string TDSChallanNo { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string FExtraOTHrs { get; set; }
        public string FExtraOTRate { get; set; }
        public string CRACC { get; set; }
        public string SickLeave { get; set; }
        public string TotalAddition { get; set; }
        public string ActualBas { get; set; }

    }
}
