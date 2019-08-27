using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Login;
using System.Web.Mvc;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service
{
    public class LoginService : ILoginService

    {

        ILoginRepository _LoginRepo;

        public LoginService()
        {
            _LoginRepo = new LoginRepository();
            
        }
        public List<SelectListItem> GetCompanyList()
        {
            var CompanyList = _LoginRepo.GetCompanyList()
                                    .Select(m => new SelectListItem { Value = m.CmpyCode, Text = string.Concat(m.CmpyCode, " - ", m.Name) })
                                    .ToList();
            return CompanyList;
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

        public List<SelectListItem> GetDepartmentList(string CmpyCode, string DivCode, string BranchCode)
        {
            var DepartmentList = _LoginRepo.GetDepartmentList(CmpyCode, DivCode, BranchCode)
                                     .Select(m => new SelectListItem { Value = m.DepartmentCode, Text = string.Concat(m.DepartmentCode, " - ", m.DepartmentName) })
                                     .ToList();
            return DepartmentList;
        }

        public List<SelectListItem> GetDivisionList(string CmpyCode)
        {
            var DivisionList = _LoginRepo.GetDivisionList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.DivisionCode, Text = string.Concat(m.DivisionCode, " - ", m.DivisionName) })
                                      .ToList();
            return DivisionList;
        }

        public LoginVM SaveLons(LoginVM LoginVM)
        {
            return _LoginRepo.Login(LoginVM);
        }

        public List<SelectListItem> GetBranchList(string CmpyCode, string DivCode)
        {
            var BranchList = _LoginRepo.GetBranchList(CmpyCode, DivCode)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                      .ToList();
            return BranchList;
        }

        public List<SelectListItem> GetBranchListN(string CmpyCode)
        {
            var BranchList = _LoginRepo.GetBranchListN(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                      .ToList();
            return BranchList;
        }

        public string Divisioncode(string CmpyCode, string BranchCode)
        {
            return _LoginRepo.Divisioncode(CmpyCode, BranchCode).ToString();
                                      
            
        }

        public List<SelectListItem> GetDivisionCurrency(string CmpyCode, string BranchCode)
        {
            var BranchList = _LoginRepo.GetDivisionCurrency(CmpyCode,BranchCode)
                                      .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
                                      .ToList();
            return BranchList;
        }
    }
}
