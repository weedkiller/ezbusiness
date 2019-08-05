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
    public class EmpShiftPayrollService : IEmpShiftPayrollService
    {
        IEmpShiftPayrollRepository _EmpShiftRepo;
        ICodeGenRepository _CodeRep;
        public EmpShiftPayrollService()
        {
            _EmpShiftRepo = new EmpShiftPayrollRepository();
            _CodeRep = new CodeGenRepository();
        }
        public bool DeleteEmpShift(string CmpyCode, string PRSFT003_code, string UserName)
        {
            return _EmpShiftRepo.DeleteEmpShift(CmpyCode, PRSFT003_code, UserName);
        }

        public List<SelectListItem> GetEmpCodes(string CmpyCode)
        {
            var EmpList = _EmpShiftRepo.GetEmpCodes(CmpyCode)
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


        public EmpShiftVM GetEmpShiftEdit(string CmpyCode, string PRSFT003_code)
        {
            var SftEdit = _EmpShiftRepo.GetEmpShiftEdit(CmpyCode, PRSFT003_code);
           // SftEdit.EmpCodeList = GetEmpCodes(CmpyCode);
          //  SftEdit.ShiftCode = GetShiftCodes(CmpyCode);
           // SftEdit.ShiftCodeAlloc = GetShiftAllocCode(CmpyCode, SftEdit.PRSFT001_code);
           
            SftEdit.EditFlag = true;
            return SftEdit;
        }

        public List<EmpShiftVM> GetEmpShiftList(string CmpyCode)
        {
            return _EmpShiftRepo.GetEmpShiftList(CmpyCode).Select(m => new EmpShiftVM
            {
                //CmpyCode = m.CmpyCode,
                //PRSFT001_code = m.PRSFT001_code,
                EmpCode = m.EmpCode,
                PRSFT002_code = m.PRSFT002_code,
                PRSFT003_code = m.PRSFT003_code,
                //SNO = m.SNO,
                //Remarks=m.Remarks,
                Empname=m.Empname,
                ShiftName=m.ShiftName

                
            }).ToList();
        }

        public List<SelectListItem> GetShiftAllocCode(string CmpyCode, string PRSFT001_code,string Prefix)
        {
            var Cd1 = _EmpShiftRepo.GetShiftAllocCode1(CmpyCode, PRSFT001_code, Prefix)
                                      .Select(m => new SelectListItem { Value = m.Code, Text =m.Code+"-"+m.CodeName  })
                                      .ToList();
            return Cd1;
        }

        public List<SelectListItem> GetShiftCodes(string CmpyCode,string Prefix)
        {
            var Cd = _EmpShiftRepo.GetShiftCodes1(CmpyCode,Prefix)
                                      .Select(m => new SelectListItem { Value = m.Code, Text =m.CodeName })
                                      .ToList();
            return Cd;
        }

        public EmpShiftVM NewEmpShift(string CmpyCode)
        {

            return new EmpShiftVM
            {
                PRSFT003_code=_CodeRep.GetCode(CmpyCode,"EMPShiftMaster"),
              //  EmpCodeList = GetEmpCodes(CmpyCode),
              //  ShiftCode = GetShiftCodes(CmpyCode),
               // ShiftCodeAlloc = GetShiftAllocCode(CmpyCode, "0"),              
                EditFlag = false
            };
        }

        public EmpShiftVM SaveEmpShift(EmpShiftVM Sft)
        {
            if (!Sft.EditFlag)
            {
                Sft.PRSFT003_code= _CodeRep.GetCode(Sft.CmpyCode, "EMPShiftMaster");
            }
           
            return _EmpShiftRepo.SaveEmpShift(Sft);
        }
    }
}
