using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFFM_COMRepository
    {
        #region FFM_COM Master
        List<FFM_COM> GetFFM_COM(string CmpyCode);
        FFM_COM_VM SaveFM_COMHEAD(FFM_COM_VM FC);
        bool DeleteFFM_COM(string FFM_COM_CODE, string CmpyCode, string UserName);
        List<FFM_COM_GROUP> GetFFM_COM_GROUP(string CmpyCode,string Prefix);
        #endregion
    }
}
