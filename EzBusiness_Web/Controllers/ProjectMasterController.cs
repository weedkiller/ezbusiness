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
    public class ProjectMasterController : Controller
    {
        IProjectMasterPayrollService _PjmsService;

        public ProjectMasterController()
        {
            _PjmsService = new ProjectMasterPayrollService();

        }
        #region Project Master
        [Route("ProjectMaster")]
        public ActionResult ProjectMaster(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_PjmsService.GetPjms(list[0].CmpyCode));
            }
        }

        [Route("Pjms")]
        public ActionResult Pjms()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_PjmsService.GetPjms(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SavePjms(ProjectMasterVM Pjms)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Pjms.CmpyCode = list[0].CmpyCode;
                Pjms.UserName = list[0].user_name;
                return Json(_PjmsService.SavePjms(Pjms), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeletePjms")]
        public ActionResult DeletePjms(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _PjmsService.DeletePjms(Code, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Pjms Request


        #endregion
    }
}