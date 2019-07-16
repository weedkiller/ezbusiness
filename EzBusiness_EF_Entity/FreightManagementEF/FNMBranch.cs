using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF
{
   public partial class FNMBranch
    {
        public int FNMBRANCH_UID { get; set; }
        public string FNMBRANCH_CODE { get; set; }
        public string CMPYCODE { get; set; }
        public string DESCRIPTION { get; set; }
        public int SNO { get; set; }
        public string PRINTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string WEBSITE { get; set; }
        public string MOBILE { get; set; }
        public string CURRENCY { get; set; }
        public string COUNTRY { get; set; }
        public string STATE { get; set; }

        public string DIVISION { get; set; }

    }
}
