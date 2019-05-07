using EzBusiness_BL_Interface.FreightManagement;
using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagement;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FMHEAD
{
    public class FMHEADController : Controller
    {
        // GET: FMHEAD
        IFMHeadFreightService _FMHService;

        public FMHEADController()
        {
            _FMHService = new FMHeadFreightService();

        }

        #region FMHEAD Master
        [Route("FMHEAD")]
        public ActionResult FMHEADMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_FMHService.GetFMHEAD(list[0].CmpyCode));
            }
        }

        //[Route("FMHEAD1")]
        //public ActionResult FMHEAD1()
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_FMHService.GetFMHEAD(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
        //    }
        //}



        [HttpPost]
        public ActionResult SaveFMHEAD(FMHEAD_VM FMH)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FMH.CMPYCODE = list[0].CmpyCode;
                FMH.UserName = list[0].user_name;
                return Json(_FMHService.SaveFMHEAD(FMH), JsonRequestBehavior.AllowGet);

            }

        }

        [Route("DeleteFMHEAD")]
        public ActionResult DeleteFMHEAD(string FNMHEAD_CODE, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FMHService.DeleteFMHEAD(FNMHEAD_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region FMHEAD Request


        #endregion
    }
}