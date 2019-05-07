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
    public class FNMCATFreightService : IFNMCATFreightService
    {

        IFNMCATRepository _FNMCATRepo;

        public FNMCATFreightService()
        {
            _FNMCATRepo = new FNMCATRepository();
        }

        public bool DeleteFNMCAT(string FNMCAT_CODE, string CmpyCode, string UserName)
        {
            return _FNMCATRepo.DeleteFNMCAT(FNMCAT_CODE, CmpyCode, UserName);
        }

        public List<FNMCAT_VM> GetFNMCAT(string CmpyCode)
        {
            return _FNMCATRepo.GetFNMCAT(CmpyCode).Select(m => new FNMCAT_VM
            {
                CMPYCODE = m.CMPYCODE,
                FNMCAT_CODE = m.FNMCAT_CODE,
                DESCRIPTION = m.DESCRIPTION,
            }).ToList();
        }

        public FNMCAT_VM SaveFNMCAT(FNMCAT_VM FC)
        {
            return _FNMCATRepo.SaveFMHEAD(FC);
        }
    }
}
