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
    public class BankMasterPayrollService : IBankMasterPayrollService
    {
        IBankMasterPayrollRepository _BnkPayrollRepo;
        ICodeGenRepository _codeRep;
        public BankMasterPayrollService()
        {
            _codeRep = new CodeGenRepository();
            _BnkPayrollRepo = new BankMasterPayrollRepository();
        }

        public bool DeleteBnk(string CmpyCode, string PRBM001_code, string UserName)
        {
            return _BnkPayrollRepo.DeleteBnk(CmpyCode, PRBM001_code, UserName);
        }

        public BankMasterVM GetBnkEdit(string CmpyCode, string PRBM001_code)
        {
            var BnkEdit = _BnkPayrollRepo.GetBnkEdit(CmpyCode, PRBM001_code);
            BnkEdit.CountryList = GetCountryCodes(CmpyCode);
            BnkEdit.BranchM = new BankBr();
            BnkEdit.Branch = GetBnkGrid(CmpyCode, PRBM001_code);                   
            BnkEdit.EditFlag = true;
            return BnkEdit;
        }

        public List<BankBr> GetBnkGrid(string CmpyCode, string PRBM001_code)
        {
            var Bnks = _BnkPayrollRepo.GetBnkGrid(CmpyCode, PRBM001_code);

            return Bnks.Select(m => new BankBr
            {               
                PRBM002_code = m.PRBM002_code,
                Bank_branch_name =m.Bank_branch_name,                

            }).ToList();
        }

        public List<BankMasterVM> GetBnkList(string CmpyCode)
        {
            return _BnkPayrollRepo.GetBnkList(CmpyCode).Select(m => new BankMasterVM
            {
               
                prbm001_code = m.PRBM001_code,               
                Bank_name = m.Bank_name,                
                country=m.country,
                                            
            }).ToList();
        }

        public BankMasterVM GetBnkNew(string CmpyCode)
        {
            return new BankMasterVM
            {

                   prbm001_code=_codeRep.GetCode(CmpyCode, "BankMaster") ,
                CountryList = GetCountryCodes(CmpyCode),
                Branch = new List<BankBr>(),
                BranchM = new BankBr(),
                EditFlag = false
            };
        }

        public List<SelectListItem> GetCountryCodes(string CmpyCode)
        {
            var CountryList = _BnkPayrollRepo.GetNationList(CmpyCode)
                                        .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                        .ToList();
            return InsertFirstElementDDL(CountryList);
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
        public BankMasterVM SaveBnk(BankMasterVM Bnk)
        {
            if (!Bnk.EditFlag)
            {
                Bnk.prbm001_code = _codeRep.GetCode(Bnk.CmpyCode, "BankMaster");
            }
            return _BnkPayrollRepo.SaveBnk(Bnk);
        }

        public int UseBnkBranch(string CmpyCode, string PRBM001_code, string PRBM002_code)
        {
            return _BnkPayrollRepo.UseBnkBranch(CmpyCode, PRBM001_code, PRBM002_code);
        }
    }
}
