using EzBusiness_EF_Entity;
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
   public interface IFNMBranchFrightService
    {
       List<FNMBranch_VM> GetFNMBranch(string CmpyCode);
        FNMBranch_VM SaveFNMBranch(FNMBranch_VM FC);
        bool DeleteFNMBranch(string FNMBranch_CODE, string CmpyCode, string UserName);
        List<SelectListItem> GetCountryCodes(string CmpyCode);
        List<SelectListItem> GetCurrencyCodes(string CmpyCode); 
         FNMBranch_VM EditFNMBranch(string CmpyCode, string FNMBranchCOde);
        //List<SelectListItem> GetCountryCodes(string CmpyCode);
    }
}


