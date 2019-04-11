using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IProjectAllotmentNewRepository
    {

        #region ProjectAllotment
        List<PRPJXDTD> GetProjectAllotmentList(string CmpyCode);
        PRPJXDTDVM SaveProjectAllotment(PRPJXDTDVM PrjAlt);

        PRPJXDTDVM GetProjectAllotmentEdit(string CmpyCode, string PRPJXDTD001_UID);
        List<Employee> GetEmpCodes(string CmpyCode);
        List<ProjectMaster> GetProjectCodes(string CmpyCode);
        bool DeleteProjectAllotment(string CmpyCode, string PRPJXDTD001_UID, string UserName);
        #endregion
    }
}
