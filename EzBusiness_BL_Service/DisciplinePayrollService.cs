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
    public class DisciplinePayrollService : IDisciplinePayrollService
    {
        IDisciplinePayrollRepository _DiRepo;

        public DisciplinePayrollService()
        {
            _DiRepo = new DisciplinePayrollRepository();
        }

        public bool DeleteDis(string Code, string CmpyCode, string UserName)
        {
            return _DiRepo.DeleteDis(Code, CmpyCode, UserName);
        }

        public List<DisciplineVM> GetDis(string CmpyCode)
        {
            return _DiRepo.GetDis(CmpyCode).Select(m => new DisciplineVM
            {
                CmpyCode = m.Cmpycode,
                Code = m.Code,
                Name = m.Name,
                UniCodeName = m.UniCodeName

            }).ToList();
        }

        public DisciplineVM SaveDis(DisciplineVM Dis)
        {
            return _DiRepo.SaveDis(Dis);
        }
    }
}
