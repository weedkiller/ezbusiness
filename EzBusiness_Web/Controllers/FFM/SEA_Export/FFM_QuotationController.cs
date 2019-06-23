using EzBusiness_BL_Service.FreightManagementBLS.SEA_Export;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FFM.SEA_Export
{
    public class FFM_QuotationController : Controller
    {
        // GET: FFM_Quotation

       FF_QTNService _QTNService;

        public FFM_QuotationController()
        {
            _QTNService = new FF_QTNService();
        }

        [Route("Quotation")]
        public ActionResult FFM_Quotation()
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



        [Route("DeleteQuotation")]
        public ActionResult DeleteFF_QTN(string FF_QTN001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _QTNService.DeleteFF_QTN(FF_QTN001_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditFF_QTNDetails")]
        public ActionResult FF_QTNDetailsEdit(string FF_QTN001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_QTNService.GetFF_QTNDetailsEdit(list[0].CmpyCode, FF_QTN001_CODE));
            }
        }

        [Route("AddFF_QTNDetails")]
        public ActionResult AddFF_QTNDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_QTNService.GetFF_QTN_AddNew(list[0].CmpyCode));
            }
        }

        public ActionResult GetFF_QTN002DetailList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_QTNService.GetFF_QTN(list[0].CmpyCode));
            }
        }
        [Route("SaveFFM_Quotation")]
        public ActionResult saveFFM_CLAUSE(FF_QTN_VM FQV)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FQV.CMPYCODE = list[0].CmpyCode;
                FQV.UserName = list[0].user_name;
                return Json(_QTNService.SaveFF_QTN_VM(FQV), JsonRequestBehavior.AllowGet);
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
                return Json(_QTNService.GetVOYAGEList(list[0].CmpyCode, VESSEL), JsonRequestBehavior.AllowGet);
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
                return Json(_QTNService.GetCurRate(list[0].CmpyCode, CurCode), JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetCust(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCust(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCurcode(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCurcode(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetUnitcode(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetUnitcode(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetVendor(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetVendor(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCLAUSE(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCLAUSE(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCRG_002(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCRG_002(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetDepart(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetDepart(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetMoveCode(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetMoveCode(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetVESSELList(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetVESSELList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetPortList(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetPortList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetContTyp(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetContTyp(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetCommodityistList(String CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_QTNService.GetCommodityistList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

    }
}