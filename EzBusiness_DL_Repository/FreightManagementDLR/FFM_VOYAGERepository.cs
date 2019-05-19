using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
    public class FFM_VOYAGERepository
    {
        System.Data.DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public List<FFM_VOYAGEA> GetFFM_VoYAGEAList(string CMPYCODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select * from FFM_VOYAGE01 yg1 inner join FFM_VOYAGE02 yg2 on yg1.FFM_VOYAGE01_CODE=yg2.FFM_VOYAGE01_CODE and  yg1.CMPYCODE=yg2.cmpycode");
            List<FFM_VOYAGEA> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<FFM_VOYAGEA>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new FFM_VOYAGEA()
                    {
                        CMPYCODE = dr["CMPYCODE"].ToString(),
                        //PRSM001_CODE = dr["PRSM001_CODE"].ToString(),
                        //DIVISION = dr["DIVISION"].ToString(),
                        FFM_VESSEL_CODE=dr["FFM_VESSEL_CODE"].ToString(),
                        FFM_VOYAGE01_CODE=dr["FFM_VOYAGE01_CODE"].ToString(),
                    });

                }
            }
            return ObjList;
        }

        public  FFM_VOYAGE_VM SaveFFM_Voyage(FFM_VOYAGE_VM gg)
        {
            int n;
            string dtstr, dtstr1 = null;
            try
            {
                if (!gg.EditFlag)
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select count(*) as [count1] from FFM_VOYAGE01 where CmpyCode='" + gg.CMPYCODE + "' and FFM_VOYAGE01_CODE='" + gg.FFM_VOYAGE01_CODE + "'");
                    dt = ds.Tables[0];
                    int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + gg.CMPYCODE + "' and Code='PRSM' ");

                    int gg1 = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        gg1 = int.Parse(dr["count1"].ToString());
                    }

                    if (gg1 == 0)
                    {


                        DateTime dt1 = Convert.ToDateTime(gg.CREATED_ON.ToString());

                        dtstr = dt1.ToString("yyyy-MM-dd");

                        DateTime dt2 = Convert.ToDateTime(gg.CREATED_ON.ToString());

                        dtstr1 = dt2.ToString("yyyy-MM-dd");

                        StringBuilder sb = new StringBuilder();
                        //sb.Append("'" + gg.PRSM001UID + "',");
                        sb.Append("'" + gg.FFM_VESSEL_CODE + "',");
                        sb.Append("'" + gg.CMPYCODE + "',");
                        sb.Append("'" + gg.FFM_VOYAGE01_CODE + "',");
                        sb.Append("'" + gg.COUNTRY + "',");
                        sb.Append("'" + gg.EMPCODE + "',");
                        sb.Append("'" + dtstr + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + gg.BASIC + "',");
                        sb.Append("'" + gg.BASICCAPTION + "',");
                        sb.Append("'" + gg.BASICACT + "',");
                        sb.Append("'" + gg.HRA + "',");
                        sb.Append("'" + gg.HRACAPTION + "',");
                        sb.Append("'" + gg.HRAACT + "',");
                        sb.Append("'" + gg.DA + "',");
                        sb.Append("'" + gg.DACAPTION + "',");
                        sb.Append("'" + gg.DAACT + "',");
                        sb.Append("'" + gg.TELE + "',");
                        sb.Append("'" + gg.TELECAPTION + "',");
                        sb.Append("'" + gg.TELEACT + "',");
                        sb.Append("'" + gg.TRANS + "',");
                        sb.Append("'" + gg.TRANSCAPTION + "',");
                        sb.Append("'" + gg.TRANSACT + "',");
                        sb.Append("'" + gg.CAR + "',");
                        sb.Append("'" + gg.CARCAPTION + "',");
                        sb.Append("'" + gg.CARACT + "',");
                        sb.Append("'" + gg.ALLOWANCE1 + "',");
                        sb.Append("'" + gg.ALLOWANCE1CAPTION + "',");
                        sb.Append("'" + gg.ALLOWANCE1ACT + "',");
                        sb.Append("'" + gg.ALLOWANCE2 + "',");
                        sb.Append("'" + gg.ALLOWANCE2CAPTION + "',");
                        sb.Append("'" + gg.ALLOWANCE2ACT + "',");
                        sb.Append("'" + gg.ALLOWANCE3 + "',");
                        sb.Append("'" + gg.ALLOWANCE3CAPTION + "',");
                        sb.Append("'" + gg.ALLOWANCE3ACT + "',");
                        sb.Append("'" + gg.TOTAL + "')");


                        //List<SalaryGrid> ObjList = new List<SalaryGrid>();

                        //ObjList.AddRange(gg.SalaryMas.Select(m => new SalaryGrid
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

                            _EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + gg.CMPYCODE + "' and Code='PRSM'");

                            _EzBusinessHelper.ActivityLog(gg.CMPYCODE, gg.UserName, "Add Salary Master", gg.PRSM001_CODE, Environment.MachineName);

                            //n = ObjList.Count;

                            //while (n > 0)
                            //{
                            //    _EzBusinessHelper.ExecuteNonQuery("insert into SHH004(CmpyCode,Code,Name,Accountcode,Amount) values('" + ObjList[n - 1].CmpyCode + "','" + ObjList[n - 1].Code + "','" + ObjList[n - 1].Name + "','" + ObjList[n - 1].Accountcode + "','" + ObjList[n - 1].Amount + "')");
                            //    n = n - 1;
                            //}
                            gg.SaveFlag = true;
                            gg.ErrorMessage = string.Empty;
                            scope1.Complete();
                        }
                    }
                }

                else
                {
                    n = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSMS001 where CmpyCode='" + gg.CMPYCODE + "' and PRSM001_CODE='" + gg.PRSM001_CODE + "' ");

                    using (TransactionScope scope = new TransactionScope())
                    {

                        _EzBusinessHelper.ExecuteNonQuery("Delete from PRSMS001 where CmpyCode='" + gg.CMPYCODE + "' and PRSM001_CODE='" + gg.PRSM001_CODE + "' ");
                        //_EzBusinessHelper.ExecuteNonQuery("Delete from SHH004 where CmpyCode='" + gg.CMPYCODE + "' and PRSM001_CODE='" + gg.PRSM001_CODE + "' ");
                        DateTime dt1 = Convert.ToDateTime(gg.Entery_date.ToString());

                        dtstr = dt1.ToString("yyyy-MM-dd");

                        DateTime dt2 = Convert.ToDateTime(gg.Effect_From.ToString());

                        dtstr1 = dt2.ToString("yyyy-MM-dd");


                        StringBuilder sb = new StringBuilder();
                        //sb.Append("'" + gg.PRSM001UID + "',");
                        sb.Append("'" + gg.PRSM001_CODE + "',");
                        sb.Append("'" + gg.CMPYCODE + "',");
                        sb.Append("'" + gg.DIVISION + "',");
                        sb.Append("'" + gg.COUNTRY + "',");
                        sb.Append("'" + gg.EMPCODE + "',");
                        sb.Append("'" + dtstr + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + gg.BASIC + "',");
                        sb.Append("'" + gg.BASICCAPTION + "',");
                        sb.Append("'" + gg.BASICACT + "',");
                        sb.Append("'" + gg.HRA + "',");
                        sb.Append("'" + gg.HRACAPTION + "',");
                        sb.Append("'" + gg.HRAACT + "',");
                        sb.Append("'" + gg.DA + "',");
                        sb.Append("'" + gg.DACAPTION + "',");
                        sb.Append("'" + gg.DAACT + "',");
                        sb.Append("'" + gg.TELE + "',");
                        sb.Append("'" + gg.TELECAPTION + "',");
                        sb.Append("'" + gg.TELEACT + "',");
                        sb.Append("'" + gg.TRANS + "',");
                        sb.Append("'" + gg.TRANSCAPTION + "',");
                        sb.Append("'" + gg.TRANSACT + "',");
                        sb.Append("'" + gg.CAR + "',");
                        sb.Append("'" + gg.CARCAPTION + "',");
                        sb.Append("'" + gg.CARACT + "',");
                        sb.Append("'" + gg.ALLOWANCE1 + "',");
                        sb.Append("'" + gg.ALLOWANCE1CAPTION + "',");
                        sb.Append("'" + gg.ALLOWANCE1ACT + "',");
                        sb.Append("'" + gg.ALLOWANCE2 + "',");
                        sb.Append("'" + gg.ALLOWANCE2CAPTION + "',");
                        sb.Append("'" + gg.ALLOWANCE2ACT + "',");
                        sb.Append("'" + gg.ALLOWANCE3 + "',");
                        sb.Append("'" + gg.ALLOWANCE3CAPTION + "',");
                        sb.Append("'" + gg.ALLOWANCE3ACT + "',");
                        sb.Append("'" + gg.TOTAL + "')");


                        //List<SalaryGrid> ObjList = new List<SalaryGrid>();

                        //ObjList.AddRange(gg.SalaryMas.Select(m => new SalaryGrid
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

                        _EzBusinessHelper.ActivityLog(gg.CMPYCODE, gg.UserName, "Update Salary Master", gg.PRSM001_CODE, Environment.MachineName);

                        //n = ObjList.Count;

                        //while (n > 0)
                        //{
                        //    _EzBusinessHelper.ExecuteNonQuery("insert into SHH004(CmpyCode,Code,Name,Accountcode,Amount) values('" + ObjList[n - 1].CmpyCode + "','" + ObjList[n - 1].Code + "','" + ObjList[n - 1].Name + "','" + ObjList[n - 1].Accountcode + "','" + ObjList[n - 1].Amount + "')");
                        //    n = n - 1;
                        //}

                        gg.ErrorMessage = string.Empty;
                        gg.SaveFlag = true;
                        scope.Complete();
                    }
                }

                return gg;

            }




            catch
            {
                gg.SaveFlag = false;
                gg.ErrorMessage = "Error Occur";

            }
            return gg;
        }
    }
}
