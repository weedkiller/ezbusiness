using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FFM_CRG_001FreightService : IFFM_CRG_001FreightService
    {
        IFFM_CRG_001Repository _FFMCRGRepo;

        public FFM_CRG_001FreightService()
        {
            _FFMCRGRepo = new FFM_CRG_001Repository();
        }
        public bool DeleteFFM_CRG_001(string FFM_CRG_001_CODE, string CmpyCode, string UserName)
        {
            return _FFMCRGRepo.DeleteFFM_CRG_001(FFM_CRG_001_CODE, CmpyCode, UserName);
        }

        public List<FFM_CRG_001_VM> GetFFM_CRG_001(string CmpyCode)
        {
            return _FFMCRGRepo.GetFFM_CRG_001(CmpyCode).Select(m => new FFM_CRG_001_VM
            {
                CMPYCODE = m.CMPYCODE,
                FFM_CRG_001_CODE = m.FFM_CRG_001_CODE,
                NAME = m.NAME,
                DISPLAY_STATUS = m.DISPLAY_STATUS,
                FFM_CRG_GROUP_CODE = m.FFM_CRG_GROUP_CODE,
            }).ToList();
        }

        public FFM_CRG_001_VM SaveFFM_CRG_001(FFM_CRG_001_VM CR)
        {
            return _FFMCRGRepo.SaveFM_CRG_001HEAD(CR);
        }
    }
}
