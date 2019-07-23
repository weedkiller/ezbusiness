using EzBusiness_DL_Interface.FreightManagementDLI.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System.Data;
using EzBusiness_EF_Entity.FreightManagementEF;
using System.Transactions;

namespace EzBusiness_DL_Repository.FreightManagementDLR.SEA_Export
{
    public class FF_QTNRepository : IFF_QTNRepository
    {

        DataSet ds = null;
        DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        DropListFillFun drop = new DropListFillFun();
        public bool DeleteFF_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FF_QTN001 where  FF_QTN001_CODE='" + FF_QTN001_CODE + "'  and Flag=0");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FF_QTN_CODE", FF_QTN001_CODE, Environment.MachineName);

                _EzBusinessHelper.ExecuteNonQuery1("update FF_QTN002 set Flag=1 where  FF_QTN001_CODE='" + FF_QTN001_CODE + "'  and Flag=0");
                _EzBusinessHelper.ExecuteNonQuery1("update FF_QTN003 set Flag=1 where  FF_QTN001_CODE='" + FF_QTN001_CODE + "'  and Flag=0");
                _EzBusinessHelper.ExecuteNonQuery1("update FF_QTN004 set Flag=1 where  FF_QTN001_CODE='" + FF_QTN001_CODE + "'  and Flag=0");
                _EzBusinessHelper.ExecuteNonQuery1("update FF_QTN005 set Flag=1 where  FF_QTN001_CODE='" + FF_QTN001_CODE + "'  and Flag=0");

                return _EzBusinessHelper.ExecuteNonQuery1("update FF_QTN001 set Flag=1 where  FF_QTN001_CODE='" + FF_QTN001_CODE + "'  and Flag=0");//CMPYCODE='" + CmpyCode + "' and

            }
            return false;
        }
     
        public List<FF_QTN_VM> GetFF_QTN(string CmpyCode,string BranchCode)
        {                                       
            ds = _EzBusinessHelper.ExecuteDataSet("Select JOB_TYPE,Branchcode,Commodity_code,DG,PZIP,PSTATE,FDZIP,FDSTATE,FF_QTN001_CODE,CUST_CODE,CONTACT,TELEPHONE,EMAIL,CUSTOMER_REF,PICKUP_PLACE,POL,POD,FND,MOVE_TYPE,REF_NO,VESSEL,VOYAGE,CARRIER,EFFECT_FROM,EFFECT_UPTO,DEPARTMENT,Total_Cost,Total_Billed,Total_Profit,Salesman,AGENT,notifypart1,notifypart2,Branchcode from FF_QTN001 where Flag=0 and  CMPYCODE='" + CmpyCode + "' and Branchcode='" + BranchCode + "' ");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_QTN_VM> ObjList = new List<FF_QTN_VM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_QTN_VM()
                {
                    CARRIER = dr["CARRIER"].ToString(),
                    CONTACT = dr["CONTACT"].ToString(),
                    CUSTOMER_REF = dr["CUSTOMER_REF"].ToString(),
                    CUST_CODE = dr["CUST_CODE"].ToString(),
                    DEPARTMENT=dr["DEPARTMENT"].ToString(),
                    EMAIL=dr["EMAIL"].ToString(),
                    FF_QTN001_CODE=dr["FF_QTN001_CODE"].ToString(),
                    EFFECT_FROM=Convert.ToDateTime(dr["EFFECT_FROM"].ToString()),
                    EFFECT_UPTO= Convert.ToDateTime(dr["EFFECT_UPTO"].ToString()),
                    FND=dr["FND"].ToString(),
                    MOVE_TYPE=dr["MOVE_TYPE"].ToString(),
                    PICKUP_PLACE=dr["PICKUP_PLACE"].ToString(),
                    POD=dr["POD"].ToString(),
                    POL=dr["POL"].ToString(),
                    REF_NO=dr["REF_NO"].ToString(),
                    TELEPHONE=dr["TELEPHONE"].ToString(),
                    Total_Billed= Convert.ToDecimal(dr["Total_Billed"].ToString()),
                    Total_Cost= Convert.ToDecimal(dr["Total_Cost"].ToString()),
                    Total_Profit= Convert.ToDecimal(dr["Total_Profit"].ToString()),
                    VESSEL=dr["VESSEL"].ToString(),
                    VOYAGE=dr["VOYAGE"].ToString(),
                    FNMBRANCH_CODE=dr["Branchcode"].ToString(),
                 //   IMCO = dr["IMCO"].ToString(),
                    AGENT = dr["AGENT"].ToString(),
                    Salesman    = dr["Salesman"].ToString(),
                    notifypart1 = dr["notifypart1"].ToString(),
                    notifypart2 = dr["notifypart2"].ToString(),
                    DG = dr["DG"].ToString(),
                    Commodity_code =dr["Commodity_code"].ToString(),
                    JOB_TYPE=dr["JOB_TYPE"].ToString()
                });
            }
            return ObjList;
        }

        public List<FF_QTN002New> GetFF_QTN002DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select Commodity_code,CBM,CFT,Container,Contents,Cont_Type,KG,LBS,No_of_qty,Seal1,sno from FF_QTN002 where Flag=0 and FF_QTN001_CODE='" + FF_QTN001_CODE + "' and CMPYCODE='" + CmpyCode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_QTN002New> ObjList = new List<FF_QTN002New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_QTN002New()
                {
                    CBM =Convert.ToDecimal(dr["CBM"].ToString()),
                    CFT = Convert.ToDecimal(dr["CFT"].ToString()),
                    Container = dr["Container"].ToString(),
                    Contents = dr["Contents"].ToString(),
                    Cont_Type=dr["Cont_Type"].ToString(),
                    KG= Convert.ToDecimal(dr["KG"].ToString()),
                    LBS= Convert.ToDecimal(dr["LBS"].ToString()),
                    No_of_qty= Convert.ToInt32(dr["No_of_qty"].ToString()),
                    Seal1= Convert.ToInt32(dr["Seal1"].ToString()),
                    sno = Convert.ToInt32(dr["sno"].ToString()),
                    Commodity_code=dr["Commodity_code"].ToString()


                });
            }
            return ObjList;
        }

        public List<FF_QTN003New> GetFF_QTN003DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select No_of_qty,Act_LBS,Dime_weight,Height,inside_Unit,Pkg_No,Sno,unit_type,Volume,Width from FF_QTN003 where Flag=0 and FF_QTN001_CODE='" + FF_QTN001_CODE + "' and CMPYCODE='" + CmpyCode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_QTN003New> ObjList = new List<FF_QTN003New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_QTN003New()
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
                    No_of_qty= Convert.ToInt32(dr["No_of_qty"].ToString()),
                });
            }
            return ObjList;
        }

        public List<FF_QTN004New> GetFF_QTN004DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select CLAUSE_CODE,CLAUSE_NAME from FF_QTN004 where Flag=0 and FF_QTN001_CODE='" + FF_QTN001_CODE + "' and CMPYCODE='" + CmpyCode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_QTN004New> ObjList = new List<FF_QTN004New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_QTN004New()
                {
                    CLUASE_CODE = dr["CLAUSE_CODE"].ToString(),
                    CLUASE_NAME = dr["CLAUSE_NAME"].ToString(),                  
                });
            }
            return ObjList;
        }

        public List<FF_QTN005New> GetFF_QTN005DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FF_QTN005 where Flag=0 and FF_QTN001_CODE='" + FF_QTN001_CODE + "' and CMPYCODE='" + CmpyCode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FF_QTN005New> ObjList = new List<FF_QTN005New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FF_QTN005New()
                {
                    Crg_code = dr["Crg_code"].ToString(),
                    Crg_name = dr["Crg_name"].ToString(),
                    Cust_Total_amt=Convert.ToDecimal(dr["Cust_Total_amt"].ToString()),
                    Cust_Curr_Rate = Convert.ToDecimal(dr["Cust_Curr_Rate"].ToString()),
                    Cust_Local_amt = Convert.ToDecimal(dr["Cust_Local_amt"].ToString()),
                    Cust_Var_Amt = Convert.ToDecimal(dr["Cust_Var_Amt"].ToString()),
                    Vend_Total_amt= Convert.ToDecimal(dr["Vend_Total_amt"].ToString()),
                    Cust_Net_Amt = Convert.ToDecimal(dr["Cust_Net_Amt"].ToString()),
                    Cust_Rate = Convert.ToDecimal(dr["Cust_Rate"].ToString()),
                    VendVar_Amt= Convert.ToDecimal(dr["VendVar_Amt"].ToString()),
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
                    Sno=Convert.ToInt32(dr["Sno"].ToString()),
                    Unit_Code=dr["Unit_Code"].ToString(),
                    Vend_code=dr["Vend_code"].ToString(),
                    Vend_Ctrl_Act=dr["Vend_Ctrl_Act"].ToString(),
                    Vend_Curr_Code=dr["Vend_Curr_Code"].ToString(),
                    Vend_name = dr["Vend_name"].ToString(),
                    No_of_qty= Convert.ToDecimal(dr["No_of_qty"].ToString()),

                });
            }
            return ObjList;
        }

        public FF_QTN_VM GetFF_QTNDetailsEdit(string CmpyCode, string FF_QTN001_CODE,string BranchCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select JOB_TYPE,Branchcode,Commodity_code,PZIP,PSTATE,FDZIP,FDSTATE,FF_QTN001_CODE,CUST_CODE,CONTACT,TELEPHONE,EMAIL,CUSTOMER_REF,PICKUP_PLACE,POL,POD,FND,MOVE_TYPE,REF_NO,VESSEL,VOYAGE,CARRIER,EFFECT_FROM,EFFECT_UPTO,DEPARTMENT,Total_Cost,Total_Billed,Total_Profit,Salesman,AGENT,notifypart1,notifypart2,Branchcode,DG from FF_QTN001 where Flag=0 and FF_QTN001_CODE='" + FF_QTN001_CODE + "' and CMPYCODE='" + CmpyCode + "' and Branchcode='" + BranchCode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FF_QTN_VM ObjList = new FF_QTN_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.CARRIER = dr["CARRIER"].ToString();
                ObjList.CONTACT = dr["CONTACT"].ToString();
                ObjList.CUSTOMER_REF = dr["CUSTOMER_REF"].ToString();
                ObjList.CUST_CODE = dr["CUST_CODE"].ToString();
                ObjList.DEPARTMENT = dr["DEPARTMENT"].ToString();
                ObjList.EMAIL = dr["EMAIL"].ToString();
                ObjList.FF_QTN001_CODE = dr["FF_QTN001_CODE"].ToString();
                ObjList.EFFECT_FROM = Convert.ToDateTime(dr["EFFECT_FROM"].ToString());
                ObjList.EFFECT_UPTO = Convert.ToDateTime(dr["EFFECT_UPTO"].ToString());
                ObjList.FND = dr["FND"].ToString();
                ObjList.MOVE_TYPE = dr["MOVE_TYPE"].ToString();
                ObjList.PICKUP_PLACE = dr["PICKUP_PLACE"].ToString();
                ObjList.POD = dr["POD"].ToString();
                ObjList.POL = dr["POL"].ToString();
                ObjList.REF_NO = dr["REF_NO"].ToString();
                ObjList.TELEPHONE = dr["TELEPHONE"].ToString();
                ObjList.Total_Billed = Convert.ToDecimal(dr["Total_Billed"].ToString());
                ObjList.Total_Cost = Convert.ToDecimal(dr["Total_Cost"].ToString());
                ObjList.Total_Profit = Convert.ToDecimal(dr["Total_Profit"].ToString());
                ObjList.VESSEL = dr["VESSEL"].ToString();
                ObjList.VOYAGE = dr["VOYAGE"].ToString();
                ObjList.FDSTATE = dr["FDSTATE"].ToString();
                ObjList.FDZIP = dr["FDZIP"].ToString();
                ObjList.PSTATE = dr["PSTATE"].ToString();
                ObjList.PZIP = dr["PZIP"].ToString();
                ObjList.Commodity_code = dr["Commodity_code"].ToString();
                ObjList.DG = dr["DG"].ToString();
                ObjList.AGENT = dr["AGENT"].ToString();
                ObjList.Salesman = dr["Salesman"].ToString();
                ObjList.notifypart1 = dr["notifypart1"].ToString();
                ObjList.notifypart2 = dr["notifypart2"].ToString();
                ObjList.FNMBRANCH_CODE = dr["Branchcode"].ToString();
                ObjList.JOB_TYPE = dr["JOB_TYPE"].ToString();
            }
            return ObjList;
        }

        public List<ComDropTbl> GetMOVEList(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("FFM_MOVE_CODE as [Code],NAME as [CodeName]", "FFM_MOVE", "CMPYCODE='"+ CmpyCode + "' and Flag=0 and (FFM_MOVE_CODE like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }

        public FF_QTN_VM SaveFF_QTN_VM(FF_QTN_VM FQV)
        {
            DateTime dte;
            string dtstr1, dtstr2, dtstr3;
            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            dte = Convert.ToDateTime(FQV.EFFECT_FROM);
            dtstr2 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(FQV.EFFECT_UPTO);
            dtstr3 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            if (!FQV.EditFlag)
            {
                try
                {

                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        #region FF_QTN002
                        List<FF_QTN002> ObjList = new List<FF_QTN002>();
                        if (FQV.FF_QTN002Detail != null)
                        {
                            ObjList.AddRange(FQV.FF_QTN002Detail.Select(m => new FF_QTN002
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
                                Commodity_code=m.Commodity_code
                            }).ToList());
                        }

                        #endregion

                        #region FF_QTN003
                        List<FF_QTN003> ObjList1 = new List<FF_QTN003>();
                        if (FQV.FF_QTN003Detail != null)
                        {
                            ObjList1.AddRange(FQV.FF_QTN003Detail.Select(m => new FF_QTN003
                            {
                                Width = m.Width,
                                Sno = m.Sno,
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

                        #region FF_QTN004

                        List<FF_QTN004> ObjList2 = new List<FF_QTN004>();
                        if (FQV.FF_QTN004Detail != null)
                        {
                            ObjList2.AddRange(FQV.FF_QTN004Detail.Select(m => new FF_QTN004
                            {
                                CLUASE_CODE = m.CLUASE_CODE,
                                CLUASE_NAME = m.CLUASE_NAME
                            }).ToList());
                        }
                        #endregion

                        #region FF_QTN005
                        List<FF_QTN005> ObjList3 = new List<FF_QTN005>();
                        if (FQV.FF_QTN005Detail != null)
                        {
                            ObjList3.AddRange(FQV.FF_QTN005Detail.Select(m => new FF_QTN005
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
                                No_of_qty=m.No_of_qty

                            }).ToList());
                        }
                        #endregion

                        //---
                        int n, i = 0;

                        #region FF_QTN002 INSERT LOOP
                        n = ObjList.Count;
                        while (n > 0)
                        {

                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_QTN002 where FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                            if (Stats1 == 0)
                            {
                                StringBuilder sb = new StringBuilder();

                                sb.Append("'" + FQV.FF_QTN001_CODE + "',");
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
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_QTN002(FF_QTN001_CODE,CBM,CFT,Container,Contents,Cont_Type,KG,LBS,No_of_qty,Seal1,sno,Commodity_code,cmpycode) values(" + sb.ToString() + "");
                                //_EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Add FFM Charge", ObjList[n - 1].FF_QTN001_CODE, Environment.MachineName);

                            }

                            n = n - 1;
                        }
                        #endregion


                        #region FF_QTN003 INSERT LOOP
                        n = ObjList1.Count;
                        while (n > 0)
                        {

                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_QTN003 where FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                            if (Stats1 == 0)
                            {
                                StringBuilder sb1 = new StringBuilder();
                                sb1.Append("'" + FQV.FF_QTN001_CODE + "',");
                                sb1.Append("'" + ObjList1[n - 1].Act_LBS + "',");
                                sb1.Append("'" + ObjList1[n - 1].Dime_weight + "',");
                                sb1.Append("'" + ObjList1[n - 1].Height + "',");
                                sb1.Append("'" + ObjList1[n - 1].inside_Unit + "',");
                                sb1.Append("'" + ObjList1[n - 1].No_of_qty + "',");
                                sb1.Append("'" + ObjList1[n - 1].Pkg_No + "',");
                                sb1.Append("'" + ObjList1[n - 1].Sno + "',");
                                sb1.Append("'" + ObjList1[n - 1].unit_type + "',");
                                sb1.Append("'" + ObjList1[n - 1].Width + "',");
                                sb1.Append("'" + ObjList1[n - 1].Volume + "',");

                                sb1.Append("'" + FQV.CMPYCODE + "')");
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_QTN003(FF_QTN001_CODE,Act_LBS,Dime_weight,Height,inside_Unit,No_of_qty,Pkg_No,Sno,unit_type,Width,Volume,cmpycode) values(" + sb1.ToString() + "");

                            }

                            n = n - 1;
                        }
                        #endregion

                        #region FF_QTN004 INSERT LOOP
                        n = ObjList2.Count;
                        while (n > 0)
                        {
                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_QTN004 where FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                            if (Stats1 == 0)
                            {
                                StringBuilder sb2 = new StringBuilder();
                                sb2.Append("'" + FQV.FF_QTN001_CODE + "',");
                                sb2.Append("'" + ObjList2[n - 1].CLUASE_CODE + "',");
                                sb2.Append("'" + ObjList2[n - 1].CLUASE_NAME + "',");
                                sb2.Append("'" + FQV.CMPYCODE + "')");
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_QTN004(FF_QTN001_CODE,CLAUSE_CODE,CLAUSE_NAME,cmpycode) values(" + sb2.ToString() + "");
                            }

                            n = n - 1;
                        }
                        #endregion

                        #region FF_QTN005 INSERT LOOP
                        n = ObjList3.Count;
                        while (n > 0)
                        {
                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_QTN005 where FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                            if (Stats1 == 0)
                            {
                                StringBuilder sb3 = new StringBuilder();
                                sb3.Append("'" + FQV.FF_QTN001_CODE + "',");
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
                                sb3.Append("'" + ObjList3[n - 1].No_of_qty + "',");
                                sb3.Append("'" + FQV.CMPYCODE + "')");
                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_QTN005(FF_QTN001_CODE,Crg_code,Crg_name,Cust_code,Cust_Ctrl_Act,Cust_Curr_Code,Cust_Curr_Rate,Cust_Local_amt,Cust_name,Cust_Net_Amt,Cust_Rate,Cust_Total_amt,Cust_Var_Amt,Expense_GL_Code,Income_GL_Code,PAY_MODE,Sno,Unit_Code,VendVar_Amt,Vend_code,Vend_Ctrl_Act,Vend_Curr_Code,Vend_Curr_Rate,Vend_Local_amt,Vend_name,Vend_Net_Amt,Vend_Rate,Vend_Total_amt,No_of_qty,CMPYCODE) values(" + sb3.ToString() + "");
                            }

                            n = n - 1;
                        }
                        #endregion

                        #region FF_QTN001 INSERT Header
                        //if (i > 0)
                        //{
                            StringBuilder sb4 = new StringBuilder();
                            sb4.Append("'" + FQV.UserName + "',");
                            sb4.Append("'" + dtstr1 + "',");
                            sb4.Append("'" + FQV.UserName + "',");
                            sb4.Append("'" + dtstr1 + "',");
                            sb4.Append("'" + FQV.CMPYCODE + "',");
                            sb4.Append("'" + FQV.FF_QTN001_CODE + "',");
                            sb4.Append("'" + FQV.CUST_CODE + "',");
                            sb4.Append("'" + FQV.CONTACT + "',");
                            sb4.Append("'" + FQV.TELEPHONE + "',");
                            sb4.Append("'" + FQV.EMAIL + "',");
                            sb4.Append("'" + FQV.CUSTOMER_REF + "',");
                            sb4.Append("'" + FQV.PICKUP_PLACE + "',");
                            sb4.Append("'" + FQV.POL + "',");
                            sb4.Append("'" + FQV.POD + "',");
                            sb4.Append("'" + FQV.FND + "',");
                            sb4.Append("'" + FQV.MOVE_TYPE + "',");
                            sb4.Append("'" + FQV.REF_NO + "',");
                            sb4.Append("'" + FQV.VESSEL + "',");
                            sb4.Append("'" + FQV.VOYAGE + "',");
                            sb4.Append("'" + FQV.CARRIER + "',");
                            sb4.Append("'" + dtstr2 + "',");
                            sb4.Append("'" + dtstr3 + "',");
                            sb4.Append("'" + FQV.DEPARTMENT + "',");
                            sb4.Append("'" + FQV.Total_Cost + "',");
                            sb4.Append("'" + FQV.Total_Billed + "',");
                            sb4.Append("'" + FQV.PZIP + "',");
                            sb4.Append("'" + FQV.PSTATE + "',");
                            sb4.Append("'" + FQV.FDSTATE + "',");
                            sb4.Append("'" + FQV.FDZIP + "',");
                            sb4.Append("'" + FQV.Commodity_code + "',");
                            sb4.Append("'" + FQV.FNMBRANCH_CODE + "',");
                         //   sb4.Append("'" + FQV.IMCO + "',");
                            sb4.Append("'" + FQV.AGENT + "',");
                            sb4.Append("'" + FQV.Salesman + "',");
                            sb4.Append("'" + FQV.notifypart1 + "',");
                            sb4.Append("'" + FQV.notifypart2 + "',");
                            sb4.Append("'" + FQV.DG + "',");
                            sb4.Append("'" + FQV.JOB_TYPE + "',");
                            sb4.Append("'" + FQV.Total_Profit + "')");
                            i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_QTN001(CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,CMPYCODE,FF_QTN001_CODE,CUST_CODE,CONTACT,TELEPHONE,EMAIL,CUSTOMER_REF,PICKUP_PLACE,POL,POD,FND,MOVE_TYPE,REF_NO,VESSEL,VOYAGE,CARRIER,EFFECT_FROM,EFFECT_UPTO,DEPARTMENT,Total_Cost,Total_Billed,PZIP,PSTATE,FDSTATE,FDZIP,Commodity_code,Branchcode,AGENT,Salesman,notifypart1,notifypart2,DG,JOB_TYPE,Total_Profit) values(" + sb4.ToString() + "");

                        int pno = _EzBusinessHelper.ExecuteScalar("Select Nos from PARTTBL001 where CmpyCode='" + FQV.CMPYCODE + "' and Code='QUOS' ");

                        _EzBusinessHelper.ExecuteNonQuery(" UPDATE PARTTBL001 SET Nos = " + (pno + 1) + " where CmpyCode='" + FQV.CMPYCODE + "' and Code='QUOS'");

                        #endregion
                        _EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Update FF QTN", FQV.FF_QTN001_CODE, Environment.MachineName);
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
                    ds = _EzBusinessHelper.ExecuteDataSet("Select * from FF_QTN001 where CmpyCode='" + FQV.CMPYCODE + "' and FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "'");
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        FF_QTN001 FQT1 = new FF_QTN001();
                        dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {                   
                            FQT1.CARRIER = FQV.CARRIER;
                            FQT1.CMPYCODE = FQV.CMPYCODE;
                            FQT1.CONTACT = FQV.CONTACT;
                            FQT1.CREATED_BY = FQV.CREATED_BY;
                            FQT1.CREATED_ON = FQV.CREATED_ON;
                            FQT1.CUSTOMER_REF = FQV.CUSTOMER_REF;
                            FQT1.CUST_CODE = FQV.CUST_CODE;
                            FQT1.DEPARTMENT = FQV.DEPARTMENT;
                            FQT1.EFFECT_FROM = FQV.EFFECT_FROM;
                            FQT1.EFFECT_UPTO = FQV.EFFECT_UPTO;
                            FQT1.EMAIL = FQV.EMAIL;
                            FQT1.FF_QTN001_CODE = FQV.FF_QTN001_CODE;
                            FQT1.FND = FQV.FND;
                            FQT1.MOVE_TYPE = FQV.MOVE_TYPE;
                            FQT1.PICKUP_PLACE = FQV.PICKUP_PLACE;
                            FQT1.POD = FQV.POD;
                            FQT1.POL = FQV.POL;
                            FQT1.REF_NO = FQV.REF_NO;
                            FQT1.TELEPHONE = FQV.TELEPHONE;
                            FQT1.Total_Billed = FQV.Total_Billed;
                            FQT1.Total_Cost = FQV.Total_Cost;
                            FQT1.Total_Profit = FQV.Total_Profit;
                            FQT1.UPDATED_BY = FQV.UPDATED_BY;
                            FQT1.UPDATED_ON = FQV.UPDATED_ON;
                            FQT1.VESSEL = FQV.VESSEL;
                            FQT1.VOYAGE = FQV.VOYAGE;
                            FQT1.PZIP = FQV.PZIP;
                            FQT1.PSTATE = FQV.PSTATE;
                            FQT1.FDSTATE = FQV.FDSTATE;
                            FQT1.FDZIP = FQV.FDZIP;
                            FQT1.JOB_TYPE = FQV.JOB_TYPE;
                            FQT1.Commodity_code = FQV.Commodity_code;
                            FQT1.FNMBRANCH_CODE = FQV.FNMBRANCH_CODE;
                           
                            FQT1.Salesman = FQV.Salesman;
                            FQT1.DG = FQV.DG;
                            FQT1.notifypart1 = FQV.notifypart1;
                            FQT1.notifypart2 = FQV.notifypart2;
                            _EzBusinessHelper.ExecuteNonQuery("delete from FF_QTN002 where CmpyCode='" + FQV.CMPYCODE + "' and FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "'");
                            _EzBusinessHelper.ExecuteNonQuery("delete from FF_QTN003 where CmpyCode='" + FQV.CMPYCODE + "' and FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "'");
                            _EzBusinessHelper.ExecuteNonQuery("delete from FF_QTN004 where CmpyCode='" + FQV.CMPYCODE + "' and FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "'");
                            _EzBusinessHelper.ExecuteNonQuery("delete from FF_QTN005 where CmpyCode='" + FQV.CMPYCODE + "' and FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "'");
                            // #region ObjectList
                            #region FF_QTN002
                            List<FF_QTN002> ObjList = new List<FF_QTN002>();
                            if (FQV.FF_QTN002Detail != null)
                            {
                                ObjList.AddRange(FQV.FF_QTN002Detail.Select(m => new FF_QTN002
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
                                    Commodity_code=m.Commodity_code,
                                    sno = m.sno,
                                }).ToList());
                            }

                            #endregion

                            #region FF_QTN003
                            List<FF_QTN003> ObjList1 = new List<FF_QTN003>();
                            if (FQV.FF_QTN003Detail != null)
                            {
                                ObjList1.AddRange(FQV.FF_QTN003Detail.Select(m => new FF_QTN003
                                {
                                    Width = m.Width,
                                    Sno = m.Sno,
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

                            #region FF_QTN004
                            List<FF_QTN004> ObjList2 = new List<FF_QTN004>();
                            if (FQV.FF_QTN004Detail != null)
                            {
                                ObjList2.AddRange(FQV.FF_QTN004Detail.Select(m => new FF_QTN004
                                {
                                    CLUASE_CODE = m.CLUASE_CODE,
                                    CLUASE_NAME = m.CLUASE_NAME
                                }).ToList());
                            }
                            #endregion

                            #region FF_QTN005
                            List<FF_QTN005> ObjList3 = new List<FF_QTN005>();
                            if (FQV.FF_QTN005Detail != null)
                            {
                                ObjList3.AddRange(FQV.FF_QTN005Detail.Select(m => new FF_QTN005
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
                                    No_of_qty = m.No_of_qty
                                }).ToList());
                            }
                            #endregion

                            //---
                            int n, i = 0;

                            #region FF_QTN002 INSERT LOOP
                            n = ObjList.Count;
                            while (n > 0)
                            {

                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_QTN002 where FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb5 = new StringBuilder();

                                    sb5.Append("'" + FQV.FF_QTN001_CODE + "',");
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
                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_QTN002(FF_QTN001_CODE,CBM,CFT,Container,Contents,Cont_Type,KG,LBS,No_of_qty,Seal1,sno,Commodity_code,cmpycode) values(" + sb5.ToString() + "");
                                    //_EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Add FFM Charge", ObjList[n - 1].FF_QTN001_CODE, Environment.MachineName);

                                }

                                n = n - 1;
                            }
                            #endregion

                            #region FF_QTN003 INSERT LOOP
                            n = ObjList1.Count;
                            while (n > 0)
                            {

                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_QTN003 where FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb6 = new StringBuilder();
                                    sb6.Append("'" + FQV.FF_QTN001_CODE + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Act_LBS + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Dime_weight + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Height + "',");
                                    sb6.Append("'" + ObjList1[n - 1].inside_Unit + "',");
                                    sb6.Append("'" + ObjList1[n - 1].No_of_qty + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Pkg_No + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Sno + "',");
                                    sb6.Append("'" + ObjList1[n - 1].unit_type + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Volume + "',");
                                    sb6.Append("'" + ObjList1[n - 1].Width + "',");
                                    sb6.Append("'" + FQV.CMPYCODE + "')");
                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_QTN003(FF_QTN001_CODE,Act_LBS,Dime_weight,Height,inside_Unit,No_of_qty,Pkg_No,Sno,unit_type,Volume,Width,cmpycode) values(" + sb6.ToString() + "");

                                }

                                n = n - 1;
                            }
                            #endregion

                            #region FF_QTN004 INSERT LOOP
                            n = ObjList2.Count;
                            while (n > 0)
                            {
                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_QTN004 where FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb7 = new StringBuilder();
                                    sb7.Append("'" + FQV.FF_QTN001_CODE + "',");
                                    sb7.Append("'" + ObjList2[n - 1].CLUASE_CODE + "',");
                                    sb7.Append("'" + ObjList2[n - 1].CLUASE_NAME + "',");
                                    sb7.Append("'" + FQV.CMPYCODE + "')");
                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_QTN004(FF_QTN001_CODE,CLAUSE_CODE,CLAUSE_NAME,cmpycode) values(" + sb7.ToString() + "");
                                }

                                n = n - 1;
                            }
                            #endregion

                            #region FF_QTN005 INSERT LOOP
                            n = ObjList3.Count;
                            while (n > 0)
                            {
                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FF_QTN005 where FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "' and  CmpyCode='" + FQV.CMPYCODE + "' and flag=0");// CmpyCode='" + FQV.CMPYCODE + "' and
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb8 = new StringBuilder();
                                    sb8.Append("'" + FQV.FF_QTN001_CODE + "',");
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
                                    sb8.Append("'" + ObjList3[n - 1].No_of_qty + "',");
                                    sb8.Append("'" + FQV.CMPYCODE + "')");
                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into FF_QTN005(FF_QTN001_CODE,Crg_code,Crg_name,Cust_code,Cust_Ctrl_Act,Cust_Curr_Code,Cust_Curr_Rate,Cust_Local_amt,Cust_name,Cust_Net_Amt,Cust_Rate,Cust_Total_amt,Cust_Var_Amt,Expense_GL_Code,Income_GL_Code,PAY_MODE,Sno,Unit_Code,VendVar_Amt,Vend_code,Vend_Ctrl_Act,Vend_Curr_Code,Vend_Curr_Rate,Vend_Local_amt,Vend_name,Vend_Net_Amt,Vend_Rate,Vend_Total_amt,No_of_qty,CMPYCODE) values(" + sb8.ToString() + "");
                                }

                                n = n - 1;
                            }
                            #endregion

                            #region FF_QTN001 Update
                            StringBuilder sb9 = new StringBuilder();

                            sb9.Append("CREATED_BY='" + FQV.UserName + "',");
                            sb9.Append("CREATED_ON='" + dtstr1 + "',");
                            sb9.Append("UPDATED_BY='" + FQV.UserName + "',");
                            sb9.Append("UPDATED_ON='" + dtstr1 + "',");                                                                                    
                            sb9.Append("CUST_CODE='" + FQV.CUST_CODE + "',");
                            sb9.Append("CONTACT='" + FQV.CONTACT + "',");
                            sb9.Append("TELEPHONE='" + FQV.TELEPHONE + "',");
                            sb9.Append("EMAIL='" + FQV.EMAIL + "',");
                            sb9.Append("CUSTOMER_REF='" + FQV.CUSTOMER_REF + "',");
                            sb9.Append("PICKUP_PLACE='" + FQV.PICKUP_PLACE + "',");
                            sb9.Append("POL='" + FQV.POL + "',");
                            sb9.Append("POD='" + FQV.POD + "',");
                            sb9.Append("FND='" + FQV.FND + "',");
                            sb9.Append("MOVE_TYPE='" + FQV.MOVE_TYPE + "',");
                            sb9.Append("REF_NO='" + FQV.REF_NO + "',");
                            sb9.Append("VESSEL='" + FQV.VESSEL + "',");
                            sb9.Append("VOYAGE='" + FQV.VOYAGE + "',");
                            sb9.Append("CARRIER='" + FQV.CARRIER + "',");
                            sb9.Append("EFFECT_FROM='" + dtstr2 + "',");
                            sb9.Append("EFFECT_UPTO='" + dtstr3 + "',");
                            sb9.Append("DEPARTMENT='" + FQV.DEPARTMENT + "',");
                            sb9.Append("Total_Cost='" + FQV.Total_Cost + "',");
                            sb9.Append("Total_Billed='" + FQV.Total_Billed + "',");
                            sb9.Append("PZIP='" + FQV.PZIP + "',");
                            sb9.Append("PSTATE='" + FQV.PSTATE + "',");
                            sb9.Append("FDZIP='" + FQV.FDZIP + "',");
                            sb9.Append("FDSTATE='" + FQV.FDSTATE + "',");
                            sb9.Append("JOB_TYPE='" + FQV.JOB_TYPE + "',");
                            sb9.Append("Commodity_code='" + FQV.Commodity_code + "',");
                            sb9.Append("Branchcode='" + FQV.FNMBRANCH_CODE + "',");
                            sb9.Append("Total_Profit='" + FQV.Total_Profit + "'");
                          

                            _EzBusinessHelper.ExecuteNonQuery("update FF_QTN001 set  " + sb9 + " where  FF_QTN001_CODE='" + FQV.FF_QTN001_CODE + "' and  cmpycode='" + FQV.CMPYCODE + "' and Flag=0");//CmpyCode='" + FQV.CMPYCODE + "' and                         
                                                                                                                                                                                                      // _EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Add FFM Voyage", ObjList[n - 1].FFM_VOYAGE01_CODE, Environment.MachineName);
                            #endregion

                            _EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Update FF QTN001", FQV.FF_QTN001_CODE, Environment.MachineName);
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

        public List<ComDropTbl> GetVESSELList(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("FFM_VESSEL_CODE as [Code],NAME as [CodeName]", "FFM_VESSEL", "CMPYCODE='" + CmpyCode + "' and Flag1=0 and (FFM_VESSEL_CODE like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetVOYAGEList(string CmpyCode,string FFM_VESSEL_CODE, string Prefix)
        {

            //select FFM_VOYAGE01_CODE,NAME from FFM_VOYAGE01 where Flag=0 and CMPYCODE='UM' and FFM_VESSEL_CODE=''
            return drop.GetCommonDrop("FFM_VOYAGE01_CODE as [Code],NAME as [CodeName]", "FFM_VOYAGE01", "CMPYCODE='" + CmpyCode + "' and Flag=0 and FFM_VESSEL_CODE='"+ FFM_VESSEL_CODE + "' and (FFM_VOYAGE01_CODE like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetSL(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("FNM_SL1001_CODE as [Code],Name as [CodeName]", "FNM_SL1001", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (FNM_SL1001_CODE like '" + Prefix + "%' or Name like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetDepart(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("DepartmentCode as [Code],DepartmentName as [CodeName]", "MDEP009", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (DepartmentCode like '" + Prefix + "%' or DepartmentName like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetCLAUSE(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("FFM_CLAUSE_CODE as [Code],NAME as [CodeName]", "FFM_CLAUSE", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (FFM_CLAUSE_CODE like '"+Prefix+"%' or NAME like '"+Prefix+"%')");
        }

        public List<FFM_CRG> GetCRG_002(string CmpyCode, string Prefix)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("SELECT  H.FFM_CRG_001_CODE CHARGE_CODE, H.NAME CHARGE_NAME,D.INCOME_ACT ,D.EXPENSE_ACT   FROM FFM_CRG_001 H INNER JOIN FFM_CRG_002 D ON H.FFM_CRG_001_CODE=D.FFM_CRG_001_CODE and H.flag=d.flag where D.operation_type='SEA' and h.cmpycode='" + CmpyCode + "' and D.flag=0 and (H.FFM_CRG_001_CODE like '" + Prefix + "%' or H.NAME like '" + Prefix + "%')");// CMPYCODE='" + CmpyCode + "' and 
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
        public List<ComDropTbl> GetContTyp(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("FFM_CNTR_CODE as [Code],NAME as [CodeName]", "FFM_CNTR", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (FFM_CNTR_CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }
        public List<FFM_CRG> GetCRGINCEXP(string CmpyCode, string FFM_CRG_001_CODE, string Prefix)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_CRG_JOB_CODE,FFM_CRG_JOB_NAME,INCOME_ACT,EXPENSE_ACT from FFM_CRG_002 where Flag=0 and FFM_CRG_001_CODE='" + FFM_CRG_001_CODE + "' and CMPYCODE='" + CmpyCode + "' and (FFM_CRG_JOB_CODE like '" + Prefix + "%' or FFM_CRG_JOB_NAME like '" + Prefix + "%')");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_CRG> ObjList = new List<FFM_CRG>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_CRG()
                {
                    FFM_CRG_JOB_CODE = dr["FFM_CRG_JOB_CODE"].ToString(),
                    FFM_CRG_JOB_NAME = dr["FFM_CRG_JOB_NAME"].ToString(),
                    INCOME_ACT= dr["INCOME_ACT"].ToString(),
                    EXPENSE_ACGT = dr["EXPENSE_ACT"].ToString(),

                });
            }
            return ObjList;
        }

        public List<ComDropTbl> GetPortList(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("FFM_PORT_CODE as [Code],NAME as [CodeName]", "FFM_PORT", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (FFM_PORT_CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }

        public List<ComDropTbl1> GetCust(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop1("A.FNM_SL1001_CODE CUSTOMER_CODE,A.Name CUSTOMER_NAME,B.COA_CODE CONTROL_ACT", "FNM_SL1001 A INNER JOIN  FNM_SL1002 B ON A.FNM_SL1001_CODE = B.FNM_SL1001_CODE and  b.CMPYCODE=a.CMPYCODE and A.Flag=B.Flag", "B.FNM_SL1002_CODE='ARP' and B.CMPYCODE='" + CmpyCode + "' and A.Flag=0 and (A.FNM_SL1001_CODE like '" + Prefix + "%' or A.Name like '" + Prefix + "%')");
        }

        public List<ComDropTbl1> GetVendor(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop1("A.FNM_SL1001_CODE CUSTOMER_CODE,A.Name CUSTOMER_NAME,B.COA_CODE CONTROL_ACT", "FNM_SL1001 A INNER JOIN  FNM_SL1002 B ON A.FNM_SL1001_CODE = B.FNM_SL1001_CODE and  b.CMPYCODE=a.CMPYCODE and A.Flag=B.Flag", "B.FNM_SL1002_CODE='APP' and B.CMPYCODE='" + CmpyCode + "' and A.Flag=0 and (A.FNM_SL1001_CODE like '" + Prefix + "%' or A.Name like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetCurcode(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("CURRENCY_CODE as [Code],CURRENCY_NAME as [CodeName]", "FNM_CURRENCY", " Flag=0 and (CURRENCY_CODE like '" + Prefix + "%' or CURRENCY_NAME like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetUnitcode(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("FFM_UNIT_CODE as [Code],NAME as [CodeName]", "FFM_UNIT", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (FFM_UNIT_CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetCommodityistList(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("FFM_COM_CODE as [Code],NAME as [CodeName]", "FFM_COM", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (FFM_COM_CODE like '" + Prefix + "%' or NAME like '" + Prefix + "%')");
        }
        public decimal GetCurRate(string CmpyCode, string CurCode)
        {
            string qur = "Select a.SELL_RATE from FNM_CURR_RATE a " +
                         " right join  (select max(ENTRY_DATE) as [ENTRY_DATE], FROM_CURRENCY_CODE, CMPYCODE from FNM_CURR_RATE group by FROM_CURRENCY_CODE, CMPYCODE ) as [FRMCUR]  on FRMCUR.FROM_CURRENCY_CODE = a.FROM_CURRENCY_CODE and FRMCUR.CMPYCODE = a.CMPYCODE and FRMCUR.ENTRY_DATE = a.ENTRY_DATE " +
                        " where a.CMPYCODE = '" + CmpyCode + "' and a.flag = 0 and a.FROM_CURRENCY_CODE = '" + CurCode + "'";
            decimal GetCurRate = _EzBusinessHelper.ExecuteScalarDec(qur);
            return GetCurRate;
        }

        public List<ComDropTbl> GetBranchListN(string CmpyCode, string Prefix)
        {
            return drop.GetCommonDrop("Branchcode as [Code],DESCRIPTION as [CodeName]", "FNMBRANCH", "CMPYCODE='" + CmpyCode + "' and Flag=0 and (Branchcode like '" + Prefix + "%' or DESCRIPTION like '" + Prefix + "%')");
        }

        public List<ComDropTbl> GetCurCodebranch(string CmpyCode, string BranchCode)
        {
            return drop.GetCommonDrop2("Select a.SELL_RATE as [CodeName], a.FROM_CURRENCY_CODE as [Code] from FNM_CURR_RATE a " +
            " right join  (select max(ENTRY_DATE) as [ENTRY_DATE], FROM_CURRENCY_CODE, CMPYCODE from FNM_CURR_RATE group by FROM_CURRENCY_CODE, CMPYCODE) as [FRMCUR]  on FRMCUR.FROM_CURRENCY_CODE = a.FROM_CURRENCY_CODE and FRMCUR.CMPYCODE = a.CMPYCODE and FRMCUR.ENTRY_DATE = a.ENTRY_DATE "+
             " where a.CMPYCODE = '"+ CmpyCode + "' and a.flag = 0 and a.FROM_CURRENCY_CODE = (select CURRENCY from FNMBRANCH where CMPYCODE = '"+ CmpyCode +"' and Branchcode = '"+BranchCode+"' )");
        }

        public bool Aprrove_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName, string Typ, string BranchCode)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FF_QTN001 where  FF_QTN001_CODE='" + FF_QTN001_CODE + "'  and Flag=0 and Branchcode = '" + BranchCode + "'");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {
                if (Typ == "Approve")
                {
                    _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Approve FF_QTN_CODE", FF_QTN001_CODE, Environment.MachineName);
                    return _EzBusinessHelper.ExecuteNonQuery1("update FF_QTN001 set ApprovalYN='Y' where  FF_QTN001_CODE='" + FF_QTN001_CODE + "'  and Flag=0 and Branchcode = '" + BranchCode + "'");//CMPYCODE='" + CmpyCode + "' and

                }else
                {
                    _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Reject FF_QTN_CODE", FF_QTN001_CODE, Environment.MachineName);
                    return _EzBusinessHelper.ExecuteNonQuery1("update FF_QTN001 set RejetedYN='Y' where  FF_QTN001_CODE='" + FF_QTN001_CODE + "'  and Flag=0 and Branchcode = '" + BranchCode + "'");//CMPYCODE='" + CmpyCode + "' and

                }

            }
            return false;
        }

        public List<ComDropTbl> GetApproveRej(string CmpyCode, string BranchCode, string FF_QTN001_CODE)
        {
            return drop.GetCommonDrop("ApprovalYN as [Code],RejetedYN as [CodeName]", "FF_QTN001", "CMPYCODE='" + CmpyCode + "' and Flag=0 and FF_QTN001_CODE='"+ FF_QTN001_CODE+ "' ");
        }
    }
}
