using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF
{
  public partial  class FNM_CURRENCY
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public Decimal FNM_CURRENCY_UID { get; set; }
        public string CURRENCY_CODE { get; set; }
        public string CURRENCY_NAME { get; set; }
        public string MASTER_STATUS { get; set; }
       
        public string Note { get; set; }

    }

}
