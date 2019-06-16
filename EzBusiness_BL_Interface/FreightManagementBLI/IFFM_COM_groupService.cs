using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
   public interface IFFM_COM_groupService
    {
        #region FFM_COM_group Master
        List<FFM_COM_GROUP_VM> GetFFM_COM_group(string CmpyCode);
        FFM_COM_GROUP_VM SaveFFM_COM_GROUP(FFM_COM_GROUP_VM FC);
        bool DeleteFFM_COM_group(string FFM_COM_group_CODE, string CmpyCode, string UserName);
        #endregion
    }
}
