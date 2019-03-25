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
    public class OTPayrollController : Controller
    {

        IOTPayrollService _OTPayrollService;
        public OTPayrollController()
        {
            _OTPayrollService = new OTPayrollService();

        }
        // GET: OTPayroll
        #region OTPayRoll Master
        [Route("OTPayroll")]
        public ActionResult OTPayroll()
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
        [Route("SaveOTPayroll")]
        public ActionResult SaveOTPayroll(OTVM OTPayroll)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                OTPayroll.Cmpycode = list[0].CmpyCode;
                return Json(_OTPayrollService.SaveOT(OTPayroll), JsonRequestBehavior.AllowGet);
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

        [Route("GetOTDet")]
        public ActionResult GetOTDetailList(string CmpyCode, string EmpCode, DateTime dte, DateTime dte1, string typ)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_OTPayrollService.GetLeaveAppDetailList(list[0].CmpyCode,EmpCode, dte, dte1, typ), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("GetEmpRep")]
        public ActionResult GetOTDetailList( string EmpCode, string DivCode, string prjCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_OTPayrollService.GetEmpRepCodeList(list[0].CmpyCode, EmpCode, DivCode, prjCode), JsonRequestBehavior.AllowGet);
            }
        }


        #endregion


    }
}