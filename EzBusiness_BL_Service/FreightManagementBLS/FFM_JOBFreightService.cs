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
    public class FFM_JOBFreightService : IFFM_JOBFreightService
    {
        IFFM_JOBRepository _FFMJOBRepo;

        public FFM_JOBFreightService()
        {
            _FFMJOBRepo = new FFM_JOBRepository();
        }
        public bool DeleteFFM_JOB(string FFM_JOB_CODE, string CmpyCode, string UserName)
        {
            return _FFMJOBRepo.DeleteFFM_JOB(FFM_JOB_CODE, CmpyCode, UserName);
        }

        public List<FFM_JOB_VM> GetFFM_JOB(string CmpyCode)
        {
            return _FFMJOBRepo.GetFFM_JOB(CmpyCode).Select(m => new FFM_JOB_VM
            {
                CMPYCODE = m.CMPYCODE,
                FFM_JOB_CODE = m.FFM_JOB_CODE,
                NAME = m.NAME,
            }).ToList();
        }

        public FFM_JOB_VM SaveFFM_JOB(FFM_JOB_VM FJ)
        {
            return _FFMJOBRepo.SaveFM_JOBHEAD(FJ);
        }
    }
}
