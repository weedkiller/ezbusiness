using EzBusiness_EF_Entity.MenuContext;
using EzBusiness_Web.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_ViewModels.Models.MenuItem
{
    public class MenuItemsVM : ITreeNode<MenuItemsVM>
    {
        public string Id
        {
            get { return this.FormID; }
        }

        public MenuItemsVM Parent { get; set; }

        public IList<MenuItemsVM> Children { get; set; }


        public string FormID { get; set; }

        public string FormName { get; set; }

        public string UnicodeName { get; set; }

        public string ParentFormID { get; set; }

        public string ParentFormName { get; set; }

        public List<SelectListItem> ParentFormList { get; set; }

        public int Sno { get; set; }

        public string frmName { get; set; }

        public bool CheckRight { get; set; }

        public bool Show { get; set; }

        public bool Report { get; set; }

        public string ShowType { get; set; }

        public int Levels { get; set; }

        public string TableName { get; set; }

        public string Fields { get; set; }

        public string Captions { get; set; }

        public string FunctionName { get; set; }

        public bool ModalForm { get; set; }

        public bool NotForUser { get; set; }

        public string AllMasterQuery { get; set; }

        public int UserDefined { get; set; }

        public string ManualCode { get; set; }

        public string CmpyCode { get; set; }

        public List<SelectListItem> MetaDataSettings { get; set; }

        public Dictionary<string, string> MenuItemSettings { get; set; }

        public bool EditMode { get; set; }

        public Dictionary<string, string> SelectedMetaDataSettings { get; set; }

        public string NavURL { get; set; }

        public string EmpCode { get; set; }

        public List<SelectListItem> EmpCodeList { get; set; }


        //---new userRights     
        public int SelAll { get; set; }
        public int NewIt { get; set; }
        public int ViewIt { get; set; }
        public int EditIt { get; set; }
        public int DeleteIt { get; set; }

    }
}
