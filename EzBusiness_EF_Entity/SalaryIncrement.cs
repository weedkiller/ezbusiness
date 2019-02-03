using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class SalaryIncrement
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public DateTime Dates { get; set; }
        public DateTime EffDates { get; set; }

        public string EmpCode { get; set; }
        public string EmpGrade { get; set; }

        public decimal ContractAmountYearly { get; set; }

        public decimal ContractAmount { get; set; }

        public decimal Total { get; set; }

    }
}
