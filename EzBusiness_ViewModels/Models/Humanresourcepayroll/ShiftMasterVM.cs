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
    public class ShiftMasterVM
    {
        public string PRSFT001_code { get; set; }
        public string country { get; set; }
        public string division { get; set; }
        public string CmpyCode { get; set; }
        public string ShiftName { get; set; }
        public string StTime { get; set; }
        public string EdTime { get; set; }
        public string ErrorMessage { get; set; }
        public bool EditFlag { get; set; }
        public bool SaveFlag { get; set; }

        public List<SelectListItem> CountryList { get; set; }
        //public List<SelectListItem> EmpCodeList { get; set; }
        public List<ShiftAllocationH> Shift { get; set; }
        public ShiftAllocationH ShiftM { get; set; }

        public string UserName { get; set; }
    }
    public class ShiftAllocationH
    {
        [Required(ErrorMessage = "Title is required.")]
        public string PRSFT002_code { get; set; }
        public string PRSFT001_code { get; set; }
        public string division { get; set; }
        public string CmpyCode { get; set; }
        public string ApprovalYN { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Enttry_Date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Effect_Date { get; set; }

    }
}



