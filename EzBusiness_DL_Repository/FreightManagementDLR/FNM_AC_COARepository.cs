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

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
   public class FNM_AC_COARepository:IFNM_AC_COARepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFNM_Ac_COA(string FNM_AC_CODE, string CmpyCode, string UserName)
        {

            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNM_AC_COA where COMPANY_UID='" + CmpyCode + "' and CODE='" + FNM_AC_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNM_AC_COA", FNM_AC_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNM_AC_COA set Flag=1 where COMPANY_UID='" + CmpyCode + "' and CODE='" + FNM_AC_CODE + "'  and Flag=0");

            }
            return false;
        }

        public List<FNM_AC_COA> GetFNM_AC_COA(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNM_AC_COA where COMPANY_UID='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_AC_COA> ObjList = new List<FNM_AC_COA>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_AC_COA()
                {
                    COMPANY_UID = dr["COMPANY_UID"].ToString(),
                    CODE = dr["CODE"].ToString(),
                    FNM_AC_COAId =Convert.ToDecimal( dr["DESCRIPTION"].ToString()),
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

        public FNM_AC_COA_VM SaveFNMBranch(FNM_AC_COA_VM ac)
        {
            try
            {
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


                    int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNM_AC_COA where COMPANY_UID='" + ac.COMPANY_UID + "' and CODE='" + ac.CODE + "'");
                    if (Stats1 == 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.Append("'" + ac.COMPANY_UID + "',");
                        sb.Append("'" + ac.FNM_AC_COA + "',");
                        sb.Append("'" + ac.CODE + "',");
                        sb.Append("'" + ac.NAME + "',");
                        sb.Append("'" + ac.Head_code + "',");
                        sb.Append("'" + ac.group_code + "',");
                        sb.Append("'" + ac.SUBGROUP_code + "',");
                        sb.Append("'" + ac.CREATED_BY + "',");
                        sb.Append("'" + ac.CREATED_ON + "',");
                        sb.Append("'" + ac.UPDATED_BY + "',");
                        sb.Append("'" + ac.UPDATED_ON + "',");
                        sb.Append("'" + ac.COA_TYPE + "',");
                        sb.Append("'" + ac.SUBLEDGER_TYPE + "',");
                        sb.Append("'" + ac.MASTER_STATUS + "',");
                        sb.Append("'" + ac.NOTE + "',");
                        sb.Append("'" + ac.NATURE + "',");
                        sb.Append("'" + ac.PL_BS + "')");
                        _EzBusinessHelper.ExecuteNonQuery("insert into FNM_AC_COA(company_UID,FNM_AC_COA,CODE,NAME,Head_Code,group_code,SUBGROUP_code,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,COA_TYPE,SUBLEDGER_TYPE,MASTER_STATUS,NOTE,NATURE,PL_BS) values(" + sb.ToString() + "");
                        _EzBusinessHelper.ActivityLog(ac.COMPANY_UID, ac.UserName, "Add FN Category", ac.CODE, Environment.MachineName);
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
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FNM_AC_COA where COMPANY_UID='" + ac.COMPANY_UID + "' and CODE='" + ac.CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("company_UID='" + ac.COMPANY_UID + "',");
                    sb.Append("FNM_AC_COA='" + ac.FNM_AC_COA + "',");
                    sb.Append("CODE='" + ac.CODE + "',");
                    //  sb.Append("'" + dtstr8 + "',");
                    sb.Append("NAME='" + ac.NAME + "',");
                    sb.Append("Head_Code='" + ac.Head_code + "',");
                    sb.Append("group_code='" + ac.group_code + "',");
                    sb.Append("SUBGROUP_code='" + ac.SUBGROUP_code + "',");
                    sb.Append("CREATED_BY='" + ac.CREATED_BY + "',");
                    sb.Append("CREATED_ON='" + ac.CREATED_ON + "',");
                    sb.Append("UPDATED_BY='" + ac.UPDATED_BY + "',");
                    sb.Append("UPDATED_ON='" + ac.UPDATED_ON + "'");
                    sb.Append("COA_TYPE='" + ac.COA_TYPE + "'");
                    sb.Append("SUBLEDGER_TYPE='" + ac.SUBLEDGER_TYPE + "'");
                    sb.Append("NOTE='" + ac.NOTE + "'");
                    sb.Append("NATURE='" + ac.NATURE + "'");
                    sb.Append("PL_BS='" + ac.PL_BS + "'");
                    _EzBusinessHelper.ExecuteNonQuery("update FNM_AC_COA set  " + sb + " where COMPANY_UID='" + ac.COMPANY_UID + "' and  CODE='" + ac.CODE + "' and Flag=0");
                    _EzBusinessHelper.ActivityLog(ac.COMPANY_UID, ac.UserName, "Update FNMBranch", ac.CODE, Environment.MachineName);

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

        public FNM_AC_COA_VM EditFNMBranch(string CmpyCode, string BranchCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMBRANCH_CODE,CMPYCODE,DESCRIPTION,SNO,PRINTNAME,ADDRESS,EMAIL,WEBSITE,MOBILE,CURRENCY,COUNTRY,STATE from FNMBRANCH where CMPYCODE='" + CmpyCode + "' and FNMBRANCH_CODE='" + BranchCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FNM_AC_COA_VM ObjList = new FNM_AC_COA_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.COMPANY_UID = dr["COMPANY_UID"].ToString();
                ObjList.FNM_AC_COA =Convert.ToDecimal( dr["FNM_AC_COA"].ToString());
                ObjList.CODE = dr["CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
                ObjList.Head_code = dr["Head_code"].ToString();
                ObjList.group_code = dr["group_code"].ToString();
                ObjList.SUBGROUP_code = dr["SUBGROUP_code"].ToString();
                ObjList.COA_TYPE = dr["COA_TYPE"].ToString();
                ObjList.SUBLEDGER_TYPE = dr["SUBLEDGER_TYPE"].ToString();
                ObjList.MASTER_STATUS = dr["MASTER_STATUS"].ToString();
                ObjList.NOTE = dr["NOTE"].ToString();
                ObjList.NATURE = dr["NATURE"].ToString();
                ObjList.PL_BS = dr["PL_BS"].ToString();
            }
            return ObjList;
        }
    }
}
