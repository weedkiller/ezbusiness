using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class OTVM
    {
        public string Cmpycode { get; set; }
        public string EmpCode { get; set; }

        public string UserName { get; set; }

        public string Code { get; set; }
        public List<SelectListItem> EmpCodeList { get; set; }


        public string DivCode { get; set; }
        public List<SelectListItem> DivCodeList { get; set; }


        public string PrjCode { get; set; }
        public List<SelectListItem> PrjCodeList { get; set; }

        public int Tyear { get; set; }
        public int Tmonth { get; set; }
        public int SrNo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Att_Date { get; set; }

        public string Attendance { get; set; }
        public decimal? Nhrs { get; set; }
        public decimal? Ohrs { get; set; }
        public decimal? FOThrs { get; set; }
        public decimal? Hhrs { get; set; }
        public decimal? ExtraHrs { get; set; }

        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public List<OTExtraDetailnew> OTExtraDetailnews { get; set; }
        public OTExtraDetailnew OTExtraDetail { get; set; }


        public List<OTExtraATTnews> OTExtraATTnews { get; set; }
        public OTExtraATTnews OTExtraATT { get; set; }

        //public List<EmployeeDetailnew> EmployeeDetailnews { get; set; }
        //public EmployeeDetailnew EmployeeDetail { get; set; }
    }

    public class OTExtraDetailnew
    {
        public DateTime? Att_Date { get; set; }

        public decimal? Nhrs { get; set; }
        public decimal? Ohrs { get; set; }
        public decimal? FOThrs { get; set; }
        public decimal? Hhrs { get; set; }
        public decimal? ExtraHrs { get; set; }
        public string EmpCode { get; set; }
    }

    public class OTExtraATTnews
    {
        public DateTime? Att_Date { get; set; }
        public string ATT { get; set; }
        public string EmpCode { get; set; }

    }
}
