using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MenuItem;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
    public interface IMenuItemRightsUService
    {

        #region MenuRights
        List<MenuItemRUVM> GetUsers(string CmpyCode, string userid);
        MenuItemRUVM SaveUsers(MenuItemRUVM Users);
        List<SelectListItem> GetEmpCodes(string CmpyCode, string typ);
        List<UserRights> GetUsersRights(string CmpyCode, string username, string typ);
        bool DeleteUsers(string CmpyCode, string username,string user_name);

        MenuItemRUVM GetUsersRightsEdit(string CmpyCode, string username);

        MenuItemRUVM GetMenuItemRUNew(string CmpyCode);

        bool GetAuthority(string CmpyCode, string username, string Rpath);

        List<UserRights> GetUsersRightsAuth(string CmpyCode, string navurl, string userid);

        #endregion
    }
}
