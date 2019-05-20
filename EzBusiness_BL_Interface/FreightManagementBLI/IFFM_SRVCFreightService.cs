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
    public interface IFFM_SRVCFreightService
    {
        #region FFM_SRVC Master
        List<FFM_SRVC_VM> GetFFM_SRVC(string CmpyCode);
        FFM_SRVC_VM SaveFFM_SRVC(FFM_SRVC_VM SR);
        bool DeleteFFM_SRVC(string FFM_SRVC_CODE, string CmpyCode, string UserName);
        #endregion
    }
}
