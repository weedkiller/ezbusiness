using EzBusiness_EF_Entity.FreightManagementEF;
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
        List<FNM_SL_VM> GetFNM_SL(string CmpyCode, string Sublesertype);
        FNM_SL_VM SaveFNM_SL(FNM_SL_VM ac);
        FNM_SL_VM EditFNM_SL(string CmpyCode, string FNM_SL1001_CODE);
        FNM_SL_VM GetFNM_SLAddNew(string Cmpycode,string type1);
        List<FNM_SL1002DetailNew> GetFNMSL002DetailList(string CmpyCode, string FNM_SL1001_CODE,string Type1);
        
       
        List<SelectListItem> GetFNMCURRENCY(string prefix);

        List<SelectListItem> GetFNMCAT(string CmpyCode,string type1,string Prefix);


        List<SelectListItem> GetFNMCATSubLed(string CmpyCode, string Prefix);



        List<FNM_SL1002DetailNew> GetFNM_SL1002Add(string CmpyCode, string FNMCAT_CODE);

    //    List<FNM_SL1002DetailNew> GetCatDropDetailListFilter(string CmpyCode, string FNMCAT_CODE);
    }
}
