using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class EmpShift
    {
        public string PRSFT003_code { get; set; }
        public string PRSFT002_code { get; set; }
        public string PRSFT001_code { get; set; }
        public string EmpCode { get; set; }
        public string Remarks { get; set; }
        public int SNO { get; set; }
        public string CmpyCode { get; set; }

        public string Empname { get; set; }
        public string ShiftName { get; set; }
    }
}
