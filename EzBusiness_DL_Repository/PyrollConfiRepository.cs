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
using System.Transactions;

namespace EzBusiness_DL_Repository
{
    public class PyrollConfiRepository : IPyrollConfiRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        DropListFillFun drop = new DropListFillFun();
        public bool DeletePyrollConfi(string Code, string CmpyCode,string UserName)
        {
            int Lons = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRCNF001 where CmpyCode='" + CmpyCode + "' and PRCNF001_CODE='" + Code + "'");
            if (Lons != 0)
            {
                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete PayRoll Config Master", Code, Environment.MachineName);
                return _EzBusinessHelper.ExecuteNonQuery1("update PRCNF001 set Flag=1 where CmpyCode='" + CmpyCode + "' and PRCNF001_CODE='" + Code + "'");
                

            }
            return false;
        }
      
        public List<PyrollConfi_Vm> GetPyrollConfiList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRCNF001 where CmpyCode='" + CmpyCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<PyrollConfi_Vm> ObjList = new List<PyrollConfi_Vm>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new PyrollConfi_Vm()
                {
                    CMPYCODE = dr["CmpyCode"].ToString(),
                    PRCNF001_CODE = dr["PRCNF001_CODE"].ToString(),
                    COUNTRY = dr["COUNTRY"].ToString(),
                    SRNO = Convert.ToInt16(dr["SRNO"].ToString()),
                    FINYEAR = Convert.ToInt16(dr["FINYEARS"].ToString()),
                    FINMONTH = Convert.ToInt16(dr["FINMONTH"].ToString()),
                    FROM_DATE = Convert.ToDateTime(dr["FROM_DATE"].ToString()),
                    TO_DATE = Convert.ToDateTime(dr["TO_DATE"].ToString()),
                    LOCK = dr["LOCK"].ToString(),
                });

            }
            return ObjList;
        }

        public PyrollConfi_Vm GetPyrollConfiDet(string CmpyCode, string Code)
        {          
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PRCNF001 where CmpyCode='" + CmpyCode + "' and PRCNF001_CODE='" + Code +"' and Flag=0");
            dt = ds.Tables[0];
            PyrollConfi_Vm PayRoll = new PyrollConfi_Vm();
            foreach (DataRow dr in dt.Rows)
            {
                PayRoll.CMPYCODE = dr["CmpyCode"].ToString();
                PayRoll.PRCNF001_CODE = dr["PRCNF001_CODE"].ToString();
                PayRoll.COUNTRY = dr["COUNTRY"].ToString();
                PayRoll.SRNO = Convert.ToInt16(dr["SRNO"].ToString());
                PayRoll.FINYEAR = Convert.ToInt16(dr["FINYEARS"].ToString());
                PayRoll.FINMONTH = Convert.ToInt16(dr["FINMONTH"].ToString());
                PayRoll.FROM_DATE = Convert.ToDateTime(dr["FROM_DATE"].ToString());
                PayRoll.TO_DATE = Convert.ToDateTime(dr["TO_DATE"].ToString());
                PayRoll.NOOFDAYS = Convert.ToInt32(dr["NOOFDAYS"].ToString());
                PayRoll.LOCK = dr["LOCK"].ToString();             
            }
            return PayRoll;
        }

        public PyrollConfi_Vm SavePyrollConfi(PyrollConfi_Vm PayCnfg)
        {
            int Sry1;
            string dtstr, dtstr1 = null;
            try
            {
                DateTime dt1 = Convert.ToDateTime(PayCnfg.FROM_DATE.ToString());

                dtstr = dt1.ToString("yyyy-MM-dd");

                DateTime dt2 = Convert.ToDateTime(PayCnfg.TO_DATE.ToString());

                dtstr1 = dt2.ToString("yyyy-MM-dd");

                if (!PayCnfg.EditFlag)
                {
                    int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + PayCnfg.CMPYCODE + "' and Code='PRCNF' ");
                    Sry1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from PRCNF001 where CmpyCode='" + PayCnfg.CMPYCODE + "' and PRCNF001_CODE='" + PayCnfg.PRCNF001_CODE + "'");                   
                    if (Sry1 == 0)
                    {                        
                        StringBuilder sb = new StringBuilder();
                        //sb.Append("'" + Sry.PRSM001UID + "',");
                        sb.Append("'" + PayCnfg.PRCNF001_CODE + "',");
                        sb.Append("'" + PayCnfg.CMPYCODE + "',");
                        sb.Append("'" + PayCnfg.COUNTRY + "',");
                        sb.Append("'" + PayCnfg.SRNO + "',");
                        sb.Append("'" + PayCnfg.FINYEAR + "',");
                        sb.Append("'" + PayCnfg.FINMONTH + "',");
                        sb.Append("'" + dtstr + "',");
                        sb.Append("'" + dtstr1 + "',");
                        sb.Append("'" + PayCnfg.NOOFDAYS + "',");
                        sb.Append("'" + PayCnfg.LOCK + "')");

                        using (TransactionScope scope = new TransactionScope())
                        {
                            int k =_EzBusinessHelper.ExecuteScalar("Select Count(*) from PRCNF001 where CmpyCode='" + PayCnfg.CMPYCODE + "' and FINYEARS='" + PayCnfg.FINYEAR + "' and FINMONTH='" + PayCnfg.FINMONTH + "' and COUNTRY ='" + PayCnfg.COUNTRY + "'");


                            if (k == 0)
                            {
                                PayCnfg.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("insert into PRCNF001(PRCNF001_CODE,CMPYCODE,COUNTRY,SRNO,FINYEARS,FINMONTH,FROM_DATE,TO_DATE,NOOFDAYS,LOCK) values(" + sb.ToString() + "");
                                //PayCnfg.SaveFlag = true;

                                _EzBusinessHelper.ExecuteNonQuery("UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + PayCnfg.CMPYCODE + "' and Code='PRCNF'");
                                _EzBusinessHelper.ActivityLog(PayCnfg.CMPYCODE, PayCnfg.UserName, "Added PayRoll Config Master", PayCnfg.PRCNF001_CODE, Environment.MachineName);
                                PayCnfg.ErrorMessage = string.Empty;
                                scope.Complete();
                            }
                            else
                            {
                                PayCnfg.ErrorMessage = "Alredy PayRoll Config created";
                                PayCnfg.SaveFlag = false;
                            }


                            
                        }
                    }
                }
                else
                {
                    Sry1 = _EzBusinessHelper.ExecuteScalar("Select count(*) from PRCNF001 where CmpyCode='" + PayCnfg.CMPYCODE + "' and PRCNF001_CODE='" + PayCnfg.PRCNF001_CODE + "' ");                                   
                    if (Sry1 != 0)
                    {
                        using (TransactionScope scope1 = new TransactionScope())
                        {
                            //_EzBusinessHelper.ExecuteNonQuery("Delete from PRCNF001 where CmpyCode='" + PayCnfg.CMPYCODE + "' and PRCNF001_CODE='" + PayCnfg.PRCNF001_CODE + "' ");

                            StringBuilder sb = new StringBuilder();
                            //sb.Append("'" + Sry.PRSM001UID + "',");
                           // sb.Append("'" + PayCnfg.PRCNF001_CODE + "',");
                            //sb.Append("CMPYCODE='" + PayCnfg.CMPYCODE + "',");
                            sb.Append("COUNTRY='" + PayCnfg.COUNTRY + "',");
                            sb.Append("SRNO='" + PayCnfg.SRNO + "',");
                            sb.Append("FINYEARS='" + PayCnfg.FINYEAR + "',");
                            sb.Append("FINMONTH='" + PayCnfg.FINMONTH + "',");
                            sb.Append("FROM_DATE='" + dtstr + "',");
                            sb.Append("TO_DATE='" + dtstr1 + "',");
                            sb.Append("NOOFDAYS='" + PayCnfg.NOOFDAYS + "',");
                            sb.Append("LOCK='" + PayCnfg.LOCK + "'");

                            int k = _EzBusinessHelper.ExecuteScalar("Select Count(*) from PRCNF001 where CmpyCode='" + PayCnfg.CMPYCODE + "' and FINYEARS='" + PayCnfg.FINYEAR + "' and FINMONTH='" + PayCnfg.FINMONTH + "' and COUNTRY ='" + PayCnfg.COUNTRY + "' and CMPYCODE='" + PayCnfg.CMPYCODE + "' and PRCNF001_CODE !='"+ PayCnfg.PRCNF001_CODE +"'");


                            if (k == 0)
                            {
                                PayCnfg.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("update PRCNF001 set " + sb + " where PRCNF001_CODE='" + PayCnfg.PRCNF001_CODE + "' and CMPYCODE='" + PayCnfg.CMPYCODE + "'");

                                // PayCnfg.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("insert into PRCNF001(PRCNF001_CODE,CMPYCODE,COUNTRY,SRNO,FINYEARS,FINMONTH,FROM_DATE,TO_DATE,NOOFDAYS,LOCK) values(" + sb.ToString() + "");
                                _EzBusinessHelper.ActivityLog(PayCnfg.CMPYCODE, PayCnfg.UserName, "Update PayRoll Config Master", PayCnfg.PRCNF001_CODE, Environment.MachineName);
                                PayCnfg.ErrorMessage = string.Empty;
                                scope1.Complete();
                            }
                            else
                            {
                                PayCnfg.ErrorMessage = "Alredy PayRoll Config created";
                                PayCnfg.SaveFlag = false;
                            }
                        }
                    }
                   
                    //PayCnfg.SaveFlag = true;
                }

                return PayCnfg;

            }
            catch
            {
                PayCnfg.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }
            return PayCnfg;
        }

        public List<Nation> GetNationList(string CmpyCode)
        {
            return drop.GetNationList(CmpyCode);
        }
    }
}
