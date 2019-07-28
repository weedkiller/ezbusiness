using EzBusiness_DL_Interface.FreightManagementDLI.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Data;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using System.Transactions;
using EzBusiness_DL_Interface.FreightManagementDLI;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
    public class CodeSettingsRepository : ICodeSettingsRepository
    {
        DataSet ds = null;
        DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        DropListFillFun drop = new DropListFillFun();
        public bool DeleteCodeSettings(string Cmpycode, string Branchcode, string Tablename, string username)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from UTM0001 where  UTM0001 where Cmpycode='" + Cmpycode + "' and Branchcode='" + Branchcode + "' and Tablename='" + Tablename + "'");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {
               _EzBusinessHelper.ActivityLog(Cmpycode, username, "Delete Code settings", Tablename, Environment.MachineName);
                //_EzBusinessHelper.ExecuteNonQuery1("update FF_BOK002 set Flag=1 where  FF_BOK001_CODE='" + FF_BOK001_CODE + "'  and Flag=0");
                _EzBusinessHelper.ExecuteNonQuery1("delete from UTI0002  where Cmpycode='" + Cmpycode + "' and Branchcode='" + Branchcode + "' and Tablename='" + Tablename + "'");
                return _EzBusinessHelper.ExecuteNonQuery1("delete from UTM0001 where  UTM0001 where Cmpycode='" + Cmpycode + "' and Branchcode='" + Branchcode + "' and Tablename='" + Tablename + "'");//CMPYCODE='" + CmpyCode + "' and

            }
            return false;
        }

        public UTM0001_VM EditCodeSettings(string Cmpycode, string Branchcode, string Tablename)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from UTM0001 where Cmpycode='" + Cmpycode + "' and Branchcode='" + Branchcode + "' and Tablename='" + Tablename + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            UTM0001_VM ObjList = new UTM0001_VM();
            foreach (DataRow dr in drc)
            {
                ObjList.Auto_increment = dr["Auto_increment"].ToString();
                ObjList.Last_No = dr["Last_No"].ToString();
                ObjList.Page_Name = dr["Page_Name"].ToString();
                ObjList.Cmpycode = dr["Cmpycode"].ToString();
                ObjList.Branchcode = dr["Branchcode"].ToString();
                ObjList.Tablename = dr["Tablename"].ToString();
                ObjList.UTI0001_CODE = dr["UTI0001_CODE"].ToString();
                ObjList.PREFIX_CODE = dr["PREFIX_CODE"].ToString();
                ObjList.Starting_No = dr["Starting_No"].ToString();
                ObjList.Total_length = dr["Total_length"].ToString();

                
            }
            return ObjList;
        }

        public List<UTM0001_VM> GetCodeSettings(string Cmpycode, string Branchcode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from UTM0001 where Cmpycode='" + Cmpycode + "' and Branchcode='" + Branchcode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<UTM0001_VM> ObjList = new List<UTM0001_VM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new UTM0001_VM()
                {
                    Auto_increment = dr["Auto_increment"].ToString(),
                    Last_No = dr["Last_No"].ToString(),
                    Page_Name = dr["Page_Name"].ToString(),
                    Cmpycode = dr["Cmpycode"].ToString(),
                    Branchcode = dr["Branchcode"].ToString(),
                    Tablename = dr["Tablename"].ToString(),
                    UTI0001_CODE = dr["UTI0001_CODE"].ToString(),
                    PREFIX_CODE = dr["PREFIX_CODE"].ToString(),
                    Starting_No = dr["Starting_No"].ToString(),
                    Total_length = dr["Total_length"].ToString()

                });
            }
            return ObjList;
        }

        public List<ComDropTbl> GetTblname(string Prefix)
        {
            return drop.GetCommonDrop("name as [Code],'' as [Codename]", "sys.objects", "type='U' and name like '" + Prefix + "%'  or name like '" + Prefix + "%' order by create_date desc ");
        }

        public List<UTI0002New> GetUTI0002DetailList(string Cmpycode, string Branchcode, string Tablename)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from UTI0002 where Cmpycode='" + Cmpycode + "' and Branchcode='" + Branchcode + "' and Tablename='" + Tablename + "'"); 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<UTI0002New> ObjList = new List<UTI0002New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new UTI0002New()
                {
                    APPROVER_ID = dr["APPROVER_ID"].ToString(),
                    APPROVER_NAME = dr["APPROVER_NAME"].ToString(),
                    Branchcode = dr["Branchcode"].ToString(),
                    Cmpycode=dr["Cmpycode"].ToString(),
                    REJECTED_ALLOW=  dr["REJECTED_ALLOW"].ToString(),
                    Tablename=dr["Tablename"].ToString(),
                    UTI0001_CODE=dr["UTI0001_CODE"].ToString(),
                    sno=Convert.ToInt16(dr["sno"].ToString()),
                    UNAPPROVE_ALLOW= dr["UNAPPROVE_ALLOW"].ToString(),
                    APPROVE_ALLOW = dr["APPROVE_ALLOW"].ToString(),

                });
            }
            return ObjList;
        }

        public UTM0001_VM SaveCodeSettings(UTM0001_VM UTM)
        {
           
            if (!UTM.EditFlag)
            {
                try
                {

                    using (TransactionScope scope1 = new TransactionScope())
                    {

                        #region UTI0002
                        List<UTI0002> ObjList1 = new List<UTI0002>();
                        if (UTM.UTI0002Detail != null)
                        {
                            ObjList1.AddRange(UTM.UTI0002Detail.Select(m => new UTI0002
                            {
                                APPROVER_ID = m.APPROVER_ID,
                                APPROVER_NAME = m.APPROVER_NAME,                                
                                REJECTED_ALLOW=m.REJECTED_ALLOW,
                                sno=m.sno,                               
                                UTI0001_CODE=m.UTI0001_CODE,
                                UNAPPROVE_ALLOW=m.UNAPPROVE_ALLOW,
                                APPROVE_ALLOW=m.APPROVE_ALLOW
                            }).ToList());
                        }
                        #endregion                    
                        //---
                        int n, i = 0;
                        #region UTI0002 INSERT LOOP
                        n = ObjList1.Count;
                        while (n > 0)
                        {
                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  UTI0002 where UTI0001_CODE='" + UTM.UTI0001_CODE + "' and Cmpycode='" + UTM.Cmpycode + "' and Branchcode='" + UTM.Branchcode + "' and  Tablename='" + UTM.Tablename + "' and APPROVER_ID='" + ObjList1[n - 1].APPROVER_ID+"' ");// CmpyCode='" + FQV.CMPYCODE + "' and and flag=0
                            if (Stats1 == 0)
                            {                           
                                StringBuilder sb1 = new StringBuilder();
                                sb1.Append("'" + UTM.UTI0001_CODE + "',");
                                sb1.Append("'" + UTM.Cmpycode + "',");
                                sb1.Append("'" + UTM.Branchcode + "',");
                                sb1.Append("'" + UTM.Tablename + "',");
                                sb1.Append("'" + ObjList1[n - 1].sno + "',");
                                sb1.Append("'" + ObjList1[n - 1].APPROVER_ID + "',");
                                sb1.Append("'" + ObjList1[n - 1].APPROVER_NAME + "',");
                                sb1.Append("'" + ObjList1[n - 1].APPROVE_ALLOW + "',");
                                sb1.Append("'" + ObjList1[n - 1].REJECTED_ALLOW + "',");
                                sb1.Append("'" + ObjList1[n - 1].UNAPPROVE_ALLOW + "')");
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into UTI0002(UTI0001_CODE,Cmpycode,Branchcode,Tablename,sno,APPROVER_ID,APPROVER_NAME,APPROVE_ALLOW,REJECTED_ALLOW,UNAPPROVE_ALLOW) values(" + sb1.ToString() + "");
                            }
                            n = n - 1;
                        }
                        #endregion
                        #region UTM0001 INSERT Header                       
                        StringBuilder sb2 = new StringBuilder();
                        sb2.Append("'" + UTM.Cmpycode + "',");
                        sb2.Append("'" + UTM.Branchcode + "',");
                        sb2.Append("'" + UTM.Tablename + "',");
                        sb2.Append("'" + UTM.UTI0001_CODE + "',");
                        sb2.Append("'" + UTM.PREFIX_CODE + "',");
                        sb2.Append("'" + UTM.Page_Name + "',");
                        sb2.Append("'" + UTM.Starting_No + "',");
                        sb2.Append("'" + UTM.Total_length + "',");
                        sb2.Append("'" + UTM.Last_No + "',");
                        sb2.Append("'" + UTM.Auto_increment + "')");
                        i = _EzBusinessHelper.ExecuteNonQuery("insert into UTM0001(Cmpycode,Branchcode,Tablename,UTI0001_CODE,PREFIX_CODE,Page_Name,Starting_No,Total_length,Last_No,Auto_increment) values(" + sb2.ToString() + "");
                        #endregion
                        _EzBusinessHelper.ActivityLog(UTM.Cmpycode, UTM.UserName, "Update Code Settings", UTM.Tablename, Environment.MachineName);
                        UTM.SaveFlag = true;
                        UTM.ErrorMessage = string.Empty;
                        scope1.Complete();
                        //}
                        return UTM;
                    }
                }
                catch (Exception ex)
                {
                    UTM.SaveFlag = false;
                }
            }
            else
            {
                try
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select * from UTM0001 where Cmpycode='" + UTM.Cmpycode + "' and Branchcode='" + UTM.Branchcode + "' and Tablename='" + UTM.Tablename + "'");
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        UTM0001 UTM1 = new UTM0001();
                        dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            UTM1.UTI0001_CODE = UTM.UTI0001_CODE;
                            UTM1.Cmpycode = UTM.Cmpycode;
                            UTM1.Auto_increment = UTM.Auto_increment;
                            UTM1.Branchcode = UTM.Branchcode;
                            UTM1.Last_No = UTM.Last_No;
                            UTM1.Page_Name = UTM.Page_Name;
                            UTM1.PREFIX_CODE = UTM.PREFIX_CODE;
                            UTM1.Starting_No = UTM.Starting_No;
                            UTM1.Tablename = UTM.Tablename;
                            UTM1.Total_length = UTM.Total_length;
                            
                            
                            _EzBusinessHelper.ExecuteNonQuery("delete from UTI0002  where Cmpycode='" + UTM.Cmpycode + "' and Branchcode='" + UTM.Branchcode + "' and Tablename='" + UTM.Tablename + "'");

                            // #region ObjectList

                            #region UTI0002
                            List<UTI0002> ObjList1 = new List<UTI0002>();
                            if (UTM.UTI0002Detail != null)
                            {
                                ObjList1.AddRange(UTM.UTI0002Detail.Select(m => new UTI0002
                                {
                                    APPROVER_ID = m.APPROVER_ID,
                                    APPROVER_NAME = m.APPROVER_NAME,
                                    Branchcode = m.Branchcode,
                                    Cmpycode = m.Cmpycode,
                                    REJECTED_ALLOW = m.REJECTED_ALLOW,
                                    sno = m.sno,
                                    Tablename = m.Tablename,
                                    UTI0001_CODE = m.UTI0001_CODE,
                                    UNAPPROVE_ALLOW=m.UNAPPROVE_ALLOW,
                                    APPROVE_ALLOW=m.APPROVE_ALLOW
                                }).ToList());
                            }
                            #endregion
                            //---
                            int n, i = 0;
                            #region UTI0002 INSERT LOOP
                            n = ObjList1.Count;
                            while (n > 0)
                            {
                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  UTI0002 where UTI0001_CODE='" + UTM.UTI0001_CODE + "' and Cmpycode='" + UTM.Cmpycode + "' and Branchcode='" + UTM.Branchcode + "' and  Tablename='" + UTM.Tablename + "' and APPROVER_ID='" + ObjList1[n - 1].APPROVER_ID + "' ");// CmpyCode='" + FQV.CMPYCODE + "' and and flag=0
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb3 = new StringBuilder();
                                    sb3.Append("'" + UTM.UTI0001_CODE + "',");
                                    sb3.Append("'" + UTM.Cmpycode + "',");
                                    sb3.Append("'" + UTM.Branchcode + "',");
                                    sb3.Append("'" + UTM.Tablename + "',");
                                    sb3.Append("'" + ObjList1[n - 1].sno + "',");
                                    sb3.Append("'" + ObjList1[n - 1].APPROVER_ID + "',");
                                    sb3.Append("'" + ObjList1[n - 1].APPROVER_NAME + "',");
                                    sb3.Append("'" + ObjList1[n - 1].APPROVE_ALLOW + "',");
                                    sb3.Append("'" + ObjList1[n - 1].REJECTED_ALLOW + "',");
                                    sb3.Append("'" + ObjList1[n - 1].UNAPPROVE_ALLOW + "')");
                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into UTI0002(UTI0001_CODE,Cmpycode,Branchcode,Tablename,sno,APPROVER_ID,APPROVER_NAME,APPROVE_ALLOW,REJECTED_ALLOW,UNAPPROVE_ALLOW) values(" + sb3.ToString() + "");
                                }
                                n = n - 1;
                            }
                            #endregion

                            #region UTM0001 Update
                           
                            
                            StringBuilder sb4 = new StringBuilder();
                            sb4.Append("Cmpycode='" + UTM.Cmpycode + "',");
                            sb4.Append("Branchcode='" + UTM.Branchcode + "',");
                            sb4.Append("Tablename='" + UTM.Tablename + "',");
                            sb4.Append("UTI0001_CODE='" + UTM.UTI0001_CODE + "',");
                            sb4.Append("PREFIX_CODE='" + UTM.PREFIX_CODE + "',");
                             sb4.Append("Starting_No='" + UTM.Starting_No + "',");
                            sb4.Append("Total_length='" + UTM.Total_length + "',");
                            sb4.Append("Last_No='" + UTM.Last_No + "',");
                            sb4.Append("Auto_increment='" + UTM.Auto_increment + "'");



                            _EzBusinessHelper.ExecuteNonQuery("update UTM0001 set  " + sb4 + " where  Cmpycode='" + UTM.Cmpycode + "' and Branchcode='" + UTM.Branchcode + "' and Tablename='" + UTM.Tablename + "'");
                            
                            #endregion

                            _EzBusinessHelper.ActivityLog(UTM.Cmpycode, UTM.UserName, "Update Code Settings", UTM.Tablename, Environment.MachineName);
                        }

                        UTM.ErrorMessage = string.Empty;
                        UTM.SaveFlag = true;
                        scope1.Complete();
                    }
                }
                catch (Exception ex)
                {

                    UTM.ErrorMessage = "Error occur";
                    UTM.SaveFlag = false;

                }
            }

            return UTM;
        }

        public List<ComDropTbl> GetUsername(string CmpyCode,string Prefix)
        {
            return drop.GetCommonDrop2("select a.user_name as [Code], b.Empname as [Codename] from Users a inner join MEM001 b on a.EmpCode = b.EmpCode and b.Flag = 0 and b.WorkingStatus = 'Y' and a.CmpyCode=b.CmpyCode where a.CmpyCode ='" + CmpyCode+ "' and a.user_name like '"+ Prefix + "%'  or b.Empname like '" + Prefix +"%'");
        }
    }
}
