using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service.FreightManagementBLS;
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
   public  class FFM_CNTRFrightService: IFFMCNTRFrightService
    {
        IFFM_CNTRRepository _FFMCNNTRRepo;

        public FFM_CNTRFrightService()
        {
            _FFMCNNTRRepo = new FFM_CNTRRepository();
        }

        public bool DeleteFMM_CNTR(string FMM_CNTR_CODE, string CmpyCode, string UserName)
        {
            return _FFMCNNTRRepo.DeleteFMM_CNTR(FMM_CNTR_CODE, CmpyCode, UserName);
        }

        public FFM_CNTR_VM EditFFM_CNTR(string CmpyCode, string FMM_CNTR_CODE)
        {
            return _FFMCNNTRRepo.EditFFM_CNTR(CmpyCode, FMM_CNTR_CODE);
        }

        public List<FFM_CNTR_VM> GetFFM_CNTR(string CmpyCode)
        {
            return _FFMCNNTRRepo.GetFFM_CNTR(CmpyCode).Select(m => new FFM_CNTR_VM
            {
                FFM_CNTR_CODE = m.FFM_CNTR_CODE,
                NAME = m.NAME,
                //Note = m.Note,
                //MASTER_STATUS = m.MASTER_STATUS
            }).ToList();
        }

        public FFM_CNTR_VM SaveFFM_CNTR(FFM_CNTR_VM FC)
        {
            return _FFMCNNTRRepo.SaveFFM_CNTR(FC);
        }
    }
}
