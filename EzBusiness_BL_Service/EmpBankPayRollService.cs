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
    public class EmpBankPayRollService : IEmpBankPayRollService
    {
        IEmpBankPayRollRepository _bkRepo;

        public EmpBankPayRollService()
        {
            _bkRepo = new EmpBankPayRollRepository();
        }

        public bool DeleteEmpBnk(string CmpyCode, string PRBM003_CODE, string UserName)
        {
            return _bkRepo.DeleteEmpBnk(CmpyCode, PRBM003_CODE, UserName);
        }

        public EmpBankVM GetEmpBankPayRollEdit(string CmpyCode, string PRBM003_CODE)
        {
         var poEdit = _bkRepo.GetEmpBnkEdit(CmpyCode, PRBM003_CODE);
            poEdit.EmpCodeList = GetEmpCodes(CmpyCode,"A");
            poEdit.PRBM001_codeList = GetPRBM001_code(CmpyCode);
            poEdit.PRBM002_codeList = GetPRBM002_code(CmpyCode, poEdit.PRBM001_code);
            poEdit.EditFlag = true;
            return poEdit;
        }

        public EmpBankVM GetEmpBankPayRollNew(string CmpyCode)
        {
            return new EmpBankVM
            {

                EmpCodeList = GetEmpCodes(CmpyCode,"B"),
                PRBM001_codeList=GetPRBM001_code(CmpyCode),
                PRBM002_codeList=GetPRBM002_code(CmpyCode,"0"),                
                EditFlag = false
            };
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
        public List<EmpBankVM> GetEmpBnkList(string CmpyCode)
        {
            return _bkRepo.GetEmpBnkList(CmpyCode).Select(m => new EmpBankVM
            {
                CmpyCode = m.CmpyCode,
                PRBM003_CODE =m.PRBM003_CODE,
                EmpCode= m.EmpCode,
                PRBM001_code=m.PRBM001_code,
                PRBM002_code=m.PRBM002_code,
                Account_no =m.Account_no,
                Entry_Date =m.Entry_Date,
                EBAN_no=m.EBAN_no,
                Remarks =m.Remarks,
                EmpName = m.EmpName
            }).ToList();
        }

        public List<SelectListItem> GetEmpCodes(string CmpyCode, string typ)
        {
            var EmpCodes = _bkRepo.GetEmpCodes(CmpyCode, typ)
                                       .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                       .ToList();
            return InsertFirstElementDDL(EmpCodes);
        }
      

           
        public List<SelectListItem> GetPRBM001_code(string CmpyCode)
        {
            var Cd = _bkRepo.GetPRBM001_code(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.PRBM001_code,Text=string.Concat(m.PRBM001_code,"-",m.Bank_name) })
                                       .ToList();
            return InsertFirstElementDDL(Cd);
        }

        public List<SelectListItem> GetPRBM002_code(string CmpyCode,string PRBM001_code)
        {
            var Cd1 = _bkRepo.GetPRBM002_code(CmpyCode, PRBM001_code)
                                       .Select(m => new SelectListItem { Value = m.PRBM002_code, Text =string.Concat(m.PRBM002_code , "-" , m.Bank_branch_name) })
                                       .ToList();
            return InsertFirstElementDDL(Cd1);
        }

        public EmpBankVM SaveEmpBnk(EmpBankVM EmpBnk)
        {
            return _bkRepo.SaveEmpBnk(EmpBnk);
        }
    }
}
