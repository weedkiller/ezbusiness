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
   public  class ProjectAllotmentService : IProjectAllotmentService
    {
        IProjectAllotmentRepository _ProjectAllotRepo;
        ICodeGenRepository _CodeRep;
        public ProjectAllotmentService()
        {
            _ProjectAllotRepo = new ProjectAllotmentRepository();
            _CodeRep = new CodeGenRepository();
        }

        public ProjectAllotmentVM NewProjectAllotment(string CmpyCode)
        {
            return new ProjectAllotmentVM
            {
                PRPRJE001_code = _CodeRep.GetCode(CmpyCode, "EMPProjectAllotment"),
                EmpCodeList = GetEmpCodes(CmpyCode),
                CCH004_codeList = GetProjectCodes(CmpyCode),             
                EditFlag = false
            };
        }

        public List<ProjectAllotmentVM> GetProjectAllotmentList(string CmpyCode)
        {
            return _ProjectAllotRepo.GetProjectAllotmentList(CmpyCode).Select(m => new ProjectAllotmentVM
            {
                CmpyCode = m.CmpyCode,
                PRPRJE001_code = m.PRPRJE001_code,
                EmpCode = m.EmpCode,
                CCH004_code = m.CCH004_code,
                Effect_From = m.Effect_From,
                Entery_date = m.Entery_date,
                Remarks = m.Remarks,
                

            }).ToList();
        }

        public ProjectAllotmentVM SaveProjectAllotment(ProjectAllotmentVM PrjAlt)
        {
            if (!PrjAlt.EditFlag)
            {
                PrjAlt.PRPRJE001_code = _CodeRep.GetCode(PrjAlt.CmpyCode, "EMPProjectAllotment");
            }

            return _ProjectAllotRepo.SaveProjectAllotment(PrjAlt);
        }

        public ProjectAllotmentVM GetProjectAllotmentEdit(string CmpyCode, string PRPRJE001_code)
        {
            var SftEdit = _ProjectAllotRepo.GetProjectAllotmentEdit(CmpyCode, PRPRJE001_code);
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

        public bool DeleteProjectAllotment(string CmpyCode, string PRPRJE001_code, string UserName)
        {
            return _ProjectAllotRepo.DeleteProjectAllotment(CmpyCode, PRPRJE001_code, UserName);
        }
    }
}
