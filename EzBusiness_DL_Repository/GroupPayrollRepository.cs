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
    public class GroupPayrollRepository : IGroupPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteGrs(string DivisionCode, string CmpyCode, string username)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from MDIV011 where CmpyCode='" + CmpyCode + "' and DivisionCode='" + DivisionCode + "'");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Division", DivisionCode, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update MDIV011 set Flag=1 where CmpyCode='" + CmpyCode + "' and DivisionCode='" + DivisionCode + "'");
                //return true;
            }
            return false;
        }

        public List<Group> GetGrs(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MDIV011 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Group> ObjList = new List<Group>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Group()
                {
                    Cmpycode = dr["CmpyCode"].ToString(),
                    DivisionCode = dr["DivisionCode"].ToString(),
                    DivisionName = dr["DivisionName"].ToString(),
                  //  UniCodeName = dr["UniCodeName"].ToString(),
                });
            }
            return ObjList;
        }
        public GroupVM SaveGrs(GroupVM Grs)
        {
        
            try
            {
                if (!Grs.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<GroupDetailnew> ObjList = new List<GroupDetailnew>();
                    ObjList.AddRange(Grs.GroupDetailnew.Select(m => new GroupDetailnew
                    {
                        CmpyCode = m.CmpyCode,
                      DivisionCode = m.DivisionCode,
                        DivisionName = m.DivisionName,
                       // UniCodeName = m.UniCodeName
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from MDIV011 where CmpyCode='" + Grs.CmpyCode + "' and DivisionCode='" + ObjList[n - 1].DivisionCode+ "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Grs.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].DivisionCode + "',");
                            sb.Append("'" + ObjList[n - 1].DivisionName + "')");
                           // sb.Append("'" + ObjList[n - 1].UniCodeName + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into MDIV011(CmpyCode,DivisionCode,DivisionName) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(Grs.CmpyCode, Grs.UserName, "Add Group", ObjList[n - 1].DivisionCode, Environment.MachineName);

                            Grs.SaveFlag = true;
                            Grs.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].DivisionCode.ToString());
                            Grs.Drecord = Drecord;
                            Grs.SaveFlag = false;
                            Grs.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return Grs;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from MDIV011 where CmpyCode='" + Grs.CmpyCode + "' and DivisionCode='" + Grs.DivisionCode+ "'and Flag=0");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update MDIV011 set CmpyCode='" + Grs.CmpyCode + "',DivisionCode='" + Grs.DivisionCode + "',DivisionName='" + Grs.DivisionName + "' where CmpyCode='" + Grs.CmpyCode + "' and DivisionCode='" + Grs.DivisionCode + "'");

                    _EzBusinessHelper.ActivityLog(Grs.CmpyCode, Grs.UserName, "Update Group", Grs.DivisionCode, Environment.MachineName);

                    Grs.SaveFlag = true;
                    Grs.ErrorMessage = string.Empty;
                }
                else
                {
                    Grs.SaveFlag = false;
                    Grs.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Grs.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }
            
            return Grs;
        }
    }
}
