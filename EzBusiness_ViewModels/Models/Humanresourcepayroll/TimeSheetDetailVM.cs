using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class TimeSheetDetailVM
    {
        public bool EditFlag { get; set; }

        public bool SaveFlag { get; set; }

        public string ErrorMessage { get; set; }

        public string Cmpycode { get; set; }

        [DisplayName("Employee Code")]
        public string EmpCode { get; set; }

        [DisplayName("Employee Name")]
        public string EmpName { get; set; }

        public List<SelectListItem> EmpCodeList { get; set; }


        public string DivCode { get; set; }

        public List<SelectListItem> DivCodeList { get; set; }

        public string PrjCode { get; set; }

        public List<SelectListItem> PrjCodeList { get; set; }


      


        public int Tyear { get; set; }
        public int Tmonth { get; set; }
        public int SrNo { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:MMM-yyyy}", ApplyFormatInEditMode = true)]
       // [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Dates { get; set; }

        public string Attendance { get; set; }
        public decimal? Nhrs { get; set; }
        public decimal? Ohrs { get; set; }
        public decimal? FOThrs { get; set; }
        public decimal? Hhrs { get; set; }
        public decimal? ExtraHrs { get; set; }

        public string UserName { get; set; }


        [DisplayName("Reporting Employee")]
        public string ReportingEmp { get; set; }
        public string Project_code { get; set; }

    }
   
}
