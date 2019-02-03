using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity.MenuContext;
using EzBusiness_ViewModels.Models.MenuItem;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
    public interface IMasterService
    {
        IList<MenuItemsVM> GetTreeData(string CmpyCode);

        IList<MenuItemsVM> GetTreeData1(string CmpyCode, string user_name, string Urole, string RepYN);

        List<SelectListItem> FormsDDLList(string CmpyCode);

        List<SelectListItem> FormsDDLListWithParentValue(string CmpyCode);

        List<SelectListItem> GetMetaSettings();

        string GetParentFormName(string CmpyCode, string ParentFormId);

        MenuItemsVM GetFormDetails(string CmpyCode, string FormId, string parentFormId);

        MenuItemsVM AddFrom(MenuItemsVM menuItem);
        MenuItemsVM EditFrom(MenuItemsVM menuItem);


        List<SelectListItem> GetEmpCodes(string CmpyCode, string typ);
    }
}
