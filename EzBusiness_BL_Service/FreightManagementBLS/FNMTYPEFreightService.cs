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
  public  class FNMTYPEFreightService : IFNMTYPEFreightService
    {

        IFNMTYPERepository _FNMTYPERepo;

        public FNMTYPEFreightService()
        {
            _FNMTYPERepo = new FNMTYPERepository();
        }

        public bool DeleteFNMTYPE(string FNMTYPE_CODE, string CmpyCode, string UserName)
        {
            return _FNMTYPERepo.DeleteFNMTYPE(FNMTYPE_CODE, CmpyCode, UserName);
        }

        public List<FNMTYPE_VM> GetFNMTYPE(string CmpyCode)
        {
            return _FNMTYPERepo.GetFNMTYPE(CmpyCode).Select(m => new FNMTYPE_VM
            {
                CMPYCODE = m.CMPYCODE,
                FNMTYPE_CODE = m.FNMTYPE_CODE,
                DESCRIPTION = m.DESCRIPTION,
            }).ToList();
        }

        public FNMTYPE_VM SaveFNMTYPE(FNMTYPE_VM FT)
        {
            return _FNMTYPERepo.SaveFNMTYPE(FT);
        }
    }
}
