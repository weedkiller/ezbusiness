using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF
{
    public partial class FNM_CURR_RATE
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
        public Decimal FNM_CURR_RATE_UID { get; set; }
        public string FROM_CURRENCY_CODE { get; set; }
        public string TO_CURRENCY_CODE { get; set; }
        public DateTime ENTRY_DATE { get; set; }
        public Decimal SELL_RATE { get; set; }
        public Decimal BUY_RATE { get; set; }
        public string MASTER_STATUS { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public List<FNM_CURR_RATENew> LoanNew { get; set; }
        public FNM_CURR_RATENew FNM_CURR_RATEDetail { get; set; }
        public List<string> Drecord { get; set; }
    }
    public class FNM_CURR_RATENew
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
        public Decimal FNM_CURR_RATE_UID { get; set; }
        public string FROM_CURRENCY_CODE { get; set; }
        public string TO_CURRENCY_CODE { get; set; }
        public DateTime ENTRY_DATE { get; set; }
        public Decimal SELL_RATE { get; set; }
        public Decimal BUY_RATE { get; set; }
        public string MASTER_STATUS { get; set; }
      }
}
