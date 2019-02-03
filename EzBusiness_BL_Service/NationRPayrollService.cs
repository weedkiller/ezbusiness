using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Service
{
    public class NationRPayrollService : INationRPayrollService
    {
        INationRPayrollRepository _NrRepo;

        public NationRPayrollService()
        {
            _NrRepo = new NationRPayrollRepository();
        }

        public bool DeleteNrs(string Code, string CmpyCode, string UserName)
        {
            return _NrRepo.DeleteNrs(Code, CmpyCode, UserName);
        }

        public List<NationRegionVM> GetNrs(string CmpyCode)
        {
            return _NrRepo.GetNrs(CmpyCode).Select(m => new NationRegionVM
            {
                CmpyCode = m.Cmpycode,
                Code = m.Code,
                Name = m.Name,
                UniCodeName = m.UniCodeName

            }).ToList();
        }

        public NationRegionVM SaveNrs(NationRegionVM Nrs)
        {
            return _NrRepo.SaveNrs(Nrs);
        }
    }
}
