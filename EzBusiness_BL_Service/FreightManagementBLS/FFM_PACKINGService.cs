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

    public class FFM_PACKINGService : IFFM_PACKINGService
    {
        IFFM_PACKINGRepository _FFMPACKINGRepo;
        public FFM_PACKINGService()
        {
            _FFMPACKINGRepo = new FFM_PACKINGRepository();
        }
        public bool DeleteFFM_PACKING(string FFM_PACKING_CODE, string CmpyCode, string UserName)
        {
            return _FFMPACKINGRepo.DeleteFFM_PACKING(FFM_PACKING_CODE, CmpyCode, UserName);
        }

        public FFM_PACKING_VM EditFFM_PACKING(string CmpyCode, string FFM_PACKING_CODE)
        {
            return _FFMPACKINGRepo.EditFFM_PACKING(CmpyCode, FFM_PACKING_CODE);
        }

        public List<FFM_PACKING_VM> GetFFM_PACKING(string CmpyCode)
        {
            return _FFMPACKINGRepo.GetFFM_PACKING(CmpyCode).Select(m => new FFM_PACKING_VM
            {
                CMPYCODE = m.CMPYCODE,
                NAME = m.NAME,
                FFM_PACKING_CODE = m.FFM_PACKING_CODE,
            }).ToList();
        }

        public FFM_PACKING_VM SaveFFM_PACKING(FFM_PACKING_VM FC)
        {
            return _FFMPACKINGRepo.SaveFFM_PACKING(FC);
        }
    }
}
