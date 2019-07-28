using EzBusiness_DL_Interface.FreightManagementDLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Data;
using EzBusiness_EF_Entity;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
    public class FFM_VESSELRepository : IFFM_VESSELRepository
    {
        DateTime dte;
        string dtstr1;
        DataSet ds = null;
        DataTable dt = null;
        DropListFillFun drop = new DropListFillFun();
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_VESSEL(string FFM_VESSEL_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_VESSEL where CMPYCODE='" + CmpyCode + "' and FFM_VESSEL_CODE='" + FFM_VESSEL_CODE + "'  and Flag1=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_VESSEL", FFM_VESSEL_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_VESSEL set Flag1=1 where CMPYCODE='" + CmpyCode + "' and FFM_VESSEL_CODE='" + FFM_VESSEL_CODE + "'  and Flag1=0");

            }
            return false;
        }

        public FFM_VESSEL_VM EditFFM_VESSEL(string CmpyCode, string FFM_VESSEL_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_VESSEL where CMPYCODE='" + CmpyCode + "' and FFM_VESSEL_CODE='" + FFM_VESSEL_CODE + "'  and Flag1=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FFM_VESSEL_VM ObjList = new FFM_VESSEL_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.CMPYCODE = dr["CMPYCODE"].ToString();
                ObjList.FFM_VESSEL_CODE = dr["FFM_VESSEL_CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
                ObjList.FLAG = dr["FLAG"].ToString();
                ObjList.SCACCODE = dr["SCACCODE"].ToString().Trim();
                ObjList.VESSEL_TYPE = dr["VESSEL_TYPE"].ToString().Trim();
                ObjList.COUNTRY = dr["COUNTRY"].ToString().Trim();
                ObjList.CARRIER = dr["CARRIER"].ToString();
                
            }
            return ObjList;
        }

        public List<FFM_VESSEL> GetFFM_VESSEL(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_VESSEL_CODE,CARRIER,COUNTRY,FLAG,NAME,SCACCODE,VESSEL_TYPE from FFM_VESSEL where CmpyCode='" + CmpyCode + "' and Flag1=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_VESSEL> ObjList = new List<FFM_VESSEL>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_VESSEL()
                {
                    FFM_VESSEL_CODE = dr["FFM_VESSEL_CODE"].ToString(),
                    CARRIER = dr["CARRIER"].ToString(),
                    COUNTRY=dr["COUNTRY"].ToString(),
                    FLAG=dr["FLAG"].ToString(),
                    NAME=dr["NAME"].ToString(),
                    SCACCODE=dr["SCACCODE"].ToString(),
                    VESSEL_TYPE=dr["VESSEL_TYPE"].ToString()
                });
            }
            return ObjList;
        }

        public FFM_VESSEL_VM SaveFFM_VESSEL(FFM_VESSEL_VM FVS)
        {
            try
            {
                dte = Convert.ToDateTime(DateTime.Now.ToString());
                dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");              
                if (!FVS.EditFlag)
                {
                    int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_VESSEL where CMPYCODE='" + FVS.CMPYCODE + "' and FFM_VESSEL_CODE='" + FVS.FFM_VESSEL_CODE + "' and  Flag1=0");
                    if (Stats1 == 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("'" + FVS.CMPYCODE + "',");
                        sb.Append("'" + FVS.FFM_VESSEL_CODE + "',");
                        sb.Append("'" + FVS.FLAG + "',");
                        sb.Append("'" + FVS.NAME + "',");
                        sb.Append("'" + FVS.CARRIER + "',");
                        sb.Append("'" + FVS.SCACCODE + "',");
                        sb.Append("'" + FVS.VESSEL_TYPE + "',");
                        sb.Append("'" + FVS.UserName + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + FVS.UserName + "',");
                        sb.Append("'" + dtstr1 + "',");                       
                        sb.Append("'" + FVS.COUNTRY + "')");
                        
                        _EzBusinessHelper.ExecuteNonQuery("insert into FFM_VESSEL(CMPYCODE,FFM_VESSEL_CODE,FLAG,NAME,CARRIER,SCACCODE,VESSEL_TYPE,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,COUNTRY) values(" + sb.ToString() + "");
                        _EzBusinessHelper.ActivityLog(FVS.CMPYCODE, FVS.UserName, "Add FFM_VESSEL", FVS.FFM_VESSEL_CODE, Environment.MachineName);
                        FVS.SaveFlag = true;
                        FVS.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        FVS.SaveFlag = false;
                        FVS.ErrorMessage = "Duplicate Record";
                    }
                    return FVS;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_VESSEL where CMPYCODE='" + FVS.CMPYCODE + "' and FFM_VESSEL_CODE='" + FVS.FFM_VESSEL_CODE + "' and  Flag1=0");
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("CARRIER='" + FVS.CARRIER + "',");                   
                    sb.Append("COUNTRY='" + FVS.COUNTRY + "',");                    
                    sb.Append("FLAG='" + FVS.FLAG + "',");
                    sb.Append("NAME='" + FVS.NAME + "',");
                    sb.Append("SCACCODE='" + FVS.SCACCODE + "',");
                    sb.Append("UPDATED_BY='" + FVS.UPDATED_BY + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "',");
                    sb.Append("VESSEL_TYPE='" + FVS.VESSEL_TYPE + "'");
                    
                    _EzBusinessHelper.ExecuteNonQuery("update FFM_VESSEL set  " + sb + " where CMPYCODE='" + FVS.CMPYCODE + "' and FFM_VESSEL_CODE='" + FVS.FFM_VESSEL_CODE + "' and  Flag1=0");
                    _EzBusinessHelper.ActivityLog(FVS.CMPYCODE, FVS.UserName, "Update FFM_VESSEL", FVS.FFM_VESSEL_CODE, Environment.MachineName);

                    FVS.SaveFlag = true;
                    FVS.ErrorMessage = string.Empty;
                }
                else
                {
                    FVS.SaveFlag = false;
                    FVS.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FVS.SaveFlag = false;


            }

            return FVS;
        }

        public List<ComDropTbl> GetNationList(string CmpyCode,string Prefix)
        {
            //return drop.GetNationList(CmpyCode);
            return drop.GetCommonDrop("CODE as [Code],NAME as [CodeName]", "MNAT019", "CMPYCODE='" + CmpyCode + "' and (CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetContainer(string CmpyCode,string Prefix)
        {
            return drop.GetCommonDrop("FFM_CNTR_CODE as [Code],NAME as [CodeName]", "FFM_CNTR", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (FFM_CNTR_CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
            //ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_CNTR_CODE,NAME from FFM_CNTR where CmpyCode='" + CmpyCode + "' and Flag=0");// 
            //dt = ds.Tables[0];
            //DataRowCollection drc = dt.Rows;
            //List<FFM_CNTR> ObjList = new List<FFM_CNTR>();
            //foreach (DataRow dr in drc)
            //{
            //    ObjList.Add(new ComDropTbl()
            //    {
            //        FFM_CNTR_CODE = dr["FFM_CNTR_CODE"].ToString(),
            //        NAME = dr["NAME"].ToString()
            //    });
            //}
            //return ObjList;
        }
    }
}
