using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF.SEA_Export
{
   public class FNINV001
    {


        public string FNINV001_CODE { get; set; }
        public string cmpycode { get; set; }
        public string BRANCHCODE { get; set; }
        public string INV_TYPE { get; set; }
        public string INV_STATUS { get; set; }
            
        public DateTime INV_DATE { get; set; }
        public DateTime Post_Date { get; set; }        
        public string NOTES { get; set; }
        public string NARRATION { get; set; }
        public string CREATED_BY { get; set; }

        public DateTime CREATED_ON { get; set; }
        
        public string UPDATED_BY { get; set; }

        public DateTime UPDATED_ON { get; set; }
        
        public string COA_CODE { get; set; }
        public string SUBLEDGER_CODE { get; set; }
        public string CURRENCY_CODE { get; set; }
        public Decimal CURRENCY_RATE { get; set; }
        public Decimal VAT_CURRENCY_AMT { get; set; }
        public Decimal VAT_LOCAL_AMT { get; set; }
        public Decimal CURRENCY_AMT { get; set; }
        public Decimal LOCAL_AMT { get; set; }
        public Decimal NET_CURRENCY_AMT { get; set; }
        public Decimal NET_LOCAL_AMT { get; set; }
        public string BILLING_ADDRESS { get; set; }
        public string SUPPLIER_JV_NO { get; set; }

        public DateTime SUPPLIER_JV_DATE { get; set; }
        
        public string SUPPLIER_GRN_NO { get; set; }
        public string RECEIVED_PAID_NAME { get; set; }
        public string UNPOSTED_NOTE { get; set; }
        public string Customer_Code { get; set; }
        public string Customer_COA { get; set; }
        public string Received_By { get; set; }
        public string SalesMan { get; set; }
        public string LOCATION_CODE { get; set; }
        public string vessel_code { get; set; }
        public string BL_CODE { get; set; }
        public string BL_REF_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }
    }
}
