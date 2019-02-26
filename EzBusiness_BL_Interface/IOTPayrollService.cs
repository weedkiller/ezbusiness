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
    public interface IOTPayrollService
    {
        List<SelectListItem> GetEmpCodeList(string CmpyCode);


        List<Employee> GetEmpRepCodeList(string CmpyCode, string EmpCode);
        List<Attendence> GetLeaveTypList(string CmpyCode);
        List<TimeSheetDetail> GetLeaveAppDetailList(string CmpyCode, string EmpCode, DateTime dte);

        List<TimeSheetDetail> GetAPDetailList(string CmpyCode, string EmpCode, DateTime dte);

        OTVM SaveOT(OTVM OT);

        OTVM SaveAP(OTVM OT);
        OTVM GetOTVMNew(string CmpyCode);




    }
}
