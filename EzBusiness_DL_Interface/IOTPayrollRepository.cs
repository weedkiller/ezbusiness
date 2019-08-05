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


        List<Division>  GetDivCodeList(string CmpyCode);

     //   List<ComDropTbl> GetDivCodeList1(string CmpyCode,string Prefix);
        List<ProjectMaster> GetPrjCodeList(string CmpyCode);

        List<Employee> GetEmpRepCodeList(string CmpyCode,string EmpCode, string DivCode,string prjCode);

        List<Attendence> GetLeaveTypList(string CmpyCode);

        List<TimeSheetDetail> GetOTDetailList(string CmpyCode, string EmpCode, DateTime dte, DateTime dte1,string typ);

        List<TimeSheetDetail> GetAPDetailList(string CmpyCode, string EmpCode, DateTime dte);

        OTVM SaveOT(OTVM OT);

        OTVM SaveAP(OTVM OT);

        #endregion
    }
}
