using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.FinaceMgmt
{
    public class FNM_SL_VM
    {

        public string CMPYCODE { get; set; }
        public string DIVISION { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        [DisplayName("Code")]
        public string FNM_SL1001_CODE { get; set; }
        public string Name { get; set; }
        [DisplayName("Print Name")]
        public string Print_Name { get; set; }

        [DisplayName("Web site")]
        public string Web_site { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Contact3 { get; set; }

        [DisplayName("Currency code")]
        public string Currency_code { get; set; }


        public List<SelectListItem> Currency_codeList { get; set; }

        [DisplayName("credit limit")]
        public Decimal credit_limit { get; set; }


        public List<SelectListItem> SUBLEDGER_TYPEList { get; set; }


 

        [DisplayName("SubLedger Type")]
        public string SUBLEDGER_TYPE { get; set; }

        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public string Name_Arabic { get; set; }

        public string Branchcode { get; set; }
        
        public FNM_SL1002DetailNew FNM_SL1002Detail { get; set; }

        public List<FNM_SL1002DetailNew> FNM_SL1002Details { get; set; }
    }
        public class FNM_SL1002DetailNew
    {
        public string CMPYCODE { get; set; }
        public Decimal DIVISION { get; set; }
        public string FNM_SL1001_CODE { get; set; }
        public string FNM_SL1002_CODE { get; set; }
        public string NAME { get; set; }
      
        public string COA_CODE { get; set; }

        public string COA_NAME { get; set; }

        public List<SelectListItem> SUBLEDGER_TYPEList1 { get; set; }
    }
}
