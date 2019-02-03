using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class PaymentTerms
    {
        public string Cmpycode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        
        public decimal NoOfDays { get; set; }
    }
}
