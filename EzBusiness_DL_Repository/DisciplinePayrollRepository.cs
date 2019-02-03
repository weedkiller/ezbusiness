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
    public class DisciplinePayrollRepository : IDisciplinePayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteDis(string Code, string CmpyCode, string username)
        {
            int Dis = _EzBusinessHelper.ExecuteScalar("Select count(*) from MDISC010 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Dis != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Discipline Master", Code, Environment.MachineName);
                return _EzBusinessHelper.ExecuteNonQuery1("delete from MDISC010 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                //return true;
            }
            return false;
        }

        public List<Discipline> GetDis(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MDISC010 where CmpyCode='"+CmpyCode+"'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Discipline> ObjList = new List<Discipline>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Discipline()
                {
                    Cmpycode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                    UniCodeName = dr["UniCodeName"].ToString(),




                });

            }
            return ObjList;
        }

        public DisciplineVM SaveDis(DisciplineVM Dis)
        {
            try
            {
                if (!Dis.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<DisciplineDetailnew> ObjList = new List<DisciplineDetailnew>();
                    ObjList.AddRange(Dis.DisciplineDetailnew.Select(m => new DisciplineDetailnew
                    {
                        CmpyCode = m.CmpyCode,
                        Code = m.Code,
                        Name = m.Name,
                        UniCodeName = m.UniCodeName
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Dis1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from MDISC010 where CmpyCode='" + Dis.CmpyCode + "' and Code='" + ObjList[n - 1].Code + "'");
                        if (Dis1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Dis.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].Code + "',");
                            sb.Append("'" + ObjList[n - 1].Name + "',");
                            sb.Append("'" + ObjList[n - 1].UniCodeName + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into MDISC010(CmpyCode,Code,Name,UniCodeName) values(" + sb.ToString() + "");
                            Dis.SaveFlag = true;
                            Dis.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].Code.ToString());

                            Dis.Drecord = Drecord;
                            Dis.SaveFlag = false;
                            Dis.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }


                    return Dis;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from MDISC010 where CmpyCode='" + Dis.CmpyCode + "' and Code='" + Dis.Code + "'");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update MDISC010 set CmpyCode='" + Dis.CmpyCode + "',Code='" + Dis.Code + "',Name='" + Dis.Name + "',UniCodeName='" + Dis.UniCodeName + "' where CmpyCode='" + Dis.CmpyCode + "' and Code='" + Dis.Code + "'");
                    Dis.SaveFlag = true;
                    Dis.ErrorMessage = string.Empty;
                }
                else
                {
                    Dis.SaveFlag = false;
                    Dis.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Dis.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }



            return Dis;
        }
    }

    }

