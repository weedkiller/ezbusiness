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
    public class ProjectAllotmentController : Controller
    {
        // GET: ProjectAllotment
        IProjectAllotmentService _ProjectAllotService;

        public ProjectAllotmentController()
        {
            _ProjectAllotService = new ProjectAllotmentService();
        }

        #region ProjectAllotment Master
        [Route("ProjectAllotment")]
        public ActionResult ProjectAllotment()
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


        public ActionResult AddProjectAllotment()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_ProjectAllotService.NewProjectAllotment(list[0].CmpyCode));
            }
        }
        [Route("EditProjectAllotment")]
        public ActionResult EditProjectAllotment(string PRPRJE001_code)
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
        public ActionResult GetProjectAllotmentList()
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
        [Route("SaveProjectAllotment")]
        public ActionResult SaveEmpShift(ProjectAllotmentVM PrjAll)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                PrjAll.CmpyCode = list[0].CmpyCode;
                PrjAll.UserName = list[0].user_name;
                return Json(_ProjectAllotService.SaveProjectAllotment(PrjAll), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteProjectAllotment")]
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