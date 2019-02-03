using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FinaceMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EzBusiness_Web.Controllers
{
    public class FinaceMgmtController : Controller
    {
        IFinaceMgmtService _finaceService;

        public FinaceMgmtController()
        {
            _finaceService = new FinaceMgmtService();

        }

        #region Exchange Rate Master
        [Route("ExchangeRate")]
        public ActionResult ExchangeRateMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_finaceService.GetExchange(list[0].CmpyCode));
            }
        }

        [Route("ExchangeRate1")]
        public ActionResult ExchangeRate()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_finaceService.GetExchange(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveExchange(ExchangeRateVM Exchange)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Exchange.CmpyCode = list[0].CmpyCode;
                Exchange.UserName = list[0].user_name;
                return Json(_finaceService.SaveExchange(Exchange), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteExchange")]
        public ActionResult DeleteExchange(string CurCode, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _finaceService.DeleteExchange(CurCode, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Finace Request


        #endregion
    }
}