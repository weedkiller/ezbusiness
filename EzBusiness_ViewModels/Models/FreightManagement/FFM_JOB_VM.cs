using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
    public class FFM_JOB_VM
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }      
        public string FFM_JOB_CODE { get; set; }
        public string NAME { get; set; }

        public string DISPLAY_STATUS { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public List<FFM_JOBNew> FFM_JOBNew { get; set; }
        public FFM_JOBNew FFM_JOBDetail { get; set; }
        public List<string> Drecord { get; set; }
    }
    public class FFM_JOBNew
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }       
        public string FFM_JOB_CODE { get; set; }
        public string NAME { get; set; }
      //  public string DISPLAY_STATUS { get; set; }
        
    }
}



