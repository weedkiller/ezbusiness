using EzBusiness_DL_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Data;
using System.Data.SqlClient;

namespace EzBusiness_DL_Repository
{
   public class LoanAppPayrollRepository : ILoanAppPayrollRepository
    {

        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteLoanApp(string CmpyCode, string PRLA001_CODE, string username)
        {
            int Bbs = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRLA001 where CmpyCode='" + CmpyCode + "' and PRLA001_CODE='" + PRLA001_CODE + "'");
            int P = _EzBusinessHelper.ExecuteScalar("select count(*) from PRLA002 where CmpyCode='" + CmpyCode + "' and PRLA001_CODE='" + PRLA001_CODE + "' and Paid='Y'");
            if (Bbs != 0 && P == 0)
            {
                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Loan Application", PRLA001_CODE, Environment.MachineName);
                _EzBusinessHelper.ExecuteNonQuery("update PRLA001 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRLA001_CODE='" + PRLA001_CODE + "'");
                _EzBusinessHelper.ExecuteNonQuery("update PRLA002 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRLA001_CODE='" + PRLA001_CODE + "'");
                return true;
            }
            return false;
        }

        public List<Employee> GetEmpCodes(string CmpyCode)
        {
            return drop.GetEmpCodes(CmpyCode, "B");
        }

        public LoanAppliationVM GetLoanAppEdit(string CmpyCode, string PRLA001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLA001 where CmpyCode='" + CmpyCode + "' and PRLA001_CODE='" + PRLA001_CODE + "' and Flag=0 ");

            dt = ds.Tables[0];
            LoanAppliationVM LoanApp = new LoanAppliationVM();
            foreach (DataRow dr in dt.Rows)
            {
                LoanApp.CmpyCode = dr["Cmpycode"].ToString();
                LoanApp.EmpCode = dr["EmpCode"].ToString();
                LoanApp.Act_code = dr["Act_code"].ToString();
                LoanApp.AppliedAmt =Convert.ToDecimal(dr["AppliedAmt"].ToString());
                LoanApp.ApprovalYN = dr["ApprovalYN"].ToString();
                LoanApp.AutoDeductionYN =dr["AutoDeductionYN"].ToString();
                LoanApp.Balance = Convert.ToDecimal(dr["Balance"].ToString());
                LoanApp.COUNTRY = dr["COUNTRY"].ToString();
                LoanApp.Deduction = Convert.ToDecimal(dr["Deduction"].ToString());
                LoanApp.DeductionStartDate = Convert.ToDateTime(dr["DeductionStartDate"].ToString());
                LoanApp.Entry_Date = Convert.ToDateTime(dr["Entry_Date"].ToString());
                LoanApp.LoanAmount= Convert.ToDecimal(dr["LoanAmount"].ToString());
                LoanApp.LoanType = dr["LoanType"].ToString();
                LoanApp.NoOfInstalments = Convert.ToInt32(dr["NoOfInstalments"].ToString());
                LoanApp.PRLA001_CODE = dr["PRLA001_CODE"].ToString();
                LoanApp.Remarks = dr["Remarks"].ToString();
                LoanApp.Status = dr["Status"].ToString();
                LoanApp.Instalment = Convert.ToDecimal(dr["Instalment"].ToString());
                

            }
            return LoanApp;
        }

        public List<LoanAppliationVM> GetLoanAppList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select a.*,b.Empname from PRLA001 a inner join MEM001 b on a.Cmpycode=b.Cmpycode and a.EmpCode=b.EmpCode and a.Flag=b.Flag where a.CmpyCode='" + CmpyCode + "' and a.Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<LoanAppliationVM> ObjList = new List<LoanAppliationVM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new LoanAppliationVM()
                {
                    CmpyCode = dr["Cmpycode"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(),
                    EmpName = dr["Empname"].ToString(),
                    Act_code = dr["Act_code"].ToString(),
                    AppliedAmt = Convert.ToDecimal(dr["AppliedAmt"].ToString()),
                    ApprovalYN = dr["ApprovalYN"].ToString(),
                    AutoDeductionYN = dr["AutoDeductionYN"].ToString(),
                    Balance = Convert.ToDecimal(dr["Balance"].ToString()),
                    COUNTRY = dr["COUNTRY"].ToString(),
                    Deduction = Convert.ToDecimal(dr["Deduction"].ToString()),
                    DeductionStartDate = Convert.ToDateTime(dr["DeductionStartDate"].ToString()),
                    Entry_Date = Convert.ToDateTime(dr["Entry_Date"].ToString()),
                    LoanAmount = Convert.ToDecimal(dr["LoanAmount"].ToString()),
                    LoanType = dr["LoanType"].ToString(),
                    NoOfInstalments = Convert.ToInt32(dr["NoOfInstalments"].ToString()),
                    PRLA001_CODE = dr["PRLA001_CODE"].ToString(),
                    Remarks = dr["Remarks"].ToString(),
                    Status = dr["Status"].ToString(),
                });
            }
            return ObjList;
        }

        public List<Loan> GetPRLM001(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLM001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Loan> ObjList = new List<Loan>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Loan()
                {
                    
                   PRLM001_CODE =dr["PRLM001_CODE"].ToString(),
                    Name = dr["Name"].ToString(),
                    Act_code=dr["Act_code"].ToString(),
                });
            }
            return ObjList;
        }

        public LoanAppliationVM SaveLoanApp(LoanAppliationVM LoanApp)
        {
            DateTime dt1;
            string dtstr = "";
            string dtstr1 = "";
            string dtdeductyyyy = "";
            string dtdeductmonth = "";
            dt1 = Convert.ToDateTime(LoanApp.Entry_Date);
            dtstr = dt1.ToString("yyyy-MM-dd");

            dt1 = Convert.ToDateTime(LoanApp.DeductionStartDate);
            dtstr1 = dt1.ToString("yyyy-MM-dd");

            try
            {
                if (!LoanApp.EditFlag)
                {

                    int Empbn1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRLA001 where CmpyCode='" + LoanApp.CmpyCode + "' and PRLA001_CODE='" + LoanApp.PRLA001_CODE + "'");
                    if (Empbn1 == 0)
                    {

                        dtdeductyyyy = dt1.ToString("yyyy");
                        dtdeductmonth = dt1.ToString("MM");
                        // LoanApp.SaveFlag = true;
                        SqlParameter[] param = {
                            new SqlParameter("@COUNTRY", LoanApp.COUNTRY),
                            new SqlParameter("@CmpyCode", LoanApp.CmpyCode),
                            new SqlParameter("@EmpCode", LoanApp.EmpCode),
                            new SqlParameter("@Entry_Date",dtstr),
                            new SqlParameter("@LoanAmount", LoanApp.LoanAmount),
                            new SqlParameter("@NoOfInstalments", LoanApp.NoOfInstalments),
                            new SqlParameter("@Instalment", LoanApp.Instalment),
                            new SqlParameter("@Deduction", LoanApp.Deduction),
                            new SqlParameter("@Balance", LoanApp.Balance),
                            new SqlParameter("@Remarks", LoanApp.Remarks),
                            new SqlParameter("@Status", LoanApp.Status),
                            new SqlParameter("@AutoDeductionYN", LoanApp.AutoDeductionYN),
                            new SqlParameter("@Deductiondate", dtstr1),
                            new SqlParameter("@Act_code", LoanApp.Act_code),
                            new SqlParameter("@LoanType", LoanApp.LoanType),
                            new SqlParameter("@ApprovalYN", LoanApp.ApprovalYN),
                            new SqlParameter("@AppliedAmt", LoanApp.AppliedAmt),
                            new SqlParameter("@Year", dtdeductyyyy),
                            new SqlParameter("@Month",dtdeductmonth)};
                        bool flag = _EzBusinessHelper.ExecuteNonQuery("usp_AddLoanApplication", param);
                        if (flag == true)
                            LoanApp.SaveFlag = true;                       
                            LoanApp.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        LoanApp.SaveFlag = false;
                        LoanApp.ErrorMessage = "Duplicate Record";
                    }
                    return LoanApp;
                }
                int P = _EzBusinessHelper.ExecuteScalar("select count(*) from PRLA002 where CmpyCode='" + LoanApp.CmpyCode + "' and PRLA001_CODE='" + LoanApp.PRLA001_CODE + "' and Paid='Y'");
                var EmpbnEdit = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRLA001 where CmpyCode='" + LoanApp.CmpyCode + "' and PRLA001_CODE='" + LoanApp.PRLA001_CODE + "'");
                if (EmpbnEdit != 0 && P == 0)
                {
                    // _EzBusinessHelper.ExecuteNonQuery("update PRLA001 set  EmpCode='" + LoanApp.EmpCode + "',Entry_Date='" + dtstr + "',LoanAmount='" + LoanApp.LoanAmount + "',NoOfInstalments='" + LoanApp.NoOfInstalments + "',Instalment='" + LoanApp.Instalment + "',Deduction='" + LoanApp.Deduction + "',Balance='" + LoanApp.Balance + "',Remarks='" + LoanApp.Remarks + "',Status='" + LoanApp.Status + "',AutoDeductionYN='" + LoanApp.AutoDeductionYN + "',DeductionStartDate='" + dtstr1 + "',Act_code='" + LoanApp.Act_code + "',LoanType='" + LoanApp.LoanType + "',ApprovalYN='" + LoanApp.ApprovalYN + "',AppliedAmt='" + LoanApp.AppliedAmt + "' where CmpyCode='" + LoanApp.CmpyCode + "' and PRLA001_CODE='" + LoanApp.PRLA001_CODE + "'");
                    //LoanApp.SaveFlag = true;
                    //LoanApp.ErrorMessage = string.Empty;

                    dtdeductyyyy = dt1.ToString("yyyy");
                    dtdeductmonth = dt1.ToString("MM");
                    // LoanApp.SaveFlag = true;
                    SqlParameter[] param = {
                            new SqlParameter("@COUNTRY", LoanApp.COUNTRY),
                            new SqlParameter("@PRLA001_CODE",LoanApp.PRLA001_CODE),
                            new SqlParameter("@CmpyCode", LoanApp.CmpyCode),
                            new SqlParameter("@EmpCode", LoanApp.EmpCode),
                            new SqlParameter("@Entry_Date",dtstr),
                            new SqlParameter("@LoanAmount", LoanApp.LoanAmount),
                            new SqlParameter("@NoOfInstalments", LoanApp.NoOfInstalments),
                            new SqlParameter("@Instalment", LoanApp.Instalment),
                            new SqlParameter("@Deduction", LoanApp.Deduction),
                            new SqlParameter("@Balance", LoanApp.Balance),
                            new SqlParameter("@Remarks", LoanApp.Remarks),
                            new SqlParameter("@Status", LoanApp.Status),
                            new SqlParameter("@AutoDeductionYN", LoanApp.AutoDeductionYN),
                            new SqlParameter("@Deductiondate", dtstr1),
                            new SqlParameter("@Act_code", LoanApp.Act_code),
                            new SqlParameter("@LoanType", LoanApp.LoanType),
                            new SqlParameter("@ApprovalYN", LoanApp.ApprovalYN),
                            new SqlParameter("@AppliedAmt", LoanApp.AppliedAmt),
                            new SqlParameter("@Year", dtdeductyyyy),
                            new SqlParameter("@Month",dtdeductmonth)};
                    bool flag = _EzBusinessHelper.ExecuteNonQuery("UpdateLoanApplication", param);
                    if (flag == true)
                        LoanApp.SaveFlag = true;
                    LoanApp.ErrorMessage = string.Empty;
                }
                else
                {
                    LoanApp.SaveFlag = false;
                    LoanApp.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                LoanApp.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return LoanApp;
        }
    }
}
