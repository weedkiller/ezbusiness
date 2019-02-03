using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Service
{
    public class DepartmentPayrollService : IDepartmentPayrollService
    {
        IDepartmentPayrollRepository _DepRepo;

        public DepartmentPayrollService()
        {
            _DepRepo = new DepartmentPayrollRepository();
        }

        public bool DeleteDeps(string DepartmentCode, string CmpyCode, string UserName)
        {
            return _DepRepo.DeleteDeps(DepartmentCode, CmpyCode, UserName);
        }

        public List<DepartmentVM> GetDeps(string CmpyCode)
        {
            return _DepRepo.GetDeps(CmpyCode).Select(m => new DepartmentVM
            {
                CmpyCode = m.Cmpycode,
                DepartmentCode = m.DepartmentCode,
                DepartmentName = m.DepartmentName,
                DivisionCode=m.DivisionCode,
                BranchCode=m.BranchCode,
               // UniCodeName = m.UniCodeName

            }).ToList();
        }

        public List<Division> GetDivisionList(string CmpyCode)
        {
           
            var Division = _DepRepo.GetDivisionList(CmpyCode);
            Division.Insert(0, new Division { DivisionCode = "", DivisionName = "-Select Division Code-" });
            return Division;
        }
        public List<SelectListItem> GetBranchCode(string CmpyCode, string Divcode)
        {
            var BranchList =_DepRepo.GetBranchCode(CmpyCode, Divcode)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                      .ToList();
            return BranchList;
        }
        public DepartmentVM SaveDeps(DepartmentVM Deps)
        {
            return _DepRepo.SaveDeps(Deps);
        }
        public List<SelectListItem> GetDepartmentList(string CmpyCode, string DivCode, string BranchCode)
        {
            var DepartmentList = _DepRepo.GetDepartmentList(CmpyCode, DivCode, BranchCode)
                                     .Select(m => new SelectListItem { Value = m.DepartmentCode, Text = string.Concat(m.DepartmentCode, " - ", m.DepartmentName) })
                                     .ToList();
            return DepartmentList;
        }

      
    }
}
