using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EzBusiness_ViewModels.Models.FreightManagement
{
    public class FFM_PORT_VM
    {
        public string CMPYCODE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string FFM_PORT_CODE { get; set; }
        public string NAME { get; set; }
        public string COUNTRY { get; set; }
        public string TERMINAL { get; set; }
        public string DISPLY_STATUS { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public List<FFM_portNew> FFM_portNew { get; set; }
        public FFM_portNew FFM_portDetail { get; set; }
        public List<string> Drecord { get; set; }
    }
    public class FFM_portNew
    {
        public string CMPYCODE { get; set; }
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string FFM_PORT_CODE { get; set; }
        public string NAME { get; set; }
        public string COUNTRY { get; set; }
        public string TERMINAL { get; set; }
        public string DISPLY_STATUS { get; set; }
        public string FFM_PACKING_CODE { get; set; }
    }
}

