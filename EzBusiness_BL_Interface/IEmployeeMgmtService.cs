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

        List<SelectListItem> GetCommList(string Type);
        List<SelectListItem> GetDivisionList(string CmpyCode);

        List<SelectListItem> GetProfList(string CmpyCode);

        List<SelectListItem>  GetBankList(string CmpyCode);
       // List<SelectListItem> GetAccList(string CmpyCode, string Typeofacc);
      



        List<SelectListItem> GetBankBranchList(string CmpyCode, string BankCode);

        List<SelectListItem> GetBranchCodeList(string CmpyCode, string DivCode);
        List<SelectListItem> GetDepartmentList(string CmpyCode, string divcode, string Brancode);

        List<SelectListItem> GetWeekdaysList(string CmpyCode);

        List<SelectListItem> GetStatusMasterList(string CmpyCode);

        List<SelectListItem> GetNationList(string CmpyCode);

      //  List<SelectListItem> GetDisciplineList(string CmpyCode);

        List<SelectListItem> GetSubTrademaster(string CmpyCode);

        List<SelectListItem> GetShiftMasterList(string CmpyCode);

        List<SelectListItem> GetVisaLocationList(string CmpyCode);

        List<SelectListItem> GetTDSTypesList(string CmpyCode);

        List<SelectListItem> GetPaymentNatureList(string CmpyCode);

        List<SelectListItem> GetTDSSection(string CmpyCode);

       // List<SelectListItem> GetEmployeeTypeMasterList(string CmpyCode);

        List<SelectListItem> GetLocationList(string CmpyCode);

        List<SelectListItem> GetDocList(string CmpyCode);

        List<SelectListItem> GetResidingYNList(string Type);

        List<SelectListItem> GetBloodGroupList(string Type);

        List<SelectListItem> GetDegreeList(string Cmpycode);

        List<SelectListItem> GetEmpList1(string cmpycode, string empcode);

        List<SelectListItem> GetSalution();

        List<SelectListItem> GetProjectList(string Cmpycode);


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
