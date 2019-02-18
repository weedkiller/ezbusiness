using EzBusiness_BL_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;

namespace EzBusiness_BL_Service
{
    public class SalaryProcessDServices : ISalaryProcessDService
    {
        ISalaryProcessDRepository _salaryrepo;

        public SalaryProcessDServices()
        {
            _salaryrepo = new SalaryProcessRepository();
        }

        public bool DeleteSalaryProcess(string CmpyCode, string Code, DateTime CurrDate, string UserName)
        {
            return _salaryrepo.DeleteSalaryProcess(CmpyCode, Code, CurrDate, UserName);
        }

        public List<SalaryProcessDetailsVM> GetSalaryDetailsList(string CmpyCode)
        {
            //return _salaryrepo.GetSalaryDetailsList(CmpyCode);


            var poEmployeeList = _salaryrepo.GetSalaryDetailsList(CmpyCode);
            return poEmployeeList.Select(m => new SalaryProcessDetailsVM
            {
               Code=m.Code,
               CurrentDate=m.CurrentDate,

            }).ToList();
        }
        public List<SalaryProcessDetailsListItem> GetTimeSheetDetailsByMonth(string CmpyCode, DateTime currDate)
        {
            //return _salaryrepo.GetSalaryDetailsList(CmpyCode);


            return  _salaryrepo.GetTimeSheetDetailsByMonth(CmpyCode,currDate);
            //return poEmployeeList.Select(m => new SalaryProcessDetailsVM
            //{
            //    em = m.Code,
            //    CurrentDate = m.CurrentDate,

            //}).ToList();
        }


        public SalaryProcessDetailsVM GetSalaryProcessEdit(string CmpyCode, string PRSFT001_code)
        {
            var poedit = _salaryrepo.GetSalaryProcessEdit(CmpyCode, PRSFT001_code);
           // poedit.salaryList = GetSalaryProcessGridEdit(CmpyCode, PRSFT001_code);
            return poedit;
        }
      
        public List<SalaryProcessDetailsListItem> GetSalaryProcessGrid(string CmpyCode,DateTime CurrDate)
        {
            return _salaryrepo.GetSalaryProcessGrid(CmpyCode, CurrDate);
        }

        public SalaryProcessDetailsVM SaveSalaryProcessD(SalaryProcessDetailsVM salary)
        {
            return _salaryrepo.SaveSalaryProcessD(salary);
        }
        public string GetSalaryProcessId(string CmpyCode)
        {
            return _salaryrepo.GetSalaryProcessId(CmpyCode);
        }

        public List<SalaryProcessDetailsListItem> GetSalaryProcessGridEdit(string CmpyCode, string PRSPD001_code)
        {
            //var poEmployeeList = _salaryrepo.GetSalaryProcessGridEdit(CmpyCode, PRSPD001_code);
            //return poEmployeeList.Select(m => new SalaryProcessDetailsListItem
            //{
            //   // Sno=m.Sno    ,
            //    Code = m.Code,
            //    EmpCode=m.EmpCode,
            //    EmpName=m.EmpName,
            //    WorkingDay=m.WorkingDay,
            //    Present=m.Present,
            //    Leaves=m.Leaves,
            //    Absent=m.Absent,
            //    SickLeaves=m.SickLeaves,
            //    WeeklyOff=m.WeeklyOff,
            //    Holiday=m.Holiday,
            //    NormalOTHrs=m.NormalOTHrs,
            //    TotalDeduction=m.TotalDeduction,
            //    MonthlyAddition=m.MonthlyAddition,              
            //}).ToList();
            return _salaryrepo.GetSalaryProcessGridEdit(CmpyCode, PRSPD001_code);

        }

        public bool CheckslryDataCalculated(string CmpyCode, DateTime CurrDate)
        {
            return _salaryrepo.CheckslryDataCalculated(CmpyCode, CurrDate);
        }
    }
}
