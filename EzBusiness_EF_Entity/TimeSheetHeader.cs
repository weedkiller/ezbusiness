using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class TimeSheetHeader
    {
        //public string Cmpycode { get; set; }
        //public string EmpCode { get; set; }
        //public int Tyear { get; set; }
        //public int Tmonth { get; set; }

        public string PRDTD001_CODE { get; set; }
        public string COUNTRY { get; set; }
        public string Cmpycode { get; set; }
        public string DIVISION { get; set; }
        public string DeptCode { get; set; }
        public DateTime Entry_Date { get; set; }
        public string EmpCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Createdno { get; set; }
        public string updatedBy { get; set; }     
        public DateTime updatedOn { get; set; }
        public string wagesby { get; set; }

    }


}
