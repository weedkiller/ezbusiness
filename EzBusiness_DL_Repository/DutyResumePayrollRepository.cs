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
    public class DutyResumePayrollRepository : IDutyResumePayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteDrs(string Cmpycode, string PRDR001_CODE, string oldLeavedays, string EmpCode, string username)
        {
           
            bool Cstatus;

            SqlParameter[] param1 = {
                        new SqlParameter("@CmpyCode",Cmpycode),
                        new SqlParameter("@Empcode",EmpCode),
                        new SqlParameter("@oldLeavedays",oldLeavedays),
                        new SqlParameter("@PRDR001_CODE",PRDR001_CODE)
                       };

            Cstatus = _EzBusinessHelper.ExecuteNonQuery("DeleteDutyResume", param1);
            if (Cstatus == true)
            {
                return _EzBusinessHelper.ActivityLog(Cmpycode, username, "Delete DutyResume Master", PRDR001_CODE, Environment.MachineName);
               // return true;
            }
            return false;
        }
        public List<DutyResume> GetDrs(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRDR001 where Cmpycode='" + Cmpycode + "' and flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<DutyResume> ObjList = new List<DutyResume>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new DutyResume()
                {
                    Cmpycode = dr["Cmpycode"].ToString(),
                    PRDR001_CODE = dr["PRDR001_CODE"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(),
                    ResumeDate = Convert.ToDateTime(dr["ResumeDate"]),
                    PRLR001_CODE= dr["PRLR001_CODE"].ToString(),
                });
            }
            return ObjList;
        }

        public DutyResumeVM GetDutyEdit(string Cmpycode, string LsNo)
        {
             DutyResumeVM du = null;
            //ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRDR001 where Cmpycode='" + Cmpycode + "' and PRDR001_CODE='" + LsNo +"'");
             ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRDR001 a,PRLR001 b where  a.Cmpycode='" + Cmpycode + "' and a.PRDR001_CODE='" + LsNo + "' and a.PRLR001_CODE = b.PRLR001_CODE and a.Cmpycode = b.Cmpycode");
             if (ds.Tables.Count > 0)
             {
               dt = ds.Tables[0];
               du= new DutyResumeVM();
               foreach (DataRow dr in dt.Rows)
               {
                    du.Cmpycode = dr["Cmpycode"].ToString();
                    du.EmpCode = dr["EmpCode"].ToString();
                    du.ResumeDate = Convert.ToDateTime(dr["ResumeDate"].ToString());
                    du.PRLR001_CODE = dr["PRLR001_CODE"].ToString();
                    du.StartDate = Convert.ToDateTime(dr["StartDate"].ToString());
                    du.EndDate = Convert.ToDateTime(dr["EndDate"].ToString());
                    du.Actual_Leave_Type = dr["Actual_Leave_Type"].ToString();
                    du.Approve_Days = dr["Approve_Days"].ToString();
                    du.Approve_Days_in_full = dr["Approve_Days_in_full"].ToString();
                    du.Approve_Days_in_Half = dr["Approve_Days_in_Half"].ToString();
                    du.country = dr["country"].ToString();
                    du.division = dr["division"].ToString();
                    du.Excess_Days_plus_minus = dr["Excess_Days_plus_minus"].ToString();
                    du.PRDR001_CODE = dr["PRDR001_CODE"].ToString();
                    du.PRLS001_CODE = dr["PRLS001_CODE"].ToString();
                    du.BalanceLeave = dr["TotalBalance"].ToString();
                    // du.Remark = dr["Remark"].ToString();
                    //du.DrNo = dr["DrNo"].ToString();
                }
            }
           return du;           
        }

        public List<Employee> GetEmpCodes(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("SELECT EmpCode, EmpName FROM MEm001 WHERE Cmpycode='" + Cmpycode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Employee> ObjList = new List<Employee>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Employee()
                {
                    EmpCode = dr["EmpCode"].ToString(),
                    Empname = dr["Empname"].ToString(),
                });

            }
            return ObjList;
        }
        public List<LeaveApplication> GetLeaveData(string cmpycode, string LanNo)
        {

            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLR001 where CmpyCode='" + cmpycode + "' AND PRLR001_CODE='" + LanNo + "' and status!='D'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<LeaveApplication> ObjList = new List<LeaveApplication>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new LeaveApplication()
                {
                   PRLR001_CODE = dr["PRLR001_CODE"].ToString(),
                   StartDate = Convert.ToDateTime(dr["StartDate"]),
                   EndDate = Convert.ToDateTime(dr["EndDate"]),
                   EmpCode = dr["EmpCode"].ToString(),
                   LeaveType = dr["LeaveType"].ToString(),
                    TotalSanctioned = dr["TotalSanctioned"].ToString(),
                    DIVISION = dr["division"].ToString(),
                    COUNTRY = dr["division"].ToString(),
                    JoiningDate = Convert.ToDateTime(dr["JoiningDate"]),
                    TotalBalance=dr["TotalBalance"].ToString()
                });

            }
            return ObjList;
        }

        public List<LeaveApplication> GetLsNo(string Cmpycode, string typ)
        {
            if (typ != "Etyp")
            {
                ds = _EzBusinessHelper.ExecuteDataSet("Select a.* from PRLR001 a where a.cmpycode='" + Cmpycode + "' and a.Status!='D' and PRLR001_CODE Not in (Select PRLR001_CODE from PRDR001 where cmpycode=a.cmpycode and flag=0) and PRLR001_CODE not in (Select PRLR001_CODE from PRDR001 where cmpycode=a.cmpycode and flag=0) order by a.PRLR001_CODE");
            }
            else
            {
                ds = _EzBusinessHelper.ExecuteDataSet("Select a.* from PRLR001 a where a.cmpycode='" + Cmpycode + "' and a.Status!='D' and PRLR001_CODE  in (Select PRLR001_CODE from PRLS001 where cmpycode = a.cmpycode and flag=0) order by a.PRLR001_CODE");
            }
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<LeaveApplication> ObjList = new List<LeaveApplication>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new LeaveApplication()
                {
                    //LsNo=dr["LsNo"].ToString(),
                    // ResumeDate= Convert.ToDateTime(dr["ResumeDate"]),                    
                    // EmpCode = dr["EmpCode"].ToString(),
                    // DrNo = dr["DrNo"].ToString()
                    PRLR001_CODE = dr["PRLR001_CODE"].ToString(),
                    StartDate = Convert.ToDateTime(dr["StartDate"]),
                    EndDate = Convert.ToDateTime(dr["EndDate"]),
                    EmpCode = dr["EmpCode"].ToString(),
                    LeaveType = dr["LeaveType"].ToString(),
                    TotalBalance=dr["TotalBalance"].ToString()
                });
            }
            return ObjList;
        }
        public List<Attendence> GetLeaveTypList(string CmpyCode)
        {
            return drop.GetAtens(CmpyCode);
        }

        public DutyResumeVM SaveDrs(DutyResumeVM Drs)
        {
            bool cstatus = false;
            int n;
            string dtstr1, dtstr2, dtstr3 = null;
            DateTime dte;
            dte = Convert.ToDateTime(Drs.EndDate.ToString());
            dtstr3 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            //dte = Convert.ToDateTime(Drs.StartDate.ToString());
            //dtstr2 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(Drs.ResumeDate.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            try
            {
                if (!Drs.EditFlag)
                {
                    SqlParameter[] param1 = {
                        new SqlParameter("@PRLR001_CODE",Drs.PRLR001_CODE),
                        new SqlParameter("@CmpyCode", Drs.Cmpycode),
                        new SqlParameter("@country",Drs.country),
                        new SqlParameter("@division",Drs.division),
                        new SqlParameter("@PRLS001_CODE",Drs.PRLS001_CODE),
                        new SqlParameter("@Empcode",Drs.EmpCode),
                        new SqlParameter("@ResumeDate",dtstr1),
                        new SqlParameter("@Excess_Date",dtstr3),
                        new SqlParameter("@Actual_Leave_Type",Drs.Actual_Leave_Type),
                        new SqlParameter("@Duty_Rm_type",Drs.Duty_Rm_type),
                        new SqlParameter("@Approve_Days",Drs.Approve_Days),
                        new SqlParameter("@Excess_Days_plus_minus",Drs.Excess_Days_plus_minus),
                        new SqlParameter("@Approve_Days_in_full",Drs.Approve_Days_in_full),
                        new SqlParameter("@Approve_Days_in_Half",Drs.Approve_Days_in_Half)
                       };
                    cstatus = _EzBusinessHelper.ExecuteNonQuery("AddDutyResume", param1);
                    if (cstatus == true)
                    {
                        Drs.SaveFlag = true;
                        Drs.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Drs.SaveFlag = false;
                        Drs.ErrorMessage = "Duplicate Record";
                    }
                    return Drs;
                }
                else
                {
                     SqlParameter[] param1 = {new SqlParameter("@PRDR001_CODE",Drs.PRDR001_CODE),
                        new SqlParameter("@PRLR001_CODE",Drs.PRLR001_CODE),
                        new SqlParameter("@CmpyCode", Drs.Cmpycode),
                        new SqlParameter("@country",Drs.country),
                        new SqlParameter("@division",Drs.division),
                        new SqlParameter("@PRLS001_CODE",Drs.PRLS001_CODE),
                        new SqlParameter("@Empcode",Drs.EmpCode),
                        new SqlParameter("@ResumeDate",dtstr1),
                        new SqlParameter("@Excess_Date",dtstr3),
                        new SqlParameter("@Actual_Leave_Type",Drs.Actual_Leave_Type),
                        new SqlParameter("@Duty_Rm_type",Drs.Duty_Rm_type),
                        new SqlParameter("@Approve_Days",Drs.Approve_Days),
                        new SqlParameter("@Excess_Days_plus_minus",Drs.Excess_Days_plus_minus),
                        new SqlParameter("@Approve_Days_in_full",Drs.Approve_Days_in_full),
                        new SqlParameter("@Approve_Days_in_Half",Drs.Approve_Days_in_Half),
                        new SqlParameter("@oldLeavedays",Drs.oldLeavedays)
                    };

                    cstatus = _EzBusinessHelper.ExecuteNonQuery("UpdateDutyResume", param1);
                    if (cstatus == true)
                    {
                        Drs.SaveFlag = true;
                        Drs.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Drs.SaveFlag = false;
                        Drs.ErrorMessage = "Duplicate Record";
                    }

                    return Drs;
                }
            }
            catch
            {
                Drs.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;
            }
            return Drs;
        }
    }
}
