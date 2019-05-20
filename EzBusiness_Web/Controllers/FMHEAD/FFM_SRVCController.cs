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
    public class FFM_SRVCController : Controller
    {
        // GET: FFM_SRVC
        IFFM_SRVCFreightService _FFMSRVCService;

        public FFM_SRVCController()
        {
            _FFMSRVCService = new FFM_SRVCFreightService();

        }

        #region FFM_SRVC Master
        [Route("FM_SRVCCategoryMaster")]
        public ActionResult FFM_SRVC_Master()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FFMSRVCService.GetFFM_SRVC(list[0].CmpyCode));
            }
        }

        [HttpPost]
        public ActionResult SaveFFM_SRVC(FFM_SRVC_VM SR)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                SR.CMPYCODE = list[0].CmpyCode;
                SR.UserName = list[0].user_name;
                return Json(_FFMSRVCService.SaveFFM_SRVC(SR), JsonRequestBehavior.AllowGet);
            }

        }

        [Route("DeleteFFM_SRVC")]
        public ActionResult DeleteFFM_SRVC(string FFM_SRVC_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFMSRVCService.DeleteFFM_SRVC(FFM_SRVC_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}