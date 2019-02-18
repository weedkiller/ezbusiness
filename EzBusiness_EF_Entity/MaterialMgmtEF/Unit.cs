using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace EzBusiness_EF_Entity
{
    public partial class Unit
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        [Display(Name = "Site Request Code")]
        public string SrCode { get; set; }

        [Display(Name = "Uni Code Name")]
        public string UniCodeName { get; set; }

        [Display(Name = "Unit Type")]
        public string UnitType { get; set; }
    }

}
