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
    public interface IFNMSUBGROUPFreightService
    {

        #region FNMSUBGROUP Master
        List<FNMSUBGROUP_VM> GetFNMSUBGROUP(string CmpyCode);
        FNMSUBGROUP_VM SaveFNMSUBGROUP(FNMSUBGROUP_VM FT);
        bool DeleteFNMSUBGROUP(string FNMSUBGROUP_CODE, string CmpyCode, string UserName);
        #endregion
    }
}
