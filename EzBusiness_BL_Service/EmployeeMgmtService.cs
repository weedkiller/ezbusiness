using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;
using EzBusiness_ViewModels;
using System.IO;
using System.Web;



namespace EzBusiness_BL_Service
{
    public class EmployeeMgmtService : IEmployeeMgmtService
    {       
        IEmployeeMgmtRepository _EmployeeMgmtRepo;

        ICodeGenRepository _CodeRep;   
        public EmployeeMgmtService()
        {
            _EmployeeMgmtRepo = new EmployeeMgmtRepository();
            _CodeRep = new CodeGenRepository();
        }

        public bool DeleteEmployee(string CmpyCode, string EmpCode, string UserName)
        {
            return _EmployeeMgmtRepo.DeleteEmployee(CmpyCode, EmpCode, UserName);
        }

    

     
        private List<SelectListItem> InsertFirstElementDDL(List<SelectListItem> items)
        {          
            items.Insert(0, new SelectListItem
            {
                Value = PurchaseMgmtConstants.DDLFirstVal,
                Text = PurchaseMgmtConstants.DDLFirstText
            });
            
            return items;
        }

        public List<SelectListItem> GetBankBranchList(string CmpyCode, string BankCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetBankBranchList(CmpyCode, BankCode)
                                        .Select(m => new SelectListItem { Value = m.PRBM002_code, Text = string.Concat(m.PRBM002_code, "-", m.Bank_branch_name) })
                                        .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetBankList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetBankList(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.PRBM001_code, Text=string.Concat(m.PRBM001_code, "-", m.Bank_name) })
                                       .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetCommList(string Type)
        {
            var itemCodes = _EmployeeMgmtRepo.GetCommList(Type)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat( m.Name) }) //m.Code, "-",
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetDepartmentList(string CmpyCode, string divcode, string Brancode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetDepartmentList(CmpyCode,  divcode,  Brancode)
                                      .Select(m => new SelectListItem { Value = m.DepartmentCode, Text = string.Concat(m.DepartmentCode, "-", m.DepartmentName) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetDisciplineList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetDisciplineList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetDivisionList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetDivisionList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.DivisionCode, Text = string.Concat(m.DivisionCode, "-", m.DivisionName) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<EducationDetailnew> GetEducationDetailList(string CmpyCode, string EmpCode)
        {
            var poEducationList = _EmployeeMgmtRepo.GetEducationDetailList(CmpyCode, EmpCode);
            return poEducationList.Select(m => new EducationDetailnew
            {
                Degree= m.Degree,
                DegreeName=m.DegreeName,
                Institution=m.Institution,
                Location=m.Location,
                ObtainedYear=m.ObtainedYear,
                SNo=m.SNo,
                Specification=m.Specification                    
            }).ToList();
        }

        public List<SelectListItem> GetResidingYNList(string Type)
        {
            var itemCodes = _EmployeeMgmtRepo.GetCommList(Type)
                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                    .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetBloodGroupList(string Type)
        {
            var itemCodes = _EmployeeMgmtRepo.GetCommList(Type)
                                   .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                   .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetDegreeList(string Cmpycode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetDegreeList(Cmpycode)
                                   .Select(m => new SelectListItem { Value = m.Name, Text = string.Concat(m.Code, "-", m.Name) })
                                   .ToList();

            return InsertFirstElementDDL(itemCodes);

        }
        public List<EmployeeDetailnew> GetEmployeeDetailList(string CmpyCode, string EmpCode)
        {
            var poEducationList = _EmployeeMgmtRepo.GetEmployeeDetailList(CmpyCode, EmpCode);
            return poEducationList.Select(m => new EmployeeDetailnew
            {
               Description=m.Description,
              // Doc=m.Doc,
               DocCode=m.DocCode,
               DocName=m.DocName,
               DocStatus=m.DocStatus,
               DocNo=m.DocNo,
               EndDate=m.EndDate,
//FileType=m.FileType,
              // FormType=m.FormType,
               IssuePlace=m.IssuePlace,
               //IssueState=m.IssueState,
               Preview=m.Preview,
               Sno=m.Sno,
               StartDate=m.StartDate,
               DocumentPath=m.DocumentPath
             
            }).ToList();
        }


        public List<Employee_VM> GetEmployeeList(string CmpyCode)
        {
            var poEmployeeList = _EmployeeMgmtRepo.GetEmployeeList(CmpyCode);
            return poEmployeeList.Select(m => new Employee_VM
            {
                EmpCode=m.EmpCode,
                Empname=m.Empname,
                DepartmentCode=m.DepartmentCode,
                EmpType=m.EmpType
            }).ToList();
        }

        public Employee_VM GetEmployeeMasterDetailsEdit(string CmpyCode, string EmpCode)
        {
            var poEdit = _EmployeeMgmtRepo.GetEmployeeMasterDetailsEdit(CmpyCode, EmpCode);
            poEdit.AccNoList = GetAccList(CmpyCode,"EXP");           
            poEdit.BankList = GetBankList(CmpyCode);

            poEdit.BankBranchCodeList = GetBankBranchList(CmpyCode,poEdit.BankCode);            
            poEdit.DiciplineList = GetDisciplineList(CmpyCode);
            poEdit.DivisionList = GetDivisionList(CmpyCode);
            poEdit.BranchCodeList = GetBranchCodeList(CmpyCode,poEdit.DivisionCode);
            poEdit.DepartmentList = GetDepartmentList(CmpyCode, poEdit.DivisionCode, poEdit.BranchCode);
            poEdit.EmployeeTypeList = GetEmployeeTypeMasterList(CmpyCode);
            poEdit.WorkingStatusList = GetStatusMasterList(CmpyCode);           
            poEdit.VisaLocationList = GetVisaLocationList(CmpyCode);
            poEdit.Week_offList = GetWeekdaysList(CmpyCode);         
            poEdit.AttTypeList = GetCommList("ATTTYPE");
            poEdit.OTMultiplierList = GetCommList("OTMULTIPLIER");
            poEdit.BloodGroupList = GetCommList("BLOODGROUP");                         
            poEdit.ReligionList= GetCommList("REGION");
            poEdit.SalutaionList = GetSalution();
            poEdit.ProfList = GetProfList(CmpyCode);
            poEdit.ReportingEmpList = GetEmpList1(CmpyCode, "SELF");
            poEdit.NationalityList = GetNationList(CmpyCode);
            poEdit.DocList = GetDocList(CmpyCode);
            poEdit.ResidingYNList = GetResidingYNList("YN");
            poEdit.ProjectList = GetProjectList(CmpyCode);
            poEdit.DegreeList = GetDegreeList(CmpyCode);
            poEdit.LocationList = GetLocationList(CmpyCode);
            poEdit.EducationDetail = new EducationDetailnew();
            poEdit.EducationDetailnews = GetEducationDetailList(CmpyCode, EmpCode);
        
            poEdit.EmployeeNominee = new EmployeeNomineenew();
            poEdit.EmployeeNomineenews = GetEmployeeNomineeList(CmpyCode, EmpCode);
            poEdit.EmployeeDetail = new EmployeeDetailnew();
            poEdit.EmployeeDetailnews = GetEmployeeDetailList(CmpyCode, EmpCode);
            poEdit.IsEditMode = true;
            return poEdit;
        }

        public Employee_VM GetEmployeeMasterDetailsNew(string CmpyCode)
        {

            List<SessionListnew> list = HttpContext.Current.Session["SesDet"] as List<SessionListnew>;

            return new Employee_VM
            {
                AccNoList = GetAccList(CmpyCode, "EXP"),
                EmpCode = _CodeRep.GetCode(CmpyCode, "EmployeeMaster"),

                BankList = GetBankList(CmpyCode),
                
                BankBranchCodeList = GetBankBranchList(CmpyCode,""),

                DiciplineList = GetDisciplineList(CmpyCode),
                DivisionList = GetDivisionList(CmpyCode),
                DivisionCode = list[0].Divcode.ToString(),

                BranchCodeList = GetBranchCodeList(CmpyCode, list[0].Divcode.ToString()),


                BranchCode = list[0].BraCode.ToString(),

                DepartmentList = GetDepartmentList(CmpyCode, list[0].Divcode, list[0].BraCode),
                DepartmentCode = list[0].DepCode.ToString(),

                EmployeeTypeList = GetEmployeeTypeMasterList(CmpyCode),
                WorkingStatusList = GetStatusMasterList(CmpyCode),
                WorkingStatus = "Y",
                VisaLocationList = GetVisaLocationList(CmpyCode),
              
                ReligionList = GetCommList("REGION"),
                AttTypeList = GetCommList("ATTTYPE"),
                OTMultiplierList = GetCommList("OTMULTIPLIER"),
                BloodGroupList = GetCommList("BLOODGROUP"),
               
                SalutaionList = GetSalution(),
                ProfList=GetProfList(CmpyCode),
                ReportingEmpList= GetEmpList1(CmpyCode, "SELF"),
              NationalityList=GetNationList(CmpyCode),
              DocList=GetDocList(CmpyCode),
              ResidingYNList=GetResidingYNList("YN"),
                ProjectList= GetProjectList(CmpyCode),
                DegreeList=GetDegreeList(CmpyCode),
                LocationList = GetLocationList(CmpyCode),
                Week_offList=GetWeekdaysList(CmpyCode),

            EducationDetailnews = new List<EducationDetailnew>(),
                EducationDetail = new EducationDetailnew(),
                EmployeeNomineenews = new List<EmployeeNomineenew>(),
                EmployeeNominee = new EmployeeNomineenew(),
                EmployeeDetailnews = new List<EmployeeDetailnew>(),
                EmployeeDetail = new EmployeeDetailnew(),                      
                IsEditMode = false
            };
        }

        
        public List<EmployeeNomineenew> GetEmployeeNomineeList(string CmpyCode, string EmpCode)
        {
            var EmployeeNomineeList = _EmployeeMgmtRepo.GetEmployeeNomineeList(CmpyCode, EmpCode);
            return EmployeeNomineeList.Select(m => new EmployeeNomineenew
            {
               
                NomineeAddress=m.NomineeAddress,
                NomineeDOB=m.NomineeDOB,
                NomineeName=m.NomineeName,
                NomineeRelation=m.NomineeRelation,
                
                SNo=m.SNo,
                                                            
            }).ToList();

        }

        public List<SelectListItem> GetEmployeeTypeMasterList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetEmployeeTypeMasterList(CmpyCode)
                                     .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                     .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

    
        public List<SelectListItem> GetLocationList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetLocationList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.LocCode, Text = string.Concat(m.LocCode, "-", m.LocName) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetNationList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetNationList(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                       .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetPaymentNatureList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetPaymentNatureList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetProfList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetProfList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.ProfCode, Text = string.Concat(m.ProfCode, "-", m.ProfName) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetShiftMasterList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetShiftMasterList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.PRSFT001_code, Text = string.Concat(m.PRSFT001_code, "-", m.ShiftName) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetStatusMasterList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetStatusMasterList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetSubTrademaster(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetSubTrademaster(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetTDSSection(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetTDSSection(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetTDSTypesList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetTDSTypesList(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat( m.Name) })//m.Code, "-",
                                       .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetVisaLocationList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetVisaLocationList(CmpyCode)
                                         .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat( m.Name) })//m.Code, "-",
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetWeekdaysList(string CmpyCode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetWeekdaysList(CmpyCode)
                                         .Select(m => new SelectListItem { Value = m.DayCode, Text = string.Concat( m.DayName) }) //m.DayCode, "-",
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
        }


        public List<SelectListItem> GetDocList(string CmpyCode)
        {

            var itemCodes = _EmployeeMgmtRepo.GetDocList(CmpyCode)
                                         .Select(m => new SelectListItem { Value = m.DocCode, Text = m.DocName })
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public Employee_VM SavePurchaseOrder(Employee_VM employeemaster)
        {
            if (!employeemaster.IsEditMode)
            {
                employeemaster.EmpCode = _CodeRep.GetCode(employeemaster.Cmpycode, "EmployeeMaster");
            }
            return _EmployeeMgmtRepo.SavePurchaseOrder(employeemaster);
        }

        public List<SelectListItem> GetSalution()
        {
            var itemCodes = _EmployeeMgmtRepo.GetSalution()
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Name) }) //m.Code, "-", 
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetAccList(string CmpyCode, string Typeofacc)
        {
            var itemCodes = _EmployeeMgmtRepo.GetAccList(CmpyCode, Typeofacc)
                                       .Select(m => new SelectListItem { Value = m.AccNo, Text = string.Concat(m.AccNo, "-", m.Description) })
                                       .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetEmpList1(string cmpycode, string empcode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetEmpList1(cmpycode, empcode)
                                        .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                        .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetProjectList(string Cmpycode)
        {
            var itemCodes = _EmployeeMgmtRepo.GetProjects(Cmpycode)
                                         .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetBranchCodeList(string CmpyCode, string DivCode)
        {
             var itemCodes = _EmployeeMgmtRepo.GetBranchCodeList(CmpyCode,DivCode)
                                        .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                        .ToList();  
            return InsertFirstElementDDL(itemCodes);
        }

       
    }
}
