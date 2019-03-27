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
    public class EmpShiftPayrollRepository : IEmpShiftPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public List<EmpShift> GetEmpShiftList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select a.PRSFT003_code,a.EmpCode,b.Empname,a.PRSFT002_code,c.ShiftName from PRSFT003  a inner join MEM001 b "+
                                                    " on a.CmpyCode = b.Cmpycode and a.EmpCode = b.EmpCode and a.Flag=b.Flag " +
                                                    " inner join  PRSFT001 c "+
                                                    " on c.PRSFT001_code = a.PRSFT001_code and a.CmpyCode = c.Cmpycode and a.Flag=c.Flag where a.CmpyCode='" + CmpyCode + "' and a.Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<EmpShift> ObjList = new List<EmpShift>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new EmpShift()
                {
                    //CmpyCode = dr["CmpyCode"].ToString(),
                    //PRSFT002_code = dr["PRSFT002_code"].ToString(),
                    //EmpCode = dr["EmpCode"].ToString(),
                    //Remarks = dr["Remarks"].ToString(),
                    //PRSFT003_code = dr["PRSFT003_code"].ToString(),
                    //PRSFT001_code = dr["PRSFT001_code"].ToString(),
                    //SNO = Convert.ToInt32(dr["SNO"].ToString()),
                    PRSFT003_code =dr["PRSFT003_code"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(),
                    Empname = dr["Empname"].ToString(),
                    PRSFT002_code = dr["PRSFT002_code"].ToString(),
                    ShiftName = dr["ShiftName"].ToString(),
                });

            }
            return ObjList;

           
        }

        public EmpShiftVM SaveEmpShift(EmpShiftVM Sft)
        {
            if (!Sft.EditFlag)
            {
                int Exi = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRSFT003 where CmpyCode='" + Sft.CmpyCode + "' and PRSFT003_code='" + Sft.PRSFT003_code + "' and Flag=0");

                int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + Sft.CmpyCode + "' and Code='PRSFT' ");
                if (Exi==0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("insert into PRSFT003(PRSFT003_code,PRSFT002_code,PRSFT001_code,SNO,EmpCode,Remarks,CmpyCode) values('" + Sft.PRSFT003_code + "','" + Sft.PRSFT002_code + "','" + Sft.PRSFT001_code + "','" + Sft.SNO + "','" + Sft.EmpCode + "','" + Sft.Remarks + "','" + Sft.CmpyCode + "')");
                    _EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + Sft.CmpyCode + "' and Code='PRSFT'");
                    Sft.SaveFlag = true;
                    Sft.ErrorMessage = string.Empty;
                }
                else
                {

                    Sft.SaveFlag = false;
                    Sft.ErrorMessage = "Duplicate Record";
                }
              
            }
            else
            {
                int n= 0;
                //_EzBusinessHelper.ExecuteScalar("Select count(*) from PRSFT003 where CmpyCode='" + Sft.CmpyCode + "' and PRSFT001_code='" + Sft.PRSFT001_code + "'");
                n = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSFT003 where CmpyCode='" + Sft.CmpyCode + "' and PRSFT003_code='" + Sft.PRSFT003_code + "' ");

                if (n != 0)
                {
                   

                    _EzBusinessHelper.ExecuteNonQuery("delete from PRSFT003 where CmpyCode='" + Sft.CmpyCode + "' and PRSFT003_code='" + Sft.PRSFT003_code + "'");

                    _EzBusinessHelper.ExecuteNonQuery("insert into PRSFT003(PRSFT003_code,PRSFT002_code,PRSFT001_code,SNO,EmpCode,Remarks,CmpyCode) values('" + Sft.PRSFT003_code + "','" + Sft.PRSFT002_code + "','" + Sft.PRSFT001_code + "','" + Sft.SNO + "','" + Sft.EmpCode + "','" + Sft.Remarks + "','" + Sft.CmpyCode + "')");

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

        public EmpShiftVM GetEmpShiftEdit(string CmpyCode, string PRSFT003_code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRSFT003 where CmpyCode='" + CmpyCode + "' and PRSFT003_code='" + PRSFT003_code +"' and Flag=0");

            dt = ds.Tables[0];
            EmpShiftVM es = new EmpShiftVM();
            foreach (DataRow dr in dt.Rows)
            {
                es.CmpyCode = dr["CmpyCode"].ToString();
                es.EmpCode = dr["EmpCode"].ToString();
                es.PRSFT002_code = dr["PRSFT002_code"].ToString();
                es.Remarks = dr["Remarks"].ToString();
                es.SNO = Convert.ToInt32(dr["SNO"].ToString());
                es.PRSFT003_code = dr["Remarks"].ToString();
                es.PRSFT001_code = dr["PRSFT001_code"].ToString();



            }
            return es;
            
        }

        public List<Employee> GetEmpCodes(string CmpyCode)
        {
            return drop.GetEmpCodes(CmpyCode ,"S");
        }
        public List<ShiftMaster> GetShiftCodes(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRSFT001 where CmpyCode='" + CmpyCode + "'");
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
                    EdTime = dr["EdTime"].ToString(),
                    ShiftName = dr["ShiftName"].ToString(),
                    division = dr["division"].ToString(),
                    StTime = dr["StTime"].ToString(),
                    

                });

            }
            return ObjList;

        }
  
       
        public List<ShiftAlloc> GetShiftAllocCode(string CmpyCode, string PRSFT001_code)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRSFT002 where CmpyCode='" + CmpyCode + "' and PRSFT001_code= '" + PRSFT001_code +"'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ShiftAlloc> ObjList = new List<ShiftAlloc>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ShiftAlloc()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    PRSFT001_code = dr["PRSFT001_code"].ToString(),
                    Enttry_Date = Convert.ToDateTime(dr["Enttry_Date"].ToString()),
                    Effect_Date = Convert.ToDateTime(dr["Effect_Date"].ToString()),
                    ApprovalYN = dr["ApprovalYN"].ToString(),
                    PRSFT002_code = dr["PRSFT002_code"].ToString(),
                    division = dr["division"].ToString(),

                });

            }
            return ObjList;

        }
        public bool DeleteEmpShift(string CmpyCode, string PRSFT003_code, string username)
        {
            int ES = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRSFT003 where CmpyCode='" + CmpyCode + "' and PRSFT003_code='" + PRSFT003_code + "'");
            if (ES != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Emp Shift Master", PRSFT003_code, Environment.MachineName);

                return  _EzBusinessHelper.ExecuteNonQuery1("update PRSFT003 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRSFT003_code='" + PRSFT003_code + "'");
              //  return true;
            }
            return false;
        }

        
    }
}
