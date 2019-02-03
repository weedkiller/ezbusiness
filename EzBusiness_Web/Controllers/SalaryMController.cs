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
    public class SalaryMController : Controller
    {
        ISalaryMpayrollService _SalzService;

        public SalaryMController()
        {
            _SalzService = new SalaryMpayrollService();

        }

        #region Salary Master
        [Route("SalaryM")]
        public ActionResult SalaryM()
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


        [Route("EditSalary")]
        public ActionResult EditSalaryDetailM(string CMPYCODE, string PRSM001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_SalzService.GetSalaryEdit(list[0].CmpyCode, PRSM001_CODE));
            }
        }

        public ActionResult AddSalaryDetailM(string CMPYCODE, string PRSM001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_SalzService.GetSalaryNew(list[0].CmpyCode, PRSM001_CODE));
            }
        }


        //public ActionResult GetDeduct(string CmpyCode, string Code, DateTime effdate)
        //{
        //    return Json(_SalrService.GetDeduct(CmpyCode, Code, effdate), JsonRequestBehavior.AllowGet);
        //}
        [Route("GetSalGrid")]
        public ActionResult GetSalGrid(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_SalzService.GetSalGrid(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        //[Route("GetContractMY")]
        //public ActionResult GetContractMY(string CmpyCode, string Code)
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_SalrService.GetContractMY(list[0].CmpyCode, Code), JsonRequestBehavior.AllowGet);
        //    }
        //}
        public ActionResult GetSryList(string CMPYCODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_SalzService.GetSryList(list[0].CmpyCode));
            }
        }

        [Route("EmpCN")]
        public ActionResult GetEmpCodes()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_SalzService.GetEmpCodes(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult GetAccountCodes(string CmpyCode)
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_SalzService.GetAccountCodes(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
        //    }
        //}
        [HttpPost]
        [Route("SaveSry")]
        public ActionResult SaveSry(SalarMpayrollVM Sry)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Sry.CMPYCODE = list[0].CmpyCode;
                Sry.UserName = list[0].user_name;
                return Json(_SalzService.SaveSry(Sry), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("DeleteSry")]
        public ActionResult DeleteSry(string CMPYCODE, string PRSM001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _SalzService.DeleteSry(list[0].CmpyCode, PRSM001_CODE, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}