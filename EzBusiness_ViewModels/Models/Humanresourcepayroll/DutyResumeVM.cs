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
    public class DutyResumeVM
    {
        public string Cmpycode { get; set; }
        public string PRDR001_CODE { get; set; }
        public string PRLR001_CODE { get; set; }


        //public string LsNo { get; set; }
        public List<SelectListItem> LsNoList { get; set; }
        public string country { get; set; }
        public string division { get; set; }
        public string PRLS001_CODE { get; set; }
        public string EmpCode { get; set; }
        public List<SelectListItem> EmpCodeList { get; set; }
       
        public string Actual_Leave_Type { get; set; }
        public string Duty_Rm_type { get; set; }


        public List<SelectListItem> Rm_TypeList { get; set; }

        public string Approve_Days { get; set; }

        [DataType(DataType.Currency)]
        public string Excess_Days_plus_minus { get; set; }
        [DataType(DataType.Currency)]
        public string Approve_Days_in_full { get; set; }
        [DataType(DataType.Currency)]
        public string Approve_Days_in_Half { get; set; }
      
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ResumeDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? JoiningDate { get; set; }

        



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

       
            
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public string BalanceLeave { get; set; }


        public int oldLeavedays { get; set; }

        public string UserName { get; set; }
    }
}
