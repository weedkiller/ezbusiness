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
    public class FNMTYPEController : Controller
    {
        // GET: FNMTYPE
        IFNMTYPEFreightService _FNMTYPEService;

        public FNMTYPEController()
        {
            _FNMTYPEService = new FNMTYPEFreightService();

        }
        #region FNMTYPE Master
        [Route("FMTYPE")]
        public ActionResult FNMTYPEMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FNMTYPEService.GetFNMTYPE(list[0].CmpyCode));
            }
        }
        [HttpPost]
        public ActionResult SaveFNMTYPE(FNMTYPE_VM FT)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FT.CMPYCODE = list[0].CmpyCode;
                FT.UserName = list[0].user_name;
                return Json(_FNMTYPEService.SaveFNMTYPE(FT), JsonRequestBehavior.AllowGet);

            }

        }

        [Route("DeleteFNMTYPE")]
        public ActionResult DeleteFNMTYPE(string FNMTYPE_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FNMTYPEService.DeleteFNMTYPE(FNMTYPE_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}