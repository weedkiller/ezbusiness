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
    }
}