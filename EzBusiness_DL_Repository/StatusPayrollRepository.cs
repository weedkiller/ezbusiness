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
using System.Transactions;

namespace EzBusiness_DL_Repository
{
    public class StatusPayrollRepository : IStatusPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteStats(string Code, string CmpyCode, string username)
        {
            int Stats = _EzBusinessHelper.ExecuteScalar("Select count(*) from MSTS023 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Stats != 0)
            {
                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Status", Code, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update MSTS023 set Flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                //return true;
            }
            return false;
        }

        public List<Status> GetStats(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MSTS023 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Status> ObjList = new List<Status>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Status()
                {
                    Cmpycode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                   // UniCodeName = dr["UniCodeName"].ToString(),




                });

            }
            return ObjList;
        }

        public StatusVM SaveStats(StatusVM Stats)
        {
            try
            {
                if (!Stats.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<StatusDetailnew> ObjList = new List<StatusDetailnew>();
                    ObjList.AddRange(Stats.StatusDetailnew.Select(m => new StatusDetailnew
                    {
                        CmpyCode=m.CmpyCode,
                        Code=m.Code,
                        Name=m.Name,
                       // UniCodeName=m.UniCodeName
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from MSTS023 where CmpyCode='" + Stats.CmpyCode + "' and Code='" + ObjList[n - 1].Code + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Stats.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].Code + "',");
                            sb.Append("'" + ObjList[n - 1].Name + "')");
                            //  sb.Append("'" + ObjList[n - 1].UniCodeName + "')");

                            using (TransactionScope scope = new TransactionScope())
                            {
                                _EzBusinessHelper.ExecuteNonQuery("insert into MSTS023(CmpyCode,Code,Name) values(" + sb.ToString() + "");
                                _EzBusinessHelper.ActivityLog(Stats.CmpyCode, Stats.UserName, "Add Status Master", Stats.Code, Environment.MachineName);
                                Stats.SaveFlag = true;
                                Stats.ErrorMessage = string.Empty;
                                scope.Complete();
                            }
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].Code.ToString());

                            Stats.Drecord = Drecord;
                            Stats.SaveFlag = false;
                            Stats.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
          
                    return Stats;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from MSTS023 where CmpyCode='" + Stats.CmpyCode + "' and Code='" + Stats.Code + "'");
                if (StatsEdit != 0)
                {
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        _EzBusinessHelper.ExecuteNonQuery("update MSTS023 set CmpyCode='" + Stats.CmpyCode + "',Code='" + Stats.Code + "',Name='" + Stats.Name + "' where CmpyCode='" + Stats.CmpyCode + "' and Code='" + Stats.Code + "'");
                        _EzBusinessHelper.ActivityLog(Stats.CmpyCode, Stats.UserName, "Update Status Master", Stats.Code, Environment.MachineName);
                       
                         Stats.SaveFlag = true;
                         Stats.ErrorMessage = string.Empty;
                        scope1.Complete();
                    }
                }
                else
                {
                    Stats.SaveFlag = false;
                    Stats.ErrorMessage = "Record not available";
                }

            }
            catch(Exception ex )
            {
                Stats.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }
           
            return Stats;
        }
    }
}
