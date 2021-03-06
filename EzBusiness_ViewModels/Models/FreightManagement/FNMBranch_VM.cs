﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
   public class FNMBranch_VM
    {
        [DisplayName("CODE")]
        public string FNMBRANCH_CODE { get; set; }
        public string CMPYCODE { get; set; }
        public string DESCRIPTION { get; set; }
        public int SNO { get; set; }
        public string PRINTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string WEBSITE { get; set; }
        public string MOBILE { get; set; }
        public string CURRENCY { get; set; }
        public string COUNTRY { get; set; }
        public string STATE { get; set; }

        public string DIVISION { get; set; }
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public List<FNMBranchDetailsNew> FNMBranchDetailsnew { get; set; }
        public FNMBranchDetailsNew FNMBranchDetail { get; set; }

        //public List<string> Drecord { get; set; }

        public List<SelectListItem> CountryList { get; set; }
        public List<SelectListItem> CurrencyList { get; set; }
        public string UserName { get; set; }
    }
    public class FNMBranchDetailsNew
    {
        public int FNMBRANCH_UID { get; set; }
        public string FNMBRANCH_CODE { get; set; }
        public string CMPYCODE { get; set; }
        public string DESCRIPTION { get; set; }
        public int SNO { get; set; }
        public string PRINTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string EMAIL { get; set; }
        public string WEBSITE { get; set; }
        public string MOBILE { get; set; }
        public string CURRENCY { get; set; }
        public string COUNTRY { get; set; }
        public string STATE { get; set; }

        public string DIVISION { get; set; }

    }
}
