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
    public class BankMasterVM
    {
        public string prbm001_code { get; set; }
        public string CmpyCode { get; set; }
        public string country { get; set; }
        public List<SelectListItem> CountryList { get; set; }
        public string Bank_name { get; set; }
        public string Reference { get; set; }
        public List<BankBr> Branch { get; set; }
        public BankBr BranchM { get; set; }
        public bool EditFlag { get; set; }
        public bool SaveFlag { get; set; }
        public string ErrorMessage { get; set; }

        public string UserName { get; set; }
    }
    public class BankBr
    {
        public string PRBM002_code { get; set; }
        public string PRBM001_code { get; set; }
        public string Bank_branch_name { get; set; }
    }
}
