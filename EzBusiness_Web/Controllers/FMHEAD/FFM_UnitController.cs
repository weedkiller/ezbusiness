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
    public class FFM_UnitController : Controller
    {

        IFFM_UNITFrightService _unitService;

        public FFM_UnitController()
        {
            _unitService = new FFM_UnitFrightService();
        }

        #region FFM_Unit Master
        [Route("FrightUnitMaster")]
        public ActionResult FFM_Unit(string CmpyCode)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return View(_unitService.GetFFM_Unit(list[0].CmpyCode));
            }
        }

        [HttpPost]
        //[Route("SaveFNMBranch")]
        public ActionResult saveFFM_Unit(FFM_Unit_VM Fcur)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Fcur.CMPYCODE = list[0].CmpyCode;
                Fcur.UserName = list[0].user_name;
                return Json(_unitService.SaveFFM_Unit(Fcur), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteFMM_Unit")]
        public ActionResult DeleteFMM_Unit(string FFM_Unit_Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _unitService.DeleteFFM_Unit(FFM_Unit_Code, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        [Route("EditFFM_Unit")]
        public ActionResult EditFFM_Unit(string FFM_Unit_Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_unitService.EditFFM_Unit(list[0].CmpyCode, FFM_Unit_Code), JsonRequestBehavior.AllowGet);
            }
        }

    }
}