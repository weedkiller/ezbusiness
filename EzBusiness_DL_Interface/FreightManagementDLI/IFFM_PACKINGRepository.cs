using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_EF_Entity.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFFM_PACKINGRepository
    {
        List<FFM_PACKING> GetFFM_PACKING(string CmpyCode);

        FFM_PACKING_VM SaveFFM_PACKING(FFM_PACKING_VM fpk);

        bool DeleteFFM_PACKING(string FFM_PACKING_CODE, string CmpyCode, string UserName);
        FFM_PACKING_VM EditFFM_PACKING(string CmpyCode, string FFM_PACKING_CODE);
    }
}
