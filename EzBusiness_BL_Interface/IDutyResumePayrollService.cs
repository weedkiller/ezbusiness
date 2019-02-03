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
    public interface IDutyResumePayrollService
    {
        List<DutyResumeVM> GetDrs(string Cmpycode);

        DutyResumeVM SaveDrs(DutyResumeVM Drs);

        DutyResumeVM GetDutyAddNew(string Cmpycode);

        DutyResumeVM GetDutyEdit(string Cmpycode,string lsno);
        List<SelectListItem> GetEmpCodes(string Cmpycode);
        List<LeaveApplication> GetLeaveData(string cmpycode, string LanNo);
        List<SelectListItem> GetLsNo(string Cmpycode, string typ);

        List<SelectListItem> GetLeaveTypList(string CmpyCode);

        //bool DeleteDrs(string Cmpycode);

        bool DeleteDrs(string Cmpycode, string PRDR001_CODE, string oldLeavedays, string EmpCode, string UserName);
    }
}
