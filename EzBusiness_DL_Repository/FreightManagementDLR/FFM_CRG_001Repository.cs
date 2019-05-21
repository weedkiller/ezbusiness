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

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
    public class FFM_CRG_001Repository : IFFM_CRG_001Repository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_CRG_001(string FFM_CRG_001_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_CRG_001 where CmpyCode='" + CmpyCode + "' and FFM_CRG_001_CODE='" + FFM_CRG_001_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_CRG_001", FFM_CRG_001_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_JOB set Flag=1 where CmpyCode='" + CmpyCode + "' and FFM_CRG_001_CODE='" + FFM_CRG_001_CODE + "'  and Flag=0");

            }
            return false;
        }

        public FFM_CRG_001_VM EditFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_CRG_001_CODE,NAME,FFM_CRG_GROUP_CODE,DISPLAY_STATUS from FFM_CRG_001 where CMPYCODE='" + CmpyCode + "' and FFM_CRG_001_CODE='" + FFM_CRG_001_CODE + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FFM_CRG_001_VM ObjList = new FFM_CRG_001_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.CMPYCODE = dr["CMPYCODE"].ToString();
                ObjList.FFM_CRG_001_CODE = dr["FFM_CRG_001_CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
                ObjList.FFM_CRG_GROUP_CODE = dr["FFM_CRG_GROUP_CODE"].ToString();
                ObjList.DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString();
                
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

        public List<FFM_CRG_001> GetFFM_CRG_001(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_CRG_001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_CRG_001> ObjList = new List<FFM_CRG_001>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_CRG_001()
                {
                    CREATED_BY = dr["CREATED_BY"].ToString(),
                    CREATED_ON = Convert.ToDateTime(dr["CREATED_ON"].ToString()),
                    UPDATED_BY = dr["UPDATED_BY"].ToString(),
                    UPDATED_ON = Convert.ToDateTime(dr["UPDATED_ON"].ToString()),
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FFM_CRG_001_CODE = dr["FFM_CRG_001_CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),
                    FFM_CRG_GROUP_CODE = dr["FFM_CRG_GROUP_CODE"].ToString(),
                    DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString()
                });
            }
            return ObjList;
        }

        public FFM_CRG_001_VM SaveFM_CRG_001(FFM_CRG_001_VM CR)
        {
            DateTime dte;
            string dtstr1;
            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            try
            {
                if (!CR.EditFlag)
                {
                   
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_CRG_001 where CmpyCode='" + CR.CMPYCODE + "' and FFM_CRG_001_CODE='" + CR.FFM_CRG_001_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + CR.CMPYCODE + "',");
                            sb.Append("'" + CR.FFM_CRG_001_CODE + "',");
                            sb.Append("'" + CR.NAME + "',");
                            sb.Append("'" + CR.UserName + "',");
                            sb.Append("'" + dtstr1 + "',");
                            sb.Append("'" + CR.UserName + "',");
                            sb.Append("'" + dtstr1 + "',");
                            sb.Append("'" + CR.DISPLAY_STATUS + "',");
                            sb.Append("'" + CR.FFM_CRG_GROUP_CODE + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into FFM_CRG_001(CMPYCODE,FFM_CRG_001_CODE,NAME,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,DISPLAY_STATUS,FFM_CRG_GROUP_CODE) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(CR.CMPYCODE, CR.UserName, "Add FN Category", CR.FFM_CRG_001_CODE, Environment.MachineName);

                            CR.SaveFlag = true;
                            CR.ErrorMessage = string.Empty;
                        }
                        else
                        {

                           
                            CR.SaveFlag = false;
                            CR.ErrorMessage = "Duplicate Record";
                        }
                      
                    return CR;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_CRG_001 where CmpyCode='" + CR.CMPYCODE + "' and FFM_CRG_001_CODE='" + CR.FFM_CRG_001_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();


                    sb.Append("CMPYCODE='" + CR.CMPYCODE + "',");
                    sb.Append("FFM_CRG_001_CODE='" + CR.FFM_CRG_001_CODE + "',");
                    sb.Append("NAME='" + CR.NAME + "',");
                    sb.Append("CREATED_BY='" + CR.UserName + "',");
                    sb.Append("CREATED_ON='" + dtstr1 + "',");
                    sb.Append("UPDATED_BY='" + CR.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "',");
                    sb.Append("DISPLAY_STATUS='" + CR.DISPLAY_STATUS + "'");
                    sb.Append("FFM_CRG_GROUP_CODE='" + CR.FFM_CRG_GROUP_CODE + "'");
                    _EzBusinessHelper.ExecuteNonQuery("update FFM_CRG_001 set  " + sb + " where FFM_CRG_001_CODE='" + CR.FFM_CRG_001_CODE + "' and Flag=0");

                    _EzBusinessHelper.ActivityLog(CR.CMPYCODE, CR.UserName, "Update FMHead", CR.FFM_CRG_001_CODE, Environment.MachineName);

                    CR.SaveFlag = true;
                    CR.ErrorMessage = string.Empty;
                }
                else
                {
                    CR.SaveFlag = false;
                    CR.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                CR.SaveFlag = false;


            }

            return CR;
        }
    
    }
}
