using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity
{
   public partial class ShiftAlloc
    {
       
        public string PRSFT002_code { get; set; }
        [Required]
        public string PRSFT001_code { get; set; }
        public string division { get; set; }
        public string CmpyCode { get; set; }
        public string ApprovalYN { get; set; }

        public DateTime Enttry_Date { get; set; }
        
        public DateTime Effect_Date { get; set; }
    }
}
