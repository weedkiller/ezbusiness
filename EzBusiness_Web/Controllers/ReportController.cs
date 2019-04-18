using EzBusiness_BL_Interface;
using EzBusiness_BL_Service;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using EzBusiness_DL_Repository;

namespace EzBusiness_Web.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report

        IReportDetailsServices _reportdetail;

        public ReportController()
        {
            _reportdetail = new ReportDetailService();
        }

        [Route("EmpoloyeeReport")]
        public ActionResult GetEmployeeDetails()
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

        [Route("GetEmpReportDetails")]
        public ActionResult GetEmpReportDetails(Employee emp)
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
                    List<Employee> data = _reportdetail.GetEmpReportDetails(list[0].CmpyCode, emp.Fdate, emp.Tdate, emp.Empname, emp.EmpCode, search);
                    // Total record count.
                    int totalRecords = data.Count;
                    data = _reportdetail.EmpReportDetailsColumnWithOrder(order, orderDir, data);
                    int recFilter = data.Count;
                    if (pageSize != -1)
                        data = data.Skip(startRec).Take(pageSize).ToList();
                    else
                        data = data.ToList();

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
        [Route("FinalSettlementReport")]
        public ActionResult FinalSettlementReportDetails()
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

        [Route("GetFinalSettlementDetails")]
        public ActionResult GetFinalSettlementDetails(FinalSettalment fnl)
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
                    List<FinalSettalment> data = _reportdetail.GetFinalSettlementDetails(list[0].CmpyCode, fnl.Fdate, fnl.Tdate, fnl.EmpName, fnl.EmpCode, search);
                    // Total record count.
                    int totalRecords = data.Count;

                    // Verification.


                    // Sorting.
                    data = _reportdetail.FinalsettlementDetailsColumnWithOrder(order, orderDir, data);

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
        [Route("MonthlyAddDeductReport")]
        public ActionResult MonthlyAddDeductReportDetails()
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

        [Route("GetMonthlyAddDeductDetails")]
        public ActionResult GetMonthlyAddDeductDetails(MonthlyAdddedDet mad)
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
                    List<MonthlyAdddedDet> data = _reportdetail.GetMonthlyAddDeductDetails(list[0].CmpyCode, mad.Fdate, mad.Tdate, mad.EmpName, mad.EmpCode, search);
                    // Total record count.
                    int totalRecords = data.Count;
                    data = _reportdetail.MonthlyAddDeductDetailsColumnWithOrder(order, orderDir, data);

                    // Filter record count.
                    int recFilter = data.Count;

                    if (pageSize != -1)
                        data = data.Skip(startRec).Take(pageSize).ToList();
                    else
                        data = data.ToList();

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
        [Route("LoanApplicatnReport")]
        public ActionResult LoanApplicatnReportDetails()
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


        [Route("GetLoanApplicatnRDetails")]
        public ActionResult GetLoanApplicatnDetails(LoanAppliation lp)
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
                        draw = "2";

                    List<LoanAppliation> data = _reportdetail.GetLoanApplicatnDetails(list[0].CmpyCode, lp.Fdate, lp.Tdate, lp.EmpName, lp.EmpCode, search);
                    // Total record count.
                    int totalRecords = data.Count;
                    // Sorting.
                    data = _reportdetail.LoanApplicatnDetailsColumnWithOrder(order, orderDir, data);
                    // Filter record count.
                    int recFilter = data.Count;
                    if (pageSize != -1)
                        data = data.Skip(startRec).Take(pageSize).ToList();
                    else
                        data = data.ToList();

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
        [Route("HolidayReport")]
        public ActionResult HolidayReportDetails()
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


        [Route("GetHolidayDetails")]
        public ActionResult GetHolidayDetails(Holiday lp)
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
                        draw = "2";

                    List<Holiday> data = _reportdetail.GetHolidayDetails(list[0].CmpyCode, lp.HRPH001_CODE, search);
                    // Total record count.
                    int totalRecords = data.Count;
                    // Sorting.
                    data = _reportdetail.HolidayDetailsColumnWithOrder(order, orderDir, data);
                    // Filter record count.
                    int recFilter = data.Count;
                    if (pageSize != -1)
                        data = data.Skip(startRec).Take(pageSize).ToList();
                    else
                        data = data.ToList();

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

        [Route("LoanReport")]
        public ActionResult LoanReportDetails()
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


        [Route("LoanReportDet")]
        public ActionResult GetLoanDetails(Loan lp)
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
                        draw = "2";

                    List<Loan> data = _reportdetail.GetLoanDetails(list[0].CmpyCode, lp.PRLM001_CODE, lp.Name, search);
                    // Total record count.
                    int totalRecords = data.Count;
                    // Sorting.
                    data = _reportdetail.LoanDetailsColumnWithOrder(order, orderDir, data);
                    // Filter record count.
                    int recFilter = data.Count;
                    if (pageSize != -1)
                        data = data.Skip(startRec).Take(pageSize).ToList();
                    else
                        data = data.ToList();

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

        [Route("ProfessinReport")]
        public ActionResult ProfessinReportDetails()
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


        [Route("GetProfessionReprtDetails")]
        public ActionResult GetProfessionReprtDetails(Profession pf)
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
                        draw = "2";

                    List<Profession> data = _reportdetail.GetProfessionReprtDetails(list[0].CmpyCode, pf.ProfCode, pf.ProfName, search);
                    // Total record count.
                    int totalRecords = data.Count;
                    // Sorting.
                    data = _reportdetail.ProfssnDetailsColumnWithOrder(order, orderDir, data);
                    // Filter record count.
                    int recFilter = data.Count;
                    if (pageSize != -1)
                        data = data.Skip(startRec).Take(pageSize).ToList();
                    else
                        data = data.ToList();

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

        [Route("LeaveApplicationReport")]
        public ActionResult GetLeaveApplReport()
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

        [Route("GetLeaveApplReportDetails")]
        public ActionResult GetLeaveApplReportDetails(LeaveApplication emp1)
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
                    List<LeaveApplication> data = _reportdetail.GetLeaveAppDetails(list[0].CmpyCode, emp1.Fdate, emp1.Tdate, emp1.EmpCode, emp1.EmpName);
                    // Total record count.
                    int totalRecords = data.Count;

                    // Verification.
                    if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
                    {
                        // Apply search
                        data = data.Where(p => p.EmpCode.ToString().ToLower().Contains(search.ToLower()) ||

                                               p.JoiningDate.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.StartDate.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.EndDate.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.TotalBalance.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.LeaveType.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.LeaveDays.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.TotalSanctioned.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.ApprovalYN.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Remarks.ToString().ToLower().Contains(search.ToLower())).ToList();

                    }

                    // Sorting.
                    data = _reportdetail.EmpReportLeaveAppColumnWithOrder(order, orderDir, data);

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
        [Route("LeaveSettlementReport")]
        public ActionResult GetLeaveSettlementReport()
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

        [Route("GetLeaveSettlemenntReportDetails")]
        public ActionResult GetLeaveSettlemenntReportDetails(LeaveSettlement emp2)
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
                    List<LeaveSettlement> data = _reportdetail.GetLeaveSettlemenntReportDetails(list[0].CmpyCode, emp2.Fdate, emp2.Tdate, emp2.Empcode, emp2.EmpName);
                    // Total record count.
                    int totalRecords = data.Count;

                    // Verification.
                    if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
                    {
                        // Apply search
                        data = data.Where(p => p.Empcode.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.LStartDate.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.LendDate.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Sanctioned_Days.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Total_days.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Total_worked_Days.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Total_LE_Days.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.LB_CF_Days.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Leave_Salary.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Addition_amt.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Ticket_amt.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Ticket_Paid.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Pending_Salary.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Advance_Salary.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Advance_Paid.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Actual_Salary.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Net_Pay.ToString().ToLower().Contains(search.ToLower()) ||

                                               p.salary_effect_date.ToString().ToLower().Contains(search.ToLower())).ToList();

                    }

                    // Sorting.
                    data = _reportdetail.EmpLeaveSettlemenntColumnWithOrder(order, orderDir, data);

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
        [Route("DutyResumeReport")]
        public ActionResult GetDutyResumeDetails()
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

        [Route("GetEmpDutyResumeDetails")]
        public ActionResult GetEmpDutyResumeDetails(DutyResume emp1)
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
                    List<DutyResume> data = _reportdetail.GetDutyResumeDetails(list[0].CmpyCode, emp1.Fdate, emp1.Tdate, emp1.EmpCode, emp1.EmpName);
                    // Total record count.
                    int totalRecords = data.Count;

                    // Verification.
                    if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
                    {
                        // Apply search
                        data = data.Where(p => p.EmpCode.ToString().ToLower().Contains(search.ToLower()) ||

                                               p.ResumeDate.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Actual_Leave_Type.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Duty_Rm_type.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Approve_Days.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Excess_Days_plus_minus.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Approve_Days_in_full.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Approve_Days_in_Half.ToString().ToLower().Contains(search.ToLower())).ToList();

                    }

                    // Sorting.
                    data = _reportdetail.EmpReportDutyResumeColumnWithOrder(order, orderDir, data);

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

        [Route("ShiftMasterReport")]
        public ActionResult GetShiftMasterDetails()
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

        [Route("GetEmpShiftMasterDetails")]
        public ActionResult GetEmpShiftMasterDetails(ShiftMaster emp1)
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
                    List<ShiftMaster> data = _reportdetail.GetShiftMasterDetails(list[0].CmpyCode, emp1.PRSFT001_code);
                    // Total record count.
                    int totalRecords = data.Count;

                    // Verification.
                    if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
                    {
                        // Apply search
                        data = data.Where(p => p.ShiftName.ToString().ToLower().Contains(search.ToLower()) ||

                                               p.division.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.country.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.StTime.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.EdTime.ToString().ToLower().Contains(search.ToLower())).ToList();
                    }

                    // Sorting.
                    data = _reportdetail.ShiftMasterReportDetailsColumnWithOrder(order, orderDir, data);

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
        [Route("ProjectReportEmployeeWise")]
        public ActionResult ProjectReportEmployeeWise()
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

        [Route("GetProjectDetailsEmployeeWise")]
        public ActionResult GetProjectDetailsEmployeeWise(TimeSheetDetail emp1)
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

                    List<TimeSheetDetail> data = _reportdetail.GetProjectDetailsEmployeeWise(list[0].CmpyCode, emp1.CurrentDate);
                    // Total record count.
                    int totalRecords = data.Count;
                    // Verification.
                    if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
                    {
                        // Apply search
                        data = data.Where(p => p.EmpCode.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.EmpName.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.ProjectCode.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.ProjectName.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Tyear.ToString().ToLower().Contains(search.ToLower()) ||
                                               p.Tmonth.ToString().ToLower().Contains(search.ToLower())).ToList();
                    }

                    // Sorting.
                    data = _reportdetail.ProjectReportDetailsColumnWithOrder(order, orderDir, data);

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

        [Route("GetSalaryReportDetails")]
        public ActionResult GetSalaryReportDetails(SalaryProcessDetailsRep SPDR)
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
                    List<SalaryProcessDetailsRep> data = _reportdetail.GetSalaryProcessDetails(list[0].CmpyCode, SPDR.Process_Date, SPDR.Division, SPDR.DepCode, SPDR.VisaLocation, search);
                    // Total record count.
                    int totalRecords = data.Count;
                    data = _reportdetail.SalaryProcessDetailsRepColumnWithOrder(order, orderDir, data);
                    int recFilter = data.Count;
                    if (pageSize != -1)
                        data = data.Skip(startRec).Take(pageSize).ToList();
                    else
                        data = data.ToList();

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

        [Route("SalaryReportDetails")]
        public ActionResult SalaryReportDetails()
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                return PartialView(_reportdetail.GetSalaryProcessDetailList(list[0].CmpyCode));

                // return PartialView(); 
            }
        }


        [Route("EmpBankTrfreport")]
        public ActionResult EmpBankTrfreport()
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


        [Route("GetEmpBankTrf")]
        public ActionResult GetEmpBankTrf(DateTime dte)
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

                    List<GetEmpBankTrf> data = _reportdetail.GetEmpBankTrf(list[0].CmpyCode, dte);

                   
                    // Total record count.
                    int totalRecords = data.Count;


                    // Sorting.
                    data = _reportdetail.EmpBankTrfColumnWithOrder(order, orderDir, data);

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
            //return PartialView(_reportdetail.GetEmpBankTrf(list[0].CmpyCode, dte));                
        }
    


        [Route("testrep")]
        public ActionResult Report1()
        {

            ReportViewer rptViewer = new ReportViewer();

            // ProcessingMode will be Either Remote or Local  
            rptViewer.ProcessingMode = ProcessingMode.Remote;
            rptViewer.SizeToReportContent = true;
            rptViewer.ZoomMode = ZoomMode.PageWidth;
           
            rptViewer.AsyncRendering = true;
            //rptViewer.ServerReport.ReportServerUrl = new Uri("http://localhost/ReportServer/");

            //rptViewer.ServerReport.ReportPath = this.SetReportPath();



            rptViewer.ServerReport.ReportServerUrl = new Uri("http://localhost/reportserver");
            rptViewer.ServerReport.ReportPath = "../EzBusinessReport/Report1.rdl";


            ViewBag.ReportViewer = rptViewer;
            return View();
        }


        public ActionResult DailyTimeSheetDetails()
        {
            return View();
        }
        public ActionResult DailyTimeSheetDetailsReport(TimeSheetDetail timerrport)
        {
            List<SessionListnew> list = Session["SesDet"] as List<SessionListnew>;
            if (list == null)
            {
                return Redirect("Login/InLogin");
            }
            else
            {
                List<TimeSheetDetail> AdmReport = _reportdetail.DailyTimeSheetDetailsReport(list[0].CmpyCode,Convert.ToDateTime(timerrport.TDate), Convert.ToDateTime(timerrport.FDate));
                List<TimeSheetDetail> objReportViewList = new List<TimeSheetDetail>();
                foreach (var EMPCode in AdmReport.Select(a => a.EmpCode).Distinct())
                {
                    TimeSheetDetail objReportView = new TimeSheetDetail();
                    string Day, DayStatus,daydata;
                    List<DayStatus> objDayStatusList = new List<DayStatus>();
                    foreach (DateTime ADateTime in AdmReport.Where(a => a.EmpCode == EMPCode).OrderBy(a=>a.Att_Date).Select(a => a.Att_Date))
                    {
                        DayStatus objDayStatus = new DayStatus();
                        objDayStatus.Day = ADateTime.ToString("dd-MMM");
                        objDayStatus.Daydata= ADateTime.ToString("dd");
                        string HdStatus = AdmReport.Where(a => a.EmpCode == EMPCode && a.Att_Date == ADateTime).Select(a => a.ATT).FirstOrDefault();
                        if(HdStatus==null)
                        {
                            objDayStatus.AttenStatus= "NA";
                        }
                        objDayStatus.AttenStatus = HdStatus;
                        objDayStatusList.Add(objDayStatus);
                    }
                    objReportView.EmpCode = EMPCode;
                    objReportView.EmpName= AdmReport.Where(a => a.EmpCode == EMPCode).Select(a => a.EmpName).FirstOrDefault();
                    objReportView.DIVISION = AdmReport.Where(a => a.EmpCode == EMPCode).Select(a => a.DIVISION).FirstOrDefault();
                    objReportView.DeptCode = AdmReport.Where(a => a.EmpCode == EMPCode).Select(a => a.DeptCode).FirstOrDefault();
                    objReportView.Project_code = AdmReport.Where(a => a.EmpCode == EMPCode).Select(a => a.Project_code).FirstOrDefault();
                    objReportView.Attendanclist = objDayStatusList;

                    objReportViewList.Add(objReportView);
                    //HolidayEntity holiday = new HolidayEntity();
                }
                  return Json(objReportViewList, JsonRequestBehavior.AllowGet);
            }
        }
        
        public ActionResult LeaveAppFormReport()
        {
           // EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
            EZMVCPRJDataSet1 ds = new EZMVCPRJDataSet1();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            //reportViewer.Width = Unit.Percentage(900);
            //reportViewer.Height = Unit.Percentage(900);

            SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["UMNIAHConn"].ConnectionString);

            con.Open();
            //SqlConnection conx = new SqlConnection(connectionString);
            SqlDataAdapter adp = new SqlDataAdapter("select * from PRLR002", con);

            adp.Fill(ds,ds.PRLR002.TableName);
            // _EzBusinessHelper.ExecuteNonQuery(")

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\LeaveApplication.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("EZMVCPRJDataSet1", ds.Tables[0]));


            ViewBag.ReportViewer = reportViewer;


            return View();
        }

    }
}
