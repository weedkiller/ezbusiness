﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_ViewModels.Models.FreightManagement
{
  public  class FFM_MOVE_VM
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
     
        public string FFM_MOVE_CODE { get; set; }
        public string NAME { get; set; }
        public bool SaveFlag { get; set; }
        public bool EditFlag { get; set; }
        public string ErrorMessage { get; set; }
        public string UserName { get; set; }
        public List<FFM_MOVE_NewDetail> ffmmovedetails { get; set; }
        public FFM_MOVE_NewDetail ffmovenewlist { get; set; }
    }
    public class FFM_MOVE_NewDetail
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }

        public string FFM_MOVE_CODE { get; set; }
        public string NAME { get; set; }
    }
}
