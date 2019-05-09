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
    public class NationRPayrollRepository :INationRPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteNrs(string Code, string CmpyCode, string username)
        {
            int Nrs = _EzBusinessHelper.ExecuteScalar("Select count(*) from MNAT019 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Nrs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Nation", Code, Environment.MachineName);
                _EzBusinessHelper.ExecuteNonQuery("delete from MNAT019 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                return true;
            }
            return false;
        }

        public List<NationRegion> GetNrs(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MNAT019 where CmpyCode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<NationRegion> ObjList = new List<NationRegion>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new NationRegion()
                {
                    Cmpycode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                   
                });

            }
            return ObjList;
        }

        public NationRegionVM SaveNrs(NationRegionVM Nrs)
        {
            try
            {
                if (!Nrs.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<NationNew> ObjList = new List<NationNew>();
                    ObjList.AddRange(Nrs.NationNew.Select(m => new NationNew
                    {
                        CmpyCode = m.CmpyCode,
                        Code = m.Code,
                        Name = m.Name,
                       
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Bbs1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from MNAT019 where CmpyCode='" + Nrs.CmpyCode + "' and Code='" + ObjList[n - 1].Code + "'");
                        if (Bbs1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Nrs.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].Code + "',");
                            sb.Append("'" + ObjList[n - 1].Name + "',");
                            sb.Append("'')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into MNAT019(CmpyCode,Code,Name,UniCodeName) values(" + sb.ToString() + "");
                            Nrs.SaveFlag = true;
                            Nrs.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].Code.ToString());

                            Nrs.Drecord = Drecord;
                            Nrs.SaveFlag = false;
                            Nrs.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    //ds = _EzBusinessHelper.ExecuteDataSet("Select count(*) as [count1] from MNAT019 where CmpyCode='" + Nrs.CmpyCode + "' and Code='" + Nrs.Code + "'");
                    //dt = ds.Tables[0];


                    //int Nrs1 = 0;
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Nrs1 = int.Parse(dr["count1"].ToString());
                    //}

                    //if (Nrs1 == 0)
                    //{
                    //    StringBuilder sb = new StringBuilder();
                    //    sb.Append("'" + Nrs.CmpyCode + "',");
                    //    sb.Append("'" + Nrs.Code + "',");
                    //    sb.Append("'" + Nrs.Name + "',");
                    //    sb.Append("'" + Nrs.UniCodeName + "')");
                    //    _EzBusinessHelper.ExecuteNonQuery("insert into MNAT019(CmpyCode,Code,Name,UniCodeName) values(" + sb.ToString() + "");
                    //    Nrs.SaveFlag = true;
                    //    Nrs.ErrorMessage = string.Empty;
                    //}
                    //else
                    //{
                    //    Nrs.SaveFlag = false;
                    //    Nrs.ErrorMessage = "Duplicate Record";
                    //}
                    return Nrs;
                }
                var NrsEdit = _EzBusinessHelper.ExecuteScalarDec("Select COUNT(*) from MNAT019 where CmpyCode='" + Nrs.CmpyCode + "' and Code='" + Nrs.Code + "'");
                if (NrsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update MNAT019 set CmpyCode='" + Nrs.CmpyCode + "',Code='" + Nrs.Code + "',Name='" + Nrs.Name + "' where CmpyCode='" + Nrs.CmpyCode + "' and Code='" + Nrs.Code + "'");
                    Nrs.SaveFlag = true;
                    Nrs.ErrorMessage = string.Empty;
                }
                else
                {
                    Nrs.SaveFlag = false;
                    Nrs.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Nrs.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Nrs;
        }
    }
}
