using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF
{
   public partial class FFM_CRG_Group
    {

        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
      
        public string FFM_CRG_GROUP_CODE { get; set; }
        public string NAME { get; set; }
        public string DISPLAY_STATUS { get; set; }
    }
}
