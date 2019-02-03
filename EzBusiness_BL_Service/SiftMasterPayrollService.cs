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
    public class SiftMasterPayrollService : ISiftMasterPayrollService
    {
        IShiftMasterPayrollRepository _ShiftPayrollRepo;
        ICodeGenRepository _codeRep;
        public SiftMasterPayrollService()
        {
            _ShiftPayrollRepo = new ShiftMasterPayrollRepository();
            _codeRep = new CodeGenRepository();
        }
        public bool DeleteShift(string CmpyCode, string PRSFT001_code, string UserName)
        {
            return _ShiftPayrollRepo.DeleteShift( CmpyCode,PRSFT001_code, UserName);
        }

        public List<SelectListItem> GetCountryCodes(string CmpyCode)
        {
            var CountryList = _ShiftPayrollRepo.GetNationList(CmpyCode)
                                        .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                        .ToList();
           // return CountryList;
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

        

        public ShiftMasterVM GetShiftEdit(string CmpyCode, string PRSFT001_code)
        {
            var SftEdit = _ShiftPayrollRepo.GetShiftEdit(CmpyCode, PRSFT001_code);
            SftEdit.CountryList = GetCountryCodes(CmpyCode);
            SftEdit.ShiftM = new ShiftAllocationH();
            SftEdit.Shift = GetShiftGrid(CmpyCode, PRSFT001_code);
            SftEdit.EditFlag = true;
            return SftEdit;
        }

        public List<ShiftAllocationH> GetShiftGrid(string CmpyCode, string PRSFT002_code)
        {
            var Shft = _ShiftPayrollRepo.GetShiftGrid(CmpyCode, PRSFT002_code);

            return Shft.Select(m => new ShiftAllocationH()
            {
                PRSFT001_code = m.PRSFT001_code,
                PRSFT002_code = m.PRSFT002_code,
                division = m.division,
                CmpyCode = m.CmpyCode,
                Effect_Date = m.Effect_Date,
                Enttry_Date = m.Enttry_Date,
                ApprovalYN = m.ApprovalYN,

            }).ToList();

        }

        public List<ShiftMasterVM> GetShiftList(string CmpyCode)
        {
            return _ShiftPayrollRepo.GetShiftList(CmpyCode).Select(m => new ShiftMasterVM
            {
                CmpyCode = m.CmpyCode,
                PRSFT001_code = m.PRSFT001_code,
                country = m.country,
                ShiftName = m.ShiftName,
                division = m.division,
                StTime=m.StTime,
                EdTime=m.EdTime,
                
            }).ToList();

        }

        public ShiftMasterVM NewShift(string CmpyCode)
        {
            return new ShiftMasterVM
            {
                PRSFT001_code= _codeRep.GetCode(CmpyCode, "ShiftMaster"),
                Shift = new List<ShiftAllocationH>(),
                ShiftM = new ShiftAllocationH(),
                CountryList = GetCountryCodes(CmpyCode),
                EditFlag = false
            };
        }

        public ShiftMasterVM SaveShift(ShiftMasterVM Sft)
        {
            if (!Sft.EditFlag)
            {
                Sft.PRSFT001_code = _codeRep.GetCode(Sft.CmpyCode, "ShiftMaster");
            }
            return _ShiftPayrollRepo.SaveShift(Sft);
        }

        public int UseShiftAlloc(string CmpyCode, string PRSFT001_code, string PRSFT002_code)
        {
            return _ShiftPayrollRepo.UseShiftAlloc(CmpyCode, PRSFT001_code, PRSFT002_code);
        }
    }
}
