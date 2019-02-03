using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
namespace EzBusiness_DL_Interface
{
   public interface IMonthlyAdddedPayrollRepository
    {
        #region MonthlyAddded
        List<Employee> GetEmpCodeList(string CmpyCode);

        List<MonthlyAdddedVM> GetMonthlyAdddedList(string CmpyCode);
        List<MonthlyAdddeddet1> GetMonthlyADGrid(string CmpyCode, string PRADN001_CODE);
        MonthlyAdddedVM SaveMonthlyAD(MonthlyAdddedVM MonthlyAD);
        MonthlyAdddedVM GetMonthlyADEdit(string CmpyCode, string PRADN001_CODE);        
        bool DeleteMonthlyAD(string CmpyCode, string PRADN001_CODE, string UserName);    
        #endregion

    }
}
