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
    public interface IProjectAllotmentNewService
    {
        PRPJXDTDVM NewProjectAllotmentN(string CmpyCode);
        List<PRPJXDTDVM> GetProjectAllotmentList(string CmpyCode);
        PRPJXDTDVM SaveProjectAllotment(PRPJXDTDVM PrjAlt);
        PRPJXDTDVM GetProjectAllotmentEdit(string CmpyCode, string PRPJXDTD001_UID);
        List<SelectListItem> GetEmpCodes(string CmpyCode);
        List<SelectListItem> GetProjectCodes(string CmpyCode);
        bool DeleteProjectAllotment(string CmpyCode, string PRPJXDTD001_UID, string UserName);
    }
}
