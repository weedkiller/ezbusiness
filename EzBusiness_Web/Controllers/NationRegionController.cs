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
    public class NationRegionController : Controller
    {
        INationRPayrollService _NrService;

        public NationRegionController()
        {
            _NrService = new NationRPayrollService();

        }

        #region NationRegion Master
        [Route("NationRegion")]
        public ActionResult NationRegionMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_NrService.GetNrs(list[0].CmpyCode));
            }
        }

        [Route("Nrs")]
        public ActionResult Nrs()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_NrService.GetNrs(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveNrs(NationRegionVM Nrs)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Nrs.CmpyCode = list[0].CmpyCode;
                Nrs.UserName = list[0].user_name;
                return Json(_NrService.SaveNrs(Nrs), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteNrs")]
        public ActionResult DeleteNrs(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _NrService.DeleteNrs(Code, CmpyCode,list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Nrs Request


        #endregion
    }
}