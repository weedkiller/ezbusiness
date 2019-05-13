using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
  public  interface IFNM_AC_COARepository
    {
        bool DeleteFNM_Ac_COA(string FNM_AC_CODE, string CmpyCode, string UserName);
        List<FNM_AC_COA> GetFNM_AC_COA(string CmpyCode);
        FNM_AC_COA_VM SaveFNMBranch(FNM_AC_COA_VM ac);
        FNM_AC_COA_VM EditFNMBranch(string CmpyCode, string BranchCode);
    }
}
