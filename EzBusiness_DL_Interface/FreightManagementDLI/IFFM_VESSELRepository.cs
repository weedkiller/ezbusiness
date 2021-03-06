﻿using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public  interface IFFM_VESSELRepository
    {
        bool DeleteFFM_VESSEL(string FFM_VESSEL_CODE, string CmpyCode, string UserName);
        List<FFM_VESSEL> GetFFM_VESSEL(string CmpyCode);      
        FFM_VESSEL_VM SaveFFM_VESSEL(FFM_VESSEL_VM ac);
        FFM_VESSEL_VM EditFFM_VESSEL(string CmpyCode, string FFM_VESSEL_CODE);
        List<ComDropTbl> GetNationList(string CmpyCode,string Prefix);

        List<ComDropTbl> GetContainer(string CmpyCode, string Prefix);


    }
}
