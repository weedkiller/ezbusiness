using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
    public partial class Department
    {
        public string Cmpycode { get; set; }
        public string DepartmentCode { get; set; }
        public string DivisionCode { get; set; }
        public string BranchCode { get; set; }

        public string DepartmentName { get; set; }
        public string UniCodeName { get; set; }
    }
}
