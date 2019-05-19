using EzBusiness_ViewModels.Models.FinaceMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FinanceManagementBLI
{
  public   interface IFNM_SL1001Service
    {
        bool DeleteFNM_SL1001(string CmpyCode, string FNM_SL1001_CODE,  string UserName);
        List<FNM_SL_VM> GetFNM_SL(string CmpyCode);
        FNM_SL_VM SaveFNM_SL(FNM_SL_VM ac);
        FNM_SL_VM EditFNM_SL(string CmpyCode, string FNM_SL1001_CODE);
        FNM_SL_VM GetFNM_SLAddNew(string Cmpycode);
        List<FNM_SL1002DetailNew> GetFNMSL002DetailList(string CmpyCode, string FNM_SL1001_CODE);
        List<SelectListItem> GetFNMCURRENCY();

        List<SelectListItem> GetFNMCAT(string CmpyCode);

        List<FNM_SL1002DetailNew> GetFNM_SL1002Add(string CmpyCode, string FNMCAT_CODE);
    }
}
