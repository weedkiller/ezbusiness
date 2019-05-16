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
    public class FFM_PACKINGRepository : IFFM_PACKINGRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_PACKING(string FFM_PACKING_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_PACKING where  FFM_PACKING_CODE='" + FFM_PACKING_CODE + "'  and Flag=0");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_PACKING_CODE", FFM_PACKING_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_PACKING set Flag=1 where  FFM_PACKING_CODE='" + FFM_PACKING_CODE + "'  and Flag=0");//CMPYCODE='" + CmpyCode + "' and

            }
            return false;
        }

        public FFM_PACKING_VM EditFFM_PACKING(string CmpyCode, string FFM_PACKING_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_PACKING_CODE,NAME,FFM_PACKING_UID from FFM_PACKING where FFM_PACKING_CODE='" + FFM_PACKING_CODE + "' and Flag=0");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FFM_PACKING_VM ObjList = new FFM_PACKING_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.FFM_PACKING_CODE = dr["FFM_PACKING_CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
               // ObjList.FFM_PACKING_UID = dr["FFM_PACKING_UID"].ToString();

            }
            return ObjList;
        }

        public List<FFM_PACKING> GetFFM_PACKING(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_PACKING_CODE,NAME,FFM_PACKING_UID from FFM_PACKING where Flag=0");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_PACKING> ObjList = new List<FFM_PACKING>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_PACKING()
                {
                    FFM_PACKING_CODE = dr["FFM_PACKING_CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),
                    //FFM_PACKING_UID = dr["MASTER_STATUS"].ToString(),                    

                });
            }
            return ObjList;
        }

        public FFM_PACKING_VM SaveFFM_PACKING(FFM_PACKING_VM fpk)
        {
            try
            {

                DateTime dte;
                string dtstr1;
                dte = Convert.ToDateTime(DateTime.Now.ToString());
                dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

                if (!fpk.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FFM_PACKINGDetailNew> ObjList = new List<FFM_PACKINGDetailNew>();
                    ObjList.AddRange(fpk.FFM_PACKINGDetailNew.Select(m => new FFM_PACKINGDetailNew
                    {
                        FFM_PACKING_CODE = m.FFM_PACKING_CODE,
                        NAME = m.NAME,
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;
                    while (n >= 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_PACKING where FFM_PACKING_CODE='" + fpk.FFM_PACKING_CODE + "'");// CmpyCode='" + FCur.CMPYCODE + "' and
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + fpk.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].FFM_PACKING_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].NAME + "',");
                            sb.Append("'" + fpk.UserName + "',");
                            sb.Append("'" + fpk.UserName + "',");
                            sb.Append("'" + dtstr1 + "',");
                            sb.Append("'" + dtstr1 + "')");
                            
                            _EzBusinessHelper.ExecuteNonQuery("insert into FFM_PACKING(CMPYCODE,FFM_PACKING_CODE,NAME,CREATED_BY,UPDATED_BY,CREATED_ON,UPDATED_ON) values(" + sb.ToString() + "");
                            _EzBusinessHelper.ActivityLog(fpk.CMPYCODE, fpk.UserName, "Add Packing Code", ObjList[n - 1].FFM_PACKING_CODE, Environment.MachineName);

                            fpk.SaveFlag = true;
                            fpk.ErrorMessage = string.Empty;
                        }
                        else
                        {
                            Drecord.Add(fpk.FFM_PACKING_CODE.ToString());
                            //  branch.Drecord = Drecord;
                            fpk.SaveFlag = false;
                            fpk.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                            return fpk;
                  } 
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_PACKING where FFM_PACKING_CODE='" + fpk.FFM_PACKING_CODE + "'and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and 
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();

                   // sb.Append("FFM_PACKING_UID='" + fpk.FFM_PACKING_UID + "',");
                    sb.Append("NAME='" + fpk.NAME + "',");
                    sb.Append("UPDATED_BY='" + fpk.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "'");

                    _EzBusinessHelper.ExecuteNonQuery("update FFM_PACKING set  " + sb + " where  FFM_PACKING_CODE='" + fpk.FFM_PACKING_CODE + "' and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and

                    _EzBusinessHelper.ActivityLog(fpk.CMPYCODE, fpk.UserName, "Update PACKING_CODE", fpk.FFM_PACKING_CODE, Environment.MachineName);

                    fpk.SaveFlag = true;
                    fpk.ErrorMessage = string.Empty;
                }
                else
                {
                    fpk.SaveFlag = false;
                    fpk.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                fpk.SaveFlag = false;


            }

            return fpk;
        }
    }
}
