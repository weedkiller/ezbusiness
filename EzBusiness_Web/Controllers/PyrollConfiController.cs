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
    public class PyrollConfiController : Controller
    {
        IPyrollConfiService _PyrollService;
        public PyrollConfiController()
        {
            _PyrollService = new PyrollConfiService();

        }
        // GET: PyrollConfi
        #region PyrollConfi
        [Route("PyrollConfi")]
        public ActionResult PyrollConfi()
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
       // [Route("AddPyrollConfi")]
        public ActionResult AddPyrollConfi()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_PyrollService.GetPayrollNew(list[0].CmpyCode));
            }
        }

        public ActionResult GetPyrollConfiList()

        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_PyrollService.GetPyrollConfiList(list[0].CmpyCode));
            }
        }    
        [HttpPost]

        [Route("SavePyrollConfi")]
        public ActionResult SavePyrollConfi(PyrollConfi_Vm Pyroll)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Pyroll.UserName = list[0].user_name;
                Pyroll.CMPYCODE = list[0].CmpyCode;
                return Json(_PyrollService.SavePyrollConfi(Pyroll), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeletePyroll")]
        public ActionResult DeletePyroll(string Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _PyrollService.DeletePyrollConfi(Code , list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditPyroll")]
        public ActionResult EditPyroll(string Code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView( _PyrollService.GetPyrollConfiDet( list[0].CmpyCode, Code) );
            }
        }
        #endregion
    }
}