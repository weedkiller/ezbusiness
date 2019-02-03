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
    public class StatePayrollService : IStatePayrollService
    {
        IStatePayrollRepository _StRepo;

        public StatePayrollService()
        {
            _StRepo = new StatePayrollRepository();
        }

        public bool DeleteSts(string Code, string CmpyCode, string UserName)
        {
            return _StRepo.DeleteSts(Code, CmpyCode, UserName);
        }

        public List<StateVM> GetSts(string CmpyCode)
        {
            return _StRepo.GetSts(CmpyCode).Select(m => new StateVM
            {
                CmpyCode = m.CmpyCode,
                Code = m.Code,
                Name = m.Name
                

            }).ToList();
        }

        public StateVM SaveSts(StateVM Sts)
        {
            return _StRepo.SaveSts(Sts);
        }
    }
}
