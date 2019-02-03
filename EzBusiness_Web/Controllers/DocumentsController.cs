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
    public class DocumentsController : Controller
    {
        IDocumentsPayrollService _DokService;

        public DocumentsController()
        {
            _DokService = new DocumentsPayrollService();

        }

        #region Documents Master
        [Route("Documents")]
        public ActionResult DocumentsMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_DokService.GetDoks(list[0].CmpyCode));
            }
        }

        [Route("Doks")]
        public ActionResult Doks()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_DokService.GetDoks(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]

        public ActionResult SaveDoks(DocumentsVM Doks)
        {
           
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Doks.CmpyCode = list[0].CmpyCode;
                Doks.UserName = list[0].user_name;
                return Json(_DokService.SaveDoks(Doks), JsonRequestBehavior.AllowGet);

            }
        }

        [Route("DeleteDoks")]
        public ActionResult DeleteDoks(string DocCode, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _DokService.DeleteDoks(DocCode, CmpyCode, list[0].CmpyCode) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Doks Request


        #endregion
    }
}