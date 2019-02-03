using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.MenuContext;
using EzBusiness_ViewModels.Models.MenuItem;
using EzBusiness_EF_Entity;

namespace EzBusiness_DL_Interface
{
    public interface IMasterRepository
    {
        List<MenuItem> GetMenuData(string CmpyCode);

        List<MenuItem> GetMenuData1(string CmpyCode, string user_name, string Urole, string RepYN);


        

        List<MenuItem> FormsDDLList(string CmpyCode);

        List<string> GetMetaSettings();

        MenuItem GetFormDetails(string CmpyCode, string FormId, string parentFormId);

        Dictionary<string, string> GetSelectedMetaSettings(string CmpyCode, string FormId);

        MenuItemsVM AddFrom(MenuItemsVM menuItem);

        MenuItemsVM EditFrom(MenuItemsVM menuItem);


        List<Employee> GetEmpCodes(string CmpyCode, string typ);

    }
}
