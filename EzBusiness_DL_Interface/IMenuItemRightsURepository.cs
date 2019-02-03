using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MenuItem;

namespace EzBusiness_DL_Interface
{
    public interface IMenuItemRightsURepository
    {

        #region MenuRights
        List<MenuItemRUVM> GetUsers(string CmpyCode,string userid);
        MenuItemRUVM SaveUsers(MenuItemRUVM Users);
        List<Employee> GetEmpCodes(string CmpyCode, string typ);    
        List<UserRights> GetUsersRights(string CmpyCode, string username, string typ);

        MenuItemRUVM GetUsersRightsEdit(string CmpyCode, string username);

        bool DeleteUsers(string CmpyCode, string username, string user_name);

        bool GetAuthority(string CmpyCode, string username,string Rpath);


        List<UserRights> GetUsersRightsAuth(string CmpyCode, string navurl, string userid);

        #endregion
    }
}
