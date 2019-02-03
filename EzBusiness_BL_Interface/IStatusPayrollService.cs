using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Interface
{
    public interface IStatusPayrollService
    {
        List<StatusVM> GetStats(string CmpyCode);

        StatusVM SaveStats(StatusVM Stats);



        bool DeleteStats(string Code, string CmpyCode, string UserName);
    }
}
