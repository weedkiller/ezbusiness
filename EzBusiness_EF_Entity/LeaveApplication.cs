using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public partial class LeaveApplication
    {

        public string PRLR001_CODE { get; set; }
        public string CmpyCode { get; set; }
        public string COUNTRY { get; set; }
        public string DIVISION { get; set; }


        public string Branch { get; set; }
        public string Dept { get; set; }
        public DateTime? Entry_Dates { get; set; }
        public string EmpCode { get; set; }

        public string EmpName { get; set; }
        public DateTime? JoiningDate { get; set; }
        public string LeaveType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public DateTime? ResumeDate { get; set; }

        public string LeaveDays { get; set; }
        public string Remarks { get; set; }
        public string TotalBalance { get; set; }
        public string TotalApplied { get; set; }
        public string TotalSanctioned { get; set; }
        public string ApprovalYN { get; set; }
        public string Status { get; set; }
        public string SendMail { get; set; }
        public string IsEncash { get; set; }

        public DateTime Fdate { get; set; }
        public DateTime Tdate { get; set; }


    }
}
