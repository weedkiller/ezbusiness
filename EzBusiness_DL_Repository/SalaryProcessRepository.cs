using EzBusiness_DL_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Data;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels;
using System.Data.SqlClient;
using System.Transactions;

namespace EzBusiness_DL_Repository
{
    public class SalaryProcessRepository : ISalaryProcessDRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
   
        public bool DeleteSalaryProcess(string CmpyCode, string Code, DateTime CurrDate, string UserName)
        {
            string dtr = CurrDate.ToString("MM");
            string dtr1 = CurrDate.ToString("yyyy");
            int salary = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSPH001 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "' and Flag=0");
            if (salary != 0)
            {
                //int n = salary;
                

                 int i=   _EzBusinessHelper.ExecuteNonQuery("update  PRSPD001 set flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "' and month(Dates)='" + dtr + "' and year(Dates)='" + dtr1 + "'");
                if (i > 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update  PRSPH001 set flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");

                    _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete Salary Process", Code, Environment.MachineName);

                    return true;
                }
                else
                return false;
            }
            return false;
        }

        public List<SalaryProcessDetailsVM> GetSalaryDetailsList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select CmpyCode,Code,Dates from PRSPD001 where CmpyCode='" + CmpyCode + "' and Flag=0 group by CmpyCode,Code,Dates");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<SalaryProcessDetailsVM> ObjList = new List<SalaryProcessDetailsVM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new SalaryProcessDetailsVM()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    CurrentDate = Convert.ToDateTime(dr["Dates"].ToString())

                });

            }
            return ObjList;
        }
       public  List<SalaryProcessDetailsListItem> GetTimeSheetDetailsByMonth(string CmpyCode, DateTime currDate)
        {
            List<SalaryProcessDetailsListItem> objList = null;
            string yeardata = currDate.ToString("yyyy");
            string monthdata = currDate.ToString("MM");
            var lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(currDate.ToString("yyyy")), Convert.ToInt32(currDate.ToString("MM")));
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                                    new SqlParameter("@Year", yeardata),
                                     new SqlParameter("@Month",monthdata),
                                     new SqlParameter("@lastdate",lastDayOfMonth)};
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetEmployeeNotInDTSbMonthly", CommandType.StoredProcedure, param);
            if (ds.Tables.Count >= 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<SalaryProcessDetailsListItem>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new SalaryProcessDetailsListItem()
                    {
                        EmpCode = dr["EmpCode"].ToString(),
                        EmpName = dr["Empname"].ToString(),
                        Sno =Convert.ToInt32(dr["srno"].ToString()),
                    });
                }
               
            }
            return objList;
        }
        public List<SalaryProcessDetailsListItem> GetSalaryProcessGrid(string CmpyCode, DateTime currDate)
        {
           
                List<SalaryProcessDetailsListItem> objList = null;
                string yeardata = currDate.ToString("yyyy");
                string monthdata = currDate.ToString("MM");
                //SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                //                    new SqlParameter("@Year", yeardata),
                //                     new SqlParameter("@Month",monthdata)};         
                ds = _EzBusinessHelper.ExecuteDataSet("select emp.Empname,sal.cmpycode,sal.empcode,Total_Days,Worked_Days,a_basic,a_hra,a_Da,a_tele,a_trans,a_car,a_allowance1,a_allowance2,a_allowance3,a_Totalsalary,C_basic,C_hra,C_totalSalary,loan_amt,adn_amount, nothrs,extraOThrs,hothrs,wothrs,not_rate_perhr,ExtraOT_rate_perhr, hot_rate_perhr, wot_rate_perhr from vw_SalaryProcess sal inner join MEM001 emp on sal.empcode = emp.EmpCode where sal.cmpycode='" + CmpyCode+"' and Tmonth='"+monthdata+"' and Tyear='"+yeardata+"'");
            if (ds.Tables.Count > 0)
            {

                dt = ds.Tables[0];

                DataRowCollection drc = dt.Rows;
                
                    objList = new List<SalaryProcessDetailsListItem>();
                    foreach (DataRow dr in drc)
                    {
                        objList.Add(new SalaryProcessDetailsListItem()
                        {
                            EmpCode = dr["empcode"].ToString(),
                            EmpName = dr["Empname"].ToString(),
                            WorkingDay = Convert.ToDecimal(dr["Total_Days"].ToString()),
                            Present = Convert.ToDecimal(dr["Worked_Days"].ToString()),
                            Leaves =0,// Convert.ToDecimal(dr["AnnualLeave"].ToString()),
                            Absent =0, //Convert.ToDecimal(dr["Absentt"].ToString()),
                            SickLeaves = 0,//Convert.ToDecimal(dr["SickLeave"].ToString()),
                            WeeklyOff = 0,//Convert.ToDecimal(dr["WeeklyOff"].ToString()),
                            Holiday = 0,//Convert.ToDecimal(dr["Holiday"].ToString()),
                            NormalOTHrs = Convert.ToDecimal(dr["nothrs"].ToString()),
                            HolidayOTHrs = Convert.ToDecimal(dr["hothrs"].ToString()),
                            WeeklyOffOTHrs = Convert.ToDecimal(dr["wothrs"].ToString()),
                            ExtraOTHrs = Convert.ToDecimal(dr["extraOThrs"].ToString()),
                            TotalEarning = Convert.ToDecimal(dr["C_totalSalary"].ToString()),
                           // TotalDeduction = Convert.ToDecimal(dr["Deduction"].ToString()),
                            NetSalary =0, //Convert.ToDecimal(dr["netsalarydata"].ToString()),
                            MonthlyAddition = Convert.ToDecimal(dr["adn_amount"].ToString()),
                            LoanDeduction = Convert.ToDecimal(dr["loan_amt"].ToString()),
                            //ErrorMsg = (dr["Flag"].ToString()),
                            ProjectCode ="NA",//dr["Project_code"].ToString(),

                            Salary = Convert.ToDecimal(dr["a_basic"].ToString()),

                        });
                    }
                }
            
                return objList;
            
        }
        public SalaryProcessDetailsVM  GetSalaryProcessEdit(string CmpyCode,string salaryCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select * from PRSPH001 where CmpyCode='" + CmpyCode + "' and code='" + salaryCode + "' and Flag=0");
            dt = ds.Tables[0];
            SalaryProcessDetailsVM drc = new SalaryProcessDetailsVM();
            foreach (DataRow dr in dt.Rows)
            {
                    drc.CmpyCode = dr["CmpyCode"].ToString();
                    drc.Code = dr["Code"].ToString();
                drc.CurrentDate =Convert.ToDateTime(dr["Dates"].ToString());
            }
            return drc;

        }
      
        public SalaryProcessDetailsVM SaveSalaryProcessD(SalaryProcessDetailsVM SPDV)
        {
            string dtstr4 = "";
            string dtstr9 = "";
            try
            {
                var Drecord = new List<string>();
                List<SalaryProcessDetailsListItem> ObjList = new List<SalaryProcessDetailsListItem>();
                ObjList.AddRange(SPDV.salaryList.Select(m => new SalaryProcessDetailsListItem
                {
                    CmpyCode = m.CmpyCode,
                    Code = m.Code,
                    Sno=m.Sno,
                    EmpName = m.EmpName,
                    EmpCode = m.EmpCode,
                    WorkingDay = m.WorkingDay,
                    Present = m.Present,
                    LossDays = m.LossDays,
                    Absent = m.Absent,
                    Leaves = m.Leaves,
                    ProjectCode=m.ProjectCode,
                    SickLeaves = m.SickLeaves,
                    WeeklyOff = m.WeeklyOff,
                    Holiday = m.Holiday,
                    NormalOTHrs = m.NormalOTHrs,
                    HolidayOTHrs = m.HolidayOTHrs,
                    WeeklyOffOTHrs = m.WeeklyOffOTHrs,
                    ExtraOTHrs = m.ExtraOTHrs,
                    FExtraOTHrs = m.FExtraOTHrs,
                    TotalAddition = m.TotalAddition,
                    TotalEarning = m.TotalEarning,
                    TotalDeduction = m.TotalDeduction,
                    LoanDeduction = m.LoanDeduction,
                    NetSalary = m.NetSalary,
                    Dates = m.Dates
                }).ToList());
                int n = 0;
                int countl = 0;
                n = ObjList.Count;
                bool result = false;
                if (!SPDV.EditFlag)
                {
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        DateTime dte = Convert.ToDateTime(SPDV.CurrentDate);
                        string saldate = dte.ToString("yyyy-MM-dd");
                        dtstr4 = dte.ToString("MM");
                        DateTime dte1 = Convert.ToDateTime(SPDV.CurrentDate);
                        dtstr9 = dte.ToString("yyyy");
                        int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + PurchaseMgmtConstants.SalaryProcessHeader + "' ");
                        while (n > 0)
                        {


                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRSPD001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "' and flag=0 and not in (EmpCode='" + ObjList[n - 1].EmpCode + "')");
                            if (Stats1 == 0)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("'" + SPDV.CmpyCode + "',");
                                sb.Append("'" + SPDV.Code + "',");
                                sb.Append("'" + saldate + "',");
                                sb.Append("'" + ObjList[n - 1].Sno + "',");
                                sb.Append("'" + ObjList[n - 1].EmpName + "',");
                                sb.Append("'" + ObjList[n - 1].ProjectCode + "',");
                                sb.Append("'" + ObjList[n - 1].EmpCode + "',");
                                sb.Append("'" + ObjList[n - 1].WorkingDay + "',");
                                sb.Append("'" + ObjList[n - 1].Present + "',");
                                sb.Append("'" + ObjList[n - 1].LossDays + "',");
                                sb.Append("'" + ObjList[n - 1].Absent + "',");
                                sb.Append("'" + ObjList[n - 1].Leaves + "',");
                                sb.Append("'" + ObjList[n - 1].SickLeaves + "',");
                                sb.Append("'" + ObjList[n - 1].WeeklyOff + "',");
                                sb.Append("'" + ObjList[n - 1].Holiday + "',");
                                sb.Append("'" + ObjList[n - 1].NormalOTHrs + "',");
                                sb.Append("'" + ObjList[n - 1].HolidayOTHrs + "',");
                                sb.Append("'" + ObjList[n - 1].WeeklyOffOTHrs + "',");
                                sb.Append("'" + ObjList[n - 1].ExtraOTHrs + "',");
                                sb.Append("'" + ObjList[n - 1].FExtraOTHrs + "',");
                                sb.Append("'" + ObjList[n - 1].MonthlyAddition + "',");
                                sb.Append("'" + ObjList[n - 1].TotalEarning + "',");
                                sb.Append("'" + ObjList[n - 1].TotalDeduction + "',");
                                sb.Append("'" + ObjList[n - 1].LoanDeduction + "',");
                                sb.Append("'" + ObjList[n - 1].NetSalary + "')");
                                
                               
                                    result = _EzBusinessHelper.ExecuteNonQuery1("insert into PRSPD001(CmpyCode,Code,Dates,Sno,EmpName,ProjectCode,EmpCode,WorkingDay,Present,LossDays,Absent,Leaves,SickLeave,WeeklyOff,Holiday,NormalOTHrs,HolidayOTHrs,WeeklyOffOTHrs,ExtraOTHrs,FExtraOTHrs,TotalAddition,TotalEarning,TotalDeduction,LoanDeduction,NetSalary) values(" + sb.ToString() + "");
                                    if (result == true)
                                    {
                                        int loanstatus = _EzBusinessHelper.ExecuteScalar("select count(*) from PRLA001 prl inner join PRLA002 la on prl.PRLA001_CODE=la.PRLA001_CODE and prl.CmpyCode=la.CmpyCode where EmpCode='" + ObjList[n - 1].EmpCode + "' and la.TMONTH='" + dtstr4 + "' and la.TYEAR='" + dtstr9 + "'");

                                        if (loanstatus > 0)
                                            countl = _EzBusinessHelper.ExecuteNonQuery("UPDATE A SET Paid = 'Y' from PRLA002 A INNER JOIN PRLA001 RA ON A.PRLA001_CODE = RA.PRLA001_CODE and a.CmpyCode = ra.CmpyCode where a.TMONTH ='" + dtstr4 + "' and a.TYEAR ='" + dtstr9 + "' and ra.EmpCode ='" + ObjList[n - 1].EmpCode + "' and a.CmpyCode ='" + SPDV.CmpyCode + "'");
                                    }
                               
                            }
                            else
                            {
                                Drecord.Add(SPDV.Code.ToString());
                                SPDV.Drecord = Drecord;
                                SPDV.SaveFlag = false;
                                SPDV.ErrorMessage = "Duplicate Record";
                            }
                            n = n - 1;
                        }
                        if (result == true)
                        {
                            int Stats11 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRSPH001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "' and Flag=0");
                            if (Stats11 == 0)
                            {
                                StringBuilder sb1 = new StringBuilder();
                                sb1.Append("'" + SPDV.CmpyCode + "',");
                                sb1.Append("'" + SPDV.Code + "',");
                                sb1.Append("'" + saldate + "',");
                                sb1.Append("'" + dtstr4 + "',");
                                sb1.Append("'" + dtstr9 + "')");
                                bool flg = _EzBusinessHelper.ExecuteNonQuery1("insert into PRSPH001(CmpyCode,Code,Dates,TMonth,TYear) values(" + sb1.ToString() + "");
                                if (flg == true)
                                {
                                    //_EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + PurchaseMgmtConstants.SalaryProcessHeader + "'");
                                    _EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + PurchaseMgmtConstants.SalaryProcessHeader + "'");

                                    _EzBusinessHelper.ActivityLog(SPDV.CmpyCode, SPDV.UserName, "Add Salary Process", SPDV.Code, Environment.MachineName);
                                    SPDV.SaveFlag = true;
                                    SPDV.ErrorMessage = string.Empty;
                                }
                            }
                            else
                            {

                                Drecord.Add(ObjList[n - 1].Code.ToString());
                                SPDV.Drecord = Drecord;
                                SPDV.SaveFlag = false;
                                SPDV.ErrorMessage = "Duplicate Record";
                            }

                        }
                        else
                        {
                            SPDV.SaveFlag = false;
                            SPDV.ErrorMessage = "Inseretion Failed";
                        }
                        scope1.Complete();
                    }
                    return SPDV;
                }
                else
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        while (n > 0)
                        {
                            var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from PRSPD001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "' and Flag=0");
                            if (StatsEdit != 0)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("CmpyCode='" + SPDV.CmpyCode + "',");
                                sb.Append("Sno='" + ObjList[n - 1].Sno + "',");
                                sb.Append("Code='" + ObjList[n - 1].Code + "',");
                                sb.Append("EmpName='" + ObjList[n - 1].EmpName + "',");
                                sb.Append("ProjectCode='"+ ObjList[n - 1].ProjectCode + "',");
                                sb.Append("EmpCode='" + ObjList[n - 1].EmpCode + "',");
                                sb.Append("WorkingDay='" + ObjList[n - 1].WorkingDay + "',");
                                sb.Append("Present='" + ObjList[n - 1].Present + "',");
                                sb.Append("LossDays='" + ObjList[n - 1].LossDays + "',");
                                sb.Append("Absent='" + ObjList[n - 1].Absent + "',");
                                sb.Append("Leaves='" + ObjList[n - 1].Leaves + "',");
                                sb.Append("SickLeave='" + ObjList[n - 1].SickLeaves + "',");
                                sb.Append("WeeklyOff='" + ObjList[n - 1].WeeklyOff + "',");
                                sb.Append("Holiday='" + ObjList[n - 1].Holiday + "',");
                                sb.Append("NormalOTHrs='" + ObjList[n - 1].NormalOTHrs + "',");
                                sb.Append("HolidayOTHrs='" + ObjList[n - 1].HolidayOTHrs + "',");
                                sb.Append("WeeklyOffOTHrs='" + ObjList[n - 1].WeeklyOffOTHrs + "',");
                                sb.Append("ExtraOTHrs='" + ObjList[n - 1].ExtraOTHrs + "',");
                                sb.Append("FExtraOTHrs='" + ObjList[n - 1].FExtraOTHrs + "',");
                                sb.Append("TotalAddition='" + ObjList[n - 1].MonthlyAddition + "',");
                                sb.Append("TotalEarning='" + ObjList[n - 1].TotalEarning + "',");
                                sb.Append("TotalDeduction='" + ObjList[n - 1].TotalDeduction + "',");
                                sb.Append("LoanDeduction='" + ObjList[n - 1].LoanDeduction + "',");
                                sb.Append("NetSalary='" + ObjList[n - 1].NetSalary + "')");
                                _EzBusinessHelper.ExecuteNonQuery("update PRSPD001 set'" + sb.ToString() + "' where compycode='" + SPDV.CmpyCode + "'and code='" + SPDV.Code + "' and Flag=0 ");

                                _EzBusinessHelper.ActivityLog(SPDV.CmpyCode, SPDV.UserName, "Update Salary Process", SPDV.Code, Environment.MachineName);

                                SPDV.SaveFlag = true;
                                SPDV.ErrorMessage = string.Empty;
                            }
                            else
                            {
                                SPDV.SaveFlag = false;
                                SPDV.ErrorMessage = "Record not available";
                            }
                            n = n - 1;
                        }
                        var SalaryEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from PRSPH001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "' and Flag=0");
                        if (SalaryEdit != 0)
                        {
                            _EzBusinessHelper.ExecuteNonQuery("update PRSPH001 set CmpyCode='" + SPDV.CmpyCode + "',Code='" + SPDV.Code + "',Month='" + dtstr4 + "',year='" + dtstr9 + "' where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "' and Flag=0");
                            SPDV.SaveFlag = true;
                            SPDV.ErrorMessage = string.Empty;
                        }
                        else
                        {
                            SPDV.SaveFlag = false;
                            SPDV.ErrorMessage = "Record not available";
                        }
                        scope.Complete();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                SPDV.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return SPDV;
        }
        public string GetSalaryProcessId(string CmpyCode)
        {
           int slrycode = _EzBusinessHelper.ExecuteScalar("select Nos from PARTTBL001 where CmpyCode='" + CmpyCode + "' and Code='SP'" );
           string SprocessCode = string.Concat(PurchaseMgmtConstants.SalaryProcessHeader, "-", (Convert.ToInt16(slrycode)).ToString().PadLeft(4, '0')).ToString();
           return SprocessCode;
        }

        public List<SalaryProcessDetailsListItem> GetSalaryProcessGridEdit(string CmpyCode, string PRSPD001_code)
        {

            ds = _EzBusinessHelper.ExecuteDataSet("select * from PRSPD001 where CmpyCode='" + CmpyCode + "' and code='" + PRSPD001_code + "' and flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<SalaryProcessDetailsListItem> objList = new List<SalaryProcessDetailsListItem>();
            foreach (DataRow dr in drc)
            {
                objList.Add(new SalaryProcessDetailsListItem()
                {
                    EmpCode = dr["EmpCode"].ToString(),
                    EmpName = dr["empname"].ToString(),
                    ProjectCode=dr["ProjectCode"].ToString(),
                    WorkingDay = Convert.ToDecimal(dr["workingday"].ToString()),
                    Present = Convert.ToDecimal(dr["Present"].ToString()),
                    Leaves = Convert.ToDecimal(dr["Leaves"].ToString()),
                    Absent = Convert.ToDecimal(dr["Absent"].ToString()),
                    SickLeaves = Convert.ToDecimal(dr["SickLeave"].ToString()),
                    WeeklyOff = Convert.ToDecimal(dr["WeeklyOff"].ToString()),
                    Holiday = Convert.ToDecimal(dr["Holiday"].ToString()),
                    NormalOTHrs = Convert.ToDecimal(dr["NormalOTHrs"].ToString()),
                    HolidayOTHrs = Convert.ToDecimal(dr["HolidayOTHrs"].ToString()),
                    WeeklyOffOTHrs = Convert.ToDecimal(dr["WeeklyOffOTHrs"].ToString()),
                    ExtraOTHrs = Convert.ToDecimal(dr["ExtraOTHrs"].ToString()),
                    TotalEarning = Convert.ToDecimal(dr["TotalEarning"].ToString()),
                    TotalDeduction = Convert.ToDecimal(dr["TotalDeduction"].ToString()),
                    NetSalary = Convert.ToDecimal(dr["NetSalary"].ToString()),
                    SickLeave = dr["SickLeave"].ToString(),
                    MonthlyAddition = Convert.ToDecimal(dr["TotalAddition"].ToString()),
                });
            }
            return objList;
        }
        public bool CheckslryDataCalculated(string CmpyCode, DateTime CurrDate)
        {
            string dtesly = CurrDate.ToString("MM");
            string dtesly1 = CurrDate.ToString("yyyy");
            int slrydata = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSPD001 where CmpyCode='" + CmpyCode + "' and Flag=0 and month(Dates)='" + dtesly + "' and year(Dates)='"+dtesly1+"'");
            if (slrydata > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
