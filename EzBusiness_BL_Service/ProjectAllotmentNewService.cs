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
   public  class ProjectAllotmentNewService : IProjectAllotmentNewService
    {
        IProjectAllotmentNewRepository _ProjectAllotRepo;
        ICodeGenRepository _CodeRep;
        public ProjectAllotmentNewService()
        {
            _ProjectAllotRepo = new ProjectAllotmentNewRepository();
            _CodeRep = new CodeGenRepository();
        }

        public List<PRPJXDTDVM> GetProjectAllotmentList(string CmpyCode)
        {
            return _ProjectAllotRepo.GetProjectAllotmentList(CmpyCode).Select(m => new PRPJXDTDVM
            {
                cmpycode = m.cmpycode,
               empcode=m.empcode,
               Dates=m.Dates,
               Project_code=m.Project_code,
               TimeIn=m.TimeIn,
               TimeOut=m.TimeOut,
               PRPJXDTD001_UID=m.PRPJXDTD001_UID
            }).ToList();
        }

        public PRPJXDTDVM SaveProjectAllotment(PRPJXDTDVM PrjAlt)
        {
            //if (!PrjAlt.EditFlag)
            //{
            //    PrjAlt.PRPRJE001_code = _CodeRep.GetCode(PrjAlt.CmpyCode, "EMPProjectAllotment");
            //}

            return _ProjectAllotRepo.SaveProjectAllotment(PrjAlt);
        }

        public PRPJXDTDVM GetProjectAllotmentEdit(string CmpyCode, string PRPJXDTD001_UID)
        {
            var SftEdit = _ProjectAllotRepo.GetProjectAllotmentEdit(CmpyCode, PRPJXDTD001_UID);
            SftEdit.EmpCodeList = GetEmpCodes(CmpyCode);
            SftEdit.CCH004_codeList = GetProjectCodes(CmpyCode);
            SftEdit.EditFlag = true;
            return SftEdit;
        }

        public List<SelectListItem> GetEmpCodes(string CmpyCode)
        {
            var EmpList = _ProjectAllotRepo.GetEmpCodes(CmpyCode)
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

        public List<SelectListItem> GetProjectCodes(string CmpyCode)
        {
            var EmpList = _ProjectAllotRepo.GetProjectCodes(CmpyCode)
                                     .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                     .ToList();
            return InsertFirstElementDDL(EmpList);
        }

        public bool DeleteProjectAllotment(string CmpyCode, string PRPJXDTD001_UID, string UserName)
        {
            return _ProjectAllotRepo.DeleteProjectAllotment(CmpyCode, PRPJXDTD001_UID, UserName);
        }

        public PRPJXDTDVM NewProjectAllotmentN(string CmpyCode)
        {
            return new PRPJXDTDVM
            {                
                EmpCodeList = GetEmpCodes(CmpyCode),
                CCH004_codeList = GetProjectCodes(CmpyCode),
                EditFlag = false
            };
        }
    }
}
