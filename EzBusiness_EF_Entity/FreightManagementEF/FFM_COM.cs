﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_EF_Entity.FreightManagementEF
{
   public partial class FFM_COM
    {
        public string CREATED_BY { get; set; }
        public DateTime CREATED_ON { get; set; }
        public string UPDATED_BY { get; set; }
        public DateTime UPDATED_ON { get; set; }
        public string CMPYCODE { get; set; }
        [Display(Name = "CODE")]
        public string FFM_COM_CODE { get; set; }
        public string NAME { get; set; }
        [Display(Name = "Group")]
        public string C_TYPE { get; set; }
    }
}
