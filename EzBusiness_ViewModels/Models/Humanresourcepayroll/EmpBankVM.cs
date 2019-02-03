using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
   public class EmpBankVM
    {
        public bool EditFlag { get; set; }
        public bool SaveFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string CmpyCode { get; set; }

        public string EmpCode { get; set; }
        public List<SelectListItem> EmpCodeList { get; set; }
        public string PRBM001_code { get; set; }
        public List<SelectListItem> PRBM001_codeList { get; set; }
        public string PRBM003_CODE { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Entry_Date { get; set; }

        public string PRBM002_code { get; set; }
        public List<SelectListItem> PRBM002_codeList { get; set; }
        public string Account_no { get; set; }
        public string EBAN_no { get; set; }
        public string Remarks { get; set; }

        public string UserName { get; set; }
    }
   
}
