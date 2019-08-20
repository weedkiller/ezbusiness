using EzBusiness_BL_Service.FinanceManagementBLS.Vouchers;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FNM.Voucher
{
    public class CrDrNoteController : Controller
    {
        // GET: CrDrNote


        CreditNoteJobService _CrDrService;

        public CrDrNoteController()
        {
            _CrDrService = new CreditNoteJobService();
        }

        [Route("CreditNote")]
        public ActionResult CreditNote()
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

        [Route("DebitNote")]
        public ActionResult DebitNote()
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

        [Route("DeleteCrDrNote")]
        public ActionResult DeleteCrDrNote(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _CrDrService.DeleteFNINV(FNINV001_CODE, list[0].CmpyCode, list[0].user_name, list[0].BraCode) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("EditCreditNoteDetails")]
        public ActionResult CreditNoteDetailsEdit(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CrDrService.GetFNINVDetailsEdit(list[0].CmpyCode, FNINV001_CODE, list[0].BraCode));
            }
        }

        [Route("AddCreditNoteDetails")]
        public ActionResult AddCreditNoteDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CrDrService.GetCredit_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }


        [Route("AddDebitNoteDetails")]
        public ActionResult AddDebitNoteDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CrDrService.GetDebit_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }


        [Route("EditDebitNoteDetails")]
        public ActionResult DebitNoteDetailsEdit(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CrDrService.GetFNINVDetailsEdit(list[0].CmpyCode, FNINV001_CODE, list[0].BraCode));
            }
        }

        public ActionResult GetCrDrDetailList(string Module_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_CrDrService.GetFNINV(list[0].CmpyCode, list[0].BraCode, Module_Type));
            }
        }
        [Route("SaveCrDrNote")]
        public ActionResult SaveCrDrNote(FNINV001_VM FQV)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FQV.cmpycode = list[0].CmpyCode;
                FQV.UserName = list[0].user_name;
                FQV.BRANCHCODE = list[0].BraCode;
                return Json(_CrDrService.SaveFNINV_VM(FQV), JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult GETBLNO(string CustCode, string Module_Type,string Type_Choose)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.GETBLNO(list[0].CmpyCode, list[0].BraCode, CustCode, Module_Type, Type_Choose), JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetCustSupp2(string Prefix,string Choose_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.GetCustSupp(list[0].CmpyCode, list[0].BraCode, "DBNTJ", Choose_Type, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCustSupp1(string Prefix, string Choose_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.GetCustSupp(list[0].CmpyCode, list[0].BraCode, "CRNTJ", Choose_Type, Prefix), JsonRequestBehavior.AllowGet);
            }
        }


        [Route("BLCrdrGE")]
        public ActionResult Bl_InvoiceGenerateLates(string BLCode, string Customer_code, string ExCode, string ExRate, string Table_Name, string Module_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { BLGENFlag = _CrDrService.Bl_InvoiceGenerateLates(list[0].CmpyCode, list[0].BraCode, BLCode, Customer_code, ExCode, ExRate, Table_Name, Module_Type, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("InvoiceCrdrGE")]
        public ActionResult BlCrdr_InvoiceGenerateLates(string InvCode, string Table_Name, string Module_Type,string InvModule_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { BLGENFlag = _CrDrService.BlCrdr_InvoiceGenerateLates(list[0].CmpyCode, list[0].BraCode, InvCode,Table_Name, Module_Type, InvModule_Type, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        

        public ActionResult GetHeaderDetail(string BLNO)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.GetHeaderDetail(list[0].CmpyCode, BLNO, list[0].BraCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetFNINV002DetailList(string BLNO)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CrDrService.GetFNINV002DetailList(list[0].CmpyCode, BLNO, list[0].BraCode), JsonRequestBehavior.AllowGet);
            }
        }

    }
}