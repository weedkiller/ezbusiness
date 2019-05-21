using EzBusiness_BL_Interface.FreightManagement;
using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagement;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FMHEAD
{
    public class FNM_AC_COAController : Controller
    {
        // GET: FNM_AC_COA

        IFNM_AC_COAService _FNM_AC_COAService;

        public FNM_AC_COAController()
        {
            _FNM_AC_COAService = new FNM_AC_COAFrightService();

        }

        #region  FNM_AC_COA Master
        [Route("AccountType")]
        public ActionResult FNMAccountType()
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

        public ActionResult GetAccountType()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FNM_AC_COAService.GetFNM_AC_COA(list[0].CmpyCode));
            }
        }

        [Route("EditAccountType")]
        public ActionResult EditAccountType(string Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FNM_AC_COAService.EditFNM_AC_COA(list[0].CmpyCode, Code));
            }
        }


        [Route("DeleteAccountTypeS")]
        public ActionResult DeleteAccountType(string Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FNM_AC_COAService.DeleteFNM_Ac_COA(list[0].CmpyCode, Code,  list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddAccountType()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FNM_AC_COAService.GetFNM_AC_COAAddNew(list[0].CmpyCode));
            }
        }

        [HttpPost]
        [Route("SaveAccountType")]
        public ActionResult SaveDrs(FNM_AC_COA_VM FNM)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FNM.COMPANY_UID = list[0].CmpyCode;
                FNM.UserName = list[0].user_name;
                return Json(_FNM_AC_COAService.SaveFNM_AC_COA(FNM), JsonRequestBehavior.AllowGet);
            }
        }


        #endregion
    }
}