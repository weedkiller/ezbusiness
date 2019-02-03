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
    public class ProfessionPayrollRepository : IProfessionPayrollRepository 
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeletePros(string ProfCode, string CmpyCode, string username)
        {
            int Pros = _EzBusinessHelper.ExecuteScalar("Select count(*) from MPROF021 where CmpyCode='" + CmpyCode + "' and ProfCode='" + ProfCode + "'");
            if (Pros != 0)
            {
                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Profession", ProfCode, Environment.MachineName);
                return _EzBusinessHelper.ExecuteNonQuery1("update MPROF021 set Flag=1 where CmpyCode='" + CmpyCode + "' and ProfCode='" + ProfCode + "'");
               // return true;
            }
            return false;
        }

        public List<Profession> GetPros(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MPROF021 where CmpyCode='" + CmpyCode + "'and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Profession> ObjList = new List<Profession>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Profession()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    ProfCode = dr["ProfCode"].ToString(),
                    ProfName = dr["ProfName"].ToString(),
                 //   UniCodeName = dr["UniCodeName"].ToString(),
                    ProfType = dr["ProfType"].ToString()


                });

            }
            return ObjList;
        }

        public ProfessionVM SavePros(ProfessionVM Pros)
        {

            try
            {
                if (!Pros.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<ProfessionDetailnew> ObjList = new List<ProfessionDetailnew>();
                    ObjList.AddRange(Pros.ProfessionDetailnew.Select(m => new ProfessionDetailnew
                    {
                        CmpyCode = m.CmpyCode,
                        ProfCode = m.ProfCode,
                        ProfName = m.ProfName,
                      //  UniCodeName = m.UniCodeName
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Pros1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from MPROF021 where CmpyCode='" + Pros.CmpyCode + "' and ProfCode='" + ObjList[n - 1].ProfCode+ "'");
                        if (Pros1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Pros.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].ProfCode + "',");
                            sb.Append("'" + ObjList[n - 1].ProfName + "')");
                          //  sb.Append("'" + ObjList[n - 1].UniCodeName + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into MPROF021(CmpyCode,ProfCode,ProfName) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(Pros.CmpyCode, Pros.UserName, "Added PayRoll Config Master", ObjList[n - 1].ProfCode, Environment.MachineName);

                            Pros.SaveFlag = true;
                            Pros.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].ProfCode.ToString());

                            Pros.Drecord = Drecord;
                            Pros.SaveFlag = false;
                            Pros.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }


                    return Pros;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from MPROF021 where CmpyCode='" + Pros.CmpyCode + "' and ProfCode='" + Pros.ProfCode + "' and Flag=0");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update MPROF021 set CmpyCode='" + Pros.CmpyCode + "',ProfCode='" + Pros.ProfCode + "',Name='" + Pros.ProfName + "' where CmpyCode='" + Pros.CmpyCode + "' and ProfCode='" + Pros.ProfCode + "'");

                    _EzBusinessHelper.ActivityLog(Pros.CmpyCode, Pros.UserName, "Update PayRoll Config Master", Pros.ProfCode, Environment.MachineName);
                    Pros.SaveFlag = true;
                    Pros.ErrorMessage = string.Empty;
                }
                else
                {
                    Pros.SaveFlag = false;
                    Pros.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Pros.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }



            return Pros;
        }
    }
}
