using EzBusiness_BL_Service.FreightManagementBLS.SEA_Export;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FFM.SEA_Export
{
    public class FNINV001Controller : Controller
    {
        // GET: FNINV001

        FNINV001Service _INVService;

        public FNINV001Controller()
        {
            _INVService = new FNINV001Service();
        }
        [Route("INVOICE")]
        public ActionResult FNINV001()
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

        [Route("DeleteINVOICE")]
        public ActionResult DeleteFNINV(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _INVService.DeleteFNINV(FNINV001_CODE, list[0].CmpyCode, list[0].user_name, list[0].BraCode) }, JsonRequestBehavior.AllowGet);
            }
        }

        [Route("EditINVOICEDetails")]
        public ActionResult INVOICEDetailsEdit(string FNINV001_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_INVService.GetFNINVDetailsEdit(list[0].CmpyCode, FNINV001_CODE, list[0].BraCode));
            }
        }

        [Route("AddINVOICEDetails")]
        public ActionResult AddINVOICEDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_INVService.GetFNINV_AddNew(list[0].CmpyCode, list[0].BraCode));
            }
        }

        public ActionResult GetINVOICEDetailList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {

                return PartialView(_INVService.GetFNINV(list[0].CmpyCode, list[0].BraCode));
            }
        }
        [Route("SaveINVOICE")]
        public ActionResult saveINVOICE(FNINV001_VM FQV)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                FQV.cmpycode = list[0].CmpyCode;
                FQV.UserName = list[0].user_name;
                return Json(_INVService.SaveFNINV_VM(FQV), JsonRequestBehavior.AllowGet);
            }
        }
    }
}