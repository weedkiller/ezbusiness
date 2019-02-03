using EzBusiness_EF_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;



namespace EzBusiness_Web.Controllers
{
    public class HolidayController : Controller
    {
        // GET: Holiday
        IHolidayPayrollService _HoliService;
        public HolidayController()
        {
            _HoliService = new HolidayPayrollService ();

        }
        #region Holiday
        [Route("HolidayMaster")]
        public ActionResult HolidayMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_HoliService.GetAtensH(list[0].CmpyCode,System.DateTime.UtcNow));
            }

        }


        //[Route("Countrys5")]
        //public ActionResult GetCountrys()
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_HoliService.GetCountrys(), JsonRequestBehavior.AllowGet);
        //    }
        //}



        [Route("GetLeaveType")]
        public ActionResult GetLeaveTypeH(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_HoliService.GetAttendenceCodesH(CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("GetHoliday")]
        public ActionResult GetAttendanceListH( DateTime date1)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return Json(_HoliService.GetAtensH(list[0].CmpyCode,date1), JsonRequestBehavior.AllowGet);
            }

        }


        [HttpPost]
        public ActionResult SaveHoliday(HolidayVM HolidayMaster)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                HolidayMaster.CmpyCode = list[0].CmpyCode;
                HolidayMaster.UserName = list[0].user_name;
                return Json(_HoliService.SaveHoliday(HolidayMaster), JsonRequestBehavior.AllowGet);
            }
        }
        
        [Route("DeleteHoliday")]
        public ActionResult DeleteHoliday(DateTime date1)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                                
                return Json(new { DeleteFlag = _HoliService.DeleteHoliday(list[0].CmpyCode, date1, list[0].user_name) }, JsonRequestBehavior.AllowGet);
                
            }
        }

        #endregion
    }
}