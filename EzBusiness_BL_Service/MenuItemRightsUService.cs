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
using EzBusiness_ViewModels.Models.MenuItem;

namespace EzBusiness_BL_Service
{
   public class MenuItemRightsUService : IMenuItemRightsUService
    {
        IMenuItemRightsURepository _MenuPayrollRepo;
        public MenuItemRightsUService()
        {
            _MenuPayrollRepo = new MenuItemRightsURepository();
        }

        public bool DeleteUsers(string CmpyCode, string username,string user_name)
        {
            return _MenuPayrollRepo.DeleteUsers(CmpyCode, username, user_name);
        }

        public List<SelectListItem> GetEmpCodes(string CmpyCode, string typ)
        {
            var EmpCodes = _MenuPayrollRepo.GetEmpCodes(CmpyCode,typ)
                                       .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                       .ToList();
            return InsertFirstElementDDL(EmpCodes);
        }

        public MenuItemRUVM GetUsersRightsEdit(string CmpyCode, string username)
        {
            var poEdit = _MenuPayrollRepo.GetUsersRightsEdit(CmpyCode, username);
            poEdit.EmpCodeList = GetEmpCodes(CmpyCode, "U");
          //  poEdit.UserRightsnews = GetUsersRights(CmpyCode, username, "U");       
            poEdit.EditFlag = true;
            return poEdit;
        }

        public MenuItemRUVM GetMenuItemRUNew(string CmpyCode)
        {
            return new MenuItemRUVM
            {
                EmpCodeList = GetEmpCodes(CmpyCode,"UR"),
               // UserRightsnews = GetUsersRights(CmpyCode, "", "N"),
               
            EditFlag = false
            };
        }

        public List<MenuItemRUVM> GetUsers(string CmpyCode, string userid)
        {         
            var poUserList = _MenuPayrollRepo.GetUsers(CmpyCode,userid);
            return poUserList.Select(m => new MenuItemRUVM
            {
                EmpCode = m.EmpCode,
                user_name = m.user_name,
                Utype=m.Utype
            }).ToList();
        }

        public List<UserRights> GetUsersRights(string CmpyCode, string username, string typ)
        {
            return _MenuPayrollRepo.GetUsersRights(CmpyCode, username, typ).Select(m => new UserRights
            {

                FormId = m.FormId,
                FormName = m.FormName,
                SelAll = m.SelAll,
                NewIt = m.NewIt,
                ViewIt = m.ViewIt,
                EditIt = m.EditIt,
                DeleteIt = m.DeleteIt,
                PrintIt = m.PrintIt,
                Froms = m.Froms,
                PostIt = m.PostIt,
                // ParentFormId = m.ParentFormId,

            }).ToList();
        }

        public MenuItemRUVM SaveUsers(MenuItemRUVM Users)
        {
            return _MenuPayrollRepo.SaveUsers(Users);
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

        public bool GetAuthority(string CmpyCode, string username, string Rpath)
        {
            return _MenuPayrollRepo.GetAuthority(CmpyCode, username, Rpath);
        }

        public List<UserRights> GetUsersRightsAuth(string CmpyCode, string navurl, string userid)
        {
            return _MenuPayrollRepo.GetUsersRightsAuth(CmpyCode, navurl, userid).Select(m => new UserRights
            {              
                SelAll = m.SelAll,
                NewIt=m.NewIt,
                ViewIt=m.ViewIt,
                EditIt=m.EditIt,
                DeleteIt=m.DeleteIt,
                PrintIt=m.PrintIt,
                Froms=m.Froms,
                PostIt=m.PostIt,
                user_name=m.user_name
            }).ToList();
        }
    }
}
