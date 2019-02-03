using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IProjectMasterPayrollRepository
    {
        #region Project Master
        List<ProjectMaster> GetPjms(string CmpyCode);

        ProjectMasterVM SavePjms(ProjectMasterVM Pjms);



        bool DeletePjms(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
