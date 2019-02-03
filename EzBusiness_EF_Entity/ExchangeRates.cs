using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class ExchangeRates
    {

        public string CmpyCode { get; set; }
        public string CurCode { get; set; }
        public string CurName { get; set; }

        public decimal CurRate { get; set; }
    }
}
