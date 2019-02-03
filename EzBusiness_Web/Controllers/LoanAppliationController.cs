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
    public class LoanAppliationController : Controller
    {
        ILoanAppPayrollService _LAPService;

        public LoanAppliationController()
        {
            _LAPService = new LoanAppPayrollService();

        }

        #region LoanAppliation
        [Route("LoanAppliation")]
        public ActionResult LoanAppliation()
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


        public ActionResult AddLoanAppliation()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_LAPService.GetLoanAppNew(list[0].CmpyCode));
            }
        }
        [Route("EditLoanAppliation")]
        public ActionResult EditLoanAppliation(string PRLA001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_LAPService.GetLoanAppEdit(list[0].CmpyCode, PRLA001_CODE));
            }
        }
        public ActionResult GetLoanAppliationList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_LAPService.GetLoanAppList(list[0].CmpyCode));
            }
        }

       
        

        [HttpPost]
        [Route("SaveLoanAppliation")]
        public ActionResult SaveLoanAppliation(LoanAppliationVM LoanApp)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                LoanApp.CmpyCode = list[0].CmpyCode;
                LoanApp.UserName = list[0].user_name;
                return Json(_LAPService.SaveLoanApp(LoanApp), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteLoanApp")]
        public ActionResult DeleteLoanApp(string PRLA001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _LAPService.DeleteLoanApp(list[0].CmpyCode, PRLA001_CODE, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}