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
    public interface  IEmployeeMgmtService
    {

        List<SelectListItem> GetCommList(string Type,string Prefix);
        List<SelectListItem> GetDivisionList(string CmpyCode, string Prefix);

        List<SelectListItem> GetProfList(string CmpyCode, string Prefix);

        List<SelectListItem>  GetBankList(string CmpyCode, string Prefix);
       // List<SelectListItem> GetAccList(string CmpyCode, string Typeofacc);
      



        List<SelectListItem> GetBankBranchList(string CmpyCode, string BankCode, string Prefix);

        List<SelectListItem> GetBranchCodeList(string CmpyCode, string DivCode, string Prefix);
        List<SelectListItem> GetDepartmentList(string CmpyCode, string divcode, string Brancode, string Prefix);

        List<SelectListItem> GetWeekdaysList(string CmpyCode, string Prefix);

        List<SelectListItem> GetStatusMasterList(string CmpyCode, string Prefix);

        List<SelectListItem> GetNationList(string CmpyCode, string Prefix);

      //  List<SelectListItem> GetDisciplineList(string CmpyCode);

        List<SelectListItem> GetSubTrademaster(string CmpyCode, string Prefix);

        List<SelectListItem> GetShiftMasterList(string CmpyCode, string Prefix);

        List<SelectListItem> GetVisaLocationList(string CmpyCode, string Prefix);

        List<SelectListItem> GetTDSTypesList(string CmpyCode, string Prefix);

        List<SelectListItem> GetPaymentNatureList(string CmpyCode, string Prefix);

        List<SelectListItem> GetTDSSection(string CmpyCode, string Prefix);

       // List<SelectListItem> GetEmployeeTypeMasterList(string CmpyCode);

        List<SelectListItem> GetLocationList(string CmpyCode, string Prefix);

        List<SelectListItem> GetDocList(string CmpyCode, string Prefix);

        List<SelectListItem> GetResidingYNList(string Type, string Prefix);

        List<SelectListItem> GetBloodGroupList(string Type, string Prefix);

        List<SelectListItem> GetDegreeList(string Cmpycode, string Prefix);

        List<SelectListItem> GetEmpList1(string cmpycode, string empcode, string Prefix);

        List<SelectListItem> GetSalution( string Prefix);

        List<SelectListItem> GetProjectList(string Cmpycode, string Prefix);


        Employee_VM GetEmployeeMasterDetailsEdit(string CmpyCode, string EmpCode,string DivCode);

        Employee_VM GetEmployeeMasterDetailsNew(string CmpyCode);
        Employee_VM SavePurchaseOrder(Employee_VM EmployeeMaster);

        List<Employee_VM> GetEmployeeList(string CmpyCode);

        List<EmployeeDetailnew> GetEmployeeDetailList(string CmpyCode, string EmpCode,string DivCode);

        //List<LeaveApplicationnew>  GetLeaveApplicationList(string CmpyCode, string EmpCode);

        //List<EmployeeExpnew> GetEmployeeExpList(string CmpyCode, string EmpCode);

        List<EmployeeNomineenew> GetEmployeeNomineeList(string CmpyCode, string EmpCode);

        List<EducationDetailnew> GetEducationDetailList(string CmpyCode, string EmpCode);

   
        bool DeleteEmployee(string CmpyCode, string EmpCode, string UserName);
    }
}
