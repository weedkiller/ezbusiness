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
    public class DutyResumeController : Controller
    {
        IDutyResumePayrollService _DrService;

        public DutyResumeController()
        {
            _DrService = new DutyResumePayrollService();

        }

        #region DutyResume Master
        [Route("DutyResume")]
        public ActionResult DutyResumeMaster()
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

        public ActionResult GetDrs()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_DrService.GetDrs(list[0].CmpyCode));
            }
        }

        [Route("EditDutyResume")]
        public ActionResult EditDutyResume(string Cmpycode ,string Lsno)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_DrService.GetDutyEdit(list[0].CmpyCode, Lsno));
            }
        }


        [Route("DeleteDrs")]
        public ActionResult DeleteDivs(string Cmpycode, string PRDR001_CODE, string oldLeavedays, string EmpCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _DrService.DeleteDrs( list[0].CmpyCode, PRDR001_CODE,oldLeavedays,EmpCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddDutyResume()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_DrService.GetDutyAddNew(list[0].CmpyCode));
            }
        }

        //[Route("Airs")]
        //public ActionResult Airs(string CmpyCode = "UM")
        //{
        //    return Json(_AirService.GetAirs(CmpyCode), JsonRequestBehavior.AllowGet);
        //}
        public ActionResult  GetLsNo(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DrService.GetLsNo(list[0].CmpyCode,Prefix));
            }
        }
        public ActionResult GetLsNoEdit(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DrService.GetLsNoEdit(list[0].CmpyCode, Prefix));
            }
        }


        [Route("EmpCN")]
        public ActionResult GetEmpCodes(string Cmpycode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DrService.GetEmpCodes(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("Ls")]
        public ActionResult GetGetLsNo(string Cmpycode,string typ)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DrService.GetLsNo(list[0].CmpyCode,typ), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("GetLANDET")]
        public ActionResult GetLANDET(string LanNo)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DrService.GetLeaveData(list[0].CmpyCode, LanNo), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Route("SaveDrs")]
        public ActionResult SaveDrs(DutyResumeVM Drs)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Drs.Cmpycode = list[0].CmpyCode;
                Drs.UserName = list[0].user_name;
                return Json(_DrService.SaveDrs(Drs), JsonRequestBehavior.AllowGet);
            }
        }

        //[Route("DeleteDrs")]
        //public ActionResult DeleteDrs(string Cmpycode)
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(new { DeleteFlag = _DrService.DeleteDrs(list[0].CmpyCode) }, JsonRequestBehavior.AllowGet);
        //    }
        //}
        #endregion

        #region DutyResume Request


        #endregion
    }
}