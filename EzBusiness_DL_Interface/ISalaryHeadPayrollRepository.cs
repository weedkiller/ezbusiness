using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface ISalaryHeadPayrollRepository
    {
        #region SalaryHead Master
        List<SalaryHead> GetSals(string CmpyCode);

        SalaryHeadVM SaveSals(SalaryHeadVM Sals);

        List<CommonTable> GetPayDeductOns();

        bool DeleteSals(string Code, string CmpyCode,string UserName);

        #endregion

        #region SalaryHead Request



        #endregion

    }
}
