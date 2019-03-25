using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
   public class SalaryProcessDetailsVM
    {
        public string Country { get; set; }
        
        public string PRSP001_Code { get; set; }
        public string Division { get; set; }
        public string CmpyCode { get; set; }
        public string Deptcode { get; set; }
        public string VisaLocation { get; set; }
        public Int32 year { get; set; }
        public Int32 Month { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public bool SaveFlag { get; set; }
        public string GroupItems { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Process_Date { get; set; }
        public List<SelectListItem>  GroupList { get; set; }
        public List<SalaryProcessDetailsListItem> salaryList { get; set; }
        public SalaryProcessDetailsListItem salaryListItems { get; set; }
       // public string DivisionCode { get; set; }
       // public List<SelectListItem> DivisionList { get; set; }
        public List<string> Drecord { get; set; }
        public DateTime created_on { get; set; }
        public DateTime Updated_on { get; set; }
        public string UserName { get; set; }
    }

   public class SalaryProcessDetailsListItem
    {
        public string ErrorMsg { get; set; }
        public string cmpycode { get; set; }
        public string country { get; set; }
        public string Division { get; set; }
        public int Tyear { get; set; }
        public int Tmonth { get; set; }
        public string Empcode { get; set; }
        public string Empname { get; set; }
        public string ProfCode { get; set; }
        public string DepCode { get; set; }
        public string ComnPrjcode { get; set; }
        public string VisaLocation { get; set; }
        public string WorkLocation { get; set; }
        public Int32 Total_Days { get; set; }
        public decimal Worked_Days { get; set; }
        public decimal a_basic { get; set; }
        public decimal a_hra { get; set; }
        public decimal a_Da { get; set; }
        public decimal a_tele { get; set; }
        public decimal a_trans { get; set; }
        public decimal a_car { get; set; }
        public decimal a_allowance1 { get; set; }
        public decimal a_allowance2 { get; set; }
        public decimal a_allowance3 { get; set; }
        public decimal a_Totalsalary { get; set; }
        public decimal C_basic { get; set; }
        public decimal C_hra { get; set; }
        public decimal C_da { get; set; }
        public decimal C_tele { get; set; }
        public decimal C_trans { get; set; }
        public decimal C_car { get; set; }
        public decimal C_allowance1 { get; set; }
        public decimal C_allowance2 { get; set; }
        public decimal C_allowance3 { get; set; }
        public decimal C_totalSalary { get; set; }
        public decimal loan_amt { get; set; }
        public decimal adn_amount { get; set; }
        public decimal nothrs { get; set; }
        public decimal extraOThrs { get; set; }
        public decimal hothrs { get; set; }
        public decimal wothrs { get; set; }
        public decimal not_rate_perhr { get; set; }
        public decimal ExtraOT_rate_perhr { get; set; }
        public decimal hot_rate_perhr { get; set; }
        public decimal wot_rate_perhr { get; set; }
        public decimal ExtraOTAmt { get; set; }
        public decimal NOTAmt { get; set; }
        public decimal HOTAmt { get; set; }
        public decimal WOTAmt { get; set; }
        public decimal NetSalary { get; set; }

        public Int32 srno { get; set; }
        public bool flag { get; set; }



    }

    public class SalaryProcessAccountsList
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string HeadCode { get; set; }
        public string HeadName { get; set; }
        public string AccNo { get; set; }
        public string Description { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string ProjectCode { get; set; }
        public string CostCode { get; set; }
        public int BOQSno { get; set; }
        public int PackageSno { get; set; }
    }

}
