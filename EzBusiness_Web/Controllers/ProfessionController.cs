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
    public class ProfessionController : Controller
    {
        IProfessionPayrollService _ProService;

        public ProfessionController()
        {
            _ProService = new ProfessionPayrollService();

        }

        #region Profession Master
        [Route("Profession")]
        public ActionResult ProfessionMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_ProService.GetPros(list[0].CmpyCode));
            }
        }

        [Route("Pros")]
        public ActionResult Pros()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_ProService.GetPros(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        

        [HttpPost]
        public ActionResult SavePros(ProfessionVM Pros)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Pros.CmpyCode = list[0].CmpyCode;
                Pros.UserName = list[0].user_name;
                return Json(_ProService.SavePros(Pros), JsonRequestBehavior.AllowGet);
            }

           
        }

        [Route("DeletePros")]
        public ActionResult DeletePros(string ProfCode, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _ProService.DeletePros(ProfCode, CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Profession Request


        #endregion
    }
}