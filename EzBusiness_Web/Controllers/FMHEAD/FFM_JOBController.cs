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
    public class FFM_JOBController : Controller
    {
        // GET: FFM_JOB
        IFFM_JOBFreightService _FFMJOBService;
        public FFM_JOBController()
        {
            _FFMJOBService = new FFM_JOBFreightService();
        }

        #region FFM_JOB Master
        [Route("FM_JOBCategoryMaster")]
        public ActionResult FFM_JOB_Master()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FFMJOBService.GetFFM_JOB(list[0].CmpyCode));
            }
        }

        [HttpPost]
        public ActionResult SaveFFM_JOB(FFM_JOB_VM FC)
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
                return Json(_FFMJOBService.SaveFFM_JOB(FC), JsonRequestBehavior.AllowGet);
            }

        }

        [Route("DeleteFFM_JOB")]
        public ActionResult DeleteFFM_JOB(string FFM_JOB_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFMJOBService.DeleteFFM_JOB(FFM_JOB_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}