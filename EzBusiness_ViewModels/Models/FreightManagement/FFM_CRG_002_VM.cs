using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
    public class FFM_CRG_002_VM
    {
        
        public string FFM_CRG_001_CODE { get; set; }

        public string CMPYCODE { get; set; }
        public string NAME { get; set; }
        public string FFM_CRG_JOB_CODE { get; set; }
        public string DISPLAY_STATUS { get; set; }
        public string INCOME_ACT { get; set; }
        public string EXPENSE_ACGT { get; set; }

        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public List<FFM_CRG_002New> FFM_CRG_002New { get; set; }
        public FFM_CRG_002New FFM_CRG_002Detail { get; set; }
        public List<string> Drecord { get; set; }
    }
    public class FFM_CRG_002New
    {      
        public string FFM_CRG_001_CODE { get; set; }

        public string CMPYCODE { get; set; }
        public string NAME { get; set; }
        public string FFM_CRG_JOB_CODE { get; set; }
        public string DISPLAY_STATUS { get; set; }
        public string INCOME_ACT { get; set; }
        public string EXPENSE_ACGT { get; set; }
    }
}

