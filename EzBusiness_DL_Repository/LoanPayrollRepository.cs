using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EzBusiness_DL_Repository
{
    public class LoanPayrollRepository : ILoanPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteLons(string Code, string CmpyCode, string username)
        {
            int Lons = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRLM001 where CmpyCode='" + CmpyCode + "' and PRLM001_CODE='" + Code + "'");
            int lonA = _EzBusinessHelper.ExecuteScalar("select count(*) from  PRLA001 where LoanType='" + Code + "' and cmpycode='" + CmpyCode + "' ");
            if (Lons != 0 && lonA==0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Loan Application", Code, Environment.MachineName);
                _EzBusinessHelper.ExecuteNonQuery("update PRLM001 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRLM001_CODE='" + Code + "'");
                return true;
            }
            return false;
        }

        public List<Loan> GetLons(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRLM001 where CmpyCode='" + CmpyCode + "'and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Loan> ObjList = new List<Loan>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Loan()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    Act_code = dr["Act_code"].ToString(),
                    PRLM001_CODE = dr["PRLM001_CODE"].ToString(),
                    COUNTRY = dr["COUNTRY"].ToString(),
                    Name=dr["Name"].ToString()
                    



                });

            }
            return ObjList;
        }

        public LoanVM SaveLons(LoanVM Lons)
        {
            try
            {
                if (!Lons.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<LoanNew> ObjList = new List<LoanNew>();
                    ObjList.AddRange(Lons.LoanNew.Select(m => new LoanNew
                    {

                        PRLM001_CODE = m.PRLM001_CODE,
                        COUNTRY = m.COUNTRY,
                        CmpyCode = m.CmpyCode,
                        Name = m.Name,
                        Act_code = m.Act_code,
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Bbs1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRLM001 where CmpyCode='" + Lons.CmpyCode + "' and COUNTRY ='"+ ObjList[n - 1].COUNTRY + "' and PRLM001_CODE='" + ObjList[n - 1].PRLM001_CODE + "'");
                        if (Bbs1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Lons.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].PRLM001_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].COUNTRY + "',");                          
                            sb.Append("'" + ObjList[n - 1].Name + "',");
                            sb.Append("'" + ObjList[n - 1].Act_code + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into PRLM001(CmpyCode,PRLM001_CODE,COUNTRY,Name,Act_code) values(" + sb.ToString() + "");
                            Lons.SaveFlag = true;
                            Lons.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].PRLM001_CODE.ToString());

                            Lons.Drecord = Drecord;
                            Lons.SaveFlag = false;
                            Lons.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    //int Lons1 = _EzBusinessHelper.ExecuteScalar("Select count(*) from ML031 where CmpyCode='" + Lons.CmpyCode + "' and Code='" + Lons.Code + "'");



                    //if (Lons1 == 0)
                    //{
                    //    StringBuilder sb = new StringBuilder();
                    //    sb.Append("'" + Lons.CmpyCode + "',");
                    //    sb.Append("'" + Lons.Code + "',");
                    //    sb.Append("'" + Lons.Name + "',");
                    //    sb.Append("'" + Lons.UniCodeName + "')");
                    //    _EzBusinessHelper.ExecuteNonQuery("insert into ML031(CmpyCode,Code,Name,UniCodeName) values(" + sb.ToString() + "");
                    //    Lons.SaveFlag = true;
                    //    Lons.ErrorMessage = string.Empty;
                    //}
                    //else
                    //{
                    //    Lons.SaveFlag = false;
                    //    Lons.ErrorMessage = "Duplicate Record";
                    //}
                    return Lons;
                }
                var LonsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from PRLM001 where CmpyCode='" + Lons.CmpyCode + "' and COUNTRY ='" + Lons.COUNTRY + "' and PRLM001_CODE='" + Lons.PRLM001_CODE + "'and Flag=0");
                if (LonsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update PRLM001 set Name='" + Lons.Name + "',Act_code='" + Lons.Act_code + "' where CmpyCode='" + Lons.CmpyCode + "' and COUNTRY ='" + Lons.COUNTRY + "' and PRLM001_CODE='" + Lons.PRLM001_CODE + "'");
                    Lons.SaveFlag = true;
                    Lons.ErrorMessage = string.Empty;
                }
                else
                {
                    Lons.SaveFlag = false;
                    Lons.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Lons.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Lons;
        }
    }
}
