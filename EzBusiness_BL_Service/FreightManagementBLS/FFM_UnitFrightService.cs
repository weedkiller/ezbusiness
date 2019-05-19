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
   public class FFM_UnitFrightService: IFFM_UNITFrightService
    {
        IFFM_UNITRepository _FFM_UnitRepo;

        public FFM_UnitFrightService()
        {
            _FFM_UnitRepo = new FFM_UnitRepository();
        }

        public bool DeleteFFM_Unit(string FFM_Unit_CODE, string CmpyCode, string UserName)
        {
            return _FFM_UnitRepo.DeleteFFM_Unit(FFM_Unit_CODE, CmpyCode, UserName);
        }

        public FFM_Unit_VM EditFFM_Unit(string CmpyCode, string FFM_Unit_CODE)
        {
            return _FFM_UnitRepo.EditFFM_Unit(CmpyCode, FFM_Unit_CODE);
        }

        public List<FFM_Unit_VM> GetFFM_Unit(string CmpyCode)
        {
            return _FFM_UnitRepo.GetFFM_Unit(CmpyCode).Select(m => new FFM_Unit_VM
            {
                FFM_UNIT_CODE = m.FFM_UNIT_CODE,
                NAME = m.NAME,
                DISPLAY_STATUS=m.DISPLAY_STATUS
                //Note = m.Note,
                //MASTER_STATUS = m.MASTER_STATUS
            }).ToList();
        }

        public FFM_Unit_VM SaveFFM_Unit(FFM_Unit_VM FC)
        {
            return _FFM_UnitRepo.SaveFFM_Unit(FC);
        }
    }
}
