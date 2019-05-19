using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
    public interface IFFM_PACKINGService
    {
        List<FFM_PACKING_VM> GetFFM_PACKING(string CmpyCode);
        FFM_PACKING_VM SaveFFM_PACKING(FFM_PACKING_VM FC);
        bool DeleteFFM_PACKING(string FFM_PACKING_CODE, string CmpyCode, string UserName);
        FFM_PACKING_VM EditFFM_PACKING(string CmpyCode, string FFM_PACKING_CODE);
    }
}
