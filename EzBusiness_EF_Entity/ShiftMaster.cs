using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial   class ShiftMaster
    {
        public Int32 srno { get; set; }
        public string PRSFT001_code { get; set; }
        public string country { get; set; }
        public string division { get; set; }
        public string CmpyCode { get; set; }
        public string ShiftName { get; set; }
        public string StTime { get; set; }
        public string EdTime { get; set; }

        public DateTime Fdate { get; set; }
        public DateTime Tdate { get; set; }

    }
}
