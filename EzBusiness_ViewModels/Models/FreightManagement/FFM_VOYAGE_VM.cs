using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
   public class FFM_VOYAGE_VM
    {        
        public string FFM_VOYAGE01_CODE { get; set; }
        public  Int32 SNO { get; set;}
        public Int32 ROTATION {get; set;}
        public string PORT { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ETB { get; set; }
        public DateTime ETD { get; set; }
        public string DISPLAY_STATUS { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string FFM_VESSEL_CODE { get; set; }
        public string CMPYCODE { get; set; }
   
     //   public string FFM_VOYAGE01_CODE { get; set; }
        public string NAME { get; set; }
        //  public string DISPLAY_STATUS { get; set; }

        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }

        public string UserName { get; set; }
    }
}
