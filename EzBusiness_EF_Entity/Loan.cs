using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class Loan
    {
        public string CmpyCode { get; set; }
        public string PRLM001_CODE { get; set; }
        public string COUNTRY { get; set; }

        public string Name { get; set; }
        public string Act_code { get; set; }

        public Int32 srno { get; set; }
    }
}
