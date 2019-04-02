using EzBusiness_DL_Interface;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EzBusiness_DL_Repository
{
   public class SalaryProcessPaymentRepository: IsalaryProcessPaymentRepository
    {
        DataSet ds = null;
        DataTable dt = null;
        DropListFillFun drop = new DropListFillFun();
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteSalaryProcessPayment(string CmpyCode, string SalCode, DateTime CurrDate, string username)
        {
            string dtr = CurrDate.ToString("MM");
            string dtr1 = CurrDate.ToString("yyyy");
            int salary = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSPD001 where CMPYCODE='" + CmpyCode + "' and PRSPD001_CODE='" + SalCode + "' and Flag=0");
            if (salary != 0)
            {
                //int n = salary;


                int i = _EzBusinessHelper.ExecuteNonQuery("update  PRSPD002 set flag=1 where  PRSPD001_CODE='" + SalCode + "'");
                if (i > 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update  PRSPD001 set flag=1 where CMPYCODE='" + CmpyCode + "' and PRSPD001_CODE='" + SalCode + "'and  TMONTH='" + dtr + "' and TYEAR='" + dtr1 + "'");
                   // _EzBusinessHelper.ExecuteNonQuery("update  PRSP001 set flag=1 where CmpyCode='" + CmpyCode + "' and PRSP001_Code='" + Code + "'");

                    _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Salary Process Details", SalCode, Environment.MachineName);

                    return true;
                }
                else
                    return false;
            }
            return false;
        }
        public List<SalaryProcessDVM> GetSalaryprocessPymntDetailList(string CmpyCode)
        {
            List<SalaryProcessDVM> ObjList = null;
            SqlParameter[] param = { new SqlParameter("@CmpyCode", CmpyCode) };
            ds = _EzBusinessHelper.ExecuteDataSet("sp_salaryprocessPaymentHeader", CommandType.StoredProcedure, param);
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<SalaryProcessDVM>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new SalaryProcessDVM()
                    {
                        CMPYCODE = dr["CmpyCode"].ToString(),
                        COUNTRY = dr["Country"].ToString(),
                        DIVISION = dr["Division"].ToString(),
                        DivisionName = dr["DivisionName"].ToString(),
                        PRSPD001_CODE = dr["PRSPD001_CODE"].ToString(),
                       // WORKLOCATION = dr["DepartmentName"].ToString(),
                        TYEAR = Convert.ToInt32( dr["Tyear"].ToString()),
                        TMONTH = Convert.ToInt32(dr["Tmonth"].ToString()),
                        PAIDTYPE = Convert.ToInt32(dr["PAIDTYPE"].ToString()),
                       
                    });

                }
            }
            return ObjList;
        }
       //public List<SalaryProcessDVM> GetNewbtnsalaryPrcesspaymentDetails(string CmpyCode)
       // {
       //     return null;
       // }
        public SalaryProcessDVM GetEditedsalryprocessPaymentdetails(string cmpycpode)
        {
            return null;
        }
        public List<SalaryprocesspaymentDetails> GetSalaryPrcessDetailsList(SalaryProcessDVM slrypymnt)
        {
            //string deptcode1 = deptcode == "0" ? "" : deptcode;
            //string vloc1 = Visalocation1 == "0" ? "" : Visalocation1;
            List<SalaryprocesspaymentDetails> objList = null;
            string yeardata = slrypymnt.SalProcess_Date.ToString("yyyy");
            string monthdata = slrypymnt.SalProcess_Date.ToString("MM");
            //  var lastDayOfMonth = DateTime.DaysInMonth(Convert.ToInt32(currDate.ToString("yyyy")), Convert.ToInt32(currDate.ToString("MM")));
            SqlParameter[] param = {new SqlParameter("@CmpyCode", slrypymnt.CMPYCODE),
                                     new SqlParameter("@divcode", slrypymnt.DIVISION),
                                     new SqlParameter("@Year", yeardata),
                                     //new SqlParameter("@PAIDTYPE", slrypymnt.PAIDTYPE),
                                      // new SqlParameter("@VisaLocation1",vloc1),
                                     new SqlParameter("@Month",monthdata) };
                                   //  new SqlParameter("@lastdate",lastDayOfMonth)};
            ds = _EzBusinessHelper.ExecuteDataSet("sp_GetSalaryProcessDetailsforBankStatus", CommandType.StoredProcedure, param);
            if (ds.Tables.Count >= 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<SalaryprocesspaymentDetails>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new SalaryprocesspaymentDetails()
                    {
                       // PRSPD001_CODE = dr["PRSPD001_CODE"].ToString(),
                        EMPCODE = dr["Empcode"].ToString(),
                        EMPNAME = dr["Empname"].ToString(),
                        BANKCODE = dr["PRBM001_code"].ToString(),
                        BANKName = dr["Bank_name"].ToString(),
                        BRANCHCODE = dr["PRBM002_code"].ToString(),
                        BANkBrachName = dr["Bank_branch_name"].ToString(),
                        AMOUNT =Convert.ToDouble(dr["NetSalary"].ToString()),
                        ACCOUNTNO = dr["Account_no"].ToString(),
                       // PAID_TYPE = dr["Empname"].ToString(),
                        srno = Convert.ToInt32(dr["srno"].ToString()),
                    });
                }

            }
            return objList;
        }
        public SalaryProcessDVM SaveSalryProcessPaymentDetails(SalaryProcessDVM SPDV)
        {
           // string deptcode1 = SPDV.Deptcode == "0" ? "" : SPDV.Deptcode;
           // string vloc1 = SPDV.VisaLocation1 == "0" ? "" : SPDV.VisaLocation1;
            string Month = "";
            string year = "";
            List<SalaryprocesspaymentDetails> objList = null;
            try
            {
                var Drecord = new List<string>();
                List<SalaryprocesspaymentDetails> ObjList = new List<SalaryprocesspaymentDetails>();
                ObjList.AddRange(SPDV.salaryList.Select(m => new SalaryprocesspaymentDetails
                {
                   
                    EMPCODE = m.EMPCODE,
                 
                }).ToList());
                int n = 0;
                int countl = 0;
                n = ObjList.Count;

                if (!SPDV.EditFlag)
                {

                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        DateTime dte = Convert.ToDateTime(SPDV.SalProcess_Date);
                        string saldate = dte.ToString("yyyy-MM-dd");
                        Month = dte.ToString("MM");
                        DateTime dte1 = Convert.ToDateTime(SPDV.SalProcess_Date);
                        year = dte.ToString("yyyy");
                        string yeardata = SPDV.SalProcess_Date.ToString("yyyy");
                        string monthdata = SPDV.SalProcess_Date.ToString("MM");
                        int count = _EzBusinessHelper.ExecuteScalar("select count(*) from PRSPD002 sp inner join PRSPD001 sp2 on sp.PRSPD001_CODE=sp2.PRSPD001_CODE  where  Division='" + SPDV.DIVISION + "' and Tyear='" + year + "' and Tmonth='" + Month + "' and cmpycode='" + SPDV.CMPYCODE + "' and sp.Flag=0 and sp2.Flag=0");
                        if (count == 0)
                        {
                            SqlParameter[] param = {new SqlParameter("@CmpyCode",SPDV.CMPYCODE),
                                    new SqlParameter("@DivCode",SPDV.DIVISION),
                                    new SqlParameter("@Year", yeardata),
                                     new SqlParameter("@Month",monthdata),
                                     new SqlParameter("@UserName",SPDV.UserName),
                                     new SqlParameter("@PRSPD001_CODE",SPDV.PRSPD001_CODE),
                                     new SqlParameter("@SalProcess_Date",SPDV.SalProcess_Date),
                                    new SqlParameter("@PAIDTYPE", SPDV.PAIDTYPE)};

                            // new SqlParameter("@visaloction",vloc1)};
                            bool result = _EzBusinessHelper.ExecuteNonQuery("sp_SaveSalaryProcessPaymentDetails", param);
                            if (result == true)
                            {
                                while (n > 0)
                                {
                                    // decimal Stats1 = _EzBusinessHelper.ExecuteScalarDec("Select count(*) as [count1] from PRSP002 where CmpyCode='" + SPDV.CmpyCode + "'  and flag=0 and empcode='" + ObjList[n - 1].Empcode + "'");   
                                    int loanstatus = _EzBusinessHelper.ExecuteScalar("update PRSP002 set  Salary_paid='Y' where Empcode='" + ObjList[n - 1].EMPCODE + "' and Division='" + SPDV.DIVISION + "' and Tyear='" + year + "' and Tmonth='" + Month + "' and cmpycode='" + SPDV.CMPYCODE + "' and Flag=0");

                                    n = n - 1;
                                }
                            }
                            _EzBusinessHelper.ActivityLog(SPDV.CMPYCODE, SPDV.UserName, "Add Salary Process Detail", SPDV.PRSPD001_CODE, Environment.MachineName);
                            SPDV.SaveFlag = true;
                            SPDV.ErrorMessage = string.Empty;
                            //}
                        }
                        else
                        {
                            SPDV.SaveFlag = false;
                            SPDV.ErrorMessage ="Duplicate Record";
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
                            var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from PRSPD001 where CmpyCode='" + SPDV.CMPYCODE + "' and Code='" + SPDV.PRSPD001_CODE + "' and Flag=0");
                            if (StatsEdit != 0)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("CmpyCode='" + SPDV.CMPYCODE + "',");
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
                                sb.Append("NetSalary='" + ObjList[n - 1].AMOUNT + "')");
                                _EzBusinessHelper.ExecuteNonQuery("update PRSPD001 set'" + sb.ToString() + "' where compycode='" + SPDV.CMPYCODE + "'and code='" + SPDV.PRSPD001_CODE + "' and Flag=0 ");

                                _EzBusinessHelper.ActivityLog(SPDV.CMPYCODE, SPDV.UserName, "Update Salary Process", SPDV.PRSPD001_CODE, Environment.MachineName);

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
                        var SalaryEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from PRSPH001 where CmpyCode='" + SPDV.CMPYCODE + "' and Code='" + SPDV.PRSPD001_CODE + "' and Flag=0");
                        if (SalaryEdit != 0)
                        {
                            _EzBusinessHelper.ExecuteNonQuery("update PRSPH001 set CmpyCode='" + SPDV.CMPYCODE + "',Code='" + SPDV.PRSPD001_CODE + "',Month='" + Month + "',year='" + year + "' where CmpyCode='" + SPDV.CMPYCODE + "' and Code='" + SPDV.PRSPD001_CODE + "' and Flag=0");
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



        public List<SalaryProcessDetailsListItem> GetBankNotDetails(string CmpyCode, DateTime currDate, string divcode, string deptcode, string Visalocation1)
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
            ds = _EzBusinessHelper.ExecuteDataSet("usp_GetEmployeeNotInBank", CommandType.StoredProcedure, param);
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
                        srno = Convert.ToInt32(dr["srno"].ToString()),
                    });
                }

            }
            return objList;
        }




        public SalaryProcessDVM GetsalryprocessPaymentEdit(string CmpyCode, string PRSPD001_COD)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select * from PRSPD001 where CmpyCode='" + CmpyCode + "' and PRSPD001_CODE='" + PRSPD001_COD + "' and Flag=0");
            dt = ds.Tables[0];
            SalaryProcessDVM drc = new SalaryProcessDVM();
            foreach (DataRow dr in dt.Rows)
            {
                drc.CMPYCODE = dr["CmpyCode"].ToString();
                drc.PRSPD001_CODE = dr["PRSPD001_CODE"].ToString();
                drc.COUNTRY = dr["Country"].ToString();
                drc.DIVISION = dr["Division"].ToString();
                drc.WORKLOCATION = dr["WORKLOCATION"].ToString();
                drc.TYEAR = Convert.ToInt32(dr["Tyear"].ToString());
                drc.TMONTH = Convert.ToInt32(dr["Tmonth"].ToString());
                drc.PAIDTYPE = Convert.ToInt32(dr["PAIDTYPE"].ToString());
            }
            return drc;

        }
        public List<SalaryprocesspaymentDetails> GetSalaryProcessPaymentGridEdit(string salcode,string paidtype)
        {
            List<SalaryprocesspaymentDetails> objList = null;
            ds = _EzBusinessHelper.ExecuteDataSet("select * from PRSPD002 where PRSPD001_CODE='"+salcode+"' and flag=0");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                objList = new List<SalaryprocesspaymentDetails>();
                foreach (DataRow dr in drc)
                {
                    objList.Add(new SalaryprocesspaymentDetails()
                    {
                        EMPCODE = dr["EMPCODE"].ToString(),
                        EMPNAME = dr["EMPNAME"].ToString(),
                        BANKCODE = dr["BANKCODE"].ToString(),
                      //  BANKName = dr["BANKName"].ToString(),
                        BRANCHCODE = dr["BRANCHCODE"].ToString(),
                      //  BANkBrachName = dr["Bank_branch_name"].ToString(),
                        AMOUNT = Convert.ToDouble(dr["AMOUNT"].ToString()),
                        ACCOUNTNO = dr["ACCOUNTNO"].ToString(),
                        // PAID_TYPE = dr["Empname"].ToString(),
                       // srno = Convert.ToInt32(dr["srno"].ToString()),
                    });
                }
            }
            return objList;

        }
    }
}
