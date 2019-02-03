using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface INationRPayrollRepository
    {
        #region NationR Master
        List<NationRegion> GetNrs(string CmpyCode);

        NationRegionVM SaveNrs(NationRegionVM Nrs);



        bool DeleteNrs(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
