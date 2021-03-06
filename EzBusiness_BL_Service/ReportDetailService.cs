﻿using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_BL_Service
{
  public class ReportDetailService : IReportDetailsServices
    {
        IReportDetailsRepository _reportdetail;
        ISalaryProcessDRepository _salaryrepo;
        IOTPayrollRepository _OTPayrollRepository;
        IEmployeeMgmtRepository _empservice;

        public ReportDetailService()
        {
            _salaryrepo = new SalaryProcessRepository();
            _reportdetail = new ReportDetailRepository();
            _OTPayrollRepository = new OTPayrollRepository();
            _empservice = new EmployeeMgmtRepository();
        }

        public List<Employee> GetEmpReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode,string search)
        {
            List<Employee> data= _reportdetail.GetEmpReportDetails(CmpyCode,Fromdate,Todate,EmpName,EmpCode);
            if (!string.IsNullOrEmpty(search) &&
                       !string.IsNullOrWhiteSpace(search))
            {
                // Apply search
                data = data.Where(p => p.EmpCode.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.Empname.ToLower().Contains(search.ToLower()) ||
                                       p.EmpType.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.EMail.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.JoiningDate.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.BloodGroup.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.ReportingEmp.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
            return data;
        }
        public List<Employee> EmpReportDetailsColumnWithOrder(string order, string orderDir, List<Employee> data)
        {
            // Initialization.
            List<Employee> lst = new List<Employee>();

            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SrNo).ToList()
                                                                                                 : data.OrderBy(p => p.SrNo).ToList();
                        break;
                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpCode).ToList()
                                                                                                 : data.OrderBy(p => p.EmpCode).ToList();
                        break;
                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Empname).ToList()
                                                                                                 : data.OrderBy(p => p.Empname).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpType).ToList()
                                                                                                 : data.OrderBy(p => p.EmpType).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EMail).ToList()
                                                                                                 : data.OrderBy(p => p.EMail).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.JoiningDate).ToList()
                                                                                                   : data.OrderBy(p => p.JoiningDate).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BloodGroup).ToList()
                                                                                                   : data.OrderBy(p => p.BloodGroup).ToList();
                        break;


                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ReportingEmp).ToList()
                                                                                                 : data.OrderBy(p => p.ReportingEmp).ToList();
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

        public List<FinalSettalment> GetFinalSettlementDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode,string search)
        {
            List<FinalSettalment> data= _reportdetail.GetFinalSettlementDetails(CmpyCode, Fromdate, Todate,EmpName,EmpCode);
            if (!string.IsNullOrEmpty(search) &&
                       !string.IsNullOrWhiteSpace(search))
            {
                // Apply search
                data = data.Where(p => p.EmpCode.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.EmpName.ToLower().Contains(search.ToLower()) ||
                                       p.PRFSET001_code.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.SalType.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.JoiningDate.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.DateofRelease.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.NetAmount.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
            return data;
        }
        public List<FinalSettalment> FinalsettlementDetailsColumnWithOrder(string order, string orderDir, List<FinalSettalment> data)
        {
            // Initialization.
            List<FinalSettalment> lst = new List<FinalSettalment>();

            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SrNo).ToList()
                                                                                                 : data.OrderBy(p => p.SrNo).ToList();
                        break;
                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpCode).ToList()
                                                                                                 : data.OrderBy(p => p.EmpCode).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpName).ToList()
                                                                                                 : data.OrderBy(p => p.EmpName).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PRFSET001_code).ToList()
                                                                                                 : data.OrderBy(p => p.PRFSET001_code).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SalType).ToList()
                                                                                                 : data.OrderBy(p => p.SalType).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.JoiningDate).ToList()
                                                                                                   : data.OrderBy(p => p.JoiningDate).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.DateofRelease).ToList()
                                                                                                   : data.OrderBy(p => p.DateofRelease).ToList();
                        break;


                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.NetAmount).ToList()
                                                                                                 : data.OrderBy(p => p.NetAmount).ToList();
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
        public List<MonthlyAdddedDet> GetMonthlyAddDeductDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode,string search)
        {
            List<MonthlyAdddedDet>  data=_reportdetail.GetMonthlyAddDeductDetails(CmpyCode, Fromdate, Todate, EmpName, EmpCode);
            if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
            {
                // Apply search
                data = data.Where(p => p.EmpCode.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.EmpName.ToLower().Contains(search.ToLower()) ||
                                       p.PRADN001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.ADN_Act_code.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.T_type.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.Remarks.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.EntryDate.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
            return data;
        }
        public List<MonthlyAdddedDet> MonthlyAddDeductDetailsColumnWithOrder(string order, string orderDir, List<MonthlyAdddedDet> data)
        {
            // Initialization.
            List<MonthlyAdddedDet> lst = new List<MonthlyAdddedDet>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpCode).ToList()
                                                                                                 : data.OrderBy(p => p.EmpCode).ToList();
                        break;
                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpName).ToList()
                                                                                                 : data.OrderBy(p => p.EmpName).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PRADN001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.PRADN001_CODE).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ADN_Act_code).ToList()
                                                                                                 : data.OrderBy(p => p.ADN_Act_code).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.T_type).ToList()
                                                                                                   : data.OrderBy(p => p.T_type).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Remarks).ToList()
                                                                                                   : data.OrderBy(p => p.Remarks).ToList();
                        break;


                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EntryDate).ToList()
                                                                                                 : data.OrderBy(p => p.EntryDate).ToList();
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

        public List<LoanAppliation> GetLoanApplicatnDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode,string search)
        {
            List<LoanAppliation> data= _reportdetail.GetLoanApplicatnDetails(CmpyCode, Fromdate, Todate, EmpName, EmpCode);
            if (!string.IsNullOrEmpty(search) &&
                      !string.IsNullOrWhiteSpace(search))
            {
                // Apply search
                data = data.Where(p => p.EmpCode.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.EmpName.ToLower().Contains(search.ToLower()) ||
                                       p.PRLA001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.AutoDeductionYN.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.Remarks.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.Status.ToString().ToLower().Contains(search.ToLower()) ||
                                        p.ApprovalYN.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.LoanType.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
            return data;
        }
        public List<LoanAppliation> LoanApplicatnDetailsColumnWithOrder(string order, string orderDir, List<LoanAppliation> data)
        {
            // Initialization.
            List<LoanAppliation> lst = new List<LoanAppliation>();

            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SrNo).ToList()
                                                                                                 : data.OrderBy(p => p.SrNo).ToList();
                        break;

                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpCode).ToList()
                                                                                                 : data.OrderBy(p => p.EmpCode).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpName).ToList()
                                                                                                 : data.OrderBy(p => p.EmpName).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PRLA001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.PRLA001_CODE).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ApprovalYN).ToList()
                                                                                                 : data.OrderBy(p => p.ApprovalYN).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.AutoDeductionYN).ToList()
                                                                                                   : data.OrderBy(p => p.AutoDeductionYN).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Remarks).ToList()
                                                                                                   : data.OrderBy(p => p.Remarks).ToList();
                        break;

                    case "7":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Status).ToList()
                                                                                                   : data.OrderBy(p => p.Status).ToList();
                        break;

                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LoanType).ToList()
                                                                                                 : data.OrderBy(p => p.LoanType).ToList();
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
        public List<Holiday> GetHolidayDetails(string CmpyCode, string HoliCode,string search)
        {
            List<Holiday> data = _reportdetail.GetHolidayDetails(CmpyCode,HoliCode);
            if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
            {
                // Apply search
                data = data.Where(p => p.HRPH001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.LEAVE_TYPEYCODE.ToLower().Contains(search.ToLower()) ||
                                       p.Description.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.Dates.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
            return data;
        }
        public List<Holiday> HolidayDetailsColumnWithOrder(string order, string orderDir, List<Holiday> data)
        {
            // Initialization.
            List<Holiday> lst = new List<Holiday>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.HRPH001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.HRPH001_CODE).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LEAVE_TYPEYCODE).ToList()
                                                                                                 : data.OrderBy(p => p.LEAVE_TYPEYCODE).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Description).ToList()
                                                                                                 : data.OrderBy(p => p.Description).ToList();
                        break;

                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Dates).ToList()
                                                                                                 : data.OrderBy(p => p.Dates).ToList();
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
        public List<Loan> GetLoanDetails(string CmpyCode, string LoanCode,string LoanName,string search)
        {
            List<Loan> data = _reportdetail.GetLoanDetails(CmpyCode, LoanCode,LoanName);
            if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
            {
                // Apply search
                data = data.Where(p => p.PRLM001_CODE.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.COUNTRY.ToLower().Contains(search.ToLower()) ||
                                       p.Name.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.Act_code.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
            return data;
        }
        public List<Loan> LoanDetailsColumnWithOrder(string order, string orderDir, List<Loan> data)
        {
            // Initialization.
            List<Loan> lst = new List<Loan>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PRLM001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.PRLM001_CODE).ToList();
                        break;
                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.COUNTRY).ToList()
                                                                                                 : data.OrderBy(p => p.COUNTRY).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Name).ToList()
                                                                                                 : data.OrderBy(p => p.Name).ToList();
                        break;

                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Act_code).ToList()
                                                                                                 : data.OrderBy(p => p.Act_code).ToList();
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
        public List<Profession> GetProfessionReprtDetails(string CmpyCode, string profCode, string profName, string search)
        {
            List<Profession> data = _reportdetail.GetProfessionReprtDetails(CmpyCode, profCode, profName);
            if (!string.IsNullOrEmpty(search) &&
                        !string.IsNullOrWhiteSpace(search))
            {
                // Apply search
                data = data.Where(p => p.ProfCode.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.ProfName.ToLower().Contains(search.ToLower()) ||
                                       p.UniCodeName.ToString().ToLower().Contains(search.ToLower()) ||
                                       p.ProfType.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
            return data;
        }
        public List<Profession> ProfssnDetailsColumnWithOrder(string order, string orderDir, List<Profession> data)
        {
            // Initialization.
            List<Profession> lst = new List<Profession>();
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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ProfCode).ToList()
                                                                                                 : data.OrderBy(p => p.ProfCode).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ProfName).ToList()
                                                                                                 : data.OrderBy(p => p.ProfName).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.UniCodeName).ToList()
                                                                                                 : data.OrderBy(p => p.UniCodeName).ToList();
                        break;

                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ProfType).ToList()
                                                                                                 : data.OrderBy(p => p.ProfType).ToList();
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

        public List<LeaveApplication> GetLeaveAppDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string EmpCode,string EmpName)
        {
            return _reportdetail.GetLeaveReportDetails(CmpyCode, Fromdate, Todate,EmpCode,EmpName);
        }

        public List<LeaveApplication> EmpReportLeaveAppColumnWithOrder(string order, string orderDir, List<LeaveApplication> data)
        {
            // Initialization.
            List<LeaveApplication> lst = new List<LeaveApplication>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpCode).ToList()
                                                                                                 : data.OrderBy(p => p.EmpCode).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.JoiningDate).ToList()
                                                                                                 : data.OrderBy(p => p.JoiningDate).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.StartDate).ToList()
                                                                                                 : data.OrderBy(p => p.StartDate).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EndDate).ToList()
                                                                                                 : data.OrderBy(p => p.EndDate).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TotalBalance).ToList()
                                                                                                   : data.OrderBy(p => p.TotalBalance).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LeaveType).ToList()
                                                                                                   : data.OrderBy(p => p.LeaveType).ToList();
                        break;

                    case "7":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LeaveDays).ToList()
                                                                                                   : data.OrderBy(p => p.LeaveType).ToList();
                        break;
                    case "8":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.TotalSanctioned).ToList()
                                                                                                   : data.OrderBy(p => p.LeaveType).ToList();
                        break;
                    case "9":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ApprovalYN).ToList()
                                                                                                   : data.OrderBy(p => p.LeaveType).ToList();
                        break;


                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Remarks).ToList()
                                                                                                 : data.OrderBy(p => p.Remarks).ToList();
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


        public List<LeaveSettlement> GetLeaveSettlemenntReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string EmpCode,string EmpName)
        {
            return _reportdetail.GetLeaveSettlemenntReportDetails(CmpyCode, Fromdate, Todate,EmpCode,EmpName);
        }

        public List<LeaveSettlement> EmpLeaveSettlemenntColumnWithOrder(string order, string orderDir, List<LeaveSettlement> data)
        {
            // Initialization.
            List<LeaveSettlement> lst = new List<LeaveSettlement>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LStartDate).ToList()
                                                                                                 : data.OrderBy(p => p.LStartDate).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LendDate).ToList()
                                                                                                 : data.OrderBy(p => p.LendDate).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Sanctioned_Days).ToList()
                                                                                                 : data.OrderBy(p => p.Sanctioned_Days).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Total_days).ToList()
                                                                                                   : data.OrderBy(p => p.Total_days).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Total_worked_Days).ToList()
                                                                                                   : data.OrderBy(p => p.Total_worked_Days).ToList();
                        break;

                    case "7":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Total_LE_Days).ToList()
                                                                                                   : data.OrderBy(p => p.Total_LE_Days).ToList();
                        break;
                    case "8":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.LB_CF_Days).ToList()
                                                                                                   : data.OrderBy(p => p.LB_CF_Days).ToList();
                        break;
                    case "9":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Leave_Salary).ToList()
                                                                                                   : data.OrderBy(p => p.Leave_Salary).ToList();
                        break;

                    case "10":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Addition_amt).ToList()
                                                                                                   : data.OrderBy(p => p.Total_worked_Days).ToList();
                        break;

                    case "11":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Deduction_Amt).ToList()
                                                                                                   : data.OrderBy(p => p.Total_LE_Days).ToList();
                        break;
                    case "12":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Ticket_amt).ToList()
                                                                                                   : data.OrderBy(p => p.LB_CF_Days).ToList();
                        break;
                    case "13":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Ticket_Paid).ToList()
                                                                                                   : data.OrderBy(p => p.Leave_Salary).ToList();
                        break;

                    case "14":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Pending_Salary).ToList()
                                                                                                   : data.OrderBy(p => p.Leave_Salary).ToList();
                        break;

                    case "15":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Advance_Salary).ToList()
                                                                                                   : data.OrderBy(p => p.Total_worked_Days).ToList();
                        break;

                    case "16":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Advance_Paid).ToList()
                                                                                                   : data.OrderBy(p => p.Total_LE_Days).ToList();
                        break;
                    case "17":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Actual_Salary).ToList()
                                                                                                   : data.OrderBy(p => p.LB_CF_Days).ToList();
                        break;
                    case "18":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Net_Pay).ToList()
                                                                                                   : data.OrderBy(p => p.Leave_Salary).ToList();
                        break;


                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.salary_effect_date).ToList()
                                                                                                 : data.OrderBy(p => p.Addition_amt).ToList();
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

        public List<DutyResume> GetDutyResumeDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string EmpCode,string EmpName)
        {
            return _reportdetail.GetDutyResumeReportDetails(CmpyCode, Fromdate, Todate,EmpCode,EmpName);
        }

        public List<DutyResume> EmpReportDutyResumeColumnWithOrder(string order, string orderDir, List<DutyResume> data)
        {
            // Initialization.
            List<DutyResume> lst = new List<DutyResume>();

            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SrNo).ToList()
                                                                                                 : data.OrderBy(p => p.SrNo).ToList();
                        break;
                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpCode).ToList()
                                                                                                 : data.OrderBy(p => p.EmpCode).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ResumeDate).ToList()
                                                                                                 : data.OrderBy(p => p.ResumeDate).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Actual_Leave_Type).ToList()
                                                                                                 : data.OrderBy(p => p.Actual_Leave_Type).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Duty_Rm_type).ToList()
                                                                                                 : data.OrderBy(p => p.Duty_Rm_type).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Approve_Days).ToList()
                                                                                                   : data.OrderBy(p => p.Approve_Days).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Excess_Days_plus_minus).ToList()
                                                                                                   : data.OrderBy(p => p.Excess_Days_plus_minus).ToList();
                        break;

                    case "7":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Approve_Days_in_full).ToList()
                                                                                                   : data.OrderBy(p => p.Approve_Days_in_full).ToList();
                        break;
                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Approve_Days_in_Half).ToList()
                                                                                                 : data.OrderBy(p => p.Approve_Days_in_Half).ToList();
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

        public List<ShiftMaster> GetShiftMasterDetails(string CmpyCode,string ShiftCode)
        {
            return _reportdetail.GetShiftMasterDetails(CmpyCode,ShiftCode);
        }
        public List<ShiftMaster> ShiftMasterReportDetailsColumnWithOrder(string order, string orderDir, List<ShiftMaster> data)
        {
            // Initialization.
            List<ShiftMaster> lst = new List<ShiftMaster>();

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
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ShiftName).ToList()
                                                                                                 : data.OrderBy(p => p.ShiftName).ToList();
                        break;
                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.country).ToList()
                                                                                                 : data.OrderBy(p => p.country).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.division).ToList()
                                                                                                 : data.OrderBy(p => p.division).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.StTime).ToList()
                                                                                                 : data.OrderBy(p => p.StTime).ToList();
                        break;
                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EdTime).ToList()
                                                                                                 : data.OrderBy(p => p.EdTime).ToList();
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

        public List<TimeSheetDetail> GetProjectDetailsEmployeeWise(string CmpyCode,DateTime CurrentDate)
        {
            return _reportdetail.GetProjectDetailsEmployeeWise(CmpyCode, CurrentDate);
        }
        public List<TimeSheetDetail> ProjectReportDetailsColumnWithOrder(string order, string orderDir, List<TimeSheetDetail> data)
        {
            // Initialization.
            List<TimeSheetDetail> lst = new List<TimeSheetDetail>();

            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Srno).ToList()                                                                                                 : data.OrderBy(p => p.Srno).ToList();
                        break;
                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpCode).ToList()                                                                                                 : data.OrderBy(p => p.EmpCode).ToList();
                        break;
                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EmpName).ToList()
                                                                                                 : data.OrderBy(p => p.EmpName).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ProjectCode).ToList()
                                                                                                 : data.OrderBy(p => p.ProjectCode).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ProjectName).ToList()
                                                                                                 : data.OrderBy(p => p.ProjectName).ToList();
                        break;
                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Tyear).ToList()                                                                                                 : data.OrderBy(p => p.Tyear).ToList();
                        break;
                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Tmonth).ToList()                                                                                                 : data.OrderBy(p => p.Tmonth).ToList();
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


        public List<SalaryProcessDetailsRep> SalaryProcessDetailsRepColumnWithOrder(string order, string orderDir, List<SalaryProcessDetailsRep> data)
        {
            // Initialization.
            List<SalaryProcessDetailsRep> lst = new List<SalaryProcessDetailsRep>();

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
        public List<SalaryProcessDetailsRep> GetSalaryProcessDetails(string CmpyCode, DateTime CurrDate, string DivCode, string deptcode, string visaloc,string search)
        {

            List<SalaryProcessDetailsRep> data = _reportdetail.GetSalaryProcessDetails(CmpyCode, CurrDate, DivCode, deptcode, visaloc);
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
                                   p.cmpycode.ToString().ToLower().Contains(search.ToLower())).ToList();
            }
            return data;

              }




        public SalaryProcessDetailsRep GetSalaryProcessDetailList(string CmpyCode)
        {
            List<SessionListnew> list = HttpContext.Current.Session["SesDet"] as List<SessionListnew>;

            return new SalaryProcessDetailsRep
            {
               
                DivisionList = GetDivCodeList(CmpyCode),
                Division = list[0].Divcode.ToString(),
               // VisaLocationList = GetVisLocList(CmpyCode),
                DepartmentList = GetDepartmentList(CmpyCode, list[0].Divcode)

            };
        }


        public List<SelectListItem> GetDivCodeList(string CmpyCode)
        {
            var itemCodes = _OTPayrollRepository.GetDivCodeList(CmpyCode)
                                     .Select(m => new SelectListItem { Value = m.DivisionCode, Text = string.Concat(m.DivisionCode, " - ", m.DivisionName) })
                                     .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
        private List<SelectListItem> InsertFirstElementDDL(List<SelectListItem> items)
        {
            items.Insert(0, new SelectListItem
            {
                Value = PurchaseMgmtConstants.DDLFirstVal,
                Text = PurchaseMgmtConstants.DDLFirstText
            });
            return items;
        }

        public List<SelectListItem> GetVisLocList(string CmpyCode,string Prefix)
        {
            var itemCodes = _empservice.GetVisaLocationList(CmpyCode, Prefix)
                                    .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                    .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
        public List<SelectListItem> GetDepartmentList(string CmpyCode, string divcode)
        {
            var itemCodes = _salaryrepo.GetDepartmentList(CmpyCode, divcode)
                                      .Select(m => new SelectListItem { Value = m.DepartmentCode, Text = string.Concat(m.DepartmentCode, "-", m.DepartmentName) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<GetEmpBankTrf> GetEmpBankTrf(string cmpycode, DateTime CurrDate)
        {
            List<GetEmpBankTrf> data = _reportdetail.GetEmpBankTrf(cmpycode, CurrDate);
            return data;
        }


        public List<GetEmpBankTrf> EmpBankTrfColumnWithOrder(string order, string orderDir, List<GetEmpBankTrf> data)
        {
            // Initialization.
            List<GetEmpBankTrf> lst = new List<GetEmpBankTrf>();

            try
            {
                // Sorting
                switch (order)
                {
                    case "0":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.SrNo).ToList()
                                                                                                 : data.OrderBy(p => p.SrNo).ToList();
                        break;
                    case "1":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.PRSPD001_CODE).ToList()
                                                                                                 : data.OrderBy(p => p.PRSPD001_CODE).ToList();
                        break;

                    case "2":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EMPCODE).ToList()
                                                                                                 : data.OrderBy(p => p.EMPCODE).ToList();
                        break;

                    case "3":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.EMPNAME).ToList()
                                                                                                 : data.OrderBy(p => p.EMPNAME).ToList();
                        break;

                    case "4":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.Bank_name).ToList()
                                                                                                 : data.OrderBy(p => p.Bank_name).ToList();
                        break;

                    case "5":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.BANKCODE).ToList()
                                                                                                   : data.OrderBy(p => p.BANKCODE).ToList();
                        break;

                    case "6":
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.ACCOUNTNO).ToList()
                                                                                                   : data.OrderBy(p => p.ACCOUNTNO).ToList();
                        break;

                   
                    default:
                        // Setting.
                        lst = orderDir.Equals("DESC", StringComparison.CurrentCultureIgnoreCase) ? data.OrderByDescending(p => p.AMOUNT).ToList()
                                                                                                 : data.OrderBy(p => p.AMOUNT).ToList();
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

        public List<TimeSheetDetail> DailyTimeSheetDetailsReport(string CmpyCode, DateTime Fromdate, DateTime Todate)
        {
            return _reportdetail.DailyTimeSheetDetailsReport(CmpyCode,Fromdate,Todate);
        }
    }
}
