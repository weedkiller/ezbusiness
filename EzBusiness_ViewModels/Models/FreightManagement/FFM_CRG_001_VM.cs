using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
    public class FFM_CRG_001_VM
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }

        [DisplayName("CODE")]
        public string FFM_CRG_001_CODE { get; set; }
        public string NAME { get; set; }
        public string FFM_CRG_GROUP_CODE { get; set; }
        public string DISPLAY_STATUS { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public List<FFM_CRG_001New> FFM_CRG_001New { get; set; }
        public FFM_CRG_001New FFM_CRG_001Detail { get; set; }
        public List<string> Drecord { get; set; }
    }
    public class FFM_CRG_001New
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
        
        public string FFM_CRG_001_CODE { get; set; }
        public string NAME { get; set; }
        public string FFM_CRG_GROUP_CODE { get; set; }
        public string DISPLAY_STATUS { get; set; }
    }
}

