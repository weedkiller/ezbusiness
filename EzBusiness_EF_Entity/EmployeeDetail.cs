using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class EmployeeDetail
    {
       public string Cmpycode { get; set; }
        public string EmpCode { get; set; }
        public string DocCode { get; set; }
        public string DocName { get; set; }
        public string DocNo { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Description { get; set; }
        public string Preview { get; set; }
       public string DocumentPath { get; set; }
        public int Sno { get; set;  }
        public string IssuePlace { get; set; }
        public string DocStatus { get; set; }
       
    }
}
