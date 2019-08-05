using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;


namespace EzBusiness_DL_Interface
{
    public interface IDutyResumePayrollRepository
    {
        #region DutyResume Master
        List<DutyResume> GetDrs(string Cmpycode);

        DutyResumeVM SaveDrs(DutyResumeVM Drs);

        DutyResumeVM GetDutyEdit(string Cmpycode,string lsno);      

        List<Employee> GetEmpCodes(string Cmpycode);

        List<ComDropTbl> GetLsNo(string Cmpycode,string Prefix);
        List<ComDropTbl> GetLsNoEdit(string Cmpycode, string Prefix);
        List<LeaveApplication> GetLsNo11(string Cmpycode, string typ);
        List<Attendence> GetLeaveTypList(string CmpyCode);
        List<LeaveApplication> GetLeaveData(string cmpycode, string LanNo);

        // bool DeleteDrs(string Cmpycode );
        bool DeleteDrs(string Cmpycode, string PRDR001_CODE, string oldLeavedays, string EmpCode, string UserName);

        #endregion

        #region DutyResume Request



        #endregion
    }
}
