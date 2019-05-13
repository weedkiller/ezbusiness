using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
   public class FNM_AC_COAFrightService: IFNM_AC_COAService
    {
        IFNM_AC_COARepository _FNMBranchRepo;

        public FNM_AC_COAFrightService()
        {
            _FNMBranchRepo = new FNM_AC_COARepository();
        }

        public bool DeleteFNM_Ac_COA(string FNM_AC_CODE, string CmpyCode, string UserName)
        {
            return _FNMBranchRepo.DeleteFNM_Ac_COA(FNM_AC_CODE, CmpyCode, UserName);
        }

        public List<FNM_AC_COA> GetFNM_AC_COA(string CmpyCode)
        {
            return _FNMBranchRepo.GetFNM_AC_COA(CmpyCode).Select(m => new FNM_AC_COA
            {
                COMPANY_UID = m.COMPANY_UID,
                FNM_AC_COAId = m.FNM_AC_COAId,
                CODE = m.CODE,
                NAME = m.NAME,
                Head_code = m.Head_code,
                group_code = m.group_code,
                SUBGROUP_code = m.SUBGROUP_code,
                COA_TYPE = m.COA_TYPE,
                SUBLEDGER_TYPE = m.SUBLEDGER_TYPE,
                MASTER_STATUS = m.MASTER_STATUS,
                NOTE = m.NOTE,
                NATURE = m.NATURE,
                PL_BS = m.PL_BS
            }).ToList();
        }
        public FNM_AC_COA_VM SaveFNMBranch(FNM_AC_COA_VM FC)
        {
            return _FNMBranchRepo.SaveFNMBranch(FC);
        }
        public FNM_AC_COA_VM EditFNMBranch(string CmpyCode, string Code)
        {
            return _FNMBranchRepo.EditFNMBranch(CmpyCode, Code);

        }
    }
}
