using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class AttendenceVM
    {  

        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string LeaveName { get; set; }


        public string CountryCode { get; set; }



        public List<SelectListItem> TypeList { get; set; }

        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public string UserName { get; set; }
    }
}
