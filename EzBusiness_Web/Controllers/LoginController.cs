using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        ILoginService _loginService;
        // IMasterService _masterService;
        public LoginController()
        {
            _loginService = new LoginService();
            //  _masterService = new MasterService();
        }


        public ActionResult InLogin(LoginVM LoginVM)
        {
            return View();
        }


        [HttpGet]
        [Route("Index")]
        public ActionResult Index()//LoginVM LoginVM
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




        [Route("InLogin1")]
        public ActionResult InLogin1(LoginVM LoginVM)
        {       
            return Json(_loginService.SaveLons(LoginVM), JsonRequestBehavior.AllowGet);
            //_loginService.SaveLons(LoginVM);
            //if (HttpContext.Session["SesDet"].ToString() != null)
            //{
                //return RedirectToAction("Index", "Test1");
                //return Redirect("www.google.com");
               // Response.Redirect("www.google.com");
            //}
           // return View(LoginVM);
        }


        [Route("CompanyCode")]
        public ActionResult CompanyCode()
        {
            return Json(_loginService.GetCompanyList(), JsonRequestBehavior.AllowGet);
        }

        [Route("DivisionCode")]
        public ActionResult DivisionCode(string CmpyCode)
        {
            return Json(_loginService.GetDivisionList(CmpyCode), JsonRequestBehavior.AllowGet);
        }

        [Route("BranchCode")]
        public ActionResult BranchCode(string CmpyCode, string DivCode)
        {
            return Json(_loginService.GetBranchList(CmpyCode,DivCode), JsonRequestBehavior.AllowGet);
        }
        [Route("DepartmentCode")]
        public ActionResult DepartmentCode(string CmpyCode, string DivCode,string Branchcode)
        {
            return Json(_loginService.GetDepartmentList(CmpyCode, DivCode,Branchcode), JsonRequestBehavior.AllowGet);
        }

        [Route("Logout")]
        public ActionResult Sess()
        {

            //List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            //Session.Remove(list.ToString());
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            list = null;
            Session["SesDet"] = list;
            

            return Redirect("Login/InLogin");
        }
       


    }
}