using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class EmployeeExp
    {
        public string CmpyCode { get; set; }
        public string EmpCode { get; set; }
        public int SNo { get; set; }
        public string CName { get; set; }
        public string CAddress { get; set; }
        public string Designation { get; set; }
        public decimal CTC  { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime  ToDate { get; set; }
        public decimal Years { get; set; }
        public string ReasonForLeaving { get; set; }
    }

}
