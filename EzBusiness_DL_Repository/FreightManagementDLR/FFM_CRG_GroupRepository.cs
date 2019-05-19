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
    public class FFM_CRG_GroupRepository : IFFM_CRG_GroupRepository
    {

        DateTime dte, dte1;
        string dtstr1, dtstr2;
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFFM_CRG_Group(string FFM_CRG_GROUP_CODE, string CmpyCode, string UserName)
        {
          

            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_CRG_Group where CMPYCODE='" + CmpyCode + "' and FFM_CRG_GROUP_CODE='" + FFM_CRG_GROUP_CODE + "'  Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_CRG_Group", FFM_CRG_GROUP_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_CRG_Group set Flag=1 where CMPYCODE='" + CmpyCode + "' and FFM_CRG_GROUP_CODE='" + FFM_CRG_GROUP_CODE + "'   and Flag=0");

            }
            return false;
        }

        public FFM_CRG_Group_VM EditFNM_AC_COA(string CmpyCode, string FFM_CRG_GROUP_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_CRG_Group where CMPYCODE='" + CmpyCode + "' and FFM_CRG_GROUP_CODE='" + FFM_CRG_GROUP_CODE + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FFM_CRG_Group_VM ObjList = new FFM_CRG_Group_VM();
            foreach (DataRow dr in drc)
            {


                ObjList.DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString();
                ObjList.FFM_CRG_GROUP_CODE = dr["FFM_CRG_GROUP_CODE"].ToString();
                ObjList.NAME= dr["NAME"].ToString();
                

            }
            return ObjList;
        }

        public List<FFM_CRG_Group_VM> GetFNM_AC_COA(string CmpyCode)
        {
            throw new NotImplementedException();
        }

        public FFM_CRG_Group_VM SaveFNM_AC_COA(FFM_CRG_Group_VM ac)
        {
            throw new NotImplementedException();
        }
    }
}
