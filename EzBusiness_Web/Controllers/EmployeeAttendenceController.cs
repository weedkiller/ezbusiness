using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;


namespace EzBusiness_Web.Controllers
{
    public class EmployeeAttendenceController : Controller
    {

        IOTPayrollService _OTPayrollService;
        public EmployeeAttendenceController()
        {
            _OTPayrollService = new OTPayrollService();

        }
        // GET: EmployeeAttendence
        #region EmployeeAttendence
        [Route("EmployeeAttendence")]
        public ActionResult EmployeeAttendence()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_OTPayrollService.GetOTVMNew(list[0].CmpyCode));
            }
        }
        [HttpPost]
        [Route("SaveEmployeeAttendence")]
        public ActionResult SaveEmployeeAttendence(OTVM OTPayroll)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                OTPayroll.Cmpycode = list[0].CmpyCode;
                return Json(_OTPayrollService.SaveAP(OTPayroll), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("EmpCN")]
        public ActionResult GetEmpCodes()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_OTPayrollService.GetEmpCodeList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("GetLeaveTypList")]
        public ActionResult GetLeaveTypList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_OTPayrollService.GetLeaveTypList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [Route("GetAPDetailList")]
        public ActionResult GetAPDetailList(string CmpyCode, string EmpCode, DateTime dte)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_OTPayrollService.GetAPDetailList(list[0].CmpyCode, EmpCode, dte), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}


