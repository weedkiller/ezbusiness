using EzBusiness_BL_Interface.FreightManagement;
using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagement;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FMHEAD
{
    public class FNM_CURR_RATEController : Controller
    {
        // GET: FNM_CURR_RATE
        IFNM_CURR_RATEService _FNM_CURR_RATEService;

        public FNM_CURR_RATEController()
        {
            _FNM_CURR_RATEService = new FNM_CURR_RATEService();

        }

        #region  FNM_AC_COA Master
        [Route("CurrentRate")]
        public ActionResult FNMCurrentRate()
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

        public ActionResult GetCurrentRate()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FNM_CURR_RATEService.GetFNM_CURR_RATE(list[0].CmpyCode));
            }
        }

        [Route("EditCURR_RATE")]
        public ActionResult EditCURR_RATE(string FROM_CURRENCY_CODE, string ENTRY_DATE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                
                
                return PartialView(_FNM_CURR_RATEService.EditFNM_CURR_RATE(list[0].CmpyCode, FROM_CURRENCY_CODE,Convert.ToDateTime(ENTRY_DATE)));
            }
        }


        [Route("DeleteFNM_CURR_RATE")]
        public ActionResult DeleteAccountType(string FROM_CURRENCY_CODE, string ENTRY_DATE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FNM_CURR_RATEService.DeleteFNM_CURR_RATE(list[0].CmpyCode, FROM_CURRENCY_CODE,Convert.ToDateTime(ENTRY_DATE), list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddFNM_CURR_RATE()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FNM_CURR_RATEService.GetFNM_CURR_RATEAddNew(list[0].CmpyCode));
            }
        }

        [HttpPost]
        [Route("SaveFNM_CURR_RATE")]
        public ActionResult SaveDrs(FNM_CURR_RATE_VM FNMcurR)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FNMcurR.CMPYCODE = list[0].CmpyCode;
                FNMcurR.UserName = list[0].user_name;
                return Json(_FNM_CURR_RATEService.SaveFNM_CURR_RATE(FNMcurR), JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetCURRENCYRateDetailList(string FROM_CURRENCY_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_FNM_CURR_RATEService.GetCURRENCYRateDetailList(list[0].CmpyCode, FROM_CURRENCY_CODE), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}