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
    public class LeaveSettlementController : Controller
    {
        // GET: SalaryMaster
        ILvSettlePayrollService _LVService;
        public LeaveSettlementController()
        {
            _LVService = new LvSettlePayrollService();

        }

        #region LeaveSettlement
        [Route("LeaveSettlement")]
        public ActionResult LeaveSettlement()
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
        [HttpPost]
        [Route("SaveLeaveSettal")]
        public ActionResult SaveLeaveSettal(LeaveSettlementVM LeaveSett)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                LeaveSett.CMPYCODE = list[0].CmpyCode.ToString();
                LeaveSett.UserName = list[0].user_name;             
                return Json(_LVService.SaveLiv(LeaveSett), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteLeaveSettal")]
        public ActionResult DeleteLeaveSettal( string PRSR001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _LVService.DeleteLiv(list[0].CmpyCode, PRSR001_CODE, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddLeaveSettal()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_LVService.GetLeaveSettlementNew(list[0].CmpyCode));
            }
        }

        [Route("EditLeaveSettal")]
        public ActionResult EditLeaveSettal(string PRSR001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_LVService.GetLivlistEdit(list[0].CmpyCode, PRSR001_CODE));
            }
        }


        public ActionResult GetLeaveDetails(string PRLR001_CODE,DateTime lvsdte)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {                
                return Json(_LVService.GetLeaveDetails(list[0].CmpyCode, PRLR001_CODE, lvsdte), JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetLeaveSettalmentList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                // return PartialView(_LVService.GetLivlist(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
                return PartialView(_LVService.GetLivlist(list[0].CmpyCode));
            }
        }

        #endregion
    }
}