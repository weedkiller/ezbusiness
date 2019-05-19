using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFNMGROUPRepository
    {
        #region FNMGROUP Master
        List<FNMGROUP> GetFNMGROUP(string CmpyCode);
        FNMGROUP_VM SaveFNMGROUP(FNMGROUP_VM FG);
        bool DeleteFNMGROUP(string FNMGROUP_CODE, string CmpyCode, string UserName);

        #endregion
    }
}
