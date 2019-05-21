using EzBusiness_DL_Interface.FreightManagementDLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Data;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
    public class FFM_CRG_002Repository : IFFM_CRG_002Repository
    {
        DataSet ds = null;
        DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_CRG_002(string FFM_CRG_JOB_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_CRG_002 where CMPYCODE='" + CmpyCode + "' and FFM_CRG_JOB_CODE='" + FFM_CRG_JOB_CODE + "'  Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_CRG_002", FFM_CRG_JOB_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_CRG_002 set Flag=1 where CMPYCODE='" + CmpyCode + "' and FFM_CRG_JOB_CODE='" + FFM_CRG_JOB_CODE + "'   and Flag=0");

            }
            return false;
        }

        public FFM_CRG_002_VM EditFFM_CRG_002(string CmpyCode, string FFM_CRG_JOB_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_CRG_002 where CMPYCODE='" + CmpyCode + "' and FFM_CRG_JOB_CODE='" + FFM_CRG_JOB_CODE + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FFM_CRG_002_VM ObjList = new FFM_CRG_002_VM();
            foreach (DataRow dr in drc)
            {


                ObjList.DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString();
                ObjList.FFM_CRG_JOB_CODE = dr["FFM_CRG_JOB_CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
                ObjList.INCOME_ACT = dr["INCOME_ACT"].ToString();
                ObjList.EXPENSE_ACGT = dr["EXPENSE_ACGT"].ToString();


            }
            return ObjList;
        }

        public List<FFM_CRG_002_VM> GetFFM_CRG_002(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_CRG_002 where CMPYCODE='" + CmpyCode + "'  and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            //    FFM_CRG_Group_VM ObjList = new FFM_CRG_Group_VM();

            List<FFM_CRG_002_VM> ObjList = new List<FFM_CRG_002_VM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_CRG_002_VM()
                {
                    CMPYCODE = dr["CMPYCODE"].ToString(),
                    //FFM_CRG_001_CODE = dr["FFM_CRG_001_CODE"].ToString(),
                    FFM_CRG_JOB_CODE = dr["FFM_CRG_JOB_CODE"].ToString(),
                    DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString(),
                    NAME = dr["NAME"].ToString(),
                    INCOME_ACT = dr["INCOME_ACT"].ToString(),
                    EXPENSE_ACGT = dr["EXPENSE_ACGT"].ToString(),

            });
            }
            return ObjList;
        }

        public FFM_CRG_002_VM SaveFFM_CRG_002(FFM_CRG_002_VM ac)
        {
            try
            {
                if (!ac.EditFlag)
                {



                    int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_CRG_002 where CmpyCode='" + ac.CMPYCODE + "' and FFM_CRG_JOB_CODE='" + ac.FFM_CRG_JOB_CODE + "'");
                    if (Stats1 == 0)
                    {


                        StringBuilder sb = new StringBuilder();
                        sb.Append("'" + ac.CMPYCODE + "',");

                        sb.Append("'" + ac.FFM_CRG_JOB_CODE + "',");
                        sb.Append("'" + ac.DISPLAY_STATUS + "',");
                        sb.Append("'" + ac.NAME + "',");
                        sb.Append("'" + ac.INCOME_ACT + "',");
                        sb.Append("'" + ac.EXPENSE_ACGT + "')");
                       

                        _EzBusinessHelper.ExecuteNonQuery("insert into FFM_CRG_002(CMPYCODE,FFM_CRG_JOB_CODE,DISPLAY_STATUS,NAME,INCOME_ACT,EXPENSE_ACGT) values(" + sb.ToString() + "");

                        _EzBusinessHelper.ActivityLog(ac.CMPYCODE, ac.UserName, "Add Charge group", ac.FFM_CRG_JOB_CODE, Environment.MachineName);

                        ac.SaveFlag = true;
                        ac.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        ac.SaveFlag = false;
                        ac.ErrorMessage = "Duplicate Record";
                    }


                    return ac;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_CRG_002 where CmpyCode='" + ac.CMPYCODE + "' and FFM_CRG_JOB_CODE='" + ac.FFM_CRG_JOB_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update FFM_CRG_002 set NAME='" + ac.NAME + "',INCOME_ACT='" + ac.INCOME_ACT + "',EXPENSE_ACGT='" + ac.EXPENSE_ACGT + "',FFM_CRG_JOB_CODE='" + ac.FFM_CRG_JOB_CODE + "',DISPLAY_STATUS='" + ac.DISPLAY_STATUS + "' where CmpyCode='" + ac.CMPYCODE + "' and FFM_CRG_JOB_CODE='" + ac.FFM_CRG_JOB_CODE + "'");

                    _EzBusinessHelper.ActivityLog(ac.CMPYCODE, ac.UserName, "Update Charge Group", ac.FFM_CRG_JOB_CODE, Environment.MachineName);

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
    }
}
