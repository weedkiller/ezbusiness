using EzBusiness_BL_Interface;
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
  public class FFM_CLAUSEFrightService: IFMM_CLAUSE_FrightService
    {
        IFFM_CLAUSERepository _FFM_CLAUSERepo;

        public FFM_CLAUSEFrightService()
        {
            _FFM_CLAUSERepo = new FFM_CLAUSERepository();
        }

        public bool DeleteFFM_CLAUSE(string FFM_CLAUSE_CODE, string CmpyCode, string UserName)
        {
            return _FFM_CLAUSERepo.DeleteFFM_CLAUSE(FFM_CLAUSE_CODE, CmpyCode, UserName);
        }

        public FFM_CLAUSE_VM EditFFM_CLAUSE(string CmpyCode, string FFM_CLAUSE_CODE)
        {
            return _FFM_CLAUSERepo.EditFFM_CLAUSE(CmpyCode, FFM_CLAUSE_CODE);
        }

        public List<FFM_CLAUSE_VM> GetFFM_CLAUSE(string CmpyCode)
        {
            return _FFM_CLAUSERepo.GetFFM_CLAUSE(CmpyCode).Select(m => new FFM_CLAUSE_VM
            {
                FFM_CLAUSE_CODE = m.FFM_CLAUSE_CODE,
                NAME = m.NAME,
                //Note = m.Note,
                //MASTER_STATUS = m.MASTER_STATUS
            }).ToList();
        }

        public FFM_CLAUSE_VM SaveFFM_CLAUSE(FFM_CLAUSE_VM FC)
        {
            return _FFM_CLAUSERepo.SaveFFM_CLAUSE(FC);
        }
    }
}
