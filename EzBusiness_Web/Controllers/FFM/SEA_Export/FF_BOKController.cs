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
    public class FF_BOKController : Controller
    {
        // GET: FFM_BOK

        FF_BOKService _BOKService;

        public FF_BOKController()
        {
            _BOKService = new FF_BOKService();
        }

        [Route("BOOKING")]
        public ActionResult FF_BOK()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_BOKService.GetFF_BOK_AddNew(list[0].CmpyCode));
            }
        }



        [Route("DeleteBOK")]
        public ActionResult DeleteFF_BOK(string FF_BOK001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _BOKService.DeleteFF_BOK(FF_BOK001_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditFF_BOKDetails")]
        public ActionResult FF_BOKDetailsEdit(string FF_BOK001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BOKService.GetFF_BOKDetailsEdit(list[0].CmpyCode, FF_BOK001_CODE));
            }
        }

        [Route("QuotFF_BOKDetails")]
        public ActionResult FF_BOKDetailsQuot(string FF_BOK001_CODE1)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BOKService.GetFF_BOKDetailsQuot(list[0].CmpyCode, FF_BOK001_CODE1));
            }
        }

        [Route("AddFF_BOKDetails")]
        public ActionResult AddFF_BOKDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BOKService.GetFF_BOK_AddNew(list[0].CmpyCode));
            }
        }

        public  ActionResult GetBill_No_Data()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BOKService.GetPortList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetFF_BOK002DetailList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_BOKService.GetFF_BOK(list[0].CmpyCode));
            }
        }
        [Route("SaveFFM_BOK")]
        public ActionResult saveFFM_BOK(FF_BOK_VM FBV)
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
                return Json(_BOKService.SaveFF_BOK_VM(FBV), JsonRequestBehavior.AllowGet);
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
                return Json(_BOKService.GetVOYAGEList(list[0].CmpyCode, VESSEL), JsonRequestBehavior.AllowGet);
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
                return Json(_BOKService.GetCurRate(list[0].CmpyCode, CurCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSLList1()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BOKService.GetSL(list[0].CmpyCode,"FM"), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSLList2()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BOKService.GetSL(list[0].CmpyCode, "OP"), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetQTNCODE()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                DateTime dt = System.DateTime.Now;
                return Json(_BOKService.GetQTNCODE(list[0].CmpyCode, dt), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GETJobTypList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BOKService.GETJobTypList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
    }
}