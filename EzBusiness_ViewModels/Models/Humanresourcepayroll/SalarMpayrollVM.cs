using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class SalarMpayrollVM
    {
        public bool EditFlag { get; set; }

        public bool SaveFlag { get; set; }

        public string ErrorMessage { get; set; }
        public int PRSM001UID { get; set; }
        public string PRSM001_CODE { get; set; }
        public string CMPYCODE { get; set; }
        public string DIVISION { get; set; }
        public string COUNTRY { get; set; }
        public string EMPCODE { get; set; }
        public List<SelectListItem> EmpCodeList { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Entery_date { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Effect_From { get; set; }
        public decimal? BASIC { get; set; }
        public string BASICCAPTION { get; set; }
        public string BASICACT { get; set; }
        public decimal? HRA { get; set; }
        public string HRACAPTION { get; set; }
        public string HRAACT { get; set; }
        public decimal? DA { get; set; }
        public string DACAPTION { get; set; }
        public string DAACT { get; set; }
        public decimal? TELE { get; set; }
        public string TELECAPTION { get; set; }
        public string TELEACT { get; set; }
        public decimal? TRANS { get; set; }
        public string TRANSCAPTION { get; set; }
        public string TRANSACT { get; set; }
        public decimal? CAR { get; set; }
        public string CARCAPTION { get; set; }
        public string CARACT { get; set; }
        public decimal? ALLOWANCE1 { get; set; }
        public string ALLOWANCE1CAPTION { get; set; }
        public string ALLOWANCE1ACT { get; set; }
        public decimal? ALLOWANCE2 { get; set; }
        public string ALLOWANCE2CAPTION { get; set; }
        public string ALLOWANCE2ACT { get; set; }
        public decimal? ALLOWANCE3 { get; set; }
        public string ALLOWANCE3CAPTION { get; set; }
        public string ALLOWANCE3ACT { get; set; }
        public decimal? TOTAL { get; set; }
       
        public List<SalaryGrid> SalaryMas { get; set; }
        public SalaryGrid SMEarning { get; set; }

        public string UserName { get; set; }

    }
    public class SalaryGrid
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Accountcode { get; set; }
        public decimal? AMOUNT { get; set; }
        public decimal? TOTAL { get; set; }

    }

}
