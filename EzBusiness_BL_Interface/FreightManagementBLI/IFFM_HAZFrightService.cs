﻿using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
  public  interface IFFM_HAZFrightService
    {
        List<FFM_HAZ_VM> GetFFM_HAZ(string CmpyCode);

        FFM_HAZ_VM SaveFFM_HAZ(FFM_HAZ_VM FCur);
        FFM_HAZ_VM EditFFM_HAZ(string CmpyCode, string FFM_HAZ_VM);
        bool DeleteFFM_HAZ(string FFM_HAZ_VM_CODE, string CmpyCode, string UserName);
    }
}
