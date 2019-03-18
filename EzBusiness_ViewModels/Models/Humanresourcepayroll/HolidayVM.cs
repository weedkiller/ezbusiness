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
  public  class HolidayVM
    {


        public string CmpyCode { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Dates { get; set; }

        public string HRPH001_UID { get; set; }

        [Display(Name = "Code")]
        public string HRPH001_CODE { get; set; }


        [Display(Name = "Leave Type Code")]
        public string LEAVE_TYPECODE { get; set; }

        public List<SelectListItem> LEAVE_TYPECODEList { get; set; }

        public string Description { get; set; }

        public string COUNTRY { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }

        //public List<SelectListItem> CountryList { get; set; }
        public List<HolidayDetailnew> HolidayDetailnew { get; set; }
        public HolidayDetailnew HolidayDetail { get; set; }

        public List<string> Drecord { get; set; }
        public string UserName { get; set; }
    }
    public class HolidayDetailnew
    {

       public string CmpyCode { get; set; }

        public DateTime? Dates { get; set; }

        public string HRPH001_CODE { get; set; }



        public string LEAVE_TYPECODE { get; set; }

        public List<SelectListItem> LEAVE_TYPECODEList { get; set; }
        public string Description { get; set; }

        public string COUNTRY { get; set; }

        
    }
}
