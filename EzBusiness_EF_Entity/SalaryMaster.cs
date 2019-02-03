using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial   class SalaryMaster
    {
      public string CmpyCode { get; set; }
        public string SmNo { get; set; }
        public string EmpCode { get; set; }
        public DateTime Dates { get; set; }
        public decimal Basic { get; set; }
        public decimal Housing { get; set; }
        public decimal Food { get; set; }
        public decimal Conveyance { get; set; }
        public decimal Others { get; set; }
        public decimal Total { get; set; }
        public decimal Others1 { get; set; }
        public DateTime EffectiveDate { get; set; }
        public decimal TDSPerc { get; set; }
    }
}
