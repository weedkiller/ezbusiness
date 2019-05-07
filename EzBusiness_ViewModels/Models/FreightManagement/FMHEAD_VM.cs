using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagement;


namespace EzBusiness_ViewModels.Models.FreightManagement
{   
   public  class FMHEAD_VM
    {
        public string CMPYCODE { get; set; }
        public string FNMHEAD_CODE { get; set; }
        public string DESCRIPTION { get; set; }

        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public List<FMHEADDetailnew> FMHEADDetailnew { get; set; }
        public FMHEADDetailnew FMHEADDetail { get; set; }

        public List<string> Drecord { get; set; }


        public string UserName { get; set; }
    }

    public class FMHEADDetailnew
    {
        public string CMPYCODE { get; set; }
        public string FNMHEAD_CODE { get; set; }
        public string DESCRIPTION { get; set; }
    }
    }
