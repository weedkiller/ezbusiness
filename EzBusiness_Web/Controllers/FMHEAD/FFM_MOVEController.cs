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
    public class FFM_MOVEController : Controller
    {
        IFFM_MOVEFrightService _MOVEService;

        public FFM_MOVEController()
        {
            _MOVEService = new FFM_MOVE_FrightService();
        }

        #region FFM_MOVE Master
        [Route("FFM_MOVEMaster")]
        public ActionResult FFM_MOVE(string CmpyCode)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return View(_MOVEService.GetFFM_MOVE(list[0].CmpyCode));
            }
        }



        [HttpPost]
        //[Route("SaveFNMBranch")]
        public ActionResult saveFFM_MOVE(FFM_MOVE_VM Fcur)
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
                return Json(_MOVEService.SaveFFM_MOVE(Fcur), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteFFM_MOVE")]
        public ActionResult DeleteFFM_MOVE(string FFM_MOVE_Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _MOVEService.DeleteFFM_MOVE(FFM_MOVE_Code, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        [Route("EditFFM_MOVE")]
        public ActionResult EditFFM_MOVE(string FFM_MOVE_Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_MOVEService.EditFFM_MOVE(list[0].CmpyCode, FFM_MOVE_Code), JsonRequestBehavior.AllowGet);
            }
        }
    }
}