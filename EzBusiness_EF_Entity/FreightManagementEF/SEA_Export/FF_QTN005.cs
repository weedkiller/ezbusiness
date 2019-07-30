using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF.SEA_Export
{
   public partial class FF_QTN005
    {      
        public string FF_QTN001_CODE { get; set; }
        public string CMPYCODE { get; set; }
        public int Sno { get; set; }
        public string Crg_code { get; set; }
        public string Crg_name { get; set; }
        public string Income_GL_Code { get; set; }
        public string Expense_GL_Code { get; set; }
        public string Unit_Code { get; set; }
        public string Cust_code { get; set; }
        public string Cust_name { get; set; }
        public string Cust_Ctrl_Act { get; set; }
        public string Cust_Curr_Code { get; set; }
        public Decimal Cust_Curr_Rate { get; set; }
        public Decimal Cust_Rate { get; set; }
        public Decimal Cust_Total_amt { get; set; }
        public Decimal Cust_Var_Amt { get; set; }
        public Decimal Cust_Net_Amt { get; set; }
        public Decimal Cust_Local_amt { get; set; }
        public string PAY_MODE { get; set; }
        public string Vend_code { get; set; }
        public string Vend_name { get; set; }
        public string Vend_Ctrl_Act { get; set; }
        public string Vend_Curr_Code { get; set; }
        public Decimal Vend_Curr_Rate { get; set; }
        public Decimal Vend_Rate { get; set; }
        public Decimal Vend_Total_amt { get; set; }
        public Decimal VendVar_Amt { get; set; }
        public Decimal Vend_Net_Amt { get; set; }
        public Decimal Vend_Local_amt { get; set; }
        public Decimal No_of_qty { get; set; }

        public string BRANCH_CODE { get; set; }

    }
}
