using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class Leave_App_VW
    {  

        public string PRLR001_CODE { get; set; }
        public string CmpyCode { get; set; }
        public string COUNTRY { get; set; }
        public string DIVISION { get; set; }
        public string Branch { get; set; }
        public string Dept { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Entry_Dates { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoiningDate { get; set; }
        public string LeaveType { get; set; }
        public List<SelectListItem> LeaveTypeList { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string LeaveDays { get; set; }
        public string Remarks { get; set; }
        public string TotalBalance { get; set; }
        public string TotalApplied { get; set; }
        public string TotalSanctioned { get; set; }

        public string oldLeavedays { get; set; }
        public string ApprovalYN { get; set; }
        public string Status { get; set; }
        public string SendMail { get; set; }
        public string IsEncash { get; set; }
        public string EmpName { get; set; }
        public string EmpCode { get; set; }
        public List<SelectListItem> EmpCodeList { get; set; }
        public bool IsEditMode { get; set; }
        public bool IsSavedFlag { get; set; }
        public string ErrorMessage { get; set; }
        public List<LeaveApplicationDetail> LeaveApplicationnews { get; set; }       
        public LeaveApplicationnews LeaveDetail { get; set; }

        public string UserName { get; set; }
    }
        public class LeaveApplicationnews
        {
            public string PRLR001_CODE { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string LeaveDays { get; set; }
        }
}
