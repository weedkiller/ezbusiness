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
    public interface IFNMGROUPFreightService
    {
        #region FNMGROUP Master
        List<FNMGROUP_VM> GetFNMGROUP(string CmpyCode);
        FNMGROUP_VM SaveFNMGROUP(FNMGROUP_VM FC);
        bool DeleteFNMGROUP(string FNMGROUP_CODE, string CmpyCode, string UserName);
        #endregion
    }
}
