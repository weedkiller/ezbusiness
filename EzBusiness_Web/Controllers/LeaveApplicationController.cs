using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.IO;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using EzBusiness_EF_Entity;
using System.Collections.Generic;

namespace EzBusiness_Web.Controllers
{
    public class LeaveApplicationController : Controller
    {

        ILeaveApplicationService _LeaveAppService;
        
        public LeaveApplicationController()
        {
            _LeaveAppService = new LeaveApplicationService();
        }

        // GET: LeaveApplication

        [Route("LeaveApplication")]
        public ActionResult LeaveApplication()
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

        public ActionResult GetLeaveApplicationList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_LeaveAppService.GetLeaveApp(list[0].CmpyCode));
            }
        }

        public ActionResult GetLeaveAppDetailList(string Empcode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //return PartialView(_LeaveAppService.GetLeaveAppDetailList(list[0].CmpyCode, Empcode));
                return Json(_LeaveAppService.GetLeaveAppDetailList(list[0].CmpyCode, Empcode), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditLeaveApplication")]
        public ActionResult EditLeaveApplication(string Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_LeaveAppService.GetLeaveAppDetailsEdit(list[0].CmpyCode, Code));
            }
        }


        [Route("PrintLeaveApplication")]
        public ActionResult PrintLeaveApplication(string Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_LeaveAppService.GetLeaveAppDetailsEdit(list[0].CmpyCode, Code));
            }
        }

        public ActionResult AddLeaveApplication()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_LeaveAppService.GetLeaveAppDetailsNew(list[0].CmpyCode));
            }
        }
        public ActionResult GetLeaveTypList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_LeaveAppService.GetLeaveTypList(list[0].CmpyCode,Prefix));
            }
        }

        [HttpPost]
        [Route("SaveLeaveApp")]
        public ActionResult SaveLeaveApp(Leave_App_VW LeaveApp)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {                
                LeaveApp.CmpyCode    = list[0].CmpyCode.ToString();
                LeaveApp.UserName = list[0].user_name;
                //LeaveApp.Branch = list[0].BraCode.ToString();
                //LeaveApp.Dept = list[0].DepCode.ToString();
                //LeaveApp.DIVISION = list[0].Divcode.ToString();
                return Json(_LeaveAppService.SaveLeaveApp(LeaveApp), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetBalanceLeave(string CmpyCode, string EmpCode, string LeaveType, DateTime joiningdte)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //return PartialView(_LeaveAppService.GetLeaveAppDetailList(list[0].CmpyCode, Empcode));
                return Json(_LeaveAppService.GetBalanceLeave(list[0].CmpyCode, EmpCode, LeaveType, joiningdte), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetJoiningdate(string CmpyCode, string EmpCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //return PartialView(_LeaveAppService.GetLeaveAppDetailList(list[0].CmpyCode, Empcode));
                return Json(_LeaveAppService.GetJoiningdate(list[0].CmpyCode, EmpCode), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("DeleteLeaveApp")]
        public ActionResult DeleteLeaveApp(string Cmpycode, string PRLR001_CODE, string oldLeavedays, string EmpCode,string LeaveType)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _LeaveAppService.DeleteLeaveApp(list[0].CmpyCode, PRLR001_CODE, oldLeavedays, EmpCode, list[0].user_name, LeaveType) }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}