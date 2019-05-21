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
    public class FFM_CRG_002Controller : Controller
    {
        // GET: FFM_CRG_002

        IFFM_CRG_002FreightService _FFM_CRG_002Service;

        public FFM_CRG_002Controller()
        {
            _FFM_CRG_002Service = new FFM_CRG_002FreightService();

        }

        #region  FFM_CRG_002 Master
        [Route("CRG_002Master")]
        public ActionResult FFM_CRG_002()
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

        public ActionResult GetFFMCRG_002()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFM_CRG_002Service.GetFFM_CRG_002(list[0].CmpyCode));
            }
        }

        [Route("EditFFM_CRG_002")]
        public ActionResult EditFFM_CRG_002(string FFM_CRG_JOB_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {


                return PartialView(_FFM_CRG_002Service.EditFFM_CRG_002(list[0].CmpyCode, FFM_CRG_JOB_CODE));
            }
        }


        [Route("DeleteFFM_CRG_002")]
        public ActionResult DeleteCRG_002(string FFM_CRG_JOB_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFM_CRG_002Service.DeleteFFM_CRG_002(list[0].CmpyCode, FFM_CRG_JOB_CODE, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddFFM_CRG_002()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFM_CRG_002Service.GetFFM_CRG_002AddNew(list[0].CmpyCode));
            }
        }

        [HttpPost]
        [Route("SaveFFM_CRG_002")]
        public ActionResult SaveCRG_002(FFM_CRG_002_VM FFMCRG_002)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FFMCRG_002.CMPYCODE = list[0].CmpyCode;
                FFMCRG_002.UserName = list[0].user_name;
                return Json(_FFM_CRG_002Service.SaveFFM_CRG_002(FFMCRG_002), JsonRequestBehavior.AllowGet);
            }
        }




        #endregion
    }
}