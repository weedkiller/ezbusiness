using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresource;

namespace EzBusiness_DL_Interface
{
    public interface ICountryResourcesRepository
    {
        #region Countrys Master
        List<Country> GetCountrys(string CmpyCode);

        CountryVM SaveCountrys(CountryVM Countrys);



        bool DeleteCountrys(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
