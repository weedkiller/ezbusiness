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
    public interface IMonthlyAdddedPayrollService
    {
        #region MonthlyAddded
        List<SelectListItem> GetEmpCodeList(string CmpyCode,string Prefix);

        List<MonthlyAdddedVM> GetMonthlyAdddedList(string CmpyCode);
        List<MonthlyAdddeddet1> GetMonthlyADGrid(string CmpyCode, string PRADN001_CODE);
        MonthlyAdddedVM SaveMonthlyAD(MonthlyAdddedVM MonthlyAD);
        MonthlyAdddedVM GetMonthlyADEdit(string CmpyCode, string PRADN001_CODE);
        MonthlyAdddedVM GetMonthlyAdddedNew(string CmpyCode);

        bool DeleteMonthlyAD(string CmpyCode, string PRADN001_CODE, string UserName);
        #endregion
    }
}
