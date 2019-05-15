using EzBusiness_EF_Entity.FreightManagementEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
  public  class FNM_CURR_RATE_VM
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
        public Decimal FNM_CURR_RATE_UID { get; set; }
        public string FROM_CURRENCY_CODE { get; set; }

        public List<SelectListItem> FROM_CURRENCY_CODEList { get; set; }
        public string TO_CURRENCY_CODE { get; set; }
        [DisplayName("ENTRY DATE")]
        public DateTime ENTRY_DATE { get; set; }

        [DisplayName("SELL RATE")]
        public Decimal SELL_RATE { get; set; }

        [DisplayName("BUY RATE")]
        public Decimal BUY_RATE { get; set; }
        public string MASTER_STATUS { get; set; }


        public string Note { get; set; }

        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }

        public List<FNM_CURRENCYRateDetailNew> FNM_CURRENCYRateDetailNew { get; set; }
        public FNM_CURRENCYRateDetailNew FNM_CURRENCYRateDetail { get; set; }

    }
    public class FNM_CURRENCYRateDetailNew
    {
        public string CMPYCODE { get; set; }
        public string FROM_CURRENCY_CODE { get; set; }
        [DisplayName("ENTRY DATE")]
        public DateTime ENTRY_DATE { get; set; }

        [DisplayName("SELL RATE")]
        public Decimal SELL_RATE { get; set; }

        [DisplayName("BUY RATE")]
        public Decimal BUY_RATE { get; set; }
    }
}
