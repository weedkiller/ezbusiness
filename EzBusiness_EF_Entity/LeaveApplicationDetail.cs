using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public partial class LeaveApplicationDetail
    {
        public string PRLR001_CODE { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string LeaveDays { get; set; }
    }
}
