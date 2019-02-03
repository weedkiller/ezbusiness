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
    public class ShiftMasterController : Controller
    {
        ISiftMasterPayrollService _ShiftService;
        public ShiftMasterController()
        {
            _ShiftService = new SiftMasterPayrollService();

        }
        #region Shift Master
        [Route("ShiftMaster")]
        public ActionResult ShiftMaster()
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
        [Route("EditShiftMaster")]
        public ActionResult EditShift(string CmpyCode, string PRSFT001_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_ShiftService.GetShiftEdit(list[0].CmpyCode, PRSFT001_code));
            }
        }
        public ActionResult AddShiftkDetail(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_ShiftService.NewShift(list[0].CmpyCode));
            }
        }
        public ActionResult GetShiftGrid(string CmpyCode, string PRSFT002_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_ShiftService.GetShiftGrid(list[0].CmpyCode, PRSFT002_code), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetShiftList(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_ShiftService.GetShiftList(list[0].CmpyCode));
            }
        }

        [Route("Country")]
        public ActionResult GetCountryCodes()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_ShiftService.GetCountryCodes(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [Route("SaveShift")]
        public ActionResult SaveShift(ShiftMasterVM Sft)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Sft.CmpyCode = list[0].CmpyCode;
                Sft.UserName = list[0].user_name;
                return Json(_ShiftService.SaveShift(Sft), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("DeleteShift")]
        public ActionResult DeleteShift(string CmpyCode, string PRSFT001_code, string PRSFT002_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _ShiftService.DeleteShift(list[0].CmpyCode, PRSFT001_code,list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("UseShiftAlloc")]
        public ActionResult UseShiftAlloc(string PRSFT001_code, string PRSFT002_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _ShiftService.UseShiftAlloc(list[0].CmpyCode, PRSFT001_code, PRSFT002_code) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}