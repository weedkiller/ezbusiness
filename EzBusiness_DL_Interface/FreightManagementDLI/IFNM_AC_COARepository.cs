using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_EF_Entity.FreightManagement;
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
        List<FNM_AC_COA_VM> GetFNM_AC_COA(string CmpyCode);
        FNM_AC_COA_VM SaveFNM_AC_COA(FNM_AC_COA_VM ac);
        FNM_AC_COA_VM EditFNM_AC_COA(string CmpyCode, string BranchCode);

        List<FMHEAD> GetFMHEAD(string Cmpycode);

        List<FNMGROUP> Getgroup_code(string Cmpycode);

        List<FNMSUBGROUP> GetSUBGROUP(string Cmpycode);

        List<FNMTYPE> GetCOA_TYPEList(string Cmpycode);

        List<FNMSUBGROUP> GetFNMSUBGROUP(string Cmpycode);


    }
}
