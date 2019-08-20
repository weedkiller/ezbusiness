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
    public class FNINV001Controller : Controller
    {
        // GET: FNINV001

        FNINV001Service _INVService;

        public FNINV001Controller()
        {
            _INVService = new FNINV001Service();
        }
        [Route("CUSTOMERINVOICE")]
        public ActionResult FNINV001()
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

        [Route("SUPPLIERINVOICE")]
        public ActionResult FNPIVJV001()
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

        [Route("DeleteINVOICE")]
        public ActionResult DeleteFNINV(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _INVService.DeleteFNINV(FNINV001_CODE, list[0].CmpyCode, list[0].user_name, list[0].BraCode) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("EditINVOICEDetails")]
        public ActionResult INVOICEDetailsEdit(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_INVService.GetFNINVDetailsEdit(list[0].CmpyCode, FNINV001_CODE, list[0].BraCode));
            }
        }

        [Route("AddINVOICEDetails")]
        public ActionResult AddINVOICEDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_INVService.GetFNINV_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }


        [Route("AddSupplierDetails")]
        public ActionResult AddSupplierDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_INVService.GetSUPINV_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }


        [Route("EditSupplierDetails")]
        public ActionResult SupplierDetailsEdit(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_INVService.GetFNINVDetailsEdit(list[0].CmpyCode, FNINV001_CODE, list[0].BraCode));
            }
        }

        public ActionResult GetINVOICEDetailList(string Module_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_INVService.GetFNINV(list[0].CmpyCode, list[0].BraCode, Module_Type));
            }
        }
        [Route("SaveINVOICE")]
        public ActionResult saveINVOICE(FNINV001_VM FQV)
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
                return Json(_INVService.SaveFNINV_VM(FQV), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCRG_002(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_INVService.GetCRG_002(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GETBLNO(string CustCode, string Module_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_INVService.GETBLNO(list[0].CmpyCode, list[0].BraCode,CustCode, Module_Type), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSupplier(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_INVService.GetSupli(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GETBLNODetails(string CustCode, string BLNO)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_INVService.GETBLNODetails(list[0].CmpyCode, list[0].BraCode,BLNO), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCustSupp2(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_INVService.GetCustSupp(list[0].CmpyCode, list[0].BraCode, "PIVJV", Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCustSupp1(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_INVService.GetCustSupp(list[0].CmpyCode, list[0].BraCode, "INVJV", Prefix), JsonRequestBehavior.AllowGet);
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
                return Json(_INVService.GetFNINV002DetailList(list[0].CmpyCode, BLNO, list[0].BraCode), JsonRequestBehavior.AllowGet);
            }
        }


        [Route("BLInvoiceGE")]
        public ActionResult Bl_InvoiceGenerateLates(string BLCode, string Customer_code, string ExCode, string ExRate, string Table_Name, string Module_Type)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { BLGENFlag = _INVService.Bl_InvoiceGenerateLates(list[0].CmpyCode, list[0].BraCode, BLCode, Customer_code, ExCode, ExRate, Table_Name,Module_Type, list[0].user_name) }, JsonRequestBehavior.AllowGet);
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
                return Json(_INVService.GetHeaderDetail(list[0].CmpyCode, BLNO, list[0].BraCode), JsonRequestBehavior.AllowGet);
            }
        }
        
    }
}