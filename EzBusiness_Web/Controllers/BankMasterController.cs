using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers
{
    public class BankMasterController : Controller
    {
        IBankMasterPayrollService _BnkService;

        public BankMasterController()
        {
            _BnkService = new BankMasterPayrollService();

        }

        #region Bank Master
        [Route("BankMaster")]
        public ActionResult BankMaster()
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


        [Route("EditBankMaster")]
        public ActionResult EditBank(string CmpyCode, string PRBM001_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BnkService.GetBnkEdit(list[0].CmpyCode, PRBM001_code));
            }
        }

        public ActionResult AddBankDetail(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BnkService.GetBnkNew(list[0].CmpyCode));
            }
        }


       
        [Route("GetBnkGrid")]
        public ActionResult GetBnkGrid(string CmpyCode, string PRBM002_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BnkService.GetBnkGrid(list[0].CmpyCode, PRBM002_code), JsonRequestBehavior.AllowGet);
            }
        }
       
        public ActionResult GetBnkList(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_BnkService.GetBnkList(list[0].CmpyCode));
            }
        }

      
        public ActionResult GetCountryCodes()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_BnkService.GetCountryCodes(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [Route("SaveBnk")]
        public ActionResult SaveBnk(BankMasterVM Bnk)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                Bnk.UserName = list[0].user_name;               
                Bnk.CmpyCode = list[0].CmpyCode;
                return Json(_BnkService.SaveBnk(Bnk), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("DeleteBnk")]
        public ActionResult DeleteBnk(string PRBM001_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _BnkService.DeleteBnk(list[0].CmpyCode, PRBM001_code, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("UseBnkBranch")]
        public ActionResult UseBnkBranch(string PRBM001_code, string PRBM002_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _BnkService.UseBnkBranch(list[0].CmpyCode, PRBM001_code, PRBM002_code) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}