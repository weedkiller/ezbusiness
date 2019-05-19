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
    public class ProjectMasterPayrollRepository : IProjectMasterPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeletePjms(string Code, string CmpyCode, string UserName)
        {
            int Pjms = _EzBusinessHelper.ExecuteScalar("Select count(*) from CCH004 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Pjms != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete Project Master", Code, Environment.MachineName);
                _EzBusinessHelper.ExecuteNonQuery("update CCH004 set Flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                return true;
            }
            return false;
        }

        public List<ProjectMaster> GetPjms(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from CCH004 where CmpyCode='" + CmpyCode + "'and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ProjectMaster> ObjList = new List<ProjectMaster>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ProjectMaster()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                    Active = dr["Active"].ToString()=="1"?"Yes":"No",                                      
                });

            }
            return ObjList;
        }

        public ProjectMasterVM SavePjms(ProjectMasterVM Pjms)
        {
            try
            {
                if (!Pjms.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<ProjectNew> ObjList = new List<ProjectNew>();
                    ObjList.AddRange(Pjms.ProjectNew.Select(m => new ProjectNew
                    {

                        Code = m.Code,
                        Active = m.Active,
                        CmpyCode = m.CmpyCode,
                        Name = m.Name,                        
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Bbs1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from CCH004 where CmpyCode='" + Pjms.CmpyCode + "' and Code='" + ObjList[n - 1].Code + "'");
                        if (Bbs1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Pjms.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].Code + "',");
                            sb.Append("'" + ObjList[n - 1].Name + "',");                            
                            sb.Append("'" + ObjList[n - 1].Active + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into CCH004(CmpyCode,Code,Name,Active) values(" + sb.ToString() + "");
                            Pjms.SaveFlag = true;
                            Pjms.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].Code.ToString());

                            Pjms.Drecord = Drecord;
                            Pjms.SaveFlag = false;
                            Pjms.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    //int Lons1 = _EzBusinessHelper.ExecuteScalar("Select count(*) from ML031 where CmpyCode='" + Lons.CmpyCode + "' and Code='" + Lons.Code + "'");



                    //if (Lons1 == 0)
                    //{
                    //    StringBuilder sb = new StringBuilder();
                    //    sb.Append("'" + Lons.CmpyCode + "',");
                    //    sb.Append("'" + Lons.Code + "',");
                    //    sb.Append("'" + Lons.Name + "',");
                    //    sb.Append("'" + Lons.UniCodeName + "')");
                    //    _EzBusinessHelper.ExecuteNonQuery("insert into ML031(CmpyCode,Code,Name,UniCodeName) values(" + sb.ToString() + "");
                    //    Lons.SaveFlag = true;
                    //    Lons.ErrorMessage = string.Empty;
                    //}
                    //else
                    //{
                    //    Lons.SaveFlag = false;
                    //    Lons.ErrorMessage = "Duplicate Record";
                    //}
                    return Pjms;
                }
                var PjmsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from CCH004 where CmpyCode='" + Pjms.CmpyCode + "' and Code='" + Pjms.Code + "'and Flag=0");
                if (PjmsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update CCH004 set Name='" + Pjms.Name + "',Active='" + Pjms.Active + "' where CmpyCode='" + Pjms.CmpyCode + "' and Code='" + Pjms.Code + "'");
                    Pjms.SaveFlag = true;
                    Pjms.ErrorMessage = string.Empty;
                }
                else
                {
                    Pjms.SaveFlag = false;
                    Pjms.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Pjms.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Pjms;
        }
    }
}
