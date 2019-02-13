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
    public class SalaryMpayrollService : ISalaryMpayrollService
    {
        ISalaryMpayrollRepository _SalzPayrollRepo;
        ICodeGenRepository _codeRep;
        public SalaryMpayrollService()
        {
            _SalzPayrollRepo = new SalaryMpayrollRepository();
            _codeRep = new CodeGenRepository();
        }

        public bool DeleteSry(string CMPYCODE, string PRSM001_CODE, string UserName)
        {
            return _SalzPayrollRepo.DeleteSry(CMPYCODE, PRSM001_CODE, UserName);
        }

        //public List<SelectListItem> GetAccountCodes(string CmpyCode)
        //{
        //    var Acs = _SalzPayrollRepo.GetAccountCodes(CmpyCode)
        //                               .Select(m => new SelectListItem { Value = m.Accountcode, Text = m.Accountcode })
        //                               .ToList();

        //    return InsertFirstElementDDL(Acs);
        //}

        public List<SelectListItem> GetEmpCodes(string CMPYCODE)
        {

            var EmpList = _SalzPayrollRepo.GetEmpCodes(CMPYCODE)
                                        .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                        .ToList();
            return InsertFirstElementDDL(EmpList);
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

        public SalarMpayrollVM GetSalaryEdit(string CMPYCODE, string PRSM001_CODE)
        {
            var SalaryEdit = _SalzPayrollRepo.GetSalaryEdit(CMPYCODE, PRSM001_CODE);
            SalaryEdit.EmpCodeList = GetEmpCodes(CMPYCODE);

            SalaryEdit.SalaryMas = GetSalGrid(CMPYCODE);

            SalaryEdit.SMEarning = new SalaryGrid();


            SalaryEdit.EditFlag = true;
            return SalaryEdit;
        }

        public SalarMpayrollVM GetSalaryNew(string CMPYCODE, string PRSM001_CODE)
        {
            return new SalarMpayrollVM
            {

                SalaryMas = new List<SalaryGrid>(),
                SMEarning = new SalaryGrid(),                
                EmpCodeList = GetEmpCodes(CMPYCODE),
                PRSM001_CODE= _codeRep.GetCode(CMPYCODE, "Salary Master"),
                EditFlag = false
            };
        }

        public List<SalaryGrid> GetSalGrid(string CmpyCode)
        {
            var Sal = _SalzPayrollRepo.GetSalGrid(CmpyCode);

            return Sal.Select(m => new SalaryGrid
            {
                Code = m.Code,
                Name = m.Name,
                Accountcode = m.Accountcode,
                //Amount = m.Amount,                

            }).ToList();
        }

        public List<SalarMpayrollVM> GetSryList(string CMPYCODE)
        {
            return _SalzPayrollRepo.GetSryList(CMPYCODE).Select(m => new SalarMpayrollVM
            {
                //PRSM001UID = m.PRSM001UID,
                PRSM001_CODE = m.PRSM001_CODE,
                CMPYCODE = m.CMPYCODE,
                DIVISION = m.DIVISION,
                COUNTRY = m.COUNTRY,
                EMPCODE = m.EMPCODE,
                Entery_date = m.Entery_date,
                Effect_From = m.Effect_From,
                BASIC = m.BASIC,
                BASICCAPTION = m.BASICCAPTION,
                BASICACT = m.BASICACT,
                HRA = m.HRA,
                HRACAPTION = m.HRACAPTION,
                HRAACT = m.HRAACT,
                DA = m.DA,
                DACAPTION = m.DACAPTION,
                DAACT = m.DAACT,
                TELE = m.TELE,
                TELECAPTION = m.TELECAPTION,
                TELEACT = m.TELEACT,
                TRANS = m.TRANS,
                TRANSCAPTION = m.TRANSCAPTION,
                TRANSACT = m.TRANSACT,
                CAR = m.CAR,
                CARCAPTION = m.CARCAPTION,
                CARACT = m.CARACT,
                ALLOWANCE1 = m.ALLOWANCE1,
                ALLOWANCE1CAPTION = m.ALLOWANCE1CAPTION,
                ALLOWANCE1ACT = m.ALLOWANCE1ACT,
                ALLOWANCE2 = m.ALLOWANCE2,
                ALLOWANCE2CAPTION = m.ALLOWANCE2CAPTION,
                ALLOWANCE2ACT = m.ALLOWANCE2ACT,
                ALLOWANCE3 = m.ALLOWANCE3,
                ALLOWANCE3CAPTION = m.ALLOWANCE3CAPTION,
                ALLOWANCE3ACT = m.ALLOWANCE3ACT,
                TOTAL = m.TOTAL,


            }).ToList();
        }

        public SalarMpayrollVM SaveSry(SalarMpayrollVM Sry)
        {
            if (!Sry.EditFlag)
            {
                Sry.PRSM001_CODE = _codeRep.GetCode(Sry.CMPYCODE, "Salary Master");
            }
            return _SalzPayrollRepo.SaveSry(Sry);
        }
    }
}
