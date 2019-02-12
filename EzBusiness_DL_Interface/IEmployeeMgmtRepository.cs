using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IEmployeeMgmtRepository
    {
        #region Employee Master

        List<CommonTable> GetCommList(string Type);

        List<Division> GetDivisionList(string CmpyCode);

       

        List<Profession> GetProfList(string CmpyCode);


        List<ProjectMaster> GetProjects(string CmpyCode);

        List<BankMaster> GetBankList(string CmpyCode);
        List<Accounts_Tbl> GetAccList(string CmpyCode,string Typeofacc);

      

        List<BankBranchTbl> GetBankBranchList(string CmpyCode,string Branchcode);

        List<BranchTbl> GetBranchCodeList(string CmpyCode,string divcode);

        List<Department> GetDepartmentList(string CmpyCode, string divcode,string Brancode);




        List<Weekdays> GetWeekdaysList(string CmpyCode);

        List<StatusMaster> GetStatusMasterList(string CmpyCode);

        List<Nation> GetNationList(string CmpyCode);

        List<Discipline> GetDisciplineList(string CmpyCode);

        List<SubTrademaster> GetSubTrademaster(string CmpyCode);

        List<ShiftMaster> GetShiftMasterList(string CmpyCode);

        List<VisaLocation> GetVisaLocationList(string CmpyCode);

        List<TDSTypes> GetTDSTypesList(string CmpyCode);

        List<PaymentNature> GetPaymentNatureList(string CmpyCode);

        List<TDSSection> GetTDSSection(string CmpyCode);

        List<EmployeeTypeMaster> GetEmployeeTypeMasterList(string CmpyCode);

        List<Location> GetLocationList(string CmpyCode);


        List<EducationLevel> GetDegreeList(string CmpyCode);


        Employee_VM GetEmployeeMasterDetailsEdit(string CmpyCode, string EmpCode);

        Employee_VM SavePurchaseOrder(Employee_VM EmployeeMaster );

        List<Employee> GetEmployeeList(string CmpyCode);

        List<EmployeeDetail> GetEmployeeDetailList(string CmpyCode, string EmpCode);

        //List<LeaveApplication> GetLeaveApplicationList(string CmpyCode, string EmpCode);


        List<EmployeeExp> GetEmployeeExpList(string CmpyCode, string EmpCode);

        List<EmployeeNominee> GetEmployeeNomineeList(string CmpyCode, string EmpCode);


        List<EducationDetail> GetEducationDetailList(string CmpyCode, string EmpCode);
     
        List<Documents> GetDocList(string CmpyCode);

        List<Grade> GetSalution();

        List<Employee> GetEmpList1(string CmpyCode, string empcode);

        bool DeleteEmployee(string CmpyCode, string EmpCode, string UserName);
        #endregion
    }
}
