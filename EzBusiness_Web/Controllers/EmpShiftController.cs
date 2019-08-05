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
    public class EmpShiftController : Controller
    {
        IEmpShiftPayrollService _EmpShiftService;

        public EmpShiftController()
        {
            _EmpShiftService = new EmpShiftPayrollService();
        }

        #region EmpShift Master
        [Route("EmpShiftMaster")]
        public ActionResult EmpShiftMaster()
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


        public ActionResult AddEmpShiftMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_EmpShiftService.NewEmpShift(list[0].CmpyCode));
            }
        }

        public ActionResult GetShiftAllocCode(string Prefix, string PRSFT001_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_EmpShiftService.GetShiftAllocCode(list[0].CmpyCode, PRSFT001_code, Prefix));
            }
        }
        public ActionResult GetShiftCodes(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_EmpShiftService.GetShiftCodes(list[0].CmpyCode, Prefix));
            }
        }
        [Route("EditEmpShiftMaster")]
        public ActionResult EditEmpShiftMaster(string PRSFT003_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_EmpShiftService.GetEmpShiftEdit(list[0].CmpyCode, PRSFT003_code));
            }
        }
        public ActionResult GetEmpShiftMasterList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_EmpShiftService.GetEmpShiftList(list[0].CmpyCode));
            }
        }

      

   

        [HttpPost]
        [Route("SaveEmpShift")]
        public ActionResult SaveEmpShift(EmpShiftVM Sft)
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
                return Json(_EmpShiftService.SaveEmpShift(Sft), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteEmpShift")]
        public ActionResult DeleteEmpShift(string PRSFT003_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _EmpShiftService.DeleteEmpShift(list[0].CmpyCode, PRSFT003_code, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
       #endregion
    }
}