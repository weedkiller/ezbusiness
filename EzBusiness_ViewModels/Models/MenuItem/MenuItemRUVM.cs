using EzBusiness_EF_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.MenuItem
{
    public class MenuItemRUVM
    {

        public string CmpyCode { get; set; }
        public string user_name { get; set; }
        public string passwords { get; set; }
        public string EmpCode { get; set; }
        public List<SelectListItem> EmpCodeList { get; set; }
        public string Utype { get; set; }        
        public List<UserRights> UserRightsnews { get; set; }
        public UserRightsnews UserRightsDetail { get; set; }

        public string UserName { get; set; }

        public bool SaveFlag { get; set; }

        public bool EditFlag { get; set; }

        public string ErrorMessage { get; set; }
    }
    public class UserRightsnews
    {
        public string CmpyCode { get; set; }
        public string user_name { get; set; }
        public string FormId { get; set; }
        public string FormName { get; set; }
        public int PostIt { get; set; }
        public string ParentFormId { get; set; }

        public int SelAll { get; set; }
        public int NewIt { get; set; }
        public int ViewIt { get; set; }
        public int EditIt { get; set; }
        public int DeleteIt { get; set; }
    }
}
