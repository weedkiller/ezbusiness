using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class LeaveSetSalarypending
    {
        public string CmpyCode { get; set; }
        public string LsNo { get; set; }
        public int Slno { get; set; }
        public string EmpCode { get; set; }
        public int Tmonth { get; set; }
        public int Tyear { get; set; }
        public DateTime? Dates { get; set; }
        public int Paid { get; set; }
        public decimal? NetPay { get; set; }

    }

}
