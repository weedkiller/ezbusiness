using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class EmpShiftVM
    {
        public string CmpyCode { get; set; }
        public string PRSFT002_code { get; set; }
        public string PRSFT003_code { get; set; }
        public string PRSFT001_code { get; set; }
        public string EmpCode { get; set; }
        public string Remarks { get; set; }
        public int SNO { get; set; }
        public string ErrorMessage { get; set; }
        public bool EditFlag { get; set; }
        public bool SaveFlag { get; set; }
        public List<SelectListItem> EmpCodeList { get; set; }

     

        public List<SelectListItem> ShiftCode { get; set; }
        public List<SelectListItem> ShiftCodeAlloc { get; set; }

        public string UserName { get; set; }

        public string Empname { get; set; }
        public string ShiftName { get; set; }

    }
}
