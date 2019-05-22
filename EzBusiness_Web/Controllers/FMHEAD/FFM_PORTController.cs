using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FMHEAD
{
    public class FFM_PORTController : Controller
    {
        // GET: FFM_PORT
        IFFM_PORTService _fpService;

        public FFM_PORTController()
        {
            _fpService = new FFM_PORTService();
        }

        #region PORT Master
        [Route("PORTMASTER")]
        public ActionResult FFM_PORT(string CmpyCode)
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
        }
        public ActionResult GetPortList(string CmpyCode)

        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_fpService.GetFFM_PORT(list[0].CmpyCode));
            }
        }
        [Route("EditFFM_PORT")]
        public ActionResult EditFFM_PORT(string CmpyCode, string FFM_PORT_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_fpService.EditFFM_PORT(list[0].CmpyCode, FFM_PORT_CODE));
            }
        }
        public ActionResult AddFFM_PORT(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_fpService.NewFFM_PORT(list[0].CmpyCode));
            }
        }
        [HttpPost]
        public ActionResult SaveFFM_PORT(FFM_PORT_VM fpk)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                fpk.CMPYCODE = list[0].CmpyCode;
                fpk.UserName = list[0].user_name;
                return Json(_fpService.SaveFFM_PORT(fpk), JsonRequestBehavior.AllowGet);
            }
        }


        [Route("DeleteFFM_PORT")]
        public ActionResult DeleteFFM_PORT(string FFM_PORT_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _fpService.DeleteFFM_PORT(FFM_PORT_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        [Route("EditFFM_PORT_CODE")]
        public ActionResult EditFFM_PORT(string FFM_PORT_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_fpService.EditFFM_PORT(list[0].CmpyCode, FFM_PORT_CODE), JsonRequestBehavior.AllowGet);
            }
        }
    }
}