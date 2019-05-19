using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
  public  class FFM_HAZFrightService: IFFM_HAZFrightService
    {
        IFFM_HAZRepository _FFM_HAZRepo;

        public FFM_HAZFrightService()
        {
            _FFM_HAZRepo = new FFM_HAZRepository();
        }
        public bool DeleteFFM_HAZ(string FFM_HAZ_CODE, string CmpyCode, string UserName)
        {
            return _FFM_HAZRepo.DeleteFFM_HAZ(FFM_HAZ_CODE, CmpyCode, UserName);
        }

        public FFM_HAZ_VM EditFFM_HAZ(string CmpyCode, string FFM_HAZ_CODE)
        {
            return _FFM_HAZRepo.EditFFM_HAZ(CmpyCode, FFM_HAZ_CODE);
        }

        public List<FFM_HAZ_VM> GetFFM_HAZ(string CmpyCode)
        {
            return _FFM_HAZRepo.GetFFM_HAZ(CmpyCode).Select(m => new FFM_HAZ_VM
            {
                FFM_HAZ_CODE = m.FFM_HAZ_CODE,
                NAME = m.NAME,
                DISPLAY_STATUS = m.DISPLAY_STATUS
                //Note = m.Note,
                //MASTER_STATUS = m.MASTER_STATUS
            }).ToList();
        }

        public FFM_HAZ_VM SaveFFM_HAZ(FFM_HAZ_VM FC)
        {
            return _FFM_HAZRepo.SaveFFM_HAZ(FC);
        }
    }
}
