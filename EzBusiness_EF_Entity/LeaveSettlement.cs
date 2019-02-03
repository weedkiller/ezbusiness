using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class LeaveSettlement
    {
        public string PRLS001_UID { get; set; }
        public string PRLS001_CODE { get; set; }
        public string DIVISION { get; set; }
        public string COUNTRY { get; set; }
        public string PRLR001_CODE { get; set; }
        public string Empcode { get; set; }
       
        public DateTime? Entry_Date { get; set; }
       
        public DateTime? LLSdate { get; set; }
       
        public DateTime? DR_Date { get; set; }
       
        public DateTime? LStartDate { get; set; }
        
        public DateTime? LendDate { get; set; }
        public decimal? Sanctioned_Days { get; set; }
        public decimal? Total_days { get; set; }
        public decimal? Total_worked_Days { get; set; }
        public decimal? Total_LE_Days { get; set; }
        public decimal? LB_CF_Days { get; set; }
        public decimal? Leave_Salary { get; set; }
        public decimal? Addition_amt { get; set; }
        public decimal? Deduction_Amt { get; set; }
        public decimal? Ticket_amt { get; set; }
        public string Ticket_Paid { get; set; }
        public decimal? Pending_Salary { get; set; }
        public decimal? Advance_Salary { get; set; }
        public decimal? Advance_Paid { get; set; }
        public decimal? Actual_Salary { get; set; }

       
        public DateTime? salary_effect_date { get; set; }
        public decimal? Net_Pay { get; set; }
        public DateTime Fdate { get; set; }
        public DateTime Tdate { get; set; }
    }
}
