using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class EmployeeNominee
    {
        public string CmpyCode { get; set; }
        public string EmpCode { get; set; }
        public int SNo { get; set; }
        public string  NomineeName { get; set; }
        public string NomineeAddress { get; set; }
        public string  NomineeRelation { get; set; }
        public string NomineeDOB { get; set; }
       
    }
}
