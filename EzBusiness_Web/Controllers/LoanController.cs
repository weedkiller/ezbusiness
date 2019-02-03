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
    public class LoanController : Controller
    {
        ILoanPayrollService _LonService;

        public LoanController()
        {
            _LonService = new LoanPayrollService();

        }

        #region Loan Master
        [Route("Loan")]
        public ActionResult LoanMaster(string CmpyCode )
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_LonService.GetLons(list[0].CmpyCode));
            }
        }

        [Route("Lons")]
        public ActionResult Lons()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_LonService.GetLons(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveLons(LoanVM Lons)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Lons.CmpyCode = list[0].CmpyCode;
                Lons.UserName = list[0].user_name;
                return Json(_LonService.SaveLons(Lons), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteLons")]
        public ActionResult DeleteLons(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _LonService.DeleteLons(Code, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Lons Request


        #endregion
    }
}