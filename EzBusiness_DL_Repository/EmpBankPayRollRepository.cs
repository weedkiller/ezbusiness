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
    public class EmpBankPayRollRepository:IEmpBankPayRollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteEmpBnk(string CmpyCode, string PRBM003_CODE, string username)
        {
            int Bbs = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRBM003 where CmpyCode='" + CmpyCode + "' and PRBM003_CODE='" + PRBM003_CODE + "'");
            if (Bbs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Emp Bank Master", PRBM003_CODE, Environment.MachineName);

                return  _EzBusinessHelper.ExecuteNonQuery1("update PRBM003 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRBM003_CODE='" + PRBM003_CODE + "'");
               // return true;
            }
            return false;
        }

        public EmpBankVM GetEmpBnkEdit(string CmpyCode, string PRBM003_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRBM003 where CmpyCode='" + CmpyCode + "' and PRBM003_CODE='" + PRBM003_CODE + "'and Flag=0 ");

            dt = ds.Tables[0];
            EmpBankVM EmpBank = new EmpBankVM();
            foreach (DataRow dr in dt.Rows)
            {
                EmpBank.CmpyCode = dr["Cmpycode"].ToString();
                EmpBank.EmpCode = dr["EmpCode"].ToString();
                EmpBank.Account_no = dr["Account_no"].ToString();              
                EmpBank.PRBM001_code = dr["PRBM001_code"].ToString();
                EmpBank.PRBM002_code = dr["PRBM002_code"].ToString();
                EmpBank.Entry_Date = Convert.ToDateTime(dr["Entry_Date"].ToString());
                EmpBank.EBAN_no = dr["EBAN_no"].ToString();               
                EmpBank.Remarks = dr["Remarks"].ToString();
                EmpBank.PRBM003_CODE = dr["PRBM003_CODE"].ToString();        
            }
            return EmpBank;
        }

        public List<EmpBankDetail> GetEmpBnkList(string CmpyCode)
        {
            // ds = _EzBusinessHelper.ExecuteDataSet("Select a.*,b.Empname from PRBM003 a inner join MEM001 b on a.Cmpycode=b.Cmpycode and a.EmpCode=b.EmpCode and a.Flag=b.Flag where a.CmpyCode='" + CmpyCode + "'and a.Flag=0");
            string qur = "Select a.*,b.Empname,c.Bank_name,d.Bank_branch_name from PRBM003 a " +
                         "inner join MEM001 b on a.Cmpycode = b.Cmpycode and a.EmpCode = b.EmpCode and b.Flag = a.Flag " +
                         "inner join PRBM001 c on c.CmpyCode = a.CMPYCODE and c.PRBM001_code = a.PRBM001_code and c.Flag = a.Flag " +
                         "inner join PRBM002 d on d.CmpyCode = a.CMPYCODE and d.PRBM002_code = a.PRBM002_code " +
                         "and d.PRBM001_code = a.PRBM001_code and d.Flag = a.Flag where a.CmpyCode='" + CmpyCode + "'and a.Flag=0 order by a.EmpCode ";
            ds = _EzBusinessHelper.ExecuteDataSet(qur);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<EmpBankDetail> ObjList = new List<EmpBankDetail>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new EmpBankDetail()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(),
                    PRBM003_CODE = dr["PRBM003_CODE"].ToString(),
                    Entry_Date = Convert.ToDateTime(dr["Entry_Date"].ToString()),
                    Remarks = dr["Remarks"].ToString(),
                    PRBM001_code = dr["Bank_name"].ToString(),
                    PRBM002_code = dr["Bank_branch_name"].ToString(),
                    Account_no = dr["Account_no"].ToString(),
                    EBAN_no = dr["EBAN_no"].ToString(),
                    EmpName=dr["EmpName"].ToString()
                });
            }
            return ObjList;
        }
        public List<Employee> GetEmpCodes(string CmpyCode)
        {          
            return drop.GetEmpCodes(CmpyCode,"B");
        }
        public List<BankMaster> GetPRBM001_code(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select prbm001_code,Bank_name from PRBM001 where CmpyCode= '" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<BankMaster> ObjList = new List<BankMaster>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new BankMaster()
                {
                    PRBM001_code = dr["PRBM001_code"].ToString(),  
                    Bank_name=dr["Bank_name"].ToString(),
                });

            }
            return ObjList;
        }

        public List<BankBranchTbl> GetPRBM002_code(string CmpyCode,string PRBM001_code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select PRBM002_code,Bank_branch_name from PRBM002 where CmpyCode= '" + CmpyCode + "' and PRBM001_code='" + PRBM001_code + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<BankBranchTbl> ObjList = new List<BankBranchTbl>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new BankBranchTbl()
                {
                    PRBM002_code = dr["PRBM002_code"].ToString(),
                    Bank_branch_name=dr["Bank_branch_name"].ToString(),
                });

            }
            return ObjList;
        }

        public EmpBankVM SaveEmpBnk(EmpBankVM EmpBnk)
        {
            DateTime dt1;
            string dtstr = "";
            dt1 = Convert.ToDateTime(EmpBnk.Entry_Date);
            dtstr = dt1.ToString("yyyy-MM-dd");
            try
            {
                if (!EmpBnk.EditFlag)
                {
                    
                 
                        int Empbn1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRBM003 where CmpyCode='" + EmpBnk.CmpyCode + "' and PRBM003_CODE='" + EmpBnk.PRBM003_CODE + "'");
                        if (Empbn1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + EmpBnk.CmpyCode + "',");
                            sb.Append("'" + EmpBnk.PRBM003_CODE + "',");
                            sb.Append("'" + EmpBnk.EmpCode + "',");
                            sb.Append("'" + EmpBnk.PRBM001_code + "',");
                            sb.Append("'" + EmpBnk.PRBM002_code + "',");
                            sb.Append("'" + dtstr + "',");
                            sb.Append("'" + EmpBnk.Account_no + "',");
                            sb.Append("'" + EmpBnk.EBAN_no + "',");
                            sb.Append("'" + EmpBnk.Remarks + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into PRBM003(CmpyCode,PRBM003_CODE,EmpCode,PRBM001_code,PRBM002_code,Entry_Date,Account_no,EBAN_no,Remarks) values(" + sb.ToString() + "");

                        _EzBusinessHelper.ActivityLog(EmpBnk.CmpyCode, EmpBnk.UserName, "Add Emp Bank Master", EmpBnk.PRBM003_CODE, Environment.MachineName);
                        EmpBnk.SaveFlag = true;
                            EmpBnk.ErrorMessage = string.Empty;
                        }
                        else
                        {

                           
                            EmpBnk.SaveFlag = false;
                            EmpBnk.ErrorMessage = "Duplicate Record";
                        }
                    //    n = n - 1;
                    //}
                   
                    return EmpBnk;
                }
                var EmpbnEdit = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRBM003 where CmpyCode='" + EmpBnk.CmpyCode + "' and PRBM003_CODE='" + EmpBnk.PRBM003_CODE + "'");
                if (EmpbnEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update PRBM003 set EmpCode='" + EmpBnk.EmpCode + "',PRBM001_code='" + EmpBnk.PRBM001_code + "',PRBM002_code='" + EmpBnk.PRBM002_code + "',Entry_Date='" + dtstr + "',Account_no='" + EmpBnk.Account_no + "',EBAN_no='" + EmpBnk.EBAN_no + "',Remarks='" + EmpBnk.Remarks + "' where CmpyCode='" + EmpBnk.CmpyCode + "' and PRBM003_CODE='" + EmpBnk.PRBM003_CODE + "'");
                    _EzBusinessHelper.ActivityLog(EmpBnk.CmpyCode, EmpBnk.UserName, "Update Emp Bank Master", EmpBnk.PRBM003_CODE, Environment.MachineName);
                    EmpBnk.SaveFlag = true;
                    EmpBnk.ErrorMessage = string.Empty;
                }
                else
                {
                    EmpBnk.SaveFlag = false;
                    EmpBnk.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                EmpBnk.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return EmpBnk;
        }
    }
}
