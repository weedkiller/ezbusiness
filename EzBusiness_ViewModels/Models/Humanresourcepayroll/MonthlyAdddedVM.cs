using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EzBusiness_EF_Entity;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
   public class MonthlyAdddedVM
    {
        public string PRADN001_CODE { get; set; }
        public string COUNTRY { get; set; }
        public string CmpyCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Entry_Date { get; set; }
        public int TYear { get; set; }
        public int TMonth { get; set; }

        public List<MonthlyAdddeddet1> MonthlyAddded { get; set; }
        public MonthlyAdddeddet1 MonthlyAdddedM { get; set; }
        public bool EditFlag { get; set; }
        public bool SaveFlag { get; set; }
        public string ErrorMessage { get; set; }

        public List<SelectListItem> EmpNameList { get; set; }

        public string UserName { get; set; }

    }
    public class MonthlyAdddeddet1
    {
        //public string PRADN001_CODE { get; set; }
        //public string CmpyCode { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
       
        public decimal ADN_Amount { get; set; }
        public string ADN_Act_code { get; set; }
        public string T_type { get; set; }
        public string Remarks { get; set; }

    }
}
