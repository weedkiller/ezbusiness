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
    public class TSDpayrollRepository : ITSDpayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public List<Employee> GetEmpCodes(string CmpyCode)
        {
            return drop.GetEmpCodes(CmpyCode,"A");
        }

        public List<TimeSheetDetail> GetTSDList(string CmpyCode, string EmpCode, DateTime date)
        {
           
            SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
                        new SqlParameter("@date1", date),
            new SqlParameter("@EmpCode",EmpCode)};

            ds = _EzBusinessHelper.ExecuteDataSet("retrieve_timesheetDet", CommandType.StoredProcedure, param);

            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<TimeSheetDetail> ObjList = new List<TimeSheetDetail>();
            try
            {
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new TimeSheetDetail()
                    {

                        EmpCode = dr["EmpCode"].ToString(),
                        Tyear = Convert.ToInt16(dr["Tyear"]),
                        Tmonth = Convert.ToInt16(dr["Tmonth"]),
                        //  SrNo = Convert.ToInt16(dr["SrNo"]),
                        Att_Date = Convert.ToDateTime(dr["Att_Date"]),
                        ATT = dr["ATT"].ToString(),
                        NHrs = dr["NHrs"].ToString() !="" ?Convert.ToDecimal(dr["NHrs"].ToString()):0,
                        ExtraHrs = dr["ExtraHrs"].ToString() !="" ?Convert.ToDecimal(dr["ExtraHrs"].ToString()):0,
                        FOTHrs = dr["FOTHrs"].ToString() !="" ?Convert.ToDecimal(dr["FOTHrs"].ToString()):0,
                        HOTHrs = dr["HOTHrs"].ToString() !="" ?Convert.ToDecimal(dr["HOTHrs"].ToString()):0,
                        OTHrs = dr["OTHrs"].ToString() !="" ?Convert.ToDecimal(dr["OTHrs"].ToString()):0,
                        ReportingEmp=dr["Reporting Emp"].ToString(),
                        Project_code=dr["Project_code"].ToString() !=""? dr["Project_code"].ToString():"-"
                    });

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ObjList;
        }
    }
}
