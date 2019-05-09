using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
   public class FNMTYPE_VM
    {

        public string CMPYCODE { get; set; }

        [DisplayName("CODE")]
        public string FNMTYPE_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public List<FNMTYPEDetailnew> FNMTYPEDetailnew { get; set; }
        public FNMTYPEDetailnew FNMTYPEDetail { get; set; }

        public List<string> Drecord { get; set; }


        public string UserName { get; set; }
    }

    public class FNMTYPEDetailnew
    {
        public string CMPYCODE { get; set; }
        public string FNMTYPE_CODE { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
