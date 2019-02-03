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
    public class ProfessionPayrollService : IProfessionPayrollService
    {
        IProfessionPayrollRepository _ProRepo;
        public ProfessionPayrollService()
        {
            _ProRepo = new ProfessionPayrollRepository();
        }

        public bool DeletePros(string ProfCode, string CmpyCode, string UserName)
        {
            return _ProRepo.DeletePros(ProfCode, CmpyCode, UserName);
        }

        public List<ProfessionVM> GetPros(string CmpyCode)
        {
            return _ProRepo.GetPros(CmpyCode).Select(m => new ProfessionVM
            {
                CmpyCode = m.CmpyCode,
                ProfCode = m.ProfCode,
                ProfName = m.ProfName,
            //    UniCodeName = m.UniCodeName,
                ProfType = m.ProfType,

            }).ToList();
        }

        public ProfessionVM SavePros(ProfessionVM Pros)
        {
            return _ProRepo.SavePros(Pros);
        }
    }
}
