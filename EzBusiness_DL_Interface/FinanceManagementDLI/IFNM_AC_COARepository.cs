using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_EF_Entity.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
  public  interface IFNM_AC_COARepository
    {
        bool DeleteFNM_Ac_COA(string CmpyCode, string FNM_AC_CODE,  string UserName);
        List<FNM_AC_COA_VM> GetFNM_AC_COA(string CmpyCode);
        FNM_AC_COA_VM SaveFNM_AC_COA(FNM_AC_COA_VM ac);
        FNM_AC_COA_VM EditFNM_AC_COA(string CmpyCode, string BranchCode);

        List<ComDropTbl> GetFMHEAD(string Cmpycode, string prefix);
        List<FMHEAD> GetFMHEAD1(string Cmpycode);
        List<ComDropTbl> Getgroup_code(string Cmpycode,string Prefix);

        List<ComDropTbl> GetSUBGROUP(string Cmpycode, string Prefix);

        List<ComDropTbl> GetCOA_TYPEList(string Cmpycode, string Prefix);

        List<ComDropTbl> GetFNMSUBGROUP(string Cmpycode, string Prefix);

        List<ComDropTbl> GetSUBLEDGER_CAT(string Cmpycode, string Prefix);


    }
}
