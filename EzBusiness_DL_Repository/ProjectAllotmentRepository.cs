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
   public class ProjectAllotmentRepository : IProjectAllotmentRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public bool DeleteProjectAllotment(string CmpyCode, string PRPRJE001_code, string UserName)
        {
            int ES = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRPRJE001 where CmpyCode='" + CmpyCode + "' and PRPRJE001_code='" + PRPRJE001_code + "'");
            if (ES != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete Project Allotment", PRPRJE001_code, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update PRPRJE001 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRPRJE001_code='" + PRPRJE001_code + "'");
                //  return true;
            }
            return false;
        }

        public List<Employee> GetEmpCodes(string CmpyCode)
        {
            return drop.GetEmpCodes(CmpyCode, "S");
        }

        public ProjectAllotmentVM GetProjectAllotmentEdit(string CmpyCode, string PRPRJE001_code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRPRJE001 where CmpyCode='" + CmpyCode + "' and PRPRJE001_code='" + PRPRJE001_code + "' and Flag=0");

            dt = ds.Tables[0];
            ProjectAllotmentVM es = new ProjectAllotmentVM();
            foreach (DataRow dr in dt.Rows)
            {
                es.CmpyCode = dr["CmpyCode"].ToString();
                es.PRPRJE001_code = dr["PRPRJE001_code"].ToString();
                es.EmpCode = dr["EmpCode"].ToString();
                es.Remarks = dr["Remarks"].ToString();
                es.CCH004_code = dr["CCH004_code"].ToString();
                es.Effect_From = Convert.ToDateTime(dr["Effect_From"].ToString());
                es.Entery_date = Convert.ToDateTime(dr["Entery_date"].ToString());
            }
            return es;
        }

        public List<ProjectAllotment> GetProjectAllotmentList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRPRJE001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ProjectAllotment> ObjList = new List<ProjectAllotment>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ProjectAllotment()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    PRPRJE001_code = dr["PRPRJE001_code"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(),
                    Remarks = dr["Remarks"].ToString(),
                    CCH004_code = dr["CCH004_code"].ToString(),
                    Effect_From = Convert.ToDateTime(dr["Effect_From"].ToString()),
                    Entery_date = Convert.ToDateTime(dr["Entery_date"].ToString()),

                });

            }
            return ObjList;
        }

        public List<ProjectMaster> GetProjectCodes(string CmpyCode)
        {
            return drop.GetProjects(CmpyCode);
        }

        public ProjectAllotmentVM SaveProjectAllotment(ProjectAllotmentVM PrjAlt)
        {
           
            DateTime dte;
            string dtstr1, dtstr2;
            dte = Convert.ToDateTime(PrjAlt.Entery_date.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(PrjAlt.Effect_From.ToString());
            dtstr2 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            if (!PrjAlt.EditFlag)
            {
                int Exi = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRPRJE001 where CmpyCode='" + PrjAlt.CmpyCode + "' and PRSFT003_code='" + PrjAlt.PRPRJE001_code + "'");

                int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + PrjAlt.CmpyCode + "' and Code='PRPRJE' ");
                if (Exi == 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("insert into PRPRJE001(PRPRJE001_code,CCH004_code,Entery_date,Effect_From,EmpCode,Remarks,CmpyCode) values('" + PrjAlt.PRPRJE001_code + "','" + PrjAlt.CCH004_code + "','" + dtstr1 + "','" + dtstr2 + "','" + PrjAlt.EmpCode + "','" + PrjAlt.Remarks + "','" + PrjAlt.CmpyCode + "')");
                    _EzBusinessHelper.ExecuteNonQuery("update PRDTD002 set  Project_code='" + PrjAlt.CCH004_code + "' where EmpCode='" + PrjAlt.EmpCode + "' and Att_Date >='" + dtstr2 + "' and CmpyCode='"+ PrjAlt.CmpyCode +"' ");
                    _EzBusinessHelper.ActivityLog(PrjAlt.CmpyCode, PrjAlt.UserName, "Insert Project Allotment", PrjAlt.PRPRJE001_code, Environment.MachineName);

                    _EzBusinessHelper.ExecuteNonQuery("UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + PrjAlt.CmpyCode + "' and Code='PRPRJE'");
                    PrjAlt.SaveFlag = true;
                    PrjAlt.ErrorMessage = string.Empty;
                }
                else
                {

                    PrjAlt.SaveFlag = false;
                    PrjAlt.ErrorMessage = "Duplicate Record";
                }

            }
            else
            {
                int n = 0;                
                n = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRPRJE001 where CmpyCode='" + PrjAlt.CmpyCode + "' and PRPRJE001_code='" + PrjAlt.PRPRJE001_code + "' ");

                if (n != 0)
                {
                 
                    _EzBusinessHelper.ExecuteNonQuery("UPDATE PRPRJE001 set CCH004_code='" + PrjAlt.CCH004_code + "',Entery_date='" + dtstr1 + "',Effect_From='" + dtstr2 + "',EmpCode='" + PrjAlt.EmpCode + "',Remarks='" + PrjAlt.Remarks + "' where PRPRJE001_code='" + PrjAlt.PRPRJE001_code + "' and CmpyCode='" + PrjAlt.CmpyCode + "'");

                    _EzBusinessHelper.ExecuteNonQuery("update PRDTD002 set  Project_code='" + PrjAlt.CCH004_code + "' where EmpCode='" + PrjAlt.EmpCode + "' and Att_Date >='" + dtstr2 + "' and CmpyCode='" + PrjAlt.CmpyCode + "' ");

                    _EzBusinessHelper.ActivityLog(PrjAlt.CmpyCode, PrjAlt.UserName, "Update Project Allotment", PrjAlt.PRPRJE001_code, Environment.MachineName);
                    PrjAlt.SaveFlag = true;
                    PrjAlt.ErrorMessage = string.Empty;

                }
                else
                {
                    PrjAlt.SaveFlag = true;
                    PrjAlt.ErrorMessage = "Error occur";
                }



            }

            return PrjAlt;
        }
    }
}
