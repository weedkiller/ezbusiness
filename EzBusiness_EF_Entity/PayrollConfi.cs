using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class PayrollConfi
    {
       // public string PRCNF001_UID { get; set; }
        public string PRCNF001_CODE { get; set; }
        public string CMPYCODE { get; set; }
        public string COUNTRY { get; set; }
        public int SRNO { get; set; }
        public int FINYEAR { get; set; }
        public int FINMONTH { get; set; }
        public DateTime? FROM_DATE { get; set; }
        public DateTime? TO_DATE { get; set; }
        public string LOCK { get; set; }

        public int NOOFDAYS { get; set; }

    }
}
