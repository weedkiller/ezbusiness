using EzBusiness_DL_Interface.FreightManagementDLI.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System.Data;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using System.Transactions;

namespace EzBusiness_DL_Repository.FreightManagementDLR.SEA_Export
{
    public class FF_BOKRepository : IFF_BOKRepository
    {

        DataSet ds = null;
        DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        DropListFillFun drop = new DropListFillFun();
        public bool DeleteFF_BOK(string CmpyCode, string FF_BOK001_CODE, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FF_BOK001 where  FF_BOK001_CODE='" + FF_BOK001_CODE + "'  and Flag=0");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FF_BOK_CODE", FF_BOK001_CODE, Environment.MachineName);

                _EzBusinessHelper.ExecuteNonQuery1("update FF_BOK002 set Flag=1 where  FF_BOK001_CODE='" + FF_BOK001_CODE + "'  and Flag=0");
                _EzBusinessHelper.ExecuteNonQuery1("update FF_BOK003 set Flag=1 where  FF_BOK001_CODE='" + FF_BOK001_CODE + "'  and Flag=0");
                _EzBusinessHelper.ExecuteNonQuery1("update FF_BOK004 set Flag=1 where  FF_BOK001_CODE='" + FF_BOK001_CODE + "'  and Flag=0");
                _EzBusinessHelper.ExecuteNonQuery1("update FF_BOK005 set Flag=1 where  FF_BOK001_CODE='" + FF_BOK001_CODE + "'  and Flag=0");

                return _EzBusinessHelper.ExecuteNonQuery1("update FF_BOK001 set Flag=1 where  FF_BOK001_CODE='" + FF_BOK001_CODE + "'  and Flag=0");//CMPYCODE='" + CmpyCode + "' and

            }
            return false;
        }

        public List<FF_BOK_VM> GetFF_BOK(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Commodity_code,FNMBRANCH_CODE,FORWARDER,SHIPPER,PLACE_OF_RCPT,FF_QTN001_CODE,FF_BOK001_DATE,DELIVERY_AT,CARRIER,BILL_TO,DEPARTMENT,FF_BOK001_CODE,ETD,ETA,FND,MOVE_TYPE,PICKUP_PLACE,POD,POL,REF_NO,Total_Billed,Total_Cost,Total_Profit,VESSEL,VOYAGE,CONSIGNEE,tranferFrom from FF_BOK001 where Flag=0 and CMPYCODE='" + CmpyCode + "' ");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_BOK_VM> ObjList = new List<FF_BOK_VM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_BOK_VM()
                {
                    FORWARDER = dr["FORWARDER"].ToString(),
                    SHIPPER = dr["SHIPPER"].ToString(),
                    PLACE_OF_RCPT = dr["PLACE_OF_RCPT"].ToString(),
                    FF_QTN001_CODE= dr["FF_QTN001_CODE"].ToString(),
                    FF_BOK001_DATE= Convert.ToDateTime(dr["FF_BOK001_DATE"].ToString()),                    
                    DELIVERY_AT = dr["DELIVERY_AT"].ToString(),
                    CARRIER = dr["CARRIER"].ToString(),
                    BILL_TO = dr["BILL_TO"].ToString(),                    
                    DEPARTMENT = dr["DEPARTMENT"].ToString(),
                    FF_BOK001_CODE = dr["FF_BOK001_CODE"].ToString(),
                    ETD = Convert.ToDateTime(dr["ETD"].ToString()),
                    ETA = Convert.ToDateTime(dr["ETA"].ToString()),
                    FND = dr["FND"].ToString(),
                    MOVE_TYPE = dr["MOVE_TYPE"].ToString(),
                    PICKUP_PLACE = dr["PICKUP_PLACE"].ToString(),
                    POD = dr["POD"].ToString(),
                    POL = dr["POL"].ToString(),
                    REF_NO = dr["REF_NO"].ToString(),                    
                    Total_Billed = Convert.ToDecimal(dr["Total_Billed"].ToString()),
                    Total_Cost = Convert.ToDecimal(dr["Total_Cost"].ToString()),
                    Total_Profit = Convert.ToDecimal(dr["Total_Profit"].ToString()),
                    VESSEL = dr["VESSEL"].ToString(),
                    VOYAGE = dr["VOYAGE"].ToString(),
                    CONSIGNEE=dr["CONSIGNEE"].ToString(),
                    tranferFrom=dr["tranferFrom"].ToString(),
                    Commodity_code= dr["Commodity_code"].ToString(),
                    FNMBRANCH_CODE = dr["FNMBRANCH_CODE"].ToString(),

                });
            }
            return ObjList;
        }

        public List<FF_BOK002New> GetFF_BOK002DetailList(string CmpyCode, string FF_BOK001_CODE,string typ)
        {
            string qur = "";
            if(typ == "Q")
            {
                qur = "Select Commodity_code,CBM,CFT,Container,Contents,Cont_Type,KG,LBS,No_of_qty,Seal1,sno from FF_QTN002 where Flag=0 and FF_QTN001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'";
            }else
            {
                qur = "Select Commodity_code,CBM,CFT,Container,Contents,Cont_Type,KG,LBS,No_of_qty,Seal1,sno from FF_BOK002 where Flag=0 and FF_BOK001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'";
            }
            ds = _EzBusinessHelper.ExecuteDataSet(qur);// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_BOK002New> ObjList = new List<FF_BOK002New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_BOK002New()
                {
                    CBM = Convert.ToDecimal(dr["CBM"].ToString()),
                    CFT = Convert.ToDecimal(dr["CFT"].ToString()),
                    Container = dr["Container"].ToString(),
                    Contents = dr["Contents"].ToString(),
                    Cont_Type = dr["Cont_Type"].ToString(),
                    KG = Convert.ToDecimal(dr["KG"].ToString()),
                    LBS = Convert.ToDecimal(dr["LBS"].ToString()),
                    No_of_qty = Convert.ToInt32(dr["No_of_qty"].ToString()),
                    Seal1 = Convert.ToInt32(dr["Seal1"].ToString()),
                    sno = Convert.ToInt32(dr["sno"].ToString()),
                    Commodity_code=dr["Commodity_code"].ToString()


                });
            }
            return ObjList;
        }

        public List<FF_BOK003New> GetFF_BOK003DetailList(string CmpyCode, string FF_BOK001_CODE,string typ)
        {
            string qur = "";
            if (typ == "Q")
            {
                qur = "Select No_of_qty,Act_LBS,Dime_weight,Height,inside_Unit,Pkg_No,Sno,unit_type,Volume,Width from FF_QTN003 where Flag=0 and FF_QTN001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'";
            }
            else
            {
                qur = "Select No_of_qty,Act_LBS,Dime_weight,Height,inside_Unit,Pkg_No,Sno,unit_type,Volume,Width from FF_BOK003 where Flag=0 and FF_BOK001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'";
            }
                ds = _EzBusinessHelper.ExecuteDataSet(qur);// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_BOK003New> ObjList = new List<FF_BOK003New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_BOK003New()
                {
                    Act_LBS = dr["Act_LBS"].ToString(),
                    Dime_weight = Convert.ToDecimal(dr["Dime_weight"].ToString()),
                    Height = Convert.ToDecimal(dr["Height"].ToString()),
                    inside_Unit = dr["inside_Unit"].ToString(),
                    Pkg_No = dr["Pkg_No"].ToString(),
                    Sno = Convert.ToInt32(dr["Sno"].ToString()),
                    unit_type = dr["unit_type"].ToString(),
                    Volume = Convert.ToDecimal(dr["Volume"].ToString()),
                    Width = Convert.ToDecimal(dr["Width"].ToString()),
                    No_of_qty = Convert.ToInt32(dr["No_of_qty"].ToString()),
                });
            }
            return ObjList;
        }

        public List<FF_BOK004New> GetFF_BOK004DetailList(string CmpyCode, string FF_BOK001_CODE,string typ)
        {
            string qur = "";
            if (typ == "Q")
            {
                qur = "Select CLAUSE_CODE,CLAUSE_NAME from FF_QTN004 where Flag=0 and FF_QTN001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'";
            }
            else
            {
                qur = "Select CLAUSE_CODE,CLAUSE_NAME from FF_BOK004 where Flag=0 and FF_BOK001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'";
            }
            ds = _EzBusinessHelper.ExecuteDataSet(qur);// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_BOK004New> ObjList = new List<FF_BOK004New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_BOK004New()
                {
                    CLUASE_CODE = dr["CLAUSE_CODE"].ToString(),
                    CLUASE_NAME = dr["CLAUSE_NAME"].ToString(),
                });
            }
            return ObjList;
        }

        public List<FF_BOK005New> GetFF_BOK005DetailList(string CmpyCode, string FF_BOK001_CODE,string typ)
        {
            string qur = "";
            if (typ == "Q")
            {
                qur = "Select * from FF_QTN005 where Flag=0 and FF_QTN001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'";
            }
            else
            {
                qur = "Select * from FF_BOK005 where Flag=0 and FF_BOK001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'";
            }
                ds = _EzBusinessHelper.ExecuteDataSet(qur);// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_BOK005New> ObjList = new List<FF_BOK005New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_BOK005New()
                {
                    Crg_code = dr["Crg_code"].ToString(),
                    Crg_name = dr["Crg_name"].ToString(),
                    Cust_Total_amt = Convert.ToDecimal(dr["Cust_Total_amt"].ToString()),
                    Cust_Curr_Rate = Convert.ToDecimal(dr["Cust_Curr_Rate"].ToString()),
                    Cust_Local_amt = Convert.ToDecimal(dr["Cust_Local_amt"].ToString()),
                    Cust_Var_Amt = Convert.ToDecimal(dr["Cust_Var_Amt"].ToString()),
                    Vend_Total_amt = Convert.ToDecimal(dr["Vend_Total_amt"].ToString()),
                    Cust_Net_Amt = Convert.ToDecimal(dr["Cust_Net_Amt"].ToString()),
                    Cust_Rate = Convert.ToDecimal(dr["Cust_Rate"].ToString()),
                    VendVar_Amt = Convert.ToDecimal(dr["VendVar_Amt"].ToString()),
                    Vend_Rate = Convert.ToDecimal(dr["Vend_Rate"].ToString()),
                    Vend_Net_Amt = Convert.ToDecimal(dr["Vend_Net_Amt"].ToString()),
                    Vend_Local_amt = Convert.ToDecimal(dr["Vend_Local_amt"].ToString()),
                    Vend_Curr_Rate = Convert.ToDecimal(dr["Vend_Curr_Rate"].ToString()),
                    Cust_code = dr["Cust_code"].ToString(),
                    Cust_Ctrl_Act = dr["Cust_Ctrl_Act"].ToString(),
                    Cust_Curr_Code = dr["Cust_Curr_Code"].ToString(),
                    Cust_name = dr["Cust_name"].ToString(),
                    Expense_GL_Code = dr["Expense_GL_Code"].ToString(),
                    Income_GL_Code = dr["Income_GL_Code"].ToString(),
                    PAY_MODE = dr["PAY_MODE"].ToString(),
                    Sno = Convert.ToInt32(dr["Sno"].ToString()),
                    Unit_Code = dr["Unit_Code"].ToString(),
                    Vend_code = dr["Vend_code"].ToString(),
                    Vend_Ctrl_Act = dr["Vend_Ctrl_Act"].ToString(),
                    Vend_Curr_Code = dr["Vend_Curr_Code"].ToString(),
                    Vend_name = dr["Vend_name"].ToString(),
                    No_of_qty = Convert.ToDecimal(dr["No_of_qty"].ToString()),

                });
            }
            return ObjList;
        }

        public FF_BOK_VM GetFF_BOKDetailsEdit(string CmpyCode, string FF_BOK001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMBRANCH_CODE,Commodity_code,TRANS_TYPE,JOB_TYPE,FORWARDER,SHIPPER,PLACE_OF_RCPT,FF_QTN001_CODE,FF_BOK001_DATE,DELIVERY_AT,CARRIER,BILL_TO,DEPARTMENT,FF_BOK001_CODE,ETD,ETA,FND,MOVE_TYPE,PICKUP_PLACE,POD,POL,REF_NO,Total_Billed,Total_Cost,Total_Profit,VESSEL,VOYAGE,CONSIGNEE from FF_BOK001 where Flag=0 and FF_BOK001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FF_BOK_VM ObjList = new FF_BOK_VM();
            foreach (DataRow dr in drc)
            {
                ObjList.TRANS_TYPE = dr["TRANS_TYPE"].ToString();
                ObjList.JOB_TYPE = dr["JOB_TYPE"].ToString();
                ObjList.PLACE_OF_RCPT= dr["PLACE_OF_RCPT"].ToString();
                ObjList.CARRIER = dr["CARRIER"].ToString();
                ObjList.BILL_TO = dr["BILL_TO"].ToString();
                ObjList.CARRIER = dr["CARRIER"].ToString();
                ObjList.SHIPPER = dr["SHIPPER"].ToString();
                ObjList.DEPARTMENT = dr["DEPARTMENT"].ToString();
                ObjList.DELIVERY_AT = dr["DELIVERY_AT"].ToString();
                ObjList.FF_BOK001_CODE = dr["FF_BOK001_CODE"].ToString();
                ObjList.ETA = Convert.ToDateTime(dr["ETA"].ToString());
                ObjList.ETD = Convert.ToDateTime(dr["ETD"].ToString());
                ObjList.FND = dr["FND"].ToString();
                ObjList.MOVE_TYPE = dr["MOVE_TYPE"].ToString();
                ObjList.PICKUP_PLACE = dr["PICKUP_PLACE"].ToString();
                ObjList.POD = dr["POD"].ToString();
                ObjList.POL = dr["POL"].ToString();
                ObjList.REF_NO = dr["REF_NO"].ToString();
                ObjList.CONSIGNEE = dr["CONSIGNEE"].ToString();
                ObjList.Total_Billed = Convert.ToDecimal(dr["Total_Billed"].ToString());
                ObjList.Total_Cost = Convert.ToDecimal(dr["Total_Cost"].ToString());
                ObjList.Total_Profit = Convert.ToDecimal(dr["Total_Profit"].ToString());
                ObjList.VESSEL = dr["VESSEL"].ToString();
                ObjList.VOYAGE = dr["VOYAGE"].ToString();
                ObjList.FF_QTN001_CODE = dr["FF_QTN001_CODE"].ToString();
                ObjList.FF_BOK001_DATE = Convert.ToDateTime(dr["FF_BOK001_DATE"].ToString());
                ObjList.FORWARDER = dr["FORWARDER"].ToString();
                ObjList.PLACE_OF_RCPT = dr["PLACE_OF_RCPT"].ToString();
                ObjList.Commodity_code = dr["Commodity_code"].ToString();
                ObjList.FNMBRANCH_CODE = dr["FNMBRANCH_CODE"].ToString();



            }
            return ObjList;
        }

        public FF_BOK_VM GetFF_BOKDetailsQuot(string CmpyCode, string FF_BOK001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FNMBRANCH_CODE,Commodity_code,PZIP,PSTATE,FDZIP,FDSTATE,FF_QTN001_CODE,CUST_CODE,CONTACT,TELEPHONE,EMAIL,CUSTOMER_REF,PICKUP_PLACE,POL,POD,FND,MOVE_TYPE,REF_NO,VESSEL,VOYAGE,CARRIER,EFFECT_FROM,EFFECT_UPTO,DEPARTMENT,Total_Cost,Total_Billed,Total_Profit from FF_QTN001 where Flag=0 and FF_QTN001_CODE='" + FF_BOK001_CODE + "' and CMPYCODE='" + CmpyCode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FF_BOK_VM ObjList = new FF_BOK_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.CARRIER = dr["CARRIER"].ToString();
              
                ObjList.DEPARTMENT = dr["DEPARTMENT"].ToString();
             
                ObjList.FF_QTN001_CODE = dr["FF_QTN001_CODE"].ToString();
                
                ObjList.FND = dr["FND"].ToString();
                ObjList.MOVE_TYPE = dr["MOVE_TYPE"].ToString();
                ObjList.PICKUP_PLACE = dr["PICKUP_PLACE"].ToString();
                ObjList.POD = dr["POD"].ToString();
                ObjList.POL = dr["POL"].ToString();
                ObjList.REF_NO = dr["REF_NO"].ToString();
               
                ObjList.Total_Billed = Convert.ToDecimal(dr["Total_Billed"].ToString());
                ObjList.Total_Cost = Convert.ToDecimal(dr["Total_Cost"].ToString());
                ObjList.Total_Profit = Convert.ToDecimal(dr["Total_Profit"].ToString());
                ObjList.VESSEL = dr["VESSEL"].ToString();
                ObjList.VOYAGE = dr["VOYAGE"].ToString();
                ObjList.ETA = System.DateTime.Now;
                ObjList.ETD = System.DateTime.Now;
                ObjList.FF_BOK001_DATE = System.DateTime.Now;                
                ObjList.Commodity_code = dr["Commodity_code"].ToString();
                ObjList.FNMBRANCH_CODE = dr["FNMBRANCH_CODE"].ToString();
            }
            return ObjList;
        }
        public List<ComDropTbl> GetMOVEList(string CmpyCode)
        {
            return drop.GetCommonDrop("FFM_MOVE_CODE as [Code],NAME as [CodeName]", "FFM_MOVE", "CMPYCODE='" + CmpyCode + "' and Flag=0");
        }

        public FF_BOK_VM SaveFF_BOK_VM(FF_BOK_VM FQV)
        {
            DateTime dte;
            string dtstr1, dtstr2, dtstr3,dtstr4;
            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            dte = Convert.ToDateTime(FQV.ETA);
            dtstr2 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(FQV.ETD);
            dtstr3 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(FQV.FF_BOK001_DATE);
            dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            if (!FQV.EditFlag)
            {
                try
                {

                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        #region FF_BOK002
                        List<FF_BOK002> ObjList = new List<FF_BOK002>();
                        if (FQV.FF_BOK002Detail != null)
                        {
                            ObjList.AddRange(FQV.FF_BOK002Detail.Select(m => new FF_BOK002
                            {
                                CFT = m.CFT,
                                CBM = m.CBM,
                                Container = m.Container,
                                Contents = m.Contents,
                                Cont_Type = m.Cont_Type,
                                KG = m.KG,
                                LBS = m.LBS,
                                No_of_qty = m.No_of_qty,
                                Seal1 = m.Seal1,
                                sno = m.sno,
                                Commodity_code=m.Commodity_code,
                            }).ToList());
                        }

                        #endregion

                        #region FF_BOK003
                        List<FF_BOK003> ObjList1 = new List<FF_BOK003>();
                        if (FQV.FF_BOK003Detail != null)
                        {
                            ObjList1.AddRange(FQV.FF_BOK003Detail.Select(m => new FF_BOK003
                            {
                                Width = m.Width,
                                sno = m.Sno,
                                Act_LBS = m.Act_LBS,
                                Dime_weight = m.Dime_weight,
                                Height = m.Height,
                                inside_Unit = m.inside_Unit,
                                No_of_qty = m.No_of_qty,
                                Pkg_No = m.Pkg_No,
                                unit_type = m.unit_type,
                                Volume = m.Volume,
                            }).ToList());
                        }
                        #endregion

                        #region FF_BOK004

                        List<FF_BOK004> ObjList2 = new List<FF_BOK004>();
                        if (FQV.FF_BOK004Detail != null)
                        {
                            ObjList2.AddRange(FQV.FF_BOK004Detail.Select(m => new FF_BOK004
                            {
                                CLAUSE_CODE = m.CLUASE_CODE,
                                CLAUSE_NAME = m.CLUASE_NAME
                            }).ToList());
                        }
                        #endregion

                        #region FF_BOK005
                        List<FF_BOK005> ObjList3 = new List<FF_BOK005>();
                        if (FQV.FF_BOK005Detail != null)
                        {
                            ObjList3.AddRange(FQV.FF_BOK005Detail.Select(m => new FF_BOK005
                            {
                                Crg_code = m.Crg_code,
                                Crg_name = m.Crg_name,
                                Cust_code = m.Cust_code,
                                Cust_Ctrl_Act = m.Cust_Ctrl_Act,
                                Cust_Curr_Rate = m.Cust_Curr_Rate,
                                Cust_Curr_Code = m.Cust_Curr_Code,
                                Cust_Local_amt = m.Cust_Local_amt,
                                Cust_name = m.Cust_name,
                                Cust_Net_Amt = m.Cust_Net_Amt,
                                Cust_Rate = m.Cust_Rate,
                                Cust_Total_amt = m.Cust_Total_amt,
                                Cust_Var_Amt = m.Cust_Var_Amt,
                                Expense_GL_Code = m.Expense_GL_Code,
                                Income_GL_Code = m.Income_GL_Code,
                                Sno = m.Sno,
                                PAY_MODE = m.PAY_MODE,
                                Unit_Code = m.Unit_Code,
                                VendVar_Amt = m.VendVar_Amt,
                                Vend_Ctrl_Act = m.Vend_Ctrl_Act,
                                Vend_name = m.Vend_name,
                                Vend_code = m.Vend_code,
                                Vend_Curr_Code = m.Vend_Curr_Code,
                                Vend_Curr_Rate = m.Vend_Curr_Rate,
                                Vend_Local_amt = m.Vend_Local_amt,
                                Vend_Net_Amt = m.Vend_Net_Amt,
                                Vend_Rate = m.Vend_Rate,
                                Vend_Total_amt = m.Vend_Total_amt,
                                No_of_Qty = m.No_of_qty

                            }).ToList());
                        }
                        #endregion

                        //---
                        int n, i = 0;

                        #region FF_BOK002 INSERT LOOP
                        n = ObjList.Count;
                        while (n > 0)
                        {

                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_BOK002 where FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                            if (Stats1 == 0)
                            {
                                StringBuilder sb = new StringBuilder();

                                sb.Append("'" + FQV.FF_BOK001_CODE + "',");
                                sb.Append("'" + ObjList[n - 1].CBM + "',");
                                sb.Append("'" + ObjList[n - 1].CFT + "',");
                                sb.Append("'" + ObjList[n - 1].Container + "',");
                                sb.Append("'" + ObjList[n - 1].Contents + "',");
                                sb.Append("'" + ObjList[n - 1].Cont_Type + "',");
                                sb.Append("'" + ObjList[n - 1].KG + "',");
                                sb.Append("'" + ObjList[n - 1].LBS + "',");
                                sb.Append("'" + ObjList[n - 1].No_of_qty + "',");
                                sb.Append("'" + ObjList[n - 1].Seal1 + "',");
                                sb.Append("'" + ObjList[n - 1].sno + "',");
                                sb.Append("'" + ObjList[n - 1].Commodity_code + "',");
                                sb.Append("'" + FQV.CMPYCODE + "')");
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_BOK002(FF_BOK001_CODE,CBM,CFT,Container,Contents,Cont_Type,KG,LBS,No_of_qty,Seal1,sno,Commodity_code,cmpycode) values(" + sb.ToString() + "");
                                //_EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Add FFM Charge", ObjList[n - 1].FF_BOK001_CODE, Environment.MachineName);

                            }

                            n = n - 1;
                        }
                        #endregion


                        #region FF_BOK003 INSERT LOOP
                        n = ObjList1.Count;
                        while (n > 0)
                        {

                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_BOK003 where FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                            if (Stats1 == 0)
                            {
                                StringBuilder sb1 = new StringBuilder();
                                sb1.Append("'" + FQV.FF_BOK001_CODE + "',");
                                sb1.Append("'" + ObjList1[n - 1].Act_LBS + "',");
                                sb1.Append("'" + ObjList1[n - 1].Dime_weight + "',");
                                sb1.Append("'" + ObjList1[n - 1].Height + "',");
                                sb1.Append("'" + ObjList1[n - 1].inside_Unit + "',");
                                sb1.Append("'" + ObjList1[n - 1].No_of_qty + "',");
                                sb1.Append("'" + ObjList1[n - 1].Pkg_No + "',");
                                sb1.Append("'" + ObjList1[n - 1].sno + "',");
                                sb1.Append("'" + ObjList1[n - 1].unit_type + "',");
                                sb1.Append("'" + ObjList1[n - 1].Width + "',");
                                sb1.Append("'" + ObjList1[n - 1].Volume + "',");

                                sb1.Append("'" + FQV.CMPYCODE + "')");
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_BOK003(FF_BOK001_CODE,Act_LBS,Dime_weight,Height,inside_Unit,No_of_qty,Pkg_No,Sno,unit_type,Width,Volume,cmpycode) values(" + sb1.ToString() + "");

                            }

                            n = n - 1;
                        }
                        #endregion

                        #region FF_BOK004 INSERT LOOP
                        n = ObjList2.Count;
                        while (n > 0)
                        {
                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_BOK004 where FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                            if (Stats1 == 0)
                            {
                                StringBuilder sb2 = new StringBuilder();
                                sb2.Append("'" + FQV.FF_BOK001_CODE + "',");
                                sb2.Append("'" + ObjList2[n - 1].CLAUSE_CODE + "',");
                                sb2.Append("'" + ObjList2[n - 1].CLAUSE_NAME + "',");
                                sb2.Append("'" + FQV.CMPYCODE + "')");
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_BOK004(FF_BOK001_CODE,CLUASE_CODE,CLUASE_NAME,cmpycode) values(" + sb2.ToString() + "");
                            }

                            n = n - 1;
                        }
                        #endregion

                        #region FF_BOK005 INSERT LOOP
                        n = ObjList3.Count;
                        while (n > 0)
                        {
                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_BOK005 where FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                            if (Stats1 == 0)
                            {
                                StringBuilder sb3 = new StringBuilder();
                                sb3.Append("'" + FQV.FF_BOK001_CODE + "',");
                                sb3.Append("'" + ObjList3[n - 1].Crg_code + "',");
                                sb3.Append("'" + ObjList3[n - 1].Crg_name + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_code + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_Ctrl_Act + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_Curr_Code + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_Curr_Rate + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_Local_amt + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_name + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_Net_Amt + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_Rate + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_Total_amt + "',");
                                sb3.Append("'" + ObjList3[n - 1].Cust_Var_Amt + "',");
                                sb3.Append("'" + ObjList3[n - 1].Expense_GL_Code + "',");
                                sb3.Append("'" + ObjList3[n - 1].Income_GL_Code + "',");
                                sb3.Append("'" + ObjList3[n - 1].PAY_MODE + "',");
                                sb3.Append("'" + ObjList3[n - 1].Sno + "',");
                                sb3.Append("'" + ObjList3[n - 1].Unit_Code + "',");
                                sb3.Append("'" + ObjList3[n - 1].VendVar_Amt + "',");
                                sb3.Append("'" + ObjList3[n - 1].Vend_code + "',");
                                sb3.Append("'" + ObjList3[n - 1].Vend_Ctrl_Act + "',");
                                sb3.Append("'" + ObjList3[n - 1].Vend_Curr_Code + "',");
                                sb3.Append("'" + ObjList3[n - 1].Vend_Curr_Rate + "',");
                                sb3.Append("'" + ObjList3[n - 1].Vend_Local_amt + "',");
                                sb3.Append("'" + ObjList3[n - 1].Vend_name + "',");
                                sb3.Append("'" + ObjList3[n - 1].Vend_Net_Amt + "',");
                                sb3.Append("'" + ObjList3[n - 1].Vend_Rate + "',");
                                sb3.Append("'" + ObjList3[n - 1].Vend_Total_amt + "',");
                                sb3.Append("'" + ObjList3[n - 1].No_of_Qty + "',");
                                sb3.Append("'" + FQV.CMPYCODE + "')");
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_BOK005(FF_BOK001_CODE,Crg_code,Crg_name,Cust_code,Cust_Ctrl_Act,Cust_Curr_Code,Cust_Curr_Rate,Cust_Local_amt,Cust_name,Cust_Net_Amt,Cust_Rate,Cust_Total_amt,Cust_Var_Amt,Expense_GL_Code,Income_GL_Code,PAY_MODE,Sno,Unit_Code,VendVar_Amt,Vend_code,Vend_Ctrl_Act,Vend_Curr_Code,Vend_Curr_Rate,Vend_Local_amt,Vend_name,Vend_Net_Amt,Vend_Rate,Vend_Total_amt,No_of_qty,CMPYCODE) values(" + sb3.ToString() + "");
                            }

                            n = n - 1;
                        }
                        #endregion

                        #region FF_BOK001 INSERT Header
                        //if (i > 0)
                        //{
                        StringBuilder sb4 = new StringBuilder();
                        sb4.Append("'" + FQV.UserName + "',");
                        sb4.Append("'" + dtstr1 + "',");
                        sb4.Append("'" + FQV.UserName + "',");
                        sb4.Append("'" + dtstr1 + "',");
                        sb4.Append("'" + FQV.CMPYCODE + "',");                       
                        sb4.Append("'" + FQV.FF_BOK001_CODE + "',");
                        sb4.Append("'" + dtstr4 + "',");
                        sb4.Append("'" + FQV.FF_QTN001_CODE + "',");
                        sb4.Append("'" + FQV.BILL_TO + "',");
                        sb4.Append("'" + FQV.SHIPPER + "',");
                        sb4.Append("'" + FQV.CONSIGNEE + "',");
                        sb4.Append("'" + FQV.FORWARDER + "',");
                        sb4.Append("'" + FQV.PICKUP_PLACE + "',");
                        sb4.Append("'" + FQV.POL + "',");
                        sb4.Append("'" + FQV.POD + "',");
                        sb4.Append("'" + FQV.FND + "',");
                        sb4.Append("'" + FQV.PLACE_OF_RCPT + "',");
                        sb4.Append("'" + FQV.MOVE_TYPE + "',");
                        sb4.Append("'" + FQV.DELIVERY_AT + "',");
                        sb4.Append("'" + FQV.REF_NO + "',");
                        sb4.Append("'" + FQV.VESSEL + "',");
                        sb4.Append("'" + FQV.VOYAGE + "',");
                        sb4.Append("'" + FQV.ETD + "',");
                        sb4.Append("'" + FQV.ETA + "',");
                        sb4.Append("'" + FQV.CARRIER + "',");
                        sb4.Append("'" + FQV.DEPARTMENT + "',");
                        sb4.Append("'" + FQV.Total_Cost + "',");
                        sb4.Append("'" + FQV.Total_Billed + "',");
                        sb4.Append("'" + FQV.JOB_TYPE + "',");
                        sb4.Append("'" + FQV.TRANS_TYPE + "',");
                        sb4.Append("'" + FQV.Commodity_code + "',");
                        sb4.Append("'" + FQV.tranferFrom + "',");
                        sb4.Append("'" + FQV.FNMBRANCH_CODE + "',");
                        sb4.Append("'" + FQV.Total_Profit + "')");

                        i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_BOK001(CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,CMPYCODE,FF_BOK001_CODE,FF_BOK001_DATE,FF_QTN001_CODE,BILL_TO,SHIPPER,CONSIGNEE,FORWARDER,PICKUP_PLACE,POL,POD,FND,PLACE_OF_RCPT,MOVE_TYPE,DELIVERY_AT,REF_NO,VESSEL,VOYAGE,ETD,ETA,CARRIER,DEPARTMENT,Total_Cost,Total_Billed,JOB_TYPE,TRANS_TYPE,Commodity_code,tranferFrom,Total_Profit,FNMBRANCH_CODE) values(" + sb4.ToString() + "");

                        #endregion
                        _EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Update FF BOK", FQV.FF_BOK001_CODE, Environment.MachineName);
                        FQV.SaveFlag = true;
                        FQV.ErrorMessage = string.Empty;
                        scope1.Complete();
                        //}
                        return FQV;
                    }
                }
                catch (Exception ex)
                {
                    FQV.SaveFlag = false;
                }
            }
            else
            {
                try
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select * from FF_BOK001 where CmpyCode='" + FQV.CMPYCODE + "' and FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "'");
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        FF_BOK001 FQT1 = new FF_BOK001();
                        dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            FQT1.CARRIER = FQV.CARRIER;
                            FQT1.CMPYCODE = FQV.CMPYCODE;                       
                            FQT1.CREATED_BY = FQV.CREATED_BY;
                            FQT1.CREATED_ON = FQV.CREATED_ON;
                            FQT1.BILL_TO = FQV.BILL_TO;
                            FQT1.CONSIGNEE = FQV.CONSIGNEE;
                            FQT1.DELIVERY_AT = FQV.DELIVERY_AT;
                            FQT1.ETA = FQV.ETA;
                            FQT1.ETA = FQV.ETA;
                            FQT1.DEPARTMENT = FQV.DEPARTMENT;
                            FQT1.FORWARDER = FQV.FORWARDER;
                            FQT1.SHIPPER = FQV.SHIPPER;
                            FQT1.PLACE_OF_RCPT = FQV.PLACE_OF_RCPT;
                            FQT1.FF_BOK001_DATE = FQV.FF_BOK001_DATE;
                            FQT1.FF_BOK001_CODE = FQV.FF_BOK001_CODE;
                            FQT1.FND = FQV.FND;
                            FQT1.MOVE_TYPE = FQV.MOVE_TYPE;
                            FQT1.PICKUP_PLACE = FQV.PICKUP_PLACE;
                            FQT1.POD = FQV.POD;
                            FQT1.POL = FQV.POL;
                            FQT1.REF_NO = FQV.REF_NO;
                            FQT1.FF_QTN001_CODE = FQV.FF_QTN001_CODE;
                            FQT1.Total_Billed = FQV.Total_Billed;
                            FQT1.Total_Cost = FQV.Total_Cost;
                            FQT1.Total_Profit = FQV.Total_Profit;
                            FQT1.UPDATED_BY = FQV.UPDATED_BY;
                            FQT1.UPDATED_ON = FQV.UPDATED_ON;
                            FQT1.VESSEL = FQV.VESSEL;
                            FQT1.VOYAGE = FQV.VOYAGE;
                            FQT1.JOB_TYPE = FQV.JOB_TYPE;
                            FQT1.TRANS_TYPE = FQV.TRANS_TYPE;
                            FQT1.Commodity_code = FQV.Commodity_code;
                            FQT1.tranferFrom = FQV.tranferFrom;

                            _EzBusinessHelper.ExecuteNonQuery("delete from FF_BOK002 where CmpyCode='" + FQV.CMPYCODE + "' and FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "'");
                            _EzBusinessHelper.ExecuteNonQuery("delete from FF_BOK003 where CmpyCode='" + FQV.CMPYCODE + "' and FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "'");
                            _EzBusinessHelper.ExecuteNonQuery("delete from FF_BOK004 where CmpyCode='" + FQV.CMPYCODE + "' and FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "'");
                            _EzBusinessHelper.ExecuteNonQuery("delete from FF_BOK005 where CmpyCode='" + FQV.CMPYCODE + "' and FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "'");
                            // #region ObjectList
                            #region FF_BOK002
                            List<FF_BOK002> ObjList = new List<FF_BOK002>();
                            if (FQV.FF_BOK002Detail != null)
                            {
                                ObjList.AddRange(FQV.FF_BOK002Detail.Select(m => new FF_BOK002
                                {
                                    CFT = m.CFT,
                                    CBM = m.CBM,
                                    Container = m.Container,
                                    Contents = m.Contents,
                                    Cont_Type = m.Cont_Type,
                                    KG = m.KG,
                                    LBS = m.LBS,
                                    No_of_qty = m.No_of_qty,
                                    Seal1 = m.Seal1,
                                    sno = m.sno,
                                    Commodity_code=m.Commodity_code,
                                }).ToList());
                            }

                            #endregion

                            #region FF_BOK003
                            List<FF_BOK003> ObjList1 = new List<FF_BOK003>();
                            if (FQV.FF_BOK003Detail != null)
                            {
                                ObjList1.AddRange(FQV.FF_BOK003Detail.Select(m => new FF_BOK003
                                {
                                    Width = m.Width,
                                    sno = m.Sno,
                                    Act_LBS = m.Act_LBS,
                                    Dime_weight = m.Dime_weight,
                                    Height = m.Height,
                                    inside_Unit = m.inside_Unit,
                                    No_of_qty = m.No_of_qty,
                                    Pkg_No = m.Pkg_No,
                                    unit_type = m.unit_type,
                                    Volume = m.Volume,
                                }).ToList());
                            }
                            #endregion

                            #region FF_BOK004
                            List<FF_BOK004> ObjList2 = new List<FF_BOK004>();
                            if (FQV.FF_BOK004Detail != null)
                            {
                                ObjList2.AddRange(FQV.FF_BOK004Detail.Select(m => new FF_BOK004
                                {
                                    CLAUSE_CODE = m.CLUASE_CODE,
                                    CLAUSE_NAME = m.CLUASE_NAME
                                }).ToList());
                            }
                            #endregion

                            #region FF_BOK005
                            List<FF_BOK005> ObjList3 = new List<FF_BOK005>();
                            if (FQV.FF_BOK005Detail != null)
                            {
                                ObjList3.AddRange(FQV.FF_BOK005Detail.Select(m => new FF_BOK005
                                {
                                    Crg_code = m.Crg_code,
                                    Crg_name = m.Crg_name,
                                    Cust_code = m.Cust_code,
                                    Cust_Ctrl_Act = m.Cust_Ctrl_Act,
                                    Cust_Curr_Rate = m.Cust_Curr_Rate,
                                    Cust_Curr_Code = m.Cust_Curr_Code,
                                    Cust_Local_amt = m.Cust_Local_amt,
                                    Cust_name = m.Cust_name,
                                    Cust_Net_Amt = m.Cust_Net_Amt,
                                    Cust_Rate = m.Cust_Rate,
                                    Cust_Total_amt = m.Cust_Total_amt,
                                    Cust_Var_Amt = m.Cust_Var_Amt,
                                    Expense_GL_Code = m.Expense_GL_Code,
                                    Income_GL_Code = m.Income_GL_Code,
                                    Sno = m.Sno,
                                    PAY_MODE = m.PAY_MODE,
                                    Unit_Code = m.Unit_Code,
                                    VendVar_Amt = m.VendVar_Amt,
                                    Vend_Ctrl_Act = m.Vend_Ctrl_Act,
                                    Vend_name = m.Vend_name,
                                    Vend_code = m.Vend_code,
                                    Vend_Curr_Code = m.Vend_Curr_Code,
                                    Vend_Curr_Rate = m.Vend_Curr_Rate,
                                    Vend_Local_amt = m.Vend_Local_amt,
                                    Vend_Net_Amt = m.Vend_Net_Amt,
                                    Vend_Rate = m.Vend_Rate,
                                    Vend_Total_amt = m.Vend_Total_amt,
                                    No_of_Qty = m.No_of_qty
                                }).ToList());
                            }
                            #endregion

                            //---
                            int n, i = 0;

                            #region FF_BOK002 INSERT LOOP
                            n = ObjList.Count;
                            while (n > 0)
                            {

                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_BOK002 where FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb5 = new StringBuilder();

                                    sb5.Append("'" + FQV.FF_BOK001_CODE + "',");
                                    sb5.Append("'" + ObjList[n - 1].CBM + "',");
                                    sb5.Append("'" + ObjList[n - 1].CFT + "',");
                                    sb5.Append("'" + ObjList[n - 1].Container + "',");
                                    sb5.Append("'" + ObjList[n - 1].Contents + "',");
                                    sb5.Append("'" + ObjList[n - 1].Cont_Type + "',");
                                    sb5.Append("'" + ObjList[n - 1].KG + "',");
                                    sb5.Append("'" + ObjList[n - 1].LBS + "',");
                                    sb5.Append("'" + ObjList[n - 1].No_of_qty + "',");
                                    sb5.Append("'" + ObjList[n - 1].Seal1 + "',");
                                    sb5.Append("'" + ObjList[n - 1].sno + "',");
                                    sb5.Append("'" + ObjList[n - 1].Commodity_code + "',");
                                    sb5.Append("'" + FQV.CMPYCODE + "')");
                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_BOK002(FF_BOK001_CODE,CBM,CFT,Container,Contents,Cont_Type,KG,LBS,No_of_qty,Seal1,sno,Commodity_code,cmpycode) values(" + sb5.ToString() + "");
                                    //_EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Add FFM Charge", ObjList[n - 1].FF_BOK001_CODE, Environment.MachineName);

                                }

                                n = n - 1;
                            }
                            #endregion

                            #region FF_BOK003 INSERT LOOP
                            n = ObjList1.Count;
                            while (n > 0)
                            {

                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_BOK003 where FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb6 = new StringBuilder();
                                    sb6.Append("'" + FQV.FF_BOK001_CODE + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Act_LBS + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Dime_weight + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Height + "',");
                                    sb6.Append("'" + ObjList1[n - 1].inside_Unit + "',");
                                    sb6.Append("'" + ObjList1[n - 1].No_of_qty + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Pkg_No + "',");
                                    sb6.Append("'" + ObjList1[n - 1].sno + "',");
                                    sb6.Append("'" + ObjList1[n - 1].unit_type + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Volume + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Width + "',");
                                    sb6.Append("'" + FQV.CMPYCODE + "')");
                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_BOK003(FF_BOK001_CODE,Act_LBS,Dime_weight,Height,inside_Unit,No_of_qty,Pkg_No,Sno,unit_type,Volume,Width,cmpycode) values(" + sb6.ToString() + "");

                                }

                                n = n - 1;
                            }
                            #endregion

                            #region FF_BOK004 INSERT LOOP
                            n = ObjList2.Count;
                            while (n > 0)
                            {
                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_BOK004 where FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb7 = new StringBuilder();
                                    sb7.Append("'" + FQV.FF_BOK001_CODE + "',");
                                    sb7.Append("'" + ObjList2[n - 1].CLAUSE_CODE + "',");
                                    sb7.Append("'" + ObjList2[n - 1].CLAUSE_NAME + "',");
                                    sb7.Append("'" + FQV.CMPYCODE + "')");
                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_BOK004(FF_BOK001_CODE,CLUASE_CODE,CLUASE_NAME,cmpycode) values(" + sb7.ToString() + "");
                                }

                                n = n - 1;
                            }
                            #endregion

                            #region FF_BOK005 INSERT LOOP
                            n = ObjList3.Count;
                            while (n > 0)
                            {
                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_BOK005 where FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb8 = new StringBuilder();
                                    sb8.Append("'" + FQV.FF_BOK001_CODE + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Crg_code + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Crg_name + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_code + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_Ctrl_Act + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_Curr_Code + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_Curr_Rate + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_Local_amt + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_name + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_Net_Amt + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_Rate + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_Total_amt + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Cust_Var_Amt + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Expense_GL_Code + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Income_GL_Code + "',");
                                    sb8.Append("'" + ObjList3[n - 1].PAY_MODE + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Sno + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Unit_Code + "',");
                                    sb8.Append("'" + ObjList3[n - 1].VendVar_Amt + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Vend_code + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Vend_Ctrl_Act + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Vend_Curr_Code + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Vend_Curr_Rate + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Vend_Local_amt + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Vend_name + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Vend_Net_Amt + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Vend_Rate + "',");
                                    sb8.Append("'" + ObjList3[n - 1].Vend_Total_amt + "',");
                                    sb8.Append("'" + ObjList3[n - 1].No_of_Qty + "',");
                                    sb8.Append("'" + FQV.CMPYCODE + "')");
                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_BOK005(FF_BOK001_CODE,Crg_code,Crg_name,Cust_code,Cust_Ctrl_Act,Cust_Curr_Code,Cust_Curr_Rate,Cust_Local_amt,Cust_name,Cust_Net_Amt,Cust_Rate,Cust_Total_amt,Cust_Var_Amt,Expense_GL_Code,Income_GL_Code,PAY_MODE,Sno,Unit_Code,VendVar_Amt,Vend_code,Vend_Ctrl_Act,Vend_Curr_Code,Vend_Curr_Rate,Vend_Local_amt,Vend_name,Vend_Net_Amt,Vend_Rate,Vend_Total_amt,No_of_qty,CMPYCODE) values(" + sb8.ToString() + "");
                                }

                                n = n - 1;
                            }
                            #endregion

                            #region FF_BOK001 Update
                            StringBuilder sb9 = new StringBuilder();

                            sb9.Append("CREATED_BY='" + FQV.UserName + "',");
                            sb9.Append("CREATED_ON='" + dtstr1 + "',");
                            sb9.Append("UPDATED_BY='" + FQV.UserName + "',");
                            sb9.Append("UPDATED_ON='" + dtstr1 + "',");
                            sb9.Append("FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "',");
                            sb9.Append("FF_BOK001_DATE='" + dtstr4 + "',");
                            sb9.Append("FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "',");
                            sb9.Append("BILL_TO='" + FQV.BILL_TO + "',");
                            sb9.Append("SHIPPER='" + FQV.SHIPPER + "',");
                            sb9.Append("CONSIGNEE='" + FQV.CONSIGNEE + "',");
                            sb9.Append("FORWARDER='" + FQV.FORWARDER + "',");
                            sb9.Append("PICKUP_PLACE='" + FQV.PICKUP_PLACE + "',");
                            sb9.Append("POL='" + FQV.POL + "',");
                            sb9.Append("POD='" + FQV.POD + "',");
                            sb9.Append("FND='" + FQV.FND + "',");
                            sb9.Append("PLACE_OF_RCPT='" + FQV.PLACE_OF_RCPT + "',");
                            sb9.Append("MOVE_TYPE='" + FQV.MOVE_TYPE + "',");
                            sb9.Append("DELIVERY_AT='" + FQV.DELIVERY_AT + "',");
                            sb9.Append("REF_NO='" + FQV.REF_NO + "',");
                            sb9.Append("VESSEL='" + FQV.VESSEL + "',");
                            sb9.Append("VOYAGE='" + FQV.VOYAGE + "',");
                            sb9.Append("ETD='" + dtstr3 + "',");
                            sb9.Append("ETA='" + dtstr2 + "',");
                            sb9.Append("CARRIER='" + FQV.CARRIER + "',");
                            sb9.Append("DEPARTMENT='" + FQV.DEPARTMENT + "',");
                            sb9.Append("Total_Cost='" + FQV.Total_Cost + "',");
                            sb9.Append("Total_Billed='" + FQV.Total_Billed + "',");
                            sb9.Append("JOB_TYPE='" + FQV.JOB_TYPE + "',");
                            sb9.Append("TRANS_TYPE='" + FQV.TRANS_TYPE + "',");
                            sb9.Append("Commodity_code='" + FQV.Commodity_code + "',");
                            sb9.Append("tranferFrom='" + FQV.tranferFrom + "',");
                            sb9.Append("FNMBRANCH_CODE='" + FQV.FNMBRANCH_CODE + "',");
                            sb9.Append("Total_Profit='" + FQV.Total_Profit + "'");



                            _EzBusinessHelper.ExecuteNonQuery("update FF_BOK001 set  " + sb9 + " where  FF_BOK001_CODE='" + FQV.FF_BOK001_CODE + "' and  cmpycode='" + FQV.CMPYCODE + "' and Flag=0");//CmpyCode='" + FQV.CMPYCODE + "' and                         
                                                                                                                                                                                                      // _EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Add FFM Voyage", ObjList[n - 1].FFM_VOYAGE01_CODE, Environment.MachineName);
                            #endregion

                            _EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Update FF BOK001", FQV.FF_BOK001_CODE, Environment.MachineName);
                        }

                        FQV.ErrorMessage = string.Empty;
                        FQV.SaveFlag = true;
                        scope1.Complete();
                    }
                }
                catch (Exception ex)
                {

                    FQV.ErrorMessage = "Error occur";
                    FQV.SaveFlag = false;

                }
            }

            return FQV;
        }

        public List<ComDropTbl> GetVESSELList(string CmpyCode)
        {
            return drop.GetCommonDrop("FFM_VESSEL_CODE as [Code],NAME as [CodeName]", "FFM_VESSEL", "CMPYCODE='" + CmpyCode + "' and Flag1=0");
        }

        public List<ComDropTbl> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE)
        {

            //select FFM_VOYAGE01_CODE,NAME from FFM_VOYAGE01 where Flag=0 and CMPYCODE='UM' and FFM_VESSEL_CODE=''
            return drop.GetCommonDrop("FFM_VOYAGE01_CODE as [Code],NAME as [CodeName]", "FFM_VOYAGE01", "CMPYCODE='" + CmpyCode + "' and Flag=0 and FFM_VESSEL_CODE='" + FFM_VESSEL_CODE + "'");
        }

        //select a.FNM_SL1001_CODE,a.Name  from FNM_SL1001 a inner join FNM_SL1002 b
        //on a.CMPYCODE=b.CMPYCODE and a.FNM_SL1001_CODE= b.FNM_SL1001_CODE where
        //b.FNM_SL1002_CODE= 'AGT'
        public List<ComDropTbl> GetSL(string CmpyCode,string typ1, string Prefix)
        {
            return drop.GetCommonDrop("FNM_SL1001_CODE as [Code],Name as [CodeName]", "FNM_SL1001", "CMPYCODE='" + CmpyCode + "' and  SUBLEDGER_TYPE='" + typ1 + "' and SUBLEDGER_TYPE !='' and Flag=0 and (FNM_SL1001_CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetSLNew(string CmpyCode, string typ1, string Prefix)
        {
            return drop.GetCommonDrop2("select a.FNM_SL1001_CODE as [Code],a.Name as [CodeName]  from FNM_SL1001 a inner join FNM_SL1002 b "
                                        + " on a.CMPYCODE=b.CMPYCODE and a.FNM_SL1001_CODE= b.FNM_SL1001_CODE and a.flag=b.flag where "
                                        +" b.FNM_SL1002_CODE= '"+ typ1 + "'  and a.CMPYCODE='"+ CmpyCode + "' and a.flag=0 and (a.FNM_SL1001_CODE like '" + Prefix + "%' or a.NAME like '" + Prefix + "%') order by a.FNM_SL1001_CODE");
        }


        public List<ComDropTbl> GetDepart(string CmpyCode)
        {
            return drop.GetCommonDrop("DepartmentCode as [Code],DepartmentName as [CodeName]", "MDEP009", "CMPYCODE='" + CmpyCode + "' and Flag=0");
        }

        public List<ComDropTbl> GetCLAUSE(string CmpyCode)
        {
            return drop.GetCommonDrop("FFM_CLAUSE_CODE as [Code],NAME as [CodeName]", "FFM_CLAUSE", "CMPYCODE='" + CmpyCode + "' and Flag=0");
        }

        public List<FFM_CRG> GetCRG_002(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet1("SELECT  H.FFM_CRG_001_CODE CHARGE_CODE, H.NAME CHARGE_NAME,D.INCOME_ACT ,D.EXPENSE_ACT   FROM FFM_CRG_001 H INNER JOIN FFM_CRG_002 D ON H.FFM_CRG_001_CODE=D.FFM_CRG_001_CODE and H.flag=d.flag where D.operation_type='SEA' and h.cmpycode='" + CmpyCode + "' and D.flag=0");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_CRG> ObjList = new List<FFM_CRG>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_CRG()
                {
                    FFM_CRG_JOB_CODE = dr["CHARGE_CODE"].ToString(),
                    FFM_CRG_JOB_NAME = dr["CHARGE_NAME"].ToString(),
                    INCOME_ACT = dr["INCOME_ACT"].ToString(),
                    EXPENSE_ACGT = dr["EXPENSE_ACT"].ToString(),

                });
            }
            return ObjList;
        }
        public List<ComDropTbl> GetContTyp(string CmpyCode)
        {
            return drop.GetCommonDrop("FFM_CNTR_CODE as [Code],NAME as [CodeName]", "FFM_CNTR", "CMPYCODE='" + CmpyCode + "' and Flag=0");
        }
        public List<FFM_CRG> GetCRGINCEXP(string CmpyCode, string FFM_CRG_001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_CRG_JOB_CODE,FFM_CRG_JOB_NAME,INCOME_ACT,EXPENSE_ACT from FFM_CRG_002 where Flag=0 and FFM_CRG_001_CODE='" + FFM_CRG_001_CODE + "' and CMPYCODE='" + CmpyCode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_CRG> ObjList = new List<FFM_CRG>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_CRG()
                {
                    FFM_CRG_JOB_CODE = dr["FFM_CRG_JOB_CODE"].ToString(),
                    FFM_CRG_JOB_NAME = dr["FFM_CRG_JOB_NAME"].ToString(),
                    INCOME_ACT = dr["INCOME_ACT"].ToString(),
                    EXPENSE_ACGT = dr["EXPENSE_ACT"].ToString(),

                });
            }
            return ObjList;
        }

        public List<ComDropTbl> GetPortList(string CmpyCode)
        {
            return drop.GetCommonDrop("FFM_PORT_CODE as [Code],NAME as [CodeName]", "FFM_PORT", "CMPYCODE='" + CmpyCode + "' and Flag=0");
        }

        public List<ComDropTbl1> GetCust(string CmpyCode)
        {
            return drop.GetCommonDrop1("A.FNM_SL1001_CODE CUSTOMER_CODE,A.Name CUSTOMER_NAME,B.COA_CODE CONTROL_ACT", "FNM_SL1001 A INNER JOIN  FNM_SL1002 B ON A.FNM_SL1001_CODE = B.FNM_SL1001_CODE and  b.CMPYCODE=a.CMPYCODE and A.Flag=B.Flag", "B.FNM_SL1002_CODE='ARP' and B.CMPYCODE='" + CmpyCode + "' and A.Flag=0");
        }

        public List<ComDropTbl1> GetVendor(string CmpyCode)
        {
            return drop.GetCommonDrop1("A.FNM_SL1001_CODE CUSTOMER_CODE,A.Name CUSTOMER_NAME,B.COA_CODE CONTROL_ACT", "FNM_SL1001 A INNER JOIN  FNM_SL1002 B ON A.FNM_SL1001_CODE = B.FNM_SL1001_CODE and  b.CMPYCODE=a.CMPYCODE and A.Flag=B.Flag", "B.FNM_SL1002_CODE='APP' and B.CMPYCODE='" + CmpyCode + "' and A.Flag=0");
        }

        public List<ComDropTbl> GetCurcode(string CmpyCode)
        {
            return drop.GetCommonDrop("CURRENCY_CODE as [Code],CURRENCY_NAME as [CodeName]", "FNM_CURRENCY", " Flag=0");
        }

        public List<ComDropTbl> GetUnitcode(string CmpyCode)
        {
            return drop.GetCommonDrop("FFM_UNIT_CODE as [Code],NAME as [CodeName]", "FFM_UNIT", "CMPYCODE='" + CmpyCode + "' and Flag=0");
        }

        public decimal GetCurRate(string CmpyCode, string CurCode)
        {
            string qur = "Select a.SELL_RATE from FNM_CURR_RATE a " +
                         " right join  (select max(ENTRY_DATE) as [ENTRY_DATE], FROM_CURRENCY_CODE, CMPYCODE from FNM_CURR_RATE group by FROM_CURRENCY_CODE, CMPYCODE ) as [FRMCUR]  on FRMCUR.FROM_CURRENCY_CODE = a.FROM_CURRENCY_CODE and FRMCUR.CMPYCODE = a.CMPYCODE and FRMCUR.ENTRY_DATE = a.ENTRY_DATE " +
                        " where a.CMPYCODE = '" + CmpyCode + "' and a.flag = 0 and a.FROM_CURRENCY_CODE = '" + CurCode + "'";
            decimal GetCurRate = _EzBusinessHelper.ExecuteScalarDec(qur);
            return GetCurRate;
        }

        public List<ComDropTbl> GETJobTypList(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("FFM_JOB_CODE as [Code],NAME as [CodeName]", "FFM_JOB", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (FFM_JOB_CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }
        public List<ComDropTbl> GetCommodityistList(string CmpyCode)
        {
            return drop.GetCommonDrop("FFM_COM_CODE as [Code],NAME as [CodeName]", "FFM_COM", "CMPYCODE='" + CmpyCode + "' and Flag=0");
        }

        public List<ComDropTbl> GetQTNCODE(string CmpyCode, DateTime vdate)
        {

           string dtstr = vdate.ToString("yyyy-MM-dd");

            return drop.GetCommonDrop("FF_QTN001_CODE as [Code],CUST_CODE as [CodeName]", "FF_QTN001", "CMPYCODE='" + CmpyCode + "' and Flag=0 and convert(varchar(25),EFFECT_UPTO,23)>='" + dtstr + "'");
        }

        public List<ComDropTbl> GetSalesman(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("EmpCode as [Code],Empname as [CodeName]", "MEM001", "CMPYCODE='" + CmpyCode + "' and Flag=0 and WorkingStatus='Y' and (EmpCode like '" + Prefix + "%' or Empname like '" + Prefix + "%')");
        }
    }
}
