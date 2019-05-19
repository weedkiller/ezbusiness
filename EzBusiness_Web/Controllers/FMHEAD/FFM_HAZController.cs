using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers
{
    public class FFM_HAZController : Controller
    {
        // GET: FFM_HAZ
        IFFM_HAZFrightService _FFM_HAZService;
        public FFM_HAZController()
        {
            _FFM_HAZService = new FFM_HAZFrightService();
        }
        #region FFM_HAZ Master
        [Route("FFM_HAZ_Master")]
        public ActionResult FFM_HAZ_Master()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FFM_HAZService.GetFFM_HAZ(list[0].CmpyCode));
            }
        }

        [HttpPost]
        public ActionResult SaveFFM_HAZ(FFM_HAZ_VM FC)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FC.CMPYCODE = list[0].CmpyCode;
                FC.UserName = list[0].user_name;
                return Json(_FFM_HAZService.SaveFFM_HAZ(FC), JsonRequestBehavior.AllowGet);
            }

        }

        [Route("DeleteFFM_HAZ")]
        public ActionResult DeleteFFM_HAZ(string FFM_HAZ_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFM_HAZService.DeleteFFM_HAZ(FFM_HAZ_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}