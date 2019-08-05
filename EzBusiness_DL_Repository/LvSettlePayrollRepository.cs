using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace EzBusiness_DL_Repository
{
    public class LvSettlePayrollRepository : ILvSettlePayrollRepository 
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun dropfill = new DropListFillFun();

        public List<LeaveSettlement> GetLivlist(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select a.*,b.Empname from PRLS001 a inner join MEM001 b on a.Cmpycode=b.Cmpycode and a.EmpCode=b.EmpCode and a.Flag=b.Flag where a.cmpycode='" + CmpyCode + "' and a.Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<LeaveSettlement> ObjList = new List<LeaveSettlement>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new LeaveSettlement()
                {
                    Empcode = dr["Empcode"].ToString(),
                    PRLS001_CODE = dr["PRLS001_CODE"].ToString(),
                    LLSdate = Convert.ToDateTime(dr["LLSdate"].ToString()),
                    Entry_Date = Convert.ToDateTime(dr["Entry_Date"].ToString()),
                    EmpName = dr["EmpName"].ToString()
                });

            }
            return ObjList;
        }

        public LeaveSettlementVM SaveLiv(LeaveSettlementVM Liv)
        {
            bool cstatus = false;            
            string dtstr1, dtstr2, dtstr3, dtstr4, dtstr5, dtstr6, dtstr7 = null;
            DateTime dte;
            dte = Convert.ToDateTime(Liv.LLSdate.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(Liv.DR_Date.ToString());
            dtstr2 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(Liv.Entry_Date.ToString());
            dtstr3 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(Liv.LStartDate.ToString());
            dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(Liv.LendDate.ToString());
            dtstr5 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(Liv.LendDate.ToString());
            dtstr6 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(Liv.salary_effect_date.ToString());
            dtstr7 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            
            try
            {
                if (!Liv.EditFlag)
                {
                    SqlParameter[] param1 = {
                        new SqlParameter("@CMPYCODE",Liv.CMPYCODE),
                        new SqlParameter("@DIVISION", Liv.DIVISION),
                        new SqlParameter("@COUNTRY",Liv.COUNTRY),                        
                        new SqlParameter("@PRLR001_CODE",Liv.PRLR001_CODE),
                        new SqlParameter("@Empcode",Liv.Empcode),
                        new SqlParameter("@Entry_Date",dtstr3),
                        new SqlParameter("@LLSdate",dtstr1),
                        new SqlParameter("@DR_Date",Liv.DR_Date),
                        new SqlParameter("@LStartDate",Liv.LStartDate),
                        new SqlParameter("@LendDate",Liv.LendDate),
                        new SqlParameter("@Sanctioned_Days",Liv.Sanctioned_Days),
                        new SqlParameter("@Total_days",Liv.Total_days),
                        new SqlParameter("@Total_worked_Days",Liv.Total_worked_Days),
                        new SqlParameter("@Total_LE_Days",Liv.Total_LE_Days),
                        new SqlParameter("@LB_CF_Days",Liv.LB_CF_Days),
                        new SqlParameter("@Leave_Salary",Liv.Leave_Salary),
                        new SqlParameter("@Addition_amt",Liv.Addition_amt),
                        new SqlParameter("@Deduction_Amt",Liv.Deduction_Amt),
                        new SqlParameter("@Ticket_amt",Liv.Ticket_amt),
                        new SqlParameter("@Ticket_Paid",Liv.Ticket_Paid),
                        new SqlParameter("@Pending_Salary",Liv.Pending_Salary),
                        new SqlParameter("@Advance_Salary",Liv.Advance_Salary),
                        new SqlParameter("@Advance_Paid",Liv.Advance_Paid),
                        new SqlParameter("@Actual_Salary",Liv.Actual_Salary),
                        new SqlParameter("@salary_effect_date",Liv.salary_effect_date),
                        new SqlParameter("@Net_Pay",Liv.Net_Pay)
                       };

                    cstatus = _EzBusinessHelper.ExecuteNonQuery("AddLeaveSett", param1);
                    if (cstatus == true)
                    {
                        Liv.SaveFlag = true;
                        Liv.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Liv.SaveFlag = false;
                        Liv.ErrorMessage = "Duplicate Record";
                    }

                    return Liv;
                }
                else
                {
                    SqlParameter[] param1 = {
                        new SqlParameter("@PRLS001_CODE",Liv.PRLS001_CODE),
                        new SqlParameter("@CMPYCODE",Liv.CMPYCODE),
                        new SqlParameter("@DIVISION", Liv.DIVISION),
                        new SqlParameter("@COUNTRY",Liv.COUNTRY),
                        new SqlParameter("@PRLR001_CODE",Liv.PRLR001_CODE),
                        new SqlParameter("@Empcode",Liv.Empcode),
                        new SqlParameter("@Entry_Date",dtstr3),
                        new SqlParameter("@LLSdate",dtstr1),
                        new SqlParameter("@DR_Date",Liv.DR_Date),
                        new SqlParameter("@LStartDate",Liv.LStartDate),
                        new SqlParameter("@LendDate",Liv.LendDate),
                        new SqlParameter("@Sanctioned_Days",Liv.Sanctioned_Days),
                        new SqlParameter("@Total_days",Liv.Total_days),
                        new SqlParameter("@Total_worked_Days",Liv.Total_worked_Days),
                        new SqlParameter("@Total_LE_Days",Liv.Total_LE_Days),
                        new SqlParameter("@LB_CF_Days",Liv.LB_CF_Days),
                        new SqlParameter("@Leave_Salary",Liv.Leave_Salary),
                        new SqlParameter("@Addition_amt",Liv.Addition_amt),
                        new SqlParameter("@Deduction_Amt",Liv.Deduction_Amt),
                        new SqlParameter("@Ticket_amt",Liv.Ticket_amt),
                        new SqlParameter("@Ticket_Paid",Liv.Ticket_Paid),
                        new SqlParameter("@Pending_Salary",Liv.Pending_Salary),
                        new SqlParameter("@Advance_Salary",Liv.Advance_Salary),
                        new SqlParameter("@Advance_Paid",Liv.Advance_Paid),
                        new SqlParameter("@Actual_Salary",Liv.Actual_Salary),
                        new SqlParameter("@salary_effect_date",Liv.salary_effect_date),
                        new SqlParameter("@Net_Pay",Liv.Net_Pay)
                       };

                    cstatus = _EzBusinessHelper.ExecuteNonQuery("UpdateLeaveSett", param1);
                    if (cstatus == true)
                    {
                        Liv.SaveFlag = true;
                        Liv.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Liv.SaveFlag = false;
                        Liv.ErrorMessage = "Duplicate Record";
                    }

                    return Liv;
                }
            }
            catch
            {
                Liv.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Liv;
        }

        public LeaveSettlementVM GetLivlistEdit(string CmpyCode, string PRLS001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLS001  where Cmpycode='" + CmpyCode + "' and PRLS001_CODE='" + PRLS001_CODE + "' ");
            dt = ds.Tables[0];
            LeaveSettlementVM LS = new LeaveSettlementVM();
            foreach (DataRow dr in dt.Rows)
            {
                LS.Actual_Salary =Convert.ToDecimal(dr["Actual_Salary"].ToString());
                LS.Addition_amt = dr["Addition_amt"].ToString() != "" ? Convert.ToDecimal(dr["Addition_amt"].ToString()) : 0;                
                LS.Advance_Paid = Convert.ToDecimal(dr["Advance_Paid"].ToString());
                LS.Advance_Salary = dr["Advance_Salary"].ToString() != "" ? Convert.ToDecimal(dr["Advance_Salary"].ToString()) : 0;                
                LS.COUNTRY = dr["COUNTRY"].ToString();
                LS.Deduction_Amt = dr["Deduction_Amt"].ToString() != "" ? Convert.ToDecimal(dr["Deduction_Amt"].ToString()) : 0;
                LS.DIVISION = dr["DIVISION"].ToString();
                LS.DR_Date = Convert.ToDateTime(dr["DR_Date"].ToString());
                LS.Empcode = dr["Empcode"].ToString();
                LS.Entry_Date = Convert.ToDateTime(dr["Entry_Date"].ToString());
                LS.LB_CF_Days = Convert.ToDecimal(dr["LB_CF_Days"].ToString());
                LS.Leave_Salary= Convert.ToDecimal(!String.IsNullOrEmpty(dr["Leave_Salary"].ToString()));
                LS.LendDate = Convert.ToDateTime(dr["LendDate"].ToString());
                LS.LLSdate = Convert.ToDateTime(dr["LLSdate"].ToString());
                LS.LStartDate= Convert.ToDateTime(dr["LStartDate"].ToString());
                LS.Net_Pay = dr["Net_Pay"].ToString() != "" ? Convert.ToDecimal(dr["Net_Pay"].ToString()) : 0;
                LS.Pending_Salary= dr["Pending_Salary"].ToString() != "" ? Convert.ToDecimal(dr["Pending_Salary"].ToString()) : 0;
                LS.PRLR001_CODE = dr["PRLR001_CODE"].ToString();
                LS.PRLS001_CODE = dr["PRLS001_CODE"].ToString();
                LS.salary_effect_date= Convert.ToDateTime(dr["salary_effect_date"].ToString());
                LS.Sanctioned_Days= Convert.ToDecimal(dr["Sanctioned_Days"].ToString());
                LS.Ticket_amt= dr["Ticket_amt"].ToString() != "" ? Convert.ToDecimal(dr["Ticket_amt"].ToString()) : 0;
                LS.Ticket_Paid= dr["Ticket_Paid"].ToString();
                LS.Total_days= dr["Total_days"].ToString() != "" ? Convert.ToDecimal(dr["Total_days"].ToString()) : 0;
                
                LS.Total_LE_Days= dr["Total_LE_Days"].ToString() != "" ? Convert.ToDecimal(dr["Total_LE_Days"].ToString()) : 0;
                
                LS.Total_worked_Days= dr["Total_worked_Days"].ToString() != "" ? Convert.ToDecimal(dr["Total_worked_Days"].ToString()) : 0;
                                       
            }
            return LS;
        }

        public List<Employee> GetEmpCodes(string CmpyCode)
        {
            return dropfill.GetEmpCodes(CmpyCode,"L1");
        }

        //public List<LeaveApplication> GetLeaveCodes(string CmpyCode,string typ)
        //{
        //    if (typ != "Etyp")
        //    {
        //        ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLR001 where cmpycode='" + CmpyCode + "' and LeaveType='AL' and ApprovalYN='Y' and PRLR001_CODE Not in (Select PRLR001_CODE from PRLS001 where cmpycode='" + CmpyCode + "') order by PRLR001_CODE");
        //    }          
        //    else
        //    {
        //        ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLR001 where cmpycode='" + CmpyCode + "' and LeaveType='AL' and ApprovalYN='Y' order by PRLR001_CODE");
        //    }

        //    dt = ds.Tables[0];
        //    DataRowCollection drc = dt.Rows;
        //    List<LeaveApplication> ObjList = new List<LeaveApplication>();
        //    foreach (DataRow dr in drc)
        //    {
        //        ObjList.Add(new LeaveApplication()
        //        {                    
        //            PRLR001_CODE = dr["PRLR001_CODE"].ToString(),
        //            EmpCode=dr["EmpCode"].ToString()                   
        //        });

        //    }
        //    return ObjList;
        //}
        public List<ComDropTbl> GetLeaveCodes(string CmpyCode, string Prefix)
        {
            //if (typ != "Etyp")
            //{
            // ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLR001 where cmpycode='" + CmpyCode + "' and LeaveType='AL' and ApprovalYN='Y' and PRLR001_CODE Not in (Select PRLR001_CODE from PRLS001 where cmpycode='" + CmpyCode + "') order by PRLR001_CODE");
            // }

            return dropfill.GetCommonDrop("PRLR001_CODE as [Code],EmpCode as [CodeName]", "PRLR001", "cmpycode='" + CmpyCode + "' and Status=0  and LeaveType='AL' and ApprovalYN='Y' and PRLR001_CODE Not in (Select PRLR001_CODE from PRLS001 where cmpycode='" + CmpyCode + "') and  (PRLR001_CODE like '" + Prefix + "%' or EmpCode like '" + Prefix + "%') order by PRLR001_CODE ");
        }

        public List<LeaveSettlementnew> GetLeaveDetails(string CmpyCode, string PRLR001_CODE,DateTime lvsdte)
        {
            

            DateTime dte;
            string dtstr1;
            dte = Convert.ToDateTime(lvsdte);
            dtstr1 = dte.ToString("yyyy-MM-dd");

            SqlParameter[] param = { new SqlParameter("@CmpyCode", CmpyCode),
                                    new SqlParameter("@PRLR001_CODE", PRLR001_CODE),
                                    new SqlParameter("@LeaveSdte", dtstr1)};


            ds = _EzBusinessHelper.ExecuteDataSet("Leaveset_Cal22Nov", CommandType.StoredProcedure, param);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
             }

                //ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLR001 where cmpycode='" + CmpyCode + "' and  PRLR001_CODE='"+ PRLR001_CODE + "'");         
                //dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                List<LeaveSettlementnew> ObjList = new List<LeaveSettlementnew>();
                foreach (DataRow dr in drc)
                {
               

                    ObjList.Add(new LeaveSettlementnew()
                    {


                        LLSdate = Convert.ToDateTime(dr["StartDate"]),
                        LendDate = Convert.ToDateTime(dr["EndDate"]),
                        Empcode = dr["EmpCode"].ToString(),
                        JoiningDate = Convert.ToDateTime(dr["JoiningDate"]),
                        DR_Date = Convert.ToDateTime(dr["ResumeDate"]),
                        Total_worked_Days = Convert.ToInt64(dr["Workingdays"]),
                        Total_days = Convert.ToDecimal(dr["Totaldays"]),
                        Total_LE_Days = Convert.ToInt64(dr["LeaveDays"]),
                        Sanctioned_Days = Convert.ToInt64(dr["TotalSanctioned"]),
                        salary_effect_date = Convert.ToDateTime(dr["SalEffDte"]),
                        Actual_Salary = Convert.ToDecimal(dr["totalsalary"].ToString()),
                        LB_CF_Days = Convert.ToDecimal(dr["BalLeave"].ToString()),
                        Leave_Salary = Convert.ToDecimal(dr["Leavesalary"].ToString())
                    });
                }
                return ObjList;
            
        }

        public bool DeleteLiv(string CmpyCode, string PRLS001_COD, string username)
        {
            bool Cstatus;
            SqlParameter[] param1 = {
                        new SqlParameter("@CmpyCode",CmpyCode),
                        new SqlParameter("@PRLS001_CODE",PRLS001_COD)
                       };
            Cstatus = _EzBusinessHelper.ExecuteNonQuery("DeleteLeaveSett", param1);
            if (Cstatus == true)
            {
                return _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Leave settalment", PRLS001_COD, Environment.MachineName);
            }

            return false;
        }

        public DateTime GetJoiningdate(string CmpyCode, string EmpCode)
        {
            DateTime Joindt = _EzBusinessHelper.ExecuteScalarDte("SELECT JoiningDate FROM MEM001 WHERE EmpCode='" + EmpCode + "' and  CmpyCode = '" + CmpyCode + "' ");// And WorkingStatus = 'Y'
            return Joindt;
        }
    }
}

    

