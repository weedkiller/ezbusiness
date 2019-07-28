using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
    public class FFM_VOYAGERepository : IFFM_VOYAGERepository
    {
        System.Data.DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public List<FFM_VOYAGE_VM> GetFFM_VoYAGEAList(string CMPYCODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select * from FFM_VOYAGE01 yg1 where yg1.CMPYCODE='" + CMPYCODE + "' and yg1.flag=0");
            List<FFM_VOYAGE_VM> ObjList = null;
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                DataRowCollection drc = dt.Rows;
                ObjList = new List<FFM_VOYAGE_VM>();
                foreach (DataRow dr in drc)
                {
                    ObjList.Add(new FFM_VOYAGE_VM()
                    {
                        CMPYCODE = dr["CMPYCODE"].ToString(),
                        DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString(),
                        NAME = dr["NAME"].ToString(),
                        FFM_VESSEL_CODE = dr["FFM_VESSEL_CODE"].ToString(),
                        FFM_VOYAGE01_CODE = dr["FFM_VOYAGE01_CODE"].ToString(),
                    });

                }
            }
            return ObjList;
        }

        public FFM_VOYAGE_VM SaveFFM_Voyage(FFM_VOYAGE_VM FCur)
        {
            DateTime dte, ETA1, ETB1, ETD1;
            string dtstr1, ETA2, ETB2, ETD2; ;
            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            if (!FCur.EditFlag)
            {
                try
                {
                    var Drecord = new List<string>();
                    List<FFM_VOYAGEA> ObjList = new List<FFM_VOYAGEA>();
                    ObjList.AddRange(FCur.newdetails.Select(m => new FFM_VOYAGEA
                    {
                        CMPYCODE = m.CMPYCODE,
                        FFM_VOYAGE01_CODE = m.FFM_VOYAGE01_CODE,
                        SNO = m.SNO,
                        ROTATION = m.ROTATION,
                        PORT = m.PORT,
                        ETA = m.ETA,
                        ETB = m.ETB,
                        ETD = m.ETD,
                        PortStayHours = m.PortStayHours,
                        SailingHrs = m.SailingHrs,
                        //CMPYCODE1 = m.CMPYCODE,
                        DISPLAY_STATUS = m.DISPLAY_STATUS,
                        //MASTER_STATUS = m.MASTER_STATUS
                    }).ToList());
                    int n, i = 0;
                    n = ObjList.Count;
                    while (n > 0)
                    {
                        ETA1 = Convert.ToDateTime(ObjList[n - 1].ETA);
                        ETA2 = ETA1.ToString("yyyy-MM-dd hh:mm:ss tt");
                        ETB1 = Convert.ToDateTime(ObjList[n - 1].ETB);
                        ETB2 = ETB1.ToString("yyyy-MM-dd hh:mm:ss tt");
                        ETD1 = Convert.ToDateTime(ObjList[n - 1].ETD);
                        ETD2 = ETD1.ToString("yyyy-MM-dd hh:mm:ss tt");
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FFM_VOYAGE01 where FFM_VOYAGE01_CODE='" + ObjList[n - 1].FFM_VOYAGE01_CODE + "' and  CmpyCode='" + ObjList[n - 1].CMPYCODE + "' and flag=0");// CmpyCode='" + FCur.CMPYCODE + "' and
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.Append("'" + FCur.FFM_VOYAGE01_CODE + "',");
                            sb.Append("'" + ObjList[n - 1].SNO + "',");
                            sb.Append("'" + ObjList[n - 1].ROTATION + "',");
                            sb.Append("'" + ObjList[n - 1].PORT + "',");
                            sb.Append("'" + ETA2 + "',");
                            sb.Append("'" + ETB2 + "',");
                            sb.Append("'" + ETD2 + "',");
                            sb.Append("'" + ObjList[n - 1].PortStayHours + "',");
                            sb.Append("'" + ObjList[n - 1].SailingHrs + "',");
                            sb.Append("'" + FCur.DISPLAY_STATUS + "',");
                            sb.Append("'" + FCur.CMPYCODE + "')");
                            //sb.Append("'" + FCur.UserName + "',");
                            //sb.Append("'" + dtstr1 + "',");
                            ////sb.Append("'" + FCur.UserName + "',");
                            //sb.Append("'" + FCur.UserName + "',");
                            //sb.Append("'" + ObjList[n - 1].DISPLAY_STATUS + "',");
                            //sb.Append("'" + dtstr1 + "')");

                            i = _EzBusinessHelper.ExecuteNonQuery("insert into FFM_VOYAGE02(ffm_VOYAGE01_CODE,SNO,ROTATION,PORT,ETA,ETB,ETD,PORT_STAY_HRS,SAILING_HRS,DISPLAY_STATUS,cmpycode) values(" + sb.ToString() + "");
                            _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Add FFM Voyage", ObjList[n - 1].FFM_VOYAGE01_CODE, Environment.MachineName);

                        }
                        else
                        {
                            Drecord.Add(FCur.FFM_VOYAGE01_CODE.ToString());
                            //  branch.Drecord = Drecord;
                            FCur.SaveFlag = false;
                            FCur.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    if (i > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.Append("'" + FCur.UserName + "',");

                        sb.Append("'"+dtstr1 +"',");
                        sb.Append("'"+FCur.UserName+"',");

                        sb.Append("'"+dtstr1 +"',");
                        sb.Append("'"+FCur.FFM_VESSEL_CODE+"',");
                        sb.Append("'"+FCur.CMPYCODE+"',");
                        sb.Append("'"+FCur.FFM_VOYAGE01_CODE+"',");
                        sb.Append("'"+FCur.NAME+"',");
                        sb.Append("'"+FCur.DISPLAY_STATUS+"')");
                        i = _EzBusinessHelper.ExecuteNonQuery("insert into FFM_VOYAGE01(created_by,created_On,UPdated_By,Updated_ON,FFM_VESSEL_CODE,CMPYCODE,FFM_VOYAGE01_CODE,NAME,Display_Status) values(" + sb.ToString() + "");
                        FCur.SaveFlag = true;
                        FCur.ErrorMessage = string.Empty;
                    }
                    return FCur;

                }
                catch (Exception ex)
                {
                    FCur.SaveFlag = false;
                }
            }
            else
            {
                try
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select * from FFM_VOYAGE01 where CmpyCode='" + FCur.CMPYCODE + "' and FFM_VOYAGE01_CODE='" + FCur.FFM_VOYAGE01_CODE + "'");
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        FFM_VOYAGEA Emp = new FFM_VOYAGEA();
                        dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {

                            Emp.FFM_VESSEL_CODE = FCur.FFM_VESSEL_CODE;
                            Emp.FFM_VOYAGE01_CODE = FCur.FFM_VOYAGE01_CODE;
                            Emp.NAME = FCur.FFM_VOYAGE01_CODE;
                            Emp.DISPLAY_STATUS = FCur.DISPLAY_STATUS;

                            _EzBusinessHelper.ExecuteNonQuery("delete from FFM_VOYAGE02 where CmpyCode='" + FCur.CMPYCODE + "' and FFM_VOYAGE01_CODE='" + FCur.FFM_VOYAGE01_CODE + "'");

                           // #region ObjectList
                            List<FFM_VOYAGEA> ObjList = new List<FFM_VOYAGEA>();
                            if (FCur.newdetails != null)
                            {

                                ObjList.AddRange(FCur.newdetails.Select(m => new FFM_VOYAGEA
                                {
                                    SNO = m.SNO,
                                    ROTATION = m.ROTATION,
                                    PORT = m.PORT,
                                    ETA = m.ETA,
                                    ETB = m.ETB,
                                    //DocNo = m.DocNo,
                                    ETD = m.ETD,
                                    PortStayHours = m.PortStayHours,
                                    SailingHrs = m.SailingHrs,

                                }).ToList());
                            }
                            StringBuilder sb = new StringBuilder();

                            sb.Append("FFM_VESSEL_CODE='" + FCur.FFM_VESSEL_CODE + "',");
                            sb.Append("CMPYCODE='" + FCur.CMPYCODE + "',");
                            sb.Append("FFM_VOYAGE01_CODE='" + FCur.FFM_VOYAGE01_CODE + "',");
                            sb.Append("DISPLAY_STATUS='" + FCur.DISPLAY_STATUS + "',");
                            sb.Append("NAME='" + FCur.NAME + "',");
                            sb.Append("UPDATED_BY='" + FCur.UserName + "',");
                            sb.Append("UPDATED_ON='" + dtstr1 + "'");
                            _EzBusinessHelper.ExecuteNonQuery("update FFM_VOYAGE01 set  " + sb + " where  FFM_VOYAGE01_CODE='" + FCur.FFM_VOYAGE01_CODE + "' and  cmpycode='" + FCur.CMPYCODE + "' and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and                         
                                                                                                                                                                                                                // _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Add FFM Voyage", ObjList[n - 1].FFM_VOYAGE01_CODE, Environment.MachineName);

                            int n, i = 0;
                            n = ObjList.Count;
                            while (n > 0)
                            {
                                ETA1 = Convert.ToDateTime(ObjList[n - 1].ETA);
                                ETA2 = ETA1.ToString("yyyy-MM-dd hh:mm:ss tt");
                                ETB1 = Convert.ToDateTime(ObjList[n - 1].ETB);
                                ETB2 = ETB1.ToString("yyyy-MM-dd hh:mm:ss tt");
                                ETD1 = Convert.ToDateTime(ObjList[n - 1].ETD);
                                ETD2 = ETD1.ToString("yyyy-MM-dd hh:mm:ss tt");

                                StringBuilder sb1 = new StringBuilder();

                                sb1.Append("'" + FCur.FFM_VOYAGE01_CODE + "',");
                                sb1.Append("'" + ObjList[n - 1].SNO + "',");
                                sb1.Append("'" + ObjList[n - 1].ROTATION + "',");
                                sb1.Append("'" + ObjList[n - 1].PORT + "',");
                                sb1.Append("'" + ETA2 + "',");
                                sb1.Append("'" + ETB2 + "',");
                                sb1.Append("'" + ETD2 + "',");
                                sb1.Append("'" + ObjList[n - 1].PortStayHours + "',");
                                sb1.Append("'" + ObjList[n - 1].SailingHrs + "',");
                                sb1.Append("'" + FCur.DISPLAY_STATUS + "',");
                                sb1.Append("'" + FCur.CMPYCODE + "')");
                                _EzBusinessHelper.ExecuteNonQuery("insert into FFM_VOYAGE02(ffm_VOYAGE01_CODE,SNO,ROTATION,PORT,ETA,ETB,ETD,PORT_STAY_HRS,SAILING_HRS,DISPLAY_STATUS,cmpycode) values(" + sb1.ToString() + "");
                                n = n - 1;
                            }

                        }

                        FCur.ErrorMessage = string.Empty;
                        FCur.SaveFlag = true;
                        scope1.Complete();
                    }

                }
                catch (Exception ex)
                {

                    FCur.ErrorMessage = "Error occur";
                    FCur.SaveFlag = false;

                }


                }

            return FCur;
        }
        public List<ComDropTbl> GetVessalCode(string CmpyCode,string Prefix)
        {
            // return drop.GetVessalCode(CmpyCode, Prefix);
            return drop.GetCommonDrop("FFM_VESSEL_CODE as [Code],NAME as [CodeName]", "FFM_VESSEL", "CMPYCODE='" + CmpyCode + "' and Flag1=0 and (FFM_VESSEL_CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetPortList(string CmpyCode,string Prefix)
        {
            //return drop.GetPortList(CmpyCode, Prefix);
            return drop.GetCommonDrop("FFM_PORT_CODE as [Code],NAME as [CodeName]", "FFM_PORT", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (FFM_PORT_CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }
        public FFM_VOYAGE_VM EditVoyagMaster(string CmpyCode, string vyogcode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select * from FFM_VOYAGE01 yg1 inner join FFM_VOYAGE02 yg2 on yg1.CMPYCODE=yg2.CmpyCode and yg1.FFM_VOYAGE01_CODE=yg2.FFM_VOYAGE01_CODE  where yg1.cmpycode='" + CmpyCode + "' and yg1.FFM_VOYAGE01_CODE='" + vyogcode + "' and yg1.Flag=0");

            dt = ds.Tables[0];
            FFM_VOYAGE_VM data = new FFM_VOYAGE_VM();
            foreach (DataRow dr in dt.Rows)
            {
                data.CMPYCODE = dr["Cmpycode"].ToString();
                data.FFM_VESSEL_CODE = dr["FFM_VESSEL_CODE"].ToString().Trim();
                data.FFM_VOYAGE01_CODE = dr["FFM_VOYAGE01_CODE"].ToString();
                data.NAME = dr["NAME"].ToString();
                data.DISPLAY_STATUS = dr["DISPLAY_STATUS"].ToString();
                data.PORT = dr["PORT"].ToString();
                data.ROTATION =Convert.ToInt32(dr["ROTATION"].ToString());
                data.PORT = dr["PORT"].ToString();
                data.ETA =Convert.ToDateTime(dr["ETA"].ToString());
                data.ETB = Convert.ToDateTime(dr["ETB"].ToString());
                data.ETD = Convert.ToDateTime(dr["ETD"].ToString());
                data.Sailinghrs = Convert.ToInt64(dr["SAILING_HRS"].ToString());
                data.PortStayhrs = Convert.ToInt64(dr["PORT_STAY_HRS"].ToString());
            }
            return data;
        }

        public List<FFM_VOYAGEA> GetVayogeDetailList(string CmpyCode, string VyogCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("select * from FFM_VOYAGE02 where cmpycode='" + CmpyCode + "' and FFM_VOYAGE01_CODE='" + VyogCode + "' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_VOYAGEA> ObjList = new List<FFM_VOYAGEA>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_VOYAGEA()
                {
                    SNO = Convert.ToInt32(dr["SNO"].ToString()),
                    ROTATION = Convert.ToInt32(dr["ROTATION"].ToString()),
                    PORT = dr["PORT"].ToString(),
                    ETA = Convert.ToDateTime(dr["ETA"].ToString()),
                    ETB = Convert.ToDateTime(dr["ETB"].ToString()),
                    ETD = Convert.ToDateTime(dr["ETD"].ToString()),
                    PortStayHours = Convert.ToInt32(dr["PORT_STAY_HRS"].ToString()),
                    SailingHrs = Convert.ToInt32(dr["SAILING_HRS"].ToString()),

                });

            }
            return ObjList;
        }

        public bool DeleteVoyagMaster(string CmpyCode, string Voyagecode, string UserName)
        {
            int unit = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_VOYAGE01 where CmpyCode='" + CmpyCode + "' and FFM_VOYAGE01_CODE='" + Voyagecode + "'");
            //  int k = _EzBusinessHelper.ExecuteScalar("select count(*) from PRDTD002 where EmpCode='" + EmpCode + "' and Cmpycode='" + CmpyCode + "'");

            if (unit != 0)
            {
                _EzBusinessHelper.ExecuteNonQuery("update FFM_VOYAGE01 set Flag=1 where CmpyCode='" + CmpyCode + "' and FFM_VOYAGE01_CODE='" + Voyagecode + "'");
                _EzBusinessHelper.ExecuteNonQuery("update FFM_VOYAGE02 set Flag=1 where CmpyCode='" + CmpyCode + "' and FFM_VOYAGE01_CODE='" + Voyagecode + "'");

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete Emp  Master", Voyagecode, Environment.MachineName);
                return true;
            }
            return false;
        }

        public string GetNameByVessalCode(string VessalCode,string cmpyCode)
        {
            string VessalName = _EzBusinessHelper.ExecuteScalarS("select Name from FFM_VESSEL where CmpyCode='"+ cmpyCode + "' and  FFM_VESSEL_CODE='"+VessalCode+"' and Flag1=0");
            return VessalName;
        }
    }

}

