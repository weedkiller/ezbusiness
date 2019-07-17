using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
   public class FNMBranchRepository:IFNMBranchRepository
   {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        
        public bool DeleteFNMBranch(string FNMBranch_CODE, string CmpyCode, string UserName)
        {

            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNMBRANCH where CMPYCODE='" + CmpyCode + "' and FNMBRANCH_CODE='" + FNMBranch_CODE + "'  and Flag=0");
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNMBRANCH", FNMBranch_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FNMBRANCH set Flag=1 where CMPYCODE='" + CmpyCode + "' and FNMBRANCH_CODE='" + FNMBranch_CODE + "'  and Flag=0");

            }
            return false;
        }
        public List<ComDropTbl> GetNationList(string CmpyCode, string Prefix)
        {
            //return drop.GetNationList(CmpyCode);
            return drop.GetCommonDrop("Code,NAME as [CodeName]", "MNAT019", " CmpyCode='"+ CmpyCode + "' and (Code like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetCurrencyList(string Prefix)
        {
            // return drop.GetCurrencyList(CmpyCode);
            return drop.GetCommonDrop("CURRENCY_CODE as [Code],CURRENCY_NAME as [CodeName]", "FNM_CURRENCY", " Flag=0 and (CURRENCY_CODE like '" + Prefix + "%' or CURRENCY_NAME like '" + Prefix + "%')");
        }
        public List<FNMBranch> GetFNMBranch(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMBRANCH_CODE,CMPYCODE,DESCRIPTION,SNO,PRINTNAME,ADDRESS,EMAIL,WEBSITE,MOBILE,CURRENCY,COUNTRY,STATE,DIVISION from FNMBRANCH where CMPYCODE='" + CmpyCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNMBranch> ObjList = new List<FNMBranch>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNMBranch()
                {
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    FNMBRANCH_CODE = dr["FNMBRANCH_CODE"].ToString(),
                    DESCRIPTION = dr["DESCRIPTION"].ToString(),
                    PRINTNAME=dr["PRINTNAME"].ToString(),
                    ADDRESS = dr["ADDRESS"].ToString(),
                    EMAIL = dr["EMAIL"].ToString(),
                    WEBSITE = dr["WEBSITE"].ToString(),
                    MOBILE = dr["MOBILE"].ToString(),
                    CURRENCY = dr["CURRENCY"].ToString(),
                    COUNTRY = dr["COUNTRY"].ToString(),
                    STATE=dr["STATE"].ToString(),
                    DIVISION=dr["DIVISION"].ToString()
                });
            }
            return ObjList;
        }
  
        public FNMBranch_VM SaveFNMBranch(FNMBranch_VM branch)
        {
            try
            {
                if (!branch.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FNMBranchDetailsNew> ObjList = new List<FNMBranchDetailsNew>();
                    ObjList.AddRange(branch.FNMBranchDetailsnew.Select(m => new FNMBranchDetailsNew
                    {
                        CMPYCODE = m.CMPYCODE,
                        FNMBRANCH_CODE = m.FNMBRANCH_CODE,
                        DESCRIPTION = m.DESCRIPTION,
                         SNO=m.SNO,
                        PRINTNAME = m.PRINTNAME,
                        ADDRESS = m.ADDRESS,
                        EMAIL = m.EMAIL,
                        WEBSITE = m.WEBSITE,
                        MOBILE = m.MOBILE,
                        CURRENCY = m.CURRENCY,
                        COUNTRY = m.COUNTRY,
                        STATE = m.STATE,
                        DIVISION=m.DIVISION,
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FNMBRANCH where CmpyCode='" + branch.CMPYCODE + "' and FNMBRANCH_CODE='" + branch.FNMBRANCH_CODE + "'");
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.Append("'" + ObjList[n - 1].FNMBRANCH_CODE + "',");
                            sb.Append("'" + branch.CMPYCODE + "',");
                            sb.Append("'" + ObjList[n - 1].DESCRIPTION + "',");
                            sb.Append("'" + ObjList[n - 1].SNO + "',");
                            sb.Append("'" + ObjList[n - 1].PRINTNAME + "',");
                            sb.Append("'" + ObjList[n - 1].ADDRESS + "',");
                            sb.Append("'" + ObjList[n - 1].EMAIL + "',");
                            sb.Append("'" + ObjList[n - 1].WEBSITE + "',");
                            sb.Append("'" + ObjList[n - 1].MOBILE + "',");
                            sb.Append("'" + ObjList[n - 1].CURRENCY + "',");
                            sb.Append("'" + ObjList[n - 1].COUNTRY + "',");
                            sb.Append("'" + ObjList[n - 1].DIVISION + "',");
                            sb.Append("'" + ObjList[n - 1].STATE + "')");

                            _EzBusinessHelper.ExecuteNonQuery("insert into FNMBRANCH(FNMBRANCH_CODE,CMPYCODE,DESCRIPTION,SNO,PRINTNAME,ADDRESS,EMAIL,WEBSITE,MOBILE,CURRENCY,COUNTRY,DIVISION,STATE) values(" + sb.ToString() + "");
                            _EzBusinessHelper.ActivityLog(branch.CMPYCODE, branch.UserName, "Add FN Category", branch.FNMBRANCH_CODE, Environment.MachineName);
                            branch.SaveFlag = true;
                            branch.ErrorMessage = string.Empty;
                        }
                        else
                        {
                            Drecord.Add(branch.FNMBRANCH_CODE.ToString());
                            //  branch.Drecord = Drecord;
                            branch.SaveFlag = false;
                            branch.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                  
                    return branch;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FNMBRANCH where CmpyCode='" + branch.CMPYCODE + "' and FNMBRANCH_CODE='" + branch.FNMBRANCH_CODE + "'and Flag=0");
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();
                  
                    sb.Append("CMPYCODE='" + branch.CMPYCODE + "',");
                    sb.Append("DESCRIPTION='" + branch.DESCRIPTION + "',");
                    sb.Append("SNO='" + branch.SNO + "',");
                    //  sb.Append("'" + dtstr8 + "',");
                    sb.Append("PRINTNAME='" + branch.PRINTNAME + "',");
                    sb.Append("ADDRESS='" + branch.ADDRESS + "',");
                    sb.Append("EMAIL='" + branch.EMAIL + "',");
                    sb.Append("WEBSITE='" + branch.WEBSITE + "',");
                    sb.Append("MOBILE='" + branch.MOBILE + "',");
                    sb.Append("CURRENCY='" + branch.CURRENCY + "',");
                    sb.Append("COUNTRY='" + branch.COUNTRY + "',");
                    sb.Append("DIVISION='" + branch.DIVISION + "',");
                    sb.Append("STATE='" + branch.STATE + "'"); 
                    _EzBusinessHelper.ExecuteNonQuery("update FNMBRANCH set  " + sb + " where CmpyCode='" + branch.CMPYCODE + "' and FNMBRANCH_CODE='" + branch.FNMBRANCH_CODE + "' and Flag=0");

                    _EzBusinessHelper.ActivityLog(branch.CMPYCODE, branch.UserName, "Update FNMBranch", branch.FNMBRANCH_CODE, Environment.MachineName);

                    branch.SaveFlag = true;
                    branch.ErrorMessage = string.Empty;
                }
                else
                {
                    branch.SaveFlag = false;
                    branch.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                branch.SaveFlag = false;


            }

            return branch;
        }

        public FNMBranch_VM EditFNMBranch(string CmpyCode,string BranchCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select DIVISION,FNMBRANCH_CODE,CMPYCODE,DESCRIPTION,SNO,PRINTNAME,ADDRESS,EMAIL,WEBSITE,MOBILE,CURRENCY,COUNTRY,STATE from FNMBRANCH where CMPYCODE='" + CmpyCode + "' and FNMBRANCH_CODE='" + BranchCode + "' and Flag=0");// 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FNMBranch_VM ObjList = new FNMBranch_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.CMPYCODE = dr["CmpyCode"].ToString();
                ObjList.FNMBRANCH_CODE = dr["FNMBRANCH_CODE"].ToString();
                ObjList.DESCRIPTION = dr["DESCRIPTION"].ToString();
                ObjList.PRINTNAME = dr["PRINTNAME"].ToString();
                ObjList.ADDRESS = dr["ADDRESS"].ToString();
                ObjList.EMAIL = dr["EMAIL"].ToString();
                ObjList.WEBSITE = dr["WEBSITE"].ToString();
                ObjList.MOBILE = dr["MOBILE"].ToString();
                ObjList.CURRENCY = dr["CURRENCY"].ToString();
                ObjList.COUNTRY = dr["COUNTRY"].ToString();
                ObjList.STATE = dr["STATE"].ToString();
                ObjList.DIVISION = dr["DIVISION"].ToString();

            }
            return ObjList;
        }

        public List<ComDropTbl> GetDivisionList(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("DivisionCode as [Code],DivisionName as [CodeName]", "MDIV011", " Flag=0 and (DivisionCode like '" + Prefix + "%' or DivisionName like '" + Prefix + "%')");
        }
    }
}
