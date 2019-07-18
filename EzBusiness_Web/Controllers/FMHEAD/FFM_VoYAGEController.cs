using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service.FreightManagementBLS;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FMHEAD
{
    public class FFM_VoYAGEController : Controller
    {
        // GET: FFM_VoYAGE
        IFFM_VOYAGEServices _FFMVoyagServices;

        public FFM_VoYAGEController()
        {
            _FFMVoyagServices = new FFM_VOYAGEService();
        }
        [Route("VoyaGEDataMaster")]
        public ActionResult VoyaGEData()
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
        [HttpPost]
        public ActionResult SaveFFM_Voyage(FFM_VOYAGE_VM Fcur)
        {

            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Fcur.CMPYCODE = list[0].CmpyCode;
                Fcur.UserName = list[0].user_name;
                return Json(_FFMVoyagServices.SaveFFM_Voyage(Fcur), JsonRequestBehavior.AllowGet);

            }

        }
        [Route("GetVessalCode")]
        public ActionResult GetVessalCode(string Prefix)
       {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_FFMVoyagServices.GetVessalCode(list[0].CmpyCode,Prefix), JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditVoyagMaster")]
        public ActionResult EditVoyagMaster(string VyogCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFMVoyagServices.EditVoyagMaster(list[0].CmpyCode,VyogCode));
            }
        }
       
        public ActionResult GetvayogeMasterList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFMVoyagServices.GetFFM_VoYAGEAList(list[0].CmpyCode));
            }
        }
        public ActionResult AddVoageYMaster()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_FFMVoyagServices.AddVoyageMaster(list[0].CmpyCode));
            }
        }
        [Route("DeleteVoyagMaster")]
        public ActionResult DeleteVoyagMaster(string Voyagecode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _FFMVoyagServices.DeleteVoyagMaster(list[0].CmpyCode, Voyagecode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("GetNameByVessalCode")]
        public ActionResult GetNameByVessalCode(string VessalCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
               
             return Json(new {Vessalname = _FFMVoyagServices.GetNameByVessalCode(VessalCode,list[0].CmpyCode) }, JsonRequestBehavior.AllowGet);
              
            }
        }

       
    }
}