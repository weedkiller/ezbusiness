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
    public class FNMSUBGROUPController : Controller
    {
        // GET: FNMSUBGROUP
        // GET: FNMGROUP
        IFNMSUBGROUPFreightService _FNMSUBGROUPService;

        public FNMSUBGROUPController()
        {
            _FNMSUBGROUPService = new FNMSUBGROUPFreightService();

        }
        #region FNMSUBGROUP Master
        [Route("FMSUBGROUP")]
        public ActionResult FNMSUBGROUPMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FNMSUBGROUPService.GetFNMSUBGROUP(list[0].CmpyCode));
            }
        }
        [HttpPost]
        public ActionResult SaveFNMSUBGROUP(FNMSUBGROUP_VM FSG)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FSG.CMPYCODE = list[0].CmpyCode;
                FSG.UserName = list[0].user_name;
                return Json(_FNMSUBGROUPService.SaveFNMSUBGROUP(FSG), JsonRequestBehavior.AllowGet);

            }

        }

        [Route("DeleteFNMSUBGROUP")]
        public ActionResult DeleteFNMSUBGROUP(string FNMSUBGROUP_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FNMSUBGROUPService.DeleteFNMSUBGROUP(FNMSUBGROUP_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}