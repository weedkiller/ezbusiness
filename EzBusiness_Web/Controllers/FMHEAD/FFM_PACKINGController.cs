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
    public class FFM_PACKINGController : Controller
    {
        // GET: FFM_PACKING
        FFM_PACKINGService _fpkgService;

        public FFM_PACKINGController()
        {
            _fpkgService = new FFM_PACKINGService();
        }

        #region PACKING Master
        [Route("PACKINGMASTER")]
        public ActionResult FFM_PACKING(string CmpyCode)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return View(_fpkgService.GetFFM_PACKING(list[0].CmpyCode));
            }
        }



        [HttpPost]
        //[Route("SaveFNMBranch")]
        public ActionResult SaveFFM_PACKING(FFM_PACKING_VM fpk)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                fpk.CMPYCODE = list[0].CmpyCode;
                fpk.UserName = list[0].user_name;
                return Json(_fpkgService.SaveFFM_PACKING(fpk), JsonRequestBehavior.AllowGet);
            }
        }


        [Route("DeleteFFM_PACKING")]
        public ActionResult DeleteFFM_PACKING(string PACKING_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _fpkgService.DeleteFFM_PACKING(PACKING_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        [Route("EditFFM_PACKING")]
        public ActionResult EditFFM_PACKING(string PACKING_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_fpkgService.EditFFM_PACKING(list[0].CmpyCode, PACKING_CODE), JsonRequestBehavior.AllowGet);
            }
        }
    }
}