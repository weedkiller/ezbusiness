using EzBusiness_BL_Interface.FreightManagementBLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FFM_CRG_002FreightService : IFFM_CRG_002FreightService
    {
        IFFM_CRG_002Repository _FFM_CRGRepo;

        public FFM_CRG_002FreightService()
        {
            _FFM_CRGRepo = new FFM_CRG_002Repository();
        }

        public bool DeleteFFM_CRG_002(string FFM_CRG_JOB_CODE, string CmpyCode, string UserName)
        {
            return _FFM_CRGRepo.DeleteFFM_CRG_002(FFM_CRG_JOB_CODE, CmpyCode, UserName);
        }

        public FFM_CRG_002_VM EditFFM_CRG_002(string CmpyCode, string FFM_CRG_JOB_CODE)
        {
            var FFM_CRGEdit = _FFM_CRGRepo.EditFFM_CRG_002(CmpyCode, FFM_CRG_JOB_CODE);

            return FFM_CRGEdit;
        }

        public List<FFM_CRG_002_VM> GetFFM_CRG_002(string CmpyCode)
        {
            return _FFM_CRGRepo.GetFFM_CRG_002(CmpyCode).Select(m => new FFM_CRG_002_VM
            {
                CMPYCODE = m.CMPYCODE,
                DISPLAY_STATUS = m.DISPLAY_STATUS,
                NAME = m.NAME,
                FFM_CRG_JOB_CODE = m.FFM_CRG_JOB_CODE,
                INCOME_ACT =m.INCOME_ACT,
                EXPENSE_ACGT = m.EXPENSE_ACGT
            }).ToList();
        }

        public FFM_CRG_002_VM GetFFM_CRG_002AddNew(string Cmpycode)
        {
            return new FFM_CRG_002_VM
            {
                EditFlag = false
            };
        }

        public FFM_CRG_002_VM SaveFFM_CRG_002(FFM_CRG_002_VM ac)
        {
            return _FFM_CRGRepo.SaveFFM_CRG_002(ac);
        }
    }
}
