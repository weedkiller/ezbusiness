using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
    public class FNMTYPERepository:IFNMTYPERepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteFNMTYPE(string FNMTYPE_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNMTYPE where CmpyCode='" + CmpyCode + "' and FNMTYPE_CODE='" + FNMTYPE_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNMTYPE", FNMTYPE_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNMTYPE set Flag=1 where CmpyCode='" + CmpyCode + "' and FNMTYPE_CODE='" + FNMTYPE_CODE + "'  and Flag=0");

            }
            return false;
        }

        public List<FNMTYPE> GetFNMTYPE(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNMTYPE where CmpyCode='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMTYPE> ObjList = new List<FNMTYPE>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMTYPE()
                {
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FNMTYPE_CODE = dr["FNMTYPE_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString(),

                });
            }
            return ObjList;
        }

        public FNMTYPE_VM SaveFNMTYPE(FNMTYPE_VM FT)
        {
            try
            {
                if (!FT.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FNMTYPEDetailnew> ObjList = new List<FNMTYPEDetailnew>();
                    ObjList.AddRange(FT.FNMTYPEDetailnew.Select(m => new FNMTYPEDetailnew
                    {
                        CMPYCODE = m.CMPYCODE,
                        FNMTYPE_CODE = m.FNMTYPE_CODE,
                        DESCRIPTION = m.DESCRIPTION,
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNMTYPE where CmpyCode='" + FT.CMPYCODE + "' and FNMTYPE_CODE='" + ObjList[n - 1].FNMTYPE_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + FT.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].FNMTYPE_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].DESCRIPTION + "')");

                            _EzBusinessHelper.ExecuteNonQuery("insert into FNMTYPE(CMPYCODE,FNMTYPE_CODE,DESCRIPTION) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(FT.CMPYCODE, FT.UserName, "Add FN FNMTYPE", ObjList[n - 1].FNMTYPE_CODE, Environment.MachineName);

                            FT.SaveFlag = true;
                            FT.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].FNMTYPE_CODE.ToString());

                            FT.Drecord = Drecord;
                            FT.SaveFlag = false;
                            FT.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return FT;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from FNMTYPE where CmpyCode='" + FT.CMPYCODE + "' and FNMTYPE_CODE='" + FT.FNMTYPE_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update FNMTYPE set CmpyCode='" + FT.CMPYCODE + "',FNMTYPE_CODE='" + FT.FNMTYPE_CODE + "',DESCRIPTION='" + FT.DESCRIPTION + "' where CmpyCode='" + FT.CMPYCODE + "' and FNMTYPE_CODE='" + FT.FNMTYPE_CODE + "'");

                    _EzBusinessHelper.ActivityLog(FT.CMPYCODE, FT.UserName, "Update FNMTYPE", FT.FNMTYPE_CODE, Environment.MachineName);

                    FT.SaveFlag = true;
                    FT.ErrorMessage = string.Empty;
                }
                else
                {
                    FT.SaveFlag = false;
                    FT.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FT.SaveFlag = false;


            }

            return FT;
        }
    }
}
