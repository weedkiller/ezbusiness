using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FinaceMgmt;


namespace EzBusiness_BL_Interface
{
    public interface IFinaceMgmtService
    {
        
        List<ExchangeRateVM> GetExchange(string CmpyCode);

        ExchangeRateVM SaveExchange(ExchangeRateVM Exchange);

     

        bool DeleteExchange(string CurCode, string CmpyCode, string UserName);

    }
}

