using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class Location
    {
        public string Cmpycode { get; set; }
        public string LocCode { get; set; }
        public string LocName { get; set; }
        public string SrCode { get; set; }
        public decimal WorkCenter { get; set; }
        public string LocType { get; set; }
        public string LocAddress { get; set; }
        public string ContactNo { get; set; }
        public string IsLocation { get; set; }
        public string IsShowroom { get; set; }
        public string IsStore { get; set; }
        public string IsWorkCenter { get; set; }
        public int Levels { get; set; }
        public string SubOf { get; set; }
        public int SNo { get; set; }
        public int LeadDays { get; set; }
        public string Prefix { get; set; }
    }
}
