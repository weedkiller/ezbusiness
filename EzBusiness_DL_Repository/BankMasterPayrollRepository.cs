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
    public class BankMasterPayrollRepository : IBankMasterPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public List<BankMaster> GetBnkList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRBM001 where CmpyCode='" + CmpyCode + "' ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<BankMaster> ObjList = new List<BankMaster>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new BankMaster()
                {
                    PRBM001_code = dr["PRBM001_code"].ToString(),
                    Bank_name = dr["Bank_name"].ToString(),
                    country= dr["country"].ToString()
                    
                });
            }
            return ObjList;
        }

        public List<BankBranchTbl> GetBnkGrid(string CmpyCode, string PRBM001_code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRBM002 where CmpyCode='" + CmpyCode + "' and PRBM001_code='" + PRBM001_code + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<BankBranchTbl> ObjList = new List<BankBranchTbl>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new BankBranchTbl()
                {                  
                   PRBM002_code = dr["PRBM002_code"].ToString(),
                   Bank_branch_name = dr["Bank_branch_name"].ToString(),                   
                });
            }
            return ObjList;
        }

        public BankMasterVM SaveBnk(BankMasterVM Bnk)
        {
            int n;
           
            if (!Bnk.EditFlag)
            {
               BankMaster pt = new BankMaster();             
                int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + Bnk.CmpyCode + "' and Code='PRBM' ");

                //pt.PRBM001_code = string.Concat("PRBM", "-", (pno + 1).ToString().PadLeft(4, '0')).ToString();                                
                List<BankBr> ObjList = new List<BankBr>();
                ObjList.AddRange(Bnk.Branch.Select(m => new BankBr
                {
                   
                    PRBM002_code = m.PRBM002_code,
                    Bank_branch_name = m.Bank_branch_name                    

                }).ToList());

                Bnk.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("insert into PRBM001(PRBM001_code,CmpyCode,country,Bank_name,Reference) values('" + Bnk.prbm001_code + "','" + Bnk.CmpyCode + "','" + Bnk.country + "','" + Bnk.Bank_name + "','" + Bnk.Reference + "')");
                n = ObjList.Count;
    

                while (n > 0 && Bnk.SaveFlag ==true)
                {
                    _EzBusinessHelper.ExecuteNonQuery("insert into PRBM002(PRBM001_code,PRBM002_code,Bank_branch_name,CmpyCode) values('" + Bnk.prbm001_code + "','" + ObjList[n - 1].PRBM002_code + "','" + ObjList[n - 1].Bank_branch_name + "','" + Bnk.CmpyCode + "')");
                    n = n - 1;
                }

                _EzBusinessHelper.ActivityLog(Bnk.CmpyCode, Bnk.UserName, "Add Bank Master", Bnk.prbm001_code, Environment.MachineName);      
                _EzBusinessHelper.ExecuteNonQuery("UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + Bnk.CmpyCode + "' and Code='PRBM'");

                Bnk.SaveFlag = true;
                Bnk.ErrorMessage = string.Empty;
            }
            else
            {
                int k = 0;
                k = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRBM003 where CmpyCode='" + Bnk.CmpyCode + "' and prbm001_code='" + Bnk.prbm001_code + "'");
                n = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRBM001 where CmpyCode='" + Bnk.CmpyCode + "' and prbm001_code='"+ Bnk.prbm001_code + "' ");

                if (n != 0 && k==0)
                {

                
                _EzBusinessHelper.ExecuteNonQuery("delete from PRBM001 where CmpyCode='" + Bnk.CmpyCode + "' and PRBM001_code='" + Bnk.prbm001_code + "'");
                _EzBusinessHelper.ExecuteNonQuery("delete from PRBM002 where CmpyCode='" + Bnk.CmpyCode + "' and PRBM001_code='" + Bnk.prbm001_code + "'");

                BankMaster pt = new BankMaster();                         
                List<BankBr> ObjList = new List<BankBr>();
                ObjList.AddRange(Bnk.Branch.Select(m => new BankBr
                {
                    PRBM001_code = m.PRBM001_code,
                    PRBM002_code = m.PRBM002_code,
                    Bank_branch_name = m.Bank_branch_name

                }).ToList());

                _EzBusinessHelper.ExecuteNonQuery("insert into PRBM001(PRBM001_code,CmpyCode,country,Bank_name,Reference) values('" + Bnk.prbm001_code + "','" + Bnk.CmpyCode + "','" + Bnk.country + "','" + Bnk.Bank_name + "','" + Bnk.Reference + "')");
                n = ObjList.Count;


                while (n > 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("insert into PRBM002(PRBM001_code,PRBM002_code,Bank_branch_name,CmpyCode) values('" + Bnk.prbm001_code + "','" + ObjList[n - 1].PRBM002_code + "','" + ObjList[n - 1].Bank_branch_name + "','" + Bnk.CmpyCode + "')");
                    n = n - 1;
                }

                    _EzBusinessHelper.ActivityLog(Bnk.CmpyCode, Bnk.UserName, "Update Bank Master", Bnk.prbm001_code, Environment.MachineName);
                    Bnk.SaveFlag = true;
                    Bnk.ErrorMessage = string.Empty;

                }
                else
                {
                    Bnk.SaveFlag = true;
                    Bnk.ErrorMessage = "Error occur";
                }

               
               
            }
            
            return Bnk;
        }

        public BankMasterVM GetBnkEdit(string CmpyCode, string PRBM001_code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRBM001 where CmpyCode='" + CmpyCode + "' and PRBM001_code='" + PRBM001_code + "' ");

            dt = ds.Tables[0];
            BankMasterVM pr = new BankMasterVM();
            foreach (DataRow dr in dt.Rows)
            {
                pr.CmpyCode = dr["CmpyCode"].ToString();
                pr.prbm001_code = dr["prbm001_code"].ToString();
                pr.country = dr["country"].ToString();
                pr.Bank_name = dr["Bank_name"].ToString();
                pr.Reference = dr["Reference"].ToString();                
            }
            return pr;
        }

        public List<Nation> GetNationList(string CmpyCode)
        {
            return drop.GetNationList(CmpyCode);
        }

        public bool DeleteBnk(string CmpyCode, string PRBM001_code, string username)
        {

            int k = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRBM003 where CmpyCode='" + CmpyCode + "' and PRBM001_code='" + PRBM001_code + "'");
            int Bns = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRBM001 where CmpyCode='" + CmpyCode + "' and PRBM001_code='" + PRBM001_code + "'");
            if (Bns != 0 && k == 0)
            {
                _EzBusinessHelper.ExecuteNonQuery("delete from PRBM001 where CmpyCode='" + CmpyCode + "' and PRBM001_code='" + PRBM001_code + "'");
                _EzBusinessHelper.ExecuteNonQuery("delete from PRBM002 where CmpyCode='" + CmpyCode + "' and PRBM001_code='" + PRBM001_code + "'");

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Bank Master", PRBM001_code, Environment.MachineName);
                return true;
            }
            return false;
        }

        public int UseBnkBranch(string CmpyCode, string PRBM001_code, string PRBM002_code)
        {
            int Bns = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRBM003 where CmpyCode='" + CmpyCode + "' and PRBM001_code='" + PRBM001_code + "' and PRBM002_code='"+ PRBM002_code + "'");
            return Bns;
        }
    }
}
