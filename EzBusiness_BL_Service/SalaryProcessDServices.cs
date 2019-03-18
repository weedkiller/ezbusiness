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
               PRSP001_Code=m.PRSP001_Code,
               Process_Date=m.Process_Date,
              Country=m.Country,
              Division=m.Division,
              Deptcode=m.Deptcode,
              year=m.year,
              Month=m.Month,
              VisaLocation=m.VisaLocation

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
            poedit.salaryList = GetSalaryProcessGridEdit(poedit.year,poedit.Month,poedit.CmpyCode);
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

        public List<SalaryProcessDetailsListItem> GetSalaryProcessGridEdit(int year,int month,string CmpyCode)
        {
            var poEmployeeList = _salaryrepo.GetSalaryProcessGridEdit(year,month,CmpyCode);
            return poEmployeeList.Select(m => new SalaryProcessDetailsListItem
            {
                // Sno=m.Sno    ,
                cmpycode = m.cmpycode,
                country = m.country,
                Division = m.Division,
                Tyear = m.Tyear,
                Tmonth = m.Tmonth,
                Empcode = m.Empcode,
                Empname = m.Empname,
                ProfCode = m.ProfCode,
                DepCode = m.DepCode,
                ComnPrjcode = m.ComnPrjcode,
                VisaLocation = m.VisaLocation,
                WorkLocation = m.WorkLocation,
                Total_Days = m.Total_Days,
                Worked_Days = m.Worked_Days,
                a_basic = m.a_basic,
                a_hra = m.a_hra,
                a_Da = m.a_Da,
                a_tele = m.a_tele,
                a_trans = m.a_trans,
                a_car = m.a_car,
                a_allowance1 = m.a_allowance1,
                a_allowance2 = m.a_allowance2,
                a_allowance3 = m.a_allowance3,
                a_Totalsalary = m.a_Totalsalary,
                C_basic = m.C_basic,
                C_hra = m.C_hra,
                C_da = m.C_da,
                C_tele = m.C_tele,
                C_trans = m.C_trans,
                C_car = m.C_car,
                C_allowance1 = m.C_allowance1,
                C_allowance2 = m.C_allowance2,
                C_allowance3 = m.C_allowance3,
                C_totalSalary = m.C_totalSalary,
                loan_amt = m.loan_amt,
                adn_amount = m.adn_amount,
                nothrs = m.nothrs,
                extraOThrs = m.extraOThrs,
                hothrs = m.hothrs,
                wothrs = m.wothrs,
                not_rate_perhr = m.not_rate_perhr,
                ExtraOT_rate_perhr = m.ExtraOT_rate_perhr,
                hot_rate_perhr = m.hot_rate_perhr,
                wot_rate_perhr = m.wot_rate_perhr,
                ExtraOTAmt = m.ExtraOTAmt,
                NOTAmt = m.NOTAmt,
                HOTAmt = m.HOTAmt,
                WOTAmt = m.WOTAmt,
                NetSalary = m.NetSalary,

            }).ToList();
            return _salaryrepo.GetSalaryProcessGridEdit(year, month, CmpyCode);

        }

        public bool CheckslryDataCalculated(string CmpyCode, DateTime CurrDate)
        {
            return _salaryrepo.CheckslryDataCalculated(CmpyCode, CurrDate);
        }
    }
}
