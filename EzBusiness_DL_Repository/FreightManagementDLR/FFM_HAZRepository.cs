using EzBusiness_DL_Interface.FreightManagementDLI;
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
   public class FFM_HAZRepository: IFFM_HAZRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteFFM_HAZ(string FFM_HAZ_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_HAZ where  FFM_HAZ_CODE='" + FFM_HAZ_CODE + "' and cmpycode='" + CmpyCode + "'  and Flag=0");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_HAZ", FFM_HAZ_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_HAZ set Flag=1 where  FFM_HAZ_CODE='" + FFM_HAZ_CODE + "' and cmpycode='" + CmpyCode + "'   and Flag=0");//CMPYCODE='" + CmpyCode + "' and

            }
            return false;
        }

        public FFM_HAZ_VM EditFFM_HAZ(string CmpyCode, string FFM_HAZ_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_HAZ_CODE,NAME,DISPLAY_STATUSfrom FFM_HAZ where FFM_HAZ_CODE='" + FFM_HAZ_CODE + "' and Flag=0");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FFM_HAZ_VM ObjList = new FFM_HAZ_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.FFM_HAZ_CODE = dr["FFM_HAZ_CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
                ObjList.DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString();
            }
            return ObjList;
        }

        public List<FFM_HAZ> GetFFM_HAZ(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_HAZ_CODE,NAME,DISPLAY_STATUS from FFM_HAZ where Flag=0");//  CMPYCODE='" + CmpyCode + "' and
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_HAZ> ObjList = new List<FFM_HAZ>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_HAZ()
                {
                    FFM_HAZ_CODE = dr["FFM_HAZ_CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),
                    DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString(),


                });
            }
            return ObjList;
        }

        public FFM_HAZ_VM SaveFFM_HAZ(FFM_HAZ_VM FCur)
        {
            try
            {

                DateTime dte;
                string dtstr1;
                dte = Convert.ToDateTime(DateTime.Now.ToString());
                dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

                if (!FCur.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FFM_HAZ_newdetails> ObjList = new List<FFM_HAZ_newdetails>();
                    ObjList.AddRange(FCur.FFM_HAZdetailsnew.Select(m => new FFM_HAZ_newdetails
                    {
                        FFM_HAZ_CODE = m.FFM_HAZ_CODE,
                        NAME = m.NAME,
                        CMPYCODE = m.CMPYCODE,
                        DISPLAY_STATUS = m.DISPLAY_STATUS,
                        //MASTER_STATUS = m.MASTER_STATUS
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;
                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_HAZ where FFM_HAZ_CODE='" + ObjList[n - 1].FFM_HAZ_CODE + "' and  CmpyCode='" + ObjList[n - 1].CMPYCODE + "' and flag=0");// CmpyCode='" + FCur.CMPYCODE + "' and
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.Append("'" + ObjList[n - 1].FFM_HAZ_CODE + "',");

                            sb.Append("'" + ObjList[n - 1].NAME + "',");
                            sb.Append("'" + FCur.CMPYCODE + "',");

                            sb.Append("'" + FCur.UserName + "',");
                            sb.Append("'" + dtstr1 + "',");
                            //sb.Append("'" + FCur.UserName + "',");
                            sb.Append("'" + FCur.UserName + "',");
                            sb.Append("'" + ObjList[n - 1].DISPLAY_STATUS + "',");
                            sb.Append("'" + dtstr1 + "')");

                            int i = _EzBusinessHelper.ExecuteNonQuery("insert into FFM_HAZ(FFM_HAZ_CODE,NAME,CMPYCODE,CREATED_BY,CREATED_ON,UPDATED_BY,DISPLAY_STATUS,UPDATED_ON) values(" + sb.ToString() + "");
                            _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Add FFM CNTR", ObjList[n - 1].FFM_HAZ_CODE, Environment.MachineName);
                            FCur.SaveFlag = true;
                            FCur.ErrorMessage = string.Empty;
                        }
                        else
                        {
                            Drecord.Add(FCur.FFM_HAZ_CODE.ToString());
                            //  branch.Drecord = Drecord;
                            FCur.SaveFlag = false;
                            FCur.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    return FCur;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_HAZ where FFM_HAZ_CODE='" + FCur.FFM_HAZ_CODE + "' and  cmpycode='" + FCur.CMPYCODE + "' and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and 
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("FFM_HAZ_CODE='" + FCur.FFM_HAZ_CODE + "',");
                    sb.Append("NAME='" + FCur.NAME + "',");
                    sb.Append("DISPLAY_STATUS='" + FCur.DISPLAY_STATUS + "',");
                    //sb.Append("Note='" + FCur.Note + "',");
                    sb.Append("UPDATED_BY='" + FCur.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "'");

                    _EzBusinessHelper.ExecuteNonQuery("update FFM_HAZ set  " + sb + " where  FFM_HAZ_CODE='" + FCur.FFM_HAZ_CODE + "' and  cmpycode='" + FCur.CMPYCODE + "' and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and

                    _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Update Currency", FCur.FFM_HAZ_CODE, Environment.MachineName);

                    FCur.SaveFlag = true;
                    FCur.ErrorMessage = string.Empty;
                }
                else
                {
                    FCur.SaveFlag = false;
                    FCur.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FCur.SaveFlag = false;


            }

            return FCur;
        }
    }
}
