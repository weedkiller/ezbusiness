using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF
{
    public partial class CRGCodeDropTbl
    {
        public string Code { get; set; }
        public string CodeName { get; set; }

        public string VAT_CODE { get; set; }
        public decimal VAT_PER { get; set; }

        public string VAT_GL_CODE { get; set; }

        public string COA_CODE { get; set; }
    }
}
