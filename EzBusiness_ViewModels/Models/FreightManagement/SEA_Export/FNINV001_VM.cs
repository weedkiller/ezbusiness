using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement.SEA_Export
{
    public class FNINV001_VM
    {
        [Display(Name = "Code")]
        public string FNINV001_CODE { get; set; }
        public string cmpycode { get; set; }
        public string BRANCHCODE { get; set; }
        public string INV_TYPE { get; set; }
        public string INV_STATUS { get; set; }
        [Display(Name = "Inv Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime INV_DATE { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Post_Date { get; set; }
        public string NOTES { get; set; }
        public string NARRATION { get; set; }
        public string CREATED_BY { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CREATED_ON { get; set; }

        public string UPDATED_BY { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime UPDATED_ON { get; set; }
        [Display(Name = "COA Code")]
        public string COA_CODE { get; set; }
        [Display(Name = "Customer Code")]
        public string SUBLEDGER_CODE { get; set; }
        [Display(Name = "Currency Code")]
        public string CURRENCY_CODE { get; set; }
        [Display(Name = "Currency Rate")]
        public decimal CURRENCY_RATE { get; set; }
        public decimal VAT_CURRENCY_AMT { get; set; }
        public decimal VAT_LOCAL_AMT { get; set; }
        public decimal CURRENCY_AMT { get; set; }
        public decimal LOCAL_AMT { get; set; }
        public decimal NET_CURRENCY_AMT { get; set; }
        public decimal NET_LOCAL_AMT { get; set; }
        public string BILLING_ADDRESS { get; set; }
        public string SUPPLIER_JV_NO { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime SUPPLIER_JV_DATE { get; set; }

        public string SUPPLIER_GRN_NO { get; set; }
        public string RECEIVED_PAID_NAME { get; set; }
        public string UNPOSTED_NOTE { get; set; }
        public string Customer_Code { get; set; }
        public string Customer_COA { get; set; }
        public string Received_By { get; set; }
        public string SalesMan { get; set; }
        public string LOCATION_CODE { get; set; }
        [Display(Name = "Vessel Code")]
        public string vessel_code { get; set; }
        [Display(Name = "BL Code")]
        public string BL_CODE { get; set; }
        [Display(Name = "Bl Ref No")]
        public string BL_REF_NO { get; set; }
        public string POL { get; set; }
        public string POD { get; set; }


        public FNINV002New FNINV002 { get; set; }
        public List<FNINV002New> FNINV002Detail { get; set; }

        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }

        public string Type_Choose { get; set; }
        [Display(Name = "Invoice No")]
        public string Invoice_No { get; set; }
    }
    public class FNINV002New
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
