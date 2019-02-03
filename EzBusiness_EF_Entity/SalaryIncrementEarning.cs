using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class SalaryIncrementEarning
    {
        public string Cmpycode { get; set; }
        public string Code { get; set; }
        public int Sno { get; set; }
        public string SalaryHeadCode { get; set; }
        public string SalaryHeadName  { get; set; }
        public string SalaryType  { get; set; }
        public decimal intAmount  { get; set; }
        public decimal? Perc { get; set; }
        public decimal Amount { get; set; }
        public string PayDeductIn { get; set; }
        public int PF { get; set; }
        public int ESIC { get; set; }
        public int VaryingAmt { get; set; }
        public int Bonus { get; set; }
        public int OT { get; set; }
        public int ProfTax { get; set; }
        public int Welfare { get; set; }
        public int AutoYN { get; set; }
        public int LockYN { get; set; }
    }
}
