using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Repository
{
   public class ReportDetailRepository:IReportDetailsRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public List<Employee> GetEmpReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode)
        {
            string fdate = Convert.ToString(Fromdate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Fromdate.ToString("yyyy-MM-dd"));
            string Tdate = Convert.ToString(Todate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Todate.ToString("yyyy-MM-dd"));
            SqlParameter[] param = {new SqlParameter("@fdate", fdate),
                                    new SqlParameter("@Tdate", Tdate),
                                     new SqlParameter("@EmpCode", EmpCode),
                                     new SqlParameter("@EmpName", EmpName),
                                     new SqlParameter("@CompyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetEmpReportDetails", CommandType.StoredProcedure, param);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Employee> objList = new List<Employee>();
            foreach (DataRow dr in drc)
            {
                objList.Add(new Employee()
                {
                    EmpCode = dr["EmpCode"].ToString(),
                    Empname = dr["Empname"].ToString(),
                    SrNo = Convert.ToInt32(dr["srno"].ToString()),
                    EmpType =dr["EmpType"].ToString(),
                    JoiningDate = Convert.ToDateTime(dr["joiningDate"].ToString()),
                    EMail =dr["Email"].ToString(),
                    ContactNo = dr["ContactNo"].ToString(),
                    Nationality =dr["Nationality"].ToString(),
                    DOB =Convert.ToDateTime(dr["DOB"].ToString()),
                    ReportingEmp =dr["ReportingEmp"].ToString(),
                    BloodGroup = dr["BloodGroup"].ToString(),
                    LanguageKnown =dr["LanguageKnown"].ToString(),
              
                });
            }
            return objList;
        }

        public List<FinalSettalment> GetFinalSettlementDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string EmpName,string EmpCode)
        {
           // string fdatetemp = Fromdate.ToString("yyyy-MM-dd");
            string fdate=Convert.ToString(Fromdate.ToString("yyyy-MM-dd")== "0001-01-01" ? null:Fromdate.ToString("yyyy-MM-dd"));
            string Tdate = Convert.ToString(Todate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Todate.ToString("yyyy-MM-dd"));
            SqlParameter[] param = {new SqlParameter("@fDate", fdate),
                                    new SqlParameter("@Tdate", Tdate),
                                     new SqlParameter("@EmpCode", EmpCode),
                                     new SqlParameter("@EmpName", EmpName),
                                     new SqlParameter("@cmpyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetFinalSettalmentDetails", CommandType.StoredProcedure, param);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FinalSettalment> objList = new List<FinalSettalment>();
            foreach (DataRow dr in drc)
            {
                objList.Add(new FinalSettalment()
                {
                    EmpCode = dr["EmpCode"].ToString(),
                    SrNo=Convert.ToInt32(dr["SrNo"].ToString()),
                    EmpName= dr["Empname"].ToString(),
                    PRFSET001_code = dr["PRFSET001_code"].ToString(),
                    Reason = dr["Reason"].ToString(),
                    JoiningDate =Convert.ToDateTime(dr["JoiningDate"].ToString()),
                    Dates = Convert.ToDateTime(dr["Dates"].ToString()),
                    SettledDate = Convert.ToDateTime(dr["SettledDate"].ToString()),
                    DateofRelease = Convert.ToDateTime(dr["DateofRelease"].ToString()),
                    NoOfDaysSuspended = Convert.ToInt32(dr["NoOfDaysSuspended"].ToString()),
                    TotalNoOfDays = Convert.ToInt32(dr["TotalNoOfDays"].ToString()),
                    NoOfDaysWkd = Convert.ToInt32(dr["NoOfDaysWkd"].ToString()),
                    Gratuity = Convert.ToDecimal(dr["Gratuity"].ToString()),
                    Addition = Convert.ToDecimal(dr["Addition"].ToString()),
                    Deduction = Convert.ToDecimal(dr["Deduction"].ToString()),
                    NetAmount = Convert.ToDecimal(dr["NetAmount"].ToString()),
                    Basic = Convert.ToDecimal(dr["Basic"].ToString()),
                    SalType = dr["SalType"].ToString(),
                    Absent = Convert.ToDecimal(dr["Absent"].ToString()),
                    DeductionDays = Convert.ToDecimal(dr["DeductionDays"].ToString()),
                    Housing = Convert.ToDecimal(dr["Housing"].ToString()),
                    Tele_Allow = Convert.ToDecimal(dr["Tele_Allow"].ToString()),
                    Other_Allow = Convert.ToDecimal(dr["Other_Allow"].ToString()),
                    Food = Convert.ToDecimal(dr["Food"].ToString()),
                    Conveyance = Convert.ToDecimal(dr["Conveyance"].ToString()),
                    NoOfDays = Convert.ToInt32(dr["NoOfDays"].ToString()),
                    LNoOfDaysWkd = Convert.ToInt32(dr["LNoOfDaysWkd"].ToString()),
                    LeaveCF = Convert.ToDecimal(dr["LeaveCF"].ToString()),
                    LeaveBF = Convert.ToDecimal(dr["LeaveBF"].ToString()),



                });
            }
            return objList;
        }

        public List<MonthlyAdddedDet> GetMonthlyAddDeductDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode)
        {
            // string fdatetemp = Fromdate.ToString("yyyy-MM-dd");
            string fdate = Convert.ToString(Fromdate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Fromdate.ToString("yyyy-MM-dd"));
            string Tdate = Convert.ToString(Todate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Todate.ToString("yyyy-MM-dd"));
            SqlParameter[] param = {new SqlParameter("@fDate", fdate),
                                    new SqlParameter("@Tdate", Tdate),
                                     new SqlParameter("@EmpCode", EmpCode),
                                     new SqlParameter("@EmpName", EmpName),
                                     new SqlParameter("@cmpyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetMonthlyAdditnDeductionDetails", CommandType.StoredProcedure, param);
            List<MonthlyAdddedDet> objList = null;
            if (ds != null)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<MonthlyAdddedDet>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new MonthlyAdddedDet()
                    {
                        srno=Convert.ToInt32(dr["Srno"].ToString()),
                        EmpCode = dr["EmpCode"].ToString(),
                        EmpName = dr["EmpName"].ToString(),
                        PRADN001_CODE = dr["PRADN001_CODE"].ToString(),
                        ADN_Amount = dr["ADN_Amount"].ToString(),
                        ADNActcode =dr["ADN_Act_code"].ToString(),
                        T_type = dr["T_type"].ToString(),
                        Remarks = dr["Remarks"].ToString(),
                        EntryDate = Convert.ToDateTime(dr["Entry_Date"].ToString()),

                    });
                }
                
            }
            return objList;
        }
        public List<LoanAppliation> GetLoanApplicatnDetails(string CmpyCode, DateTime Fromdate, DateTime Todate, string EmpName, string EmpCode)
        {
            // string fdatetemp = Fromdate.ToString("yyyy-MM-dd");
            string fdate = Convert.ToString(Fromdate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Fromdate.ToString("yyyy-MM-dd"));
            string Tdate = Convert.ToString(Todate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Todate.ToString("yyyy-MM-dd"));
            SqlParameter[] param = {new SqlParameter("@fDate", fdate),
                                    new SqlParameter("@Tdate", Tdate),
                                     new SqlParameter("@EmpCode", EmpCode),
                                     new SqlParameter("@EmpName", EmpName),
                                     new SqlParameter("@cmpyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetLoanApplicatnsDetails", CommandType.StoredProcedure, param);
            List<LoanAppliation> objList = null;
            if (ds != null)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<LoanAppliation>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new LoanAppliation()
                    {
                        SrNo = Convert.ToInt32(dr["SrNo"].ToString()),
                        EmpCode = dr["EmpCode"].ToString(),
                        EmpName = dr["EmpName"].ToString(),
                        PRLA001_CODE = dr["PRLA001_CODE"].ToString(),
                        LoanAmount =Convert.ToDecimal(dr["LoanAmount"].ToString()),
                        NoOfInstalments =Convert.ToInt32(dr["NoOfInstalments"].ToString()),
                        Instalment =Convert.ToDecimal(dr["Instalment"].ToString()),
                        Deduction = Convert.ToDecimal(dr["Deduction"].ToString()),
                        Entry_Date = Convert.ToDateTime(dr["Entry_Date"].ToString()),
                        Balance = Convert.ToDecimal(dr["Balance"].ToString()),
                        Remarks = dr["Remarks"].ToString(),
                        Status = dr["Status"].ToString(),
                        AutoDeductionYN = dr["AutoDeductionYN"].ToString(),
                        DeductionStartDate =Convert.ToDateTime(dr["DeductionStartDate"].ToString()),
                        Act_code = dr["Act_code"].ToString(),
                        LoanType = dr["LoanType"].ToString(),
                        ApprovalYN = dr["ApprovalYN"].ToString(),
                        AppliedAmt =Convert.ToDecimal(dr["AppliedAmt"].ToString()),
                    });
                }

            }
            return objList;
        }

        public List<Holiday> GetHolidayDetails(string CmpyCode,string HoliCode)
        {
            // string fdatetemp = Fromdate.ToString("yyyy-MM-dd");
           // string fdate = Convert.ToString(Fromdate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Fromdate.ToString("yyyy-MM-dd"));
           // string Tdate = Convert.ToString(Todate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Todate.ToString("yyyy-MM-dd"));
            SqlParameter[] param = {
                                     new SqlParameter("@HoliCode", HoliCode),
                                     new SqlParameter("@cmpyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetHolidayreportDetails", CommandType.StoredProcedure, param);
            List<Holiday> objList = null;
            if (ds != null)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<Holiday>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new Holiday()
                    {
                        srno=Convert.ToInt32(dr["SrNo"].ToString()),
                        HRPH001_CODE = dr["HRPH001_CODE"].ToString(),
                        LEAVE_TYPEYCODE = dr["LEAVE_TYPE"].ToString(),
                        Description = dr["Description"].ToString(),
                        Dates = Convert.ToDateTime(dr["HOLIDAY_DATE"].ToString()),
                       
                    });
                }

            }
            return objList;
        }
        public List<Loan> GetLoanDetails(string CmpyCode, string LoanCode,string LoanName)
        {
            // string fdatetemp = Fromdate.ToString("yyyy-MM-dd");
            // string fdate = Convert.ToString(Fromdate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Fromdate.ToString("yyyy-MM-dd"));
            // string Tdate = Convert.ToString(Todate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Todate.ToString("yyyy-MM-dd"));
            SqlParameter[] param = {
                                     new SqlParameter("@LoanCode",LoanCode),
                                     new SqlParameter("@LoanName", LoanName),
                                     new SqlParameter("@cmpyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetLoanreportDetails", CommandType.StoredProcedure, param);
            List<Loan> objList = null;
            if (ds != null)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<Loan>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new Loan()
                    {
                        srno=Convert.ToInt32(dr["SrNo"].ToString()),
                        PRLM001_CODE = dr["PRLM001_CODE"].ToString(),
                        COUNTRY = dr["COUNTRY"].ToString(),
                        Name = dr["Name"].ToString(),
                        Act_code =dr["Act_code"].ToString(),

                    });
                }

            }
            return objList;
        }
        public List<Profession> GetProfessionReprtDetails(string CmpyCode, string profCode, string ProfName)
        {
            // string fdatetemp = Fromdate.ToString("yyyy-MM-dd");
            // string fdate = Convert.ToString(Fromdate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Fromdate.ToString("yyyy-MM-dd"));
            // string Tdate = Convert.ToString(Todate.ToString("yyyy-MM-dd") == "0001-01-01" ? null : Todate.ToString("yyyy-MM-dd"));
            SqlParameter[] param = {
                                     new SqlParameter("@profCode",profCode),
                                     new SqlParameter("@ProfName", ProfName),
                                     new SqlParameter("@cmpyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetProfreportDetails", CommandType.StoredProcedure, param);
            List<Profession> objList = null;
            if (ds != null)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<Profession>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new Profession()
                    {
                        srno=Convert.ToInt32(dr["SrNo"].ToString()),
                        ProfCode = dr["ProfCode"].ToString(),
                        ProfName = dr["ProfName"].ToString(),
                        UniCodeName = dr["UniCodeName"].ToString(),
                        ProfType = dr["ProfType"].ToString(),

                    });
                }

            }
            return objList;
        }
        public List<LeaveApplication> GetLeaveReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string EmpCode,string EmpName)
        {
            string fdate = Fromdate.ToString("yyyy-MM-dd");
            string Tdate = Todate.ToString("yyyy-MM-dd");
            SqlParameter[] param = {new SqlParameter("@fdate", fdate),
                                    new SqlParameter("@Tdate", Tdate),
                                    new SqlParameter("@EmpCode",EmpCode),
                                    new SqlParameter("@EmpName",EmpName),
                                     new SqlParameter("@CompyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetLeaveAppReportDetails", CommandType.StoredProcedure, param);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<LeaveApplication> objList = new List<LeaveApplication>();
            foreach (DataRow dr in drc)
            {
                objList.Add(new LeaveApplication()
                {
                    srno=Convert.ToInt32(dr["SrNo"].ToString()),
                    EmpCode = dr["EmpCode"].ToString(),
                    EmpName=dr["Empname"].ToString(),
                    JoiningDate = Convert.ToDateTime(dr["joiningDate"].ToString()),
                    StartDate = Convert.ToDateTime(dr["StartDate"].ToString()),
                    EndDate = Convert.ToDateTime(dr["EndDate"].ToString()),
                    TotalBalance = dr["TotalBalance"].ToString(),
                    LeaveType = dr["LeaveType"].ToString(),
                    LeaveDays = dr["LeaveDays"].ToString(),
                    TotalSanctioned = (dr["TotalSanctioned"].ToString()),
                    ApprovalYN = dr["ApprovalYN"].ToString(),
                    Remarks = dr["Remarks"].ToString(),
                });
            }
            return objList;
        }

        public List<LeaveSettlement> GetLeaveSettlemenntReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string EmpCode,string EmpName)
        {
            string fdate = Fromdate.ToString("yyyy-MM-dd");
            string Tdate = Todate.ToString("yyyy-MM-dd");
            SqlParameter[] param = {new SqlParameter("@fdate", fdate),
                                    new SqlParameter("@Tdate", Tdate),
                                    new SqlParameter("@EmpCode",EmpCode),
                                    new SqlParameter("@EmpName",EmpName),
                                     new SqlParameter("@CompyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetLeaveSetReportDetails", CommandType.StoredProcedure, param);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<LeaveSettlement> objList = new List<LeaveSettlement>();
            foreach (DataRow dr in drc)
            {
                objList.Add(new LeaveSettlement()
                {
                    Empcode = dr["Empcode"].ToString(),
                    EmpName = dr["Empname"].ToString(),
                    srno=Convert.ToInt32(dr["SrNo"].ToString()),                   
                    LStartDate = Convert.ToDateTime(dr["LStartDate"].ToString()),
                    LendDate = Convert.ToDateTime(dr["LendDate"].ToString()),
                    Sanctioned_Days = Convert.ToDecimal(dr["Sanctioned_Days"].ToString()),
                    Total_days = Convert.ToDecimal(dr["Total_days"].ToString()),
                    Total_worked_Days = Convert.ToDecimal(dr["Total_worked_Days"].ToString()),
                    Total_LE_Days = Convert.ToDecimal(dr["Total_LE_Days"].ToString()),
                    LB_CF_Days = Convert.ToDecimal(dr["LB_CF_Days"].ToString()),
                    Leave_Salary = Convert.ToDecimal(dr["Leave_Salary"].ToString()),
                    Addition_amt = Convert.ToDecimal(dr["Addition_amt"].ToString()),
                    Deduction_Amt = Convert.ToDecimal(dr["Deduction_Amt"].ToString()),
                    Ticket_amt = Convert.ToDecimal(dr["Ticket_amt"].ToString()),
                    Ticket_Paid = (dr["Ticket_Paid"].ToString()),
                    Pending_Salary = Convert.ToDecimal(dr["Pending_Salary"].ToString()),
                    Advance_Salary = Convert.ToDecimal(dr["Advance_Salary"].ToString()),
                    Advance_Paid = Convert.ToDecimal(dr["Advance_Paid"].ToString()),
                    Actual_Salary = Convert.ToDecimal(dr["Actual_Salary"].ToString()),
                    Net_Pay = Convert.ToDecimal(dr["Net_Pay"].ToString()),
                    salary_effect_date = Convert.ToDateTime(dr["salary_effect_date"].ToString()),

                });
            }
            return objList;
        }

        public List<DutyResume> GetDutyResumeReportDetails(string CmpyCode, DateTime Fromdate, DateTime Todate,string EmpCode,string EmpName)
        {
            string fdate = Fromdate.ToString("yyyy-MM-dd");
            string Tdate = Todate.ToString("yyyy-MM-dd");
            SqlParameter[] param = {new SqlParameter("@fdate", fdate),
                                    new SqlParameter("@Tdate", Tdate),
                                    new SqlParameter("@EmpCode",EmpCode),
                                    new SqlParameter("@EmpName",EmpName),
                                     new SqlParameter("@CompyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetDutyResumeReportDetails", CommandType.StoredProcedure, param);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<DutyResume> objList = new List<DutyResume>();
            foreach (DataRow dr in drc)
            {
                objList.Add(new DutyResume()
                {
                    EmpCode = dr["EmpCode"].ToString(),
                    EmpName=dr["Empname"].ToString(),
                    ResumeDate = Convert.ToDateTime(dr["ResumeDate"].ToString()),
                    Actual_Leave_Type = dr["Actual_Leave_Type"].ToString(),
                    Duty_Rm_type = dr["Duty_Rm_type"].ToString(),
                    Approve_Days = dr["Approve_Days"].ToString(),
                    Excess_Days_plus_minus = (dr["Excess_Days_plus_minus"].ToString()),
                    Approve_Days_in_full = dr["Approve_Days_in_full"].ToString(),
                    Approve_Days_in_Half = dr["Approve_Days_in_Half"].ToString(),
                    SrNo=Convert.ToInt32(dr["SrNo"].ToString())
                });
            }
            return objList;
        }

        public List<ShiftMaster> GetShiftMasterDetails(string CmpyCode, string ShiftCode)
        {
            List<ShiftMaster> objList=null;
          //  string fdate = Fromdate.ToString("yyyy-MM-dd");
           // string Tdate = Todate.ToString("yyyy-MM-dd");
            SqlParameter[] param = {new SqlParameter("@ShiftCode", ShiftCode),
                                   
                                     new SqlParameter("@CompyCode",CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetShiftMasterDetails", CommandType.StoredProcedure, param);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 objList = new List<ShiftMaster>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new ShiftMaster()
                    {
                        PRSFT001_code=dr["PRSFT001_code"].ToString(),
                        srno = Convert.ToInt32(dr["SrNo"].ToString()),
                        ShiftName = dr["ShiftName"].ToString(),
                        country = dr["country"].ToString(),
                        division = dr["division"].ToString(),
                        StTime = dr["StTime"].ToString(),
                        EdTime = dr["EdTime"].ToString(),

                    });
                }
            }
            return objList;
        }

       public List<TimeSheetDetail> GetProjectDetailsEmployeeWise(string CmpyCode,DateTime CurrentDate)
        {
            string FMonth = CurrentDate.ToString("MM");
            string Fyear = CurrentDate.ToString("yyyy");
            List<TimeSheetDetail> objList = null;
            //  string fdate = Fromdate.ToString("yyyy-MM-dd");
            // string Tdate = Todate.ToString("yyyy-MM-dd");
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                                     new SqlParameter("@TMonth", FMonth),
                                     new SqlParameter("@TYear",Fyear)};
            ds = _EzBusinessHelper.ExecuteDataSet("GetProjectDetails", CommandType.StoredProcedure, param);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<TimeSheetDetail>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new TimeSheetDetail()
                    {
                        Srno = Convert.ToInt32(dr["SrNo"].ToString()),
                        EmpCode = dr["Empcode"].ToString(),
                        EmpName = dr["EmpName"].ToString(),
                        Tmonth  = Convert.ToInt32(dr["TMONTH"].ToString()),
                        Tyear = Convert.ToInt32(dr["TYEAR"].ToString()),
                        ProjectCode = dr["Project_code"].ToString(),
                        ProjectName = dr["Name"].ToString(),
                        ProjectDuration= dr["ProjectDuration"].ToString()
                    });
                }
            }
            return objList;
        }

        public List<SalaryProcessDetailsRep> GetSalaryProcessDetails(string CmpyCode, DateTime CurrDate, string DivCode, string deptcode, string visaloc)
        {
            string deptcode1 = deptcode == "0" ? "" : deptcode;
            string vloc1 = visaloc == "0" ? "" : visaloc;
            List<SalaryProcessDetailsRep> objList = null;
            string yeardata = CurrDate.ToString("yyyy");
            string monthdata = CurrDate.ToString("MM");
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                                    new SqlParameter("@DivCode",DivCode),
                                    new SqlParameter("@deptcode",deptcode1),
                                    new SqlParameter("@vloc",vloc1),
                                    new SqlParameter("@Year", yeardata),
                                    new SqlParameter("@Month",monthdata)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetSalaryProcessRep", CommandType.StoredProcedure, param);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<SalaryProcessDetailsRep>();
                foreach (DataRow dr in drc)
                {

                   


                    objList.Add(new SalaryProcessDetailsRep()
                    {
                        srno = Convert.ToInt32(dr["SrNo"].ToString()),
                        Empcode = dr["empcode"].ToString(),
                        Empname = dr["Empname"].ToString(),
                        Absent=dr["absentt"].ToString(),
                       Division=dr["Division"].ToString(),
                        
                        ProfCode = dr["ProfCode"].ToString(),
                        DepCode = dr["DepCode"].ToString(),
                        ComnPrjcode = dr["ComnPrjcode"].ToString(),
                     
                        VisaLocation = dr["VisaLocation"].ToString(),
                        WorkLocation = dr["WorkLocation"].ToString(),
                        Total_Days = Convert.ToInt32(dr["Total_Days"].ToString()),
                        Worked_Days = Convert.ToInt32(dr["Worked_Days"].ToString()),
                        a_basic = Convert.ToDecimal(dr["a_basic"].ToString()),
                        a_hra = Convert.ToDecimal(dr["a_hra"].ToString()),
                        a_Da = Convert.ToDecimal(dr["a_Da"].ToString()),
                        a_tele = Convert.ToDecimal(dr["a_tele"].ToString()),
                        a_trans = Convert.ToDecimal(dr["a_trans"].ToString()),
                        a_car = Convert.ToDecimal(dr["a_car"].ToString()),
                        a_allowance1 = Convert.ToDecimal(dr["a_allowance1"].ToString()),
                        a_allowance2 = Convert.ToDecimal(dr["a_allowance2"].ToString()),
                        a_allowance3 = Convert.ToDecimal(dr["a_allowance3"].ToString()),
                        a_Totalsalary = Convert.ToDecimal(dr["a_Totalsalary"].ToString()),
                        C_basic = Convert.ToDecimal(dr["C_basic"].ToString()),
                        C_hra = Convert.ToDecimal(dr["C_hra"].ToString()),
                        C_da = Convert.ToDecimal(dr["C_da"].ToString()),
                        C_tele = Convert.ToDecimal(dr["C_tele"].ToString()),
                        C_trans = Convert.ToDecimal(dr["C_trans"].ToString()),
                        C_car = Convert.ToDecimal(dr["C_car"].ToString()),
                        C_allowance1 = Convert.ToDecimal(dr["C_allowance1"].ToString()),
                        C_allowance2 = Convert.ToDecimal(dr["C_allowance2"].ToString()),
                        C_allowance3 = Convert.ToDecimal(dr["C_allowance3"].ToString()),
                        C_totalSalary = Convert.ToDecimal(dr["C_totalSalary"].ToString()),
                        loan_amt = Convert.ToDecimal(dr["loan_amt"].ToString()),
                        adn_amount = Convert.ToDecimal(dr["adn_amount"].ToString()),
                        nothrs = Convert.ToDecimal(dr["nothrs"].ToString()),
                        extraOThrs = Convert.ToDecimal(dr["extraOThrs"].ToString()),
                        hothrs = Convert.ToDecimal(dr["hothrs"].ToString()),
                        wothrs = Convert.ToDecimal(dr["wothrs"].ToString()),
                        not_rate_perhr = Convert.ToDecimal(dr["not_rate_perhr"].ToString()),
                        hot_rate_perhr = Convert.ToDecimal(dr["hot_rate_perhr"].ToString()),
                        ExtraOT_rate_perhr = Convert.ToDecimal(dr["ExtraOT_rate_perhr"].ToString()),
                        wot_rate_perhr = Convert.ToDecimal(dr["wot_rate_perhr"].ToString()),
                        ExtraOTAmt = Convert.ToDecimal(dr["ExtraOTAmt"].ToString()),
                        NOTAmt = Convert.ToDecimal(dr["NOTAmt"].ToString()),
                        HOTAmt = Convert.ToDecimal(dr["HOTAmt"].ToString()),
                        WOTAmt = Convert.ToDecimal(dr["WOTAmt"].ToString()),
                        NetSalary = Convert.ToDecimal(dr["NetSalary"].ToString()),
                        Salary_Paid= dr["Salary_paid"].ToString(),
                        Incentive_Paid= dr["incentive_paid"].ToString()

                    });
                }
            }

            return objList;
        }

        public List<GetEmpBankTrf> GetEmpBankTrf(string cmpycode, DateTime CurrDate)
        {
           
            List<GetEmpBankTrf> objList = null;
            string yeardata = CurrDate.ToString("yyyy");
            string monthdata = CurrDate.ToString("MM");
          
            ds = _EzBusinessHelper.ExecuteDataSet("Select SrNo,EMPCODE,EMPNAME,ACCOUNTNO,BANKCODE +' - '+ Bank_name as [BANKCODE],AMOUNT,Bank_name,PRSPD001_CODE from  Usp_GetEmpBankTrans  where tmonth =" + monthdata + " and tyear="+ yeardata + " and cmpycode='"+ cmpycode + "'");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<GetEmpBankTrf>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new GetEmpBankTrf()
                    {
                        SrNo = Convert.ToInt32(dr["SrNo"].ToString()),
                        EMPCODE = dr["EMPCODE"].ToString(),
                        EMPNAME = dr["EMPNAME"].ToString(),
                        ACCOUNTNO=dr["ACCOUNTNO"].ToString(),
                        BANKCODE=dr["BANKCODE"].ToString(),
                        AMOUNT=Convert.ToDecimal(dr["AMOUNT"].ToString()),
                        Bank_name=dr["Bank_name"].ToString(),                      
                        PRSPD001_CODE=dr["PRSPD001_CODE"].ToString(),
                       
                       

                    });
                }
            }

            return objList;
        }
        public List<TimeSheetDetail> DailyTimeSheetDetailsReport(string CmpyCode, DateTime Fromdate, DateTime Todate)
        {

            List<TimeSheetDetail> objList = null;
            string yeardata = Todate.ToString("yyyy/MM/dd");
            string monthdata = Fromdate.ToString("yyyy/MM/dd");
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                                    new SqlParameter("@Fromdate", yeardata),
                                    new SqlParameter("@Tdate",monthdata)};
            ds = _EzBusinessHelper.ExecuteDataSet("web_DailyTimeSheetDetailsReport", CommandType.StoredProcedure, param);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<TimeSheetDetail>();
                foreach (DataRow dr in drc)
                {

                    objList.Add(new TimeSheetDetail()
                    {
                        // srno = Convert.ToInt32(dr["SrNo"].ToString()),
                        EmpCode = dr["EmpCode"].ToString(),
                        EmpName = dr["EmpName"].ToString(),
                        DIVISION = dr["DivisionName"].ToString(),
                        DeptCode = dr["DepartmentName"].ToString(),
                        Att_Date = Convert.ToDateTime(dr["Att_Date"].ToString()),
                        ATT = dr["ATT"].ToString(),
                        ProjectCode = dr["Project_code"].ToString(),
                    });
                }
            }

            return objList;
        }
    }
      
 } 

