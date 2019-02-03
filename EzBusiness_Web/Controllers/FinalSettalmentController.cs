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
    public class FinalSettalmentController : Controller
    {

        IFinalsettalmentService _FinalsettalmentService;

        public FinalSettalmentController()
        {
            _FinalsettalmentService = new FinalsettalmentService();

        }

        // GET: FinalSettalment

        [Route("FinalSettalment")]
        public ActionResult FinalSettalment()
        {
            return View();
        }

        public ActionResult AddFinalSettalment(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FinalsettalmentService.GetFinalSettalmentNew(list[0].CmpyCode));
            }
        }

        public ActionResult GetFinalSettalmentList(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FinalsettalmentService.GetFinalSettalment(list[0].CmpyCode));
            }
        }

        [HttpPost]
        [Route("SaveFinalSettalment")]
        public ActionResult SaveFinalSett(Finalsettalment_VM finset)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                finset.Cmpycode = list[0].CmpyCode;
                finset.UserName = list[0].user_name;
                return Json(_FinalsettalmentService.SaveFinalSettalment(finset), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("DeleteFinalSettalment")]
        public ActionResult DeleteFinalSettalment(string CmpyCode, string PRFSET001_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FinalsettalmentService.DeleteFinalSettalment(list[0].CmpyCode, PRFSET001_code,list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("EditFinalSettalment")]
        public ActionResult EditFinalSettalment(string PRFSET001_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FinalsettalmentService.GetFinalSettalmentEdit(list[0].CmpyCode, PRFSET001_code));
            }
        }

        public ActionResult GetFinalSetI(string EmpCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {                
                return Json(_FinalsettalmentService.GetFinalSetI(list[0].CmpyCode,EmpCode), JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GetFinalSetII(string Empcode, DateTime joiingdte, DateTime Reldate, float deducdays, string F1_type, float basicper, DateTime LLSdate, float Ldeducdays, string emptyp, float bleave, float Lbasic, float Housing, float Food, float Tele, float Transport, float Other_Allow)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_FinalsettalmentService.GetFinalSetII(list[0].CmpyCode, Empcode, joiingdte, Reldate, deducdays, F1_type, basicper, LLSdate, Ldeducdays, emptyp, bleave, Lbasic, Housing, Food, Tele, Transport, Other_Allow), JsonRequestBehavior.AllowGet);
            }

        }
    }
}