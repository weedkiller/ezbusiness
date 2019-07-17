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

        List<ComDropTbl> GetCommList(string Type, string Prefix);

        List<ComDropTbl> GetDivisionList(string CmpyCode, string Prefix);

       

        List<ComDropTbl> GetProfList(string CmpyCode, string Prefix);


        List<ComDropTbl> GetProjects(string CmpyCode, string Prefix);

        List<ComDropTbl> GetBankList(string CmpyCode, string Prefix);
      //  List<Accounts_Tbl> GetAccList(string CmpyCode,string Typeofacc);

      

        List<ComDropTbl> GetBankBranchList(string CmpyCode,string Branchcode, string Prefix);

        List<ComDropTbl> GetBranchCodeList(string CmpyCode,string divcode, string Prefix);

        List<ComDropTbl> GetDepartmentList(string CmpyCode, string divcode,string Brancode, string Prefix);




        List<ComDropTbl> GetWeekdaysList(string CmpyCode, string Prefix);

        List<ComDropTbl> GetStatusMasterList(string CmpyCode, string Prefix);

        List<ComDropTbl> GetNationList(string CmpyCode, string Prefix);

      //  List<Discipline> GetDisciplineList(string CmpyCode);

        List<ComDropTbl> GetSubTrademaster(string CmpyCode, string Prefix);

        List<ComDropTbl> GetShiftMasterList(string CmpyCode, string Prefix);

        List<ComDropTbl> GetVisaLocationList(string CmpyCode, string Prefix);

        List<ComDropTbl> GetTDSTypesList(string CmpyCode, string Prefix);

        List<ComDropTbl> GetPaymentNatureList(string CmpyCode, string Prefix);

        List<ComDropTbl> GetTDSSection(string CmpyCode, string Prefix);

       // List<EmployeeTypeMaster> GetEmployeeTypeMasterList(string CmpyCode);

        List<ComDropTbl> GetLocationList(string CmpyCode, string Prefix);


        List<ComDropTbl> GetDegreeList(string CmpyCode, string Prefix);


        Employee_VM GetEmployeeMasterDetailsEdit(string CmpyCode, string EmpCode);

        Employee_VM SavePurchaseOrder(Employee_VM EmployeeMaster );

        List<Employee> GetEmployeeList(string CmpyCode);

        List<EmployeeDetail> GetEmployeeDetailList(string CmpyCode, string EmpCode,string DivCode);

        //List<LeaveApplication> GetLeaveApplicationList(string CmpyCode, string EmpCode);


        List<EmployeeExp> GetEmployeeExpList(string CmpyCode, string EmpCode);

        List<EmployeeNominee> GetEmployeeNomineeList(string CmpyCode, string EmpCode);


        List<EducationDetail> GetEducationDetailList(string CmpyCode, string EmpCode);
     
        List<ComDropTbl> GetDocList(string CmpyCode, string Prefix);

        List<ComDropTbl> GetSalution(string Prefix);

        List<ComDropTbl> GetEmpList1(string CmpyCode, string empcode, string Prefix);

        bool DeleteEmployee(string CmpyCode, string EmpCode, string UserName);
        #endregion
    }
}
