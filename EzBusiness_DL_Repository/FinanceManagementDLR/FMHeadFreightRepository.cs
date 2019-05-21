using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface.FreightManagement;
using EzBusiness_EF_Entity.FreightManagement;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EzBusiness_DL_Repository.FreightManagement
{
    public class FMHeadFreightRepository : IFMHeadFreightRepository
    {

        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteFMHEAD(string FNMHEAD_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNMHEAD where CmpyCode='" + CmpyCode + "' and FNMHEAD_CODE='" + FNMHEAD_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNMHEAD", FNMHEAD_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNMHEAD set Flag=1 where CmpyCode='" + CmpyCode + "' and FNMHEAD_CODE='" + FNMHEAD_CODE + "'  and Flag=0");
              
            }
            return false;
        }

        public List<FMHEAD> GetFMHEAD(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNMHEAD where CmpyCode='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FMHEAD> ObjList = new List<FMHEAD>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FMHEAD()
                {
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FNMHEAD_CODE = dr["FNMHEAD_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString(),
                    //  UniCodeName = dr["UniCodeName"].ToString(),
                });
            }
            return ObjList;
        }

        public FMHEAD_VM SaveFMHEAD(FMHEAD_VM FH)
        {
            try
            {
                if (!FH.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FMHEADDetailnew> ObjList = new List<FMHEADDetailnew>();
                    ObjList.AddRange(FH.FMHEADDetailnew.Select(m => new FMHEADDetailnew
                    {
                        CMPYCODE = m.CMPYCODE,
                        FNMHEAD_CODE = m.FNMHEAD_CODE,
                        DESCRIPTION = m.DESCRIPTION,                      
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNMHEAD where CmpyCode='" + FH.CMPYCODE + "' and FNMHEAD_CODE='" + ObjList[n - 1].FNMHEAD_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + FH.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].FNMHEAD_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].DESCRIPTION + "')");
                            // sb.Append("'" + ObjList[n - 1].UniCodeName + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into FNMHEAD(CMPYCODE,FNMHEAD_CODE,DESCRIPTION) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(FH.CMPYCODE, FH.UserName, "Add Head", ObjList[n - 1].FNMHEAD_CODE, Environment.MachineName);

                            FH.SaveFlag = true;
                            FH.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].FNMHEAD_CODE.ToString());

                            FH.Drecord = Drecord;
                            FH.SaveFlag = false;
                            FH.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return FH;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FNMHEAD where CmpyCode='" + FH.CMPYCODE + "' and FNMHEAD_CODE='" + FH.FNMHEAD_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update FNMHEAD set CmpyCode='" + FH.CMPYCODE + "',FNMHEAD_CODE='" + FH.FNMHEAD_CODE + "',DESCRIPTION='" + FH.DESCRIPTION + "' where CmpyCode='" + FH.CMPYCODE + "' and FNMHEAD_CODE='" + FH.FNMHEAD_CODE + "'");

                    _EzBusinessHelper.ActivityLog(FH.CMPYCODE, FH.UserName, "Update FNMHEAD", FH.FNMHEAD_CODE, Environment.MachineName);

                    FH.SaveFlag = true;
                    FH.ErrorMessage = string.Empty;
                }
                else
                {
                    FH.SaveFlag = false;
                    FH.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FH.SaveFlag = false;
              

            }

            return FH;
        }
    }
}
