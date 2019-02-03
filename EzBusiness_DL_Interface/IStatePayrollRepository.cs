using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IStatePayrollRepository
    {
        #region State Master
        List<State> GetSts(string CmpyCode);

        StateVM SaveSts(StateVM Sts);



        bool DeleteSts(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
