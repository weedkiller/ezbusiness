using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Login;
using System.Web.Mvc;


namespace EzBusiness_BL_Interface
{
   public interface ILoginService
    {
        List<SelectListItem> GetCompanyList();

        List<SelectListItem> GetDivisionList(string CmpyCode);
        List<SelectListItem> GetBranchList(string CmpyCode, string DivCode);

        List<SelectListItem> GetDepartmentList(string CmpyCode, string DivCode, string BranchCode);
        LoginVM SaveLons(LoginVM LoginVM);

    }
}
