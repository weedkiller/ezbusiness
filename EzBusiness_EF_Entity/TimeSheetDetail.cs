using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class TimeSheetDetail
    {
       


        public string PRDTD001_CODE { get; set; }
        public string COUNTRY { get; set; }
        public string Cmpycode { get; set; }
        public string DIVISION { get; set; }
        public string DeptCode { get; set; }
        public DateTime Att_Date { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }


        public int Tyear { get; set; }
        public int Tmonth { get; set; }
        public string ATT { get; set; }
        public string ATT_Actual { get; set; }
        public string TradeCode { get; set; }
        public string Project_code { get; set; }
        public string Cost_center { get; set; }
        public decimal TotalHrs { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public decimal NHrs { get; set; }
        public decimal OTHrs { get; set; }
        public decimal HOTHrs { get; set; }
        public decimal FOTHrs { get; set; }
        public string Remarks { get; set; }
        public string Paid { get; set; }
        public decimal ExtraHrs { get; set; }
        public string WAGESBY { get; set; }

        public string ReportingEmp { get; set; }
       
        //Report for Project Details
        public Int32 Srno { get; set; }
        public string ProjectDuration { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime Adate { get; set; }
        public List<DayStatus> Attendanclist { get; set; }
        public string FDate { get; set; }
        public string TDate { get; set; }

        //public int Tyear { get; set; }
        //public int Tmonth { get; set; }
        //public int SrNo { get; set; }
        //public DateTime? Dates { get; set; }
        //public string Attendance { get; set; }
        //public decimal? Nhrs { get; set; }
        //public decimal? Ohrs { get; set; }
        //public decimal? FOThrs { get; set; }
        //public decimal? Hhrs { get; set; }
        //public decimal? ExtraHrs { get; set; }
    }
    public partial class OTExtraDetail
    {

        public string EmpCode { get; set; }
        public DateTime? Att_Date { get; set; }

        public decimal NHrs { get; set; }
        public decimal OTHrs { get; set; }
        public decimal HOTHrs { get; set; }
        public decimal FOTHrs { get; set; }
        public decimal ExtraHrs { get; set; }
    }
    public partial class OTExtraATT
    {
        public DateTime? Att_Date { get; set; }
        public string ATT { get; set; }
        public string EmpCode { get; set; }

    }
    public class DayStatus
    {
        public string Day { get; set; }
        public string AttenStatus { get; set; }
        public string Daydata { get; set; }
    }

}
