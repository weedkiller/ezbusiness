using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class NationRegionVM
    {
        public string CmpyCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }


        public string UniCodeName { get; set; }


        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }
        public List<NationNew> NationNew { get; set; }
        public NationNew NRDetail { get; set; }

        public List<string> Drecord { get; set; }

        public string UserName { get; set; }
    }
    public class NationNew
    {
        public string CmpyCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string UniCodeName { get; set; }

    }
}
