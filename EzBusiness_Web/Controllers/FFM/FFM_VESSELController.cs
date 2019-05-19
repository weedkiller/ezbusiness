using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FMHEAD
{
    public class FFM_VESSELController : Controller
    {
        // GET: FFM_VESSEL
        IFFM_VESSELService _FFM_VESSELService;

        public FFM_VESSELController()
        {
            _FFM_VESSELService = new FFM_VESSELService();

        }

        #region  FNM_AC_COA Master
        [Route("Vessel")]
        public ActionResult FFM_VESSEL()
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

        public ActionResult GetFFM_VESSEL()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFM_VESSELService.GetFFM_VESSEL(list[0].CmpyCode));
            }
        }

        [Route("EditFFM_VESSEL")]
        public ActionResult EditFFM_VESSEL(string FFM_VESSEL_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFM_VESSELService.EditFFM_VESSEL(list[0].CmpyCode, FFM_VESSEL_CODE));
            }
        }


        [Route("DeleteFFM_VESSEL")]
        public ActionResult DeleteAccountType(string FFM_VESSEL_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFM_VESSELService.DeleteFFM_VESSEL(FFM_VESSEL_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddVESSEL()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFM_VESSELService.GetFFM_VESSELAddNew(list[0].CmpyCode));
            }
        }

        [HttpPost]
        [Route("SaveVESSEL")]
        public ActionResult SaveDrs(FFM_VESSEL_VM FNM)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FNM.CMPYCODE = list[0].CmpyCode;
                FNM.UserName = list[0].user_name;
                return Json(_FFM_VESSELService.SaveFFM_VESSEL(FNM), JsonRequestBehavior.AllowGet);
            }
        }


        #endregion
    }
}