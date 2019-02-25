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
    public class MonthlyAdddedController : Controller
    {
        IMonthlyAdddedPayrollService _MonthlyAdddedService;
        ISalaryprocCondService _SalProCond;
        public MonthlyAdddedController()
        {
            _MonthlyAdddedService = new MonthlyAdddedPayrollService();
            _SalProCond = new SalaryprocCondService();
        }

        #region MonthlyAddded Master
        [Route("MonthlyAddded")]
        public ActionResult MonthlyAddded()
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


        [Route("EditMonthlyAddded")]
        public ActionResult EditMonthlyAddded(string CmpyCode, string PRADN001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_MonthlyAdddedService.GetMonthlyADEdit(list[0].CmpyCode, PRADN001_CODE));
            }
        }

        public ActionResult AddMonthlyAddded(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_MonthlyAdddedService.GetMonthlyAdddedNew(list[0].CmpyCode));
            }
        }



        [Route("GetMonthlyAdddedGrid")]
        public ActionResult GetMonthlyAdddedGrid(string CmpyCode, string PRADN001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_MonthlyAdddedService.GetMonthlyADGrid(CmpyCode, PRADN001_CODE), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMonthlyAdddedList(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_MonthlyAdddedService.GetMonthlyAdddedList(list[0].CmpyCode));
            }
        }



        [HttpPost]
        [Route("SaveMonthly")]
        public ActionResult SaveMonthly(MonthlyAdddedVM Monthly)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Monthly.CmpyCode = list[0].CmpyCode;
                Monthly.UserName = list[0].user_name;
                return Json(_MonthlyAdddedService.SaveMonthlyAD(Monthly), JsonRequestBehavior.AllowGet);

            }
        }
        [Route("DeleteMonthly")]
        public ActionResult DeleteMonthly(string CmpyCode, string PRADN001_CODE)

        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _MonthlyAdddedService.DeleteMonthlyAD(list[0].CmpyCode, PRADN001_CODE, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
#endregion
