using EzBusiness_BL_Interface.FinanceManagementBLI;
using EzBusiness_BL_Service.FinanceManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FinaceMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FNM
{
    public class FNM_SLController : Controller
    {
        // GET: FNM_SL
        IFNM_SL1001Service _FNM_SLService;

        public FNM_SLController()
        {
            _FNM_SLService = new FNM_SL1001Service();

        }

        #region  FNMSupplier Master
      //  [Route("SubLedgre")]
        [Route("subledger")]
        public ActionResult FNMSupplier()
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
        [Route("OprationalCustomer")]
        public ActionResult FNMOprationalCustomer()
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
        public ActionResult GetSupplier(string Sublesertype)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FNM_SLService.GetFNM_SL(list[0].CmpyCode,Sublesertype));
            }
        }

        [Route("EditSupplier")]
        public ActionResult EditSupplier(string Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FNM_SLService.EditFNM_SL(list[0].CmpyCode, Code));
            }
        }


        [Route("DeleteSupplier")]
        public ActionResult DeleteSupplier(string FNM_SL1001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FNM_SLService.DeleteFNM_SL1001(list[0].CmpyCode, FNM_SL1001_CODE, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AddSupplier()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FNM_SLService.GetFNM_SLAddNew(list[0].CmpyCode));
            }
        }

        [HttpPost]
        [Route("SaveSupplier")]
        public ActionResult SaveFNM_SL(FNM_SL_VM FNM)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FNM.CMPYCODE = list[0].CmpyCode;
                FNM.UserName = list[0].user_name;
                FNM.DIVISION = list[0].Divcode;
                return Json(_FNM_SLService.SaveFNM_SL(FNM), JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult GetCatDropDetailList(string SUBLEDGER_TYPE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_FNM_SLService.GetFNM_SL1002Add(list[0].CmpyCode, SUBLEDGER_TYPE), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCatDropDetailListFilter(string SUBLEDGER_TYPE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_FNM_SLService.GetFNMCAT(list[0].CmpyCode, SUBLEDGER_TYPE), JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}