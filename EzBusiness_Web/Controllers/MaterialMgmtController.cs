using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MaterialMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers
{
    public class MaterialMgmtController : Controller
    {
        IMaterialMgmtService _materialService;
        
        public MaterialMgmtController()
        {
            _materialService = new MaterialMgmtService();
            
        }

        #region Unit Master
        [Route("UnitMaster")]
        public ActionResult UnitMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_materialService.GetUnits(list[0].CmpyCode));
            }
        }

        [Route("Units")]
        public ActionResult Units()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_materialService.GetUnits(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("UnitTypes")]
        public ActionResult GetUnitTypes()
        {
            return Json(_materialService.GetUnitTypes(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveUnit(UnitVM UnitMaster)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_materialService.SaveUnit(list[0].CmpyCode,UnitMaster), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteUnit")]
        public ActionResult DeleteUnit(string Code, string CmpyCode)
        {
            return Json(new { DeleteFlag = _materialService.DeleteUnit(Code, CmpyCode) }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Material Request


        #endregion
    }
}