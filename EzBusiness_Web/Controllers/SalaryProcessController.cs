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
    public class SalaryProcessController : Controller
    {

        ISalaryProcessDService _SalService;

        public SalaryProcessController()
        {
            _SalService = new SalaryProcessDServices();
        }

        [Route("SalaryProcess")]
        public ActionResult SalaryProcess()
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
        public ActionResult AddSalesProcess()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_SalService.GetSalaryProcessDetailList(list[0].CmpyCode));

                // return PartialView(); 
            }
        }
        //public ActionResult GetSalaryProcessId()
        //{
        //    List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
        //    if (list == null)
        //    {
        //        return Redirect("Login/InLogin");
        //    }
        //    else
        //    {
        //        return Json(_SalService.GetSalaryProcessId(list[0].CmpyCode), JsonRequestBehavior.AllowGet);

        //    }
        //}
        [Route("GetTimeSheetDetailsByMonth")]
       public ActionResult GetTimeSheetDetailsByMonth(string CurrentDate,string divcode,string Deptcode,string VisaLocation1)
        {
            List<SalaryProcessDetailsListItem> data = null;
            try
            {
                List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
                if (list == null)
                {
                    return Redirect("Login/InLogin");
                }
                else
                {
                    data = _SalService.GetTimeSheetDetailsByMonth(list[0].CmpyCode,Convert.ToDateTime(CurrentDate), divcode,Deptcode,VisaLocation1);
                }
            }
            catch(Exception ex)
            {

            }
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);

        }
        [Route("GetCalculatedSalary")]
        public ActionResult GetCalculatedSalaryDetails(SalaryProcessDetailsVM slryVM)
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

                    if (pageSize == -1)
                    {
                        draw = "2";
                    }
                    List<SalaryProcessDetailsListItem> data = _SalService.GetSalaryProcessGrid(list[0].CmpyCode, slryVM.Process_Date,slryVM.DivisionCode,slryVM.Deptcode,slryVM.VisaLocation1);
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
                        data = data.Where(p => p.srno.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Empcode.ToLower().Contains(search.ToLower()) ||
                                               p.Empname.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.country.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Tmonth.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Tyear.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.cmpycode.ToString().ToLower().Contains(search.ToLower())||
                                               p.ProfCode.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.DepCode.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.ComnPrjcode.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Division.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.VisaLocation.ToString().ToLower().Contains(search.ToLower()) ||
                        p.WorkLocation.ToString().ToLower().Contains(search.ToLower()) ||
                        p.Total_Days.ToString().ToLower().Contains(search.ToLower()) ||
                        p.Worked_Days.ToString().ToLower().Contains(search.ToLower()) ||
                        p.VisaLocation.ToString().ToLower().Contains(search.ToLower()) ||
                        p.loan_amt.ToString().ToLower().Contains(search.ToLower()) ||
                        p.adn_amount.ToString().ToLower().Contains(search.ToLower()) ||
                        p.nothrs.ToString().ToLower().Contains(search.ToLower()) ||
                        p.extraOThrs.ToString().ToLower().Contains(search.ToLower()) ||
                        p.hothrs.ToString().ToLower().Contains(search.ToLower())).ToList();
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
        [HttpPost]
        [Route("SaveSalaryProcess")]
        public ActionResult SaveSalaryProcess(SalaryProcessDetailsVM salarym)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                salarym.CmpyCode = list[0].CmpyCode;
                salarym.UserName = list[0].user_name;
                return Json(_SalService.SaveSalaryProcessD(salarym), JsonRequestBehavior.AllowGet);
            }
        }

    //  [Route("DeleteSalaryProcess")]
        public ActionResult DeleteSalaryProcess(string SalCode,string currdate)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                bool breturn = false;
                //string[] Ids = ids.Split(',');
                //foreach (string Id in Ids)
                //{
                    if (_SalService.DeleteSalaryProcess(list[0].CmpyCode, SalCode,Convert.ToDateTime(currdate.ToString()),list[0].user_name))
                        breturn = true;
                    else
                        breturn = false;
              //  }
                return Json(breturn, JsonRequestBehavior.AllowGet);
            }
        }
        [Route("EditSalaryProcess")]
        public ActionResult EditSalaryProcess(string salP_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_SalService.GetSalaryProcessEdit(list[0].CmpyCode, salP_code));
            }
        }
        public ActionResult GetSalaryProcessGridEdit(string SPDate)
        {
            DateTime processDate = Convert.ToDateTime(SPDate.ToString());
            string year = processDate.ToString("yyyy");
            string month = processDate.ToString("MM");
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_SalService.GetSalaryProcessGridEdit(Convert.ToInt32(year.ToString()), Convert.ToInt32(month.ToString()), list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetSalaryDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_SalService.GetSalaryDetailsList(list[0].CmpyCode));
            }
        }

        private List<SalaryProcessDetailsListItem> salaryprocessColumnWithOrder(string order, string orderDir, List<SalaryProcessDetailsListItem> data)
        {
            // Initialization.
            List<SalaryProcessDetailsListItem> lst = new List<SalaryProcessDetailsListItem>();

            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.srno).ToList()
                                                                                                 : data.OrderBy(p => p.srno).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Empcode).ToList()
                                                                                                 : data.OrderBy(p => p.Empcode).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Empname).ToList()
                                                                                                 : data.OrderBy(p => p.Empname).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.country).ToList()
                                                                                                 : data.OrderBy(p => p.country).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Tmonth).ToList()
                                                                                                   : data.OrderBy(p => p.Tmonth).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Tyear).ToList()
                                                                                                   : data.OrderBy(p => p.Tyear).ToList();
                        break;


                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.cmpycode).ToList()
                                                                                                 : data.OrderBy(p => p.cmpycode).ToList();
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
        [Route("CheckslryDataCalculated")]
        public ActionResult CheckslryDataCalculated(string CurrentDate, string divcode, string Deptcode, string VisaLocation1)
        {
            bool flag=false;
            try
            {
                List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
                if (list == null)
                {
                    return Redirect("Login/InLogin");
                }
                else
                {
                    flag = _SalService.CheckslryDataCalculated(list[0].CmpyCode, Convert.ToDateTime(CurrentDate),divcode,Deptcode,VisaLocation1);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(new { data = flag }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDivisionList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_SalService.GetDivCodeList(list[0].CmpyCode), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetDepartmentList(string divcode)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_SalService.GetDepartmentList(list[0].CmpyCode, divcode), JsonRequestBehavior.AllowGet);
            }
        }
    }
}