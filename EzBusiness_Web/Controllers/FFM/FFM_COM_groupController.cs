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

namespace EzBusiness_Web.Controllers.FFM
{
    public class FFM_COM_groupController : Controller
    {

        IFFM_COM_groupService _FFMCOMgroupService;

        public FFM_COM_groupController()
        {
            _FFMCOMgroupService = new FFM_COM_groupService();

        }

        #region FFM_COM_Group Master
        [Route("COMGroupMaster")]
        public ActionResult FFM_COM_Group()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FFMCOMgroupService.GetFFM_COM_group(list[0].CmpyCode));
            }
        }

        [HttpPost]
        public ActionResult SaveFFM_COM_group(FFM_COM_GROUP_VM FC)
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
                return Json(_FFMCOMgroupService.SaveFFM_COM_GROUP(FC), JsonRequestBehavior.AllowGet);
            }

        }

        [Route("DeleteFFM_COM_group")]
        public ActionResult DeleteFFM_COM_group(string FFM_COM_Group_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFMCOMgroupService.DeleteFFM_COM_group(FFM_COM_Group_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}