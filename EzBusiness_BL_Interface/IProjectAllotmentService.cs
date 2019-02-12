using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;
namespace EzBusiness_BL_Interface
{
    public interface IProjectAllotmentService
    {        
        ProjectAllotmentVM NewProjectAllotment(string CmpyCode);
        List<ProjectAllotmentVM> GetProjectAllotmentList(string CmpyCode);
        ProjectAllotmentVM SaveProjectAllotment(ProjectAllotmentVM PrjAlt);
        ProjectAllotmentVM GetProjectAllotmentEdit(string CmpyCode, string PRPRJE001_code);
        List<SelectListItem> GetEmpCodes(string CmpyCode);
        List<SelectListItem> GetProjectCodes(string CmpyCode);
        bool DeleteProjectAllotment(string CmpyCode, string PRPRJE001_code, string UserName);
    }
}
