using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class Profession
    {
        public string CmpyCode { get; set; }
        public string ProfCode { get; set; }
        public string ProfName { get; set; }

        public string UniCodeName { get; set; }

        public string ProfType { get; set; }

        public Int32 srno { get; set; }
    }
}
