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
    public class AttendencePayrollRepository : IAttendencePayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteAtens(string Code, string CmpyCode, string username)
        {
            int Atens = _EzBusinessHelper.ExecuteScalar("Select count(*) from MLH033 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Atens != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Leave Type Master", Code, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update MLH033 set Flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                //return true;
            }
            return false;
        }

        public List<Attendence> GetAtens(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MLH033 where CmpyCode='"+ CmpyCode  +"'and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Attendence> ObjList = new List<Attendence>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Attendence()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    LeaveName = dr["LeaveName"].ToString(),
                    CountryCode = dr["CountryCode"].ToString(),

                });

            }
            return ObjList;
        }

       
        public List<Country> GetCountryCodes(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("SELECT Code, Name FROM CTY085 Order By Code");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Country> ObjList = new List<Country>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Country()
                {
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                });

            }
            return ObjList;
        }

        public AttendenceVM SaveAtens(AttendenceVM Atens)
        {
            try
            {
                if (!Atens.EditFlag)
                {
                    int Atens1 = _EzBusinessHelper.ExecuteScalar("Select count(*) from MLH033 where CmpyCode=' "+ Atens.CmpyCode +"' and Code='" + Atens.Code + "'");
                    if (Atens1 == 0)
                    {

                        Atens.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("insert into MLH033(CmpyCode,Code,LeaveName,CountryCode) values('" + Atens.CmpyCode + "','" + Atens.Code + "','" + Atens.LeaveName + "','" + Atens.CountryCode + "')");
                       _EzBusinessHelper.ActivityLog(Atens.CmpyCode, Atens.UserName, "Add Leave Type Master", Atens.Code, Environment.MachineName);

                        //Atens.SaveFlag = true;
                        Atens.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Atens.SaveFlag = false;
                        Atens.ErrorMessage = "Duplicate Record";
                    }
                    return Atens;
                }
                var AtensEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from MLH033 where CmpyCode='" + Atens.CmpyCode + "' and Code='" + Atens.Code + "'");
                if (AtensEdit != 0)
                {
                    Atens.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("update MLH033 set LeaveName='" + Atens.LeaveName + "',CountryCode='" + Atens.CountryCode + "' where CmpyCode='" + Atens.CmpyCode + "' and Code='" + Atens.Code + "'");
                     _EzBusinessHelper.ActivityLog(Atens.CmpyCode, Atens.UserName, "Update Leave Type Master", Atens.Code, Environment.MachineName);
                    Atens.ErrorMessage = string.Empty;
                }
                else
                {
                    Atens.SaveFlag = false;
                    Atens.ErrorMessage = "Record not available";
                }

            }
            catch
            {
                Atens.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Atens;
        }
    }
}
