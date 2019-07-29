using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF.SEA_Export
{
    public class FNINV002
    {

        
        public string COMPANYCODE { get; set; }
        public string BRANCHCODE { get; set; }
        public string INV001_CODE { get; set; }
        public string JV_NO { get; set; }
        public Decimal LINE_NO { get; set; }
        public string ITEMCODE { get; set; }
        public int O_CHARGE_UID { get; set; }
        public string UNIT_TYPE { get; set; }
        public Decimal NO_OF_QTY { get; set; }
        public Decimal RATE_PER_QTY { get; set; }
        public string COA_CODE { get; set; }
        public string SUBLEDGER_CODE { get; set; }
        public string Location_Code { get; set; }
        public string O_CURR_CODE { get; set; }
        public Decimal O_CURR_RATE { get; set; }
        public Decimal O_CURR_AMT { get; set; }
        public Decimal O_LOCAL_AMT { get; set; }
        public Decimal O_VAT_LOCAL_AMT { get; set; }
        public string VAT_CODE { get; set; }
        public Decimal VAT_PER { get; set; }
        public Decimal V_CURR_AMT { get; set; }
        public Decimal V_LOCAL_AMT { get; set; }
        public Decimal V_VAT_CURR_AMT { get; set; }
        public Decimal V_VAT_LOCAL_AMT { get; set; }
        public Decimal V_NET_CURR_AMT { get; set; }
        public Decimal V_NET_LOCAL_AMT { get; set; }
        public string Narration { get; set; }
        public string NOTE { get; set; }
        public Decimal Ret_Qty { get; set; }
        public Decimal Cost_per_qty { get; set; }
    }
}
