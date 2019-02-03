using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class VisaLocationVM
    {
        public string CmpyCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }


        public string UniCodeName { get; set; }


        public string CompanyMolID { get; set; }


        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public List<VisaLocNew> VisaLocNew { get; set; }
        public VisaLocNew VisaDetail { get; set; }

        public List<string> Drecord { get; set; }

        public string UserName { get; set; }
    }
    public class VisaLocNew
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string UniCodeName { get; set; }
        public string CompanyMolID { get; set; }

    }
}
