using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MenuItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EzBusiness_Web.HtmlHelpers;


namespace EzBusiness_Web.Controllers
{
    public class MDIController : Controller
    {
        IMasterService _masterService;

        public MDIController()
        {
            _masterService = new MasterService();
        }
        //public MDIController(IMasterService masterService)
        //{
        //    _masterService = masterService;
        //}

        public ActionResult Test()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult GetMenuTree()
        {

            //IList<MenuItemsVM> topLevelMenus = TreeHelper.ConvertToForest(service.GetTreeData());
            //Response.Write(@"<ul  class='nav' id='side-menu'>");
            //foreach (var topLevelMenu in topLevelMenus)
            //{
            //    RenderMenu(topLevelMenu);
            //}
            //Response.Write("</ul>");
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //return PartialView(_masterService.GetTreeData(list[0].CmpyCode));
                
                return PartialView(_masterService.GetTreeData1(list[0].CmpyCode,list[0].user_name,list[0].Utype, "A"));  //all Menu -A
            }
        }

        [HttpGet]
        public ActionResult MDIForm()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                var formsList = MDIHelper.FormsDDLList(list[0].CmpyCode);
                return View(new MenuItemsVM
                {
                    ParentFormList = formsList,
                    MetaDataSettings = _masterService.GetMetaSettings()
                });
            }
        }

        [Route("MenuItem")]
        public ActionResult EditMDIForm()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                ViewBag.formsList = MDIHelper.FormsDDLListWithParentFormValue(list[0].CmpyCode);
                return View();
            }
        }


        public ActionResult EditMDIFormPartial(string formId, string parentFormId)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_masterService.GetFormDetails(list[0].CmpyCode, formId, parentFormId));
            }
        }


        public string GetParentFromName(string CmpyCode, string ParentFormId)
        {
            return _masterService.GetParentFormName(CmpyCode, ParentFormId);
        }

        //[HttpPost]
        [HttpGet]
        public ActionResult MDIForm(FormCollection formCollection, MenuItemsVM menuItemsVM)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                if (ModelState.IsValid)
                {

                    var metaSettings = GetMetaSettings(formCollection["hdnMetaSettings"]);
                    menuItemsVM.MenuItemSettings = metaSettings;
                    menuItemsVM.CmpyCode = list[0].CmpyCode;
                    if (menuItemsVM.EditMode)
                    {
                        var result = _masterService.EditFrom(menuItemsVM);
                    }
                    else
                    {
                        var result = _masterService.AddFrom(menuItemsVM);
                    }
                }


                ModelState.Clear();


                var formsList = MDIHelper.FormsDDLList(list[0].CmpyCode);
                return View("MDIForm", new MenuItemsVM
                {
                    ParentFormList = formsList,
                    MetaDataSettings = _masterService.GetMetaSettings()
                });
            }
        }

        private Dictionary<string, string> GetMetaSettings(string metaSettings)
        {
            var metaSettingDetailsDict = new Dictionary<string, string>();
            var mtSett = metaSettings.Split('&');
            foreach (var item in mtSett)
            {
                if (item.Length > 0)
                {
                    var mtPairs = item.Split(',');
                    metaSettingDetailsDict.Add(mtPairs.ElementAt(0), mtPairs.ElementAt(1));
                }
            }
            return metaSettingDetailsDict;
        }
        
       

    }
}