using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
    public class FFM_SRVCRepository : IFFM_SRVCRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_SRVC(string FFM_SRVC_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_SRVC where CmpyCode='" + CmpyCode + "' and FFM_SRVC_CODE='" + FFM_SRVC_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_SRVC", FFM_SRVC_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_SRVC set Flag=1 where CmpyCode='" + CmpyCode + "' and FFM_SRVC_CODE='" + FFM_SRVC_CODE + "'  and Flag=0");

            }
            return false;
        }

        public List<FFM_SRVC> GetFFM_SRVC(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_SRVC where CmpyCode='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_SRVC> ObjList = new List<FFM_SRVC>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_SRVC()
                {
                    CREATED_BY = dr["CREATED_BY"].ToString(),
                    CREATED_ON = Convert.ToDateTime(dr["CREATED_ON"].ToString()),
                    UPDATED_BY = dr["UPDATED_BY"].ToString(),
                    UPDATED_ON = Convert.ToDateTime(dr["UPDATED_ON"].ToString()),
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FFM_SRVC_CODE = dr["FFM_SRVC_CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),

                });
            }
            return ObjList;
        }

        public FFM_SRVC_VM SaveFM_SRVCHEAD(FFM_SRVC_VM SR)
        {
            DateTime dte;
            string dtstr1;
            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            try
            {
                if (!SR.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FFM_SRVCNew> ObjList = new List<FFM_SRVCNew>();
                    ObjList.AddRange(SR.FFM_SRVCNew.Select(m => new FFM_SRVCNew
                    {
                        CREATED_BY = m.CREATED_BY,
                        CREATED_ON = m.CREATED_ON,
                        UPDATED_BY = m.UPDATED_BY,
                        UPDATED_ON = m.UPDATED_ON,
                        CMPYCODE = m.CMPYCODE,
                        FFM_SRVC_CODE = m.FFM_SRVC_CODE,
                        NAME = m.NAME,

                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_SRVC where CmpyCode='" + SR.CMPYCODE + "' and FFM_SRVC_CODE='" + ObjList[n - 1].FFM_SRVC_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + SR.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].FFM_SRVC_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].NAME + "',");
                            sb.Append("'" + SR.UserName + "',");
                            sb.Append("'" + dtstr1 + "',");
                            sb.Append("'" + SR.UserName + "',");
                            sb.Append("'" + dtstr1 + "')");

                            _EzBusinessHelper.ExecuteNonQuery("insert into FFM_SRVC(CMPYCODE,FFM_SRVC_CODE,NAME,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(SR.CMPYCODE, SR.UserName, "Add FN Category", ObjList[n - 1].FFM_SRVC_CODE, Environment.MachineName);

                            SR.SaveFlag = true;
                            SR.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].FFM_SRVC_CODE.ToString());

                            SR.Drecord = Drecord;
                            SR.SaveFlag = false;
                            SR.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return SR;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_SRVC where CmpyCode='" + SR.CMPYCODE + "' and FFM_SRVC_CODE='" + SR.FFM_SRVC_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();


                    sb.Append("CMPYCODE='" + SR.CMPYCODE + "',");
                    sb.Append("FFM_SRVC_CODE='" + SR.FFM_SRVC_CODE + "',");
                    sb.Append("NAME='" + SR.NAME + "',");
                    sb.Append("CREATED_BY='" + SR.UserName + "',");
                    sb.Append("CREATED_ON='" + dtstr1 + "',");
                    sb.Append("UPDATED_BY='" + SR.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "'");

                    _EzBusinessHelper.ExecuteNonQuery("update FFM_SRVC set  " + sb + " where FFM_SRVC_CODE='" + SR.FFM_SRVC_CODE + "' and Flag=0");

                    _EzBusinessHelper.ActivityLog(SR.CMPYCODE, SR.UserName, "Update FMHead", SR.FFM_SRVC_CODE, Environment.MachineName);

                    SR.SaveFlag = true;
                    SR.ErrorMessage = string.Empty;
                }
                else
                {
                    SR.SaveFlag = false;
                    SR.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                SR.SaveFlag = false;


            }

            return SR;

        }
    
    }
}
