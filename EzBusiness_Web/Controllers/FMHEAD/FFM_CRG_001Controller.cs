using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FMHEAD
{
    public class FFM_CRG_001Controller : Controller
    {
        // GET: FFM_CRG_001
        IFFM_CRG_001FreightService _FFMCRGService;
        public FFM_CRG_001Controller()
        {
            _FFMCRGService = new FFM_CRG_001FreightService();
        }

        #region FFM_CRG_001 Master
        [Route("Chargemaster")]
        public ActionResult FM_CRG_001CategoryMaster()
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
        public ActionResult GetFM_CRG_001()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFMCRGService.GetFFM_CRG_001(list[0].CmpyCode));
            }
        }
        [HttpPost]
        [Route("SaveFFM_CRG_001")]
        public ActionResult SaveFFM_CRG_001(FFM_CRG_001_VM CR)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                CR.CMPYCODE = list[0].CmpyCode;
                 CR.UserName = list[0].user_name;
                return Json(_FFMCRGService.SaveFFM_CRG_001(CR), JsonRequestBehavior.AllowGet);
            }

        }


        [Route("EditFFM_CRG_001")]
        public ActionResult EditFFM_CRG_001(string Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFMCRGService.EditFM_CRG_001(list[0].CmpyCode, Code));
            }
        }

        public ActionResult AddFM_CRG_001()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFMCRGService.FM_CRG_001AddNew(list[0].CmpyCode));
            }
        }
        [Route("DeleteFFM_CRG_001")]
        public ActionResult DeleteFFM_CRG_001(string FFM_CRG_001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFMCRGService.DeleteFFM_CRG_001( list[0].CmpyCode, FFM_CRG_001_CODE, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}