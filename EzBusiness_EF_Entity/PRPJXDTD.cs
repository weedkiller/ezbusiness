using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public partial class PRPJXDTD
    {
        public int PRPJXDTD001_UID { get; set; }
        public string cmpycode { get; set; }
        public string country { get; set; }
        public string empcode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Dates { get; set; }
        public string Project_code { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public decimal NHrs { get; set; }
        public decimal OTHrs { get; set; }
        public decimal HOTHrs { get; set; }
        public decimal FOTHrs { get; set; }
        public decimal ExtraHrs { get; set; }
        public decimal TotalHrs { get; set; }
        public string Cost_center { get; set; }

    }
}
