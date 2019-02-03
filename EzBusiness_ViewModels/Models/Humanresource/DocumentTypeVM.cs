using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;

namespace EzBusiness_ViewModels.Models.Humanresource
{
    public class DocumentTypeVM
    {
        public string CmpyCode { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }


        public string UnicodeName { get; set; }


        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }

        public string UserName { get; set; }
    }
}
