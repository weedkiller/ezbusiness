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
            return drop.GetEmpCodes(CmpyCode, "A");
        }
        public List<Attendence> GetLeaveTypList(string CmpyCode)
        {
            return drop.GetAtens(CmpyCode);
        }

        public List<TimeSheetDetail> GetOTDetailList(string CmpyCode, string EmpCode, DateTime dte1)
        {

            string dtstr1 = null;
            DateTime dte;

            dte = Convert.ToDateTime(dte1);
            dtstr1 = dte.ToString("yyyy-MM-dd");
            ds = _EzBusinessHelper.ExecuteDataSet("select * from PRDTD002  where format(Att_Date,'yyyy-MM-dd') ='" + dtstr1 + "'  and Empcode ='" + EmpCode + "' and cmpycode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<TimeSheetDetail> ObjList = new List<TimeSheetDetail>();
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
                    //ReportingEmp=dr["Reporting Emp"].ToString()
                });

            }
            return ObjList;
        }

        public List<TimeSheetDetail> GetAPDetailList(string CmpyCode, string EmpCode, DateTime dte1)
        {

            string dtstr1 = null;
            DateTime dte;

            dte = Convert.ToDateTime(dte1);
            dtstr1 = dte.ToString("yyyy-MM-dd");
            ds = _EzBusinessHelper.ExecuteDataSet("select Att_Date,ATT from PRDTD002  where format(Att_Date,'yyyy-MM-dd') ='" + dtstr1 + "'  and Empcode ='" + EmpCode + "' and cmpycode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<TimeSheetDetail> ObjList = new List<TimeSheetDetail>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new TimeSheetDetail()
                {
                    Att_Date = Convert.ToDateTime(dr["Att_Date"].ToString()),
                    ATT = dr["ATT"].ToString(),

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

                }).ToList());
            }
            n = ObjList.Count;

            while (n > 0)
            {
                dte = Convert.ToDateTime(ObjList[n - 1].Att_Date);
                dtstr1 = dte.ToString("yyyy-MM-dd");
                _EzBusinessHelper.ExecuteNonQuery("update PRDTD002 set OTHrs='" + ObjList[n - 1].OTHrs + "',FOTHrs='" + ObjList[n - 1].FOTHrs + "',HOTHrs='" + ObjList[n - 1].HOTHrs + "',Extrahrs='" + ObjList[n - 1].ExtraHrs + "' where format(Att_Date,'yyyy-MM-dd') ='" + dtstr1 + "' and Empcode ='" + OT.EmpCode + "' and cmpycode='" + OT.Cmpycode + "'");
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

                }).ToList());
            }
            n = ObjList.Count;

            while (n > 0)
            {
                dte = Convert.ToDateTime(ObjList[n - 1].Att_Date);
                dtstr1 = dte.ToString("yyyy-MM-dd");
                _EzBusinessHelper.ExecuteNonQuery("update PRDTD002 set ATT='" + ObjList[n - 1].ATT + "' where format(Att_Date,'yyyy-MM-dd') ='" + dtstr1 + "' and Empcode ='" + OT.EmpCode + "' and cmpycode='" + OT.Cmpycode + "'");
                n = n - 1;
            }

            OT.ErrorMessage = string.Empty;
            OT.SaveFlag = true;

            return OT;
        }
    }
}
