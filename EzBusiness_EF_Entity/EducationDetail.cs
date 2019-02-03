using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class EducationDetail
    {
        public string Cmpycode {get;set;}
        public string code { get; set; }
        public int  SNo  {get;set;}
        public string Institution { get; set; }
        public string Location { get; set; }
        public string Degree { get; set; }
        public decimal ObtainedYear { get; set; }
        public string  Specification { get; set; }
        public string DegreeName { get; set; }
    }
}
