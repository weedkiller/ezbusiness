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
    public class FFM_COMController : Controller
    {
        // GET: FFM_COM

        IFFM_COMFreightService _FFMCOMService;

        public FFM_COMController()
        {
            _FFMCOMService = new FFM_COMFreightService();

        }

        #region FFM_COM Master
        [Route("COMCategoryMaster")]
        public ActionResult FFM_COM_Master()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FFMCOMService.GetFFM_COM(list[0].CmpyCode));
            }
        }

        [HttpPost]
        public ActionResult SaveFFM_COM(FFM_COM_VM FC)
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
                return Json(_FFMCOMService.SaveFFM_COM(FC), JsonRequestBehavior.AllowGet);
            }

        }

        [Route("DeleteFFM_COM")]
        public ActionResult DeleteFFM_COM(string FFM_COM_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFMCOMService.DeleteFFM_COM(FFM_COM_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("COMGROUP")]
        public ActionResult COMGROUPCode(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_FFMCOMService.GetFFM_COM_GROUP(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }


        }
        #endregion
    }
}