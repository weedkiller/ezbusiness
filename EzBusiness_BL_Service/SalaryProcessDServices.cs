using EzBusiness_BL_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using System.Web;
using System.Web.Mvc;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service
{
    public class SalaryProcessDServices : ISalaryProcessDService
    {
        ISalaryProcessDRepository _salaryrepo;
        ICodeGenRepository _CodeRep;
        IOTPayrollRepository _OTPayrollRepository;
        IEmployeeMgmtRepository _empservice;
        public SalaryProcessDServices()
        {
            _salaryrepo = new SalaryProcessRepository();
            _CodeRep = new CodeGenRepository();
            _OTPayrollRepository = new OTPayrollRepository();
            _empservice = new EmployeeMgmtRepository();
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
              DivisionCode=m.DivisionCode,
              Deptcode=m.Deptcode,
              year=m.year,
              Month=m.Month,
              DeptName=m.DeptName,
              DivisionName=m.DivisionName,
              VisaLocationName=m.VisaLocationName,
              VisaLocation1=m.VisaLocation1

            }).ToList();
        }
        public List<SalaryProcessDetailsListItem> GetTimeSheetDetailsByMonth(string CmpyCode, DateTime currDate,string divcode,string Deptcode, string VisaLocation1)
        {
            //return _salaryrepo.GetSalaryDetailsList(CmpyCode);


            return  _salaryrepo.GetTimeSheetDetailsByMonth(CmpyCode,currDate,divcode,Deptcode,VisaLocation1);
            //return poEmployeeList.Select(m => new SalaryProcessDetailsVM
            //{
            //    em = m.Code,
            //    CurrentDate = m.CurrentDate,

            //}).ToList();
        }


        public SalaryProcessDetailsVM GetSalaryProcessEdit(string CmpyCode, string PRSFT001_code)
        {
            var poedit = _salaryrepo.GetSalaryProcessEdit(CmpyCode, PRSFT001_code);
            poedit.DivisionList = GetDivCodeList(CmpyCode);
            poedit.VisaLocationList = GetVisLocList(CmpyCode);               
            poedit.VisaLocationList = GetVisLocList(CmpyCode);
            poedit.DepartmentList = GetDepartmentList(CmpyCode, poedit.DivisionCode);
         //   poedit.salaryList = GetSalaryProcessGridEdit(poedit.year,poedit.Month,poedit.CmpyCode);

            return poedit;
        }
      
        public List<SalaryProcessDetailsListItem> GetSalaryProcessGrid(string CmpyCode,DateTime CurrDate,string DivCode,string deptcode,string visaloc)
        {
            return _salaryrepo.GetSalaryProcessGrid(CmpyCode, CurrDate,DivCode,deptcode,visaloc);
        }

        public SalaryProcessDetailsVM SaveSalaryProcessD(SalaryProcessDetailsVM salary)
        {
            if(!salary.EditFlag)
            {
                salary.PRSP001_Code = _CodeRep.GetCode(salary.CmpyCode, "SalaryProcess");
            }
            return _salaryrepo.SaveSalaryProcessD(salary);
        }
        public SalaryProcessDetailsVM GetSalaryProcessDetailList(string CmpyCode)
        {
            List<SessionListnew> list = HttpContext.Current.Session["SesDet"] as List<SessionListnew>;

            return new SalaryProcessDetailsVM
            {
                // AccNoList = GetAccList(CmpyCode, "EXP"),
                PRSP001_Code = _CodeRep.GetCode(CmpyCode,"SalaryProcess"),
                DivisionList = GetDivCodeList(CmpyCode),
                DivisionCode = list[0].Divcode.ToString(),
                VisaLocationList =GetVisLocList(CmpyCode),
               DepartmentList =GetDepartmentList(CmpyCode,list[0].Divcode)

            };
        }

        public List<SalaryProcessDetailsListItem> GetSalaryProcessGridEdit(int year,int month,string CmpyCode)
        {
            var poEmployeeList = _salaryrepo.GetSalaryProcessGridEdit(year,month,CmpyCode);
            return poEmployeeList.Select(m => new SalaryProcessDetailsListItem
            {
                 srno=m.srno,
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
        public bool CheckslryDataCalculated(string CmpyCode, DateTime CurrDate, string Divcode, string DeptCode, string Visaloc)
        {
            return _salaryrepo.CheckslryDataCalculated(CmpyCode, CurrDate,Divcode,DeptCode,Visaloc);
        }

        public List<SelectListItem> GetDivCodeList(string CmpyCode)
        {
            var itemCodes = _OTPayrollRepository.GetDivCodeList(CmpyCode)
                                     .Select(m => new SelectListItem { Value = m.DivisionCode, Text = string.Concat(m.DivisionCode, " - ", m.DivisionName) })
                                     .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
        private List<SelectListItem> InsertFirstElementDDL(List<SelectListItem> items)
        {
            items.Insert(0, new SelectListItem
            {
                Value = PurchaseMgmtConstants.DDLFirstVal,
                Text = PurchaseMgmtConstants.DDLFirstText
            });          
            return items;
        }

        public List<SelectListItem> GetVisLocList(string CmpyCode)
        {
            var itemCodes = _empservice.GetVisaLocationList(CmpyCode)
                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                    .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
        public List<SelectListItem> GetDepartmentList(string CmpyCode, string divcode)
        {
            var itemCodes = _salaryrepo.GetDepartmentList(CmpyCode, divcode)
                                      .Select(m => new SelectListItem { Value = m.DepartmentCode, Text = string.Concat(m.DepartmentCode, "-", m.DepartmentName) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

    }
}
