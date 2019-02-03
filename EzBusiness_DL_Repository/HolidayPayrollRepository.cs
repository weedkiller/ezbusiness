using EzBusiness_DL_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Data;
using System.Data.SqlClient;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Repository
{
    public class HolidayPayrollRepository : IHolidayPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public List<Attendence> GetAttendenceCodesH(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("SELECT Code, LeaveName FROM MLH033  where Code='HL'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Attendence> ObjList = new List<Attendence>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Attendence()
                {
                    Code = dr["Code"].ToString(),
                    LeaveName = dr["LeaveName"].ToString(),
                });

            }
            return ObjList;
        }

        public List<HolidayVM> GetAtensH(string CmpyCode, DateTime date)
        {
            string dtstr = null;
            DateTime dt1 = Convert.ToDateTime(date.ToString());

            dtstr = dt1.ToString("yyyy");
            ds = _EzBusinessHelper.ExecuteDataSet("Select HRPH001_CODE,Holiday_date,COUNTRY,LEAVE_TYPE,Description from HRPH001 where CmpyCode='" + CmpyCode + "'and format(Holiday_date,'yyyy')='" + dtstr + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<HolidayVM> ObjList = new List<HolidayVM>();

            
            foreach (DataRow dr in drc)
            {

                dt1 = Convert.ToDateTime(dr["Holiday_date"].ToString());

                dtstr = dt1.ToString("yyyy-MM-dd");

                ObjList.Add(new HolidayVM()
                {
                   
                    Dates = dtstr,
                  COUNTRY= dr["COUNTRY"].ToString(),
                    LEAVE_TYPECODE = dr["LEAVE_TYPE"].ToString(),
                  Description= dr["Description"].ToString(),
                    HRPH001_CODE = dr["HRPH001_CODE"].ToString()
                });

            }
            return ObjList;
        }

        public HolidayVM SaveHoliday(HolidayVM Hol)
        {
            DateTime dt1;
            try
            {
                if (!Hol.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<HolidayDetailnew> ObjList = new List<HolidayDetailnew>();
                    ObjList.AddRange(Hol.HolidayDetailnew.Select(m => new HolidayDetailnew
                    {
                        CmpyCode = m.CmpyCode,
                        Dates = m.Dates,
                        COUNTRY = m.COUNTRY,
                        LEAVE_TYPECODE = m.LEAVE_TYPECODE,
                        Description = m.Description,
                        HRPH001_CODE=m.HRPH001_CODE
                        

                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;
                    string dtstr;
                    while (n > 0)
                    {
                         dt1 = Convert.ToDateTime(ObjList[n - 1].Dates);

                        dtstr = dt1.ToString("yyyy-MM-dd");


                        int Atens1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from HRPH001 where CmpyCode='" + Hol.CmpyCode + "' and format(Holiday_date,'dd-MM-yyyy')=format(cast('" + dtstr + "'  as date),'dd-MM-yyyy')");
                        if (Atens1 == 0)
                        {                         
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Hol.CmpyCode + "',");
                            sb.Append("'" + dtstr + "',");
                            sb.Append("'" + ObjList[n - 1].COUNTRY + "',");
                            sb.Append("'" + ObjList[n - 1].LEAVE_TYPECODE + "',");
                            sb.Append("'" + ObjList[n - 1].Description + "',");
                            sb.Append("'" + ObjList[n - 1].HRPH001_CODE + "')");

                            _EzBusinessHelper.ExecuteNonQuery("insert into HRPH001(CmpyCode,Holiday_date,COUNTRY,LEAVE_TYPE,Description,HRPH001_CODE) values(" + sb.ToString() + "");

                            _EzBusinessHelper.ActivityLog(Hol.CmpyCode, Hol.UserName, "Add Holiday", dtstr, Environment.MachineName);

                            Hol.SaveFlag = true;
                            Hol.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(dtstr);

                            Hol.Drecord = Drecord;
                            Hol.SaveFlag = false;
                            Hol.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;

                    }


                    return Hol;
                }

            dt1 = Convert.ToDateTime(Hol.Dates);

               string dtstr1 = dt1.ToString("yyyy-MM-dd hh:mm:ss tt");

                var StatsEdit = _EzBusinessHelper.ExecuteNonQuery("Select count(*) from HRPH001 where CmpyCode='" + Hol.CmpyCode + "' and format(Holiday_date,'dd-MM-yyyy')=format(cast('" + dtstr1 + "'  as date),'dd-MM-yyyy')");
                if (StatsEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update HRPH001 set CmpyCode='" + Hol.CmpyCode + "',Holiday_date='" + Hol.Dates + "',COUNTRY='" + Hol.COUNTRY + "',LEAVE_TYPE='" + Hol.LEAVE_TYPECODE + "',Description='" + Hol.Description + "' where HRPH001_CODE='"+ Hol.HRPH001_CODE +"' and  CmpyCode='" + Hol.CmpyCode + "' and format(Holiday_date,'dd-MM-yyyy')=format(cast('" + dtstr1 + "'  as date),'dd-MM-yyyy')");

                    _EzBusinessHelper.ActivityLog(Hol.CmpyCode, Hol.UserName, "Update Holiday", Hol.Dates, Environment.MachineName);

                    Hol.SaveFlag = true;
                    Hol.ErrorMessage = string.Empty;
                }
                else
                {
                    Hol.SaveFlag = false;
                    Hol.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Hol.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }


            return Hol;

        }

        public bool DeleteHoliday(string CmpyCode, DateTime date1, string username)
        {
            DateTime dt1;
            string dtstr;
            dt1 = Convert.ToDateTime(date1);

            dtstr = dt1.ToString("yyyy-MM-dd");

            int Stats = _EzBusinessHelper.ExecuteScalar("Select count(*) from HRPH001 where CmpyCode='" + CmpyCode + "' and format(Holiday_date,'dd-MM-yyyy')=format(cast('" + dtstr + "'  as date),'dd-MM-yyyy')");
            if (Stats != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Holiday", date1.ToString() , Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update HRPH001 set Flag=1 where CmpyCode='" + CmpyCode + "' and format(Holiday_date,'dd-MM-yyyy')=format(cast('" + dtstr + "'  as date),'dd-MM-yyyy')");
                //return true;
            }
            return false;
        }
    }
    }
    

