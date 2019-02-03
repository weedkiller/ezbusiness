using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using System.Web.Mvc;

using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Interface
{
    public interface IDepartmentPayrollService
    {
        List<DepartmentVM> GetDeps(string CmpyCode);

        DepartmentVM SaveDeps(DepartmentVM Deps);

        List<Division> GetDivisionList(string CmpyCode);


        List<SelectListItem> GetDepartmentList(string CmpyCode, string DivCode, string BranchCode);

        //List<Branch> GetBranchList(string CmpyCode);

        List<SelectListItem> GetBranchCode(string CmpyCode, string Divcode);




        bool DeleteDeps(string DepartmentCode, string CmpyCode, string UserName);
    }
}
