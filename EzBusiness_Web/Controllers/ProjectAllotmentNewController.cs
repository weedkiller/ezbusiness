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
    public class ProjectAllotmentNewController : Controller
    {
        // GET: ProjectAllotmentNew.

        // GET: ProjectAllotment
        IProjectAllotmentNewService _ProjectAllotService;

        public ProjectAllotmentNewController()
        {
            _ProjectAllotService = new ProjectAllotmentNewService();
        }

        #region ProjectAllotment Master
        [Route("ProjectAllotmentNew")]
        public ActionResult ProjectAllotmentNew()
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


        public ActionResult AddProjectAllotmentNew()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_ProjectAllotService.NewProjectAllotmentN(list[0].CmpyCode));
            }
        }
        [Route("EditProjectAllotmentNew")]
        public ActionResult EditProjectAllotmentNew(string PRPRJE001_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_ProjectAllotService.GetProjectAllotmentEdit(list[0].CmpyCode, PRPRJE001_code));
            }
        }
        public ActionResult GetProjectAllotmentNewList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_ProjectAllotService.GetProjectAllotmentList(list[0].CmpyCode));
            }
        }
        [HttpPost]
        [Route("SaveProjectAllotmentNew")]
        public ActionResult SaveEmpShift(PRPJXDTDVM PrjAll)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                PrjAll.cmpycode = list[0].CmpyCode;
                PrjAll.Username = list[0].user_name;
                return Json(_ProjectAllotService.SaveProjectAllotment(PrjAll), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteProjectAllotmentNew")]
        public ActionResult DeleteEmpShift(string PRPRJE001_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _ProjectAllotService.DeleteProjectAllotment(list[0].CmpyCode, PRPRJE001_code, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}