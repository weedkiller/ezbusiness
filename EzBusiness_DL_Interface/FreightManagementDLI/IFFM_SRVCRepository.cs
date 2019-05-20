using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFFM_SRVCRepository
    {
        #region FFM_SRVC Master
        List<FFM_SRVC> GetFFM_SRVC(string CmpyCode);
        FFM_SRVC_VM SaveFM_SRVCHEAD(FFM_SRVC_VM SR);
        bool DeleteFFM_SRVC(string FFM_SRVC_CODE, string CmpyCode, string UserName);

        #endregion
    }
}
