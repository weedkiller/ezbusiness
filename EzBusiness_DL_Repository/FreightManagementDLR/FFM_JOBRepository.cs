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
    public class FFM_JOBRepository : IFFM_JOBRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_JOB(string FFM_JOB_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_JOB where CmpyCode='" + CmpyCode + "' and FFM_JOB_CODE='" + FFM_JOB_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_JOB", FFM_JOB_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_JOB set Flag=1 where CmpyCode='" + CmpyCode + "' and FFM_JOB_CODE='" + FFM_JOB_CODE + "'  and Flag=0");

            }
            return false;
        }

        public List<FFM_JOB> GetFFM_JOB(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_JOB where CmpyCode='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_JOB> ObjList = new List<FFM_JOB>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_JOB()
                {
                    CREATED_BY = dr["CREATED_BY"].ToString(),
                    CREATED_ON = Convert.ToDateTime(dr["CREATED_ON"].ToString()),
                    UPDATED_BY = dr["UPDATED_BY"].ToString(),
                    UPDATED_ON = Convert.ToDateTime(dr["UPDATED_ON"].ToString()),
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FFM_JOB_CODE = dr["FFM_JOB_CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),

                });
            }
            return ObjList;
        }

        public FFM_JOB_VM SaveFM_JOBHEAD(FFM_JOB_VM FJ)
        {
            DateTime dte;
            string dtstr1;
            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            try
            {
                if (!FJ.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FFM_JOBNew> ObjList = new List<FFM_JOBNew>();
                    ObjList.AddRange(FJ.FFM_JOBNew.Select(m => new FFM_JOBNew
                    {
                        CREATED_BY = m.CREATED_BY,
                        CREATED_ON = m.CREATED_ON,
                        UPDATED_BY = m.UPDATED_BY,
                        UPDATED_ON = m.UPDATED_ON,
                        CMPYCODE = m.CMPYCODE,
                        FFM_JOB_CODE = m.FFM_JOB_CODE,
                        NAME = m.NAME,

                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_JOB where CmpyCode='" + FJ.CMPYCODE + "' and FFM_JOB_CODE='" + ObjList[n - 1].FFM_JOB_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + FJ.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].FFM_JOB_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].NAME + "',");
                            sb.Append("'" + FJ.UserName + "',");
                            sb.Append("'" + dtstr1 + "',");
                            sb.Append("'" + FJ.UserName + "',");
                            sb.Append("'" + dtstr1 + "')");

                            _EzBusinessHelper.ExecuteNonQuery("insert into FFM_JOB(CMPYCODE,FFM_JOB_CODE,NAME,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(FJ.CMPYCODE, FJ.UserName, "Add FN Category", ObjList[n - 1].FFM_JOB_CODE, Environment.MachineName);

                            FJ.SaveFlag = true;
                            FJ.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].FFM_JOB_CODE.ToString());

                            FJ.Drecord = Drecord;
                            FJ.SaveFlag = false;
                            FJ.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return FJ;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_JOB where CmpyCode='" + FJ.CMPYCODE + "' and FFM_JOB_CODE='" + FJ.FFM_JOB_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();


                    sb.Append("CMPYCODE='" + FJ.CMPYCODE + "',");
                    sb.Append("FFM_JOB_CODE='" + FJ.FFM_JOB_CODE + "',");
                    sb.Append("NAME='" + FJ.NAME + "',");
                    sb.Append("CREATED_BY='" + FJ.UserName + "',");
                    sb.Append("CREATED_ON='" + dtstr1 + "',");
                    sb.Append("UPDATED_BY='" + FJ.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "'");

                    _EzBusinessHelper.ExecuteNonQuery("update FFM_JOB set  " + sb + " where FFM_JOB_CODE='" + FJ.FFM_JOB_CODE + "' and Flag=0");

                    _EzBusinessHelper.ActivityLog(FJ.CMPYCODE, FJ.UserName, "Update FMHead", FJ.FFM_JOB_CODE, Environment.MachineName);

                    FJ.SaveFlag = true;
                    FJ.ErrorMessage = string.Empty;
                }
                else
                {
                    FJ.SaveFlag = false;
                    FJ.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FJ.SaveFlag = false;


            }

            return FJ;
        }
    }
}
