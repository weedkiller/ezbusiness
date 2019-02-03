using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IStatusPayrollRepository
    {
        #region Status Master
        List<Status> GetStats(string CmpyCode);

        StatusVM SaveStats(StatusVM Stats);



        bool DeleteStats(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
