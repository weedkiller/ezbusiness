using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_Web.Controllers.FMHEAD
{
    public class FFM_PORTController : Controller
    {
        // GET: FFM_PORT
        IFFM_PORTService _fpService;
        public FFM_PORTController()
        {
            _fpService = new FFM_PORTService();
        }

        #region PORT Master
        [Route("PORTMASTER")]
        public ActionResult FFM_PORT(string CmpyCode)
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
        //[OutputCache(Duration =5)]
        public ActionResult GetPortList()
        {
            JsonResult result = new JsonResult();
            try
            {
                List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
                if (list == null)
                {
                    return Redirect("Login/InLogin");
                }
                else
                {
                    // Initialization.
                    string search = Request.Form.GetValues("search[value]")[0];
                    string draw = Request.Form.GetValues("draw")[0];
                    string order = Request.Form.GetValues("order[0][column]")[0];
                    string orderDir = Request.Form.GetValues("order[0][dir]")[0];
                    int startRec = Convert.ToInt32(Request.Form.GetValues("start")[0]);
                    int pageSize = Convert.ToInt32(Request.Form.GetValues("length")[0]);

                    string FFM_PORT_CODE1= Request.Form.GetValues("columns[0][search][value]").FirstOrDefault();
                    string NAME1 = Request.Form.GetValues("columns[1][search][value]").FirstOrDefault();
                    string COUNTRY1 = Request.Form.GetValues("columns[2][search][value]").FirstOrDefault();
                    string TERMINAL1 = Request.Form.GetValues("columns[3][search][value]").FirstOrDefault();
                    string LATITUDE1 = Request.Form.GetValues("columns[4][search][value]").FirstOrDefault();
                    string LANGITUDE1 = Request.Form.GetValues("columns[5][search][value]").FirstOrDefault();
                    string DISPLY_STATUS1 = Request.Form.GetValues("columns[6][search][value]").FirstOrDefault();

                    if (pageSize == -1)
                    {
                        draw = "2";
                    }

                    List<FFM_PORT_VM> data = _fpService.GetFFM_PORT(list[0].CmpyCode);
                    // Total record count.
                    int totalRecords = 0;
                    if (data != null)
                    {
                        totalRecords = data.Count;
                    }
                    else
                        totalRecords = 0;
                    // Verification.
                    if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
                    {
                        // Apply search
                        data = data.Where(p => p.FFM_PORT_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.NAME.ToLower().Contains(search.ToLower()) ||
                                               p.COUNTRY.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.TERMINAL.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.LATITUDE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.LANGITUDE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.DISPLY_STATUS.ToString().ToLower().Contains(search.ToLower())
                                              ).ToList();
                      
                    }

                    if (!string.IsNullOrEmpty(FFM_PORT_CODE1) &&
                        !string.IsNullOrWhiteSpace(FFM_PORT_CODE1))
                    {
                        data = data.Where(p => p.FFM_PORT_CODE.ToString().ToLower().Contains(FFM_PORT_CODE1.ToLower())                                             
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(NAME1) &&
                       !string.IsNullOrWhiteSpace(NAME1))
                    {
                        data = data.Where(p => p.NAME.ToString().ToLower().Contains(NAME1.ToLower())
                                              ).ToList();
                    }

                    if (!string.IsNullOrEmpty(COUNTRY1) &&
                       !string.IsNullOrWhiteSpace(COUNTRY1))
                    {
                        data = data.Where(p => p.COUNTRY.ToString().ToLower().Contains(COUNTRY1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(TERMINAL1) &&
                      !string.IsNullOrWhiteSpace(TERMINAL1))
                    {
                        data = data.Where(p => p.TERMINAL.ToString().ToLower().Contains(TERMINAL1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(LATITUDE1) &&
                     !string.IsNullOrWhiteSpace(LATITUDE1))
                    {
                        data = data.Where(p => p.LATITUDE.ToString().ToLower().Contains(LATITUDE1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(LANGITUDE1) &&
                     !string.IsNullOrWhiteSpace(LANGITUDE1))
                    {
                        data = data.Where(p => p.LANGITUDE.ToString().ToLower().Contains(LANGITUDE1.ToLower())
                                              ).ToList();
                    }
                    if (!string.IsNullOrEmpty(DISPLY_STATUS1) &&
                   !string.IsNullOrWhiteSpace(DISPLY_STATUS1))
                    {
                        data = data.Where(p => p.DISPLY_STATUS.ToString().ToLower().Contains(DISPLY_STATUS1.ToLower())
                                              ).ToList();
                    }

                    // Sorting.
                    data = this.salaryprocessColumnWithOrder(order, orderDir, data);

                    // Filter record count.
                    int recFilter = data.Count;


                    if (pageSize != -1)
                    {
                        data = data.Skip(startRec).Take(pageSize).ToList();
                    }
                    else
                    {
                        data = data.ToList();
                    }

                    // Loading drop down lists.
                    result = this.Json(new { draw = Convert.ToInt32(draw), recordsTotal = totalRecords, recordsFiltered = recFilter, data = data }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Return info.
            return result;
        }
        private List<FFM_PORT_VM> salaryprocessColumnWithOrder(string order, string orderDir, List<FFM_PORT_VM> data)
        {
            // Initialization.
            List<FFM_PORT_VM> lst = new List<FFM_PORT_VM>();
            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.FFM_PORT_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.FFM_PORT_CODE).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.NAME).ToList()
                                                                                                 : data.OrderBy(p => p.NAME).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.COUNTRY).ToList()
                                                                                                 : data.OrderBy(p => p.COUNTRY).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TERMINAL).ToList()
                                                                                                 : data.OrderBy(p => p.TERMINAL).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LATITUDE).ToList()
                                                                                                   : data.OrderBy(p => p.LATITUDE).ToList();
                        break;
                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LANGITUDE).ToList()
                                                                                                   : data.OrderBy(p => p.LANGITUDE).ToList();
                        break;
               
                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DISPLY_STATUS).ToList()
                                                                                                 : data.OrderBy(p => p.DISPLY_STATUS).ToList();
                        break;

                }
            }
            catch (Exception ex)
            {
                // info.
                Console.Write(ex);
            }

            // info.
            return lst;

        }
        [Route("EditFFM_PORT")]
        public ActionResult EditFFM_PORT(string CmpyCode, string FFM_PORT_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_fpService.EditFFM_PORT(list[0].CmpyCode, FFM_PORT_CODE));
            }
        }
        public ActionResult AddFFM_PORT(string CmpyCode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_fpService.NewFFM_PORT(list[0].CmpyCode));
            }
        }
        [HttpPost]
        public ActionResult SaveFFM_PORT(FFM_PORT_VM fpk)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                fpk.CMPYCODE = list[0].CmpyCode;
                fpk.UserName = list[0].user_name;
                return Json(_fpService.SaveFFM_PORT(fpk), JsonRequestBehavior.AllowGet);
            }
        }


        [Route("DeleteFFM_PORT")]
        public ActionResult DeleteFFM_PORT(string FFM_PORT_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(new { DeleteFlag = _fpService.DeleteFFM_PORT(FFM_PORT_CODE, list[0].CmpyCode, list[0].user_name) }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        [Route("EditFFM_PORT_CODE")]
        public ActionResult EditFFM_PORT(string FFM_PORT_CODE)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_fpService.EditFFM_PORT(list[0].CmpyCode, FFM_PORT_CODE), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult GetCountry(string Prefix)
            {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Json("Login/InLogin");
            }
            else
            {
                return Json(_fpService.GetCountryList1(list[0].CmpyCode, Prefix), JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult GetCountry1()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Json("Login/InLogin");
            }
            else
            {
                return Json(_fpService.GetCountryList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
    }
}