using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EzBusiness_EF_Entity
{
    public partial class Employee
    {
        public string Cmpycode { get; set; }
        public string EmpCode { get; set; }
        public string Empname { get; set; }
        public string EmpType { get; set; }
        public string DivisionCode { get; set; }
        public string ProfCode { get; set; }
        public string JoiningDate { get; set; }
        public string Sex { get; set; }
       
        public string Address { get; set; }
        public Nullable<System.DateTime> FirstSetDate { get; set; }
       
        public string LeaveStatus { get; set; }
        public string WorkingStatus { get; set; }
        public Nullable<System.DateTime> LastRetDate { get; set; }
      
      
      
       
        public string VisaLocation { get; set; }
        public string Nationality { get; set; }
      
        public Nullable<System.DateTime> DOB { get; set; }
      
        public string VisaStatus { get; set; }
        public string WorkLocation { get; set; }
        public string AddressLocal { get; set; }
       
        public string DepartmentCode { get; set; }
        public string ProjectCode { get; set; }
        public string BankCode { get; set; }
        public string BankAccNo { get; set; }
        public string AccNo { get; set; }
       
        public decimal DiscountP { get; set; }
       
       
        public string ReportingEmp { get; set; }
        public string MaritalStatus { get; set; }
        public string BloodGroup { get; set; }
        public string PhysicallyDisabledYN { get; set; }
        public string PhysicallyDisabled { get; set; }
       
        public string Salutaion { get; set; }
        
       
        public string ContactNo { get; set; }
        public string EMail { get; set; }
        public string BranchCode { get; set; }

        public string BankBranchCode { get; set; }
        
       
        
        public Nullable<System.DateTime> ContactDate { get; set; }
        public string AbscondingYN { get; set; }
        public Nullable<System.DateTime> AbscondingDate { get; set; }
       
        public string TicketType { get; set; }
        public string TicketNo { get; set; }
        public string Contract { get; set; }
        public string SupervisorYN { get; set; }
        public string LanguageKnown { get; set; }
        public Nullable<System.DateTime> LeaveSettlementDate { get; set; }
       
       
        public string GroupCode { get; set; }

       
        public string LocCode { get; set; }
        public string photpath { get; set; }

        public decimal? BalLeave { get; set; }


        public string wagesby { get; set; }

        public string Week_off1 { get; set; }
        public string Week_off2 { get; set; }

        public string SrNo { get; set; }

        public DateTime Fdate { get; set; }
        public DateTime Tdate { get; set; }

    }
}
