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
    public interface IFFM_COMFreightService
    {
        #region FFM_COM Master
        List<FFM_COM_VM> GetFFM_COM(string CmpyCode);
        FFM_COM_VM SaveFFM_COM(FFM_COM_VM FC);
        bool DeleteFFM_COM(string FFM_COM_CODE, string CmpyCode, string UserName);

        List<FFM_COM_GROUP> GetFFM_COM_GROUP(string CmpyCode);
        #endregion
    }
}
