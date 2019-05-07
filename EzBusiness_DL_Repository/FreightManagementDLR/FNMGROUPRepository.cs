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
   public class FNMGROUPRepository :IFNMGROUPRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteFNMGROUP(string FNMGROUP_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNMGROUP where CmpyCode='" + CmpyCode + "' and FNMGROUP_CODE='" + FNMGROUP_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNMGROUP", FNMGROUP_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNMGROUP set Flag=1 where CmpyCode='" + CmpyCode + "' and FNMGROUP_CODE='" + FNMGROUP_CODE + "'  and Flag=0");

            }
            return false;
        }

        public List<FNMGROUP> GetFNMGROUP(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNMGROUP where CmpyCode='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMGROUP> ObjList = new List<FNMGROUP>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMGROUP()
                {
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FNMGROUP_CODE = dr["FNMGROUP_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString(),

                });
            }
            return ObjList;
        }

        public FNMGROUP_VM SaveFNMGROUP(FNMGROUP_VM FG)
        {
            try
            {
                if (!FG.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FNMGROUPDetailnew> ObjList = new List<FNMGROUPDetailnew>();
                    ObjList.AddRange(FG.FNMGROUPDetailnew.Select(m => new FNMGROUPDetailnew
                    {
                        CMPYCODE = m.CMPYCODE,
                        FNMGROUP_CODE = m.FNMGROUP_CODE,
                        DESCRIPTION = m.DESCRIPTION,
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNMGROUP where CmpyCode='" + FG.CMPYCODE + "' and FNMGROUP_CODE='" + ObjList[n - 1].FNMGROUP_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + FG.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].FNMGROUP_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].DESCRIPTION + "')");

                            _EzBusinessHelper.ExecuteNonQuery("insert into FNMGROUP(CMPYCODE,FNMGROUP_CODE,DESCRIPTION) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(FG.CMPYCODE, FG.UserName, "Add FN Group", ObjList[n - 1].FNMGROUP_CODE, Environment.MachineName);

                            FG.SaveFlag = true;
                            FG.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].FNMGROUP_CODE.ToString());

                            FG.Drecord = Drecord;
                            FG.SaveFlag = false;
                            FG.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return FG;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from FNMGROUP where CmpyCode='" + FG.CMPYCODE + "' and FNMCAT_CODE='" + FG.FNMGROUP_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update FNMGROUP set CmpyCode='" + FG.CMPYCODE + "',FNMGROUP_CODE='" + FG.FNMGROUP_CODE + "',DESCRIPTION='" + FG.DESCRIPTION + "' where CmpyCode='" + FG.CMPYCODE + "' and FNMGROUP_CODE='" + FG.FNMGROUP_CODE + "'");

                    _EzBusinessHelper.ActivityLog(FG.CMPYCODE, FG.UserName, "Update FNMGROUP", FG.FNMGROUP_CODE, Environment.MachineName);

                    FG.SaveFlag = true;
                    FG.ErrorMessage = string.Empty;
                }
                else
                {
                    FG.SaveFlag = false;
                    FG.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FG.SaveFlag = false;


            }

            return FG;
        }
    }
}
