using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public partial class Salesman
    {
        public string Cmpycode { get; set; }
        public string SalesmanCode { get; set; }
        public string  Name { get; set; }
        public string PhoneNo { get; set; }
        public decimal DiscountP { get; set; }
        public decimal CommissionP { get; set; }


    }
}
