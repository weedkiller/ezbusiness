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
    public class FNMGROUPController : Controller
    {
        // GET: FNMGROUP
        IFNMGROUPFreightService _FNMGROUPService;

        public FNMGROUPController()
        {
            _FNMGROUPService = new FNMGROUPFreightService();

        }
        #region FNMGROUP Master
        [Route("FMGROUP")]
        public ActionResult FNMGROUPMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FNMGROUPService.GetFNMGROUP(list[0].CmpyCode));
            }
        }
        [HttpPost]
        public ActionResult SaveFNMGROUP(FNMGROUP_VM FG)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FG.CMPYCODE = list[0].CmpyCode;
                FG.UserName = list[0].user_name;
                return Json(_FNMGROUPService.SaveFNMGROUP(FG), JsonRequestBehavior.AllowGet);

            }

        }

        [Route("DeleteFNMGROUP")]
        public ActionResult DeleteFNMGROUP(string FNMGROUP_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FNMGROUPService.DeleteFNMGROUP(FNMGROUP_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}