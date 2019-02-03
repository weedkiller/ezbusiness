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
    public class EmpBankController : Controller
    {
        IEmpBankPayRollService _bkService;

        public EmpBankController()
        {
            _bkService = new EmpBankPayRollService();

        }

        #region EmpBank Master
        [Route("EmpBankMaster")]
        public ActionResult EmpBankMaster()
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

       
        public ActionResult AddEmpBankMaster()
        {
            List<SessionListnew> list = Session ["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_bkService.GetEmpBankPayRollNew(list[0].CmpyCode));
           }
        }
        [Route("EditEmpBankMaster")]
        public ActionResult EditEmpBankMaster(string PRBM003_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_bkService.GetEmpBankPayRollEdit(list[0].CmpyCode , PRBM003_CODE));
            }
        }
        public ActionResult GetEmpBankMasterList()
       {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_bkService.GetEmpBnkList(list[0].CmpyCode));
            }
        }

        //[Route("EMPz")]
        //public ActionResult GetEmpCodes()
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_bkService.GetEmpCodes(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
        //    }
        //}
        //[Route("Cda")]
        //public ActionResult GetPRBM001_code()
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_bkService.GetPRBM001_code(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
        //    }
        //}
       
        public ActionResult GetPRBM002_code(string PRBM001_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_bkService.GetPRBM002_code(list[0].CmpyCode, PRBM001_code), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Route("SaveEmpBnk")]
        public ActionResult SaveEmpBnk(EmpBankVM EmpBnk)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                EmpBnk.CmpyCode = list[0].CmpyCode;
                EmpBnk.UserName = list[0].user_name;
                return Json(_bkService.SaveEmpBnk(EmpBnk), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteEmpBnk")]
        public ActionResult DeleteEmpBnk(string PRBM003_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _bkService.DeleteEmpBnk(list[0].CmpyCode, PRBM003_CODE, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Material Request


        #endregion
    }
}