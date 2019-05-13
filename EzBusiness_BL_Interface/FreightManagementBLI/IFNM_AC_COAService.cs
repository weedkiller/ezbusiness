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
   public interface IFNM_AC_COAService
    {
        bool DeleteFNM_Ac_COA(string FNM_AC_CODE, string CmpyCode, string UserName);
        List<FNM_AC_COA_VM> GetFNM_AC_COA(string CmpyCode);
        FNM_AC_COA_VM SaveFNM_AC_COA(FNM_AC_COA_VM ac);
        FNM_AC_COA_VM EditFNM_AC_COA(string CmpyCode, string Code);

        FNM_AC_COA_VM GetFNM_AC_COAAddNew(string Cmpycode);

        List<SelectListItem> GetFMHEAD(string Cmpycode);
        List<SelectListItem> Getgroup_code(string Cmpycode);
        List<SelectListItem> GetSUBGROUP(string Cmpycode);
        List<SelectListItem> GetCOA_TYPEList(string Cmpycode);
        List<SelectListItem> GetFNMSUBGROUP(string Cmpycode);
    }
}
