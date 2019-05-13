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
    public class FNM_CURRENCYController : Controller
    {
        // GET: FNM_CURRENCY


        IFNM_CURRENCYService _CURRService;

        public FNM_CURRENCYController()
        {
            _CURRService = new FNM_CURRENCYService();
        }

        #region CURRENC Master
        [Route("CURRENCYMaster")]
        public ActionResult FNM_CURRENCY(string CmpyCode)
        {
            

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return View(_CURRService.GetFNM_CURRENCY(list[0].CmpyCode));
            }
        }



        [HttpPost]
        //[Route("SaveFNMBranch")]
        public ActionResult SaveFNMBranch(FNM_CURRENCY_VM Fcur)
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
                return Json(_CURRService.SaveFNM_CURRENCY(Fcur), JsonRequestBehavior.AllowGet);
            }
        }



        [Route("DeleteFNM_CURRENCY")]
        public ActionResult DeleteFNM_CURRENCY(string CURRENCYCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _CURRService.DeleteFNM_CURRENCY(CURRENCYCode, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        [Route("EditFNM_CURRENCY")]
        public ActionResult EditFNM_CURRENCY(string CURRENCYCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CURRService.EditFNM_CURRENCY(list[0].CmpyCode, CURRENCYCode), JsonRequestBehavior.AllowGet);
            }
        }
    }
}