using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public partial class MonthlyAdddedMst
    {

        public string PRADN001_CODE { get; set; }
        public string COUNTRY { get; set; }
        public string CmpyCode { get; set; }
        public DateTime Entry_Date { get; set; }
        public int TYear { get; set; }
        public int TMonth  { get; set; }
    }
}
