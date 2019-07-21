using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.FreightManagement.SEA_Export
{
  public  class FF_BL_VM
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

        public string FF_BL001_CODE { get; set; }
        public DateTime FF_BL001_DATE { get; set; }
        public string FF_QTN001_CODE { get; set; }
        public string FF_BOK001_CODE { get; set; }

        public string BILL_TO { get; set; }
        public string BILL_TOEMP { get; set; }
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ETD { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ETA { get; set; }
        public string CARRIER { get; set; }
        public string DEPARTMENT { get; set; }
        public Decimal Total_Cost { get; set; }
        public Decimal Total_Billed { get; set; }
        public Decimal Total_Profit { get; set; }

        public string Commodity_code { get; set; }

        public string DG { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public FF_BL002New FF_BL002 { get; set; }
        public List<FF_BL002New> FF_BL002Detail { get; set; }
        public FF_BL003New FF_BL003 { get; set; }
        public List<FF_BL003New> FF_BL003Detail { get; set; }
        public FF_BL004New FF_BL004 { get; set; }
        public List<FF_BL004New> FF_BL004Detail { get; set; }
        public FF_BL005New FF_BL005 { get; set; }
        public List<FF_BL005New> FF_BL005Detail { get; set; }
        public List<SelectListItem> DEPARTMENTList { get; set; }
        public List<SelectListItem> CLAUSEList { get; set; }
        public List<SelectListItem> CRG_002List { get; set; }

        public List<SelectListItem> SLList { get; set; }
        public List<SelectListItem> SLList1 { get; set; }


        public List<SelectListItem> Commodityist { get; set; }

        public List<SelectListItem> VOYAGEList { get; set; }
        public List<SelectListItem> MoveCodeList { get; set; }
       
        public List<SelectListItem> VESSELList { get; set; }

        public List<SelectListItem> PortList1 { get; set; }

        public List<SelectListItem> PortList2 { get; set; }
        public List<SelectListItem> PortList3 { get; set; }

        public List<SelectListItem> PortList4 { get; set; }
        public List<SelectListItem> PortList5 { get; set; }

        public List<SelectListItem> CustList { get; set; }

        public List<SelectListItem> VendorList { get; set; }
        public List<SelectListItem> CurList { get; set; }

        public List<SelectListItem> ConTypList { get; set; }

        public string JOB_TYPE { get; set; }
        public string TRANS_TYPE { get; set; }
        
        public List<SelectListItem> UnitcodeList { get; set; }
        public List<SelectListItem> JobTypList { get; set; }

        public List<SelectListItem> BILL_TOList { get; set; }
        public List<SelectListItem> SHIPPERList { get; set; }
        public List<SelectListItem> CONSIGNEEList { get; set; }
        public List<SelectListItem> FORWARDERList { get; set; }

        public List<SelectListItem> GetBOKCODEList { get; set; }
        public List<SelectListItem> GetCustomerList { get; set; }

        public List<SelectListItem> GetEmpList { get; set; }
        public string tranferFrom { get; set; }
        public string FNMBRANCH_CODE { get; set; }


      

        public string AGENT { get; set; }

        public string Salesman { get; set; }
        public string notifypart1 { get; set; }
        public string notifypart2 { get; set; }

        
    }
    public class FF_BL002New
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


        public Decimal Temp_Range_min { get; set; }
        public Decimal Temp_Range_max { get; set; }
        public Decimal Dimension { get; set; }
        public Decimal Volume { get; set; }
        public Decimal GrossWeight { get; set; }

        public string Commodity_code { get; set; }
        public List<SelectListItem> ConTypList1 { get; set; }
        public List<SelectListItem> Commodityist1 { get; set; }
    }
    public class FF_BL003New
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
    public class FF_BL004New
    {
        public string CLUASE_CODE { get; set; }
        public string CLUASE_NAME { get; set; }
        public List<SelectListItem> CLAUSEList4 { get; set; }
    }
    public class FF_BL005New
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
        public Decimal No_of_qty { get; set; }

        public List<SelectListItem> VendorList5 { get; set; }
        public List<SelectListItem> CVendorList5 { get; set; }

        public List<SelectListItem> VCurList5 { get; set; }

        public List<SelectListItem> UnitcodeList5 { get; set; }
        public List<SelectListItem> CRG_002List5 { get; set; }

        public List<SelectListItem> CCurList5 { get; set; }
    }
}
