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
        public ActionResult GetQuotation()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_QTNService.GetFF_QTN(list[0].CmpyCode));
            }
        }
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
                return Json(_QTNService.GetFF_QTNDetailsEdit(list[0].CmpyCode, FF_QTN001_CODE), JsonRequestBehavior.AllowGet);
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
                return Json(_QTNService.GetFF_QTN_AddNew(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
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

                return View(_QTNService.GetFF_QTN(list[0].CmpyCode));
            }
        }
        public ActionResult saveFFM_CLAUSE(FF_QTN_VM Fcur)
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
                return Json(_QTNService.SaveFF_QTN_VM(Fcur), JsonRequestBehavior.AllowGet);
            }
        }
    }
}