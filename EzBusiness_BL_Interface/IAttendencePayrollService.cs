using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
    public interface IAttendencePayrollService
    {
        List<AttendenceVM> GetAtens(string CmpyCode);

        AttendenceVM SaveAtens(AttendenceVM Atens);        


        List<Country> GetCountryCodes(string CmpyCode);

        bool DeleteAtens(string Code, string CmpyCode, string username);
    }
}
