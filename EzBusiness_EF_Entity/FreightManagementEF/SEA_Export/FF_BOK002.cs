using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF.SEA_Export
{
   public partial class FF_BOK002
    {
        
public string FF_BOK001_CODE { get; set; }
        public string CMPYCODE { get; set; }
        public int sno { get; set; }
        public string Container { get; set; }
        public string Cont_Type { get; set; }
        public int Seal1 { get; set; }
        public int No_of_qty { get; set; }
        public string Contents { get; set; }
        public Decimal LBS { get; set; }
        public Decimal KG { get; set; }
        public Decimal CFT { get; set; }
        public Decimal CBM { get; set; }
       
    }
}
