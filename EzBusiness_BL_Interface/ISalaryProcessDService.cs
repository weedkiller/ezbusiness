using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface
{
   public interface ISalaryProcessDService
    {
        List<SalaryProcessDetailsVM> GetSalaryDetailsList(string CmpyCode);
        List<SalaryProcessDetailsListItem> GetSalaryProcessGrid(string CmpyCode,DateTime CurrDate);
         List<SalaryProcessDetailsListItem> GetTimeSheetDetailsByMonth(string CmpyCode, DateTime currDate);
        SalaryProcessDetailsVM SaveSalaryProcessD(SalaryProcessDetailsVM Sft);

        SalaryProcessDetailsVM GetSalaryProcessEdit(string CmpyCode, string PRSFT001_code);
        List<SalaryProcessDetailsListItem> GetSalaryProcessGridEdit(int year, int month, string CmpyCode);
        string GetSalaryProcessId(string CmpyCode);
        bool DeleteSalaryProcess(string CmpyCode,string Code,DateTime CurrDate,string UserName);
        // int UseShiftAlloc(string CmpyCode, string PRSFT001_code, string PRSFT002_code);
        bool CheckslryDataCalculated(string CmpyCode, DateTime CurrDate);
        //  #endregion
        #region SalaryProcess Request

        #endregion

    }
}
