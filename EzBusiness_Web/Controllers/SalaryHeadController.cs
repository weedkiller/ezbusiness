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
    public class SalaryHeadController : Controller
    {
        ISalaryHeadPayrollService _SalService;

        public SalaryHeadController()
        {
            _SalService = new SalaryHeadPayrollService();

        }

        #region SalaryHead Master
        [Route("SalaryHead")]
        public ActionResult SalaryHeadMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_SalService.GetSals(list[0].CmpyCode));
            }
        }

        [Route("Sals")]
        public ActionResult Sals()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_SalService.GetSals(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("Commontable1")]
        public ActionResult GetPayDeductOns()
        {
            return Json(_SalService.GetPayDeductOns(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveSals(SalaryHeadVM Sals)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Sals.CmpyCode = list[0].CmpyCode;
                Sals.UserName = list[0].user_name;
                return Json(_SalService.SaveSals(Sals), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteSals")]
        public ActionResult DeleteSals(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _SalService.DeleteSals(Code, list[0].CmpyCode,list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region SalaryHead Request


        #endregion
    }
}