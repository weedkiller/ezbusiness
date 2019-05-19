using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFNMTYPERepository
    {
        #region FNMTYPE Master
        List<FNMTYPE> GetFNMTYPE(string CmpyCode);
        FNMTYPE_VM SaveFNMTYPE(FNMTYPE_VM FT);
        bool DeleteFNMTYPE(string FNMTYPE_CODE, string CmpyCode, string UserName);

        #endregion
    }
}
