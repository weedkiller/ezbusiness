using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF.SEA_Export
{
  public partial  class FF_BOK003
    {

        
public string CMPYCODE { get; set; }
        public string FF_BOK001_CODE { get; set; }
        public int sno { get; set; }
        public string Pkg_No { get; set; }

        public int No_of_qty { get; set; }
        
public string unit_type { get; set; }
        public Decimal Height { get; set; }
        public Decimal Width { get; set; }
        public string Act_LBS { get; set; }
public string inside_Unit { get; set; }
        public Decimal Volume { get; set; }
        public Decimal Dime_weight { get; set; }
       
    }
}
