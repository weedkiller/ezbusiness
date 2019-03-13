using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class DutyResume
    {

        public string Cmpycode { get; set; }
        public string PRDR001_CODE { get; set; }
        public string PRLR001_CODE { get; set; }
        public string country { get; set; }
        public string division { get; set; }
        public string PRLS001_CODE { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public DateTime ResumeDate { get; set; }
        public string Actual_Leave_Type { get; set; }
        public string Duty_Rm_type { get; set; }
        public string Approve_Days { get; set; }
        public string Excess_Days_plus_minus { get; set; }
        public string Approve_Days_in_full { get; set; }
        public string Approve_Days_in_Half { get; set; }
        public Int32 SrNo { get; set; }
        public DateTime Fdate { get; set; }
        public DateTime Tdate { get; set; }

    }
}
