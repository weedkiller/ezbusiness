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
    public class LoanPayrollService : ILoanPayrollService
    {
        ILoanPayrollRepository _LonRepo;

        public LoanPayrollService()
        {
            _LonRepo = new LoanPayrollRepository();
        }

        public bool DeleteLons(string Code, string CmpyCode, string UserName)
        {
            return _LonRepo.DeleteLons(Code, CmpyCode, UserName);
        }

        public List<LoanVM> GetLons(string CmpyCode)
        {
            return _LonRepo.GetLons(CmpyCode).Select(m => new LoanVM
            {
                PRLM001_CODE = m.PRLM001_CODE,
                COUNTRY = m.COUNTRY,
                CmpyCode = m.CmpyCode,
                Name = m.Name,
                Act_code = m.Act_code,
            }).ToList();
        }

        public LoanVM SaveLons(LoanVM Lons)
        {
            return _LonRepo.SaveLons(Lons);
        }
    }
}
