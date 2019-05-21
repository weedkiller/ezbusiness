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
    public class FFM_SRVCFreightService : IFFM_SRVCFreightService
    {
        IFFM_SRVCRepository _FFMSRVCRepo;

        public FFM_SRVCFreightService()
        {
            _FFMSRVCRepo = new FFM_SRVCRepository();
        }
        public bool DeleteFFM_SRVC(string FFM_SRVC_CODE, string CmpyCode, string UserName)
        {
            return _FFMSRVCRepo.DeleteFFM_SRVC(FFM_SRVC_CODE, CmpyCode, UserName);
        }

        public List<FFM_SRVC_VM> GetFFM_SRVC(string CmpyCode)
        {
            return _FFMSRVCRepo.GetFFM_SRVC(CmpyCode).Select(m => new FFM_SRVC_VM
            {
                CMPYCODE = m.CMPYCODE,
                FFM_SRVC_CODE = m.FFM_SRVC_CODE,
                NAME = m.NAME,
            }).ToList();
        }

        public FFM_SRVC_VM SaveFFM_SRVC(FFM_SRVC_VM SR)
        {
            return _FFMSRVCRepo.SaveFM_SRVCHEAD(SR);
        }
    }
}
