using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;
using EzBusiness_ViewModels;


namespace EzBusiness_BL_Service
{
    public class LvSettlePayrollService : ILvSettlePayrollService
    {
        ILvSettlePayrollRepository _LvPayrollRepo;
        ICodeGenRepository _CodeRep;

        public LvSettlePayrollService()
        {
            _LvPayrollRepo = new LvSettlePayrollRepository();
            _CodeRep = new CodeGenRepository();
        }

        public bool DeleteLiv(string CmpyCode, string PRLS001_CODE, string UserName)
        {
            return _LvPayrollRepo.DeleteLiv(CmpyCode, PRLS001_CODE, UserName);
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


        public List<SelectListItem> GetEmpCodes(string CmpyCode)
        {       
            var itemCodes = _LvPayrollRepo.GetEmpCodes(CmpyCode)
                                        .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                        .ToList();

            return InsertFirstElementDDL(itemCodes);        
        }

        public List<SelectListItem> GetLeaveCodes(string CmpyCode, string typ)
        {
            var itemCodes = _LvPayrollRepo.GetLeaveCodes(CmpyCode,typ)
                                        .Select(m => new SelectListItem { Value = m.PRLR001_CODE, Text = m.PRLR001_CODE +"-" +m.EmpCode })
                                        .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<LeaveSettlementnew> GetLeaveDetails(string CmpyCode, string PRLR001_CODE, DateTime lvsdte)
        {
            var poLeaveAppList = _LvPayrollRepo.GetLeaveDetails(CmpyCode, PRLR001_CODE, lvsdte);
            return poLeaveAppList.Select(m => new LeaveSettlementnew
            {

                LLSdate = m.LLSdate,
                LendDate = m.LendDate,
                Empcode = m.Empcode,
                JoiningDate = m.JoiningDate,
                DR_Date = m.DR_Date,
                Total_worked_Days =m.Total_worked_Days,
                Total_days = m.Total_days,
                Total_LE_Days = m.Total_LE_Days,
                Sanctioned_Days = m.Sanctioned_Days,
                salary_effect_date = m.salary_effect_date,
                Actual_Salary = m.Actual_Salary,
                LB_CF_Days = m.LB_CF_Days,
                Leave_Salary=m.Leave_Salary,
                // StartDate =m.StartDate,
                //EndDate = m.EndDate,
                //EmpCode =m.EmpCode,
                //JoiningDate = m.JoiningDate,
                //ResumeDate = m.ResumeDate,
                //TotalBalance = m.TotalBalance,
                //TotalSanctioned = m.TotalSanctioned,
                //LeaveDays=m.LeaveDays,

            }).ToList();
        }

        public List<LeaveSettlementVM> GetLivlist(string CmpyCode)
        {
            var poEmployeeList = _LvPayrollRepo.GetLivlist(CmpyCode);
            return poEmployeeList.Select(m => new LeaveSettlementVM
            {
               Empcode=m.Empcode,
               PRLS001_CODE=m.PRLS001_CODE,
               LLSdate=m.LLSdate,
               Entry_Date=m.Entry_Date
            }).ToList();
        }

        public LeaveSettlementVM GetLivlistEdit(string CmpyCode, string PRLS001_COD)
        {
            var poEdit = _LvPayrollRepo.GetLivlistEdit(CmpyCode, PRLS001_COD);
            poEdit.EmpCodeList = GetEmpCodes(CmpyCode);
            poEdit.LeaveList = GetLeaveCodes(CmpyCode, "Etyp");
            poEdit.JoiningDate = _LvPayrollRepo.GetJoiningdate(CmpyCode, poEdit.Empcode);
            poEdit.EditFlag = true;
            return poEdit;
        }

        public LeaveSettlementVM SaveLiv(LeaveSettlementVM Liv)
        {
            if (!Liv.EditFlag)
            {
                Liv.PRLS001_CODE = _CodeRep.GetCode(Liv.CMPYCODE, "LeaveSettlement");
            }

            Liv.COUNTRY = _CodeRep.GetCountry(Liv.CMPYCODE, Liv.Empcode);
            Liv.DIVISION = _CodeRep.GetDiv(Liv.CMPYCODE, Liv.Empcode);

            return _LvPayrollRepo.SaveLiv(Liv);
        }

        public LeaveSettlementVM GetLeaveSettlementNew(string CmpyCode)
        {
            return new LeaveSettlementVM
            {
                PRLS001_CODE=_CodeRep.GetCode(CmpyCode, "LeaveSettlement"),
                EmpCodeList = GetEmpCodes(CmpyCode),
                LeaveList = GetLeaveCodes(CmpyCode, "Etyp1"),
                Ticket_Paid="Paid",
                EditFlag = false
            };
        }
    }
}
