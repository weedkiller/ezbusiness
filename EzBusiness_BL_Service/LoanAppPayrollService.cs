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
    public class LoanAppPayrollService : ILoanAppPayrollService
    {

        ILoanAppPayrollRepository _LoanAppRepo;
        ICodeGenRepository _CodeRep;
        public LoanAppPayrollService()
        {
            _LoanAppRepo = new LoanAppPayrollRepository();
            _CodeRep = new CodeGenRepository();
        }
        public bool DeleteLoanApp(string CmpyCode, string PRLA001_CODE, string UserName)
        {
            return _LoanAppRepo.DeleteLoanApp(CmpyCode, PRLA001_CODE, UserName);
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
            var EmpCodes = _LoanAppRepo.GetEmpCodes(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                      .ToList();
            return InsertFirstElementDDL(EmpCodes);
        }

        public LoanAppliationVM GetLoanAppEdit(string CmpyCode, string PRLA001_CODE)
        {
            var poEdit = _LoanAppRepo.GetLoanAppEdit(CmpyCode, PRLA001_CODE);
            poEdit.EmpCodeList = GetEmpCodes(CmpyCode);
            poEdit.LoanTypeList = GetPRLM001(CmpyCode);           
            poEdit.EditFlag = true;
            return poEdit;
        }

        public List<LoanAppliationVM> GetLoanAppList(string CmpyCode)
        {
            return _LoanAppRepo.GetLoanAppList(CmpyCode).Select(m => new LoanAppliationVM
            {
                            
                PRLA001_CODE = m.PRLA001_CODE,
                COUNTRY = m.COUNTRY,                
                EmpCode = m.EmpCode,
                Entry_Date = m.Entry_Date,
                LoanAmount = m.LoanAmount,
                NoOfInstalments = m.NoOfInstalments,
                Instalment = m.Instalment,
                Deduction = m.Deduction,
                Balance = m.Balance,
                Remarks = m.Remarks,
                Status = m.Status,
                AutoDeductionYN = m.AutoDeductionYN,
                DeductionStartDate = m.DeductionStartDate,
                Act_code = m.Act_code,
                LoanType = m.LoanType,
                ApprovalYN = m.ApprovalYN,
                AppliedAmt = m.AppliedAmt,
            }).ToList();
        }

        public LoanAppliationVM GetLoanAppNew(string CmpyCode)
        {
            return new LoanAppliationVM
            {
                PRLA001_CODE = _CodeRep.GetCode(CmpyCode, "LoanAppliation"),
            EmpCodeList = GetEmpCodes(CmpyCode),
                LoanTypeList = GetPRLM001(CmpyCode),               
                EditFlag = false
            };
        }

        public List<SelectListItem> GetPRLM001(string CmpyCode)
        {
            var Cd = _LoanAppRepo.GetPRLM001(CmpyCode)
                                     .Select(m => new SelectListItem { Value = m.PRLM001_CODE, Text = m.PRLM001_CODE + "-" + m.Act_code })
                                     .ToList();
            return InsertFirstElementDDL(Cd);
        }

        public LoanAppliationVM SaveLoanApp(LoanAppliationVM LoanApp)
        {
            if (!LoanApp.EditFlag)
            {
                LoanApp.PRLA001_CODE = _CodeRep.GetCode(LoanApp.CmpyCode, "LoanAppliation");
            }
            return _LoanAppRepo.SaveLoanApp(LoanApp);
        }
    }
}
