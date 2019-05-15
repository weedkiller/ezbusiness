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
    public class FFM_VESSELRepository : IFFM_VESSELRepository
    {

        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_VESSEL(string FFM_VESSEL_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_VESSEL where CMPYCODE='" + CmpyCode + "' and FFM_VESSEL_CODE='" + FFM_VESSEL_CODE + "'  and Flag1=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_VESSEL", FFM_VESSEL_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNM_AC_COA set Flag=1 where CMPYCODE='" + CmpyCode + "' and FFM_VESSEL_CODE='" + FFM_VESSEL_CODE + "'  and Flag1=0");

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
                ObjList.SCACCODE = dr["SCACCODE"].ToString();
                ObjList.VESSEL_TYPE = dr["VESSEL_TYPE"].ToString();
                ObjList.COUNTRY = dr["COUNTRY"].ToString();
                ObjList.CARRIER = dr["CARRIER"].ToString();
                
            }
            return ObjList;
        }

        public List<FFM_VESSEL> GetFFM_VESSEL(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMHEAD_CODE,DESCRIPTION from FMHEAD where CmpyCode='" + Cmpycode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_VESSEL> ObjList = new List<FFM_VESSEL>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_VESSEL()
                {
                    FFM_VESSEL_CODE = dr["FFM_VESSEL_CODE"].ToString(),
                   
                });
            }
            return ObjList;
        }

        public FFM_VESSEL_VM SaveFFM_VESSEL(FFM_VESSEL_VM ac)
        {
            throw new NotImplementedException();
        }
    }
}
