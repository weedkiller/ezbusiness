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
    public class StateController : Controller
    {
        IStatePayrollService _StService;

        public StateController()
        {
            _StService = new StatePayrollService();

        }

        #region State Master
        [Route("State")]
        public ActionResult StateMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_StService.GetSts(list[0].CmpyCode));
            }
        }

        [Route("Sts")]
        public ActionResult Sts()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_StService.GetSts(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveSts(StateVM Sts)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                Sts.CmpyCode = list[0].CmpyCode;
                return Json(_StService.SaveSts(Sts), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteSts")]
        public ActionResult DeleteSts(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _StService.DeleteSts(Code,list[0].CmpyCode,list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Sts Request


        #endregion
    }
}