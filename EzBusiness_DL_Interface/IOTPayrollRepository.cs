using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IOTPayrollRepository
    {

        #region OTPayroll
        List<Employee> GetEmpCodeList(string CmpyCode);

        List<Attendence> GetLeaveTypList(string CmpyCode);

        List<TimeSheetDetail> GetOTDetailList(string CmpyCode, string EmpCode, DateTime dte);

        List<TimeSheetDetail> GetAPDetailList(string CmpyCode, string EmpCode, DateTime dte);

        OTVM SaveOT(OTVM OT);

        OTVM SaveAP(OTVM OT);

        #endregion
    }
}
