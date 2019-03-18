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
    public class DepartmentVM
    {
        public string CmpyCode { get; set; }

        [Display(Name = "Code")]
        public string DepartmentCode { get; set; }
        [Display(Name = "Division Code")]
        public string DivisionCode { get; set; }
        public List<SelectListItem> DivisionCodeList { get; set; }
        [Display(Name = "Branch Code")]
        public string BranchCode { get; set; }
        public List<SelectListItem> BranchCodeList { get; set; }
        [Display(Name = "Name")]
        public string DepartmentName { get; set; }
        public string UniCodeName { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public List<DepartmentDetailnew> DepartmentDetailnew { get; set; }
        public DepartmentDetailnew DepartmentDetail { get; set; }
        public List<string> Drecord { get; set; }
        public string UserName { get; set; }

    }


    public class DepartmentDetailnew
    {
        public string CmpyCode { get; set; }
        public string DepartmentCode { get; set; }
        public string DivisionCode { get; set; }
        public string BranchCode { get; set; }
        public string DepartmentName { get; set; }
        public string UniCodeName { get; set; }

    }

}
