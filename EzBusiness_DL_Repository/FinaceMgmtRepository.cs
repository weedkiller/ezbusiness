using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FinaceMgmt;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EzBusiness_DL_Repository
{
    public class FinaceMgmtRepository : IFinaceMgmtRepository

    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteExchange(string CurCode, string CmpyCode, string username)
        {
            int Exchange = _EzBusinessHelper.ExecuteScalar("Select count(*) from MEXR017 where CmpyCode='" + CmpyCode + "' and CurCode='" + CurCode + "'");
            if (Exchange != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Finance Master", CurCode, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("delete from MEXR017 where CmpyCode='" + CmpyCode + "' and CurCode='" + CurCode + "'");
              //  return true;
            }
            return false;
        }

        public List<ExchangeRates> GetExchange(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MEXR017 where CmpyCode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ExchangeRates> ObjList = new List<ExchangeRates>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ExchangeRates()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    CurCode = dr["CurCode"].ToString(),
                    CurRate = Convert.ToDecimal(dr["CurRate"]),
                    CurName = dr["CurName"].ToString()
                    

                });

            }
            return ObjList;
        }

        public ExchangeRateVM SaveExchange(ExchangeRateVM Exchange)
        {
            try
            {
                if (!Exchange.EditFlag)
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select count(*) as [count1] from MEXR017 where CmpyCode='" +  Exchange.CmpyCode + "' and CurCode='" + Exchange.CurCode + "'");
                    dt = ds.Tables[0];


                    int Exchange1=0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Exchange1 = int.Parse(dr["count1"].ToString());
                    }
                    
                    if (Exchange1 == 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("'"+Exchange.CmpyCode +"',");
                        sb.Append("'" + Exchange.CurCode + "',");                        
                        sb.Append("'" + Exchange.CurName + "',");
                        sb.Append("'" + Exchange.CurRate + "')");
                        _EzBusinessHelper.ExecuteNonQuery("insert into MEXR017(CmpyCode,CurCode,CurName,CurRate) values(" + sb.ToString()+ "");
                        Exchange.SaveFlag = true;
                        Exchange.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Exchange.SaveFlag = false;
                        Exchange.ErrorMessage = "Duplicate Record";
                    }
                    return Exchange;
                }
                var ExchangeEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from MEXR017 where CmpyCode='" + Exchange.CmpyCode + "' and CurCode='" + Exchange.CurCode + "'");
                if (ExchangeEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update MEXR017 set CmpyCode='" + Exchange.CmpyCode + "',CurCode='" + Exchange.CurCode + "',CurName='" + Exchange.CurName + "',CurRate='" + Exchange.CurRate + "' where CmpyCode='" + Exchange.CmpyCode + "' and CurCode='" + Exchange.CurCode + "'");
                    Exchange.SaveFlag = true;
                    Exchange.ErrorMessage = string.Empty;
                }
                else
                {
                    Exchange.SaveFlag = false;
                    Exchange.ErrorMessage = "Record not available";
                }

            }
            catch
            {
                Exchange.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Exchange;
        }
    }
}
