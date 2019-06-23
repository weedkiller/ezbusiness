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
        public bool DeleteFFM_CRG_Group(string CmpyCode,string FFM_CRG_GROUP_CODE, string UserName)
        {
          

            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_CRG_Group where CMPYCODE='" + CmpyCode + "' and FFM_CRG_GROUP_CODE='" + FFM_CRG_GROUP_CODE + "' and Flag=0");
            if (Grs != 0)
            {
                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_CRG_Group", FFM_CRG_GROUP_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_CRG_Group set Flag=1 where CMPYCODE='" + CmpyCode + "' and FFM_CRG_GROUP_CODE='" + FFM_CRG_GROUP_CODE + "'and Flag=0");
            }
            return false;
        }

        public FFM_CRG_Group_VM EditFFM_CRG_Group(string CmpyCode, string FFM_CRG_GROUP_CODE)
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
                ObjList.VAT_CODE = dr["VAT_CODE"].ToString();
                ObjList.VAT_GL_CODE = dr["VAT_GL_CODE"].ToString();
                ObjList.Name_Arabic = dr["Name_Arabic"].ToString();

            }
            return ObjList;
        }

        public List<FFM_CRG_Group_VM> GetFFM_CRG_Group(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_CRG_Group where CMPYCODE='" + CmpyCode + "'  and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
        //    FFM_CRG_Group_VM ObjList = new FFM_CRG_Group_VM();

            List<FFM_CRG_Group_VM> ObjList = new List<FFM_CRG_Group_VM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_CRG_Group_VM()
                {
                 CMPYCODE= dr["CMPYCODE"].ToString(),
                    FFM_CRG_GROUP_CODE = dr["FFM_CRG_GROUP_CODE"].ToString(),
                    DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString(),
                    NAME = dr["NAME"].ToString(),
                    VAT_CODE=dr["VAT_CODE"].ToString(),
                    VAT_GL_CODE=dr["VAT_GL_CODE"].ToString(),
                    Name_Arabic=dr["Name_Arabic"].ToString(),                                  
                });
            }
            return ObjList; 
        }

        public FFM_CRG_Group_VM SaveFFM_CRG_Group(FFM_CRG_Group_VM FCG)
        {

            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            try
            {
                if (!FCG.EditFlag)
                {
                  

                  
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_CRG_GROUP where CmpyCode='" + FCG.CMPYCODE + "' and FFM_CRG_GROUP_CODE='" + FCG.FFM_CRG_GROUP_CODE + "'");
                        if (Stats1 == 0)
                        {


                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + FCG.CMPYCODE + "',");
                            sb.Append("'" + FCG.FFM_CRG_GROUP_CODE + "',");
                            sb.Append("'" + FCG.DISPLAY_STATUS + "',");
                            sb.Append("'" + FCG.NAME + "',");
                            sb.Append("'" + FCG.VAT_CODE + "',");
                            sb.Append("'" + FCG.VAT_GL_CODE + "',");
                            sb.Append("'" + dtstr1 + "',");
                            sb.Append("'" + dtstr1 + "',");
                            sb.Append("'" + FCG.UserName + "',");
                            sb.Append("'" + FCG.Name_Arabic + "',");
                            sb.Append("'" + FCG.UserName + "')");
                                                     
                            _EzBusinessHelper.ExecuteNonQuery("insert into FFM_CRG_GROUP(CMPYCODE,FFM_CRG_GROUP_CODE,DISPLAY_STATUS,NAME,VAT_CODE,VAT_GL_CODE,CREATED_ON,UPDATED_ON,CREATED_BY,Name_Arabic,UPDATED_BY) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(FCG.CMPYCODE, FCG.UserName, "Add Charge group", FCG.FFM_CRG_GROUP_CODE, Environment.MachineName);

                            FCG.SaveFlag = true;
                            FCG.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            

                            
                            FCG.SaveFlag = false;
                            FCG.ErrorMessage = "Duplicate Record";
                        }
                       

                    return FCG;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_CRG_GROUP where CmpyCode='" + FCG.CMPYCODE + "' and FFM_CRG_GROUP_CODE='" + FCG.FFM_CRG_GROUP_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update FFM_CRG_GROUP set NAME='" + FCG.NAME + "',VAT_GL_CODE='"+ FCG.VAT_GL_CODE + "',VAT_CODE='"+ FCG.VAT_CODE +"',UPDATED_ON='" + dtstr1 + "',UPDATED_BY='" + FCG.UserName + "',FFM_CRG_GROUP_CODE='" + FCG.FFM_CRG_GROUP_CODE + "',DISPLAY_STATUS='" + FCG.DISPLAY_STATUS + "',Name_Arabic='" + FCG.Name_Arabic + "' where CmpyCode='" + FCG.CMPYCODE + "' and FFM_CRG_GROUP_CODE='" + FCG.FFM_CRG_GROUP_CODE + "'");

                    _EzBusinessHelper.ActivityLog(FCG.CMPYCODE, FCG.UserName, "Update Charge Group", FCG.FFM_CRG_GROUP_CODE, Environment.MachineName);

                    FCG.SaveFlag = true;
                    FCG.ErrorMessage = string.Empty;
                }
                else
                {
                    FCG.SaveFlag = false;
                    FCG.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FCG.SaveFlag = false;


            }

            return FCG;
        }
    }
}
