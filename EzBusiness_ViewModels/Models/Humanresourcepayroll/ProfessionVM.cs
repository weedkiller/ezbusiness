using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.ComponentModel.DataAnnotations;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class ProfessionVM
    {
        public string CmpyCode { get; set; }

        [Display(Name = "Code")]
        public string ProfCode { get; set; }
        [Display(Name = "Name")]
        public string ProfName { get; set; }

        public string UniCodeName { get; set; }

        public string ProfType { get; set; }

        
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }



        public List<ProfessionDetailnew> ProfessionDetailnew { get; set; }
        public ProfessionDetailnew ProfessionDetail { get; set; }

        public List<string> Drecord { get; set; }

        public string UserName { get; set; }

    }

    public class ProfessionDetailnew
    {
        public string CmpyCode { get; set; }
        public string ProfCode { get; set; }
        public string ProfName { get; set; }
        public string UniCodeName { get; set; }

    }
}
