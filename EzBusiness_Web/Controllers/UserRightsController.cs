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
    public class UserRightsController : Controller
    {
        // GET: UserRights



        IMenuItemRightsUService _MenuRights;
        IMasterService _masterService;
        ISalaryprocCondService _SalryProCond;
        public UserRightsController()
        {
            _MenuRights = new MenuItemRightsUService();

            _masterService = new MasterService();
            _SalryProCond = new SalaryprocCondService();
        }

        [Route("SalryProCond")]
        public ActionResult CheckSalryProCond(string Empcode,DateTime dtmonthyy)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return  Json(_SalryProCond.GetSalaryProcess(list[0].CmpyCode, Empcode, dtmonthyy), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("AuthCheck")]
        public ActionResult GetEmployeeMasterList1(string rpath1)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                bool t = true;
                if (list[0].Utype == "U")
                {
                    //string rpath1 = (string)this.RouteData.Values["controller"];
                    t = _MenuRights.GetAuthority(list[0].CmpyCode, list[0].user_name, rpath1);
                }
                return Json(new { Urights = t }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("UserRights")]
        public ActionResult UserRightMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View();
            }

            //return View();
        }


        [ChildActionOnly]
        [Route("GetCheckMenu")]
        public ActionResult GetCheckMenu()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
               return PartialView(_masterService.GetTreeData(list[0].CmpyCode));
               
            }

            //return View();
        }

        [ChildActionOnly]
        public ActionResult GetMenuTreeRightF()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //return PartialView(_masterService.GetTreeData(list[0].CmpyCode));

                return PartialView(_masterService.GetTreeData1(list[0].CmpyCode, list[0].user_name, list[0].Utype, "F"));
            }
        }

        [ChildActionOnly]
        public ActionResult GetMenuTreeRightR()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //return PartialView(_masterService.GetTreeData(list[0].CmpyCode));

                return PartialView(_masterService.GetTreeData1(list[0].CmpyCode, list[0].user_name, list[0].Utype, "R"));
            }
        }


        public ActionResult GetUserRightMasterList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_MenuRights.GetUsers(list[0].CmpyCode,list[0].user_name));
            }
        }

        [Route("EditUserRightMaster")]
        public ActionResult EditUserRightMaster(string Username)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_MenuRights.GetUsersRightsEdit(list[0].CmpyCode, Username));
            }
        }

        public ActionResult AddUserRightMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_MenuRights.GetMenuItemRUNew(list[0].CmpyCode));
            }
        }

        [HttpPost]
        [Route("SaveUserRight")]
        public ActionResult SaveUserRight(MenuItemRUVM Users)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Users.CmpyCode = list[0].CmpyCode.ToString();
                Users.UserName = list[0].user_name;               
                return Json(_MenuRights.SaveUsers(Users), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteUserRight")]
        public ActionResult DeleteUserRight(string user_name)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //CmpyCode = list[0].CmpyCode;
                return Json(new { DeleteFlag = _MenuRights.DeleteUsers(list[0].CmpyCode, user_name,list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("GetUserRight")]
        public ActionResult GetUserRight(string user_name,string Utype)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //CmpyCode = list[0].CmpyCode;
                return Json( _MenuRights.GetUsersRights(list[0].CmpyCode, user_name, Utype) , JsonRequestBehavior.AllowGet);
            }
        }



        [Route("GetUserRightAuth")]
        public ActionResult GetUserRightAuth(string navurl)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //CmpyCode = list[0].CmpyCode;
                return Json(_MenuRights.GetUsersRightsAuth(list[0].CmpyCode, navurl, list[0].user_name), JsonRequestBehavior.AllowGet);
            }
        }



        //
    }
}