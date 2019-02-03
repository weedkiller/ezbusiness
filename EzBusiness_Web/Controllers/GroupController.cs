using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers
{


    public class GroupController : Controller
    {
        IGroupPayrollService _GrService;

        public GroupController()
        {
            _GrService = new GroupPayrollService();

        }

        #region Group Master
        [Route("Group")]
        public ActionResult GroupMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_GrService.GetGrs(list[0].CmpyCode));
            }
        }

        [Route("Grs")]
        public ActionResult Grs()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_GrService.GetGrs(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveGrs(GroupVM  Grs)
        {
          
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Grs.CmpyCode = list[0].CmpyCode;
                Grs.UserName = list[0].user_name;
                return Json(_GrService.SaveGrs(Grs), JsonRequestBehavior.AllowGet);

            }

        }

        [Route("DeleteGrs")]
        public ActionResult DeleteGrs(string DivisionCode, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _GrService.DeleteGrs(DivisionCode, CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Grs Request


        #endregion
    }
}