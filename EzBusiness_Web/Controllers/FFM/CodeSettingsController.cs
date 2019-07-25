using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FFM
{
    public class CodeSettingsController : Controller
    {
        // GET: CodeSettings



        CodeSettingsService _CodeService;
      
        public CodeSettingsController()
        {
            _CodeService = new CodeSettingsService();
        }
        [Route("CodeSettings")]
        public ActionResult CodeSettings()
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

        [Route("DeleteCodeSettings")]
        public ActionResult DeleteCodeSettings(string Tablename)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _CodeService.DeleteCodeSettings(list[0].CmpyCode, list[0].BraCode,Tablename, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditCodeSettings")]
        public ActionResult CodeSettingsEdit(string Tablename)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CodeService.EditCodeSettings(list[0].CmpyCode, list[0].BraCode, Tablename));
            }
        }

        [Route("AddCodeSettings")]
        public ActionResult AddCodeSettings()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_CodeService.Get_CodeServiceAddNew());
            }
        }
        [Route("GetUsernameList")]
        public ActionResult GetUsernameList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CodeService.GetUsername(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("GetTableList")]
        public ActionResult GetTableList(string Prefix)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CodeService.GetTblname(Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetCodeSettings()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_CodeService.GetCodeSettings(list[0].CmpyCode, list[0].BraCode));
            }
        }
        [Route("SaveCodeSettings")]
        public ActionResult saveFFM_BL(UTM0001_VM UTM)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                UTM.Cmpycode = list[0].CmpyCode;
                UTM.UserName = list[0].user_name;
                UTM.Branchcode = list[0].BraCode;
                return Json(_CodeService.SaveCodeSettings(UTM), JsonRequestBehavior.AllowGet);
            }
        }

    }
}