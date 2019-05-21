using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FinaceMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FinanceManagementDLI
{
  public  interface IFNM_SL1001Repository
    {
        bool DeleteFNM_SL1001(string CmpyCode, string FNM_SL1001_CODE,  string UserName);
        List<FNM_SL1001> GetFNM_SL(string CmpyCode);
        FNM_SL_VM SaveFNM_SL(FNM_SL_VM FNSL);
        FNM_SL_VM EditFNM_SL(string CmpyCode, string FNM_SL1001_CODE);
        List<FNM_CURRENCY> GetCURRENCYList();
        List<FNMCAT> GetFNMCAT(string CmpyCode,string type1);
        List<FNM_SL1002> GetFNM_SL1002( string CmpyCode,string FNM_SL1001_CODE);

        List<FNM_SL1002> GetFNM_SL1002Add(string CmpyCode, string FNMCAT_CODE);


    }
}
