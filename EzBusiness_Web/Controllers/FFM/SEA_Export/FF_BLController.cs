using EzBusiness_BL_Service.FreightManagementBLS.SEA_Export;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FFM.SEA_Export
{
    public class FF_BLController : Controller
    {
        // GET: FFM_BL

        FF_BLService _BLService;
        FF_BOKService _bkservice;
        public FF_BLController()
        {
            _BLService = new FF_BLService();
        }

        [Route("BILL")]
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

        [Route("DeleteBL")]
        public ActionResult DeleteFF_BL(string FF_BL001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _BLService.DeleteFF_BL(FF_BL001_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditFF_BLDetails")]
        public ActionResult FF_BLDetailsEdit(string FF_BL001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BLService.GetFF_BLDetailsEdit(list[0].CmpyCode, FF_BL001_CODE,list[0].BraCode));
            }
        }

        [Route("AddFF_BLDetails")]
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
        [Route("GetCustomerList")]
        public ActionResult GetCustomerList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BLService.GetSL(list[0].CmpyCode,Prefix), JsonRequestBehavior.AllowGet);
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

                return PartialView(_BLService.GetFF_BL(list[0].CmpyCode,list[0].BraCode));
            }
        }
        [Route("SaveFFM_BL")]
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

        public ActionResult GetVESSELCodeList(string VESSEL)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BLService.GetVOYAGEList(list[0].CmpyCode, VESSEL), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCurRate(string CurCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BLService.GetCurRate(list[0].CmpyCode, CurCode), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("BLFF_BOKDetails")]
        public ActionResult FF_BOKDetailsBL(string FF_BOK001_CODE1)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BLService.GetFF_BLDetailsBk(list[0].CmpyCode, FF_BOK001_CODE1));
            }
        }
    }
}