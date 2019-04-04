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
            bool rowStatus=false, rowStatus1 = false;
            List<SalaryprocesspaymentDetails> objList = null;
            try
            {


                DateTime dte = Convert.ToDateTime(SPDV.SalProcess_Date);
                string saldate = dte.ToString("yyyy-MM-dd");
                Month = dte.ToString("MM");
                DateTime dte1 = Convert.ToDateTime(SPDV.SalProcess_Date);
                year = dte.ToString("yyyy");
                string yeardata = SPDV.SalProcess_Date.ToString("yyyy");
                string monthdata = SPDV.SalProcess_Date.ToString("MM");
                var Drecord = new List<string>();
                List<SalaryprocesspaymentDetails> ObjList = new List<SalaryprocesspaymentDetails>();
                ObjList.AddRange(SPDV.salaryList.Select(m => new SalaryprocesspaymentDetails
                {
                    srno = m.srno,
                    EMPCODE = m.EMPCODE,
                    EMPNAME = m.EMPNAME,
                    BANKCODE = m.BANKCODE,
                    BRANCHCODE = m.BRANCHCODE,
                    ACCOUNTNO = m.ACCOUNTNO,
                    AMOUNT = m.AMOUNT,
                    Paid=m.Paid

                }).ToList());

                int n = 0;
                int countl = 0;
                n = ObjList.Count;
                if (!SPDV.EditFlag)
                {
                  
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                       string countrry = _EzBusinessHelper.ExecuteScalarS("select COUNTRY from PRCNF001 where FINYEARS='" + yeardata + "' and  FINMONTH='" + monthdata + "' and CMPYCODE='" + SPDV.CMPYCODE + "' and Flag=0");
                            while (n > 0)
                            {
                            int count = _EzBusinessHelper.ExecuteScalar("select count(*) from PRSPD002 sp inner join PRSPD001 sp2 on sp.PRSPD001_CODE=sp2.PRSPD001_CODE  where  Division='" + SPDV.DIVISION + "' and Tyear='" + year + "' and Tmonth='" + Month + "' and cmpycode='" + SPDV.CMPYCODE + "' and sp.Flag=0 and sp2.Flag=0 and EMPCODE='" + ObjList[n - 1].EMPCODE + "'");
                            if (count == 0)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("'" + SPDV.PRSPD001_CODE + "',");
                                sb.Append("'" + ObjList[n - 1].EMPCODE + "',");
                                sb.Append("'" + ObjList[n - 1].EMPNAME + "',");
                                sb.Append("'" + ObjList[n - 1].BANKCODE + "',");
                                sb.Append("'" + ObjList[n - 1].BRANCHCODE + "',");
                                sb.Append("'" + ObjList[n - 1].ACCOUNTNO + "',");
                                sb.Append("'" + ObjList[n - 1].AMOUNT + "',");
                                sb.Append("'" + SPDV.PAIDTYPE + "')");
                                // sb.Append("'" + ObjList[n - 1].UniCodeName + "')");
                                rowStatus = _EzBusinessHelper.ExecuteNonQuery1("insert into PRSPD002(PRSPD001_CODE,EMPCODE,EMPNAME,BANKCODE,BRANCHCODE,ACCOUNTNO,AMOUNT,PAID_TYPE)  values(" + sb.ToString() + "");
                                //Deps.SaveFlag = true;
                                //Deps.ErrorMessage = string.Empty;
                                if (rowStatus == true)
                                {
                                    if (SPDV.PAIDTYPE == 1)
                                    {
                                        // decimal Stats1 = _EzBusinessHelper.ExecuteScalarDec("Select count(*) as [count1] from PRSP002 where CmpyCode='" + SPDV.CmpyCode + "'  and flag=0 and empcode='" + ObjList[n - 1].Empcode + "'");   
                                        int loanstatus = _EzBusinessHelper.ExecuteNonQuery("update PRSP002 set  Salary_paid='Y' where Empcode='" + ObjList[n - 1].EMPCODE + "' and Division='" + SPDV.DIVISION + "' and Tyear='" + year + "' and Tmonth='" + Month + "' and cmpycode='" + SPDV.CMPYCODE + "' and Flag=0");
                                    }
                                    if (SPDV.PAIDTYPE == 0)
                                    {
                                        // decimal Stats1 = _EzBusinessHelper.ExecuteScalarDec("Select count(*) as [count1] from PRSP002 where CmpyCode='" + SPDV.CmpyCode + "'  and flag=0 and empcode='" + ObjList[n - 1].Empcode + "'");   
                                        int loanstatus = _EzBusinessHelper.ExecuteNonQuery("update PRSP002 set  incentive_paid='Y' where Empcode='" + ObjList[n - 1].EMPCODE + "' and Division='" + SPDV.DIVISION + "' and Tyear='" + year + "' and Tmonth='" + Month + "' and cmpycode='" + SPDV.CMPYCODE + "' and Flag=0");
                                    }
                                }
                            }
                            else
                            {
                                //Drecord.Add(ObjList[n - 1].EMPCODE.ToString());
                                // SPDV.deco = Drecord;
                                SPDV.SaveFlag = false;
                                SPDV.ErrorMessage = "Duplicate Record";
                            }
                            n = n - 1;
                            }

                            int maxcount = _EzBusinessHelper.ExecuteScalar("select COUNT(*) from prspd0011");
                            int rowcount = maxcount + 1;
                            if (rowStatus == true)
                            {
                                StringBuilder sb = new StringBuilder();
                                sb.Append("'" + rowcount + "',");
                                sb.Append("'" + SPDV.PRSPD001_CODE + "',");
                                sb.Append("'" + SPDV.CMPYCODE + "',");
                                sb.Append("'" + countrry + "',");
                                sb.Append("'" + SPDV.DIVISION + "',");
                                sb.Append("'',");
                                sb.Append("'" + yeardata + "',");
                                sb.Append("'" + monthdata + "',");
                                sb.Append("'" + SPDV.PAIDTYPE + "')");
                                // sb.Append("'" + ObjList[n - 1].UniCodeName + "')");
                                rowStatus1 = _EzBusinessHelper.ExecuteNonQuery1("insert into PRSPD001(PRSPD001_UID,PRSPD001_CODE,CMPYCODE,COUNTRY,DIVISION,WORKLOCATION,TYEAR,TMONTH,PAIDTYPE)  values(" + sb.ToString() + "");

                            }
                            if (rowStatus1 == true)
                            {
                                _EzBusinessHelper.ExecuteNonQuery("UPDATE PARTTBL001 SET Nos =Nos+1 where CmpyCode='" + SPDV.CMPYCODE + "' and Code='PRSPD'");
                                _EzBusinessHelper.ActivityLog(SPDV.CMPYCODE, SPDV.UserName, "Add Salary Process Detail", SPDV.PRSPD001_CODE, Environment.MachineName);
                                SPDV.SaveFlag = true;
                                SPDV.ErrorMessage = string.Empty;
                            }
                       
                        scope1.Complete();
                    }
                }
                else
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        var statsedit = _EzBusinessHelper.ExecuteScalarDec("select count(*) from PRSPD001 where CMPYCODE='" + SPDV.CMPYCODE + "' and PRSPD001_CODE='" + SPDV.PRSPD001_CODE + "' and flag=0");
                        if (statsedit != 0)
                        {
                            while (n > 0)
                               {
                           
                               
                                 _EzBusinessHelper.ExecuteNonQuery1("update PRSPD002 set PAID_TYPE=" + ObjList[n - 1].Paid + " where  PRSPD001_CODE='" + SPDV.PRSPD001_CODE + "' and EMPCODE='" + ObjList[n - 1].EMPCODE + "'");
                               if (SPDV.PAIDTYPE == 1)
                                {
                                    if(ObjList[n - 1].Paid==0)
                                    {
                                        int loanstatus = _EzBusinessHelper.ExecuteNonQuery("update PRSP002 set  Salary_paid='N' where Empcode='" + ObjList[n - 1].EMPCODE + "' and Division='" + SPDV.DIVISION + "' and Tyear='" + year + "' and Tmonth='" + Month + "' and cmpycode='" + SPDV.CMPYCODE + "' and Flag=0");
                                    }
                                    if (ObjList[n - 1].Paid == 1)
                                    {
                                        int loanstatus = _EzBusinessHelper.ExecuteNonQuery("update PRSP002 set  Salary_paid='Y' where Empcode='" + ObjList[n - 1].EMPCODE + "' and Division='" + SPDV.DIVISION + "' and Tyear='" + year + "' and Tmonth='" + Month + "' and cmpycode='" + SPDV.CMPYCODE + "' and Flag=0");
                                    }
                                    // decimal Stats1 = _EzBusinessHelper.ExecuteScalarDec("Select count(*) as [count1] from PRSP002 where CmpyCode='" + SPDV.CmpyCode + "'  and flag=0 and empcode='" + ObjList[n - 1].Empcode + "'");   

                                }
                                if (SPDV.PAIDTYPE == 0)
                                {
                                    // decimal Stats1 = _EzBusinessHelper.ExecuteScalarDec("Select count(*) as [count1] from PRSP002 where CmpyCode='" + SPDV.CmpyCode + "'  and flag=0 and empcode='" + ObjList[n - 1].Empcode + "'");   
                                    if (ObjList[n - 1].Paid == 0)
                                    {
                                        int loanstatus = _EzBusinessHelper.ExecuteNonQuery("update PRSP002 set  incentive_paid='N' where Empcode='" + ObjList[n - 1].EMPCODE + "' and Division='" + SPDV.DIVISION + "' and Tyear='" + year + "' and Tmonth='" + Month + "' and cmpycode='" + SPDV.CMPYCODE + "' and Flag=0");
                                    }
                                    if (ObjList[n - 1].Paid == 1)
                                    {
                                        int loanstatus = _EzBusinessHelper.ExecuteNonQuery("update PRSP002 set  incentive_paid='Y' where Empcode='" + ObjList[n - 1].EMPCODE + "' and Division='" + SPDV.DIVISION + "' and Tyear='" + year + "' and Tmonth='" + Month + "' and cmpycode='" + SPDV.CMPYCODE + "' and Flag=0");

                                    }
                                }
                                // _ezbusinesshelper.executenonquery("update prspd001 set'" + sb.tostring() + "' where compycode='" + spdv.cmpycode + "'and code='" + spdv.prspd001_code + "' and flag=0 ");

                                // _ezbusinesshelper.activitylog(spdv.cmpycode, spdv.username, "update salary process", spdv.prspd001_code, environment.machinename);

                              
                          
                            n = n - 1;
                        }

                        StringBuilder sb = new StringBuilder();
                        sb.Append("CMPYCODE='" + SPDV.CMPYCODE + "',");
                        sb.Append("PRSPD001_CODE='" + SPDV.PRSPD001_CODE + "',");
                        sb.Append("DIVISION='" + SPDV.DIVISION + "',");
                        sb.Append("TYEAR='" + yeardata + "',");
                        sb.Append("TMONTH='" + monthdata + "',");
                        sb.Append("PAIDTYPE='" + SPDV.PAIDTYPE + "'");
                        //sb.Append("workingday='" + objlist[n - 1].workingday + "',");
                        //sb.Append("present='" + objlist[n - 1].present + "',");
                        ////sb.append("lossdays='" + objlist[n - 1].lossdays + "',");
                        bool status = _EzBusinessHelper.ExecuteNonQuery1("update PRSPD001 set " + sb.ToString() + " where CMPYCODE='" + SPDV.CMPYCODE + "'  and PRSPD001_CODE='" + SPDV.PRSPD001_CODE + "'");
                            SPDV.SaveFlag = true;
                            SPDV.ErrorMessage = string.Empty;
                        }
                       else
                          {
                            SPDV.SaveFlag = false;
                            SPDV.ErrorMessage = "record not available";
                        }
                        //var salaryedit = _ezbusinesshelper.executenonquery("select * from prsph001 where cmpycode='" + spdv.cmpycode + "' and code='" + spdv.prspd001_code + "' and flag=0");
                        //if (salaryedit != 0)
                        //{
                        //    _ezbusinesshelper.executenonquery("update prsph001 set cmpycode='" + spdv.cmpycode + "',code='" + spdv.prspd001_code + "',month='" + month + "',year='" + year + "' where cmpycode='" + spdv.cmpycode + "' and code='" + spdv.prspd001_code + "' and flag=0");
                        //    spdv.saveflag = true;
                        //    spdv.errormessage = string.empty;
                        //}
                        //else
                        //{
                        //    SPDV.SaveFlag = false;
                        //    SPDV.ErrorMessage = "record not available";
                        //}
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
                         PAID_TYPE = dr["PAID_TYPE"].ToString(),
                       // srno = Convert.ToInt32(dr["srno"].ToString()),
                    });
                }
            }
            return objList;

        }
    }
}
