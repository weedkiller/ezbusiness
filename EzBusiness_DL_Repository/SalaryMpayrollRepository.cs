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
    public class SalaryMpayrollRepository : ISalaryMpayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public List<SalaryM> GetSryList(string CMPYCODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRSMS001 where CmpyCode='" + CMPYCODE + "' and  Flag=0 ");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<SalaryM> ObjList = new List<SalaryM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new SalaryM()
                {
                    CMPYCODE = dr["CMPYCODE"].ToString(),
                    PRSM001_CODE = dr["PRSM001_CODE"].ToString(),
                    DIVISION = dr["DIVISION"].ToString(),
                    COUNTRY = dr["COUNTRY"].ToString(),
                    EMPCODE = dr["EMPCODE"].ToString(),
                    Entery_date = Convert.ToDateTime(dr["Entery_date"]),
                    Effect_From = Convert.ToDateTime(dr["Effect_From"]),
                    BASIC = Convert.ToDecimal(dr["BASIC"]),
                    BASICCAPTION = dr["BASICCAPTION"].ToString(),
                    BASICACT = dr["BASICACT"].ToString(),
                    HRA = Convert.ToDecimal(dr["HRA"]),
                    HRACAPTION = dr["HRACAPTION"].ToString(),
                    HRAACT = dr["HRAACT"].ToString(),
                    DA = Convert.ToDecimal(dr["DA"]),
                    DACAPTION = dr["DACAPTION"].ToString(),
                    DAACT = dr["DAACT"].ToString(),
                    TELE = Convert.ToDecimal(dr["TELE"]),
                    TELECAPTION = dr["TELECAPTION"].ToString(),
                    TELEACT = dr["TELEACT"].ToString(),
                    TRANS = Convert.ToDecimal(dr["TRANS"]),
                    TRANSCAPTION = dr["TRANSCAPTION"].ToString(),
                    TRANSACT = dr["TRANSACT"].ToString(),
                    CAR = Convert.ToDecimal(dr["CAR"]),
                    CARCAPTION = dr["CARCAPTION"].ToString(),
                    CARACT = dr["CARACT"].ToString(),
                    ALLOWANCE1 = Convert.ToDecimal(dr["ALLOWANCE1"]),
                    ALLOWANCE1CAPTION = dr["ALLOWANCE1CAPTION"].ToString(),
                    ALLOWANCE1ACT = dr["ALLOWANCE1ACT"].ToString(),
                    ALLOWANCE2 = Convert.ToDecimal(dr["ALLOWANCE2"]),
                    ALLOWANCE2CAPTION = dr["ALLOWANCE2CAPTION"].ToString(),
                    ALLOWANCE2ACT = dr["ALLOWANCE2ACT"].ToString(),
                    ALLOWANCE3 = Convert.ToDecimal(dr["ALLOWANCE3"]),
                    ALLOWANCE3CAPTION = dr["ALLOWANCE3CAPTION"].ToString(),
                    ALLOWANCE3ACT = dr["ALLOWANCE3ACT"].ToString(),
                    TOTAL = Convert.ToDecimal(dr["TOTAL"]),


                });

            }
            return ObjList;
        }

        public SalarMpayrollVM SaveSry(SalarMpayrollVM Sry)
        {
            int n;
            string dtstr, dtstr1 = null;
            try
            {
                if (!Sry.EditFlag)
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select count(*) as [count1] from PRSMS001 where CmpyCode='" + Sry.CMPYCODE + "' and PRSM001_CODE='" + Sry.PRSM001_CODE + "'");
                    dt = ds.Tables[0];


                    int Sry1 = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Sry1 = int.Parse(dr["count1"].ToString());
                    }

                    if (Sry1 == 0)
                    {


                        DateTime dt1 = Convert.ToDateTime(Sry.Entery_date.ToString());

                        dtstr = dt1.ToString("yyyy-MM-dd");

                        DateTime dt2 = Convert.ToDateTime(Sry.Effect_From.ToString());

                        dtstr1 = dt2.ToString("yyyy-MM-dd");

                        StringBuilder sb = new StringBuilder();
                        //sb.Append("'" + Sry.PRSM001UID + "',");
                        sb.Append("'" + Sry.PRSM001_CODE + "',");
                        sb.Append("'" + Sry.CMPYCODE + "',");
                        sb.Append("'" + Sry.DIVISION + "',");
                        sb.Append("'" + Sry.COUNTRY + "',");
                        sb.Append("'" + Sry.EMPCODE + "',");
                        sb.Append("'" + dtstr + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + Sry.BASIC + "',");
                        sb.Append("'" + Sry.BASICCAPTION + "',");
                        sb.Append("'" + Sry.BASICACT + "',");
                        sb.Append("'" + Sry.HRA + "',");
                        sb.Append("'" + Sry.HRACAPTION + "',");
                        sb.Append("'" + Sry.HRAACT + "',");
                        sb.Append("'" + Sry.DA + "',");
                        sb.Append("'" + Sry.DACAPTION + "',");
                        sb.Append("'" + Sry.DAACT + "',");
                        sb.Append("'" + Sry.TELE + "',");
                        sb.Append("'" + Sry.TELECAPTION + "',");
                        sb.Append("'" + Sry.TELEACT + "',");
                        sb.Append("'" + Sry.TRANS + "',");
                        sb.Append("'" + Sry.TRANSCAPTION + "',");
                        sb.Append("'" + Sry.TRANSACT + "',");
                        sb.Append("'" + Sry.CAR + "',");
                        sb.Append("'" + Sry.CARCAPTION + "',");
                        sb.Append("'" + Sry.CARACT + "',");
                        sb.Append("'" + Sry.ALLOWANCE1 + "',");
                        sb.Append("'" + Sry.ALLOWANCE1CAPTION + "',");
                        sb.Append("'" + Sry.ALLOWANCE1ACT + "',");
                        sb.Append("'" + Sry.ALLOWANCE2 + "',");
                        sb.Append("'" + Sry.ALLOWANCE2CAPTION + "',");
                        sb.Append("'" + Sry.ALLOWANCE2ACT + "',");
                        sb.Append("'" + Sry.ALLOWANCE3 + "',");
                        sb.Append("'" + Sry.ALLOWANCE3CAPTION + "',");
                        sb.Append("'" + Sry.ALLOWANCE3ACT + "',");
                        sb.Append("'" + Sry.TOTAL + "')");


                        //List<SalaryGrid> ObjList = new List<SalaryGrid>();

                        //ObjList.AddRange(Sry.SalaryMas.Select(m => new SalaryGrid
                        //{

                        //    CmpyCode = m.CmpyCode,
                        //    Code = m.Code,
                        //    Amount = m.Amount.Value,
                        //    Name = m.Name,                            
                        //    Accountcode = m.Accountcode

                        //    //CmpyCode = po.CmpyCode,
                        //    //MRCode = pt.MRCode, //response.MRCode,

                        //}).ToList());

                        using (TransactionScope scope1 = new TransactionScope())
                        {
                            _EzBusinessHelper.ExecuteNonQuery("insert into PRSMS001(PRSM001_CODE,CMPYCODE,DIVISION,COUNTRY,EMPCODE,Entery_date,Effect_From,BASIC,BASICCAPTION,BASICACT,HRA,HRACAPTION,HRAACT,DA,DACAPTION,DAACT,TELE,TELECAPTION,TELEACT,TRANS,TRANSCAPTION,TRANSACT,CAR,CARCAPTION,CARACT,ALLOWANCE1,ALLOWANCE1CAPTION,ALLOWANCE1ACT,ALLOWANCE2,ALLOWANCE2CAPTION,ALLOWANCE2ACT,ALLOWANCE3,ALLOWANCE3CAPTION,ALLOWANCE3ACT,TOTAL) values(" + sb.ToString() + "");


                            _EzBusinessHelper.ActivityLog(Sry.CMPYCODE, Sry.UserName, "Add Salary Master", Sry.PRSM001_CODE, Environment.MachineName);
                       
                        //n = ObjList.Count;

                        //while (n > 0)
                        //{
                        //    _EzBusinessHelper.ExecuteNonQuery("insert into SHH004(CmpyCode,Code,Name,Accountcode,Amount) values('" + ObjList[n - 1].CmpyCode + "','" + ObjList[n - 1].Code + "','" + ObjList[n - 1].Name + "','" + ObjList[n - 1].Accountcode + "','" + ObjList[n - 1].Amount + "')");
                        //    n = n - 1;
                        //}
                        Sry.SaveFlag = true;
                        Sry.ErrorMessage = string.Empty;
                            scope1.Complete();
                        }
                    }
                }

                else
                {
                    n = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSMS001 where CmpyCode='" + Sry.CMPYCODE + "' and PRSM001_CODE='" + Sry.PRSM001_CODE + "' ");

                    using (TransactionScope scope = new TransactionScope())
                    {

                        _EzBusinessHelper.ExecuteNonQuery("Delete from PRSMS001 where CmpyCode='" + Sry.CMPYCODE + "' and PRSM001_CODE='" + Sry.PRSM001_CODE + "' ");
                        //_EzBusinessHelper.ExecuteNonQuery("Delete from SHH004 where CmpyCode='" + Sry.CMPYCODE + "' and PRSM001_CODE='" + Sry.PRSM001_CODE + "' ");
                        DateTime dt1 = Convert.ToDateTime(Sry.Entery_date.ToString());

                        dtstr = dt1.ToString("yyyy-MM-dd");

                        DateTime dt2 = Convert.ToDateTime(Sry.Effect_From.ToString());

                        dtstr1 = dt2.ToString("yyyy-MM-dd");


                        StringBuilder sb = new StringBuilder();
                        //sb.Append("'" + Sry.PRSM001UID + "',");
                        sb.Append("'" + Sry.PRSM001_CODE + "',");
                        sb.Append("'" + Sry.CMPYCODE + "',");
                        sb.Append("'" + Sry.DIVISION + "',");
                        sb.Append("'" + Sry.COUNTRY + "',");
                        sb.Append("'" + Sry.EMPCODE + "',");
                        sb.Append("'" + dtstr + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + Sry.BASIC + "',");
                        sb.Append("'" + Sry.BASICCAPTION + "',");
                        sb.Append("'" + Sry.BASICACT + "',");
                        sb.Append("'" + Sry.HRA + "',");
                        sb.Append("'" + Sry.HRACAPTION + "',");
                        sb.Append("'" + Sry.HRAACT + "',");
                        sb.Append("'" + Sry.DA + "',");
                        sb.Append("'" + Sry.DACAPTION + "',");
                        sb.Append("'" + Sry.DAACT + "',");
                        sb.Append("'" + Sry.TELE + "',");
                        sb.Append("'" + Sry.TELECAPTION + "',");
                        sb.Append("'" + Sry.TELEACT + "',");
                        sb.Append("'" + Sry.TRANS + "',");
                        sb.Append("'" + Sry.TRANSCAPTION + "',");
                        sb.Append("'" + Sry.TRANSACT + "',");
                        sb.Append("'" + Sry.CAR + "',");
                        sb.Append("'" + Sry.CARCAPTION + "',");
                        sb.Append("'" + Sry.CARACT + "',");
                        sb.Append("'" + Sry.ALLOWANCE1 + "',");
                        sb.Append("'" + Sry.ALLOWANCE1CAPTION + "',");
                        sb.Append("'" + Sry.ALLOWANCE1ACT + "',");
                        sb.Append("'" + Sry.ALLOWANCE2 + "',");
                        sb.Append("'" + Sry.ALLOWANCE2CAPTION + "',");
                        sb.Append("'" + Sry.ALLOWANCE2ACT + "',");
                        sb.Append("'" + Sry.ALLOWANCE3 + "',");
                        sb.Append("'" + Sry.ALLOWANCE3CAPTION + "',");
                        sb.Append("'" + Sry.ALLOWANCE3ACT + "',");
                        sb.Append("'" + Sry.TOTAL + "')");


                        //List<SalaryGrid> ObjList = new List<SalaryGrid>();

                        //ObjList.AddRange(Sry.SalaryMas.Select(m => new SalaryGrid
                        //{

                        //    CmpyCode = m.CmpyCode,
                        //    Code = m.Code,
                        //    Amount = m.Amount.Value,
                        //    Name = m.Name,
                        //    Accountcode = m.Accountcode

                        //    //CmpyCode = po.CmpyCode,
                        //    //MRCode = pt.MRCode, //response.MRCode,

                        //}).ToList());

                        _EzBusinessHelper.ExecuteNonQuery("insert into PRSMS001(PRSM001_CODE,CMPYCODE,DIVISION,COUNTRY,EMPCODE,Entery_date,Effect_From,BASIC,BASICCAPTION,BASICACT,HRA,HRACAPTION,HRAACT,DA,DACAPTION,DAACT,TELE,TELECAPTION,TELEACT,TRANS,TRANSCAPTION,TRANSACT,CAR,CARCAPTION,CARACT,ALLOWANCE1,ALLOWANCE1CAPTION,ALLOWANCE1ACT,ALLOWANCE2,ALLOWANCE2CAPTION,ALLOWANCE2ACT,ALLOWANCE3,ALLOWANCE3CAPTION,ALLOWANCE3ACT,TOTAL) values(" + sb.ToString() + "");

                        _EzBusinessHelper.ActivityLog(Sry.CMPYCODE, Sry.UserName, "Update Salary Master", Sry.PRSM001_CODE, Environment.MachineName);

                        //n = ObjList.Count;

                        //while (n > 0)
                        //{
                        //    _EzBusinessHelper.ExecuteNonQuery("insert into SHH004(CmpyCode,Code,Name,Accountcode,Amount) values('" + ObjList[n - 1].CmpyCode + "','" + ObjList[n - 1].Code + "','" + ObjList[n - 1].Name + "','" + ObjList[n - 1].Accountcode + "','" + ObjList[n - 1].Amount + "')");
                        //    n = n - 1;
                        //}

                        Sry.ErrorMessage = string.Empty;
                        Sry.SaveFlag = true;
                        scope.Complete();
                    }
                }

                return Sry;

            }




            catch
            {
                Sry.SaveFlag = false;
                Sry.ErrorMessage = "Error Occur";

            }
            return Sry;

        }

   

        public SalarMpayrollVM GetSalaryEdit(string CMPYCODE, string PRSM001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRSMS001 where CmpyCode='" + CMPYCODE + "' and PRSM001_CODE='" + PRSM001_CODE + "' and Flag=0 ");

            dt = ds.Tables[0];
            SalarMpayrollVM pr = new SalarMpayrollVM();
            foreach (DataRow dr in dt.Rows)
            {
                CMPYCODE = dr["CMPYCODE"].ToString();
                //pr.PRSM001UID = Convert.ToInt16(dr["PRSM001UID"].ToString());
                pr.PRSM001_CODE = dr["PRSM001_CODE"].ToString();
                pr.DIVISION = dr["DIVISION"].ToString();
                pr.COUNTRY = dr["COUNTRY"].ToString();
                pr.EMPCODE = dr["EMPCODE"].ToString();
                pr.Entery_date = Convert.ToDateTime(dr["Entery_date"].ToString());
                pr.Effect_From = Convert.ToDateTime(dr["Effect_From"].ToString());
                pr.BASIC = Convert.ToDecimal(dr["BASIC"].ToString());
                pr.BASICCAPTION = dr["BASICCAPTION"].ToString();
                pr.BASICACT = dr["BASICACT"].ToString();
                pr.HRA = Convert.ToDecimal(dr["HRA"].ToString());
                pr.HRACAPTION = dr["HRACAPTION"].ToString();
                pr.HRAACT = dr["HRAACT"].ToString();
                pr.DA = Convert.ToDecimal(dr["DA"].ToString());
                pr.DACAPTION = dr["DACAPTION"].ToString();
                pr.DAACT = dr["DAACT"].ToString();
                pr.TELE = Convert.ToDecimal(dr["TELE"].ToString());
                pr.TELECAPTION = dr["TELECAPTION"].ToString();
                pr.TELEACT = dr["TELEACT"].ToString();
                pr.TRANS = Convert.ToDecimal(dr["TRANS"].ToString());
                pr.TRANSCAPTION = dr["TRANSCAPTION"].ToString();
                pr.TRANSACT = dr["TRANSACT"].ToString();
                pr.CAR = Convert.ToDecimal(dr["CAR"].ToString());
                pr.CARCAPTION = dr["CARCAPTION"].ToString();
                pr.CARACT = dr["CARACT"].ToString();
                pr.ALLOWANCE1 = Convert.ToDecimal(dr["ALLOWANCE1"].ToString());
                pr.ALLOWANCE1CAPTION = dr["ALLOWANCE1CAPTION"].ToString();
                pr.ALLOWANCE1ACT = dr["ALLOWANCE1ACT"].ToString();
                pr.ALLOWANCE2 = Convert.ToDecimal(dr["ALLOWANCE2"].ToString());
                pr.ALLOWANCE2CAPTION = dr["ALLOWANCE2CAPTION"].ToString();
                pr.ALLOWANCE2ACT = dr["ALLOWANCE2ACT"].ToString();
                pr.ALLOWANCE3 = Convert.ToDecimal(dr["ALLOWANCE3"].ToString());
                pr.ALLOWANCE3CAPTION = dr["ALLOWANCE3CAPTION"].ToString();
                pr.ALLOWANCE3ACT = dr["ALLOWANCE3ACT"].ToString();
                pr.TOTAL = Convert.ToDecimal(dr["TOTAL"].ToString());

            }
            return pr;
        }

        public List<Employee> GetEmpCodes(string CMPYCODE)
        {
            return drop.GetEmpCodes(CMPYCODE, "SM");
        }

        public bool DeleteSry(string CMPYCODE, string PRSM001_CODE, string username)
        {

            int Sals = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSMS001 where CmpyCode='" + CMPYCODE + "' and PRSM001_CODE='" + PRSM001_CODE + "'");
            if (Sals != 0)
            {

                _EzBusinessHelper.ActivityLog(CMPYCODE, username, "Delete Salary Process", PRSM001_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update PRSMS001 set Flag=1 where CmpyCode='" + CMPYCODE + "' and PRSM001_CODE='" + PRSM001_CODE + "'");
                //_EzBusinessHelper.ExecuteNonQuery("delete from SHH004 where CmpyCode='" + CMPYCODE + "' and PRSM001_CODE='" + PRSM001_CODE + "'");

               // return true;
            }
            return false;
        }

        public List<SalaryMGrid> GetSalGrid(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select A.Code,A.Name,B.Accountcode from SHH004 A, ACCTBL001 B where A.cmpyCode ='" + CmpyCode + "' and B.Code = A.Code" );
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<SalaryMGrid> ObjList = new List<SalaryMGrid>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new SalaryMGrid()
                {
                    
                    Code = dr["Code"].ToString(),                    
                    Name = dr["Name"].ToString(),
                    Accountcode = dr["Accountcode"].ToString(),
                    //Amount = Convert.ToDecimal(dr["Amount"]),

                });
            }
            return ObjList;
        }

        //public List<SalaryMGrid> GetAccountCodes(string CmpyCode)
        //{

        //    ds = _EzBusinessHelper.ExecuteDataSet("SELECT Accountcode FROM SHH004 WHERE Cmpycode='" + CmpyCode + "'");
        //    dt = ds.Tables[0];
        //    DataRowCollection drc = dt.Rows;
        //    List<SalaryMGrid> ObjList = new List<SalaryMGrid>();
        //    foreach (DataRow dr in drc)
        //    {
        //        ObjList.Add(new SalaryMGrid()
        //        {
        //            Accountcode = dr["Accountcode"].ToString(),                    
        //        });

        //    }
        //    return ObjList;
        //}
    }
}
