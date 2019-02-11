using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresource;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EzBusiness_DL_Repository
{
    public class CountryResourcesRepository : ICountryResourcesRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteCountrys(string Code, string CmpyCode, string username)
        {
            int Countrys = _EzBusinessHelper.ExecuteScalar("Select count(*) from Country where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Countrys != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Country Master", Code, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("delete from Country where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
               // return true;
            }
            return false;
        }

        public List<Country> GetCountrys(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from Country where CmpyCode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Country> ObjList = new List<Country>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Country()
                {
                    Cmpycode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                    UniCodeName = dr["UniCodeName"].ToString(),




                });

            }
            return ObjList;
        }

        public CountryVM SaveCountrys(CountryVM Countrys)
        {
            try
            {
                if (!Countrys.EditFlag)
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select count(*) as [count1] from Country where CmpyCode='" + Countrys.CmpyCode + "' and Code='" + Countrys.Code + "'");
                    dt = ds.Tables[0];


                    int Countrys1 = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Countrys1 = int.Parse(dr["count1"].ToString());
                    }

                    if (Countrys1 == 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("'" + Countrys.CmpyCode + "',");
                        sb.Append("'" + Countrys.Code + "',");
                        sb.Append("'" + Countrys.Name + "',");
                        sb.Append("'" + Countrys.UniCodeName + "')");
                        _EzBusinessHelper.ExecuteNonQuery("insert into Country(CmpyCode,Code,Name,UniCodeName) values(" + sb.ToString() + "");
                        Countrys.SaveFlag = true;
                        Countrys.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Countrys.SaveFlag = false;
                        Countrys.ErrorMessage = "Duplicate Record";
                    }
                    return Countrys;
                }
                var CountrysEdit = _EzBusinessHelper.ExecuteScalar("Select count(*) from Country where CmpyCode='" + Countrys.CmpyCode + "' and Code='" + Countrys.Code + "'");
                if (CountrysEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update Country set CmpyCode='" + Countrys.CmpyCode + "',Code='" + Countrys.Code + "',Name='" + Countrys.Name + "',UniCodeName='" + Countrys.UniCodeName + "' where CmpyCode='"+ Countrys.CmpyCode + "' and Code='" + Countrys.Code + "'");
                    Countrys.SaveFlag = true;
                    Countrys.ErrorMessage = string.Empty;
                }
                else
                {
                    Countrys.SaveFlag = false;
                    Countrys.ErrorMessage = "Record not available";
                }

            }
            catch
            {
                Countrys.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Countrys;

        }
    }
}            
