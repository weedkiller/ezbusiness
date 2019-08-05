using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface
{
    public interface ISalaryProcessDRepository
    {
        List<SalaryProcessDetailsVM> GetSalaryDetailsList(string CmpyCode);
        List<SalaryProcessDetailsListItem> GetSalaryProcessGrid(string CmpyCode, DateTime CurrDate, string DivCode,string deptcode, string visaloc);
        SalaryProcessDetailsVM SaveSalaryProcessD(SalaryProcessDetailsVM salary);
        SalaryProcessDetailsVM GetSalaryProcessEdit(string CmpyCode, string PRSPD001_code);

        List<SalaryProcessDetailsListItem> GetTimeSheetDetailsByMonth(string CmpyCode, DateTime currDate,string divcode,string DeptCode,string visalocation);
        List<SalaryProcessDetailsListItem> GetSalaryProcessGridEdit(int year, int month, string CmpyCode);
        bool DeleteSalaryProcess(string CmpyCode, string Code, DateTime CurrDate, string UserName);
        //SalaryProcessDetailsVM GetSalaryProcessDetailList(string CmpyCode);
        bool CheckslryDataCalculated(string CmpyCode, DateTime CurrDate,string divcode,string deptcode,string visaloc);
        List<Department> GetDepartmentList(string CmpyCode, string divcode);
        List<ComDropTbl> GetDepartmentList1(string CmpyCode, string divcode,string Prefix);


        #region SalaryProcess Request

        #endregion

    }
}
