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
  public  class FNMSUBGROUPFreightService : IFNMSUBGROUPFreightService
    {
        IFNMSUBGROUPRepository _FNMSUBGROUPERepo;

        public FNMSUBGROUPFreightService()
        {
            _FNMSUBGROUPERepo = new FNMSUBGROUPRepository();
        }

        public bool DeleteFNMSUBGROUP(string FNMSUBGROUP_CODE, string CmpyCode, string UserName)
        {
           return _FNMSUBGROUPERepo.DeleteFNMSUBGROUP(FNMSUBGROUP_CODE, CmpyCode, UserName);
        }

        public List<FNMSUBGROUP_VM> GetFNMSUBGROUP(string CmpyCode)
        {
            return _FNMSUBGROUPERepo.GetFNMSUBGROUP(CmpyCode).Select(m => new FNMSUBGROUP_VM
            {
                CMPYCODE = m.CMPYCODE,
                FNMSUBGROUP_CODE = m.FNMSUBGROUP_CODE,
                DESCRIPTION = m.DESCRIPTION,
            }).ToList();
        }

        public FNMSUBGROUP_VM SaveFNMSUBGROUP(FNMSUBGROUP_VM FT)
        {
            return _FNMSUBGROUPERepo.SaveFNMSUBGROUP(FT);
        }
    }
}
