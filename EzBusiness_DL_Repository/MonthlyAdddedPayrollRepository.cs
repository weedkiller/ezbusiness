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
using System.Transactions;

namespace EzBusiness_DL_Repository
{
    public class MonthlyAdddedPayrollRepository : IMonthlyAdddedPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public List<Employee> GetEmpCodeList(string CmpyCode)
        {
            return drop.GetEmpCodes(CmpyCode, "E");
        }

        public List<MonthlyAdddeddet1> GetMonthlyADGrid(string CmpyCode, string PRADN001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRADN002 where CmpyCode='" + CmpyCode + "' and PRADN001_CODE='" + PRADN001_CODE + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MonthlyAdddeddet1> ObjList = new List<MonthlyAdddeddet1>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MonthlyAdddeddet1()
                {

                    ADN_Act_code = dr["ADN_Act_code"].ToString(),
                    ADN_Amount = Convert.ToDecimal(dr["ADN_Amount"].ToString()),
                    EmpCode = dr["EmpCode"].ToString(),
                    EmpName = dr["EmpName"].ToString(),
                    Remarks = dr["Remarks"].ToString(),
                    T_type = dr["T_type"].ToString(),
                });
            }
            return ObjList;
        }

        public MonthlyAdddedVM SaveMonthlyAD(MonthlyAdddedVM MonthlyAD)
        {

            string dtstr1 = null;
            DateTime dte;

            dte = Convert.ToDateTime(MonthlyAD.Entry_Date.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            int n;

            if (!MonthlyAD.EditFlag)
            {
                MonthlyAdddedMst pt = new MonthlyAdddedMst();
                int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + MonthlyAD.CmpyCode + "' and Code='PRADN' ");

                //pt.PRBM001_code = string.Concat("PRBM", "-", (pno + 1).ToString().PadLeft(4, '0')).ToString();                                
                List<MonthlyAdddeddet1> ObjList = new List<MonthlyAdddeddet1>();
                ObjList.AddRange(MonthlyAD.MonthlyAddded.Select(m => new MonthlyAdddeddet1
                {
                    ADN_Act_code = m.ADN_Act_code,
                    ADN_Amount = m.ADN_Amount,
                    EmpCode = m.EmpCode,
                    EmpName = m.EmpName,
                    Remarks = m.Remarks,
                    T_type = m.T_type,
                }).ToList());

                try
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        _EzBusinessHelper.ExecuteNonQuery("insert into PRADN001(PRADN001_CODE,COUNTRY,CmpyCode,Entry_Date,TYear,TMonth) values('" + MonthlyAD.PRADN001_CODE + "','" + MonthlyAD.COUNTRY + "','" + MonthlyAD.CmpyCode + "','" + dtstr1 + "','" + MonthlyAD.TYear + "','" + MonthlyAD.TMonth + "')");
                        n = ObjList.Count;


                        while (n > 0)
                        {
                            _EzBusinessHelper.ExecuteNonQuery("insert into PRADN002(PRADN001_CODE,CmpyCode,EmpCode,EmpName,ADN_Amount,ADN_Act_code,T_type,Remarks) values('" + MonthlyAD.PRADN001_CODE + "','" + MonthlyAD.CmpyCode + "','" + ObjList[n - 1].EmpCode + "','" + ObjList[n - 1].EmpName + "','" + ObjList[n - 1].ADN_Amount + "','" + ObjList[n - 1].ADN_Act_code + "','" + ObjList[n - 1].T_type + "','" + ObjList[n - 1].Remarks + "')");
                            n = n - 1;
                        }
                        _EzBusinessHelper.ExecuteNonQuery("UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + MonthlyAD.CmpyCode + "' and Code='PRADN'");

                        MonthlyAD.SaveFlag = true;
                        MonthlyAD.ErrorMessage = string.Empty;
                        scope.Complete();
                    }
                }
                catch (Exception)
                {

                    MonthlyAD.SaveFlag = false;
                    MonthlyAD.ErrorMessage = "error occur";
                }

            }
            else
            {


                n = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRADN001 where CmpyCode='" + MonthlyAD.CmpyCode + "' and PRADN001_CODE='" + MonthlyAD.PRADN001_CODE + "' ");

                if (n != 0)
                {


                    MonthlyAdddedMst pt = new MonthlyAdddedMst();
                    //int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + MonthlyAD.CmpyCode + "' and Code='PRBM' ");

                    //pt.PRBM001_code = string.Concat("PRBM", "-", (pno + 1).ToString().PadLeft(4, '0')).ToString();                                
                    List<MonthlyAdddeddet1> ObjList = new List<MonthlyAdddeddet1>();
                    ObjList.AddRange(MonthlyAD.MonthlyAddded.Select(m => new MonthlyAdddeddet1
                    {

                        ADN_Act_code = m.ADN_Act_code,
                        ADN_Amount = m.ADN_Amount,
                        EmpCode = m.EmpCode,
                        EmpName = m.EmpName,
                        Remarks = m.Remarks,
                        T_type = m.T_type,



                    }).ToList());

                    try
                    {
                        using (TransactionScope scope1 = new TransactionScope())
                        {

                            _EzBusinessHelper.ExecuteNonQuery("delete from PRADN001 where CmpyCode='" + MonthlyAD.CmpyCode + "' and PRADN001_CODE='" + MonthlyAD.PRADN001_CODE + "'");
                            _EzBusinessHelper.ExecuteNonQuery("delete from PRADN002 where CmpyCode='" + MonthlyAD.CmpyCode + "' and PRADN001_CODE='" + MonthlyAD.PRADN001_CODE + "'");
                            _EzBusinessHelper.ExecuteNonQuery("insert into PRADN001(PRADN001_CODE,COUNTRY,CmpyCode,Entry_Date,TYear,TMonth) values('" + MonthlyAD.PRADN001_CODE + "','" + MonthlyAD.COUNTRY + "','" + MonthlyAD.CmpyCode + "','" + dtstr1 + "','" + MonthlyAD.TYear + "','" + MonthlyAD.TMonth + "')");
                            n = ObjList.Count;
                            while (n > 0)
                            {
                                _EzBusinessHelper.ExecuteNonQuery("insert into PRADN002(PRADN001_CODE,CmpyCode,EmpCode,EmpName,ADN_Amount,ADN_Act_code,T_type,Remarks) values('" + MonthlyAD.PRADN001_CODE + "','" + MonthlyAD.CmpyCode + "','" + ObjList[n - 1].EmpCode + "','" + ObjList[n - 1].EmpName + "','" + ObjList[n - 1].ADN_Amount + "','" + ObjList[n - 1].ADN_Act_code + "','" + ObjList[n - 1].T_type + "','" + ObjList[n - 1].Remarks + "')");
                                n = n - 1;
                            }
                            MonthlyAD.SaveFlag = true;
                            MonthlyAD.ErrorMessage = string.Empty;
                            scope1.Complete();
                        }
                    }
                    catch (Exception)
                    {

                        MonthlyAD.SaveFlag = false;
                        MonthlyAD.ErrorMessage = "error occur";
                    }
                }
                else
                {
                    MonthlyAD.SaveFlag = true;
                    MonthlyAD.ErrorMessage = "Error occur";
                }
            }

            return MonthlyAD;
        }

        public MonthlyAdddedVM GetMonthlyADEdit(string CmpyCode, string PRADN001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRADN001 where CmpyCode='" + CmpyCode + "' and PRADN001_CODE='" + PRADN001_CODE + "' and Flag=0 ");
            dt = ds.Tables[0];
            MonthlyAdddedVM MonthlyAD = new MonthlyAdddedVM();
            foreach (DataRow dr in dt.Rows)
            {
                MonthlyAD.Entry_Date = Convert.ToDateTime(dr["Entry_Date"].ToString());
                MonthlyAD.TMonth = Convert.ToInt32(dr["TMonth"].ToString());
                MonthlyAD.TYear = Convert.ToInt32(dr["TYear"].ToString());
                MonthlyAD.PRADN001_CODE = dr["PRADN001_CODE"].ToString();
                //MonthlyAD.MonthlyAddded = GetMonthlyADGrid(CmpyCode, PRADN001_CODE);               
            }
            return MonthlyAD;
        }

        public bool DeleteMonthlyAD(string CmpyCode, string PRADN001_CODE, string username)
        {

            int Bns = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRADN001 where CmpyCode='" + CmpyCode + "' and PRADN001_CODE='" + PRADN001_CODE + "'");
            if (Bns != 0)
            {
                _EzBusinessHelper.ExecuteNonQuery("update PRADN001 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRADN001_CODE='" + PRADN001_CODE + "'");
                _EzBusinessHelper.ExecuteNonQuery("update PRADN002 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRADN001_CODE='" + PRADN001_CODE + "'");
                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Monthly", PRADN001_CODE, Environment.MachineName);
                return true;
            }
            return false;
        }

        public List<MonthlyAdddedVM> GetMonthlyAdddedList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRADN001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MonthlyAdddedVM> ObjList = new List<MonthlyAdddedVM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MonthlyAdddedVM()
                {
                    PRADN001_CODE = dr["PRADN001_CODE"].ToString(),
                    Entry_Date = Convert.ToDateTime(dr["Entry_Date"].ToString()),
                    TMonth = Convert.ToInt32(dr["TMonth"].ToString()),
                    TYear = Convert.ToInt32(dr["TYear"].ToString()),

                });
            }
            return ObjList;
        }
    }
}
