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
    public class LeaveSettlementVM
    {
        public bool EditFlag { get; set; }
        public bool SaveFlag { get; set; }
        public string ErrorMessage { get; set; }        
        public string CMPYCODE { get; set; }        
        public string PRLS001_UID { get; set; }
        public string PRLS001_CODE { get; set; }
        public string DIVISION { get; set; }
        public string COUNTRY { get; set; }
        public string PRLR001_CODE { get; set; }

        public List<SelectListItem> LeaveList { get; set; }
        public string Empcode { get; set; }

        public string EmpName { get; set; }

        public List<SelectListItem> EmpCodeList { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]


        //public List<SelectListItem> EmployeeTypeList { get; set; }
        public DateTime Entry_Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LLSdate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DR_Date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LStartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LendDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? JoiningDate { get; set; }
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? salary_effect_date { get; set; }
        public decimal? Net_Pay { get; set; }

        public string UserName { get; set; }

    }
    
}
