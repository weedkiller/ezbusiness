﻿using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
   public interface IFFM_UNITRepository
    {
        List<FFM_Unit> GetFFM_Unit(string CmpyCode);

        FFM_Unit_VM SaveFFM_Unit(FFM_Unit_VM FCur);
        FFM_Unit_VM EditFFM_Unit(string CmpyCode, string FFM_Unit_VM);
        bool DeleteFFM_Unit(string FFM_Unit_VM_CODE, string CmpyCode, string UserName);
    }
}
