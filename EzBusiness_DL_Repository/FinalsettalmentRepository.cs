using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresource;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Repository
{
    public class FinalsettalmentRepository : IFinalsettalmentRepository
    {

        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteFinalSettalment(string CmpyCode,string Code, string username)
        {
            int Lons = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRFSET001 where CmpyCode='" + CmpyCode + "' and PRFSET001_code='" + Code + "'");
            if (Lons != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Final settalment", Code, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update PRFSET001 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRFSET001_code='" + Code + "'");
                //return true;
            }
            return false;
        }

        public List<FinalSettalment> GetFinalSettalment(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select a.*,b.Empname from PRFSET001 a inner join MEM001 b on a.Cmpycode=b.Cmpycode and a.EmpCode=b.EmpCode and a.Flag=b.Flag where a.CmpyCode='" + CmpyCode + "' and a.Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FinalSettalment> ObjList = new List<FinalSettalment>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FinalSettalment()
                {
                    Cmpycode = dr["CmpyCode"].ToString(),
                    PRFSET001_code = dr["PRFSET001_code"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(),
                    SettledDate = Convert.ToDateTime(dr["SettledDate"].ToString()),
                    Dates = Convert.ToDateTime(dr["Dates"].ToString()),
                    EmpName=dr["EmpName"].ToString(),
                });

            }
            return ObjList;
        }

        public Finalsettalment_VM SaveFinalSettalment(Finalsettalment_VM Fins)
        {
            try
            {
                DateTime dte;
                string dtstr1, dtstr2, dtstr3, dtstr4, dtstr5; ;



                dte = Convert.ToDateTime(Fins.Dates);
                dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                dte = Convert.ToDateTime(Fins.Dates);
                dtstr2 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                dte = Convert.ToDateTime(Fins.JoiningDate);
                dtstr3 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                dte = Convert.ToDateTime(Fins.DateofRelease);
                dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
                dte = Convert.ToDateTime(Fins.DutyResume);
                dtstr5 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");


                if (!Fins.EditFlag)
                {
                    int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + Fins.Cmpycode + "' and Code='PRFSET' ");

                    int Lons1 = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRFSET001 where CmpyCode='" + Fins.Cmpycode + "' and PRFSET001_code='" + Fins.PRFSET001_code + "'");
                    if (Lons1 == 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("'" + Fins.Cmpycode + "',");
                        sb.Append("'" + Fins.PRFSET001_code + "',");
                        sb.Append("'" + Fins.EmpCode + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + Fins.Reason + "',");
                        sb.Append("'" + dtstr2 + "',");
                        sb.Append("'" + dtstr3 + "',");
                        sb.Append("'" + dtstr4 + "',");
                        sb.Append("'" + Fins.NoOfDaysSuspended + "',");
                        sb.Append("'" + Fins.TotalNoOfDays + "',");
                        sb.Append("'" + Fins.NoOfDaysWkd + "',");
                        sb.Append("'" + Fins.GratuityEntitled + "',");
                        sb.Append("'" + Fins.Gratuity + "',");
                        sb.Append("'" + Fins.Addition + "',");
                        sb.Append("'" + Fins.Deduction + "',");
                        sb.Append("'" + Fins.NetAmount + "',");
                        sb.Append("'" + Fins.Status + "',");
                        sb.Append("'" + Fins.Stype + "',");
                        sb.Append("'" + Fins.TerType + "',");
                        sb.Append("'" + Fins.Basic + "',");
                        sb.Append("'" + Fins.SalType + "',");
                        sb.Append("'" + Fins.Remarks + "',");
                        sb.Append("'" + Fins.Absent + "',");
                        sb.Append("'" + Fins.DeductionDays + "',");
                        sb.Append("'" + Fins.UserCode + "',");
                        sb.Append("'" + Fins.Housing + "',");
                        sb.Append("'" + Fins.Tele_Allow + "',");
                        sb.Append("'" + Fins.Other_Allow + "',");
                        sb.Append("'" + Fins.Food + "',");
                        sb.Append("'" + Fins.Conveyance + "',");
                        // sb.Append("'" + Fins.OTWorkedHrs + "',");
                        sb.Append("'" + Fins.NoOfDays + "',");
                        sb.Append("'" + Fins.LNoOfDaysWkd + "',");
                        sb.Append("'" + dtstr5 + "',");
                        sb.Append("'" + Fins.LeaveCF + "',");
                        sb.Append("'" + Fins.LeaveBF + "',");
                        sb.Append("'" + Fins.LAppDays + "',");
                        sb.Append("'" + Fins.LeaveSalary + "',");
                        sb.Append("'" + Fins.PSalary + "',");
                        sb.Append("'" + Fins.LLSDate + "',");
                        sb.Append("'" + Fins.LBasic + "',");
                        sb.Append("'" + Fins.LeaveEntiled + "',");
                        sb.Append("'" + Fins.TotalEntiled + "',");
                        sb.Append("'" + Fins.LDeductionDays + "',");
                        sb.Append("'" + Fins.LAbsent + "',");
                        sb.Append("'" + Fins.ApprovalYN + "',");
                        sb.Append("'" + Fins.PostYN + "',");
                        sb.Append("'" + Fins.BasicL + "',");
                        sb.Append("'" + Fins.HousingL + "',");
                        sb.Append("'" + Fins.Tele_AllowL + "',");
                        sb.Append("'" + Fins.Other_AllowL + "',");
                        sb.Append("'" + Fins.FoodL + "',");
                        sb.Append("'" + Fins.ConveyanceL + "',");
                        // sb.Append("'" + Fins.NoticeYN + "',");
                        sb.Append("'" + Fins.GratuityAc + "',");
                        sb.Append("'" + Fins.LeaveAc + "',");
                        sb.Append("'" + Fins.UnpaidAc + "',");
                        sb.Append("'" + Fins.AccrualAc + "',");
                        // sb.Append("'" + Fins.JvNumber + "',");
                        sb.Append("'" + Fins.LoanDeduction + "',");
                        sb.Append("'" + Fins.OtherDeduction + "')");

                        Fins.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("insert into PRFSET001(Cmpycode,PRFSET001_code,EmpCode,Dates,Reason,SettledDate,JoiningDate,DateofRelease,NoOfDaysSuspended,TotalNoOfDays,NoOfDaysWkd,GratuityEntitled,Gratuity,Addition,Deduction,NetAmount,Status,Stype,TerType,Basic,SalType,Remarks,Absent,DeductionDays,UserCode,Housing,Tele_Allow,Other_Allow,Food,Conveyance,NoOfDays,LNoOfDaysWkd,DutyResume,LeaveCF,LeaveBF,LAppDays,LeaveSalary,PSalary,LLSDate,LBasic,LeaveEntiled,TotalEntiled,LDeductionDays,LAbsent,ApprovalYN,PostYN,BasicL,HousingL,Tele_AllowL,Other_AllowL,FoodL,ConveyanceL,GratuityAc,LeaveAc,UnpaidAc,AccrualAc,LoanDeduction,OtherDeduction) values(" + sb.ToString() + "");
                        _EzBusinessHelper.ExecuteNonQuery1("update [MEM001] set  WorkingStatus='"+ Fins.TerType + "' where  EmpCode='" + Fins.EmpCode + "' and Cmpycode='" + Fins.Cmpycode + "'");
                        if (Fins.SaveFlag == false)
                        {
                            Fins.ErrorMessage = "Duplicate Record";
                        }
                        else
                        {

                            _EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + Fins.Cmpycode + "' and Code='PRFSET'");
                            Fins.ErrorMessage = string.Empty;
                        }
                    }
                }
                else
                {
                    var LonsEdit = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRFSET001 where CmpyCode='" + Fins.Cmpycode + "'  and PRFSET001_code='" + Fins.PRFSET001_code + "'");
                    if (LonsEdit != 0)
                    {

                        StringBuilder sb = new StringBuilder();
                        sb.Append("EmpCode='" + Fins.EmpCode + "',");
                        sb.Append("Dates='" + dtstr1 + "',");
                        sb.Append("Reason='" + Fins.Reason + "',");
                        sb.Append("SettledDate='" + dtstr2 + "',");
                        sb.Append("JoiningDate='" + dtstr3 + "',");
                        sb.Append("DateofRelease='" + dtstr4 + "',");
                        sb.Append("NoOfDaysSuspended='" + Fins.NoOfDaysSuspended + "',");
                        sb.Append("TotalNoOfDays='" + Fins.TotalNoOfDays + "',");
                        sb.Append("NoOfDaysWkd='" + Fins.NoOfDaysWkd + "',");
                        sb.Append("GratuityEntitled='" + Fins.GratuityEntitled + "',");
                        sb.Append("Gratuity='" + Fins.Gratuity + "',");
                        sb.Append("Addition='" + Fins.Addition + "',");
                        sb.Append("Deduction='" + Fins.Deduction + "',");
                        sb.Append("NetAmount='" + Fins.NetAmount + "',");
                        sb.Append("Status='" + Fins.Status + "',");
                        sb.Append("Stype='" + Fins.Stype + "',");
                        sb.Append("TerType='" + Fins.TerType + "',");
                        sb.Append("Basic='" + Fins.Basic + "',");
                        sb.Append("SalType='" + Fins.SalType + "',");
                        sb.Append("Remarks='" + Fins.Remarks + "',");
                        sb.Append("Absent='" + Fins.Absent + "',");
                        sb.Append("DeductionDays='" + Fins.DeductionDays + "',");
                        sb.Append("UserCode='" + Fins.UserCode + "',");
                        sb.Append("Housing='" + Fins.Housing + "',");
                        sb.Append("Tele_Allow='" + Fins.Tele_Allow + "',");
                        sb.Append("Other_Allow='" + Fins.Other_Allow + "',");
                        sb.Append("Food='" + Fins.Food + "',");
                        sb.Append("Conveyance='" + Fins.Conveyance + "',");
                        // sb.Append("OTWorkedHrs='" + Fins.OTWorkedHrs + "',");
                        sb.Append("NoOfDays='" + Fins.NoOfDays + "',");
                        sb.Append("LNoOfDaysWkd='" + Fins.LNoOfDaysWkd + "',");
                        sb.Append("DutyResume='" + dtstr5 + "',");
                        sb.Append("LeaveCF='" + Fins.LeaveCF + "',");
                        sb.Append("LeaveBF='" + Fins.LeaveBF + "',");
                        sb.Append("LAppDays='" + Fins.LAppDays + "',");
                        sb.Append("LeaveSalary='" + Fins.LeaveSalary + "',");
                        sb.Append("PSalary='" + Fins.PSalary + "',");
                        sb.Append("LLSDate='" + Fins.LLSDate + "',");
                        sb.Append("LBasic='" + Fins.LBasic + "',");
                        sb.Append("LeaveEntiled='" + Fins.LeaveEntiled + "',");
                        sb.Append("TotalEntiled='" + Fins.TotalEntiled + "',");
                        sb.Append("LDeductionDays='" + Fins.LDeductionDays + "',");
                        sb.Append("LAbsent='" + Fins.LAbsent + "',");
                        sb.Append("ApprovalYN='" + Fins.ApprovalYN + "',");
                        sb.Append("PostYN='" + Fins.PostYN + "',");
                        sb.Append("BasicL='" + Fins.BasicL + "',");
                        sb.Append("HousingL='" + Fins.HousingL + "',");
                        sb.Append("Tele_AllowL='" + Fins.Tele_AllowL + "',");
                        sb.Append("Other_AllowL='" + Fins.Other_AllowL + "',");
                        sb.Append("FoodL='" + Fins.FoodL + "',");
                        sb.Append("ConveyanceL='" + Fins.ConveyanceL + "',");
                        //  sb.Append("NoticeYN='" + Fins.NoticeYN + "',");
                        sb.Append("GratuityAc='" + Fins.GratuityAc + "',");
                        sb.Append("LeaveAc='" + Fins.LeaveAc + "',");
                        sb.Append("UnpaidAc='" + Fins.UnpaidAc + "',");
                        sb.Append("AccrualAc='" + Fins.AccrualAc + "',");
                        // sb.Append("JvNumber='" + Fins.JvNumber + "',");
                        sb.Append("LoanDeduction='" + Fins.LoanDeduction + "',");
                        sb.Append("OtherDeduction='" + Fins.OtherDeduction + "'");

                        Fins.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("update PRFSET001 set " + sb.ToString() + " where CmpyCode='" + Fins.Cmpycode + "'  and PRFSET001_code='" + Fins.PRFSET001_code + "'");
                        _EzBusinessHelper.ExecuteNonQuery1("update [MEM001] set  WorkingStatus='" + Fins.TerType + "' where  EmpCode='" + Fins.EmpCode + "' and Cmpycode='" + Fins.Cmpycode + "'");
                        //Fins.SaveFlag = true;                   
                        if (Fins.SaveFlag == false)
                        {
                            Fins.ErrorMessage = "Record not available";
                        }
                        else
                        {
                            Fins.ErrorMessage = string.Empty;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Fins.SaveFlag = false;
                Fins.ErrorMessage = ex.Message;

            }

            return Fins;
        }

        public List<Employee> GetEmpCodes(string CmpyCode, string typ)
        {
            return drop.GetEmpCodes(CmpyCode, typ);
        }

        public Finalsettalment_VM GetFinalsettalmentEdit(string CmpyCode, string PRFSET001_code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRFSET001 where CmpyCode='" + CmpyCode + "' and PRFSET001_code='" + PRFSET001_code + "' and Flag=0");
            dt = ds.Tables[0];
            Finalsettalment_VM es = new Finalsettalment_VM();
            foreach (DataRow dr in dt.Rows)
            {
                es.Absent = Convert.ToDecimal(dr["Absent"].ToString());
                es.AccrualAc = dr["AccrualAc"].ToString();
                es.Addition = Convert.ToDecimal(dr["Addition"].ToString());
                es.ApprovalYN = dr["ApprovalYN"].ToString();
                es.Basic = Convert.ToDecimal(dr["Basic"].ToString());
                es.BasicL = Convert.ToDecimal(dr["BasicL"].ToString());
                es.Conveyance = Convert.ToDecimal(dr["Conveyance"].ToString());
                es.ConveyanceL = Convert.ToDecimal(dr["ConveyanceL"].ToString());
                es.DateofRelease = Convert.ToDateTime(dr["DateofRelease"].ToString());
                es.Dates = Convert.ToDateTime(dr["Dates"].ToString());
                es.Deduction = Convert.ToDecimal(dr["Deduction"].ToString());
                es.DeductionDays = Convert.ToDecimal(dr["DeductionDays"].ToString());
                es.LDeductionDays = Convert.ToInt32(dr["LDeductionDays"].ToString());
                es.LeaveAc = dr["LeaveAc"].ToString();
                es.LeaveBF = Convert.ToDecimal(dr["LeaveBF"].ToString());
                es.LeaveCF = Convert.ToDecimal(dr["LeaveCF"].ToString());
                es.LeaveEntiled = Convert.ToDecimal(dr["LeaveEntiled"].ToString());
                es.LeaveSalary = Convert.ToDecimal(dr["LeaveSalary"].ToString());
                es.LLSDate = Convert.ToDateTime(dr["LLSDate"].ToString());
                es.LNoOfDaysWkd = Convert.ToInt32(dr["LNoOfDaysWkd"].ToString());
                es.LoanDeduction = Convert.ToDecimal(dr["LoanDeduction"].ToString());
                es.NetAmount = Convert.ToDecimal(dr["NetAmount"].ToString());
                es.NoOfDays = Convert.ToInt32(dr["NoOfDays"].ToString());
                es.NoOfDaysSuspended = Convert.ToInt32(dr["NoOfDaysSuspended"].ToString());
                es.NoOfDaysWkd = Convert.ToInt32(dr["NoOfDaysWkd"].ToString());
                // es.NoticeYN = dr["NoticeYN"].ToString();
                es.OtherDeduction = Convert.ToDecimal(dr["OtherDeduction"].ToString());
                es.Other_Allow = Convert.ToDecimal(dr["Other_Allow"].ToString());
                es.Other_AllowL = Convert.ToDecimal(dr["Other_AllowL"].ToString());
                //  es.OTWorkedHrs = Convert.ToDecimal(dr["OTWorkedHrs"].ToString());
                es.PostYN = dr["PostYN"].ToString();
                es.PSalary = Convert.ToDecimal(dr["PSalary"].ToString());
                es.Reason = dr["Reason"].ToString();
                es.Remarks = dr["Remarks"].ToString();
                es.JoiningDate = Convert.ToDateTime(dr["JoiningDate"].ToString());

                es.SalType = dr["SalType"].ToString();
                es.SettledDate = Convert.ToDateTime(dr["SettledDate"].ToString());
                es.Stype = dr["Stype"].ToString();
                es.Tele_Allow = Convert.ToDecimal(dr["Tele_Allow"].ToString());
                es.Tele_AllowL = Convert.ToDecimal(dr["Tele_AllowL"].ToString());
                es.TerType = dr["TerType"].ToString();
                es.TotalEntiled = Convert.ToDecimal(dr["TotalEntiled"].ToString());
                es.TotalNoOfDays = Convert.ToInt32(dr["TotalNoOfDays"].ToString());
                es.UnpaidAc = dr["UnpaidAc"].ToString();
                es.UserCode = dr["UserCode"].ToString();
                es.EmpCode = dr["EmpCode"].ToString();
                es.Gratuity = Convert.ToDecimal(dr["Gratuity"].ToString());
                es.GratuityEntitled = Convert.ToInt32(dr["GratuityEntitled"].ToString());
                es.Food = Convert.ToDecimal(dr["Food"].ToString());
                es.Housing = Convert.ToDecimal(dr["Housing"].ToString());
                es.FoodL = Convert.ToDecimal(dr["FoodL"].ToString());
                es.HousingL = Convert.ToDecimal(dr["HousingL"].ToString());
                es.LAbsent = Convert.ToInt32(dr["LAbsent"].ToString());
                es.DutyResume = Convert.ToDateTime(dr["DutyResume"].ToString());
            }
            return es;

        }

        public List<FinalSettI> GetFinalSetI(string CmpyCode, string EmpCode)
        {
            SqlParameter[] param = { new SqlParameter("@CmpyCode", CmpyCode),
                                    new SqlParameter("@EmpCode", EmpCode)};



            ds = _EzBusinessHelper.ExecuteDataSet("usp_retFinalSetI", CommandType.StoredProcedure, param);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
            }



            //ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLR001 where cmpycode='" + CmpyCode + "' and  PRLR001_CODE='"+ PRLR001_CODE + "'");         
            //dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FinalSettI> ObjList = new List<FinalSettI>();
            foreach (DataRow dr in drc)
            {


                ObjList.Add(new FinalSettI()
                {
                    JoiningDate = Convert.ToDateTime(dr["JoiningDate"].ToString()),
                    Basic = Convert.ToDecimal(dr["Basic"].ToString()),
                    LBasic = Convert.ToDecimal(dr["LBasic"].ToString()),
                    Conveyance = Convert.ToDecimal(dr["Transport"].ToString()),
                    Food = Convert.ToDecimal(dr["Food"].ToString()),
                    Housing = Convert.ToDecimal(dr["Housing"].ToString()),
                    Other_Allow = Convert.ToDecimal(dr["Total Allownce"].ToString()),
                    Tele_Allow = Convert.ToDecimal(dr["Tele Allownce"].ToString()),
                    LastRetDate = Convert.ToDateTime(dr["LastRetDate"].ToString()),
                    LLSDate = Convert.ToDateTime(dr["LLSDate"].ToString()),
                    BalLeave = Convert.ToDecimal(dr["BalLeave"].ToString()),

                });
            }
            return ObjList;
        }

        public List<FinalSetII> GetFinalSetII(string Cmpycode, string Empcode, DateTime joiingdte, DateTime Reldate, float deducdays, string F1_type, float basicper, DateTime LLSdate, float Ldeducdays, string emptyp, float bleave, float Lbasic, float Housing, float Food, float Tele, float Transport, float Other_Allow)
        {
            SqlParameter[] param = { new SqlParameter("@Cmpycode",Cmpycode),
                                     new SqlParameter("@Empcode",Empcode),
                                     new SqlParameter("@joiingdte",joiingdte),
                                     new SqlParameter("@Reldate",Reldate),
                                     new SqlParameter("@deducdays",deducdays),
                                     new SqlParameter("@F1_type",F1_type),
                                     new SqlParameter("@basicper",basicper),
                                     new SqlParameter("@LLSdate",LLSdate),
                                     new SqlParameter("@Ldeducdays",Ldeducdays),
                                     new SqlParameter("@emptyp",emptyp),
                                     new SqlParameter("@bleave",bleave),
                                     new SqlParameter("@Lbasic",Lbasic),
                                     new SqlParameter("@Housing",Housing),
                                     new SqlParameter("@Food",Food),
                                     new SqlParameter("@Tele",Tele),
                                     new SqlParameter("@Transport",Transport),
                                     new SqlParameter("@Other_Allow",Other_Allow),};

            ds = _EzBusinessHelper.ExecuteDataSet("usp_FinsetIItest", CommandType.StoredProcedure, param);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
            }



            //ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLR001 where cmpycode='" + CmpyCode + "' and  PRLR001_CODE='"+ PRLR001_CODE + "'");         
            //dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FinalSetII> ObjList = new List<FinalSetII>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FinalSetII()
                {
                    absent = Convert.ToDouble(dr["absent"].ToString()),
                    BasicL = Convert.ToDouble(dr["BasicL"].ToString()),
                    deduct = Convert.ToDouble(dr["deduct"].ToString()),
                    FoodL = Convert.ToDouble(dr["FoodL"].ToString()),
                    Gratuity = Convert.ToDouble(dr["Gratuity"].ToString()),
                    GratuityEntitled = Convert.ToDouble(dr["GratuityEntitled"].ToString()),
                    HousingL = Convert.ToDouble(dr["HousingL"].ToString()),
                    labsentday = Convert.ToDouble(dr["labsentday"].ToString()),
                    LAppDays = Convert.ToDouble(dr["LAppDays"].ToString()),
                    LeaveSalary = Convert.ToDouble(dr["LeaveSalary"].ToString()),
                    loanamt = Convert.ToDouble(dr["loanamt"].ToString()),
                    lTotalnoday = Convert.ToDouble(dr["lTotalnoday"].ToString()),
                    lTotalnoWeekday = Convert.ToDouble(dr["lTotalnoWeekday"].ToString()),
                    NetAmount = Convert.ToDouble(dr["NetAmount"].ToString()),
                    Other_AllowL = Convert.ToDouble(dr["Other_AllowL"].ToString()),
                    TeleL = Convert.ToDouble(dr["TeleL"].ToString()),
                    totaldays = Convert.ToDouble(dr["totaldays"].ToString()),
                    TotalEntiled = Convert.ToDouble(dr["TotalEntiled"].ToString()),
                    totalnowek = Convert.ToDouble(dr["totalnowek"].ToString()),
                    TransportL = Convert.ToDouble(dr["TransportL"].ToString()),                   
                });
            }
            return ObjList;
        }

        
    }


}
