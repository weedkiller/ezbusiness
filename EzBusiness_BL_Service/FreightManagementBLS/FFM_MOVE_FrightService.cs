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
   public class FFM_MOVE_FrightService: IFFM_MOVEFrightService
    {
        IFFM_MOVERepository _FFMMOVERepo;

        public FFM_MOVE_FrightService()
        {
            _FFMMOVERepo = new FFM_MOVERepository();
        }

        public bool DeleteFFM_MOVE(string FFM_MOVE_CODE, string CmpyCode, string UserName)
        {
            return _FFMMOVERepo.DeleteFFM_MOVE(FFM_MOVE_CODE, CmpyCode, UserName);
        }

        public FFM_MOVE_VM EditFFM_MOVE(string CmpyCode, string FFM_MOVE_CODE)
        {
            return _FFMMOVERepo.EditFFM_MOVE(CmpyCode, FFM_MOVE_CODE);
        }

        public List<FFM_MOVE_VM> GetFFM_MOVE(string CmpyCode)
        {
            return _FFMMOVERepo.GetFFM_MOVE(CmpyCode).Select(m => new FFM_MOVE_VM
            {
                FFM_MOVE_CODE = m.FFM_MOVE_CODE,
                NAME = m.NAME,
                //Note = m.Note,
                //MASTER_STATUS = m.MASTER_STATUS
            }).ToList();
        }

        public FFM_MOVE_VM SaveFFM_MOVE(FFM_MOVE_VM FC)
        {
            return _FFMMOVERepo.SaveFFM_MOVE(FC);
        }
    }
}
