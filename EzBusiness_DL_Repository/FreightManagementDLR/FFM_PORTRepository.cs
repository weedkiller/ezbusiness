using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_EF_Entity;
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
    public class FFM_PORTRepository : IFFM_PORTRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteFFM_PORT(string FFM_PORT_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_PORT where  FFM_PORT_CODE='" + FFM_PORT_CODE + "'  and Flag=0");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_PORT_CODE", FFM_PORT_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_PORT set Flag=1 where  FFM_PORT_CODE='" + FFM_PORT_CODE + "'  and Flag=0");//CMPYCODE='" + CmpyCode + "' and

            }
            return false;
        }

        public FFM_PORT_VM EditFFM_PORT(string CmpyCode, string FFM_PORT_CODE)
        {
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FFM_PORT_VM ObjList = new FFM_PORT_VM();
            foreach (DataRow dr in drc)
            {
                ObjList.FFM_PORT_CODE = dr["FFM_PORT_CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
                ObjList.CMPYCODE = dr["CMPYCODE"].ToString();
                ObjList.COUNTRY = dr["COUNTRY"].ToString();
                ObjList.UPDATED_BY = dr["UPDATED_BY"].ToString();
                ObjList.UPDATED_ON = Convert.ToDateTime(dr["UPDATED_ON"].ToString());
                ObjList.CREATED_BY = dr["CREATED_BY"].ToString();
                ObjList.CREATED_ON = Convert.ToDateTime(dr["CREATED_ON"].ToString());
                ObjList.DISPLY_STATUS = dr["DISPLY_STATUS"].ToString();
                ObjList.TERMINAL = dr["TERMINAL"].ToString();
            }
            return ObjList;
        }
        public List<Nation> GetCountryList(string CmpyCode)
        {
          return   drop.GetNationList(CmpyCode);
        }
        public List<FFM_PORT> GetFFM_PORT(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_PORT_CODE,NAME,COUNTRY,TERMINAL,LATITUDE,LANGITUDE,DISPLY_STATUS from FFM_PORT where Flag=0");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_PORT> ObjList = new List<FFM_PORT>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_PORT()
                {
                    FFM_PORT_CODE = dr["FFM_PORT_CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),
                    COUNTRY = dr["COUNTRY"].ToString(),
                    TERMINAL = dr["TERMINAL"].ToString(),
                    LANGITUDE=dr["LANGITUDE"].ToString(),
                    LATITUDE = dr["LATITUDE"].ToString(),
                    DISPLY_STATUS = dr["DISPLY_STATUS"].ToString(),
                });
            }
            return ObjList;
        }

        public FFM_PORT_VM SaveFFM_PORT(FFM_PORT_VM fpk)
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
                    //List<FFM_portNew> ObjList = new List<FFM_portNew>();
                    //ObjList.AddRange(fpk.FFM_portNew.Select(m => new FFM_portNew
                    //{
                    //    FFM_PORT_CODE = m.FFM_PORT_CODE,
                    //    NAME = m.NAME,
                    //    //Equals = m.Equals,
                    //    DISPLY_STATUS = m.DISPLY_STATUS,
                    //    COUNTRY = m.COUNTRY,

                    //}).ToList());
                    //int n = 0;
                    //n = ObjList.Count;
                    //while (n >= 0)
                    //{
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_PACKING where FFM_PACKING_CODE='" + fpk.FFM_PORT_CODE + "'");// CmpyCode='" + FCur.CMPYCODE + "' and
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + fpk.CMPYCODE + "',");
                            sb.Append("'" + fpk.FFM_PORT_CODE + "',");
                            sb.Append("'" + fpk.NAME + "',");
                            sb.Append("'" + fpk.COUNTRY + "',");
                            sb.Append("'" + fpk.TERMINAL + "',");
                            sb.Append("'" + fpk.LANGITUDE + "',");
                            sb.Append("'" + fpk.LATITUDE + "',");
                            sb.Append("'" + fpk.DISPLY_STATUS + "',");
                            sb.Append("'" + fpk.UserName + "',");
                            sb.Append("'" + fpk.UserName + "',");
                            sb.Append("'" + dtstr1 + "',");
                            sb.Append("'" + dtstr1 + "')");

                            _EzBusinessHelper.ExecuteNonQuery("insert into FFM_PORT(CMPYCODE,FFM_PORT_CODE,NAME,COUNTRY,TERMINAL,LANGITUDE,LATITUDE,DISPLY_STATUS,CREATED_BY,UPDATED_BY,CREATED_ON,UPDATED_ON) values(" + sb.ToString() + "");
                            _EzBusinessHelper.ActivityLog(fpk.CMPYCODE, fpk.UserName, "Add PORT Code", fpk.FFM_PORT_CODE, Environment.MachineName);

                            fpk.SaveFlag = true;
                            fpk.ErrorMessage = string.Empty;
                        }
                        else
                        {
                            Drecord.Add(fpk.FFM_PORT_CODE.ToString());
                            //  branch.Drecord = Drecord;
                            fpk.SaveFlag = false;
                            fpk.ErrorMessage = "Duplicate Record";
                        }

                  //  }
                    return fpk;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_PORT where FFM_PORT_CODE='" + fpk.FFM_PORT_CODE + "'and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and 
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();

                        // sb.Append("FFM_PACKING_UID='" + fpk.FFM_PACKING_UID + "',");
                        sb.Append("NAME='" + fpk.NAME + "',");
                        sb.Append("COUNTRY='" + fpk.COUNTRY + "',");
                        sb.Append("TERMINAL='" + fpk.TERMINAL + "',");
                        sb.Append("LANGITUDE='" + fpk.LANGITUDE + "',");
                        sb.Append("LATITUDE='" + fpk.LATITUDE + "',");
                        sb.Append("UPDATED_BY='" + fpk.UserName + "',");
                        sb.Append("UPDATED_ON='" + dtstr1 + "'");

                        _EzBusinessHelper.ExecuteNonQuery("update FFM_PORT set  " + sb + " where  FFM_PORT_CODE='" + fpk.FFM_PORT_CODE + "' and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and

                        _EzBusinessHelper.ActivityLog(fpk.CMPYCODE, fpk.UserName, "Update FFM_PORT", fpk.FFM_PORT_CODE, Environment.MachineName);

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

