using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
   public class FNM_AC_COA_VM
    {
        public string COMPANY_UID { get; set; }
        public Decimal FNM_AC_COA { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string Head_code { get; set; }
        public string group_code { get; set; }
        public string SUBGROUP_code { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string COA_TYPE { get; set; }
        public string SUBLEDGER_TYPE { get; set; }
        public string MASTER_STATUS { get; set; }
        public string NOTE { get; set; }
        public string NATURE { get; set; }
        public string PL_BS { get; set; }
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }
         public List<string> Drecord { get; set; }

        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
   
       
    }
}
