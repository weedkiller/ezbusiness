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
    public class FFM_CLAUSEController : Controller
    {
        IFMM_CLAUSE_FrightService _ClauseService;

        public FFM_CLAUSEController()
        {
            _ClauseService = new FFM_CLAUSEFrightService();
        }

        #region FFM_CLAUSE Master
        [Route("FFM_CLAUSEMaster")]
        public ActionResult FFM_CLAUSE(string CmpyCode)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return View(_ClauseService.GetFFM_CLAUSE(list[0].CmpyCode));
            }
        }



        [HttpPost]
        //[Route("SaveFNMBranch")]
        public ActionResult saveFFM_CLAUSE(FFM_CLAUSE_VM Fcur)
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
                return Json(_ClauseService.SaveFFM_CLAUSE(Fcur), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteFFM_CLAUSE")]
        public ActionResult DeleteFFM_CLAUSE(string FFM_CLAUSE_Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _ClauseService.DeleteFFM_CLAUSE(FFM_CLAUSE_Code, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        [Route("EditFFM_CLAUSE")]
        public ActionResult EditFFM_CLAUSE(string FFM_CLAUSE_Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_ClauseService.EditFFM_CLAUSE(list[0].CmpyCode, FFM_CLAUSE_Code), JsonRequestBehavior.AllowGet);
            }
        }
    }
}