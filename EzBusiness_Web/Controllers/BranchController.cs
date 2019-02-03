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
    public class BranchController : Controller
    {

        IBranchPayrollService _BrService;

        public BranchController()
        {
            _BrService = new BranchPayrollService();

        }

        #region Branch Master
        [Route("Branch")]
        public ActionResult BranchMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_BrService.GetBrnc(list[0].CmpyCode));
            }
        }

        [Route("Brnc")]
        public ActionResult Brnc()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BrService.GetBrnc(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveBrnc(BranchVM Brc)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Brc.CmpyCode = list[0].CmpyCode;
                Brc.Username = list[0].user_name;
                return Json(_BrService.SaveBrnc(Brc), JsonRequestBehavior.AllowGet);

            }

        }

        [Route("DeleteBrs")]
        public ActionResult DeleteBrs(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _BrService.DeleteBrnc(Code, CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("DivCommontable2")]
        public ActionResult DivisionCode(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BrService.GetDivisionList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }


        }

        #endregion

        #region Brs Request


        #endregion
    }
}