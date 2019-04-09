using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
   public interface IReportDetailsServices
    {
        List<Employee> GetEmpReportDetails(string CmpyCode, DateTime Fromdate,DateTime Todate,string EmpName,string EmpCode, string search);
        List<Employee> EmpReportDetailsColumnWithOrder(string order, string orderDir, List<Employee> data);

        List<FinalSettalment> GetFinalSettlementDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode,string search);
        List<FinalSettalment> FinalsettlementDetailsColumnWithOrder(string order, string orderDir, List<FinalSettalment> data);

        List<MonthlyAdddedDet> GetMonthlyAddDeductDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode,string search);
        List<MonthlyAdddedDet> MonthlyAddDeductDetailsColumnWithOrder(string order, string orderDir, List<MonthlyAdddedDet> data);

        List<LoanAppliation> GetLoanApplicatnDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode, string search);
        List<LoanAppliation> LoanApplicatnDetailsColumnWithOrder(string order, string orderDir, List<LoanAppliation> data);

        List<Holiday> GetHolidayDetails(string CmpyCode, string HoliCode, string search);
        List<Holiday> HolidayDetailsColumnWithOrder(string order, string orderDir, List<Holiday> data);

        List<Loan> LoanDetailsColumnWithOrder(string order, string orderDir, List<Loan> data);
        List<Loan> GetLoanDetails(string CmpyCode, string LoanCode, string LoanName, string search);

        List<Profession> GetProfessionReprtDetails(string CmpyCode, string profCode, string profName, string search);
        List<Profession> ProfssnDetailsColumnWithOrder(string order, string orderDir, List<Profession> data);

        List<LeaveApplication> GetLeaveAppDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string EmpCode,string EmpName);
        List<LeaveApplication> EmpReportLeaveAppColumnWithOrder(string order, string orderDir, List<LeaveApplication> data);

        List<LeaveSettlement> GetLeaveSettlemenntReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpCode, string EmpName);
        List<LeaveSettlement> EmpLeaveSettlemenntColumnWithOrder(string order, string orderDir, List<LeaveSettlement> data);

        List<DutyResume> GetDutyResumeDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string Empcode,string EmpName);
        List<DutyResume> EmpReportDutyResumeColumnWithOrder(string order, string orderDir, List<DutyResume> data);

        List<ShiftMaster> GetShiftMasterDetails(string CmpyCode, string ShiftCode);
        List<ShiftMaster> ShiftMasterReportDetailsColumnWithOrder(string order, string orderDir, List<ShiftMaster> data);
        List<TimeSheetDetail> GetProjectDetailsEmployeeWise(string CmpyCode,DateTime CurrentDate);
        List<TimeSheetDetail> ProjectReportDetailsColumnWithOrder(string order, string orderDir, List<TimeSheetDetail> data);

        List<SalaryProcessDetailsRep> GetSalaryProcessDetails(string CmpyCode, DateTime CurrDate, string DivCode, string deptcode, string visaloc, string search);


        List<SalaryProcessDetailsRep> SalaryProcessDetailsRepColumnWithOrder(string order, string orderDir, List<SalaryProcessDetailsRep> data);

        SalaryProcessDetailsRep GetSalaryProcessDetailList(string CmpyCode);

        List<SelectListItem> GetDivCodeList(string CmpyCode);

        List<SelectListItem> GetVisLocList(string CmpyCode);
        List<SelectListItem> GetDepartmentList(string CmpyCode, string divcode);


        List<GetEmpBankTrf> GetEmpBankTrf(string cmpycode, DateTime CurrDate);
        List<GetEmpBankTrf> EmpBankTrfColumnWithOrder(string order, string orderDir, List<GetEmpBankTrf> data);
    }
}
