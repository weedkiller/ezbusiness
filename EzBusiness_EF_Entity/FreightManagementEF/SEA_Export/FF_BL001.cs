using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF.SEA_Export
{
  public partial  class FF_BL001
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }

        public string TRANS_TYPE { get; set; }
        public string CMPYCODE { get; set; }
        public string JOB_TYPE { get; set; }
        public string FF_BL001_CODE { get; set; }
        public DateTime FF_BL001_DATE { get; set; }
        public string FF_QTN001_CODE { get; set; }

        public string FF_BOK001_CODE { get; set; }
        public string BILL_TO { get; set; }
        public string SHIPPER { get; set; }
        public string CONSIGNEE { get; set; }
        public string FORWARDER { get; set; }
        public string PICKUP_PLACE { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string FND { get; set; }
        public string PLACE_OF_RCPT { get; set; }
        public string MOVE_TYPE { get; set; }
        public string DELIVERY_AT { get; set; }
        public string REF_NO { get; set; }
        public string VESSEL { get; set; }
        public string VOYAGE { get; set; }
        
 
            public DateTime ETD { get; set; }
        public DateTime ETA { get; set; }
        public string CARRIER { get; set; }
        public string DEPARTMENT { get; set; }
        public Decimal Total_Cost { get; set; }
        public Decimal Total_Billed { get; set; }
        public Decimal Total_Profit { get; set; }
    }
}
