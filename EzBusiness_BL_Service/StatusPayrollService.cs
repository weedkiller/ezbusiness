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
    public class StatusPayrollService : IStatusPayrollService
    {
        IStatusPayrollRepository _StatRepo;

        public StatusPayrollService()
        {
            _StatRepo = new StatusPayrollRepository();
        }

        public bool DeleteStats(string Code, string CmpyCode, string UserName)
        {
            return _StatRepo.DeleteStats(Code, CmpyCode, UserName);
        }

        public List<StatusVM> GetStats(string CmpyCode)
        {
            return _StatRepo.GetStats(CmpyCode).Select(m => new StatusVM
            {
                CmpyCode = m.Cmpycode,
                Code = m.Code,
                Name = m.Name,
               // UniCodeName = m.UniCodeName

            }).ToList();
        }

        public StatusVM SaveStats(StatusVM StatustMaster)
        {
            return _StatRepo.SaveStats(StatustMaster);
        }
    }
}
