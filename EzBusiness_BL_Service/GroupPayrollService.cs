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
    public class GroupPayrollService : IGroupPayrollService
    {
        IGroupPayrollRepository _GrRepo;

        public GroupPayrollService()
        {
            _GrRepo = new GroupPayrollRepository();
        }

        public bool DeleteGrs(string DivisionCode, string CmpyCode, string UserName)
        {
            return _GrRepo.DeleteGrs(DivisionCode, CmpyCode, UserName);
        }

        public List<GroupVM> GetGrs(string CmpyCode)
        {
            return _GrRepo.GetGrs(CmpyCode).Select(m => new GroupVM
            {
                CmpyCode = m.Cmpycode,
                DivisionCode = m.DivisionCode,
                DivisionName = m.DivisionName,
                UniCodeName = m.UniCodeName

            }).ToList();
        }

        public GroupVM SaveGrs(GroupVM Grs)
        {
            return _GrRepo.SaveGrs(Grs);
        }
    }
}
