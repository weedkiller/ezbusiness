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
        DropListFillFun drop = new DropListFillFun();
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
   
        public bool DeleteSalaryProcess(string CmpyCode, string Code, DateTime CurrDate, string UserName)
        {
            string dtr = CurrDate.ToString("MM");
            string dtr1 = CurrDate.ToString("yyyy");
            int salary = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSP001 where CmpyCode='" + CmpyCode + "' and PRSP001_Code='" + Code + "' and Flag=0");
            if (salary != 0)
            {
                //int n = salary;
                

                int i=   _EzBusinessHelper.ExecuteNonQuery("update  PRSP002 set flag=1 where CmpyCode='" + CmpyCode + "' and  Tmonth='" + dtr + "' and Tyear='" + dtr1 + "'");
                if (i > 0)
                {
                   _EzBusinessHelper.ExecuteNonQuery("update  PRSP001 set flag=1 where CmpyCode='" + CmpyCode + "' and PRSP001_Code='" + Code + "'");
                    _EzBusinessHelper.ExecuteNonQuery("update  PRSP001 set flag=1 where CmpyCode='" + CmpyCode + "' and PRSP001_Code='" + Code + "'");

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
            List<SalaryProcessDetailsVM> ObjList = null;
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode)};
            ds = _EzBusinessHelper.ExecuteDataSet("salaryProcessHeaderDetails",CommandType.StoredProcedure,param);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                 ObjList = new List<SalaryProcessDetailsVM>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new SalaryProcessDetailsVM()
                    {
                        CmpyCode = dr["CmpyCode"].ToString(),
                        Country = dr["Country"].ToString(),
                        DivisionCode = dr["Division"].ToString(),
                        DivisionName = dr["DivisionName"].ToString(),
                        Deptcode=dr["Deptcode"].ToString(),
                        DeptName = dr["DepartmentName"].ToString(),
                        VisaLocation1 =dr["Visalocation"].ToString(),
                        VisaLocationName = dr["Name"].ToString(),
                        year =Convert.ToInt32(dr["Tyear"].ToString()),
                        Month=Convert.ToInt32(dr["Tmonth"].ToString()),
                        PRSP001_Code = dr["PRSP001_CODE"].ToString(),
                        Process_Date = Convert.ToDateTime(dr["Process_Date"].ToString())
                    });

                }
            }
            return ObjList;
        }
       public  List<SalaryProcessDetailsListItem> GetTimeSheetDetailsByMonth(string CmpyCode, DateTime currDate,string divcode,string deptcode,string Visalocation1)
        {
            string deptcode1 = deptcode == "0" ? "" : deptcode;
            string vloc1 = Visalocation1 == "0" ? "" : Visalocation1;
            List<SalaryProcessDetailsListItem> objList = null;
            string yeardata = currDate.ToString("yyyy");
            string monthdata = currDate.ToString("MM");
            var lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(currDate.ToString("yyyy")), Convert.ToInt32(currDate.ToString("MM")));
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                                     new SqlParameter("@divcode", divcode),
                                     new SqlParameter("@Year", yeardata),
                                      new SqlParameter("@deptcode", deptcode1),
                                       new SqlParameter("@VisaLocation1",vloc1),
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
                        Empcode = dr["EmpCode"].ToString(),
                        Empname = dr["Empname"].ToString(),
                        srno =Convert.ToInt32(dr["srno"].ToString()),
                    });
                }
               
            }
            return objList;
        }
        public List<SalaryProcessDetailsListItem> GetSalaryProcessGrid(string CmpyCode, DateTime currDate,string DivCode,string deptcode,string visaloc)
        {
            string deptcode1 = deptcode == "0" ? "" : deptcode;
            string vloc1 = visaloc == "0" ? "" : visaloc;
            List<SalaryProcessDetailsListItem> objList = null;
                string yeardata = currDate.ToString("yyyy");
                string monthdata = currDate.ToString("MM");
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                                    new SqlParameter("@DivCode",DivCode),
                                    new SqlParameter("@deptcode",deptcode1),
                                    new SqlParameter("@vloc",vloc1),
                                    new SqlParameter("@Year", yeardata),
                                    new SqlParameter("@Month",monthdata)};
            ds = _EzBusinessHelper.ExecuteDataSet("GetCalculatedSalaryDetails", CommandType.StoredProcedure,param);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;                
                    objList = new List<SalaryProcessDetailsListItem>();
                    foreach (DataRow dr in drc)
                    {
                        objList.Add(new SalaryProcessDetailsListItem()
                        {
                            srno=Convert.ToInt32(dr["SrNo"].ToString()),
                            Empcode = dr["empcode"].ToString(),
                            Empname = dr["Empname"].ToString(),
                            country=dr["country"].ToString(),
                            Tmonth=Convert.ToInt32(dr["Tmonth"].ToString()),
                            Tyear = Convert.ToInt32(dr["Tyear"].ToString()),
                            cmpycode = dr["cmpycode"].ToString(),
                            ProfCode = dr["ProfCode"].ToString(),
                            DepCode = dr["DepCode"].ToString(),
                            ComnPrjcode = dr["ComnPrjcode"].ToString(),
                            Division = dr["Division"].ToString(),
                            VisaLocation = dr["VisaLocation"].ToString(),
                            WorkLocation = dr["WorkLocation"].ToString(),
                            Total_Days = Convert.ToInt32(dr["Total_Days"].ToString()),
                            Worked_Days = Convert.ToInt32(dr["Worked_Days"].ToString()),
                            a_basic =Convert.ToDecimal(dr["a_basic"].ToString()),
                            a_hra =Convert.ToDecimal(dr["a_hra"].ToString()),
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
                            loan_amt =Convert.ToDecimal(dr["loan_amt"].ToString()),
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

                        });
                    }
                }
            
                return objList;
        }
        public SalaryProcessDetailsVM  GetSalaryProcessEdit(string CmpyCode,string salaryCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select * from PRSP001 where CmpyCode='" + CmpyCode + "' and PRSP001_CODE='" + salaryCode + "' and Flag=0");
            dt = ds.Tables[0];
            SalaryProcessDetailsVM drc = new SalaryProcessDetailsVM();
            foreach (DataRow dr in dt.Rows)
            {
                    drc.CmpyCode = dr["CmpyCode"].ToString();
                    drc.PRSP001_Code = dr["PRSP001_Code"].ToString();
                    drc.Country = dr["Country"].ToString();
                    drc.DivisionCode = dr["Division"].ToString();
                    drc.VisaLocation1 = dr["VisaLocation"].ToString();
                    drc.year =Convert.ToInt32(dr["Tyear"].ToString());
                    drc.Month = Convert.ToInt32(dr["Tmonth"].ToString());
                    drc.Process_Date =Convert.ToDateTime(dr["Process_Date"].ToString());
            }
            return drc;

        }
      
        public SalaryProcessDetailsVM SaveSalaryProcessD(SalaryProcessDetailsVM SPDV)
        {
            string deptcode1 = SPDV.Deptcode == "0" ? "" : SPDV.Deptcode;
            string vloc1 = SPDV.VisaLocation1 == "0" ? "" : SPDV.VisaLocation1;
            string Month = "";
            string year = "";
            List<SalaryProcessDetailsListItem> objList = null;           
            try
            {
                var Drecord = new List<string>();
                List<SalaryProcessDetailsListItem> ObjList = new List<SalaryProcessDetailsListItem>();
                ObjList.AddRange(SPDV.salaryList.Select(m => new SalaryProcessDetailsListItem
                {
                    //country = m.country,
                    //Division = m.Division,
                    //Tyear = m.Tyear,
                    //Tmonth = m.Tmonth,
                    Empcode = m.Empcode,
                    //Empname = m.Empname,
                    //ProfCode = m.ProfCode,
                    //DepCode = m.DepCode,
                    //ComnPrjcode = m.ComnPrjcode,
                    //VisaLocation = m.VisaLocation,
                    //WorkLocation = m.WorkLocation,
                    //Total_Days = m.Total_Days,
                    //Worked_Days = m.Worked_Days,               
                    //loan_amt = m.loan_amt,
                    //adn_amount = m.adn_amount,
                    //ExtraOTAmt = m.ExtraOTAmt,
                    //NOTAmt = m.NOTAmt,
                    //HOTAmt = m.HOTAmt,
                    //WOTAmt = m.WOTAmt,
                    //NetSalary = m.NetSalary,
                    //flag = m.flag,
                    //Salary_Paid = m.Salary_Paid,
                    //Incentive_Paid = m.Incentive_Paid

                }).ToList());
                int n = 0;
                int countl = 0;
                n = ObjList.Count;
               
                if (!SPDV.EditFlag)
                {

                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        DateTime dte = Convert.ToDateTime(SPDV.Process_Date);
                        string saldate = dte.ToString("yyyy-MM-dd");
                        Month = dte.ToString("MM");
                        DateTime dte1 = Convert.ToDateTime(SPDV.Process_Date);
                        year = dte.ToString("yyyy");
                        string yeardata = SPDV.Process_Date.ToString("yyyy");
                        string monthdata = SPDV.Process_Date.ToString("MM");
                        SqlParameter[] param = {new SqlParameter("@CmpyCode",SPDV.CmpyCode),
                                    new SqlParameter("@DivCode",SPDV.DivisionCode),
                                    new SqlParameter("@Year", yeardata),
                                     new SqlParameter("@Month",monthdata),
                                     new SqlParameter("@UserName",SPDV.UserName),
                                     new SqlParameter("@PRSP001_CODE",SPDV.PRSP001_Code),
                                     new SqlParameter("Process_Date",SPDV.Process_Date),
                                     new SqlParameter("@DeptCode",deptcode1),
                                     new SqlParameter("@visaloction",vloc1)};
                        bool result = _EzBusinessHelper.ExecuteNonQuery("usp_SaveDataSalaryProcess", param);
                        int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + PurchaseMgmtConstants.SalaryProcessHeader + "' ");
                        if (result == true)
                        {
                            while (n > 0)
                            {
                                // decimal Stats1 = _EzBusinessHelper.ExecuteScalarDec("Select count(*) as [count1] from PRSP002 where CmpyCode='" + SPDV.CmpyCode + "'  and flag=0 and empcode='" + ObjList[n - 1].Empcode + "'");   
                                int loanstatus = _EzBusinessHelper.ExecuteScalar("select count(*) from PRLA001 prl inner join PRLA002 la on prl.PRLA001_CODE=la.PRLA001_CODE and prl.CmpyCode=la.CmpyCode where EmpCode='" + ObjList[n - 1].Empcode + "' and la.TMONTH='" + Month + "' and la.TYEAR='" + year + "'");
                                if (loanstatus > 0)
                                    countl = _EzBusinessHelper.ExecuteNonQuery("UPDATE A SET Paid = 'Y' from PRLA002 A INNER JOIN PRLA001 RA ON A.PRLA001_CODE = RA.PRLA001_CODE and a.CmpyCode = ra.CmpyCode where a.TMONTH ='" + Month + "' and a.TYEAR ='" + year + "' and ra.EmpCode ='" + ObjList[n - 1].Empcode + "' and a.CmpyCode ='" + SPDV.CmpyCode + "'");

                                n = n - 1;
                            }
                        }
                            
                                //if (bool flg == true)
                                //{
                                    //_EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + PurchaseMgmtConstants.SalaryProcessHeader + "'");
                                   // _EzBusinessHelper.ExecuteNonQuery("UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + PurchaseMgmtConstants.SalaryProcessHeader + "'");
                                    _EzBusinessHelper.ActivityLog(SPDV.CmpyCode, SPDV.UserName, "Add Salary Process", SPDV.PRSP001_Code, Environment.MachineName);
                                    SPDV.SaveFlag = true;
                                    SPDV.ErrorMessage = string.Empty;
                                //}
                           

                        
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
                            var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from PRSPD001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.PRSP001_Code + "' and Flag=0");
                            if (StatsEdit != 0)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("CmpyCode='" + SPDV.CmpyCode + "',");
                                //sb.Append("Sno='" + ObjList[n - 1].Sno + "',");
                                //sb.Append("Code='" + ObjList[n - 1].Code + "',");
                                //sb.Append("EmpName='" + ObjList[n - 1].EmpName + "',");
                                //sb.Append("ProjectCode='"+ ObjList[n - 1].ProjectCode + "',");
                                //sb.Append("EmpCode='" + ObjList[n - 1].EmpCode + "',");
                                //sb.Append("WorkingDay='" + ObjList[n - 1].WorkingDay + "',");
                                //sb.Append("Present='" + ObjList[n - 1].Present + "',");
                                //sb.Append("LossDays='" + ObjList[n - 1].LossDays + "',");
                                //sb.Append("Absent='" + ObjList[n - 1].Absent + "',");
                                //sb.Append("Leaves='" + ObjList[n - 1].Leaves + "',");
                                //sb.Append("SickLeave='" + ObjList[n - 1].SickLeaves + "',");
                                //sb.Append("WeeklyOff='" + ObjList[n - 1].WeeklyOff + "',");
                                //sb.Append("Holiday='" + ObjList[n - 1].Holiday + "',");
                                //sb.Append("NormalOTHrs='" + ObjList[n - 1].NormalOTHrs + "',");
                                //sb.Append("HolidayOTHrs='" + ObjList[n - 1].HolidayOTHrs + "',");
                                //sb.Append("WeeklyOffOTHrs='" + ObjList[n - 1].WeeklyOffOTHrs + "',");
                                //sb.Append("ExtraOTHrs='" + ObjList[n - 1].ExtraOTHrs + "',");
                                //sb.Append("FExtraOTHrs='" + ObjList[n - 1].FExtraOTHrs + "',");
                                //sb.Append("TotalAddition='" + ObjList[n - 1].MonthlyAddition + "',");
                                //sb.Append("TotalEarning='" + ObjList[n - 1].TotalEarning + "',");
                                //sb.Append("TotalDeduction='" + ObjList[n - 1].TotalDeduction + "',");
                                //sb.Append("LoanDeduction='" + ObjList[n - 1].LoanDeduction + "',");
                                sb.Append("NetSalary='" + ObjList[n - 1].NetSalary + "')");
                                _EzBusinessHelper.ExecuteNonQuery("update PRSPD001 set'" + sb.ToString() + "' where compycode='" + SPDV.CmpyCode + "'and code='" + SPDV.PRSP001_Code + "' and Flag=0 ");

                                _EzBusinessHelper.ActivityLog(SPDV.CmpyCode, SPDV.UserName, "Update Salary Process", SPDV.PRSP001_Code, Environment.MachineName);

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
                        var SalaryEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from PRSPH001 where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.PRSP001_Code + "' and Flag=0");
                        if (SalaryEdit != 0)
                        {
                            _EzBusinessHelper.ExecuteNonQuery("update PRSPH001 set CmpyCode='" + SPDV.CmpyCode + "',Code='" + SPDV.PRSP001_Code + "',Month='" + Month + "',year='" + year + "' where CmpyCode='" + SPDV.CmpyCode + "' and Code='" + SPDV.PRSP001_Code + "' and Flag=0");
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
        //public string GetSalaryProcessId(string CmpyCode)
        //{
        //   int slrycode = _EzBusinessHelper.ExecuteScalar("select Nos from PARTTBL001 where CmpyCode='" + CmpyCode + "' and Code='SP'" );
        //   string SprocessCode = string.Concat(PurchaseMgmtConstants.SalaryProcessHeader, "-", (Convert.ToInt16(slrycode)).ToString().PadLeft(4, '0')).ToString();
        //   return SprocessCode;
        //}

        public List<SalaryProcessDetailsListItem> GetSalaryProcessGridEdit(int year, int month, string cmpycode)
        {
            List<SalaryProcessDetailsListItem> objList = null;
            ds = _EzBusinessHelper.ExecuteDataSet("select ROW_NUMBER() over(partition by cmpycode order by empcode) as SrNo,* from PRSP002 where CmpyCode='" + cmpycode + "'  and flag=0 and Tyear='" + year + "' and Tmonth='" + month + "'");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<SalaryProcessDetailsListItem>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new SalaryProcessDetailsListItem()
                    {
                        srno = Convert.ToInt32(dr["SrNo"].ToString()),
                        Empcode = dr["empcode"].ToString(),
                        Empname = dr["Empname"].ToString(),
                        country = dr["country"].ToString(),
                        Tmonth = Convert.ToInt32(dr["Tmonth"].ToString()),
                        Tyear = Convert.ToInt32(dr["Tyear"].ToString()),
                        cmpycode = dr["cmpycode"].ToString(),
                        ProfCode = dr["ProfCode"].ToString(),
                        DepCode = dr["DepCode"].ToString(),
                        ComnPrjcode = dr["ComnPrjcode"].ToString(),
                        Division = dr["Division"].ToString(),
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


                    });
                }
            }
                return objList;
            
        }
        public bool CheckslryDataCalculated(string CmpyCode, DateTime CurrDate, string divcode, string deptcode, string visaloc)
        {
            string deptcode1 = deptcode == "0" ? "" : deptcode;
            string vloc1 = visaloc == "0" ? "" : visaloc;
            string dtesly = CurrDate.ToString("MM");
            string dtesly1 = CurrDate.ToString("yyyy");
            int slrydata = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSP001 where CmpyCode='"+CmpyCode+"' and Flag=0 and Tmonth='"+ dtesly + "' and Tyear='" + dtesly1 + "' and Division='"+divcode+"' and ('"+ deptcode1 + "'='' or Deptcode='"+ deptcode1 + "')  and ('" + vloc1 + "'='' or Visalocation='" + vloc1 + "')");
            if (slrydata > 0)
            {
                return true;
            }
            else
                return false;
        }
        public List<Department> GetDepartmentList(string CmpyCode, string divcode)
        {
            return drop.GetDepCodebyDivision(CmpyCode, divcode);
        }
        public List<ComDropTbl> GetDepartmentList1(string CmpyCode, string divcode,string Prefix)
        {
            return drop.GetCommonDrop("DepartmentCode as [Code],DepartmentName as [CodeName]", "MDEP009", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (DepartmentCode like '" + Prefix + "%' or DepartmentName like '" + Prefix + "%')");

        }
    }
}
