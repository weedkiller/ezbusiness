using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers
{
    public class AttendenceController : Controller
    {
        IAttendencePayrollService _AtenService;

        public AttendenceController()
        {
            _AtenService = new AttendencePayrollService();

        }

        #region Attendence Master
        [Route("AttendenceMaster")]
        public ActionResult AttendenceMaster( )
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_AtenService.GetAtens(list[0].CmpyCode));
            }
        }

        [Route("Atens")]
        public ActionResult Atens()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_AtenService.GetAtens(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

       
        [Route("Country2")]
        public ActionResult GetCountryCodes()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_AtenService.GetCountryCodes(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult SaveAtens(AttendenceVM Atens)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Atens.UserName = list[0].user_name;
                Atens.CmpyCode = list[0].CmpyCode;                
                return Json(_AtenService.SaveAtens(Atens), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteAtens")]
        public ActionResult DeleteAtens(string Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _AtenService.DeleteAtens(Code, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Attendence Request


        #endregion
    }
}