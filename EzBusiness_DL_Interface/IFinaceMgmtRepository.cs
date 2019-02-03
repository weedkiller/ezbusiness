using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FinaceMgmt;

namespace EzBusiness_DL_Interface
{
    public interface IFinaceMgmtRepository
    {
        #region ExchangeRate Master
        List<ExchangeRates> GetExchange(string CmpyCode);

        ExchangeRateVM SaveExchange(ExchangeRateVM Exchange);



        bool DeleteExchange(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
