using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IProjectAllotmentRepository
    {

        #region ProjectAllotment
        List<ProjectAllotment> GetProjectAllotmentList(string CmpyCode);
        ProjectAllotmentVM SaveProjectAllotment(ProjectAllotmentVM PrjAlt);

        ProjectAllotmentVM GetProjectAllotmentEdit(string CmpyCode, string PRPRJE001_code);
        List<Employee> GetEmpCodes(string CmpyCode);
        List<ProjectMaster> GetProjectCodes(string CmpyCode);        
        bool DeleteProjectAllotment(string CmpyCode, string PRPRJE001_code, string UserName);
        #endregion
    }
}
