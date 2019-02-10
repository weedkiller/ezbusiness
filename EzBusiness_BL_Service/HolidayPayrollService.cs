using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;
using EzBusiness_ViewModels;


namespace EzBusiness_BL_Service
{

    public class HolidayPayrollService : IHolidayPayrollService
    {
       IHolidayPayrollRepository  _HolyRepo;
        public HolidayPayrollService()
        {
            _HolyRepo = new HolidayPayrollRepository();
        }

        public bool DeleteHoliday(string CmpyCode, string HRPH001_CODE, string UserName)
        {
            return _HolyRepo.DeleteHoliday(CmpyCode, HRPH001_CODE, UserName);
        }

        
        public List<HolidayVM> GetAtensH(string CmpyCode, DateTime date)
        {
           return _HolyRepo.GetAtensH(CmpyCode, date).Select(m => new HolidayVM
            {               
                Dates = m.Dates,
                COUNTRY=m.COUNTRY,
                LEAVE_TYPECODE=m.LEAVE_TYPECODE,
                Description=m.Description,  
                HRPH001_CODE=m.HRPH001_CODE            
            }).ToList();
        }

    

       public List<Attendence> GetAttendenceCodesH(string CmpyCode)
        {
            var Cou =_HolyRepo.GetAttendenceCodesH(CmpyCode);
            Cou.Insert(0, new Attendence { Code = "0", LeaveName = "-Select-" });
            return Cou;
        }

        //public List<Country> GetCountrys()
        //{

        //    var Countrys = _HolyRepo.GetCountrys();
        //    Countrys.Insert(0, new Country { Code = "0", Name = "-Select-" });
        //    return Countrys;
        //}

        public HolidayVM SaveHoliday(HolidayVM Hol)
        {
            return _HolyRepo.SaveHoliday(Hol);
        }
    }
}
