using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF
{
   public partial class FFM_VESSEL
    {

        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
     
        public string FFM_VESSEL_CODE { get; set; }
        public string NAME { get; set; }
        public string FLAG { get; set; }
        public string SCACCODE { get; set; }
        public string CARRIER { get; set; }
        public string VESSEL_TYPE { get; set; }
        public string COUNTRY { get; set; }


    }
}
