﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
    public class FFM_SRVC_VM
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
        [DisplayName("CODE")]
        public string FFM_SRVC_CODE { get; set; }
        public string NAME { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public List<FFM_SRVCNew> FFM_SRVCNew { get; set; }
        public FFM_SRVCNew FFM_SRVCDetail { get; set; }
        public List<string> Drecord { get; set; }
    }
    public class FFM_SRVCNew
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
       
        public string FFM_SRVC_CODE { get; set; }
        public string NAME { get; set; }
    }
}

