using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface.FreightManagement;
using EzBusiness_DL_Repository.FreightManagement;
using EzBusiness_EF_Entity.FreightManagement;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_BL_Interface.FreightManagement
{
    public interface IFMHeadFreightService
    {
        #region FMHead Master
        List<FMHEAD_VM> GetFMHEAD(string CmpyCode);
        FMHEAD_VM SaveFMHEAD(FMHEAD_VM FH);
        bool DeleteFMHEAD(string FNMHEAD_CODE, string CmpyCode, string UserName);
        #endregion
    }
}
