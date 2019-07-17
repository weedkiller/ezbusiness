﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF.SEA_Export
{
   public partial class FF_QTN001
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }       
        public string FF_QTN001_CODE { get; set; }
        public string CUST_CODE { get; set; }
        public string CONTACT { get; set; }
        public string TELEPHONE { get; set; }
        public string EMAIL { get; set; }
        public string CUSTOMER_REF { get; set; }
        public string PICKUP_PLACE { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
        public string FND { get; set; }
        public string MOVE_TYPE { get; set; }
        public string REF_NO { get; set; }
        public string VESSEL { get; set; }
        public string VOYAGE { get; set; }
        public string CARRIER { get; set; }      
        public DateTime EFFECT_FROM { get; set; }
        public DateTime EFFECT_UPTO { get; set; }
        public string DEPARTMENT { get; set; }
        public Decimal Total_Cost { get; set; }
        public Decimal Total_Billed { get; set; }
        public Decimal Total_Profit { get; set; }

        public string PZIP { get; set; }

        public string PSTATE { get; set; }
        public string FDZIP { get; set; }

        public string FDSTATE { get; set; }

        public string Commodity_code { get; set; }

        public string FNMBRANCH_CODE { get; set; }
    }

}
