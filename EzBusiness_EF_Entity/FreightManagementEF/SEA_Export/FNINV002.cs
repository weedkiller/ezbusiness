using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF.SEA_Export
{
    public class FNINV002
    {
        public string cmpycode { get; set; }
        public string BRANCHCODE { get; set; }
        public string INV001_CODE { get; set; }
        public decimal LINE_NO { get; set; }
        public int O_CHARGE_UID { get; set; }
        public string ITEMCODE { get; set; }
        public string Item_Description { get; set; }
        public string UNIT_TYPE { get; set; }
        public decimal NO_OF_QTY { get; set; }
        public decimal RATE_PER_QTY { get; set; }
        public string COA_CODE { get; set; }
        public string SUBLEDGER_CODE { get; set; }
        public string Location_Code { get; set; }
        public string O_CURR_CODE { get; set; }
        public decimal O_CURR_RATE { get; set; }
        public decimal O_CURR_AMT { get; set; }
        public decimal O_LOCAL_AMT { get; set; }
        public decimal O_VAT_LOCAL_AMT { get; set; }
        public decimal O_VAT_CURR_AMT { get; set; }
        public string VAT_CODE { get; set; }
        public decimal VAT_PER { get; set; }
        public string VAT_GL_CODE { get; set; }
        public decimal V_CURR_AMT { get; set; }
        public decimal V_LOCAL_AMT { get; set; }
        public decimal V_VAT_CURR_AMT { get; set; }
        public decimal V_VAT_LOCAL_AMT { get; set; }
        public decimal V_NET_CURR_AMT { get; set; }
        public decimal V_NET_LOCAL_AMT { get; set; }
        public string Narration { get; set; }
        public string NOTE { get; set; }
        public decimal Ret_Qty { get; set; }
        public decimal Cost_per_qty { get; set; }
        
    }
}
