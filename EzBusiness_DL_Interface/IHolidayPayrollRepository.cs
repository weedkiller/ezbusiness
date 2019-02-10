using EzBusiness_EF_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IHolidayPayrollRepository
    {

        List<Attendence> GetAttendenceCodesH(string CmpyCode);

        //List<Country> GetCountrys();


        List<HolidayVM> GetAtensH(string CmpyCode,  DateTime date);


        bool DeleteHoliday(string CmpyCode, string HRPH001_CODE, string UserName);

        HolidayVM SaveHoliday(HolidayVM Hol);



    }
}
