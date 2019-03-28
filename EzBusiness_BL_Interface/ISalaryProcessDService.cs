using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
   public interface ISalaryProcessDService
    {
        List<SalaryProcessDetailsVM> GetSalaryDetailsList(string CmpyCode);
        List<SalaryProcessDetailsListItem> GetSalaryProcessGrid(string CmpyCode,DateTime CurrDate,string divcode,string deptcode,string visaloc);
         List<SalaryProcessDetailsListItem> GetTimeSheetDetailsByMonth(string CmpyCode,DateTime CurrentDate, string divcode, string Deptcode, string VisaLocation1);
        SalaryProcessDetailsVM SaveSalaryProcessD(SalaryProcessDetailsVM Sft);
        List<SelectListItem> GetDivCodeList(string CmpyCode);

        List<SelectListItem> GetVisLocList(string CmpyCode);

        SalaryProcessDetailsVM GetSalaryProcessEdit(string CmpyCode, string PRSFT001_code);
        List<SalaryProcessDetailsListItem> GetSalaryProcessGridEdit(int year, int month, string CmpyCode);
        SalaryProcessDetailsVM GetSalaryProcessDetailList(string CmpyCode);
        bool DeleteSalaryProcess(string CmpyCode,string Code,DateTime CurrDate,string UserName);
        // int UseShiftAlloc(string CmpyCode, string PRSFT001_code, string PRSFT002_code);
        bool CheckslryDataCalculated(string CmpyCode, DateTime CurrDate,string Divcode,string DeptCode,string Visaloc);
        List<SelectListItem> GetDepartmentList(string CmpyCode, string divcode);
        //  #endregion
        #region SalaryProcess Request

        #endregion

    }
}
