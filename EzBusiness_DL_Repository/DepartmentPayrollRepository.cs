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
using System.Web;
namespace EzBusiness_DL_Repository
{
    public class DepartmentPayrollRepository : IDepartmentPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        // public static readonly List<SessionListnew> list = HttpContext.Current.Session["SesDet"] as List<SessionListnew>;

        public bool DeleteDeps(string DepartmentCode, string CmpyCode, string username)
        {

           // var list = context.Session["SesDet"] as List<SessionListnew>;

            int Deps = _EzBusinessHelper.ExecuteScalar("Select count(*) from MDEP009 where CmpyCode='" + CmpyCode + "' and DepartmentCode='" + DepartmentCode + "'");
            if (Deps != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Department Master", DepartmentCode, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update MDEP009 set Flag=1 where CmpyCode='" + CmpyCode + "' and DepartmentCode='" + DepartmentCode + "'");
               // return true;
            }
            return false;
        }
        public List<Department> GetDeps(string CmpyCode)
        {
            //var list = context.Session["SesDet"] as List<SessionListnew>;

            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MDEP009 where CmpyCode='" +CmpyCode +"'and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Department> ObjList = new List<Department>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Department()
                {
                    Cmpycode = dr["CmpyCode"].ToString(),
                    DepartmentCode = dr["DepartmentCode"].ToString(),
                    DepartmentName = dr["DepartmentName"].ToString(),
                    DivisionCode = dr["DivisionCode"].ToString(),
                    BranchCode = dr["BranchCode"].ToString(),
                   /// UniCodeName = dr["UniCodeName"].ToString(),
                });

            }
            return ObjList;
        }
        public List<Division> GetDivisionList(string CmpyCode)
        {
            return drop.GetDivCode(CmpyCode);
        }
        public DepartmentVM SaveDeps(DepartmentVM Deps)
        { 
            try
            {
                if (!Deps.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<DepartmentDetailnew> ObjList = new List<DepartmentDetailnew>();
                    ObjList.AddRange(Deps.DepartmentDetailnew.Select(m => new DepartmentDetailnew
                    {
                        CmpyCode = m.CmpyCode,
                        DepartmentCode = m.DepartmentCode,                                        
                        DepartmentName = m.DepartmentName,
                        DivisionCode=m.DivisionCode,
                        BranchCode=m.BranchCode,
                       // UniCodeName = m.UniCodeName
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Deps1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from MDEP009 where CmpyCode='" + Deps.CmpyCode + "' and DepartmentCode='" + ObjList[n - 1].DepartmentCode + "'");
                        if (Deps1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Deps.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].DepartmentCode + "',");
                            sb.Append("'" + ObjList[n - 1].DepartmentName + "',");
                            sb.Append("'" + ObjList[n - 1].DivisionCode + "',");
                            sb.Append("'" + ObjList[n - 1].BranchCode + "')");
                           // sb.Append("'" + ObjList[n - 1].UniCodeName + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into MDEP009(CmpyCode,DepartmentCode,DepartmentName,DivisionCode,BranchCode) values(" + sb.ToString() + "");
                           Deps.SaveFlag = true;
                           Deps.ErrorMessage = string.Empty;
                        }
                        else
                        {
                            Drecord.Add(ObjList[n - 1].DepartmentCode.ToString());
                            Deps.Drecord = Drecord;
                            Deps.SaveFlag = false;
                            Deps.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    return Deps;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalar("Select count(*) from MDEP009 where CmpyCode='" + Deps.CmpyCode + "' and DepartmentCode='" + Deps.DepartmentCode + "'");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update MDEP009 set CmpyCode='" +Deps.CmpyCode + "',DepartmentCode='" + Deps.DepartmentCode + "',DepartmentName='" + Deps.DepartmentName + "',DivisionCode='" + Deps.DivisionCode + "',BranchCode='" + Deps.BranchCode + "' where CmpyCode='" + Deps.CmpyCode + "' and DepartmentCode='" + Deps.DepartmentCode + "'");
                    Deps.SaveFlag = true;
                   Deps.ErrorMessage = string.Empty;
                }
                else
                {
                 Deps.SaveFlag = false;
                   Deps.ErrorMessage = "Record not available";
                }
            }
            catch (Exception ex)
            {
               Deps.SaveFlag = false;           
            }
                  return Deps;
              }

        public List<Department> GetDepartmentList(string CmpyCode, string DivCode, string BranchCode)
        {
            return drop.GetDepCode(CmpyCode, DivCode, BranchCode);
        }

        public List<BranchTbl> GetBranchCode(string CmpyCode, string DivCode)
        {
            return drop.GetBranchCode1(CmpyCode, DivCode);
        }
    }
       
}
