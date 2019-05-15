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
   public class FNM_CURRENCYRepository : IFNM_CURRENCYRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteFNM_CURRENCY(string FNM_CURRENCY_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNM_CURRENCY where  CURRENCY_CODE='" + FNM_CURRENCY_CODE + "'  and Flag=0");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNM_CURRENCY", FNM_CURRENCY_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNM_CURRENCY set Flag=1 where  CURRENCY_CODE='" + FNM_CURRENCY_CODE + "'  and Flag=0");//CMPYCODE='" + CmpyCode + "' and

            }
            return false;
        }

        public FNM_CURRENCY_VM EditFNM_CURRENCY(string CmpyCode, string FNM_CURRENCYCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select CURRENCY_CODE,CURRENCY_NAME,MASTER_STATUS,Note from FNM_CURRENCY where CURRENCY_CODE='" + FNM_CURRENCYCode + "' and Flag=0");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FNM_CURRENCY_VM ObjList = new FNM_CURRENCY_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.CURRENCY_CODE = dr["CURRENCY_CODE"].ToString();
                ObjList.CURRENCY_NAME = dr["CURRENCY_NAME"].ToString();
                ObjList.MASTER_STATUS = dr["MASTER_STATUS"].ToString();
                ObjList.Note = dr["Note"].ToString();

            }
            return ObjList;
        }

        public List<FNM_CURRENCY> GetFNM_CURRENCY(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select CURRENCY_CODE,CURRENCY_NAME,MASTER_STATUS,Note from FNM_CURRENCY where Flag=0");//  CMPYCODE='" + CmpyCode + "' and
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_CURRENCY> ObjList = new List<FNM_CURRENCY>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_CURRENCY()
                {
                    CURRENCY_CODE = dr["CURRENCY_CODE"].ToString(),
                    CURRENCY_NAME = dr["CURRENCY_NAME"].ToString(),
                    MASTER_STATUS = dr["MASTER_STATUS"].ToString(),
                    Note = dr["Note"].ToString()

                });
            }
            return ObjList;
        }

        public FNM_CURRENCY_VM SaveFNM_CURRENCY(FNM_CURRENCY_VM FCur)
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
                    List<FNM_CURRENCYDetailNew> ObjList = new List<FNM_CURRENCYDetailNew>();
                    ObjList.AddRange(FCur.FNM_CURRENCYDetailNew.Select(m => new FNM_CURRENCYDetailNew
                    {
                      CURRENCY_CODE=m.CURRENCY_CODE,
                      CURRENCY_NAME=m.CURRENCY_NAME,
                      Note=m.Note,
                      MASTER_STATUS=m.MASTER_STATUS
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;
                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNM_CURRENCY where CURRENCY_CODE='" + ObjList[n - 1].CURRENCY_CODE + "'");// CmpyCode='" + FCur.CMPYCODE + "' and
                    if (Stats1 == 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.Append("'" + ObjList[n - 1].CURRENCY_CODE + "',");
                       
                        sb.Append("'" + ObjList[n - 1].CURRENCY_NAME + "',");
                        sb.Append("'" + ObjList[n - 1].Note + "',");
                        sb.Append("'" + ObjList[n - 1].MASTER_STATUS + "',");
                        sb.Append("'" + FCur.UserName + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + FCur.UserName + "',");
                        sb.Append("'" + dtstr1 + "')");
                       
                        _EzBusinessHelper.ExecuteNonQuery("insert into FNM_CURRENCY(CURRENCY_CODE,CURRENCY_NAME,Note,MASTER_STATUS,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values(" + sb.ToString() + "");
                        _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Add FN Currency", ObjList[n - 1].CURRENCY_CODE, Environment.MachineName);
                        FCur.SaveFlag = true;
                        FCur.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Drecord.Add(FCur.CURRENCY_CODE.ToString());
                        //  branch.Drecord = Drecord;
                        FCur.SaveFlag = false;
                        FCur.ErrorMessage = "Duplicate Record";
                    }
                        n = n - 1;
                    }
                    return FCur;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FNM_CURRENCY where CURRENCY_CODE='" + FCur.CURRENCY_CODE + "'and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and 
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("CURRENCY_CODE='" + FCur.CURRENCY_CODE + "',");
                    sb.Append("CURRENCY_NAME='" + FCur.CURRENCY_NAME + "',");                  
                    sb.Append("MASTER_STATUS='" + FCur.MASTER_STATUS + "',");
                    sb.Append("Note='" + FCur.Note + "',");
                    sb.Append("UPDATED_BY='" + FCur.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "'");
                   
                    _EzBusinessHelper.ExecuteNonQuery("update FNM_CURRENCY set  " + sb + " where  CURRENCY_CODE='" + FCur.CURRENCY_CODE + "' and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and

                    _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Update Currency", FCur.CURRENCY_CODE, Environment.MachineName);

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
