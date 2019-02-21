using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EzBusiness_ViewModels.Models.MaterialMgmt
{
    public class UnitVM
    {

        public string CmpyCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }


        public string SrCode { get; set; }
        [Display(Name = "Uni Code Name")]
        public string UniCodeName { get; set; }
        [Display(Name = "Unit Type")]
        public string UnitType { get; set; }

        public List<SelectListItem> UnitTypeList { get; set; }
        public UnitNew UnitDetail { get; set; }
        public List<UnitNew> UnitNew { get; set;}
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }
        public List<string> Drecord { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class UnitNew
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string UniCodeName { get; set; }
        public string Name { get; set; }
        public string UnitType { get; set; }

    }
}
