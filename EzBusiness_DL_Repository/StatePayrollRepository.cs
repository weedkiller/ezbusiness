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
    public class StatePayrollRepository : IStatePayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteSts(string Code, string CmpyCode, string username)
        {
            int Sts = _EzBusinessHelper.ExecuteScalar("Select count(*) from MSM059 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Sts != 0)
            {
                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete State", Code, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update MSM059 set Flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                //return true;
            }
            return false;
        }

        public List<State> GetSts(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MSM059 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<State> ObjList = new List<State>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new State()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                


                });

            }
            return ObjList;
        }

        public StateVM SaveSts(StateVM Sts)
        {
            try
            {
                if (!Sts.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<StateNew> ObjList = new List<StateNew>();
                    ObjList.AddRange(Sts.StateNew.Select(m => new StateNew
                    {
                        CmpyCode = m.CmpyCode,
                        Code = m.Code,
                        Name = m.Name,                        
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Bbs1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from MSM059 where CmpyCode='" + Sts.CmpyCode + "' and Code='" + ObjList[n - 1].Code + "'");
                        if (Bbs1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Sts.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].Code + "',");
                            sb.Append("'" + ObjList[n - 1].Name + "')");

                            using (TransactionScope scope = new TransactionScope())
                            {
                                _EzBusinessHelper.ExecuteNonQuery("insert into MSM059(CmpyCode,Code,Name) values(" + sb.ToString() + "");

                                _EzBusinessHelper.ActivityLog(Sts.CmpyCode, Sts.UserName, "Add State Master", Sts.Code, Environment.MachineName);

                                Sts.SaveFlag = true;
                                Sts.ErrorMessage = string.Empty;
                                scope.Complete();
                            }
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].Code.ToString());

                            Sts.Drecord = Drecord;
                            Sts.SaveFlag = false;
                            Sts.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    //ds = _EzBusinessHelper.ExecuteDataSet("Select count(*) as [count1] from MSM059 where CmpyCode='" + Sts.CmpyCode + "' and Code='" + Sts.Code + "'");
                    //dt = ds.Tables[0];


                    //int Sts1 = 0;
                    //foreach (DataRow dr in dt.Rows)
                    //{
                    //    Sts1 = int.Parse(dr["count1"].ToString());
                    //}

                    //if (Sts1 == 0)
                    //{
                    //    StringBuilder sb = new StringBuilder();
                    //    sb.Append("'" + Sts.CmpyCode + "',");
                    //    //sb.Append("'UM',");
                    //    sb.Append("'" + Sts.Code + "',");
                    //    sb.Append("'" + Sts.Name + "')");
                    //    _EzBusinessHelper.ExecuteNonQuery("insert into MSM059(CmpyCode,Code,Name) values(" + sb.ToString() + "");
                    //    Sts.SaveFlag = true;
                    //    Sts.ErrorMessage = string.Empty;
                    //}
                    //else
                    //{
                    //    Sts.SaveFlag = false;
                    //    Sts.ErrorMessage = "Duplicate Record";
                    //}
                    return Sts;
                }
                var StsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from MSM059 where CmpyCode='" + Sts.CmpyCode + "' and Code='" + Sts.Code + "'");
                if (StsEdit != 0)
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        _EzBusinessHelper.ExecuteNonQuery("update MSM059 set Name='" + Sts.Name + "' where CmpyCode='" + Sts.CmpyCode + "' and Code='" + Sts.Code + "'");
                        _EzBusinessHelper.ActivityLog(Sts.CmpyCode, Sts.UserName, "Update State Master", Sts.Code, Environment.MachineName);
                        Sts.SaveFlag = true;
                        Sts.ErrorMessage = string.Empty;
                        scope.Complete();
                    }
                }
                else
                {
                    Sts.SaveFlag = false;
                    Sts.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Sts.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Sts;
        }
    }
}
