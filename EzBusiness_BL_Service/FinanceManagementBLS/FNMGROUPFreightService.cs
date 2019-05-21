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
   public class FNMGROUPFreightService :IFNMGROUPFreightService
    {
        IFNMGROUPRepository _FNMGROUPERepo;

        public FNMGROUPFreightService()
        {
            _FNMGROUPERepo = new FNMGROUPRepository();
        }

        public bool DeleteFNMGROUP(string FNMGROUP_CODE, string CmpyCode, string UserName)
        {
            return _FNMGROUPERepo.DeleteFNMGROUP(FNMGROUP_CODE, CmpyCode, UserName);
        }

        public List<FNMGROUP_VM> GetFNMGROUP(string CmpyCode)
        {
            return _FNMGROUPERepo.GetFNMGROUP(CmpyCode).Select(m => new FNMGROUP_VM
            {
                CMPYCODE = m.CMPYCODE,
                FNMGROUP_CODE = m.FNMGROUP_CODE,
                DESCRIPTION = m.DESCRIPTION,
            }).ToList();
        }

        public FNMGROUP_VM SaveFNMGROUP(FNMGROUP_VM FC)
        {
            return _FNMGROUPERepo.SaveFNMGROUP(FC);
        }
    }
}
