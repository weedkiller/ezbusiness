using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagement;
using System.ComponentModel;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
   public class FNMCAT_VM
    {
        public string CMPYCODE { get; set; }

        [DisplayName("CODE")]
        public string FNMCAT_CODE { get; set; }
        public string DESCRIPTION { get; set; }
        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public List<FNMCATDetailnew> FNMCATDetailnew { get; set; }
        public FNMCATDetailnew FNMCATDetail { get; set; }

        public List<string> Drecord { get; set; }


        public string UserName { get; set; }
    }

    public class FNMCATDetailnew
    {
        public string CMPYCODE { get; set; }
        public string FNMCAT_CODE { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
