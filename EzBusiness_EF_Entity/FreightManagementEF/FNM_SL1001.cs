using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF
{
  public partial  class FNM_SL1001
    {

        public string CMPYCODE { get; set; }
        public string DIVISION { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string FNM_SL1001_CODE { get; set; }
        public string Name { get; set; }
        public string Print_Name { get; set; }
        public string Web_site { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Address { get; set; }
        public string Contact1 { get; set; }
        public string Contact2 { get; set; }
        public string Contact3 { get; set; }
        public string Currency_code { get; set; }
        public Decimal credit_limit { get; set; }
        public string SUBLEDGER_TYPE { get; set; }

        public string Name_Arabic { get; set; }
    }
}
