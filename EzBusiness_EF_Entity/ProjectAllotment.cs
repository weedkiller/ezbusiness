using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class ProjectAllotment
    {      
       
        public string PRPRJE001_code { get; set; }

        public string CCH004_code { get; set; }

        public DateTime Entery_date { get; set; }

        public DateTime Effect_From { get; set; }

        public string EmpCode { get; set; }

        public string Remarks { get; set; }

        public string CmpyCode { get; set; }


    }
}
