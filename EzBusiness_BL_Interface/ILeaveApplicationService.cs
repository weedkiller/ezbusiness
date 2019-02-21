using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
    public interface ILeaveApplicationService
    {

        #region LeaveApp
        List<Leave_App_VW> GetLeaveApp(string CmpyCode);
        List<SelectListItem> GetEmpCodeList(string CmpyCode,string typ);

        List<SelectListItem> GetLeaveTypList(string CmpyCode);
        Leave_App_VW GetLeaveAppDetailsEdit(string CmpyCode, string code);
        List<LeaveApplicationDetail> GetLeaveAppDetailList(string CmpyCode, string EmpCode);
        Leave_App_VW SaveLeaveApp(Leave_App_VW LeaveApp);
        Leave_App_VW GetLeaveAppDetailsNew(string CmpyCode);
        DateTime GetJoiningdate(string CmpyCode, string EmpCode);

     

        decimal GetBalanceLeave(string CmpyCode, string EmpCode, string LeaveType, DateTime joiningdte);
        bool DeleteLeaveApp(string Cmpycode, string PRLR001_CODE, string oldLeavedays, string EmpCode, string UserName, string LeaveType);
        #endregion
    }
}
