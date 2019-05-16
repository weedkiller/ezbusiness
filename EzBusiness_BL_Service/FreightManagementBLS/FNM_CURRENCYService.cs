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
    public class FNM_CURRENCYService : IFNM_CURRENCYService
    {

        IFNM_CURRENCYRepository _FNMCURRENCYRepo;

        public FNM_CURRENCYService()
        {
            _FNMCURRENCYRepo = new FNM_CURRENCYRepository();
        }

        public bool DeleteFNM_CURRENCY(string FNM_CURRENCY_CODE, string CmpyCode, string UserName)
        {
            return _FNMCURRENCYRepo.DeleteFNM_CURRENCY(FNM_CURRENCY_CODE, CmpyCode, UserName);
        }

        public FNM_CURRENCY_VM EditFNM_CURRENCY(string CmpyCode, string FNM_CURRENCYCOde)
        {
            return _FNMCURRENCYRepo.EditFNM_CURRENCY(CmpyCode, FNM_CURRENCYCOde);
        }

        public List<FNM_CURRENCY_VM> GetFNM_CURRENCY(string CmpyCode)
        {
            return _FNMCURRENCYRepo.GetFNM_CURRENCY(CmpyCode).Select(m => new FNM_CURRENCY_VM
            {
                CURRENCY_CODE = m.CURRENCY_CODE,
                CURRENCY_NAME = m.CURRENCY_NAME,               
                Note = m.Note,
                MASTER_STATUS=m.MASTER_STATUS
            }).ToList();
        }

        public FNM_CURRENCY_VM SaveFNM_CURRENCY(FNM_CURRENCY_VM FC)
        {
            return _FNMCURRENCYRepo.SaveFNM_CURRENCY(FC);
        }
    }
}
