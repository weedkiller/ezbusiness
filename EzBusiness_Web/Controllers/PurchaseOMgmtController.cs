using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.PurchaseMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers
{
    public class PurchaseOMgmtController : Controller
    {


        IPurchaseMgmtOService _purchaseService;
        // GET: PurchaseOMgmt
        public PurchaseOMgmtController()
        {
            _purchaseService = new PurchaseMgmtOService();
            //  _masterService = new MasterService();
        }



        #region Purchase Request

        [Route("PurchaseOrder")]
        public ActionResult PurchaseOrder()

        {
            return View();
        }



        public ActionResult SiteOrder()
        {
            return View();
        }


        public ActionResult GetPurchaseOrderList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_purchaseService.GetPurchaseOrderList(list[0].CmpyCode));
            }
        }

        [Route("EditPurchaseOrdernew")]
        public ActionResult EditPurchaseOrder(string POCode, string restyp)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_purchaseService.GetPOMasterDetailsEdit(list[0].CmpyCode, POCode, restyp));
            }
        }

        public ActionResult AddPurchaseOrder()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_purchaseService.GetPOMasterDetailsNew(list[0].CmpyCode));
            }
        }
        [HttpPost]
        [Route("SavePurchaseOrder")]
        public ActionResult SavePurchaseOrder(PurchaseOrderVM purchaseOrder)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                purchaseOrder.CmpyCode =list[0].CmpyCode;
                return Json(_purchaseService.SavePurchaseOrder(purchaseOrder), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeletePurchaseOrder")]
        public ActionResult DeletePurchaseOrder(string POCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _purchaseService.DeletePurchaseOrder(list[0].CmpyCode, POCode) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetItemCodeDescription(string itemCode, string restyp)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_purchaseService.GetItemCodeDescription(list[0].CmpyCode, itemCode, restyp), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetItemCodeList(string restyp)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_purchaseService.GetItemCodeList(list[0].CmpyCode, restyp), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSupplierList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_purchaseService.GetSupplierList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetPOFromList()
        {
            return Json(_purchaseService.GetPOFromList("POType"), JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetCurList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_purchaseService.GetCurList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult GetDivisionList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_purchaseService.GetDivisionList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult GetPOReqList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_purchaseService.GetPOReqList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        //[Route ("ReqPurchase")]
        public ActionResult GetPOItemReqList(string MRCode)
        {
            //    return Json(_purchaseService.GetPOItemReqListnew("UM", MRCode), JsonRequestBehavior.AllowGet);
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_purchaseService.GetPOItemReqListnew(list[0].CmpyCode, MRCode));
            }
        }
        public ActionResult GetPOItemReqDetList(string MRCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_purchaseService.GetPOItemReqDetList(list[0].CmpyCode, MRCode), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}