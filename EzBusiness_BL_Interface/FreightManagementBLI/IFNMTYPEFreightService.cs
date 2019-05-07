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
   public interface IFNMTYPEFreightService
    {
        #region FNMTYPE Master
        List<FNMTYPE_VM> GetFNMTYPE(string CmpyCode);
        FNMTYPE_VM SaveFNMTYPE(FNMTYPE_VM FT);
        bool DeleteFNMTYPE(string FNMTYPE_CODE, string CmpyCode, string UserName);
        #endregion
    }
}
