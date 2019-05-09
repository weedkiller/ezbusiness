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
    public class FNMCATController : Controller
    {
        // GET: FNMCAT

        IFNMCATFreightService _FNMCATService;

        public FNMCATController()
        {
            _FNMCATService = new FNMCATFreightService();

        }

        #region FNMCAT Master
        [Route("FMCategoryMaster")]
        public ActionResult FNMCATMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FNMCATService.GetFNMCAT(list[0].CmpyCode));
            }
        }
        [HttpPost]
        public ActionResult SaveFNMCAT(FNMCAT_VM FC)
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
                return Json(_FNMCATService.SaveFNMCAT(FC), JsonRequestBehavior.AllowGet);

            }

        }

        [Route("DeleteFNMCAT")]
        public ActionResult DeleteFNMCAT(string FNMCAT_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FNMCATService.DeleteFNMCAT(FNMCAT_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}