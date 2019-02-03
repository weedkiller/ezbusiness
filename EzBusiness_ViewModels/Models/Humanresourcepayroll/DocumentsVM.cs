using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;

namespace EzBusiness_ViewModels.Models.Humanresourcepayroll
{
    public class DocumentsVM
    {
        public string CmpyCode { get; set; }

        public string DocCode { get; set; }

        public string DocName { get; set; }


        public string UniCodeName { get; set; }


        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }


        public List<DocumentsDetailnew> DocumentsDetailnew { get; set; }
        public DocumentsDetailnew DocumentsDetail { get; set; }

        public List<string> Drecord { get; set; }

        public string UserName { get; set; }

    }
    public class DocumentsDetailnew
    {
        public string CmpyCode { get; set; }
        public string DocCode { get; set; }
        public string DocName { get; set; }
        public string UniCodeName { get; set; }

    }



}

