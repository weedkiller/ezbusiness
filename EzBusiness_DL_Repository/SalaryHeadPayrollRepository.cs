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
    public class SalaryHeadPayrollRepository : ISalaryHeadPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteSals(string Code, string CmpyCode, string username)
        {
            int Sals = _EzBusinessHelper.ExecuteScalar("Select count(*) from SHH004 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");

            int sa1 = _EzBusinessHelper.ExecuteScalar("Select count(*) from ACCTBL001 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Sals != 0 && sa1==0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Salary Head", Code, Environment.MachineName);
                return _EzBusinessHelper.ExecuteNonQuery1("update SHH004 set Flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
               // return true;
            }
            return false;
        }

        public List<CommonTable> GetPayDeductOns()
        {
            ds = _EzBusinessHelper.ExecuteDataSet("SELECT Code, Name FROM CMTBL003 WHERE Type ='PERIOD' Order By Code");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<CommonTable> ObjList = new List<CommonTable>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new CommonTable()
                {
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                });

            }
            return ObjList;
        }

        public List<SalaryHead> GetSals(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from SHH004 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<SalaryHead> ObjList = new List<SalaryHead>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new SalaryHead()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                    //Description = dr["Description"].ToString(),
                    //AmtType = dr["AmtType"].ToString(),
                    //PayDeductOn = dr["PayDeductOn"].ToString(),
                    //SNo = dr["SNo"].ToString()

                });

            }
            return ObjList;
        }

        public SalaryHeadVM SaveSals(SalaryHeadVM Sals)
        {
            try
            {
                if (!Sals.EditFlag)
                {
                    int Sals1 = _EzBusinessHelper.ExecuteScalar("Select count(*) from SHH004 where CmpyCode='" + Sals.CmpyCode + "' and Code='" + Sals.Code + "'");
                    if (Sals1 == 0)
                    {
                        _EzBusinessHelper.ExecuteNonQuery("insert into SHH004(CmpyCode,Code,Name) values('" + Sals.CmpyCode + "','" + Sals.Code + "','" + Sals.Name + "')");

                        _EzBusinessHelper.ActivityLog(Sals.CmpyCode, Sals.UserName, "Add Salary Head", Sals.Code, Environment.MachineName);

                        Sals.SaveFlag = true;
                        Sals.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Sals.SaveFlag = false;
                        Sals.ErrorMessage = "Duplicate Record";
                    }
                    return Sals;
                }
                var SalsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from SHH004 where CmpyCode='" + Sals.CmpyCode + "' and Code='" + Sals.Code + "'");
                if (SalsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update SHH004 set CmpyCode='" + Sals.CmpyCode + "',Code='" + Sals.Code + "',Name='" + Sals.Name + "' where CmpyCode='" + Sals.CmpyCode + "' and Code='" + Sals.Code + "'");

                    _EzBusinessHelper.ActivityLog(Sals.CmpyCode, Sals.UserName, "Update Salary Head", Sals.Code, Environment.MachineName);
                    Sals.SaveFlag = true;
                    Sals.ErrorMessage = string.Empty;
                }
                else
                {
                    Sals.SaveFlag = false;
                    Sals.ErrorMessage = "Record not available";
                }

            }
            catch
            {
                Sals.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Sals;
        }
    }
}
