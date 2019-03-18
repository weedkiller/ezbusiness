using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.ComponentModel.DataAnnotations;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class GroupVM
    {
        public string CmpyCode { get; set; }
        [Display(Name = "Code")]
        public string DivisionCode { get; set; }
        [Display(Name = "Name")]
        public string DivisionName { get; set; }


        public string UniCodeName { get; set; }


        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public List<GroupDetailnew> GroupDetailnew { get; set; }
        public GroupDetailnew GroupDetail { get; set; }

        public List<string> Drecord { get; set; }


        public string UserName { get; set; }
    }

    public class GroupDetailnew
    {
        public string CmpyCode { get; set; }
        public string DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public string UniCodeName { get; set; }

    }

}
