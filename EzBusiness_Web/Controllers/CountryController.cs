using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EzBusiness_Web.Controllers
{
    public class CountryController : Controller
    {
        ICountryResourcesService _CountrysService;

        public CountryController()
        {
            _CountrysService = new CountryResourcesService();

        }

        #region Country Master
        [Route("Country")]
        public ActionResult CountryMaster(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return View(_CountrysService.GetCountrys(list[0].CmpyCode));
            }
        }

        [Route("Country1")]
        public ActionResult Country(string CmpyCode )
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_CountrysService.GetCountrys(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public ActionResult SaveCountrys(CountryVM Countrys)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                Countrys.UserName = list[0].user_name;
                Countrys.CmpyCode = list[0].CmpyCode;
                return Json(_CountrysService.SaveCountrys(Countrys), JsonRequestBehavior.AllowGet);
            }
        }

        [Route("DeleteCountrys")]
        public ActionResult DeleteCountrys(string Code, string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _CountrysService.DeleteCountrys(Code, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Countrys Request


        #endregion
    }
}