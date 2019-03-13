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
   public class PyrollConfi_Vm
    {
        public string PRCNF001_CODE { get; set; }
        public string CMPYCODE { get; set; }
        public string COUNTRY { get; set; }
        public int SRNO { get; set; }
        public int FINYEAR { get; set; }
        public int FINMONTH { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FROM_DATE { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TO_DATE { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? D_DATE { get; set; }

        public string LOCK { get; set; }

        public int NOOFDAYS { get; set; }

        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public string UserName { get; set; }

        public string Nationality { get; set; }
        public List<SelectListItem> NationalityList { get; set; }
    }
}
