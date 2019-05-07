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
    public class FNMSUBGROUPRepository :IFNMSUBGROUPRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteFNMSUBGROUP(string FNMSUBGROUP_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNMSUBGROUP where CmpyCode='" + CmpyCode + "' and FNMSUBGROUP_CODE='" + FNMSUBGROUP_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNMSUBGROUP", FNMSUBGROUP_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNMSUBGROUP set Flag=1 where CmpyCode='" + CmpyCode + "' and FNMSUBGROUP_CODE='" + FNMSUBGROUP_CODE + "'  and Flag=0");

            }
            return false;
        }

        public List<FNMSUBGROUP> GetFNMSUBGROUP(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNMSUBGROUP where CmpyCode='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMSUBGROUP> ObjList = new List<FNMSUBGROUP>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMSUBGROUP()
                {
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FNMSUBGROUP_CODE = dr["FNMSUBGROUP_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString(),

                });
            }
            return ObjList;
        }

        public FNMSUBGROUP_VM SaveFNMSUBGROUP(FNMSUBGROUP_VM FSG)
        {
            try
            {
                if (!FSG.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FNMSUBGROUPDetailnew> ObjList = new List<FNMSUBGROUPDetailnew>();
                    ObjList.AddRange(FSG.FNMSUBGROUPDetailnew.Select(m => new FNMSUBGROUPDetailnew
                    {
                        CMPYCODE = m.CMPYCODE,
                        FNMSUBGROUP_CODE = m.FNMSUBGROUP_CODE,
                        DESCRIPTION = m.DESCRIPTION,
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNMSUBGROUP where CmpyCode='" + FSG.CMPYCODE + "' and FNMSUBGROUP_CODE='" + ObjList[n - 1].FNMSUBGROUP_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + FSG.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].FNMSUBGROUP_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].DESCRIPTION + "')");

                            _EzBusinessHelper.ExecuteNonQuery("insert into FNMSUBGROUP(CMPYCODE,FNMSUBGROUP_CODE,DESCRIPTION) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(FSG.CMPYCODE, FSG.UserName, "Add FN SubGroup", ObjList[n - 1].FNMSUBGROUP_CODE, Environment.MachineName);

                            FSG.SaveFlag = true;
                            FSG.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].FNMSUBGROUP_CODE.ToString());

                            FSG.Drecord = Drecord;
                            FSG.SaveFlag = false;
                            FSG.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return FSG;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from FNMSUBGROUP where CmpyCode='" + FSG.CMPYCODE + "' and FNMSUBGROUP_CODE='" + FSG.FNMSUBGROUP_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update FNMSUBGROUP set CmpyCode='" + FSG.CMPYCODE + "',FNMSUBGROUP_CODE='" + FSG.FNMSUBGROUP_CODE + "',DESCRIPTION='" + FSG.DESCRIPTION + "' where CmpyCode='" + FSG.CMPYCODE + "' and FNMSUBGROUP_CODE='" + FSG.FNMSUBGROUP_CODE + "'");

                    _EzBusinessHelper.ActivityLog(FSG.CMPYCODE, FSG.UserName, "Update FNMSUBGROUP", FSG.FNMSUBGROUP_CODE, Environment.MachineName);

                    FSG.SaveFlag = true;
                    FSG.ErrorMessage = string.Empty;
                }
                else
                {
                    FSG.SaveFlag = false;
                    FSG.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FSG.SaveFlag = false;


            }

            return FSG;
        }
    }
}
