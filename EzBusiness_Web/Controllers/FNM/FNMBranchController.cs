﻿using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FMHEAD
{
    public class FNMBranchController : Controller
    {
        // GET: FNMBranch

        IFNMBranchFrightService _branchService;

        public FNMBranchController()
        {
            _branchService = new FNMBranchFrightServices();
        }

        #region Branch Master
        [Route("Branch_Master")]
        public ActionResult FNMBranch(string CmpyCode)
        {
            // string ab = Session["SesDet"].ToString();

            // var list = Session["SesDet"] as List<object>;

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
       
        public ActionResult GetFNM_BranchDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_branchService.GetFNMBranch(list[0].CmpyCode));
            }
        }
        [Route("GetCountryCodes")]
        public ActionResult GetCountryCodes(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_branchService.GetCountryCodes(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("GetCountryCodesList")]
        public ActionResult GetCountryCodesList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_branchService.GetCountryCodesList(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("GetCurrencyCodes")]
        public ActionResult GetCurrencyCodes(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_branchService.GetCurrencyCodes(Prefix), JsonRequestBehavior.AllowGet);
            }
        }

       
        public ActionResult GetDivisionList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_branchService.GetDivisionList(list[0].CmpyCode,Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        [Route("SaveFNMBranch")]
        public ActionResult SaveFNMBranch(FNMBranch_VM brnch)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                brnch.CMPYCODE = list[0].CmpyCode;
                brnch.UserName = list[0].user_name;
                return Json(_branchService.SaveFNMBranch(brnch), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteFNMBranch")]
        public ActionResult DeleteFNMBranch(string branchCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _branchService.DeleteFNMBranch(branchCode, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        [Route("EditFNMBranch")]
        public ActionResult EditFNMBranch(string branchCode)
        {        
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_branchService.EditFNMBranch(list[0].CmpyCode,branchCode));
            }
        }
    
        public ActionResult GetMasterCode()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_branchService.GetMasterCode(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("AddFNM_Branch")]
        public ActionResult AddFNM_Branch()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_branchService.AddNewFNM_Branch(list[0].CmpyCode));
            }
        }
    }

}
