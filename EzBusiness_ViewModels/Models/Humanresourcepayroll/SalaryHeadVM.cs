using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class SalaryHeadVM
    {
        public string CmpyCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        //public string Description { get; set; }

        //public string AmtType { get; set; }


        //public string PayDeductOn { get; set; }


        //public string SNo { get; set; }



     //   public List<SelectListItem> PayDeductOnList { get; set; }

        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public string UserName { get; set; }
    }
}
