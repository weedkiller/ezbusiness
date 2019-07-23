using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_EF_Entity.FreightManagement;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
   public class FNM_AC_COA_VM
    {
        public string COMPANY_UID { get; set; }
        public Decimal FNM_AC_COAID { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public string Head_code { get; set; }
        public List<SelectListItem> Head_codeList { get; set; }
        public string group_code { get; set; }
        public List<SelectListItem> group_codeList { get; set; }
        public string SUBGROUP_code { get; set; }
        public List<SelectListItem> SUBGROUP_codeList { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public string FNMBRANCH_CODE { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string COA_TYPE { get; set; }
        public List<SelectListItem> COA_TYPEList { get; set; }
        public string SUBLEDGER_TYPE { get; set; }
        public List<SelectListItem> SUBLEDGER_TYPEList { get; set; }

        public string SUBLEDGER_CAT { get; set; }

        public List<SelectListItem> SUBLEDGER_CATList { get; set; }
        public string MASTER_STATUS { get; set; }
        public string NOTE { get; set; }
        public string NATURE { get; set; }
        public string PL_BS { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }       
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public string Name_Arabic { get; set; }                  
    }
}
