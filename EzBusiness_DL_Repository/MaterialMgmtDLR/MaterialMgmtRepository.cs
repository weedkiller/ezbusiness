using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MaterialMgmt;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EzBusiness_DL_Repository
{
    public class MaterialMgmtRepository :IMaterialMgmtRepository
    {

        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public List<Unit> GetUnits(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MMU001 where CmpyCode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Unit> ObjList = new List<Unit>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Unit()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                    UniCodeName = dr["UniCodeName"].ToString(),
                    UnitType = dr["UnitType"].ToString()

                });

            }
            return ObjList;
        }

        public UnitVM SaveUnit(UnitVM unit)
        {
            try
            {
                if (!unit.EditFlag)
                {
                    int unit1 = _EzBusinessHelper.ExecuteScalar("Select count(*) from MMU001 where CmpyCode='" + unit.CmpyCode + "' and Code='" + unit.Code + "'");
                    if (unit1 == 0)
                    {
                        _EzBusinessHelper.ExecuteNonQuery("insert into MMU001(CmpyCode,Code,Name,UniCodeName,UnitType)values('" + unit.CmpyCode + "','" + unit.Code + "','" + unit.Name + "','" + unit.UniCodeName + "','" + unit.UnitType + "')");
                        unit.SaveFlag = true;
                        unit.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        unit.SaveFlag = false;
                        unit.ErrorMessage = "Duplicate Record";
                    }
                    return unit;
                }
                var unitEdit = _EzBusinessHelper.ExecuteScalar("Select * from MMU001 where CmpyCode='" + unit.CmpyCode + "' and Code='" + unit.Code + "'");
                if (unitEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update MMU001 set CmpyCode='" + unit.CmpyCode + "',Code='" + unit.Code + "',Name='" + unit.Name + "',UniCodeName='" + unit.UniCodeName + "',UnitType='" + unit.UnitType + "' where CmpyCode='" + unit.CmpyCode + "' and Code='" + unit.Code + "'");
                    unit.SaveFlag = true;
                    unit.ErrorMessage = string.Empty;
                }
                else
                {
                    unit.SaveFlag = false;
                    unit.ErrorMessage = "Record not available";
                }

            }
            catch
            {
                unit.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return unit;
        }

        public List<UnitType> GetUnitTypes()
        {
            List<UnitType> ObjList = null;
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MMUT001");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<UnitType>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new UnitType()
                    {
                        Code = dr["Code"].ToString(),
                        Name = dr["Name"].ToString(),
                    });

                }
               
            }
            return ObjList;
        }

        public bool DeleteUnit(string Code, string CmpyCode)
        {
            int unit = _EzBusinessHelper.ExecuteScalar("Select count(*) from MMU001 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (unit != 0)
            {
                _EzBusinessHelper.ExecuteNonQuery("delete from MMU001 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                return true;
            }
            return false;
        }
    }
}
