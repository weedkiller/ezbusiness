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
using EzBusiness_ViewModels;

namespace EzBusiness_DL_Repository
{
    public class OTPayrollRepository : IOTPayrollRepository
    {

        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public List<Employee> GetEmpCodeList(string CmpyCode)
        {
            return drop.GetEmpCodes(CmpyCode, "T");
        }
        public List<Attendence> GetLeaveTypList(string CmpyCode)
        {
            return drop.GetAtens(CmpyCode);
        }

        public List<TimeSheetDetail> GetOTDetailList(string CmpyCode, string EmpCode, DateTime dte1, DateTime dte2,string typ)
        {

            string dtstr1, dtstr2 = null;
            DateTime dte;

            dte = Convert.ToDateTime(dte1);
            dtstr1 = dte.ToString("yyyy-MM-dd");

            dte = Convert.ToDateTime(dte2);
            dtstr2 = dte.ToString("yyyy-MM-dd");

            //
            //if (typ == "E")
            //{
            //    ds = _EzBusinessHelper.ExecuteDataSet("select Att_Date,EmpCode,EmpName,(select isnull(ReportingEmp,'-') from MEM001 b where b.Cmpycode=a.Cmpycode and  b.EmpCode=a.EmpCode ) as [Reporting Emp],TYEAR,TMONTH,ATT,NHrs,OTHrs,HOTHrs,FOTHrs,ExtraHrs,TotalHrs from PRDTD002  a  where format(a.Att_Date,'yyyy-MM-dd') >='" + dtstr1 + "' and format(a.Att_Date,'yyyy-MM-dd') <='" + dtstr2 + "'  and a.EmpCode in (SELECT EmpCode from MEM001 where  Flag=0 and (WorkingStatus='Y' Or WorkingStatus='W') And (ReportingEmp='" + EmpCode + "' or EmpCode='" + EmpCode + "')  and CmpyCode=a.cmpycode)  and a.cmpycode='" + CmpyCode + "'");

            //}
            //else
            //{
            //    ds = _EzBusinessHelper.ExecuteDataSet("select Att_Date,EmpCode,EmpName,(select isnull(ReportingEmp,'-') from MEM001 b where b.Cmpycode=a.Cmpycode and  b.EmpCode=a.EmpCode ) as [Reporting Emp],TYEAR,TMONTH,ATT,NHrs,OTHrs,HOTHrs,FOTHrs,ExtraHrs,TotalHrs from PRDTD002  a  where format(a.Att_Date,'yyyy-MM-dd') >='" + dtstr1 + "' and format(a.Att_Date,'yyyy-MM-dd') <='" + dtstr2 + "'  and a.EmpCode in (SELECT EmpCode from MEM001 where  Flag=0 and (WorkingStatus='Y' Or WorkingStatus='W') And DIVISION='" + EmpCode + "' )  and CmpyCode=a.cmpycode)  and a.cmpycode='" + CmpyCode + "'");
            //}
            SqlParameter[] param = { new SqlParameter("@mod", typ),
                                     new SqlParameter("@PassVal",EmpCode),
                                     new SqlParameter("@Cmpycode", CmpyCode),
                                     new SqlParameter("@fdate",dtstr1),
                                     new SqlParameter("@tdate",dtstr2)
                                    };
            ds = _EzBusinessHelper.ExecuteDataSet("Sp_OTDropdownFill", CommandType.StoredProcedure, param);

            //dt = ds.Tables[0];

            //SqlParameter[] param = {new SqlParameter("@CmpyCode", CmpyCode),
            //            new SqlParameter("@date1", dtstr1),
            //new SqlParameter("@EmpCode",EmpCode)};

            //ds = _EzBusinessHelper.ExecuteDataSet("retrieve_timesheetDet", CommandType.StoredProcedure, param);
            List<TimeSheetDetail> ObjList = null;
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];

                DataRowCollection drc = dt.Rows;
                ObjList = new List<TimeSheetDetail>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new TimeSheetDetail()
                    {
                        Tmonth = Convert.ToInt16(dr["Tmonth"].ToString()),
                        ATT = dr["ATT"].ToString(),
                        Att_Date = Convert.ToDateTime(dr["Att_Date"].ToString()),
                        NHrs = dr["NHrs"].ToString() != "" ? Convert.ToDecimal(dr["NHrs"].ToString()) : 0,
                        ExtraHrs = dr["ExtraHrs"].ToString() != "" ? Convert.ToDecimal(dr["ExtraHrs"].ToString()) : 0,
                        FOTHrs = dr["FOTHrs"].ToString() != "" ? Convert.ToDecimal(dr["FOTHrs"].ToString()) : 0,
                        HOTHrs = dr["HOTHrs"].ToString() != "" ? Convert.ToDecimal(dr["HOTHrs"].ToString()) : 0,
                        OTHrs = dr["OTHrs"].ToString() != "" ? Convert.ToDecimal(dr["OTHrs"].ToString()) : 0,
                        EmpCode = dr["EmpCode"].ToString()
                    });

                }
            }
           
            return ObjList;
        }

        public List<TimeSheetDetail> GetAPDetailList(string CmpyCode, string EmpCode, DateTime dte1)
        {

            string dtstr1 = null;
            DateTime dte;

            dte = Convert.ToDateTime(dte1);
            dtstr1 = dte.ToString("yyyy-MM-dd");
            ds = _EzBusinessHelper.ExecuteDataSet("select Att_Date,ATT,EmpCode from PRDTD002  where format(Att_Date,'yyyy-MM-dd') ='" + dtstr1 + "'  and Empcode in (SELECT EmpCode from MEM001 where  Flag=0 and (WorkingStatus='Y' Or WorkingStatus='W') And EmpCode='" + EmpCode + "'  or ReportingEmp='" + EmpCode + "'   and CmpyCode='" + CmpyCode + "') and cmpycode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<TimeSheetDetail> ObjList = new List<TimeSheetDetail>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new TimeSheetDetail()
                {
                    Att_Date = Convert.ToDateTime(dr["Att_Date"].ToString()),
                    ATT = dr["ATT"].ToString(),
                    EmpCode=dr["EmpCode"].ToString()
                });

            }
            return ObjList;
        }

        public OTVM SaveOT(OTVM OT)
        {
            string dtstr1 = null;
            DateTime dte;
            int n;
            List<OTExtraDetail> ObjList = new List<OTExtraDetail>();
            if (OT.OTExtraDetailnews != null)
            {
                ObjList.AddRange(OT.OTExtraDetailnews.Select(m => new OTExtraDetail
                {
                    Att_Date = m.Att_Date,
                    ExtraHrs = Convert.ToDecimal(m.ExtraHrs),
                    FOTHrs = Convert.ToDecimal(m.FOThrs),
                    HOTHrs = Convert.ToDecimal(m.Hhrs),
                    NHrs = Convert.ToDecimal(m.Nhrs),
                    OTHrs = Convert.ToDecimal(m.Ohrs),
                    EmpCode=m.EmpCode

                }).ToList());
            }
            n = ObjList.Count;

            while (n > 0)
            {
                dte = Convert.ToDateTime(ObjList[n - 1].Att_Date);
                dtstr1 = dte.ToString("yyyy-MM-dd");
                _EzBusinessHelper.ExecuteNonQuery("update PRDTD002 set OTHrs='" + ObjList[n - 1].OTHrs + "',FOTHrs='" + ObjList[n - 1].FOTHrs + "',HOTHrs='" + ObjList[n - 1].HOTHrs + "',Extrahrs='" + ObjList[n - 1].ExtraHrs + "' where format(Att_Date,'yyyy-MM-dd') ='" + dtstr1 + "' and Empcode ='" + ObjList[n - 1].EmpCode + "' and cmpycode='" + OT.Cmpycode + "'");
                n = n - 1;
            }

            OT.ErrorMessage = string.Empty;
            OT.SaveFlag = true;

            return OT;
        }



        public OTVM SaveAP(OTVM OT)
        {
            string dtstr1 = null;
            DateTime dte;
            int n;

            List<OTExtraATT> ObjList = new List<OTExtraATT>();
            if (OT.OTExtraATTnews != null)
            {
                ObjList.AddRange(OT.OTExtraATTnews.Select(m => new OTExtraATT
                {
                    Att_Date = m.Att_Date,
                    ATT = (m.ATT).ToString(),
                    EmpCode=m.EmpCode

                }).ToList());
            }
            n = ObjList.Count;

            while (n > 0)
            {
                dte = Convert.ToDateTime(ObjList[n - 1].Att_Date);
                dtstr1 = dte.ToString("yyyy-MM-dd");
                _EzBusinessHelper.ExecuteNonQuery("update PRDTD002 set NHrs=0, ATT='" + ObjList[n - 1].ATT + "' where format(Att_Date,'yyyy-MM-dd') ='" + dtstr1 + "' and Empcode ='" + ObjList[n - 1].EmpCode + "' and cmpycode='" + OT.Cmpycode + "'");
                n = n - 1;
            }

            OT.ErrorMessage = string.Empty;
            OT.SaveFlag = true;

            return OT;
        }

        public List<Employee> GetEmpRepCodeList(string CmpyCode, string EmpCode)
        {
            string qur = "SELECT EmpCode FROM MEM001 WHERE CmpyCode = '" + CmpyCode + "' and Flag=0 And WorkingStatus = 'Y' and EmpCode='" + EmpCode + "'  or ReportingEmp='" + EmpCode + "'   and CmpyCode='" + CmpyCode + "'  Order By EmpCode";
            ds = _EzBusinessHelper.ExecuteDataSet(qur);
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Employee> ObjList = new List<Employee>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Employee()
                {                    
                    EmpCode = dr["EmpCode"].ToString()
                });

            }
            return ObjList;
        }

        public List<Division> GetDivCodeList(string CmpyCode)
        {
            return drop.GetDivCode(CmpyCode);
        }

        public List<ProjectMaster> GetPrjCodeList(string CmpyCode)
        {
            return drop.GetProjects(CmpyCode);
        }
    }
}
