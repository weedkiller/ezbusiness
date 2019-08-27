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
    public class FNM_CURR_RATERepository : IFNM_CURR_RATERepository
    {
        DateTime dte, dte1;
        string dtstr1, dtstr2;
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFNM_CURR_RATE(string CmpyCode, string FROM_CURRENCY_CODE, DateTime ENTRY_DATE, string UserName)
        {
            
            dte1 = Convert.ToDateTime(ENTRY_DATE);
            dtstr2 = dte1.ToString("yyyy-MM-dd");

            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNM_CURR_RATE where CMPYCODE='" + CmpyCode + "' and FROM_CURRENCY_CODE='" + FROM_CURRENCY_CODE + "' and format(ENTRY_DATE,'yyyy-MM-dd')='" + dtstr2 +"'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNM_CURR_RATE", FROM_CURRENCY_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNM_CURR_RATE set Flag=1 where CMPYCODE='" + CmpyCode + "' and FROM_CURRENCY_CODE='" + FROM_CURRENCY_CODE + "'  and format(ENTRY_DATE,'yyyy-MM-dd')='" + dtstr2 + "' and Flag=0");

            }
            return false;
        }

        public FNM_CURR_RATE_VM EditFNM_CURR_RATE(string CmpyCode, string FROM_CURRENCY_CODE, DateTime ENTRY_DATE)
        {

            dte1 = Convert.ToDateTime(ENTRY_DATE);
            dtstr2 = dte1.ToString("yyyy-MM-dd");
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNM_CURR_RATE where CMPYCODE='" + CmpyCode + "' and FROM_CURRENCY_CODE='" + FROM_CURRENCY_CODE + "' and format(ENTRY_DATE,'yyyy-MM-dd')='" + dtstr2 + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FNM_CURR_RATE_VM ObjList = new FNM_CURR_RATE_VM();
            foreach (DataRow dr in drc)
            {

              
                ObjList.FROM_CURRENCY_CODE = dr["FROM_CURRENCY_CODE"].ToString();
                ObjList.TO_CURRENCY_CODE = dr["TO_CURRENCY_CODE"].ToString();
                ObjList.MASTER_STATUS = dr["MASTER_STATUS"].ToString();
                ObjList.Note = dr["Note"].ToString();
                ObjList.ENTRY_DATE = Convert.ToDateTime(dr["ENTRY_DATE"].ToString());
                ObjList.BUY_RATE= Convert.ToDecimal(dr["BUY_RATE"].ToString());
                ObjList.SELL_RATE = Convert.ToDecimal(dr["SELL_RATE"].ToString());
                ObjList.Branch_code =Convert.ToString(dr["Branchcode"].ToString());

            }
            return ObjList;
        }

        public List<FNM_CURRENCY> GetFNMCURRENCY()
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select CURRENCY_CODE,CURRENCY_NAME from FNM_CURRENCY where Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_CURRENCY> ObjList = new List<FNM_CURRENCY>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_CURRENCY()
                {
                    CURRENCY_CODE = dr["CURRENCY_CODE"].ToString(),
                    CURRENCY_NAME = dr["CURRENCY_NAME"].ToString()
                });
            }
            return ObjList;
        }

        public List<FNM_CURR_RATE_VM> GetFNM_CURR_RATE(string CmpyCode)
        {
            //Select a.* from FNM_CURR_RATE a right join  (select max(ENTRY_DATE) as [ENTRY_DATE],FROM_CURRENCY_CODE,CMPYCODE from FNM_CURR_RATE group by FROM_CURRENCY_CODE,CMPYCODE ) as [FRMCUR]  on FRMCUR.FROM_CURRENCY_CODE=a.FROM_CURRENCY_CODE and FRMCUR.CMPYCODE=a.CMPYCODE and FRMCUR.ENTRY_DATE=a.ENTRY_DATE where a.CMPYCODE='UM' and a.flag=0
            //            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNM_CURR_RATE where CMPYCODE='" + CmpyCode + "' and Flag=0");// 
            ds = _EzBusinessHelper.ExecuteDataSet("Select a.* from FNM_CURR_RATE a right join  (select max(ENTRY_DATE) as [ENTRY_DATE],FROM_CURRENCY_CODE,CMPYCODE from FNM_CURR_RATE group by FROM_CURRENCY_CODE,CMPYCODE ) as [FRMCUR]  on FRMCUR.FROM_CURRENCY_CODE=a.FROM_CURRENCY_CODE and FRMCUR.CMPYCODE=a.CMPYCODE and FRMCUR.ENTRY_DATE=a.ENTRY_DATE where a.CMPYCODE='" + CmpyCode + "' and a.flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_CURR_RATE_VM> ObjList = new List<FNM_CURR_RATE_VM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_CURR_RATE_VM()
                {
                    CMPYCODE = dr["CMPYCODE"].ToString(),
                    FROM_CURRENCY_CODE = dr["FROM_CURRENCY_CODE"].ToString(),
                    TO_CURRENCY_CODE = dr["TO_CURRENCY_CODE"].ToString(),
                    SELL_RATE = Convert.ToDecimal(dr["SELL_RATE"].ToString()),
                    BUY_RATE = Convert.ToDecimal(dr["BUY_RATE"].ToString()),
                    ENTRY_DATE = Convert.ToDateTime(dr["ENTRY_DATE"].ToString()),
                    Note = dr["Note"].ToString(),
                    MASTER_STATUS=dr["MASTER_STATUS"].ToString(),
                    Branch_code = dr["Branchcode"].ToString()
                });
            }
            return ObjList;
        }

        public FNM_CURR_RATE_VM SaveFNM_CURR_RATE(FNM_CURR_RATE_VM FnCurRate)
        {
            try
            {

                
                dte = Convert.ToDateTime(DateTime.Now.ToString());
                dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

                dte1 = Convert.ToDateTime(FnCurRate.ENTRY_DATE);
                dtstr2 = dte1.ToString("yyyy-MM-dd");

                if (!FnCurRate.EditFlag)
                {
                 
                    int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNM_CURR_RATE where CMPYCODE='" + FnCurRate.CMPYCODE + "' and FROM_CURRENCY_CODE='" + FnCurRate.FROM_CURRENCY_CODE + "' and format(ENTRY_DATE,'yyyy-MM-dd hh:mm:ss tt')='" + dtstr2 + "' and Flag=0");
                    if (Stats1 == 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("'" + FnCurRate.CMPYCODE + "',");
                        sb.Append("'" + FnCurRate.TO_CURRENCY_CODE + "',");
                        sb.Append("'" + FnCurRate.FROM_CURRENCY_CODE + "',");
                        sb.Append("'" + FnCurRate.SELL_RATE + "',");
                        sb.Append("'" + FnCurRate.BUY_RATE + "',");
                        sb.Append("'" + FnCurRate.UserName + "',");
                        sb.Append("'" + dtstr1 + "',");                        
                        sb.Append("'" + FnCurRate.UserName + "',");                        
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + dtstr2 + "',");
                        sb.Append("'" + FnCurRate.MASTER_STATUS + "',");
                        sb.Append("'" + FnCurRate.Branch_code + "'");
                        sb.Append("'" + FnCurRate.Note + "')");
                      int i=_EzBusinessHelper.ExecuteNonQuery("insert into FNM_CURR_RATE(CMPYCODE,TO_CURRENCY_CODE,FROM_CURRENCY_CODE,SELL_RATE,BUY_RATE,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,ENTRY_DATE,MASTER_STATUS,Branchcode,NOTE) values(" + sb.ToString() + "");
                        _EzBusinessHelper.ActivityLog(FnCurRate.CMPYCODE, FnCurRate.UserName, "Add FNM_CURR_RATE", FnCurRate.FROM_CURRENCY_CODE, Environment.MachineName);
                        FnCurRate.SaveFlag = true;
                        FnCurRate.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        FnCurRate.SaveFlag = false;
                        FnCurRate.ErrorMessage = "Duplicate Record";
                    }
                    return FnCurRate;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FNM_CURR_RATE where CMPYCODE='" + FnCurRate.CMPYCODE + "' and FROM_CURRENCY_CODE='" + FnCurRate.FROM_CURRENCY_CODE + "' and format(ENTRY_DATE,'yyyy-MM-dd')='" + dtstr2 + "' and Flag=0");
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("BUY_RATE='" + FnCurRate.BUY_RATE + "',");
                    sb.Append("ENTRY_DATE='" + dtstr2 + "',");
                    sb.Append("MASTER_STATUS='" + FnCurRate.MASTER_STATUS + "',");
                    sb.Append("Note='" + FnCurRate.Note + "',");
                    sb.Append("TO_CURRENCY_CODE='" + FnCurRate.TO_CURRENCY_CODE + "',");
                    sb.Append("Branchcode='" + FnCurRate.Branch_code + "',");
                    sb.Append("SELL_RATE='" + FnCurRate.SELL_RATE + "',");
                    sb.Append("UPDATED_BY='" + FnCurRate.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "'");
                   
                    _EzBusinessHelper.ExecuteNonQuery("update FNM_CURR_RATE set  " + sb + " where CMPYCODE='" + FnCurRate.CMPYCODE + "' and FROM_CURRENCY_CODE='" + FnCurRate.FROM_CURRENCY_CODE + "' and format(ENTRY_DATE,'yyyy-MM-dd')='" + dtstr2 + "' and Flag=0");
                    _EzBusinessHelper.ActivityLog(FnCurRate.CMPYCODE, FnCurRate.UserName, "Update FNM_CURR_RATE", FnCurRate.FROM_CURRENCY_CODE, Environment.MachineName);

                    FnCurRate.SaveFlag = true;
                    FnCurRate.ErrorMessage = string.Empty;
                }
                else
                {
                    FnCurRate.SaveFlag = false;
                    FnCurRate.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FnCurRate.SaveFlag = false;


            }

            return FnCurRate;
        }

        public List<FNM_CURRENCYRateDetailNew> GetCURRENCYRateDetailList(string CmpyCode, string FROM_CURRENCY_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select ENTRY_DATE,BUY_RATE,SELL_RATE from FNM_CURR_RATE where FROM_CURRENCY_CODE='" + FROM_CURRENCY_CODE + "' and CMPYCODE='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNM_CURRENCYRateDetailNew> ObjList = new List<FNM_CURRENCYRateDetailNew>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNM_CURRENCYRateDetailNew()
                {
                    ENTRY_DATE =Convert.ToDateTime(dr["ENTRY_DATE"].ToString()),
                    BUY_RATE =Convert.ToDecimal(dr["BUY_RATE"].ToString()),
                    SELL_RATE = Convert.ToDecimal(dr["SELL_RATE"].ToString()),
                });
            }
            return ObjList;
        }
    }
}
