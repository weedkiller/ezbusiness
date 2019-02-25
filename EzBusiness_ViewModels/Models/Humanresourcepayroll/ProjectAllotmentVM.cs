using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class ProjectAllotmentVM
    {
        public string PRPRJE001_code { get; set; }

        public string CCH004_code { get; set; }

        public DateTime Entery_date { get; set; }

        public DateTime Effect_From { get; set; }

        public string EmpCode { get; set; }

        public string Remarks { get; set; }

        public string CmpyCode { get; set; }

        public string ErrorMessage { get; set; }
        public bool EditFlag { get; set; }
        public bool SaveFlag { get; set; }
        public List<SelectListItem> EmpCodeList { get; set; }
        public List<SelectListItem> CCH004_codeList { get; set; }
       
        public string UserName { get; set; }
    }
}
