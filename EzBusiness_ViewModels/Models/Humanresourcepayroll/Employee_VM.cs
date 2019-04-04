using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class Employee_VM
    {
        public string Cmpycode { get; set; }
        public string EmpCode { get; set; }
        public string Empname { get; set; }
        public string EmpType { get; set; }
        public List<SelectListItem> EmployeeTypeList { get; set; }
        public string DivisionCode { get; set; }
        public List<SelectListItem> DivisionList { get; set; }
        public string ProfCode { get; set; }
        public List<SelectListItem> ProfList { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public string Sex { get; set; }
        public string SalType { get; set; }
        public string Address { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FirstSetDate { get; set; }       
        public string LeaveStatus { get; set; }
        public string WorkingStatus { get; set; }
        public List<SelectListItem> WorkingStatusList { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> LastRetDate { get; set; }          
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        public string VisaLocation { get; set; }
        public List<SelectListItem> VisaLocationList { get; set; }
        public string Nationality { get; set; }
        public List<SelectListItem> NationalityList { get; set; }       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOB { get; set; }        
        public string VisaStatus { get; set; }
        public string WorkLocation { get; set; }
        public string AddressLocal { get; set; }       
        public string DepartmentCode { get; set; }
        public List<SelectListItem> DepartmentList { get; set; }
        public string ProjectCode { get; set; }
        public List<SelectListItem> ProjectList { get; set; }
        public string BankCode { get; set; }
        public List<SelectListItem> BankList { get; set; }
        public string BankAccNo { get; set; }
        public string AccNo { get; set; }
        public List<SelectListItem> AccNoList { get; set; }               
        public List<SelectListItem> OTMultiplierList { get; set; } 
        public string ReportingEmp { get; set; }
        public List<SelectListItem> ReportingEmpList { get; set; }
        public string MaritalStatus { get; set; }
        public string BloodGroup { get; set; }
        public List<SelectListItem> BloodGroupList { get; set; }
        public string PhysicallyDisabledYN { get; set; }
        public string PhysicallyDisabled { get; set; }       
        public List<SelectListItem> ReligionList { get; set; }
        public string Salutaion { get; set; }
        public List<SelectListItem> SalutaionList { get; set; }                
        public string ContactNo { get; set; }
        public string EMail { get; set; }
        public string BranchCode { get; set; }        
        public List<SelectListItem> BranchCodeList { get; set; }
        public string BankBranchCode { get; set; }
        public List<SelectListItem> BankBranchCodeList { get; set; }        
        public List<SelectListItem> AttTypeList { get; set; }                   
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ContactDate { get; set; }
        public string AbscondingYN { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AbscondingDate { get; set; }        
        public List<SelectListItem> DiciplineList { get; set; }        
        public string TicketType { get; set; }
        public string TicketNo { get; set; }
        public string Contract { get; set; }
        public string SupervisorYN { get; set; }
        public string LanguageKnown { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> LeaveSettlementDate { get; set; }
        public string PANNumber { get; set; }             
        public string GroupCode { get; set; }       
        public string LocCode { get; set; }
        public List<SelectListItem> LocationList { get; set; }
        public bool IsEditMode { get; set; }
        public bool IsSavedFlag { get; set; }
        public string ErrorMessage { get; set; }
        public List<EmployeeDetailnew> EmployeeDetailnews { get; set; }   
        public List<EducationDetailnew> EducationDetailnews { get; set; }
      //  public List<LeaveApplicationnew> LeaveApplicationnew { get; set; }
        public List<EmployeeNomineenew> EmployeeNomineenews { get; set; }
       // public List<EmployeeExpnew> EmployeeExpnew { get; set; }
        public EmployeeDetailnew EmployeeDetail { get; set; }
        public EducationDetailnew EducationDetail { get; set; }
      //  public LeaveApplicationnew LeaveApplication { get; set; }
        public EmployeeNomineenew EmployeeNominee { get; set; }
       // public EmployeeExpnew EmployeeExp { get; set; }
        public List<SelectListItem> DocList { get; set; }
        public List<SelectListItem> ResidingYNList { get; set; }
        public List <SelectListItem> DegreeList { get; set; }
        public string photpath { get; set; }
        public string sourcephoto { get; set; }

        public string wagesby { get; set; }

        public List<SelectListItem> Week_offList { get; set; }

        public string Week_off1 { get; set; }
        public string Week_off2 { get; set; }

        public string UserName { get; set; }

       

        public string Country { get; set; }

    }   
    public class EmployeeDetailnew
    {
        public string Cmpycode { get; set; }
        public string EmpCode { get; set; }
        public string DocCode { get; set; }

      



        public string DocName { get; set; }
        public string DocNo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string EndDate { get; set; }
        public string Description { get; set; }
        public string Preview { get; set; }
        public string Doc { get; set; } //image
        public string FileType { get; set; }
        public string FormType { get; set; }
        public int Sno { get; set; }
        public string IssuePlace { get; set; }
        public string DocStatus { get; set; }
        public int IssueState { get; set; }
        public HttpPostedFileBase SourceFile { get; set; }
        public string DocumentPath { get; set; }
    }
    public  class EducationDetailnew
    {
        public string Cmpycode { get; set; }
        public string code { get; set; }
        public int SNo { get; set; }
        public string Institution { get; set; }
        public string Location { get; set; }
        public string Degree { get; set; }
        public decimal ObtainedYear { get; set; }
        public string Specification { get; set; }
        public string DegreeName { get; set; }

    }

    //public class LeaveApplicationnew
    //{
    //    public string CmpyCode { get; set; }
    //    public string LANo { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    //    public DateTime Dates { get; set; }
    //    public string EmpCode { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime JoiningDate { get; set; }
    //    public string LeaveType { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime StartDate { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime EndDate { get; set; }
    //    public int LeaveDays { get; set; }
    //    public string Remarks { get; set; }
    //    public decimal TotalBalance { get; set; }
    //    public decimal TotalApplied { get; set; }
    //    public decimal TotalSanctioned { get; set; }
    //    public string ApprovalYN { get; set; }
    //    public Byte SendMail { get; set; }

    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    //    public DateTime ResumeDate { get; set; }
    //    public string Status { get; set; }
    //    public string Phone { get; set; }
    //    public string Place { get; set; }
    //    public int UseTicket { get; set; }
    //    public decimal NoofTickets { get; set; }


    //}
    public class EmployeeNomineenew
    {
        public string CmpyCode { get; set; }
        public string EmpCode { get; set; }
        public int SNo { get; set; }
        public string NomineeName { get; set; }
        public string NomineeAddress { get; set; }
        public string NomineeRelation { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string NomineeDOB { get; set; }
        
    }

    //public class EmployeeExpnew
    //{

    //    public string CmpyCode { get; set; }
    //    public string EmpCode { get; set; }
    //    public int SNo { get; set; }
    //    public string CName { get; set; }
    //    public string CAddress { get; set; }
    //    public string Designation { get; set; }
    //    public decimal CTC { get; set; }
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

    //    public DateTime FromDate { get; set; }
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    //    public DateTime ToDate { get; set; }
    //    public decimal Years { get; set; }
    //    public string ReasonForLeaving { get; set; }
    //}

}
