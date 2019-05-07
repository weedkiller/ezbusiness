using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFNMCATRepository
    {
        #region FNMCAT Master
        List<FNMCAT> GetFNMCAT(string CmpyCode);
        FNMCAT_VM SaveFMHEAD(FNMCAT_VM FC);
        bool DeleteFNMCAT(string FNMCAT_CODE, string CmpyCode, string UserName);

        #endregion
    }
}
