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
    public class TimeSheetDetController : Controller
    {
        ITSDpayrollService _TdsService;

        public TimeSheetDetController()
        {
            _TdsService = new TSDpayrollService();

        }
        [Route("TSD")]
        public ActionResult TSD()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_TdsService.GetOTVMNew(list[0].CmpyCode));
            }
        }
        [Route("GetTSDList")]
        public ActionResult GetTSDList( string EmpCode, string Divcode, DateTime date1)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                //return PartialView(_TdsService.GetTSDList(list[0].CmpyCode, EmpCode, date1));

                return Json(_TdsService.GetTSDList(list[0].CmpyCode, EmpCode, Divcode, date1), JsonRequestBehavior.AllowGet);
            }
        }

       
        public ActionResult GetEmpCodes()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_TdsService.GetEmpCodes(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCountryP(DateTime dt)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                var country = _TdsService.GetCountryP(list[0].CmpyCode, dt);
                if (country == null)
                {
                    country = "0";
                }
                return Json(country, JsonRequestBehavior.AllowGet);
            }
        }
    }
}