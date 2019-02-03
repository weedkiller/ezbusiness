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
    public class ShiftMasterPayrollRepository: IShiftMasterPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public List<ShiftMaster> GetShiftList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRSFT001 where CmpyCode='" + CmpyCode + "'and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ShiftMaster> ObjList = new List<ShiftMaster>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ShiftMaster()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    PRSFT001_code = dr["PRSFT001_code"].ToString(),
                    country = dr["country"].ToString(),
                    division = dr["division"].ToString(),
                    EdTime = dr["EdTime"].ToString(),
                    StTime = dr["StTime"].ToString(),
                    ShiftName = dr["ShiftName"].ToString(),




                });

            }
            return ObjList;
        }

        public List<ShiftAlloc> GetShiftGrid(string CmpyCode, string PRSFT001_code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRSFT002 where CmpyCode='" + CmpyCode + "' and PRSFT001_code='" + PRSFT001_code + "'and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ShiftAlloc> ObjList = new List<ShiftAlloc>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ShiftAlloc()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    PRSFT002_code = dr["PRSFT002_code"].ToString(),
                    PRSFT001_code = dr["PRSFT001_code"].ToString(),
                    ApprovalYN = dr["ApprovalYN"].ToString(),
                    division = dr["division"].ToString(),
                    Effect_Date = Convert.ToDateTime(dr["Effect_Date"].ToString()),
                    Enttry_Date = Convert.ToDateTime(dr["Enttry_Date"].ToString()),
                    
                });
            }
            return ObjList;
        }

        public ShiftMasterVM SaveShift(ShiftMasterVM Sft)
        {
            int n;
            int k = 0;
            string Dst1, Dst2 = null;
            DateTime dt1,dt2;
            string Approved;

            if (!Sft.EditFlag)
            {

               
                ShiftMaster pt = new ShiftMaster();
                int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + Sft.CmpyCode + "' and Code='PRSFT' ");

                //pt.PRBM001_code = string.Concat("PRBM", "-", (pno + 1).ToString().PadLeft(4, '0')).ToString();                                
                List<ShiftAllocationH> ObjList = new List<ShiftAllocationH>();
                ObjList.AddRange(Sft.Shift.Select(m => new ShiftAllocationH
                {
                    
               
            
                CmpyCode =m.CmpyCode,
                    PRSFT002_code = m.PRSFT002_code,
                    PRSFT001_code= m.PRSFT001_code,
                    Enttry_Date=m.Enttry_Date,  
                    Effect_Date=m.Effect_Date,
                    division=m.division,
                    ApprovalYN=m.ApprovalYN,
                                                                            
                }).ToList());

                k = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSFT001 where CmpyCode='" + Sft.CmpyCode + "' and PRSFT001_code='" + Sft.PRSFT001_code + "' ");
              
                n = ObjList.Count;
                if (n != 0 && k == 0)
                {

                    _EzBusinessHelper.ExecuteNonQuery("insert into PRSFT001(PRSFT001_code,CmpyCode,country,division,ShiftName,StTime,EdTime) values('" + Sft.PRSFT001_code + "','" + Sft.CmpyCode + "','" + Sft.country + "','" + Sft.division + "','" + Sft.ShiftName + "','" + Sft.StTime + "','" + Sft.EdTime + "')");

                    while (n > 0)
                    {

                        dt1 = Convert.ToDateTime(ObjList[n - 1].Enttry_Date.ToString());
                        Dst1 = dt1.ToString("yyyy-MM-dd hh:mm:ss tt");
                        dt2 = Convert.ToDateTime(ObjList[n - 1].Effect_Date.ToString());
                        Dst2 = dt2.ToString("yyyy-MM-dd hh:mm:ss tt");
                        //if (ObjList[n - 1].ApprovalYN ="YES")
                        //    Approved = "Y";
                        //else
                        //    Approved = "N";


                        _EzBusinessHelper.ExecuteNonQuery("insert into PRSFT002(PRSFT001_code,PRSFT002_code,CmpyCode,division,Enttry_Date,Effect_Date,ApprovalYN) values('" + Sft.PRSFT001_code + "','" + ObjList[n - 1].PRSFT002_code + "','" + Sft.CmpyCode + "', '" + ObjList[n - 1].division + "', '" + Dst1 + "', '" + Dst2 + "', '" + ObjList[n - 1].ApprovalYN + "')");



                        n = n - 1;
                    }
                    _EzBusinessHelper.ActivityLog(Sft.CmpyCode, Sft.UserName, "Add Shift  Master", Sft.PRSFT001_code, Environment.MachineName);
                    _EzBusinessHelper.ExecuteNonQuery("UPDATE PARTTBL001 SET Nos ="+(pno+1)+" where CmpyCode='" + Sft.CmpyCode + "' and Code='PRSFT'");
                    Sft.SaveFlag = true;
                    Sft.ErrorMessage = string.Empty;
                }
                else
                {
                    Sft.SaveFlag = true;
                    Sft.ErrorMessage = "Duplicate Record";
                }
               
            }
            else
            {
              
                k = 0;//_EzBusinessHelper.ExecuteScalar("Select count(*) from PRSFT003 where CmpyCode='" + Sft.CmpyCode + "' and PRSFT001_code='" + Sft.PRSFT001_code + "'");
                n = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSFT001 where CmpyCode='" + Sft.CmpyCode + "' and PRSFT001_code='" + Sft.PRSFT001_code + "' ");

                if (n != 0 && k == 0)
                {
                    string DT1, DT2;

                    _EzBusinessHelper.ExecuteNonQuery("delete from PRSFT001 where CmpyCode='" + Sft.CmpyCode + "' and PRSFT001_code='" + Sft.PRSFT001_code + "'");
                    _EzBusinessHelper.ExecuteNonQuery("delete from PRSFT002 where CmpyCode='" + Sft.CmpyCode + "' and PRSFT001_code='" + Sft.PRSFT001_code + "'");

                    ShiftMaster pt = new ShiftMaster();
                    List<ShiftAllocationH> ObjList = new List<ShiftAllocationH>();
                    ObjList.AddRange(Sft.Shift.Select(m => new ShiftAllocationH
                    {
                        PRSFT001_code = m.PRSFT001_code,
                        PRSFT002_code = m.PRSFT002_code,
                        CmpyCode = m.CmpyCode,
                        ApprovalYN = m.ApprovalYN,
                        division = m.division,
                        Effect_Date = m.Effect_Date,
                        Enttry_Date = m.Enttry_Date

                    }).ToList());

                    _EzBusinessHelper.ExecuteNonQuery("insert into PRSFT001(PRSFT001_code,CmpyCode,country,division,ShiftName,StTime,EdTime) values('" + Sft.PRSFT001_code + "','" + Sft.CmpyCode + "','" + Sft.country + "','" + Sft.division + "','" + Sft.ShiftName + "','" + Sft.StTime + "','" + Sft.EdTime + "')");
                    n = ObjList.Count;


                    while (n > 0)
                    {
                        dt1 = Convert.ToDateTime(ObjList[n - 1].Enttry_Date.ToString());
                        Dst1 = dt1.ToString("yyyy-MM-dd hh:mm:ss tt");
                        dt2 = Convert.ToDateTime(ObjList[n - 1].Effect_Date.ToString());
                        Dst2 = dt2.ToString("yyyy-MM-dd hh:mm:ss tt");

                        _EzBusinessHelper.ExecuteNonQuery("insert into PRSFT002(PRSFT001_code,PRSFT002_code,CmpyCode,division,Enttry_Date,Effect_Date,ApprovalYN) values('" + Sft.PRSFT001_code + "','" + ObjList[n - 1].PRSFT002_code + "','" + Sft.CmpyCode + "', '" + ObjList[n - 1].division + "', '" + Dst1 + "', '" + Dst2 + "', '" + ObjList[n - 1].ApprovalYN + "')");
                        n = n - 1;
                    }

                    _EzBusinessHelper.ActivityLog(Sft.CmpyCode, Sft.UserName, "Update Shift  Master", Sft.PRSFT001_code, Environment.MachineName);
                    Sft.SaveFlag = true;
                    Sft.ErrorMessage = string.Empty;

                }
                else
                {
                    Sft.SaveFlag = true;
                    Sft.ErrorMessage = "Error occur";
                }



            }

            return Sft;
        }

        public ShiftMasterVM GetShiftEdit(string CmpyCode, string PRSFT001_code)
        {

            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRSFT001 where CmpyCode='" + CmpyCode + "' and PRSFT001_code='" + PRSFT001_code + "'and Flag=0");

            dt = ds.Tables[0];
            ShiftMasterVM pr = new ShiftMasterVM();
            foreach (DataRow dr in dt.Rows)
            {
                pr.CmpyCode = dr["CmpyCode"].ToString();
                pr.PRSFT001_code = dr["PRSFT001_code"].ToString();
                pr.country = dr["country"].ToString();
                pr.StTime = dr["StTime"].ToString();
                pr.EdTime = dr["EdTime"].ToString();
                pr.division = dr["division"].ToString();
                pr.ShiftName = dr["ShiftName"].ToString();
            }
            return pr;
        }

        public List<Nation> GetNationList(string CmpyCode)
        {
            return drop.GetNationList(CmpyCode);
        }

        public bool DeleteShift(string CmpyCode, string PRSFT001_code, string username)
        {
            int k = 0;// _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSFT003 where CmpyCode='" + CmpyCode + "' and PRSFT001_code='" + PRSFT001_code + "'");
            int Bns = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSFT001 where CmpyCode='" + CmpyCode + "' and PRSFT001_code='" + PRSFT001_code + "'");
            if (Bns != 0 && k == 0)
            {
                _EzBusinessHelper.ExecuteNonQuery("update PRSFT001 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRSFT001_code='" + PRSFT001_code + "'");
                _EzBusinessHelper.ExecuteNonQuery("update PRSFT002 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRSFT001_code='" + PRSFT001_code + "'");

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Shift Master", PRSFT001_code, Environment.MachineName);

                return true;
            }
            return false;
        }

        public int UseShiftAlloc(string CmpyCode, string PRSFT001_code, string PRSFT002_code)
        {
            int Sns = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSFT001 where CmpyCode='" + CmpyCode + "' and PRSFT001_code='" + PRSFT001_code + "' and PRSFT002_code='" + PRSFT002_code + "'");
            return Sns;
        }
    }
}
