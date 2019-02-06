using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface
{
    public interface IReportDetailsRepository
    {
        List<Employee> GetEmpReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode);

        List<FinalSettalment> GetFinalSettlementDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode);

        List<MonthlyAdddedDet> GetMonthlyAddDeductDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode);

        List<LoanAppliation> GetLoanApplicatnDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode);

        List<Holiday> GetHolidayDetails(string CmpyCode, string HoliCode);

        List<Loan> GetLoanDetails(string CmpyCode, string LoanCode, string LoanName);

        List<Profession> GetProfessionReprtDetails(string CmpyCode, string profCode, string ProfName);

        List<LeaveApplication> GetLeaveReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate);
        List<LeaveSettlement> GetLeaveSettlemenntReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate);

        List<DutyResume> GetDutyResumeReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string EmpCode,string EmpName);
        List<ShiftMaster> GetShiftMasterDetails(string CmpyCode, DateTime Fromdate, DateTime Todate);

    }
}
