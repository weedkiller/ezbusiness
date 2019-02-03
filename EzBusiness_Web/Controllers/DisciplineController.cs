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
    public class DisciplineController : Controller
    {
        IDisciplinePayrollService _DiService;

        public DisciplineController()
        {
            _DiService = new DisciplinePayrollService();

        }

        #region Discipline Master
        [Route("Discipline")]
        public ActionResult DisciplineMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_DiService.GetDis(list[0].CmpyCode));
            }
        }

        [Route("Dis")]
        public ActionResult Dis()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DiService.GetDis(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveDis(DisciplineVM Dis)
        {
           

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Dis.CmpyCode = list[0].CmpyCode;
                Dis.UserName = list[0].user_name;
                return Json(_DiService.SaveDis(Dis), JsonRequestBehavior.AllowGet);
            }

        }

        [Route("DeleteDis")]
        public ActionResult DeleteDis(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _DiService.DeleteDis(Code, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Dis Request


        #endregion
    }
}