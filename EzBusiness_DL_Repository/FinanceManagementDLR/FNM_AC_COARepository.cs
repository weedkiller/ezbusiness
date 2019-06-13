using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagement;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
   public class FNM_AC_COARepository:IFNM_AC_COARepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFNM_Ac_COA(string CmpyCode, string FNM_AC_CODE,  string UserName)
        {

            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNM_AC_COA where CMPYCODE='" + CmpyCode + "' and FNM_AC_COA_CODE='" + FNM_AC_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNM_AC_COA", FNM_AC_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNM_AC_COA set Flag=1 where CMPYCODE='" + CmpyCode + "' and FNM_AC_COA_CODE='" + FNM_AC_CODE + "'  and Flag=0");

            }
            return false;
        }

        public List<FNM_AC_COA_VM> GetFNM_AC_COA(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNM_AC_COA where CMPYCODE='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_AC_COA_VM> ObjList = new List<FNM_AC_COA_VM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_AC_COA_VM()
                {
                    COMPANY_UID = dr["CMPYCODE"].ToString(),
                    CODE = dr["FNM_AC_COA_CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),
                    Head_code = dr["Head_code"].ToString(),
                    group_code = dr["group_code"].ToString(),
                    SUBGROUP_code = dr["SUBGROUP_code"].ToString(),
                    COA_TYPE = dr["COA_TYPE"].ToString(),
                    SUBLEDGER_TYPE = dr["SUBLEDGER_TYPE"].ToString(),
                    MASTER_STATUS = dr["MASTER_STATUS"].ToString(),
                    NOTE = dr["NOTE"].ToString(),
                    NATURE = dr["NATURE"].ToString(),
                    PL_BS = dr["PL_BS"].ToString()
                });
            }
            return ObjList;
        }

        public FNM_AC_COA_VM SaveFNM_AC_COA(FNM_AC_COA_VM ac)
        {
            try
            {

                DateTime dte;
                string dtstr1;
                dte = Convert.ToDateTime(DateTime.Now.ToString());
                dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

                if (!ac.EditFlag)
                {
                    //var Drecord = new List<string>();
                    //FNM_AC_COA_VM ObjList = new FNM_AC_COA_VM();
                   
                    //    CMPYCODE = m.CMPYCODE,
                    //    FNMBRANCH_CODE = m.FNMBRANCH_CODE,
                    //    DESCRIPTION = m.DESCRIPTION,
                    //    SNO = m.SNO,
                    //    PRINTNAME = m.PRINTNAME,
                    //    ADDRESS = m.ADDRESS,
                    //    EMAIL = m.EMAIL,
                    //    WEBSITE = m.WEBSITE,
                    //    MOBILE = m.MOBILE,
                    //    CURRENCY = m.CURRENCY,
                    //    COUNTRY = m.COUNTRY,
                    //    STATE = m.STATE
                   
                    //int n = 0;
                   // n = ObjList.Count;


                    int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNM_AC_COA where CMPYCODE='" + ac.COMPANY_UID + "' and FNM_AC_COA_CODE='" + ac.CODE + "'");
                    if (Stats1 == 0)
                    {
                        StringBuilder sb = new StringBuilder();

                      
                        sb.Append("'" + ac.COMPANY_UID + "',");                      
                        sb.Append("'" + ac.CODE + "',");
                        sb.Append("'" + ac.NAME + "',");
                        sb.Append("'" + ac.Head_code + "',");
                        sb.Append("'" + ac.group_code + "',");
                        sb.Append("'" + ac.SUBGROUP_code + "',");
                        sb.Append("'" + ac.UserName + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + ac.UserName + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + ac.COA_TYPE + "',");
                        sb.Append("'" + ac.SUBLEDGER_TYPE + "',");
                        sb.Append("'"+ ac.SUBLEDGER_CAT + "',");
                        sb.Append("'" + ac.MASTER_STATUS + "',");
                        sb.Append("'" + ac.NOTE + "',");
                        sb.Append("'" + ac.NATURE + "',");
                        sb.Append("'" + ac.Name_Arabic + "',");
                        sb.Append("'" + ac.PL_BS + "')");
                        _EzBusinessHelper.ExecuteNonQuery("insert into FNM_AC_COA(CMPYCODE,FNM_AC_COA_CODE,NAME,Head_Code,group_code,SUBGROUP_code,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,COA_TYPE,SUBLEDGER_TYPE,SUBLEDGER_CAT,MASTER_STATUS,NOTE,NATURE,Name_Arabic,PL_BS) values(" + sb.ToString() + "");
                        _EzBusinessHelper.ActivityLog(ac.COMPANY_UID, ac.UserName, "Add FNM_AC_COA", ac.CODE, Environment.MachineName);
                        ac.SaveFlag = true;
                        ac.ErrorMessage = string.Empty;
                    }
                    else
                    {

                        //Drecord.Add(branch.FNMBRANCH_CODE.ToString());
                        //  branch.Drecord = Drecord;
                        ac.SaveFlag = false;
                        ac.ErrorMessage = "Duplicate Record";
                    }
                    return ac;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FNM_AC_COA where CMPYCODE='" + ac.COMPANY_UID + "' and FNM_AC_COA_CODE='" + ac.CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();
                                        
                    //  sb.Append("'" + dtstr8 + "',");
                    sb.Append("NAME='" + ac.NAME + "',");
                    sb.Append("Head_Code='" + ac.Head_code + "',");
                    sb.Append("group_code='" + ac.group_code + "',");
                    sb.Append("SUBGROUP_code='" + ac.SUBGROUP_code + "',");
                    sb.Append("UPDATED_BY='" + ac.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "',");
                    sb.Append("COA_TYPE='" + ac.COA_TYPE + "',");
                    sb.Append("SUBLEDGER_TYPE='" + ac.SUBLEDGER_TYPE + "',");
                    sb.Append("SUBLEDGER_CAT='" + ac.SUBLEDGER_CAT + "',");
                    sb.Append("NOTE='" + ac.NOTE + "',");
                    sb.Append("NATURE='" + ac.NATURE + "',");
                    sb.Append("Name_Arabic='" + ac.Name_Arabic + "',");
                    sb.Append("PL_BS='" + ac.PL_BS + "'");
                    _EzBusinessHelper.ExecuteNonQuery("update FNM_AC_COA set  " + sb + " where CMPYCODE='" + ac.COMPANY_UID + "' and  FNM_AC_COA_CODE='" + ac.CODE + "' and Flag=0");
                    _EzBusinessHelper.ActivityLog(ac.COMPANY_UID, ac.UserName, "Update FNM_AC_COA", ac.CODE, Environment.MachineName);
                    ac.SaveFlag = true;
                    ac.ErrorMessage = string.Empty;
                }
                else
                {
                    ac.SaveFlag = false;
                    ac.ErrorMessage = "Record not available";
                }
            }
            catch (Exception ex)
            {
                ac.SaveFlag = false;

            }

            return ac;
        }

        public FNM_AC_COA_VM EditFNM_AC_COA(string CmpyCode, string Code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select CMPYCODE,FNM_AC_COA_CODE,NAME,Head_code,group_code,SUBGROUP_code,COA_TYPE,SUBLEDGER_TYPE,SUBLEDGER_CAT,MASTER_STATUS,NOTE,NATURE,Name_Arabic,PL_BS from FNM_AC_COA where CMPYCODE='" + CmpyCode + "' and FNM_AC_COA_CODE='" + Code + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FNM_AC_COA_VM ObjList = new FNM_AC_COA_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.COMPANY_UID = dr["CMPYCODE"].ToString();               
                ObjList.CODE = dr["FNM_AC_COA_CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
                ObjList.Head_code = dr["Head_code"].ToString();
                ObjList.group_code = dr["group_code"].ToString();
                ObjList.SUBGROUP_code = dr["SUBGROUP_code"].ToString();
                ObjList.COA_TYPE = dr["COA_TYPE"].ToString();
                ObjList.SUBLEDGER_TYPE = dr["SUBLEDGER_TYPE"].ToString();
                ObjList.SUBLEDGER_CAT = dr["SUBLEDGER_CAT"].ToString();
                ObjList.MASTER_STATUS = dr["MASTER_STATUS"].ToString();
                ObjList.NOTE = dr["NOTE"].ToString();
                ObjList.NATURE = dr["NATURE"].ToString();
                ObjList.Name_Arabic = dr["Name_Arabic"].ToString();
                ObjList.PL_BS = dr["PL_BS"].ToString();
            }
            return ObjList;
        }

        public List<FMHEAD> GetFMHEAD(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMHEAD_CODE,DESCRIPTION from FNMHEAD where CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FMHEAD> ObjList = new List<FMHEAD>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FMHEAD()
                {
                    FNMHEAD_CODE = dr["FNMHEAD_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString()
                });
            }
            return ObjList;
        }

        public List<FNMGROUP> Getgroup_code(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMGROUP_CODE,DESCRIPTION from FNMGROUP where CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMGROUP> ObjList = new List<FNMGROUP>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMGROUP()
                {                   
                    FNMGROUP_CODE = dr["FNMGROUP_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString()
                });
            }
            return ObjList;
        }

        public List<FNMSUBGROUP> GetSUBGROUP(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMSUBGROUP_CODE,DESCRIPTION from FNMSUBGROUP where CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMSUBGROUP> ObjList = new List<FNMSUBGROUP>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMSUBGROUP()
                {
                    FNMSUBGROUP_CODE = dr["FNMSUBGROUP_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString()
                });
            }
            return ObjList;
        }

        public List<FNMTYPE> GetCOA_TYPEList(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMTYPE_CODE,DESCRIPTION from FNMTYPE where CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMTYPE> ObjList = new List<FNMTYPE>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMTYPE()
                {
                    FNMTYPE_CODE = dr["FNMTYPE_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString()
                });
            }
            return ObjList;
        }

        public List<FNMSUBGROUP> GetFNMSUBGROUP(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMSUBGROUP_CODE,DESCRIPTION from FNMSUBGROUP where CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMSUBGROUP> ObjList = new List<FNMSUBGROUP>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMSUBGROUP()
                {
                    FNMSUBGROUP_CODE = dr["FNMSUBGROUP_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString()
                });
            }
            return ObjList;
        }

        public List<FNMCAT> GetSUBLEDGER_CAT(string Cmpycode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMSLCAT_CODE,DESCRIPTION from FNMSLCAT where CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMCAT> ObjList = new List<FNMCAT>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMCAT()
                {
                    FNMSLCAT_CODE = dr["FNMSLCAT_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString()
                });
            }
            return ObjList;
        }
    }
}
