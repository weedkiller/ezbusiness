using EzBusiness_DL_Interface.FinanceManagementDLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FinaceMgmt;
using System.Data;
using System.Transactions;
using EzBusiness_EF_Entity;

namespace EzBusiness_DL_Repository.FinanceManagementDLR
{
    public class FNM_SL1001Repository : IFNM_SL1001Repository
    {
      
        DataSet ds = null;
        DataTable dt = null;
      
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteFNM_SL1001(string CmpyCode,string FNM_SL1001_CODE,  string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNM_SL1001 where CMPYCODE='" + CmpyCode + "' and FNM_SL1001_CODE='" + FNM_SL1001_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNM_SL1001", FNM_SL1001_CODE, Environment.MachineName);

                bool t1, t2;

                t1=_EzBusinessHelper.ExecuteNonQuery1("update FNM_SL1001 set Flag=1 where CMPYCODE='" + CmpyCode + "' and FNM_SL1001_CODE='" + FNM_SL1001_CODE + "'  and Flag=0");
                t2 = _EzBusinessHelper.ExecuteNonQuery1("update FNM_SL1002 set Flag=1 where CMPYCODE='" + CmpyCode + "' and FNM_SL1001_CODE='" + FNM_SL1001_CODE + "'  and Flag=0");
                if(t1==true && t2 == true)
                {
                    return _EzBusinessHelper.ExecuteNonQuery1("update FNM_SL1001 set Flag=1 where CMPYCODE='" + CmpyCode + "' and FNM_SL1001_CODE='" + FNM_SL1001_CODE + "'  and Flag=0");
                }                
            }
            return false;
        }

        public FNM_SL_VM EditFNM_SL(string CmpyCode, string FNM_SL1001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNM_SL1001 where CMPYCODE='" + CmpyCode + "' and FNM_SL1001_CODE='" + FNM_SL1001_CODE + "'  and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FNM_SL_VM ObjList = new FNM_SL_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.CMPYCODE = dr["CMPYCODE"].ToString();
                ObjList.FNM_SL1001_CODE = dr["FNM_SL1001_CODE"].ToString();
                ObjList.Name = dr["Name"].ToString();
                ObjList.Print_Name = dr["Print_Name"].ToString();
                ObjList.Tel = dr["Tel"].ToString().Trim();
                ObjList.Address = dr["Address"].ToString().Trim();
                ObjList.Contact1 = dr["Contact1"].ToString().Trim();
                ObjList.Contact2 = dr["Contact2"].ToString();
                ObjList.Contact3 = dr["Contact3"].ToString();
                ObjList.credit_limit =Convert.ToDecimal(dr["credit_limit"].ToString());
                ObjList.Currency_code = dr["Currency_code"].ToString();
                ObjList.Email = dr["Email"].ToString();
                ObjList.Fax = dr["Fax"].ToString();
                ObjList.SUBLEDGER_TYPE = dr["SUBLEDGER_TYPE"].ToString();
                ObjList.Web_site = dr["Web_site"].ToString();
                ObjList.Name_Arabic =Convert.ToString(dr["Name_Arabic"]);
                ObjList.Branchcode = dr["Branchcode"].ToString();

            }
            return ObjList;
        }

        public List<FNM_SL1001> GetFNM_SL(string CmpyCode,string SubledgerType)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNM_SL1001_CODE,Name,Print_Name,Web_site,Email,Tel,Fax,Address,Contact1,Contact2,Contact3,Currency_code,credit_limit,SUBLEDGER_TYPE,Name_Arabic from FNM_SL1001 where CmpyCode='" + CmpyCode + "' and SUBLEDGER_TYPE='"+SubledgerType+"' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_SL1001> ObjList = new List<FNM_SL1001>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_SL1001()
                {
                    Address = dr["Address"].ToString(),
                    Contact1 = dr["Contact1"].ToString(),
                    Contact2 = dr["Contact2"].ToString(),
                    Contact3 = dr["Contact3"].ToString(),
                    Name = dr["NAME"].ToString(),
                    credit_limit =Convert.ToDecimal(dr["credit_limit"].ToString()),
                    Currency_code = dr["Currency_code"].ToString(),
                    Email=dr["Email"].ToString(),
                    FNM_SL1001_CODE=dr["FNM_SL1001_CODE"].ToString(),
                    Fax=dr["Fax"].ToString(),
                    Print_Name=dr["Print_Name"].ToString(),
                    Tel=dr["Tel"].ToString(),
                    Web_site=dr["Web_site"].ToString(),
                    SUBLEDGER_TYPE=dr["SUBLEDGER_TYPE"].ToString(),
                    Name_Arabic = dr["Name_Arabic"].ToString(),
                });
            }
            return ObjList;
        }

        public List<ComDropTbl> GetFNMCAT(string CmpyCode, string type1, string Prefix)
        {
            string qur = "";
            if(type1 == "FM")
            {
                qur = "Select FNMSLCAT_CODE as [Code],DESCRIPTION as [CodeName] from FNMSLCAT where FNMSLCAT_CODE  in('APP','ARP') and  CmpyCode='" + CmpyCode + "' and Flag=0 and (FNMSLCAT_CODE like '" + Prefix + "%' or DESCRIPTION like '" + Prefix + "%')";
            }
            else
            {
                qur = "Select FNMSLCAT_CODE as [Code],DESCRIPTION as [CodeName] from FNMSLCAT where FNMSLCAT_CODE not in('APP','ARP') and CmpyCode='" + CmpyCode + "' and Flag=0 and (FNMSLCAT_CODE like '" + Prefix + "%' or DESCRIPTION like '" + Prefix + "%')";
            }

            return drop.GetCommonDrop2(qur);
            //ds = _EzBusinessHelper.ExecuteDataSet(qur);// 
            //dt = ds.Tables[0];
            //DataRowCollection drc = dt.Rows;
            //List<FNMCAT> ObjList = new List<FNMCAT>();
            //foreach (DataRow dr in drc)
            //{
            //    ObjList.Add(new FNMCAT()
            //    {
            //        FNMSLCAT_CODE = dr["FNMSLCAT_CODE"].ToString(),
            //        DESCRIPTION = dr["DESCRIPTION"].ToString()
            //    });
            //}
            //return ObjList;
        }
          

        public List<FNM_SL1002> GetFNM_SL1002(string CmpyCode, string FNM_SL1001_CODE)
        {
           
            ds = _EzBusinessHelper.ExecuteDataSet("Select COA_CODE,FNM_SL1002_CODE,NAME,COA_NAME from FNM_SL1002 where CmpyCode='" + CmpyCode + "' and Flag=0 and FNM_SL1001_CODE='" + FNM_SL1001_CODE + "'");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_SL1002> ObjList = new List<FNM_SL1002>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_SL1002()
                {
                    COA_CODE = dr["COA_CODE"].ToString(),
                    FNM_SL1002_CODE = dr["FNM_SL1002_CODE"].ToString(),
                    NAME=dr["NAME"].ToString(),
                    COA_NAME=dr["COA_NAME"].ToString()
                });
            }
            return ObjList;
        }

        public List<ComDropTbl> GetFNMCURRENCY(string Prefix)
        {


            return drop.GetCommonDrop("CURRENCY_CODE as [Code],CURRENCY_NAME as [CodeName]", "FNM_CURRENCY", "Flag=0 and (CURRENCY_CODE like '" + Prefix + "%' or CURRENCY_NAME like '" + Prefix + "%')");
            //ds = _EzBusinessHelper.ExecuteDataSet("Select CURRENCY_CODE,CURRENCY_NAME from FNM_CURRENCY where Flag=0");// 
            //dt = ds.Tables[0];
            //DataRowCollection drc = dt.Rows;
            //List<ComDropTbl> ObjList = new List<ComDropTbl>();
            //foreach (DataRow dr in drc)
            //{
            //    ObjList.Add(new ComDropTbl()
            //    {
            //        Code = dr["CURRENCY_CODE"].ToString(),
            //        CodeName = dr["CURRENCY_NAME"].ToString()
            //    });
            //}
            //return ObjList;
        }

        public FNM_SL_VM SaveFNM_SL(FNM_SL_VM FNSL)
        {
            int n = 0;
            DateTime dte;
            string dtstr7;
            dte = Convert.ToDateTime(System.DateTime.Now);
            dtstr7 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            var counter = 1;
            if (!FNSL.EditFlag)
            {
                try
                {
                    //FNM_SL1001 FNMSL = new FNM_SL1001();
                    #region FNM_SL1001_VM1
                    //FNMSL.Address = FNSL.Address;
                    //FNMSL.CMPYCODE = FNSL.CMPYCODE;
                    //FNMSL.Contact1 = FNSL.Contact1;
                    //FNMSL.Contact2 = FNSL.Contact2;
                    //FNMSL.Contact3 = FNSL.Contact3;
                    //FNMSL.CREATED_BY = FNSL.UserName;
                    //FNMSL.credit_limit = FNSL.credit_limit;
                    //FNMSL.Currency_code = FNSL.Currency_code;
                    //FNMSL.Email = FNSL.Email;
                    //FNMSL.Fax = FNSL.Fax;
                    //FNMSL.FNM_SL1001_CODE = FNSL.FNM_SL1001_CODE;
                    //FNMSL.Name = FNSL.Name;
                    //FNMSL.Name_Arabic = FNSL.Name_Arabic;
                    //FNMSL.Print_Name = FNSL.Print_Name;
                    //FNMSL.SUBLEDGER_TYPE = FNSL.SUBLEDGER_TYPE;
                    //FNMSL.Tel = FNSL.Tel;
                    //FNMSL.UPDATED_BY = FNSL.UserName;
                    //FNMSL.Web_site = FNSL.Web_site;                                          
                    #endregion                   
                    #region ObjectList
                    List<FNM_SL1002DetailNew> ObjList = new List<FNM_SL1002DetailNew>();
                    if (FNSL.FNM_SL1002Details != null)
                    {
                        ObjList.AddRange(FNSL.FNM_SL1002Details.Select(m => new FNM_SL1002DetailNew
                        {
                            CMPYCODE=m.CMPYCODE,
                            COA_CODE=m.COA_CODE,
                            DIVISION=m.DIVISION,
                            FNM_SL1001_CODE=m.FNM_SL1001_CODE,
                            FNM_SL1002_CODE=m.FNM_SL1002_CODE,
                            COA_NAME=m.COA_NAME,
                            NAME =m.NAME
                        }).ToList());
                    }
                    #endregion                     
                    using (TransactionScope scope = new TransactionScope())
                    {
                        StringBuilder sb = new StringBuilder();
                        #region FNM SL001
                        sb.Append("(Address,");
                        sb.Append("CMPYCODE,");
                        sb.Append("Contact1,");
                        sb.Append("Contact2,");
                        sb.Append("Contact3,");
                        sb.Append("CREATED_BY,");
                        sb.Append("credit_limit,");
                        sb.Append("Currency_code,");
                        sb.Append("Email,");
                        sb.Append("Fax,");
                        sb.Append("FNM_SL1001_CODE,");                        
                        sb.Append("Name,");
                        sb.Append("Print_Name,");
                        sb.Append("SUBLEDGER_TYPE,");
                        sb.Append("Tel,");
                        sb.Append("UPDATED_BY,");
                        sb.Append("Web_site,");
                        sb.Append("UPDATED_ON,");
                        sb.Append("DIVISION,");
                        sb.Append("Name_Arabic,");
                        sb.Append("Branchcode,");
                        sb.Append("CREATED_ON)");
                        sb.Append(" values(");
                        //'---
                        sb.Append("'" + FNSL.Address + "',");
                        sb.Append("'" + FNSL.CMPYCODE + "',");
                        sb.Append("'" + FNSL.Contact1 + "',");
                        sb.Append("'" + FNSL.Contact2 + "',");
                        sb.Append("'" + FNSL.Contact3 + "',");
                        sb.Append("'" + FNSL.UserName + "',");
                        sb.Append("'" + FNSL.credit_limit + "',");
                        sb.Append("'" + FNSL.Currency_code + "',");
                        sb.Append("'" + FNSL.Email + "',");
                        sb.Append("'" + FNSL.Fax + "',");
                        sb.Append("'" + FNSL.FNM_SL1001_CODE + "',");
                        //sb.Append("'" + dtstr3 + "',");
                        sb.Append("'" + FNSL.Name + "',");
                        sb.Append("'" + FNSL.Print_Name + "',");
                        sb.Append("'" + FNSL.SUBLEDGER_TYPE + "',");
                        sb.Append("'" + FNSL.Tel + "',");
                        sb.Append("'" + FNSL.UPDATED_BY + "',");
                        sb.Append("'" + FNSL.Web_site + "',");
                        sb.Append("'" + dtstr7 + "',");
                        sb.Append("'"+ FNSL.DIVISION + "',");
                        sb.Append("'" + FNSL.Name_Arabic + "',");
                        sb.Append("'" + FNSL.Branchcode + "',");
                        sb.Append("'" + dtstr7 + "')");

                        bool resul = _EzBusinessHelper.ExecuteNonQuery1("insert into FNM_SL1001" + sb + "");
                        _EzBusinessHelper.ActivityLog(FNSL.CMPYCODE, FNSL.UserName, "Add FNM_SL1001", FNSL.FNM_SL1001_CODE, Environment.MachineName);
                        #endregion
                        if (resul == true)
                        {                           
                            #region FNMSL002
                            n = ObjList.Count;
                            while (n > 0)
                            {                               
                                sb.Clear();
                                sb.Append("(CMPYCODE,");
                                sb.Append("DIVISION,");
                                sb.Append("FNM_SL1001_CODE,");
                                sb.Append("FNM_SL1002_CODE,");
                                sb.Append("NAME,");
                                sb.Append("COA_NAME,");
                                sb.Append("COA_CODE)");
                                sb.Append(" values(");
                                sb.Append("'" + FNSL.CMPYCODE + "',");
                                sb.Append("'" + FNSL.DIVISION + "',");
                                sb.Append("'" + FNSL.FNM_SL1001_CODE + "',");
                                sb.Append("'" + ObjList[n - 1].FNM_SL1002_CODE + "',");
                                sb.Append("'" + ObjList[n - 1].NAME + "',");
                                sb.Append("'" + ObjList[n - 1].COA_NAME + "',");
                                sb.Append("'" + ObjList[n - 1].COA_CODE + "')");
                                _EzBusinessHelper.ExecuteNonQuery("insert into FNM_SL1002" + sb + " ");
                                int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + FNSL.CMPYCODE + "' and Code='CUST' ");
                                _EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + FNSL.CMPYCODE + "' and Code='CUST'");
                                _EzBusinessHelper.ActivityLog(FNSL.CMPYCODE, FNSL.UserName, "Update FNM_SL1001", FNSL.FNM_SL1001_CODE, Environment.MachineName);
                                n = n - 1;
                            }
                            #endregion                         
                            counter = 1;
                            FNSL.ErrorMessage = string.Empty;
                            FNSL.SaveFlag = true;
                           // FNSL.ErrorMessage = string.Empty;
                        }
                        scope.Complete();
                    }
                }
                catch (Exception)
                {
                    FNSL.ErrorMessage = "Error occur";
                    FNSL.SaveFlag = false;
                }
            }
            else
            {               
                try
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNM_SL1001 where CMPYCODE='" + FNSL.CMPYCODE + "' and FNM_SL1001_CODE='" + FNSL.FNM_SL1001_CODE + "' and Flag=0");
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        FNM_SL1001 FNMSL = new FNM_SL1001();
                        dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            #region FNMSL001                            
                            FNMSL.Address = FNSL.Address;
                            FNMSL.CMPYCODE = FNSL.CMPYCODE;
                            FNMSL.Contact1 = FNSL.Contact1;
                            FNMSL.Contact2 = FNSL.Contact2;
                            FNMSL.Contact3 = FNSL.Contact3;
                            FNMSL.CREATED_BY = FNSL.UserName;
                            FNMSL.credit_limit = FNSL.credit_limit;
                            FNMSL.Currency_code = FNSL.Currency_code;
                            FNMSL.Email = FNSL.Email;
                            FNMSL.Fax = FNSL.Fax;
                            FNMSL.FNM_SL1001_CODE = FNSL.FNM_SL1001_CODE;
                            FNMSL.Name = FNSL.Name;
                            FNMSL.Print_Name = FNSL.Print_Name;
                            FNMSL.SUBLEDGER_TYPE = FNSL.SUBLEDGER_TYPE;
                            FNMSL.Tel = FNSL.Tel;
                            FNMSL.UPDATED_BY = FNSL.UserName;
                            FNMSL.Web_site = FNSL.Web_site;
                            FNMSL.Branchcode = FNSL.Branchcode;
                            #endregion

                            _EzBusinessHelper.ExecuteNonQuery("delete from FNM_SL1002 where CmpyCode='" + FNSL.CMPYCODE + "' and FNM_SL1001_CODE='" + FNSL.FNM_SL1001_CODE + "'");
                            
                            #region ObjectList
                            List<FNM_SL1002DetailNew> ObjList = new List<FNM_SL1002DetailNew>();
                            if (FNSL.FNM_SL1002Details != null)
                            {
                                ObjList.AddRange(FNSL.FNM_SL1002Details.Select(m => new FNM_SL1002DetailNew
                                {
                                    CMPYCODE = m.CMPYCODE,
                                    COA_CODE = m.COA_CODE,
                                    DIVISION = m.DIVISION,
                                    FNM_SL1001_CODE = FNSL.FNM_SL1001_CODE,
                                    FNM_SL1002_CODE = m.FNM_SL1002_CODE,
                                    COA_NAME=m.COA_NAME,
                                    NAME = m.NAME
                                }).ToList());
                            }
                            #endregion                                                     
                            StringBuilder sb = new StringBuilder();

                            #region FNM_SL1001
                            sb.Append("Address='" + FNSL.Address + "',");
                            sb.Append("Contact1='" + FNSL.Contact1 + "',");
                            sb.Append("Contact2='" + FNSL.Contact2 + "',");
                            sb.Append("Contact3='" + FNSL.Contact3 + "',");
                            sb.Append("DIVISION='" + FNSL.DIVISION + "',");
                            sb.Append("CREATED_BY='" + FNSL.CREATED_BY + "',");
                            sb.Append("credit_limit='" + FNSL.credit_limit + "',");
                            sb.Append("Currency_code='" + FNSL.Currency_code + "',");                            
                            sb.Append("Email='" + FNSL.Email + "',");
                            sb.Append("Fax='" + FNSL.Fax + "',");                           
                            sb.Append("Name='" + FNSL.Name + "',");
                            sb.Append("Print_Name='" + FNSL.Print_Name + "',");
                            sb.Append("SUBLEDGER_TYPE='" + FNSL.SUBLEDGER_TYPE + "',");
                            sb.Append("Tel='" + FNSL.Tel + "',");
                            sb.Append("UPDATED_BY='" + FNSL.UserName + "',");
                            sb.Append("Web_site='" + FNSL.Web_site + "',");
                            sb.Append("UPDATED_ON='" + dtstr7 + "',");
                            sb.Append("Branchcode='" + FNSL.Branchcode + "',");                            
                            sb.Append("Name_Arabic='" + FNSL.Name_Arabic + "',");
                            sb.Append("CREATED_ON='" + dtstr7 + "'");
                        _EzBusinessHelper.ExecuteNonQuery("update FNM_SL1001 set " + sb + " where Cmpycode='" + FNSL.CMPYCODE + "' and FNM_SL1001_CODE='" + FNSL.FNM_SL1001_CODE + "'");

                            #endregion
                            #region FNMSL002
                            n = ObjList.Count;
                            while (n > 0)
                            {                               
                                sb.Clear();
                                sb.Append("(CMPYCODE,");
                                sb.Append("DIVISION,");
                                sb.Append("FNM_SL1001_CODE,");
                                sb.Append("FNM_SL1002_CODE,");
                                sb.Append("NAME,");
                                sb.Append("COA_NAME,");
                                sb.Append("COA_CODE)");
                                sb.Append(" values(");
                                sb.Append("'" + FNMSL.CMPYCODE + "',");
                                sb.Append("'" + FNSL.DIVISION + "',");
                                sb.Append("'" + FNMSL.FNM_SL1001_CODE + "',");
                                sb.Append("'" + ObjList[n - 1].FNM_SL1002_CODE + "',");
                                sb.Append("'" + ObjList[n - 1].NAME + "',");
                                sb.Append("'" + ObjList[n - 1].COA_NAME + "',");
                                sb.Append("'" + ObjList[n - 1].COA_CODE + "')");
                                _EzBusinessHelper.ExecuteNonQuery("insert into FNM_SL1002" + sb + " ");
                                n = n - 1;
                            }

                            #endregion                                                     
                        }                       
                        FNSL.ErrorMessage = string.Empty;
                        FNSL.SaveFlag = true;                        
                        scope1.Complete();
                    }
                }
                catch (Exception ex)
                {
                    FNSL.ErrorMessage = "Error occur";
                    FNSL.SaveFlag = false;
                }
            }

            return FNSL;
        }

        public List<FNM_SL1002> GetFNM_SL1002Add(string CmpyCode, string FNMCAT_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select d.fnmslcat_code as [FNM SL Code],d.description as [Description],h.FNM_AC_COA_CODE as [CODE],h.name as [COA NAME]  from FNM_AC_COA h inner join FNMSLCAT d on h.SUBLEDGER_CAT=d.FNMSLCAT_CODE and h.Flag=d.Flag where D.Flag=0  and d.CMPYCODE=h.CMPYCODE and d.FNMSLCAT_CODE='" + FNMCAT_CODE + "' and d.CMPYCODE='" + CmpyCode  +"'");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_SL1002> ObjList = new List<FNM_SL1002>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_SL1002()
                {            
                    COA_CODE = dr["CODE"].ToString(),
                    FNM_SL1002_CODE = dr["FNM SL Code"].ToString(),
                    NAME = dr["Description"].ToString(),
                    COA_NAME=dr["COA NAME"].ToString()
                });
            }
            return ObjList;
        }
    }
}
