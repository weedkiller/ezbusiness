using EzBusiness_BL_Service.FreightManagementBLS.SEA_Export;

using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FFM.SEA_Import
{
    public class FFBLIMPController : Controller
    {
        // GET: FFBLIMP
        FF_BLService _BLService;

        public FFBLIMPController()
        {
            _BLService = new FF_BLService();
        }


        [Route("Aprrove_IMPBLL")]
        public ActionResult Aprrove_QTN(string FF_BL001_CODE, string Typ)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { StatusFlag = _BLService.Aprrove_QTN(list[0].CmpyCode, FF_BL001_CODE, list[0].user_name, Typ, list[0].BraCode, "FF_BL001") }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("IMPBILL")]
        public ActionResult FF_BL()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_BLService.GetFF_BL_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }

        [Route("DeleteIMPBL")]
        public ActionResult DeleteFF_BL(string FF_BL001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _BLService.DeleteFF_BL(FF_BL001_CODE, list[0].CmpyCode, list[0].user_name, list[0].BraCode) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditIMP_BLDetails")]
        public ActionResult FF_BLDetailsEdit(string FF_BL001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BLService.GetFF_BLDetailsEdit(list[0].CmpyCode, FF_BL001_CODE, list[0].BraCode));
            }
        }

        [Route("AddIMP_BLDetails")]
        public ActionResult AddFF_BLDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BLService.GetFF_BL_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }


        public ActionResult GetFF_BLDetailList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_BLService.GetFF_BL(list[0].CmpyCode, list[0].BraCode, "IMP"));
            }
        }
        [Route("SaveIMP_BL")]
        public ActionResult saveFFM_BL(FF_BL_VM FBV)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FBV.CMPYCODE = list[0].CmpyCode;
                FBV.UserName = list[0].user_name;
                return Json(_BLService.SaveFF_BL_VM(FBV), JsonRequestBehavior.AllowGet);
            }
        }
    }
}