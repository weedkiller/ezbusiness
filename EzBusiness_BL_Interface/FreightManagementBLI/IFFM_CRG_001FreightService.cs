using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
    public interface IFFM_CRG_001FreightService
    {
        #region FFM_CRG_001 Master
        List<FFM_CRG_001_VM> GetFFM_CRG_001(string CmpyCode);
        FFM_CRG_001_VM SaveFFM_CRG_001(FFM_CRG_001_VM CR);
        bool DeleteFFM_CRG_001(string FFM_CRG_001_CODE, string CmpyCode, string UserName);
        #endregion
    }
}
