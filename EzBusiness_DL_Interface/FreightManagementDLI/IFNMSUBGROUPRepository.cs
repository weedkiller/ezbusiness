using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFNMSUBGROUPRepository
    {
        #region FNMSUBGROUP Master
        List<FNMSUBGROUP> GetFNMSUBGROUP(string CmpyCode);
        FNMSUBGROUP_VM SaveFNMSUBGROUP(FNMSUBGROUP_VM FSG);
        bool DeleteFNMSUBGROUP(string FNMSUBGROUP_CODE, string CmpyCode, string UserName);

        #endregion
    }
}
