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
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Transactions;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
    public class FFM_CRG_001Repository : IFFM_CRG_001Repository
    {
        DataSet ds = null;
        DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE,  string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_CRG_001 where CmpyCode='" + CmpyCode + "' and FFM_CRG_001_CODE='" + FFM_CRG_001_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete Charge master", FFM_CRG_001_CODE, Environment.MachineName);

                 _EzBusinessHelper.ExecuteNonQuery1("update FFM_CRG_001 set Flag=1 where CmpyCode='" + CmpyCode + "' and FFM_CRG_001_CODE='" + FFM_CRG_001_CODE + "'  and Flag=0");
                 _EzBusinessHelper.ExecuteNonQuery1("update FFM_CRG_002 set Flag=1 where CmpyCode='" + CmpyCode + "' and FFM_CRG_001_CODE='" + FFM_CRG_001_CODE + "'  and Flag=0");
                return true;
            } 
            return false;
        }

        public FFM_CRG_VM EditFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_CRG_001_CODE,NAME,FFM_CRG_GROUP_CODE,DISPLAY_STATUS,Name_Arabic from FFM_CRG_001 where CMPYCODE='" + CmpyCode + "' and FFM_CRG_001_CODE='" + FFM_CRG_001_CODE + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FFM_CRG_VM ObjList = new FFM_CRG_VM();
            foreach (DataRow dr in drc)
            {

                //ObjList.CMPYCODE = dr["CMPYCODE"].ToString();
                ObjList.FFM_CRG_001_CODE = dr["FFM_CRG_001_CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
                ObjList.FFM_CRG_GROUP_CODE = dr["FFM_CRG_GROUP_CODE"].ToString();
                ObjList.DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString();
                ObjList.Name_Arabic = dr["Name_Arabic"].ToString();
            }
            return ObjList;
        }

        public List<FFM_CRG_Group> GetCRG_Group(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_CRG_GROUP_CODE,NAME from  FFM_CRG_GROUP where CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_CRG_Group> ObjList = new List<FFM_CRG_Group>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_CRG_Group()
                {
                    FFM_CRG_GROUP_CODE = dr["FFM_CRG_GROUP_CODE"].ToString(),
                    NAME = dr["NAME"].ToString()
                });
            }
            return ObjList;
        }

        public List<FFM_CRG> GetFFM_CRG_001(string CmpyCode)
        {
            List<FFM_CRG> ObjList = null;
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_CRG_001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<FFM_CRG>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new FFM_CRG()
                    {
                        CREATED_BY = dr["CREATED_BY"].ToString(),
                        CREATED_ON = Convert.ToDateTime(dr["CREATED_ON"].ToString()),
                        UPDATED_BY = dr["UPDATED_BY"].ToString(),
                        UPDATED_ON = Convert.ToDateTime(dr["UPDATED_ON"].ToString()),
                        CMPYCODE = dr["CmpyCode"].ToString(),
                        FFM_CRG_001_CODE = dr["FFM_CRG_001_CODE"].ToString(),
                        NAME = dr["NAME"].ToString(),
                        FFM_CRG_GROUP_CODE = dr["FFM_CRG_GROUP_CODE"].ToString(),
                        DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString(),
                        Name_Arabic = dr["Name_Arabic"].ToString()
                    });
                }
            }
            return ObjList;
        }

        public FFM_CRG_VM SaveFM_CRG_001(FFM_CRG_VM FCur)
         {           
            DateTime dte, ETA1, ETB1, ETD1;
            string dtstr1, ETA2, ETB2, ETD2; ;
            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            if (!FCur.EditFlag)
            {
                try
                {
                    var Drecord = new List<string>();
                    List<FFM_CRG> ObjList = new List<FFM_CRG>();
                    if (FCur.crgnewDetails != null)
                    {
                        ObjList.AddRange(FCur.crgnewDetails.Select(m => new FFM_CRG
                        {
                            CMPYCODE = m.CMPYCODE,
                            SNO = m.SNO,
                            FFM_CRG_001_CODE = m.FFM_CRG_001_CODE,
                            FFM_CRG_JOB_CODE = m.FFM_CRG_JOB_CODE,
                            FFM_CRG_JOB_NAME = m.FFM_CRG_JOB_NAME,
                            OPERATION_TYPE = m.OPERATION_TYPE,
                            DISPLAY_STATUS = m.DISPLAY_STATUS,
                            INCOME_ACT = m.INCOME_ACT,
                            EXPENSE_ACGT = m.EXPENSE_ACGT,
                          //  Name_Arabic=m.Arabic_Name,
                        }).ToList());
                    }
                  
                    int n, i = 0;
                    n = ObjList.Count;
                    while (n > 0)
                    {
                        //ETA1 = Convert.ToDateTime(ObjList[n - 1].ETA);
                        //ETA2 = ETA1.ToString("yyyy-MM-dd hh:mm:ss tt");
                        //ETB1 = Convert.ToDateTime(ObjList[n - 1].ETB);
                        //ETB2 = ETB1.ToString("yyyy-MM-dd hh:mm:ss tt");
                        //ETD1 = Convert.ToDateTime(ObjList[n - 1].ETD);
                        //ETD2 = ETD1.ToString("yyyy-MM-dd hh:mm:ss tt");
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FFM_CRG_002 where FFM_CRG_001_CODE='" + ObjList[n - 1].FFM_CRG_001_CODE + "' and  CmpyCode='" + ObjList[n - 1].CMPYCODE + "' and flag=0");// CmpyCode='" + FCur.CMPYCODE + "' and
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.Append("'" + FCur.FFM_CRG_001_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].SNO + "',");
                            sb.Append("'" + ObjList[n - 1].FFM_CRG_JOB_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].FFM_CRG_JOB_NAME + "',");
                            sb.Append("'" + ObjList[n - 1].OPERATION_TYPE + "',");
                            sb.Append("'" + ObjList[n - 1].INCOME_ACT + "',");
                            sb.Append("'" + ObjList[n - 1].EXPENSE_ACGT + "',");                          
                            sb.Append("'" + FCur.DISPLAY_STATUS + "',");
                          //  sb.Append("'" + ObjList[n - 1].Name_Arabic + "',");
                            sb.Append("'" + FCur.CMPYCODE + "')");                        
                            i = _EzBusinessHelper.ExecuteNonQuery("insert into FFM_CRG_002(FFM_CRG_001_CODE,SNO,FFM_CRG_JOB_CODE,FFM_CRG_JOB_NAME,OPERATION_TYPE,INCOME_ACT,EXPENSE_ACT,DISPLAY_STATUS,cmpycode) values(" + sb.ToString() + "");
                            _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Add FFM Charge", ObjList[n - 1].FFM_CRG_001_CODE, Environment.MachineName);
                        }
                        else
                        {
                            Drecord.Add(FCur.FFM_CRG_001_CODE.ToString());
                            //branch.Drecord = Drecord;
                            FCur.SaveFlag = false;
                            FCur.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    if (i > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.Append("'" + FCur.UserName + "',");

                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + FCur.UserName + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + FCur.FFM_CRG_001_CODE + "',");
                        sb.Append("'" + FCur.CMPYCODE + "',");
                        sb.Append("'" + FCur.FFM_CRG_GROUP_CODE + "',");
                        sb.Append("'" + FCur.NAME + "',");
                        sb.Append("'" + FCur.Name_Arabic + "',");
                        sb.Append("'" + FCur.DISPLAY_STATUS + "')");
                        i = _EzBusinessHelper.ExecuteNonQuery("insert into FFM_CRG_001(created_by,created_On,UPdated_By,Updated_ON,FFM_CRG_001_CODE,CMPYCODE,FFM_CRG_GROUP_CODE,NAME,Name_Arabic,Display_Status) values(" + sb.ToString() + "");
                        FCur.SaveFlag = true;
                        FCur.ErrorMessage = string.Empty;
                    }else
                    {
                        FCur.ErrorMessage = "Enter atleast one Record on Grid";
                    }
                    return FCur;

                }
                catch (Exception ex)
                {
                    FCur.SaveFlag = false;
                }
            }
            else
            {
                try
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_CRG_001 where CmpyCode='" + FCur.CMPYCODE + "' and FFM_CRG_001_CODE='" + FCur.FFM_CRG_001_CODE + "'");
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        FFM_CRG Emp = new FFM_CRG();
                        dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {

                            Emp.FFM_CRG_001_CODE = FCur.FFM_CRG_001_CODE;
                            Emp.FFM_CRG_GROUP_CODE = FCur.FFM_CRG_GROUP_CODE;
                            Emp.NAME = FCur.NAME;
                            Emp.DISPLAY_STATUS = FCur.DISPLAY_STATUS;

                            _EzBusinessHelper.ExecuteNonQuery("delete from FFM_CRG_002 where CmpyCode='" + FCur.CMPYCODE + "' and FFM_CRG_001_CODE='" + FCur.FFM_CRG_001_CODE + "'");

                            // #region ObjectList
                            List<FFM_CRG> ObjList = new List<FFM_CRG>();
                            if (FCur.crgnewDetails != null)
                            {

                                ObjList.AddRange(FCur.crgnewDetails.Select(m => new FFM_CRG
                                {
                                    CMPYCODE = m.CMPYCODE,
                                    SNO = m.SNO,
                                    FFM_CRG_001_CODE = m.FFM_CRG_001_CODE,
                                    FFM_CRG_JOB_CODE = m.FFM_CRG_JOB_CODE,
                                    FFM_CRG_JOB_NAME = m.FFM_CRG_JOB_NAME,
                                    OPERATION_TYPE = m.OPERATION_TYPE,
                                    DISPLAY_STATUS = m.DISPLAY_STATUS,
                                    INCOME_ACT = m.INCOME_ACT,
                                    EXPENSE_ACGT = m.EXPENSE_ACGT,
                                  

                                }).ToList());
                            }

                            int n, i = 0;
                            n = ObjList.Count;
                            while (n > 0)
                            {


                                StringBuilder sb1 = new StringBuilder();

                                sb1.Append("'" + FCur.FFM_CRG_001_CODE + "',");
                                sb1.Append("'" + ObjList[n - 1].SNO + "',");
                                sb1.Append("'" + ObjList[n - 1].FFM_CRG_JOB_CODE + "',");
                                sb1.Append("'" + ObjList[n - 1].FFM_CRG_JOB_NAME + "',");
                                sb1.Append("'" + ObjList[n - 1].OPERATION_TYPE + "',");
                                sb1.Append("'" + ObjList[n - 1].INCOME_ACT + "',");
                                sb1.Append("'" + ObjList[n - 1].EXPENSE_ACGT + "',");
                               // sb1.Append("'" + ObjList[n - 1].Name_Arabic + "',");
                                sb1.Append("'" + FCur.DISPLAY_STATUS + "',");
                                sb1.Append("'" + FCur.CMPYCODE + "')");
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FFM_CRG_002(FFM_CRG_001_CODE,SNO,FFM_CRG_JOB_CODE,FFM_CRG_JOB_NAME,OPERATION_TYPE,INCOME_ACT,EXPENSE_ACT,DISPLAY_STATUS,cmpycode) values(" + sb1.ToString() + "");
                                //_EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Add FFM Voyage", ObjList[n - 1].FFM_VOYAGE01_CODE, Environment.MachineName);

                                // _EzBusinessHelper.ExecuteNonQuery("insert into FFM_VOYAGE02(ffm_VOYAGE01_CODE,SNO,ROTATION,PORT,ETA,ETB,ETD,PORT_STAY_HRS,SAILING_HRS,DISPLAY_STATUS,cmpycode) values(" + sb1.ToString() + "");
                                n = n - 1;
                            }
                            if (i > 0)
                            {
                                StringBuilder sb = new StringBuilder();

                                sb.Append("FFM_CRG_001_CODE='" + FCur.FFM_CRG_001_CODE + "',");
                                sb.Append("CMPYCODE='" + FCur.CMPYCODE + "',");
                                sb.Append("FFM_CRG_GROUP_CODE='" + FCur.FFM_CRG_GROUP_CODE + "',");
                                sb.Append("DISPLAY_STATUS='" + FCur.DISPLAY_STATUS + "',");
                                sb.Append("NAME='" + FCur.NAME + "',");
                                sb.Append("UPDATED_BY='" + FCur.UserName + "',");                            
                                sb.Append("UPDATED_ON='" + dtstr1 + "',");
                                sb.Append("Name_Arabic='" + FCur.Name_Arabic + "'");
                                _EzBusinessHelper.ExecuteNonQuery("update FFM_CRG_001 set  " + sb + " where  FFM_CRG_001_CODE='" + FCur.FFM_CRG_001_CODE + "' and  cmpycode='" + FCur.CMPYCODE + "' and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and                         
                                _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Update FFM CRG", FCur.FFM_CRG_001_CODE, Environment.MachineName);
                            }
                            else
                            {
                                FCur.ErrorMessage = "Enter atleast one Record on Grid";
                            }// _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Add FFM Voyage", ObjList[n - 1].FFM_VOYAGE01_CODE, Environment.MachineName);
                           
                            
                        }
                       
                        FCur.ErrorMessage = string.Empty;
                        FCur.SaveFlag = true;
                        scope1.Complete();
                    }

                }
                catch (Exception ex)
                {

                    FCur.ErrorMessage = "Error occur";
                    FCur.SaveFlag = false;

                }


            }

            return FCur;
        
    }

        public List<FFM_CRG_Details> GetCRGDetailList(string CmpyCode, string CRGCode)
        {
            List<FFM_CRG_Details> ObjList = null;
            ds = _EzBusinessHelper.ExecuteDataSet("select SNO,FFM_CRG_JOB_CODE,FFM_CRG_001_CODE,FFM_CRG_JOB_NAME,OPERATION_TYPE,INCOME_ACT,EXPENSE_ACT,name_arabic from FFM_CRG_002 where cmpycode='" + CmpyCode + "' and FFM_CRG_001_CODE='" + CRGCode + "' and Flag=0");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                   ObjList = new List<FFM_CRG_Details>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new FFM_CRG_Details()
                    {
                        SNO = Convert.ToInt32(dr["SNO"].ToString()),
                        FFM_CRG_JOB_CODE = dr["FFM_CRG_JOB_CODE"].ToString(),
                        FFM_CRG_JOB_NAME = dr["FFM_CRG_JOB_NAME"].ToString(),
                        OPERATION_TYPE = dr["OPERATION_TYPE"].ToString(),
                        INCOME_ACT = dr["INCOME_ACT"].ToString(),
                        EXPENSE_ACGT = dr["EXPENSE_ACT"].ToString(),
                        FFM_CRG_001_CODE = dr["FFM_CRG_001_CODE"].ToString(),
                        // SailingHrs = Convert.ToInt32(dr["SAILING_HRS"].ToString()),
                      //  Arabic_Name = dr["name_arabic"].ToString(),
                    });

                }
            }
            return ObjList;
        }

        public List<FFM_JOB> GetJobCode(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_JOB_CODE,NAME from  FFM_JOB where CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_JOB> ObjList = new List<FFM_JOB>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_JOB()
                {
                    FFM_JOB_CODE = dr["FFM_JOB_CODE"].ToString(),
                    NAME = dr["NAME"].ToString()
                });
            }
            return ObjList;
        }

        public List<FNM_AC_COA> GetIncomeAct(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select FNM_AC_COA_CODE,NAME from  FNM_AC_COA where SUBLEDGER_TYPE='ENTRY' and  CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_AC_COA> ObjList = new List<FNM_AC_COA>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_AC_COA()
                {
                    CODE = dr["FNM_AC_COA_CODE"].ToString(),
                    NAME = dr["NAME"].ToString()
                });
            }
            return ObjList;
        }
    }
}
