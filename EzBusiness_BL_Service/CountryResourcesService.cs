using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresource;

namespace EzBusiness_BL_Service
{
    public class CountryResourcesService : ICountryResourcesService
    {
        ICountryResourcesRepository _CountryRepo;

        public CountryResourcesService()
        {
            _CountryRepo = new CountryResourcesRepository();
        }

        public bool DeleteCountrys(string Code, string CmpyCode, string UserName)
        {
            return _CountryRepo.DeleteCountrys(Code, CmpyCode, UserName);
        }

        public List<CountryVM> GetCountrys(string CmpyCode)
        {
            return _CountryRepo.GetCountrys(CmpyCode).Select(m => new CountryVM
            {
                CmpyCode = m.Cmpycode,
                Code = m.Code,
                Name = m.Name,
                UniCodeName = m.UniCodeName

            }).ToList();
        }

        public CountryVM SaveCountrys(CountryVM Countrys)
        {
            return _CountryRepo.SaveCountrys(Countrys);
        }
    }
}
