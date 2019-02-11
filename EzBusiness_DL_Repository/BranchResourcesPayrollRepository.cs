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
    public class BranchResourcesPayrollRepository : IBranchResourceRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public bool DeleteBrch(string Code, string CmpyCode,string UserName)
        {
            int Brch = _EzBusinessHelper.ExecuteScalar("Select count(*) from MBR005 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Brch != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete Branch", Environment.MachineName, Code);
                _EzBusinessHelper.ExecuteNonQuery("update MBR005 set Flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                return true;
            }
            return false;
        }

        public List<BranchTbl> GetBrch(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MBR005 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<BranchTbl> ObjList = new List<BranchTbl>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new BranchTbl
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    DivCode = dr["DivCode"].ToString(),
                    Name = dr["Name"].ToString(),
                    Code=dr["Code"].ToString()
                });

            }
            return ObjList;
        }

        public BranchVM SaveBrch(BranchVM Brnc)
        {
            try
            {
                if (!Brnc.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<BranchDdetailnew> ObjList = new List<BranchDdetailnew>();
                    ObjList.AddRange(Brnc.BranchDdetailnew.Select(m => new BranchDdetailnew
                    {
                        CmpyCode = m.CmpyCode,
                        DivCode = m.DivCode,
                        Name = m.Name,
                        Code=m.Code                       
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from MBR005 where CmpyCode='" + Brnc.CmpyCode + "' and Code='" + ObjList[n - 1].Code + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Brnc.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].DivCode + "',");
                            sb.Append("'" + ObjList[n - 1].Name + "',");
                            sb.Append("'" + ObjList[n - 1].Code + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into MBR005(CmpyCode,DivCode,Name,Code) values(" + sb.ToString() + "");
                            Brnc.SaveFlag = true;
                            Brnc.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].Code.ToString());

                            Brnc.Drecord = Drecord;
                            Brnc.SaveFlag = false;
                            Brnc.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }

                    return Brnc;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalar("Select count(*) from MBR005 where CmpyCode='" + Brnc.CmpyCode + "' and Code='" + Brnc.Code + "'");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update MBR005 set CmpyCode='" + Brnc.CmpyCode + "',DivCode='" + Brnc.DivCode + "',Name='" + Brnc.Name + "' where CmpyCode='" + Brnc.CmpyCode + "' and Code='" + Brnc.Code + "'");
                    Brnc.SaveFlag = true;
                    Brnc.ErrorMessage = string.Empty;
                }
                else
                {
                    Brnc.SaveFlag = false;
                    Brnc.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Brnc.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;
            }
            return Brnc;
        }
        public List<Division> GetDivisionList(string CmpyCode)
        {
            return drop.GetDivCode(CmpyCode);
        }
    }
 }

