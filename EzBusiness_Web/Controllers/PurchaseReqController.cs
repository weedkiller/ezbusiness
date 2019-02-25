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
    public class PurchaseReqController : Controller
    {
        IPurchaseReqService _purchaseService;
       // IMasterService _masterService;
        public PurchaseReqController()
        {
            _purchaseService = new PurchaseReqService();
          //  _masterService = new MasterService();
        }



        #region Purchase Request

        [Route("PurchaseReq")]
        public ActionResult PurchaseRequest()
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



        public ActionResult SiteRequest()
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

        [Route("EditPurchaseReq")]
        public ActionResult EditPurchaseOrder(string MRCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_purchaseService.GetPOMasterDetailsEdit(list[0].CmpyCode, MRCode));
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

        [Route("SavePurchaseReq")]        
        public ActionResult SavePurchaseOrder(PurchaseReqVM purchaseOrder)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                purchaseOrder.CmpyCode = list[0].CmpyCode;
                return Json(_purchaseService.SavePurchaseOrder(purchaseOrder), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeletePurchaseReq")]
        public ActionResult DeletePurchaseOrder(string MRCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _purchaseService.DeletePurchaseOrder(list[0].CmpyCode, MRCode) }, JsonRequestBehavior.AllowGet);
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
        #endregion
    }
}