using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFFM_COM_GROUPRepository
    {

        #region FFM_COM_GROUP Master
        List<FFM_COM_GROUP> GetFFM_COM_GROUP(string CmpyCode);
        FFM_COM_GROUP_VM SaveFFM_COM_GROUP(FFM_COM_GROUP_VM FC);
        bool DeleteFFM_COM_GROUP(string FFM_COM_GROUP_CODE, string CmpyCode, string UserName);

        #endregion
    }
}
