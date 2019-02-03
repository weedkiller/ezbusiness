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
    public class StatusController : Controller
    {
        IStatusPayrollService _StatService;

        public StatusController()
        {
            _StatService = new StatusPayrollService();

        }

        #region Status Master
        [Route("StatusMaster")]
        public ActionResult StatusMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_StatService.GetStats(list[0].CmpyCode));
            }
        }

        [Route("Stats")]
        public ActionResult Stats()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_StatService.GetStats(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveStats(StatusVM StatustMaster)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                StatustMaster.CmpyCode = list[0].CmpyCode;
                return Json(_StatService.SaveStats(StatustMaster), JsonRequestBehavior.AllowGet);
                
            }
        }

        [Route("DeleteStats")]
        public ActionResult DeleteStats(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //CmpyCode = list[0].CmpyCode;
                return Json(new { DeleteFlag = _StatService.DeleteStats(Code,list[0].CmpyCode,list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Stats Request


        #endregion
    }
}