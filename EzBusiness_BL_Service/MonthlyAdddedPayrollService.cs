using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresource;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Service
{
    public class MonthlyAdddedPayrollService : IMonthlyAdddedPayrollService
    {
        IMonthlyAdddedPayrollRepository _MonthlyAdddedPayrollRepo;
        ICodeGenRepository _CodeRep;
        public MonthlyAdddedPayrollService()
        {
            _MonthlyAdddedPayrollRepo = new MonthlyAdddedPayrollRepository();
            _CodeRep = new CodeGenRepository();
        }
        public bool DeleteMonthlyAD(string CmpyCode, string PRADN001_CODE, string UserName)
        {
            return _MonthlyAdddedPayrollRepo.DeleteMonthlyAD(CmpyCode, PRADN001_CODE, UserName);
        }

        public List<SelectListItem> GetEmpCodeList(string CmpyCode)
        {
            var EmpCodeList = _MonthlyAdddedPayrollRepo.GetEmpCodeList(CmpyCode)
                                         .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                         .ToList();
            return InsertFirstElementDDL(EmpCodeList);
        }
        private List<SelectListItem> InsertFirstElementDDL(List<SelectListItem> items)
        {
            items.Insert(0, new SelectListItem
            {
                Value = EzBusiness_ViewModels.PurchaseMgmtConstants.DDLFirstVal,
                Text = EzBusiness_ViewModels.PurchaseMgmtConstants.DDLFirstText
            });
            return items;
        }
        public List<MonthlyAdddedVM> GetMonthlyAdddedList(string CmpyCode)
        {
            return _MonthlyAdddedPayrollRepo.GetMonthlyAdddedList(CmpyCode).Select(m => new MonthlyAdddedVM
            {
                PRADN001_CODE=m.PRADN001_CODE,
                Entry_Date=m.Entry_Date,
                TMonth=m.TMonth,
                TYear=m.TYear,               
            }).ToList();
        }

        public MonthlyAdddedVM GetMonthlyAdddedNew(string CmpyCode)
        {
            return new MonthlyAdddedVM
            {
                PRADN001_CODE=_CodeRep.GetCode(CmpyCode, "MonthlyAddded"),
                MonthlyAddded = new List<MonthlyAdddeddet1>(),
                MonthlyAdddedM = new MonthlyAdddeddet1(),
                EmpNameList = GetEmpCodeList(CmpyCode),
                EditFlag = false
            };
        }
        public MonthlyAdddedVM GetMonthlyADEdit(string CmpyCode, string PRADN001_CODE)
        {
            var MonthlyEdit = _MonthlyAdddedPayrollRepo.GetMonthlyADEdit(CmpyCode, PRADN001_CODE);

            MonthlyEdit.MonthlyAdddedM = new MonthlyAdddeddet1();
            MonthlyEdit.EmpNameList = GetEmpCodeList(CmpyCode);
            MonthlyEdit.MonthlyAddded = GetMonthlyADGrid(CmpyCode, PRADN001_CODE);
            MonthlyEdit.EditFlag = true;
            return MonthlyEdit;
        }

        public List<MonthlyAdddeddet1> GetMonthlyADGrid(string CmpyCode, string PRADN001_CODE)
        {
            var Bnks = _MonthlyAdddedPayrollRepo.GetMonthlyADGrid(CmpyCode, PRADN001_CODE);

            return Bnks.Select(m => new MonthlyAdddeddet1
            {
                ADN_Act_code=m.ADN_Act_code,
                ADN_Amount=m.ADN_Amount,
                EmpCode=m.EmpCode,
                EmpName=m.EmpName,
                Remarks=m.Remarks,
                T_type=m.T_type,               
            }).ToList();
        }

        public MonthlyAdddedVM SaveMonthlyAD(MonthlyAdddedVM MonthlyAD)
        {
            if (!MonthlyAD.EditFlag)
            {
                MonthlyAD.PRADN001_CODE = _CodeRep.GetCode(MonthlyAD.CmpyCode, "MonthlyAddded");
            }
            return _MonthlyAdddedPayrollRepo.SaveMonthlyAD(MonthlyAD);
        }
    }
}
