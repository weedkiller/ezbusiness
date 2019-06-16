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
    public class FFM_COM_GROUPRepository : IFFM_COM_GROUPRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_COM_GROUP(string FFM_COM_GROUP_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_COM_GROUP where CmpyCode='" + CmpyCode + "' and FFM_COM_GROUP_CODE='" + FFM_COM_GROUP_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_COM_GROUP", FFM_COM_GROUP_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_COM_GROUP set Flag=1 where CmpyCode='" + CmpyCode + "' and FFM_COM_GROUP_CODE='" + FFM_COM_GROUP_CODE + "'  and Flag=0");

            }
            return false;
        }

        public List<FFM_COM_GROUP> GetFFM_COM_GROUP(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_COM_GROUP where CmpyCode='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_COM_GROUP> ObjList = new List<FFM_COM_GROUP>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_COM_GROUP()
                {
                    CREATED_BY = dr["CREATED_BY"].ToString(),
                    CREATED_ON = Convert.ToDateTime(dr["CREATED_ON"].ToString()),
                    UPDATED_BY = dr["UPDATED_BY"].ToString(),
                    UPDATED_ON = Convert.ToDateTime(dr["UPDATED_ON"].ToString()),
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FFM_COM_GROUP_CODE = dr["FFM_COM_GROUP_CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),

                });
            }
            return ObjList;
        }

        public FFM_COM_GROUP_VM SaveFFM_COM_GROUP(FFM_COM_GROUP_VM FC)
        {
            DateTime dte;
            string dtstr1;
            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            try
            {
                if (!FC.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FFM_COM_GROUPNew> ObjList = new List<FFM_COM_GROUPNew>();
                    ObjList.AddRange(FC.FFM_COM_GROUPNew.Select(m => new FFM_COM_GROUPNew
                    {
                        CREATED_BY = m.CREATED_BY,
                        CREATED_ON = m.CREATED_ON,
                        UPDATED_BY = m.UPDATED_BY,
                        UPDATED_ON = m.UPDATED_ON,
                        CMPYCODE = m.CMPYCODE,
                        FFM_COM_GROUP_CODE = m.FFM_COM_GROUP_CODE,
                        NAME = m.NAME,

                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_COM_GROUP where CmpyCode='" + FC.CMPYCODE + "' and FFM_COM_GROUP_CODE='" + ObjList[n - 1].FFM_COM_GROUP_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + FC.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].FFM_COM_GROUP_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].NAME + "',");
                            sb.Append("'" + FC.UserName + "',");
                            sb.Append("'" + dtstr1 + "',");
                            sb.Append("'" + FC.UserName + "',");
                            sb.Append("'" + dtstr1 + "')");

                            _EzBusinessHelper.ExecuteNonQuery("insert into FFM_COM_GROUP(CMPYCODE,FFM_COM_GROUP_CODE,NAME,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(FC.CMPYCODE, FC.UserName, "Add FM COM GROUP CODE", ObjList[n - 1].FFM_COM_GROUP_CODE, Environment.MachineName);

                            FC.SaveFlag = true;
                            FC.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].FFM_COM_GROUP_CODE.ToString());

                            FC.Drecord = Drecord;
                            FC.SaveFlag = false;
                            FC.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return FC;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_COM_GROUP where CmpyCode='" + FC.CMPYCODE + "' and FFM_COM_GROUP_CODE='" + FC.FFM_COM_GROUP_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();


                    sb.Append("CMPYCODE='" + FC.CMPYCODE + "',");
                    sb.Append("FFM_COM_GROUP_CODE='" + FC.FFM_COM_GROUP_CODE + "',");
                    sb.Append("NAME='" + FC.NAME + "',");
                    sb.Append("CREATED_BY='" + FC.UserName + "',");
                    sb.Append("CREATED_ON='" + dtstr1 + "',");
                    sb.Append("UPDATED_BY='" + FC.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "'");

                    _EzBusinessHelper.ExecuteNonQuery("update FFM_COM_GROUP set  " + sb + " where FFM_COM_GROUP_CODE='" + FC.FFM_COM_GROUP_CODE + "' and Flag=0");

                    _EzBusinessHelper.ActivityLog(FC.CMPYCODE, FC.UserName, "Update FFM_COM_GROUP", FC.FFM_COM_GROUP_CODE, Environment.MachineName);

                    FC.SaveFlag = true;
                    FC.ErrorMessage = string.Empty;
                }
                else
                {
                    FC.SaveFlag = false;
                    FC.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FC.SaveFlag = false;


            }

            return FC;
        }
    }
}
