using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface ILoanPayrollRepository
    {
        #region Loan Master
        List<Loan> GetLons(string CmpyCode);

        LoanVM SaveLons(LoanVM Lons);



        bool DeleteLons(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
