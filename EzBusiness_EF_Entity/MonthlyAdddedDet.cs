using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public partial  class MonthlyAdddedDet
    {        
        public string PRADN001_CODE { get; set; }
        public string CmpyCode { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string ADN_Amount { get; set; }
        public int ADN_Act_code { get; set; }
        public string T_type { get; set; }
        public string Remarks { get; set; }
        public DateTime EntryDate { get; set; }

        public string ADNActcode { get; set; }

        public DateTime Fdate { get; set; }
        public DateTime Tdate { get; set; }

        public Int32 srno { get; set; }

    }
}
