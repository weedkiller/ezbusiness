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
    public class FFM_CNTRController : Controller
    {
        // GET: FNM_CURRENCY


        IFFMCNTRFrightService _CNTRService;

        public FFM_CNTRController()
        {
            _CNTRService = new FFM_CNTRFrightService();
        }

        #region FFM_CNTR Master
        [Route("FFM_CNTRMaster")]
        public ActionResult FFM_CNTR(string CmpyCode)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return View(_CNTRService.GetFFM_CNTR(list[0].CmpyCode));
            }
        }



        [HttpPost]
        //[Route("SaveFNMBranch")]
        public ActionResult saveFFM_CNTR(FFM_CNTR_VM Fcur)
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
                return Json(_CNTRService.SaveFFM_CNTR(Fcur), JsonRequestBehavior.AllowGet);
            }
        }



        [Route("DeleteFMM_CNTR")]
        public ActionResult DeleteFMM_CNTR(string CURRENCYCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _CNTRService.DeleteFMM_CNTR(CURRENCYCode, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        [Route("EditFFM_CNTR")]
        public ActionResult EditFFM_CNTR(string CURRENCYCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CNTRService.EditFFM_CNTR(list[0].CmpyCode, CURRENCYCode), JsonRequestBehavior.AllowGet);
            }
        }

    }
}