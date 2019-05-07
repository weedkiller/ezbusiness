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
    public class FNMCATRepository : IFNMCATRepository
    {

        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeleteFNMCAT(string FNMCAT_CODE, string CmpyCode, string UserName)
        {

            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNMCAT where CmpyCode='" + CmpyCode + "' and FNMCAT_CODE='" + FNMCAT_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNMCAT", FNMCAT_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNMCAT set Flag=1 where CmpyCode='" + CmpyCode + "' and FNMCAT_CODE='" + FNMCAT_CODE + "'  and Flag=0");

            }
            return false;
        }

        public List<FNMCAT> GetFNMCAT(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNMCAT where CmpyCode='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMCAT> ObjList = new List<FNMCAT>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMCAT()
                {
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FNMCAT_CODE = dr["FNMCAT_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString(),
                    
                });
            }
            return ObjList;
        }

        public FNMCAT_VM SaveFMHEAD(FNMCAT_VM FC)
        {
            try
            {
                if (!FC.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FNMCATDetailnew> ObjList = new List<FNMCATDetailnew>();
                    ObjList.AddRange(FC.FNMCATDetailnew.Select(m => new FNMCATDetailnew
                    {
                        CMPYCODE = m.CMPYCODE,
                        FNMCAT_CODE = m.FNMCAT_CODE,
                        DESCRIPTION = m.DESCRIPTION,
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNMCAT where CmpyCode='" + FC.CMPYCODE + "' and FNMHEAD_CODE='" + ObjList[n - 1].FNMCAT_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + FC.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].FNMCAT_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].DESCRIPTION + "')");
                            
                            _EzBusinessHelper.ExecuteNonQuery("insert into FNMCAT(CMPYCODE,FNMCAT_CODE,DESCRIPTION) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(FC.CMPYCODE, FC.UserName, "Add FN Category", ObjList[n - 1].FNMCAT_CODE, Environment.MachineName);

                            FC.SaveFlag = true;
                            FC.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].FNMCAT_CODE.ToString());

                            FC.Drecord = Drecord;
                            FC.SaveFlag = false;
                            FC.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return FC;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from FNMCAT where CmpyCode='" + FC.CMPYCODE + "' and FNMCAT_CODE='" + FC.FNMCAT_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update FNMCAT set CmpyCode='" + FC.CMPYCODE + "',FNMHEAD_CODE='" + FC.FNMCAT_CODE + "',DESCRIPTION='" + FC.DESCRIPTION + "' where CmpyCode='" + FC.CMPYCODE + "' and FNMCAT_CODE='" + FC.FNMCAT_CODE + "'");

                    _EzBusinessHelper.ActivityLog(FC.CMPYCODE, FC.UserName, "Update FMHead", FC.FNMCAT_CODE, Environment.MachineName);

                    FC.SaveFlag = true;
                    FC.ErrorMessage = string.Empty;
                }
                else
                {
                    FC.SaveFlag = false;
                    FC.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FC.SaveFlag = false;


            }

            return FC;
        }
    }
}
