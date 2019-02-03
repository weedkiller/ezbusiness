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
    public class VisaLocationController : Controller
    {
        IVisaLocationPayrollService _VlService;

        IMenuItemRightsUService _MenuRights;
        public VisaLocationController()
        {
            _VlService = new VisaLocationPayrollService();
            _MenuRights = new MenuItemRightsUService();
        }

        #region VisaLocation Master
        [Route("VisaLocation")]
        
        public ActionResult VisaLocationMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {              
                string rpath1 = (string)this.RouteData.Values["controller"];
                if(list[0].Utype=="U")
                {
                  bool t=  _MenuRights.GetAuthority(list[0].CmpyCode, list[0].user_name, rpath1);
                    if (t == false)
                        return Redirect("Login/InLogin");
                }
                
                return View(_VlService.GetVls(list[0].CmpyCode));
            }
        }

        [Route("Vls")]
        public ActionResult Vls()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_VlService.GetVls(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveVls(VisaLocationVM Vls)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Vls.CmpyCode = list[0].CmpyCode;
                Vls.UserName = list[0].user_name;
                return Json(_VlService.SaveVls(Vls), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteVls")]
        public ActionResult DeleteVls(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _VlService.DeleteVls(Code,list[0].CmpyCode,list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Vls Request


        #endregion
    }
}