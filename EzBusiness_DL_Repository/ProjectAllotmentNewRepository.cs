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
    public class ProjectAllotmentNewRepository : IProjectAllotmentNewRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public List<PRPJXDTD> GetProjectAllotmentList(string CmpyCode)
        {

            List<PRPJXDTD> ObjList = null;
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRPJXDTD001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<PRPJXDTD>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new PRPJXDTD()
                    {
                        PRPJXDTD001_UID=Convert.ToInt32(dr["PRPJXDTD001_UID"].ToString()),
                        cmpycode = dr["CmpyCode"].ToString(),
                        empcode = dr["empcode"].ToString(),
                        Dates = Convert.ToDateTime(dr["Dates"].ToString()),
                        Project_code = dr["Project_code"].ToString(),
                        TimeIn = dr["TimeIn"].ToString(),
                        TimeOut = dr["TimeOut"].ToString(),

                    });

                }
            }
            return ObjList;
        }

        public PRPJXDTDVM SaveProjectAllotment(PRPJXDTDVM PrjAlt)
        {
            DateTime dte;
            string dtstr1;
            dte = Convert.ToDateTime(PrjAlt.Dates.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            bool cstatus = false;

            try
            {
                if (!PrjAlt.EditFlag)
                {


 


                   SqlParameter[] param1 = {
                        new SqlParameter("@empcode",PrjAlt.empcode),
                        new SqlParameter("@cmpycode", PrjAlt.cmpycode),
                        new SqlParameter("@Att_Date",dtstr1),
                        new SqlParameter("@projcode",PrjAlt.Project_code),
                        new SqlParameter("@timein",PrjAlt.TimeIn),
                        new SqlParameter("@timeout",PrjAlt.TimeOut),
                        new SqlParameter("@typMod","I"),
                        new SqlParameter("@PRPJXDTD001_UID",1),
                       
                       };
                    cstatus = _EzBusinessHelper.ExecuteNonQuery("Sp_PRPJXDTD001", param1);
                    if (cstatus == true)
                    {
                        PrjAlt.SaveFlag = true;
                        PrjAlt.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        PrjAlt.SaveFlag = false;
                        PrjAlt.ErrorMessage = "Duplicate Record";
                    }
                    return PrjAlt;
                }
                else
                {
                    SqlParameter[] param1 = {
                        new SqlParameter("@empcode",PrjAlt.empcode),
                        new SqlParameter("@cmpycode", PrjAlt.cmpycode),
                        new SqlParameter("@Att_Date",dtstr1),
                        new SqlParameter("@projcode",PrjAlt.Project_code),
                        new SqlParameter("@timein",PrjAlt.TimeIn),
                        new SqlParameter("@timeout",PrjAlt.TimeOut),
                        new SqlParameter("@typMod","U"),
                        new SqlParameter("@PRPJXDTD001_UID",PrjAlt.PRPJXDTD001_UID),

                       };

                    cstatus = _EzBusinessHelper.ExecuteNonQuery("Sp_PRPJXDTD001", param1);
                    if (cstatus == true)
                    {
                        PrjAlt.SaveFlag = true;
                        PrjAlt.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        PrjAlt.SaveFlag = false;
                        PrjAlt.ErrorMessage = "Duplicate Record";
                    }

                    return PrjAlt;
                }
            }
            catch
            {
                PrjAlt.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;
            }
            return PrjAlt;
        }

        public PRPJXDTDVM GetProjectAllotmentEdit(string CmpyCode, string PRPJXDTD001_UID)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRPJXDTD001 where CmpyCode='" + CmpyCode + "' and PRPJXDTD001_UID='" + PRPJXDTD001_UID + "' and Flag=0");

            dt = ds.Tables[0];
            PRPJXDTDVM es = new PRPJXDTDVM();
            foreach (DataRow dr in dt.Rows)
            {
                es.cmpycode = dr["cmpycode"].ToString();
                es.PRPJXDTD001_UID = Convert.ToInt32(dr["PRPJXDTD001_UID"].ToString());
                es.empcode = dr["empcode"].ToString();               
                es.Project_code = dr["Project_code"].ToString();               
                es.Dates = Convert.ToDateTime(dr["Dates"].ToString());
                es.TimeIn= dr["TimeIn"].ToString();
                es.TimeOut = dr["TimeOut"].ToString();
            }
            return es;
        }

        public List<Employee> GetEmpCodes(string CmpyCode)
        {
            return drop.GetEmpCodes(CmpyCode, "S");
        }

        public List<ProjectMaster> GetProjectCodes(string CmpyCode)
        {
            return drop.GetProjects(CmpyCode);
        }

        public bool DeleteProjectAllotment(string CmpyCode, string PRPJXDTD001_UID, string UserName)
        {
            int ES = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRPJXDTD001 where CmpyCode='" + CmpyCode + "' and PRPJXDTD001_UID='" + PRPJXDTD001_UID + "'");
            if (ES != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete Project Allotment", PRPJXDTD001_UID, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update PRPRJE001 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRPJXDTD001_UID='" + PRPJXDTD001_UID + "'");
                //  return true;
            }
            return false;
        }
    }
}
