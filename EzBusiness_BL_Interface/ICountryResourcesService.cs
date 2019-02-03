using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresource;

namespace EzBusiness_BL_Interface
{
    public interface ICountryResourcesService
    {
        List<CountryVM> GetCountrys(string CmpyCode);

        CountryVM SaveCountrys(CountryVM Countrys);



        bool DeleteCountrys(string Code, string CmpyCode, string UserName);
    }
}
