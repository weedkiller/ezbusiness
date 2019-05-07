using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagement;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_EF_Entity.FreightManagementEF;

namespace EzBusiness_DL_Interface.FreightManagement
{
    public interface  IFMHeadFreightRepository
    {

        #region FMHead Master
        List<FMHEAD> GetFMHEAD(string CmpyCode);

        FMHEAD_VM SaveFMHEAD(FMHEAD_VM FH);



        bool DeleteFMHEAD(string FNMHEAD_CODE, string CmpyCode, string UserName);

      

        #endregion
    }
}
