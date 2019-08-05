using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface ILeaveApplicationRepository
    {
        #region LeaveApp
        List<LeaveApplication> GetLeaveApp(string CmpyCode);
        List<Employee> GetEmpCodeList(string CmpyCode,string typ);

        List<ComDropTbl> GetLeaveTypList(string CmpyCode,string Prefix);
        Leave_App_VW GetLeaveAppDetailsEdit(string CmpyCode, string code);
        List<LeaveApplicationDetail> GetLeaveAppDetailList(string CmpyCode, string EmpCode);    
        Leave_App_VW SaveLeaveApp(Leave_App_VW LeaveApp);

  

        DateTime GetJoiningdate(string CmpyCode, string EmpCode);


        decimal GetBalanceLeave(string CmpyCode, string EmpCode, string LeaveType, DateTime joiningdte);
        bool DeleteLeaveApp(string Cmpycode, string PRLR001_CODE, string oldLeavedays, string EmpCode, string UserName, string LeaveType);
        #endregion
    }
}
