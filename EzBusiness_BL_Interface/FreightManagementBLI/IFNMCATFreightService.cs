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
    public interface IFNMCATFreightService
    {
        #region FNMCAT Master
        List<FNMCAT_VM> GetFNMCAT(string CmpyCode);
        FNMCAT_VM SaveFNMCAT(FNMCAT_VM FC);
        bool DeleteFNMCAT(string FNMCAT_CODE, string CmpyCode, string UserName);
        #endregion
    }
}
