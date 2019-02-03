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
    public  class VisaLocationPayrollService : IVisaLocationPayrollService
    {
        IVisaLocationPayrollRepository _VlRepo;

        public VisaLocationPayrollService()
        {
            _VlRepo = new VisaLocationPayrollRepository();
        }

        public bool DeleteVls(string Code, string CmpyCode, string UserName)
        {
            return _VlRepo.DeleteVls(Code, CmpyCode, UserName);
        }

        public List<VisaLocationVM> GetVls(string CmpyCode)
        {
            return _VlRepo.GetVls(CmpyCode).Select(m => new VisaLocationVM
            {
                CmpyCode = m.CmpyCode,
                Code = m.Code,
                Name = m.Name,
                CompanyMolID=m.CompanyMolID

            }).ToList();
        }

        public VisaLocationVM SaveVls(VisaLocationVM Vls)
        {
            return _VlRepo.SaveVls(Vls);
        }
    }
}
