using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
   public  interface IFNM_CURR_RATEService 
    {
        bool DeleteFNM_CURR_RATE(string CmpyCode, string FROM_CURRENCY_CODE, DateTime ENTRY_DATE, string UserName);
        List<FNM_CURR_RATE_VM> GetFNM_CURR_RATE(string CmpyCode);
        FNM_CURR_RATE_VM SaveFNM_CURR_RATE(FNM_CURR_RATE_VM ac);
        FNM_CURR_RATE_VM EditFNM_CURR_RATE(string CmpyCode, string FROM_CURRENCY_CODE, DateTime ENTRY_DATE,string Tocurrdate);

        FNM_CURR_RATE_VM GetFNM_CURR_RATEAddNew(string Cmpycode);

        List<FNM_CURRENCYRateDetailNew> GetCURRENCYRateDetailList(string CmpyCode, string FROM_CURRENCY_CODE);
        List<SelectListItem> GetFNMCURRENCY();
    }
}
