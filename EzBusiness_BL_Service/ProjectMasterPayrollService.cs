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
    public class ProjectMasterPayrollService : IProjectMasterPayrollService
    {
        IProjectMasterPayrollRepository _PjmsRepo;

        public ProjectMasterPayrollService()
        {
            _PjmsRepo = new ProjectMasterPayrollRepository();
        }

        public bool DeletePjms(string Code, string CmpyCode, string UserName)
        {
            return _PjmsRepo.DeletePjms(Code, CmpyCode, UserName);
        }

        public List<ProjectMasterVM> GetPjms(string CmpyCode)
        {
            return _PjmsRepo.GetPjms(CmpyCode).Select(m => new ProjectMasterVM
            {
                Code = m.Code,                
                CmpyCode = m.CmpyCode,
                Name = m.Name,
                Active = m.Active,
            }).ToList();
        }

        public ProjectMasterVM SavePjms(ProjectMasterVM Pjms)
        {
            return _PjmsRepo.SavePjms(Pjms);
        }
    }
}
