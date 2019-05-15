using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
  public  class FNM_CURRENCY_VM
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public Decimal FNM_CURRENCY_UID { get; set; }
        [DisplayName("Code")]
        public string CURRENCY_CODE { get; set; }
        [DisplayName("Name")]
        public string CURRENCY_NAME { get; set; }
        [DisplayName("Master Status")]
        public string MASTER_STATUS { get; set; }
        public string Note { get; set; }

        public string CMPYCODE { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }

        public string UserName { get; set; }
        public List<FNM_CURRENCYDetailNew> FNM_CURRENCYDetailNew { get; set; }
        public FNM_CURRENCYDetailNew FNM_CURRENCYDetail { get; set; }
        public List<string> Drecord { get; set; }
    }
    public class FNM_CURRENCYDetailNew
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public Decimal FNM_CURRENCY_UID { get; set; }
        public string CURRENCY_CODE { get; set; }
        public string CURRENCY_NAME { get; set; }
        public string MASTER_STATUS { get; set; }
        public string CMPYCODE { get; set; }
        public string Note { get; set; }

    }
}

