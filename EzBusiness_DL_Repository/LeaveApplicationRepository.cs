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
using EzBusiness_ViewModels;

namespace EzBusiness_DL_Repository
{
    public class LeaveApplicationRepository : ILeaveApplicationRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public bool DeleteLeaveApp(string Cmpycode, string PRLR001_CODE, string oldLeavedays, string EmpCode, string username)
        {
            //int LeaveApp = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRLR001 where CmpyCode='" + CmpyCode + "' and PRLR001_CODE='" + Code + "'");
            //if (LeaveApp != 0)
            //{
            //    _EzBusinessHelper.ExecuteNonQuery("delete from PRLR001 where CmpyCode='" + CmpyCode + "' and PRLR001_CODE='" + Code + "'");
            //    return true;
            //}

            bool Cstatus;

            SqlParameter[] param1 = {
                        new SqlParameter("@CmpyCode",Cmpycode),
                        new SqlParameter("@Empcode",EmpCode),
                        new SqlParameter("@oldLeavedays",oldLeavedays),
                        new SqlParameter("@PRLR001_CODE",PRLR001_CODE)
                       };


            Cstatus = _EzBusinessHelper.ExecuteNonQuery("DeleteLeaveproc", param1);
            if (Cstatus == true)
            {
                return _EzBusinessHelper.ActivityLog(Cmpycode, username, "Delete Division", PRLR001_CODE, Environment.MachineName);
            }
            return false;
        }

       

        public List<LeaveApplication> GetLeaveApp(string CmpyCode)
        {
            // ds = _EzBusinessHelper.ExecuteDataSet("Select a.PRLR001_CODE,a.Empcode, (Select Empname from Mem001 where empcode=a.empcode) as [Emp Name]  from PRLR001 a where a.CmpyCode='" + CmpyCode + "'");
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode)};



            ds = _EzBusinessHelper.ExecuteDataSet("GetAllLeavApp", CommandType.StoredProcedure, param);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<LeaveApplication> ObjList = new List<LeaveApplication>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new LeaveApplication()
                {
                    //CmpyCode = dr["CmpyCode"].ToString(),
                    PRLR001_CODE = dr["PRLR001_CODE"].ToString(),
                    EmpCode=dr["EmpCode"].ToString(),
                    EmpName = dr["Emp Name"].ToString()
                    //LeaveDays=dr["LeaveDays"].ToString(),
                    //Status=dr["Status"].ToString(),
                    //TotalApplied = dr["TotalApplied"].ToString(),
                    //TotalBalance = dr["TotalBalance"].ToString(),
                    //TotalSanctioned = dr["TotalSanctioned"].ToString()
                });

            }
            return ObjList;
        }

        public Leave_App_VW SaveLeaveApp(Leave_App_VW LeaveApp)
        {
            bool cstatus = false;
            int n;
            string dtstr1, dtstr2, dtstr3,dtstr4=  null;
            DateTime dte;

            dte = Convert.ToDateTime(LeaveApp.StartDate.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(LeaveApp.EndDate.ToString());
            dtstr2 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            dte = Convert.ToDateTime(LeaveApp.Entry_Dates.ToString());
            dtstr3 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(LeaveApp.JoiningDate.ToString());
            dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            try
            {
                if (!LeaveApp.IsEditMode)
                {
                    //int LeaveApp1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRLR001 where CmpyCode='" + LeaveApp.CmpyCode + "' and PRLR001_CODE='" + LeaveApp.PRLR001_CODE + "'");                  
                    //if (LeaveApp1 == 0)
                    //{
                    SqlParameter[] param1 = {new SqlParameter("@CmpyCode", LeaveApp.CmpyCode),
                        new SqlParameter("@COUNTRY", LeaveApp.COUNTRY),
                        new SqlParameter("@DIVISION",LeaveApp.DIVISION),
                          new SqlParameter("@Entry_Dates",dtstr3 ),
                          new SqlParameter("@EmpCode",LeaveApp.EmpCode),
                          new SqlParameter("@JoiningDate",dtstr4),
                          new SqlParameter("@LeaveType",LeaveApp.LeaveType),
                          new SqlParameter("@StartDate",dtstr1),
                          new SqlParameter("@EndDate",dtstr2),
                          new SqlParameter("@LeaveDays",LeaveApp.LeaveDays),
                          //new SqlParameter("@Remarks",LeaveApp.Remarks),
                          new SqlParameter("@Remarks",! String.IsNullOrWhiteSpace(LeaveApp.Remarks) ? LeaveApp.Remarks : ""),
                           new SqlParameter("@TotalBalance",LeaveApp.TotalBalance),
                           new SqlParameter("@TotalApplied",LeaveApp.TotalApplied),
                          new SqlParameter("@TotalSanctioned",! String.IsNullOrWhiteSpace(LeaveApp.TotalSanctioned) ? LeaveApp.TotalSanctioned : "0"),
                          new SqlParameter("@ApprovalYN",LeaveApp.ApprovalYN),
                          new SqlParameter("@Status",LeaveApp.Status),};

                    cstatus = _EzBusinessHelper.ExecuteNonQuery("AddLeaveproc", param1);
                    if (cstatus == true)
                    {
                        LeaveApp.IsSavedFlag = true;
                        LeaveApp.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        LeaveApp.IsSavedFlag = false;
                        LeaveApp.ErrorMessage = "Duplicate Record";
                    }
                    return LeaveApp;

                }
                else
                {

                    SqlParameter[] param1 = {new SqlParameter("@CmpyCode", LeaveApp.CmpyCode),
                        new SqlParameter("@PRLR001_CODE",LeaveApp.PRLR001_CODE),
                        new SqlParameter("@COUNTRY", LeaveApp.COUNTRY),
                          new SqlParameter("@DIVISION",LeaveApp.DIVISION),
                          new SqlParameter("@Entry_Dates",dtstr3 ),
                          new SqlParameter("@EmpCode",LeaveApp.EmpCode),
                          new SqlParameter("@JoiningDate",dtstr4),
                          new SqlParameter("@LeaveType",LeaveApp.LeaveType),
                          new SqlParameter("@StartDate",dtstr1),
                          new SqlParameter("@EndDate",dtstr2),
                          new SqlParameter("@LeaveDays",LeaveApp.LeaveDays),
                          //! String.IsNullOrWhiteSpace(productName) ? productName : null
                         // new SqlParameter("@Remarks",LeaveApp.Remarks),
                         new SqlParameter("@Remarks",! String.IsNullOrWhiteSpace(LeaveApp.Remarks) ? LeaveApp.Remarks : ""),
                           new SqlParameter("@TotalBalance",LeaveApp.TotalBalance),
                           new SqlParameter("@oldLeavedays",LeaveApp.oldLeavedays),
                           new SqlParameter("@TotalApplied",LeaveApp.TotalApplied),
                          new SqlParameter("@TotalSanctioned",! String.IsNullOrWhiteSpace(LeaveApp.TotalSanctioned) ? LeaveApp.TotalSanctioned : "0"),
                          new SqlParameter("@ApprovalYN",LeaveApp.ApprovalYN),
                          new SqlParameter("@Status",LeaveApp.Status),};

                    cstatus = _EzBusinessHelper.ExecuteNonQuery("UpdateLeaveproc", param1);
                    if (cstatus == true)
                    {
                        LeaveApp.IsSavedFlag = true;
                        LeaveApp.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        LeaveApp.IsSavedFlag = false;
                        LeaveApp.ErrorMessage = "Duplicate Record";
                    }
                    return LeaveApp;

                }

                    //AddLeaveproc

                    // int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + LeaveApp.CmpyCode + "' and Code='" + PurchaseMgmtConstants.LeaveHeader + "' ");

                    // LeaveApp.PRLR001_CODE = string.Concat(PurchaseMgmtConstants.LeaveHeader, "-", (Convert.ToInt16(pno)).ToString().PadLeft(4, '0')).ToString();


                    // StringBuilder sb = new StringBuilder();

                    // sb.Append("(PRLR001_CODE,");
                    // sb.Append("CmpyCode,");
                    // sb.Append("COUNTRY,");
                    // sb.Append("DIVISION,");
                    // sb.Append("Branch,");
                    // sb.Append("Dept,");
                    // sb.Append("Entry_Dates,");
                    // sb.Append("EmpCode,");
                    // sb.Append("JoiningDate,");
                    // sb.Append("LeaveType,");
                    // sb.Append("StartDate,");
                    // sb.Append("EndDate,");
                    // sb.Append("LeaveDays,");
                    // sb.Append("Remarks,");
                    // sb.Append("TotalBalance,");
                    // sb.Append("TotalApplied,");
                    // sb.Append("TotalSanctioned,");
                    // sb.Append("ApprovalYN,");
                    // sb.Append("Status)");

                    // sb.Append(" values('" + LeaveApp.PRLR001_CODE + "',");
                    // sb.Append("'" + LeaveApp.CmpyCode + "',");
                    // sb.Append("'" + LeaveApp.COUNTRY + "',");
                    // sb.Append("'" + LeaveApp.DIVISION + "',");
                    // sb.Append("'" + LeaveApp.Branch + "',");
                    // sb.Append("'" + LeaveApp.Dept + "',");
                    // sb.Append("'" + dtstr3 + "',");
                    // sb.Append("'" + LeaveApp.EmpCode + "',");
                    // sb.Append("'" + dtstr4 + "',");
                    // sb.Append("'" + LeaveApp.LeaveType + "',");
                    // sb.Append("'" + dtstr1 + "',");
                    // sb.Append("'" + dtstr2 + "',");
                    // sb.Append("'" + LeaveApp.LeaveDays + "',");
                    // sb.Append("'" + LeaveApp.Remarks + "',");
                    // sb.Append("'" + LeaveApp.TotalBalance + "',");
                    // sb.Append("'" + LeaveApp.TotalApplied + "',");
                    // sb.Append("'" + LeaveApp.TotalSanctioned + "',");
                    // sb.Append("'" + LeaveApp.ApprovalYN + "',");
                    // sb.Append("'" + LeaveApp.Status + "')");
                    // _EzBusinessHelper.ExecuteNonQuery("insert into PRLR001 " + sb.ToString() + "");
                    // LeaveApp.IsSavedFlag = true;
                    // LeaveApp.ErrorMessage = string.Empty;

                    // _EzBusinessHelper.ExecuteNonQuery("update Mem001 set BalLeave ="+LeaveApp.TotalBalance+"-" + LeaveApp.LeaveDays + " where EmpCode = '" + LeaveApp.EmpCode + "' and cmpycode = '" + LeaveApp.CmpyCode + "'");

                    //_EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + LeaveApp.CmpyCode + "' and Code='" + PurchaseMgmtConstants.LeaveHeader + "'");
               // }
                    //else
                    //{
                    //    LeaveApp.IsSavedFlag = false;
                    //    LeaveApp.ErrorMessage = "Duplicate Record";
                    //}
                   
                //}
                //var DivsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * PRLR001 where CmpyCode='" + LeaveApp.CmpyCode + "' and PRLR001_CODE='" + LeaveApp.PRLR001_CODE + "'");
                //if (DivsEdit != 0)
                //{
                //    _EzBusinessHelper.ExecuteNonQuery("delete from PRLR001 where CmpyCode='" + LeaveApp.CmpyCode + "' and PRLR001_CODE='" + LeaveApp.PRLR001_CODE + "'");
                //    StringBuilder sb = new StringBuilder();

                //    sb.Append("(PRLR001_CODE,");
                //    sb.Append("CmpyCode,");
                //    sb.Append("COUNTRY,");
                //    sb.Append("DIVISION,");
                //    sb.Append("Branch,");
                //    sb.Append("Dept,");
                //    sb.Append("Entry_Dates,");
                //    sb.Append("EmpCode,");
                //    sb.Append("JoiningDate,");
                //    sb.Append("LeaveType,");
                //    sb.Append("StartDate,");
                //    sb.Append("EndDate,");
                //    sb.Append("LeaveDays,");
                //    sb.Append("Remarks,");
                //    sb.Append("TotalBalance,");
                //    sb.Append("TotalApplied,");
                //    sb.Append("TotalSanctioned,");
                //    sb.Append("ApprovalYN,");
                //    sb.Append("Status)");

                //    sb.Append(" values('" + LeaveApp.PRLR001_CODE + "',");
                //    sb.Append("'" + LeaveApp.CmpyCode + "',");
                //    sb.Append("'" + LeaveApp.COUNTRY + "',");
                //    sb.Append("'" + LeaveApp.DIVISION + "',");
                //    sb.Append("'" + LeaveApp.Branch + "',");
                //    sb.Append("'" + LeaveApp.Dept + "',");
                //    sb.Append("'" + dtstr3 + "',");
                //    sb.Append("'" + LeaveApp.EmpCode + "',");
                //    sb.Append("'" + dtstr4 + "',");
                //    sb.Append("'" + LeaveApp.LeaveType + "',");
                //    sb.Append("'" + dtstr1 + "',");
                //    sb.Append("'" + dtstr2 + "',");
                //    sb.Append("'" + LeaveApp.LeaveDays + "',");
                //    sb.Append("'" + LeaveApp.Remarks + "',");
                //    sb.Append("'" + LeaveApp.TotalBalance + "',");
                //    sb.Append("'" + LeaveApp.TotalApplied + "',");
                //    sb.Append("'" + LeaveApp.TotalSanctioned + "',");
                //    sb.Append("'" + LeaveApp.ApprovalYN + "',");
                //    sb.Append("'" + LeaveApp.Status + "'");

                //    _EzBusinessHelper.ExecuteNonQuery("insert into PRLR001 " + sb.ToString() + "");
                //    _EzBusinessHelper.ExecuteNonQuery("update Mem001 set BalLeave =BalLeave-'" + LeaveApp.LeaveDays + "' where EmpCode = '" + LeaveApp.EmpCode + "' and cmpycode = '" + LeaveApp.CmpyCode + "'");
                //    LeaveApp.IsSavedFlag = true;
                //    LeaveApp.ErrorMessage = string.Empty;
                //}
                //else
                //{
                //    LeaveApp.IsSavedFlag = false;
                //    LeaveApp.ErrorMessage = "Record not available";
                //}
                //return LeaveApp;

            }
            catch(Exception ex)
            {
                LeaveApp.IsSavedFlag = false;
                 LeaveApp.ErrorMessage = ex.Message;

            }

            return LeaveApp;
        
    }

        public List<Employee> GetEmpCodeList(string CmpyCode,string typ)
        {
            return drop.GetEmpCodes(CmpyCode, typ);
        }

        public Leave_App_VW GetLeaveAppDetailsEdit(string CmpyCode, string code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLR001 where CmpyCode='" + CmpyCode + "' and PRLR001_CODE='" + code + "' ");
            dt = ds.Tables[0];
            Leave_App_VW LeaveApp1 = new Leave_App_VW();
            foreach (DataRow dr in dt.Rows)
            {
                LeaveApp1.ApprovalYN = dr["ApprovalYN"].ToString();
                //LeaveApp1.Branch = dr["Branch"].ToString();
                LeaveApp1.CmpyCode = dr["CmpyCode"].ToString();
                LeaveApp1.COUNTRY = dr["COUNTRY"].ToString();
               // LeaveApp1.Dept = dr["Dept"].ToString();
               // LeaveApp1.DIVISION = dr["DIVISION"].ToString();
                LeaveApp1.EmpCode = dr["EmpCode"].ToString();
                LeaveApp1.Entry_Dates = Convert.ToDateTime(dr["Dates"].ToString());
                LeaveApp1.JoiningDate = Convert.ToDateTime(dr["JoiningDate"].ToString());
                LeaveApp1.EndDate = Convert.ToDateTime(dr["EndDate"].ToString());
                LeaveApp1.StartDate = Convert.ToDateTime(dr["StartDate"].ToString());
                LeaveApp1.Status = dr["Status"].ToString();
                LeaveApp1.TotalApplied = dr["TotalApplied"].ToString();
                LeaveApp1.TotalBalance = dr["TotalBalance"].ToString();
                LeaveApp1.oldLeavedays = dr["LeaveDays"].ToString();
                LeaveApp1.LeaveDays= dr["LeaveDays"].ToString();
                LeaveApp1.TotalSanctioned = dr["TotalSanctioned"].ToString();
                LeaveApp1.Remarks = dr["Remarks"].ToString();
                LeaveApp1.LeaveType = dr["LeaveType"].ToString();
                LeaveApp1.PRLR001_CODE = dr["PRLR001_CODE"].ToString();                
            }
            return LeaveApp1;
        }

        //public Leave_App_VW GetJoinDate(string CmpyCode, string EmpCode)
        //{

        //    Leave_App_VW Leav_App = new Leave_App_VW();
        //    CommonFun comfun = new CommonFun();
        //    Leav_App.JoiningDate = comfun.GetJoingDate(CmpyCode, EmpCode);
        //    return Leav_App;
        //}
        
        public List<LeaveApplicationDetail> GetLeaveAppDetailList(string CmpyCode, string EmpCode)
        {
            DateTime dte;
            string dtstr4, dtstr5;
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLR001 where CmpyCode='" + CmpyCode + "' and EmpCode='" + EmpCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<LeaveApplicationDetail> ObjList = new List<LeaveApplicationDetail>();
            foreach (DataRow dr in drc)
            {
                dte = Convert.ToDateTime(dr["StartDate"].ToString());
                dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                dte = Convert.ToDateTime(dr["EndDate"].ToString());
                dtstr5 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");



                
                ObjList.Add(new LeaveApplicationDetail()
                {
                    PRLR001_CODE =dr["PRLR001_CODE"].ToString(),
                    StartDate = dtstr4,
                    EndDate = dtstr5,
                    LeaveDays = dr["LeaveDays"].ToString(),
                    
                });

            }
            return ObjList;
        }

        public List<Attendence> GetLeaveTypList(string CmpyCode)
        {
            return drop.GetAtens(CmpyCode);
        }


        public decimal GetBalanceLeave(string CmpyCode, string EmpCode,string LeaveType,DateTime joiningdte)
        {
            SqlParameter[] param = {new SqlParameter("@cmpycode", CmpyCode),
                        new SqlParameter("@empcode", EmpCode),
                         new SqlParameter("@LeaveTyp", LeaveType),
                          new SqlParameter("@joiningdte", joiningdte),};
            decimal BalLeave=0;
            ds = _EzBusinessHelper.ExecuteDataSet("BalanceLeave_Cal", CommandType.StoredProcedure, param);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            foreach (DataRow dr in drc)
            {
                BalLeave =Convert.ToDecimal(dr["BalLeave"].ToString());
            }
                return BalLeave;
        }

        public DateTime GetJoiningdate(string CmpyCode, string EmpCode)
        {
            DateTime Joindt = _EzBusinessHelper.ExecuteScalarDte("SELECT JoiningDate FROM MEM001 WHERE EmpCode='" + EmpCode + "' and  CmpyCode = '" + CmpyCode + "'  And WorkingStatus = 'Y'");
            return Joindt;
        }


    }
}
