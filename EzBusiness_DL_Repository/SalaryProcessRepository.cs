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

namespace EzBusiness_DL_Repository
{
    public class SalaryProcessRepository : ISalaryProcessDRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
   
        public bool DeleteSalaryProcess(string CmpyCode,string EmpCode,string sal_Code,string flag, string username)
        {
            int salary = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSPH001 where CmpyCode='" + CmpyCode + "' and Code='" + sal_Code + "'");
            if (salary != 0)
            {
                if (flag == "sp")
                {
                    _EzBusinessHelper.ExecuteNonQuery("update  PRSPD001 set flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + sal_Code + "' and EmpCode='" + EmpCode + "'");

                    _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Salary Process", sal_Code, Environment.MachineName);

                    return true;
                }
                if(flag == "spH")
                {
                    _EzBusinessHelper.ExecuteNonQuery("update  PRSPD001 set flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + sal_Code + "' and EmpCode='" + EmpCode + "'");
                    _EzBusinessHelper.ExecuteNonQuery("update  PRSPH001 set flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + sal_Code + "'");

                    _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Salary Process", sal_Code, Environment.MachineName);

                    return true;
                }

            }
            return false;
        }

        public List<SalaryProcessDetailsVM> GetSalaryDetailsList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select CmpyCode,Code,Dates from PRSPD001 where CmpyCode='" + CmpyCode + "'");
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
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                                    new SqlParameter("@Year", yeardata),
                                     new SqlParameter("@Month",monthdata)};
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
                SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                                    new SqlParameter("@Year", yeardata),
                                     new SqlParameter("@Month",monthdata)};
            //   ds = _EzBusinessHelper.ExecuteDataSet("usp_GetEmployeeNotInDTSbMonthly", CommandType.StoredProcedure, param);
            //if (ds.Tables.Count >= 0)
            //{
            //    dt = ds.Tables[0];
            //    DataRowCollection drc = dt.Rows;
            //    objList = new List<SalaryProcessDetailsListItem>();
            //    foreach (DataRow dr in drc)
            //    {
            //        objList.Add(new SalaryProcessDetailsListItem()
            //        {
            //            EmpCode = dr["EmpCode"].ToString(),
            //            EmpName = dr["Empname"].ToString(),
            //        });
            //    }   
            // }
            //else
            //{
                ds = _EzBusinessHelper.ExecuteDataSet("usp_GetSlryProsesDetails", CommandType.StoredProcedure, param);
                if (ds.Tables.Count > 0)
                {

                    dt = ds.Tables[0];
                    DataRowCollection drc = dt.Rows;
                    objList = new List<SalaryProcessDetailsListItem>();
                    foreach (DataRow dr in drc)
                    {
                        objList.Add(new SalaryProcessDetailsListItem()
                        {
                            EmpCode = dr["EmpCode"].ToString(),
                            EmpName = dr["empname"].ToString(),
                            WorkingDay = Convert.ToDecimal(dr["workingday"].ToString()),
                            Present = Convert.ToDecimal(dr["Present"].ToString()),
                            Leaves = Convert.ToDecimal(dr["AnnualLeave"].ToString()),
                            Absent = Convert.ToDecimal(dr["Absentt"].ToString()),
                            SickLeaves = Convert.ToDecimal(dr["SickLeave"].ToString()),
                            WeeklyOff = Convert.ToDecimal(dr["WeeklyOff"].ToString()),
                            Holiday = Convert.ToDecimal(dr["Holiday"].ToString()),
                            NormalOTHrs = Convert.ToDecimal(dr["NOTHrs"].ToString()),
                            HolidayOTHrs = Convert.ToDecimal(dr["HOTHrs"].ToString()),
                            WeeklyOffOTHrs = Convert.ToDecimal(dr["FOTHrs"].ToString()),
                            ExtraOTHrs = Convert.ToDecimal(dr["ExtraOTHrs"].ToString()),
                            TotalEarning = Convert.ToDecimal(dr["TotalEarningdata"].ToString()),
                            TotalDeduction = Convert.ToDecimal(dr["Deduction"].ToString()),
                            NetSalary = Convert.ToDecimal(dr["netsalarydata"].ToString()),
                            MonthlyAddition = Convert.ToDecimal(dr["Addition"].ToString()),
                            LoanDeduction = Convert.ToDecimal(dr["LoanDeductiondata"].ToString()),
                            //ErrorMsg = (dr["Flag"].ToString()),
                            Salary = Convert.ToDecimal(dr["BasicSalary"].ToString()),

                        });
                    }
                }
            
                return objList;
            
        }
        public SalaryProcessDetailsVM  GetSalaryProcessEdit(string CmpyCode,string salaryCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select * from PRSPH001 where CmpyCode='" + CmpyCode + "' and code='" + salaryCode + "'");
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
                    EmpName = m.EmpName,
                    EmpCode = m.EmpCode,
                    WorkingDay = m.WorkingDay,
                    Present = m.Present,
                    LossDays = m.LossDays,
                    Absent = m.Absent,
                    Leaves = m.Leaves,
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
                    DateTime dte = Convert.ToDateTime(SPDV.CurrentDate);
                    string saldate = dte.ToString("yyyy-MM-dd");
                    dtstr4 = dte.ToString("MM");
                    DateTime dte1 = Convert.ToDateTime(SPDV.CurrentDate);
                    dtstr9 = dte.ToString("yyyy");
                    int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + PurchaseMgmtConstants.SalaryProcessHeader + "' ");
                    while (n > 0)
                    {
                        

                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRSPD001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "' and not in (EmpCode='" + ObjList[n - 1].EmpCode + "')");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + SPDV.CmpyCode + "',");
                            sb.Append("'" + SPDV.Code + "',");
                            sb.Append("'" + saldate + "',");
                            sb.Append("'" + ObjList[n - 1].Sno + "',");
                            sb.Append("'" + ObjList[n - 1].EmpName + "',");
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
                            result = _EzBusinessHelper.ExecuteNonQuery1("insert into PRSPD001(CmpyCode,Code,Dates,Sno,EmpName,EmpCode,WorkingDay,Present,LossDays,Absent,Leaves,SickLeave,WeeklyOff,Holiday,NormalOTHrs,HolidayOTHrs,WeeklyOffOTHrs,ExtraOTHrs,FExtraOTHrs,TotalAddition,TotalEarning,TotalDeduction,LoanDeduction,NetSalary) values(" + sb.ToString() + "");
                            if (result == true)
                            {
                                countl = _EzBusinessHelper.ExecuteNonQuery("UPDATE A SET Paid = 'Y' from PRLA002 A INNER JOIN PRLA001 RA ON A.PRLA001_CODE = RA.PRLA001_CODE and a.CmpyCode = ra.CmpyCode where a.TMONTH = 11 and a.TYEAR = 2018 and ra.EmpCode ='" + ObjList[n - 1].EmpCode + "' and a.CmpyCode ='" + SPDV.CmpyCode + "'");
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
                        if (result == true && countl>0)
                            {
                                int Stats11 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRSPH001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "'");
                                if (Stats11 == 0)
                                {
                                    StringBuilder sb1 = new StringBuilder();
                                    sb1.Append("'" + SPDV.CmpyCode + "',");
                                    sb1.Append("'" + SPDV.Code + "',");
                                    sb1.Append("'" + saldate + "',");
                                    sb1.Append("'" + dtstr4 + "',");
                                    sb1.Append("'" + dtstr9 + "')");
                                   bool flg= _EzBusinessHelper.ExecuteNonQuery1("insert into PRSPH001(CmpyCode,Code,Dates,TMonth,TYear) values(" + sb1.ToString() + "");
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

                    return SPDV;
                }
                else
                {
                    while (n > 0)
                    {
                        var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from PRSPD001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "'");
                        if (StatsEdit != 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("CmpyCode='" + SPDV.CmpyCode + "',");
                            sb.Append("Sno='" + ObjList[n - 1].Sno + "',");
                            sb.Append("Code='" + ObjList[n - 1].Code + "',");
                            sb.Append("EmpName='" + ObjList[n - 1].EmpName + "',");
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
                            _EzBusinessHelper.ExecuteNonQuery("update PRSPD001 set'" + sb.ToString() + "' where compycode='" + SPDV.CmpyCode + "'and code='" + SPDV.Code + "' ");

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
                    var SalaryEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from PRSPH001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "'");
                    if (SalaryEdit != 0)
                    {
                        _EzBusinessHelper.ExecuteNonQuery("update PRSPH001 set CmpyCode='" + SPDV.CmpyCode + "',Code='" + SPDV.Code + "',Month='" + dtstr4 + "',year='" + dtstr9 + "' where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.Code + "'");
                        SPDV.SaveFlag = true;
                        SPDV.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        SPDV.SaveFlag = false;
                        SPDV.ErrorMessage = "Record not available";
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
                    //  Dates =Convert.ToDateTime(dr["Dates"].ToString()),
                    WorkingDay = Convert.ToDecimal(dr["workingday"].ToString()),
                    Present = Convert.ToDecimal(dr["Present"].ToString()),
                    Leaves = Convert.ToDecimal(dr["Leaves"].ToString()),
                    Absent = Convert.ToDecimal(dr["Absent"].ToString()),
                    SickLeaves = Convert.ToDecimal(dr["SickLeave"].ToString()),
                    WeeklyOff = Convert.ToDecimal(dr["WeeklyOff"].ToString()),
                    Holiday = Convert.ToDecimal(dr["Holiday"].ToString()),
                    NormalOTHrs = Convert.ToDecimal(dr["NormalOTHrs"].ToString()),
                    // HolidayOTHrs = Convert.ToDecimal(dr["HOTHrs"].ToString()),
                    // WeeklyOffOTHrs = Convert.ToDecimal(dr["ExtraOTHrs"].ToString()),
                    //  ExtraOTHrs = Convert.ToDecimal(dr["ExtraOTHrs"].ToString()),
                    // TotalEarning = Convert.ToDecimal(dr["TotalEarning"].ToString()),
                    TotalDeduction = Convert.ToDecimal(dr["TotalDeduction"].ToString()),
                    // NetSalary = Convert.ToDecimal(dr["NetSalary"].ToString()),
                    //SickLeave = dr["SickLeave"].ToString(),
                    MonthlyAddition = Convert.ToDecimal(dr["TotalAddition"].ToString()),
                });
            }
            return objList;
        }
    }
}
