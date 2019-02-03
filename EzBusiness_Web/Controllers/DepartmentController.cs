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
    public class DepartmentController : Controller
    {
        IDepartmentPayrollService _DepService;

        public DepartmentController()
        {
            _DepService = new DepartmentPayrollService();
        }

        #region Department Master
        [Route("Department")]
        public ActionResult DepartmentMaster(string CmpyCode)
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

                return View(_DepService.GetDeps(list[0].CmpyCode));
            }
        }

        [Route("Deps")]
        public ActionResult Deps(string CmpyCode )
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DepService.GetDeps(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveDeps(DepartmentVM Deps)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Deps.CmpyCode = list[0].CmpyCode;
                Deps.UserName = list[0].user_name;
                return Json(_DepService.SaveDeps(Deps), JsonRequestBehavior.AllowGet);
            }
        }

      
        [Route("Commontable2")]
        public ActionResult DivisionCode(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DepService.GetDivisionList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }


        }


        [Route("Commontable3")]
        public ActionResult BranchCode(string CmpyCode, string Divcode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DepService.GetBranchCode(list[0].CmpyCode,Divcode), JsonRequestBehavior.AllowGet);
            }


        }

        [Route("DepartmentCode")]
        public ActionResult DepartmentCode(string CmpyCode, string DivCode, string Branchcode)
        {
            return Json(_DepService.GetDepartmentList(CmpyCode, DivCode, Branchcode), JsonRequestBehavior.AllowGet);
        }


        [Route("DeleteDeps")]
        public ActionResult DeleteDeps(string DepartmentCode, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _DepService.DeleteDeps(DepartmentCode, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Lons Request


        #endregion
    }
}