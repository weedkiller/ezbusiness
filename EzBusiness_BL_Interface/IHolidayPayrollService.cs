using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;


namespace EzBusiness_BL_Interface
{
  public  interface IHolidayPayrollService
    {
        List<Attendence> GetAttendenceCodesH(string CmpyCode);

        List<HolidayVM> GetAtensH(string CmpyCode,DateTime date);

        //  List<Country> GetCountrys();

        bool DeleteHoliday(string CmpyCode, string HRPH001_CODE, string UserName);

        HolidayVM SaveHoliday(HolidayVM Hol);

    }
}
