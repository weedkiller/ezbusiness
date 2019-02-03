using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IDepartmentPayrollRepository
    {
        #region Department Master
        List<Department> GetDeps(string CmpyCode);

        DepartmentVM SaveDeps(DepartmentVM Deps);

        List<Division> GetDivisionList(string CmpyCode);

       // List<Branch> GetBranchList(string CmpyCode);

        List<BranchTbl> GetBranchCode(string CmpyCode,string Divcode);

        List<Department> GetDepartmentList(string CmpyCode, string DivCode, string BranchCode);
        bool DeleteDeps(string DepartmentCode, string CmpyCode, string UserName);


        #endregion
    }
}
