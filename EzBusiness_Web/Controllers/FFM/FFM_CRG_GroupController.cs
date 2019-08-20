using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FFM
{
    public class FFM_CRG_GroupController : Controller
    {
        // GET: FFM_CRG_Group
        IFFM_CRG_GroupService _FFM_CRG_GroupService;

        public FFM_CRG_GroupController()
        {
            _FFM_CRG_GroupService = new FFM_CRG_GroupService();

        }

        #region  FFM_CRG_Group Master
        [Route("ChargeGroup")]
        public ActionResult FFMChargeGroup()
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

        public ActionResult GetChargeGroup()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFM_CRG_GroupService.GetFFM_CRG_Group(list[0].CmpyCode));
            }
        }

        [Route("EditFFM_CRG_Group")]
        public ActionResult EditFFM_CRG_Group(string FFM_CRG_GROUP_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_FFM_CRG_GroupService.EditFFM_CRG_Group(list[0].CmpyCode, FFM_CRG_GROUP_CODE));
            }
        }


        [Route("DeleteFFM_CRG_Group")]
        public ActionResult DeleteAccountType(string FFM_CRG_GROUP_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFM_CRG_GroupService.DeleteFFM_CRG_Group(list[0].CmpyCode, FFM_CRG_GROUP_CODE, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddFFM_CRG_Group()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFM_CRG_GroupService.GetFFM_CRG_GroupAddNew(list[0].CmpyCode));
            }
        }

        [HttpPost]
        [Route("SaveFFM_CRG_Group")]
        public ActionResult SaveDrs(FFM_CRG_Group_VM FNMCRG_Grp)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FNMCRG_Grp.CMPYCODE = list[0].CmpyCode;
                FNMCRG_Grp.UserName = list[0].user_name;
                return Json(_FFM_CRG_GroupService.SaveFFM_CRG_Group(FNMCRG_Grp), JsonRequestBehavior.AllowGet);
            }
        }


       

        #endregion
    }
}