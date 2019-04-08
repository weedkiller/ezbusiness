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
    public class SalaryProcessPaymentController : Controller
    {
        // GET: SalaryProcessPayment
        IsalaryProcessPaymentService _SalpaymntService;

        public SalaryProcessPaymentController()
        {
            _SalpaymntService = new salaryProcessPaymentService();
        }
        [Route("SalaryProcessPayment")]
        public ActionResult SalaryProcessPayment()
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
    
        public ActionResult GetSalaryprocessPymntDetailList()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_SalpaymntService.GetSalaryprocessPymntDetailList(list[0].CmpyCode));
            }
        }
        public ActionResult AddSalesProcessPayment()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_SalpaymntService.GetNewbtnsalaryPrcesspaymentDetails(list[0].CmpyCode));

                // return PartialView(); 
            }
        }
        [Route("GetSalaryProcessDetails")]
        public ActionResult GetSalaryProcessDetails(SalaryProcessDVM slryVM)
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
                    slryVM.CMPYCODE = list[0].CmpyCode;
                    List<SalaryprocesspaymentDetails> data = _SalpaymntService.GetSalaryPrcessDetailsList(slryVM);
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
                                               p.EMPCODE.ToLower().Contains(search.ToLower()) ||
                                               p.EMPNAME.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.BANKCODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.BANKName.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.BANkBrachName.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.BRANCHCODE.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.ACCOUNTNO.ToString().ToLower().Contains(search.ToLower())).ToList();
                        //p.ProfCode.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.DepCode.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.ComnPrjcode.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.Division.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.VisaLocation.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.WorkLocation.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.Total_Days.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.Worked_Days.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.VisaLocation.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.loan_amt.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.adn_amount.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.nothrs.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.extraOThrs.ToString().ToLower().Contains(search.ToLower()) ||
                        //p.hothrs.ToString().ToLower().Contains(search.ToLower())).ToList();
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
        private List<SalaryprocesspaymentDetails> salaryprocessColumnWithOrder(string order, string orderDir, List<SalaryprocesspaymentDetails> data)
        {
            // Initialization.
            List<SalaryprocesspaymentDetails> lst = new List<SalaryprocesspaymentDetails>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EMPCODE).ToList()
                                                                                                 : data.OrderBy(p => p.EMPCODE).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EMPNAME).ToList()
                                                                                                 : data.OrderBy(p => p.EMPNAME).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BANKCODE).ToList()
                                                                                                 : data.OrderBy(p => p.BANKCODE).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BANKName).ToList()
                                                                                                   : data.OrderBy(p => p.BANKName).ToList();
                        break;
                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BRANCHCODE).ToList()
                                                                                                   : data.OrderBy(p => p.BRANCHCODE).ToList();
                        break;
                    case "7":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BANkBrachName).ToList()
                                                                                                   : data.OrderBy(p => p.BANkBrachName).ToList();
                        break;

                  


                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ACCOUNTNO).ToList()
                                                                                                 : data.OrderBy(p => p.ACCOUNTNO).ToList();
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
        public ActionResult SaveSalryProcessPaymentDetails(SalaryProcessDVM salarym)

        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                salarym.CMPYCODE = list[0].CmpyCode;
                salarym.UserName = list[0].user_name;
                return Json(_SalpaymntService.SaveSalryProcessPaymentDetails(salarym), JsonRequestBehavior.AllowGet);
            }
        }


        [Route("GetEmployeeNotInBank")]
        public ActionResult GetEmployeeNotInBank(string CurrentDate, string divcode, string Deptcode, string VisaLocation1)
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
                    data = _SalpaymntService.GetBankNotDetails(list[0].CmpyCode, Convert.ToDateTime(CurrentDate), divcode, Deptcode, VisaLocation1);
                }
            }
            catch (Exception ex)
            {

            }
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);

        }



        [Route("EditSalaryProcessPayment")]
        public ActionResult EditSalaryProcessPayment(string salP_code)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_SalpaymntService.GetsalryprocessPaymentEdit(list[0].CmpyCode, salP_code));
            }
        }

        public ActionResult DeleteSalaryProcessPayment(string SalCode, string currdate)
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
                if (_SalpaymntService.DeleteSalaryProcessPayment(list[0].CmpyCode, SalCode, Convert.ToDateTime(currdate.ToString()), list[0].user_name))
                    breturn = true;
                else
                    breturn = false;
                //  }
                return Json(breturn, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult GetSalaryProcessPaymentGridEdit(string SalCode,string paidtype)
        {
            //DateTime processDate = Convert.ToDateTime(SPDate.ToString());
            //string year = processDate.ToString("yyyy");
            //string month = processDate.ToString("MM");
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;

            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return Json(_SalpaymntService.GetSalaryProcessPaymentGridEdit(list[0].CmpyCode, SalCode, paidtype), JsonRequestBehavior.AllowGet);
            }
        }
    }


}