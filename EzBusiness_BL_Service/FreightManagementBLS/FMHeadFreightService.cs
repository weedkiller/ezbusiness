using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface.FreightManagement;
using EzBusiness_DL_Interface.FreightManagement;
using EzBusiness_DL_Repository.FreightManagement;
using EzBusiness_EF_Entity.FreightManagement;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
   public class FMHeadFreightService : IFMHeadFreightService
    {
        IFMHeadFreightRepository _FMHeadRepo;

        public FMHeadFreightService()
        {
            _FMHeadRepo = new FMHeadFreightRepository();
        }

        public bool DeleteFMHEAD(string FNMHEAD_CODE, string CmpyCode, string UserName)
        {
           return _FMHeadRepo.DeleteFMHEAD(FNMHEAD_CODE, CmpyCode, UserName);


        }

        public List<FMHEAD_VM> GetFMHEAD(string CmpyCode)
        {
            return _FMHeadRepo.GetFMHEAD(CmpyCode).Select(m => new FMHEAD_VM
            {
                CMPYCODE = m.CMPYCODE,
                FNMHEAD_CODE = m.FNMHEAD_CODE,
                DESCRIPTION = m.DESCRIPTION,
              

            }).ToList();
        }

        public FMHEAD_VM SaveFMHEAD(FMHEAD_VM FH)
        {
            return _FMHeadRepo.SaveFMHEAD(FH);
        }
    }
}
