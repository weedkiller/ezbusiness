using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IAttendencePayrollRepository
    {
        #region Attendence Master
        List<Attendence> GetAtens(string CmpyCode);

        AttendenceVM SaveAtens(AttendenceVM Atens);
        

        List<Country> GetCountryCodes(string CmpyCode);

        bool DeleteAtens(string Code, string CmpyCode, string username);

        #endregion

        #region Attendence Request



        #endregion

    }
}
