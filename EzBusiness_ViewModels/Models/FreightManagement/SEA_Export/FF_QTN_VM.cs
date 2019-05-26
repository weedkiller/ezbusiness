using EzBusiness_EF_Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.FreightManagement.SEA_Export
{
   public class FF_QTN_VM
    {
        public string CREATED_BY { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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
        public List<SelectListItem> MoveCodeList { get; set; }
        public string REF_NO { get; set; }
        public string VESSEL { get; set; }
        public string VOYAGE { get; set; }
        public string CARRIER { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EFFECT_FROM { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EFFECT_UPTO { get; set; }
        public string DEPARTMENT { get; set; }

        public List<SelectListItem> DEPARTMENTList { get; set; }
        public List<SelectListItem> CLAUSEList { get; set; }
        public List<SelectListItem> CRG_002List { get; set; }

        public List<SelectListItem> SLList { get; set; }

        public List<SelectListItem> VOYAGEList { get; set; }

        public List<SelectListItem> VESSELList { get; set; }

        public Decimal Total_Cost { get; set; }
        public Decimal Total_Billed { get; set; }
        public Decimal Total_Profit { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
    
        public FF_QTN002New FF_QTN002 { get; set; }
        public List<FF_QTN002New> FF_QTN002Detail { get; set; }
        public FF_QTN003New FF_QTN003 { get; set; }
        public List<FF_QTN003New> FF_QTN003Detail { get; set; }
        public FF_QTN004New FF_QTN004 { get; set; }
        public List<FF_QTN004New> FF_QTN004Detail { get; set; }
        public FF_QTN005New FF_QTN005 { get; set; }
        public List<FF_QTN005New> FF_QTN005Detail { get; set; }



    }

    

    public class FF_QTN002New
    {       
        public int sno { get; set; }
        public string Container { get; set; }
        public string Cont_Type { get; set; }
        public int Seal1 { get; set; }
        public int No_of_qty { get; set; }
        public string Contents { get; set; }
        public Decimal LBS { get; set; }
        public Decimal KG { get; set; }
        public Decimal CFT { get; set; }
        public Decimal CBM { get; set; }
    }
    public class FF_QTN003New
    {  
        public int Sno { get; set; }
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
    public class FF_QTN004New
    {     
        public string CLUASE_CODE { get; set; }
        public string CLUASE_NAME { get; set; }
    }
    public class FF_QTN005New
    {              
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
    }
}
