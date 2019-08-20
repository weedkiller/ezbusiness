using EzBusiness_DL_Interface.FinanceManagementDLI.Vouchers;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EzBusiness_DL_Repository.FinanceManagementDLR.Vouchers
{
  public  class CreditNoteJobRepository : ICreditNoteJobRepository
    {
        DataSet ds = null;
        DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        DropListFillFun drop = new DropListFillFun();

        public bool DeleteFNINV(string CmpyCode, string FNINV001_CODE, string UserName, string BRANCHCODE)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FNINV001 where BRANCHCODE='" + BRANCHCODE + "' and  FNINV001_CODE='" + FNINV001_CODE + "'  and Flag=0");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FNINV001_CODE", FNINV001_CODE, Environment.MachineName);

                _EzBusinessHelper.ExecuteNonQuery1("update FNINV002 set Flag=1 where BRANCHCODE='" + BRANCHCODE + "' and INV001_CODE='" + FNINV001_CODE + "'  and Flag=0");

                return _EzBusinessHelper.ExecuteNonQuery1("update FNINV001 set Flag=1 where BRANCHCODE='" + BRANCHCODE + "' and FNINV001_CODE='" + FNINV001_CODE + "'  and Flag=0");//CMPYCODE='" + CmpyCode + "' and

            }
            return false;
        }

        public List<FNINV001_VM> GetFNINV(string CmpyCode, string Branchcode, string Module_Type)
        {

            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNINV001 where Flag=0  and CMPYCODE='" + CmpyCode + "' and BRANCHCODE='" + Branchcode + "' and INV_TYPE='" + Module_Type + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNINV001_VM> ObjList = new List<FNINV001_VM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNINV001_VM()
                {
                    FNINV001_CODE = dr["FNINV001_CODE"].ToString(),
                    cmpycode = dr["cmpycode"].ToString(),
                    BRANCHCODE = dr["BRANCHCODE"].ToString(),
                    Post_Date = Convert.ToDateTime(dr["Post_Date"].ToString()),
                    NOTES = dr["NOTES"].ToString(),
                    NARRATION = dr["NARRATION"].ToString(),
                    CREATED_BY = dr["CREATED_BY"].ToString(),
                    CREATED_ON = Convert.ToDateTime(dr["CREATED_ON"].ToString()),
                    UPDATED_BY = dr["UPDATED_BY"].ToString(),
                    UPDATED_ON = Convert.ToDateTime(dr["UPDATED_ON"].ToString()),
                    COA_CODE = dr["COA_CODE"].ToString(),
                    SUBLEDGER_CODE = dr["SUBLEDGER_CODE"].ToString(),
                    CURRENCY_CODE = dr["CURRENCY_CODE"].ToString(),
                    CURRENCY_RATE = Convert.ToDecimal(dr["CURRENCY_RATE"].ToString()),
                    BILLING_ADDRESS = dr["BILLING_ADDRESS"].ToString(),
                    //SUPPLIER_JV_NO = dr["SUPPLIER_JV_NO"].ToString(),

                    //SUPPLIER_JV_DATE = Convert.ToDateTime(dr["SUPPLIER_JV_DATE"].ToString()),
                    //SUPPLIER_GRN_NO = dr["SUPPLIER_GRN_NO"].ToString(),
                    RECEIVED_PAID_NAME = dr["RECEIVED_PAID_NAME"].ToString(),
                    UNPOSTED_NOTE = dr["UNPOSTED_NOTE"].ToString(),

                    //Customer_COA = dr["COA_CODE"].ToString(),
                    Received_By = dr["Received_By"].ToString(),
                    SalesMan = dr["SalesMan"].ToString(),
                    LOCATION_CODE = dr["LOCATION_CODE"].ToString(),
                    vessel_code = dr["vessel_code"].ToString(),
                    BL_CODE = dr["BL_CODE"].ToString(),
                    BL_REF_NO = dr["BL_REF_NO"].ToString(),
                    POL = dr["POL"].ToString(),
                    POD = dr["POD"].ToString(),
                    VAT_LOCAL_AMT = Convert.ToDecimal(dr["VAT_LOCAL_AMT"].ToString()),
                    VAT_CURRENCY_AMT = Convert.ToDecimal(dr["VAT_CURRENCY_AMT"].ToString()),
                    INV_DATE = Convert.ToDateTime(dr["INV_DATE"].ToString()),
                    INV_STATUS = dr["INV_STATUS"].ToString(),
                    INV_TYPE = dr["INV_TYPE"].ToString(),
                    Type_Choose=dr["Type_Choose"].ToString()
                    //CURRENCY_AMT = Convert.ToDecimal(dr["CURRENCY_AMT"].ToString()),
                    //LOCAL_AMT = Convert.ToDecimal(dr["LOCAL_AMT"].ToString()),
                    //NET_CURRENCY_AMT = Convert.ToDecimal(dr["NET_CURRENCY_AMT"].ToString()),
                    //NET_LOCAL_AMT = Convert.ToDecimal(dr["NET_LOCAL_AMT"].ToString()),

                });

            }
            return ObjList;

        }

        public List<FNINV002New> GetFNINV002DetailList(string CmpyCode, string FNINV001_CODE, string BRANCHCODE)
        {
            string qur = "";


            qur = "Select LINE_NO,O_CHARGE_UID,ITEMCODE,Item_Description,UNIT_TYPE,NO_OF_QTY,RATE_PER_QTY,COA_CODE,SUBLEDGER_CODE,Location_Code,O_CURR_CODE,O_CURR_RATE,O_CURR_AMT,O_LOCAL_AMT,O_VAT_LOCAL_AMT,O_VAT_CURR_AMT,VAT_CODE,VAT_PER,VAT_GL_CODE,V_CURR_AMT,V_LOCAL_AMT,V_VAT_CURR_AMT,V_VAT_LOCAL_AMT,V_NET_CURR_AMT,V_NET_LOCAL_AMT,Narration,NOTE,Ret_Qty,Cost_per_qty from FNINV002 where Flag=0 and INV001_CODE='" + FNINV001_CODE + "' and CMPYCODE='" + CmpyCode + "' and BRANCHCODE='" + BRANCHCODE + "'";


            ds = _EzBusinessHelper.ExecuteDataSet(qur);// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FNINV002New> ObjList = new List<FNINV002New>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FNINV002New()
                {

                    //cmpycode = dr["cmpycode"].ToString(),
                    //BRANCHCODE = dr["BRANCHCODE"].ToString(),
                    //INV001_CODE = dr["INV001_CODE"].ToString(),
                    LINE_NO = Convert.ToDecimal(dr["LINE_NO"].ToString()),
                    ITEMCODE = dr["ITEMCODE"].ToString(),
                    O_CHARGE_UID = Convert.ToInt16(dr["O_CHARGE_UID"].ToString()),
                    UNIT_TYPE = dr["UNIT_TYPE"].ToString(),
                    Item_Description = dr["Item_Description"].ToString(),
                    O_VAT_CURR_AMT = Convert.ToDecimal(dr["O_VAT_CURR_AMT"].ToString()),
                    VAT_GL_CODE = dr["VAT_GL_CODE"].ToString(),
                    NO_OF_QTY = Convert.ToDecimal(dr["NO_OF_QTY"].ToString()),
                    RATE_PER_QTY = Convert.ToDecimal(dr["RATE_PER_QTY"].ToString()),
                    COA_CODE = dr["COA_CODE"].ToString(),
                    SUBLEDGER_CODE = dr["SUBLEDGER_CODE"].ToString(),
                    Location_Code = dr["Location_Code"].ToString(),
                    O_CURR_CODE = dr["O_CURR_CODE"].ToString(),
                    O_CURR_RATE = Convert.ToDecimal(dr["O_CURR_RATE"].ToString()),
                    O_CURR_AMT = Convert.ToDecimal(dr["O_CURR_AMT"].ToString()),
                    O_LOCAL_AMT = Convert.ToDecimal(dr["O_LOCAL_AMT"].ToString()),
                    O_VAT_LOCAL_AMT = Convert.ToDecimal(dr["O_VAT_LOCAL_AMT"].ToString()),
                    VAT_CODE = dr["VAT_CODE"].ToString(),
                    VAT_PER = Convert.ToDecimal(dr["VAT_PER"].ToString()),
                    V_CURR_AMT = Convert.ToDecimal(dr["V_CURR_AMT"].ToString()),
                    V_LOCAL_AMT = Convert.ToDecimal(dr["V_LOCAL_AMT"].ToString()),
                    V_VAT_CURR_AMT = Convert.ToDecimal(dr["V_VAT_CURR_AMT"].ToString()),
                    V_VAT_LOCAL_AMT = Convert.ToDecimal(dr["V_VAT_LOCAL_AMT"].ToString()),
                    V_NET_CURR_AMT = Convert.ToDecimal(dr["V_NET_CURR_AMT"].ToString()),
                    V_NET_LOCAL_AMT = Convert.ToDecimal(dr["V_NET_LOCAL_AMT"].ToString()),
                    Narration = dr["Narration"].ToString(),
                    NOTE = dr["NOTE"].ToString(),
                    //Ret_Qty =Convert.ToDecimal(dr["Ret_Qty"].ToString()),
                    //Cost_per_qty=Convert.ToDecimal(dr["Cost_per_qty"].ToString()),


                });
            }
            return ObjList;
        }

        public FNINV001_VM GetFNINVDetailsBL(string CmpyCode, string FF_BL001_CODE, string Branchcode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FF_BL001 where Flag=0 and FF_BL001_CODE='" + FF_BL001_CODE + "' and CMPYCODE='" + CmpyCode + "' and Branchcode='" + Branchcode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FNINV001_VM ObjList = new FNINV001_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.POD = dr["POD"].ToString();
                ObjList.POL = dr["POL"].ToString();





                ObjList.SalesMan = dr["Salesman"].ToString();

                ObjList.BRANCHCODE = dr["Branchcode"].ToString();
            }
            return ObjList;
        }

        public FNINV001_VM GetFNINVDetailsEdit(string CmpyCode, string FNINV001_CODE, string Branchcode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNINV001 where Flag=0 and FNINV001_CODE='" + FNINV001_CODE + "' and CMPYCODE='" + CmpyCode + "' and BRANCHCODE='" + Branchcode + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FNINV001_VM ObjList = new FNINV001_VM();
            foreach (DataRow dr in drc)
            {
                ObjList.FNINV001_CODE = dr["FNINV001_CODE"].ToString();
                ObjList.cmpycode = dr["cmpycode"].ToString();
                ObjList.BRANCHCODE = dr["BRANCHCODE"].ToString();

                ObjList.Post_Date = Convert.ToDateTime(dr["Post_Date"].ToString());
                ObjList.NOTES = dr["NOTES"].ToString();
                ObjList.NARRATION = dr["NARRATION"].ToString();
                ObjList.CREATED_BY = dr["CREATED_BY"].ToString();
                ObjList.CREATED_ON = Convert.ToDateTime(dr["CREATED_ON"].ToString());
                ObjList.UPDATED_BY = dr["UPDATED_BY"].ToString();
                ObjList.UPDATED_ON = Convert.ToDateTime(dr["UPDATED_ON"].ToString());
                ObjList.COA_CODE = dr["COA_CODE"].ToString();
                ObjList.SUBLEDGER_CODE = dr["SUBLEDGER_CODE"].ToString();
                ObjList.CURRENCY_CODE = dr["CURRENCY_CODE"].ToString();
                ObjList.CURRENCY_RATE = Convert.ToDecimal(dr["CURRENCY_RATE"].ToString());

                ObjList.BILLING_ADDRESS = dr["BILLING_ADDRESS"].ToString();
                ObjList.SUPPLIER_JV_NO = dr["SUPPLIER_JV_NO"].ToString();
                //ObjList.SUPPLIER_JV_DATE =Convert.ToDateTime(dr["SUPPLIER_JV_DATE"].ToString());

                if (String.IsNullOrEmpty(dr["SUPPLIER_JV_DATE"].ToString()))
                {
                    ObjList.SUPPLIER_JV_DATE = System.DateTime.Today;
                }
                else
                {
                    ObjList.SUPPLIER_JV_DATE = Convert.ToDateTime(dr["SUPPLIER_JV_DATE"].ToString());
                }

                ObjList.SUPPLIER_GRN_NO = dr["SUPPLIER_GRN_NO"].ToString();
                ObjList.RECEIVED_PAID_NAME = dr["RECEIVED_PAID_NAME"].ToString();
                ObjList.UNPOSTED_NOTE = dr["UNPOSTED_NOTE"].ToString();

                ObjList.Customer_COA = dr["COA_CODE"].ToString();
                ObjList.Received_By = dr["Received_By"].ToString();
                ObjList.SalesMan = dr["SalesMan"].ToString();
                ObjList.LOCATION_CODE = dr["LOCATION_CODE"].ToString();
                ObjList.vessel_code = dr["vessel_code"].ToString();
                ObjList.BL_CODE = dr["BL_CODE"].ToString();
                ObjList.BL_REF_NO = dr["BL_REF_NO"].ToString();
                ObjList.POL = dr["POL"].ToString();
                ObjList.POD = dr["POD"].ToString();
                ObjList.VAT_LOCAL_AMT = Convert.ToDecimal(dr["VAT_LOCAL_AMT"].ToString());
                ObjList.VAT_CURRENCY_AMT = Convert.ToDecimal(dr["VAT_CURRENCY_AMT"].ToString());
                ObjList.INV_DATE = Convert.ToDateTime(dr["INV_DATE"].ToString());
                ObjList.INV_STATUS = dr["INV_STATUS"].ToString();
                ObjList.INV_TYPE = dr["INV_TYPE"].ToString();
                ObjList.CURRENCY_AMT = Convert.ToDecimal(dr["CURRENCY_AMT"].ToString());
                ObjList.LOCAL_AMT = Convert.ToDecimal(dr["LOCAL_AMT"].ToString());
                ObjList.NET_CURRENCY_AMT = Convert.ToDecimal(dr["NET_CURRENCY_AMT"].ToString());
                ObjList.NET_LOCAL_AMT = Convert.ToDecimal(dr["NET_LOCAL_AMT"].ToString());

                ObjList.Type_Choose = dr["Type_Choose"].ToString();
            }
            return ObjList;
        }


        public FNINV001_VM SaveFNINV_VM(FNINV001_VM FNINV)
        {
            DateTime dte;
            string dtstr1, dtstr2, dtstr3, dtstr4;
            dte = Convert.ToDateTime(DateTime.Now.ToString());
            dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(FNINV.SUPPLIER_JV_DATE);
            dtstr2 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(FNINV.Post_Date);
            dtstr3 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");
            dte = Convert.ToDateTime(FNINV.INV_DATE);
            dtstr4 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

            if (!FNINV.EditFlag)
            {
                try
                {
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        #region FNINV002
                        List<FNINV002> ObjList = new List<FNINV002>();
                        if (FNINV.FNINV002Detail != null)
                        {
                            ObjList.AddRange(FNINV.FNINV002Detail.Select(m => new FNINV002
                            {
                                BRANCHCODE = m.BRANCHCODE,
                                COA_CODE = m.COA_CODE,
                                cmpycode = m.cmpycode,
                                Cost_per_qty = m.Cost_per_qty,
                                INV001_CODE = m.INV001_CODE,
                                ITEMCODE = m.ITEMCODE,
                                Item_Description = m.Item_Description,
                                O_VAT_CURR_AMT = m.O_VAT_CURR_AMT,
                                VAT_GL_CODE = m.VAT_GL_CODE,
                                LINE_NO = m.LINE_NO,
                                Location_Code = m.Location_Code,
                                Narration = m.Narration,
                                NOTE = m.NOTE,
                                NO_OF_QTY = m.NO_OF_QTY,
                                O_CHARGE_UID = m.O_CHARGE_UID,
                                O_CURR_AMT = m.O_CURR_AMT,
                                O_CURR_CODE = m.O_CURR_CODE,
                                O_CURR_RATE = m.O_CURR_RATE,
                                O_LOCAL_AMT = m.O_LOCAL_AMT,
                                O_VAT_LOCAL_AMT = m.O_VAT_LOCAL_AMT,
                                RATE_PER_QTY = m.RATE_PER_QTY,
                                Ret_Qty = m.Ret_Qty,
                                SUBLEDGER_CODE = m.SUBLEDGER_CODE,
                                UNIT_TYPE = m.UNIT_TYPE,
                                VAT_CODE = m.VAT_CODE,
                                VAT_PER = m.VAT_PER,
                                V_CURR_AMT = m.V_CURR_AMT,
                                V_LOCAL_AMT = m.V_LOCAL_AMT,
                                V_NET_CURR_AMT = m.V_NET_CURR_AMT,
                                V_NET_LOCAL_AMT = m.V_NET_LOCAL_AMT,
                                V_VAT_CURR_AMT = m.V_VAT_CURR_AMT,
                                V_VAT_LOCAL_AMT = m.V_VAT_LOCAL_AMT,


                            }).ToList());
                        }

                        #endregion
                        //---
                        int n, i = 0;

                        #region FNINV002 INSERT LOOP
                        n = ObjList.Count;
                        while (n > 0)
                        {

                            int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FNINV002 where INV001_CODE='" + FNINV.FNINV001_CODE + "' and  CmpyCode='" + FNINV.cmpycode + "' and flag=0 and O_CHARGE_UID='" + ObjList[n - 1].O_CHARGE_UID + "'");// CmpyCode='" + FQV.CMPYCODE + "' and
                            if (Stats1 == 0)
                            {
                                StringBuilder sb5 = new StringBuilder();

                                sb5.Append("'" + FNINV.cmpycode + "',");
                                sb5.Append("'" + FNINV.BRANCHCODE + "',");
                                sb5.Append("'" + FNINV.FNINV001_CODE + "',");
                                sb5.Append("'" + n + "',");
                                sb5.Append("'" + ObjList[n - 1].O_CHARGE_UID + "',");
                                sb5.Append("'" + ObjList[n - 1].ITEMCODE + "',");
                                sb5.Append("'" + ObjList[n - 1].Item_Description + "',");
                                sb5.Append("'" + ObjList[n - 1].UNIT_TYPE + "',");
                                sb5.Append("'" + ObjList[n - 1].NO_OF_QTY + "',");
                                sb5.Append("'" + ObjList[n - 1].RATE_PER_QTY + "',");
                                sb5.Append("'" + ObjList[n - 1].COA_CODE + "',");
                                sb5.Append("'" + FNINV.SUBLEDGER_CODE + "',");
                                sb5.Append("'" + ObjList[n - 1].Location_Code + "',");
                                sb5.Append("'" + ObjList[n - 1].O_CURR_CODE + "',");
                                sb5.Append("'" + ObjList[n - 1].O_CURR_RATE + "',");
                                sb5.Append("'" + ObjList[n - 1].O_CURR_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].O_LOCAL_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].O_VAT_LOCAL_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].O_VAT_CURR_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].VAT_CODE + "',");
                                sb5.Append("'" + ObjList[n - 1].VAT_PER + "',");
                                sb5.Append("'" + ObjList[n - 1].VAT_GL_CODE + "',");
                                sb5.Append("'" + ObjList[n - 1].V_CURR_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].V_LOCAL_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].V_VAT_CURR_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].V_VAT_LOCAL_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].V_NET_CURR_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].V_NET_LOCAL_AMT + "',");
                                sb5.Append("'" + ObjList[n - 1].Narration + "',");
                                sb5.Append("'" + ObjList[n - 1].NOTE + "',");
                                sb5.Append("'" + ObjList[n - 1].Ret_Qty + "',");
                                sb5.Append("'" + ObjList[n - 1].Cost_per_qty + "')");


                                i = _EzBusinessHelper.ExecuteNonQuery("insert into FNINV002(cmpycode,BRANCHCODE,INV001_CODE,LINE_NO,O_CHARGE_UID,ITEMCODE,Item_Description,UNIT_TYPE,NO_OF_QTY,RATE_PER_QTY,COA_CODE,SUBLEDGER_CODE,Location_Code,O_CURR_CODE,O_CURR_RATE,O_CURR_AMT,O_LOCAL_AMT,O_VAT_LOCAL_AMT,O_VAT_CURR_AMT,VAT_CODE,VAT_PER,VAT_GL_CODE,V_CURR_AMT,V_LOCAL_AMT,V_VAT_CURR_AMT,V_VAT_LOCAL_AMT,V_NET_CURR_AMT,V_NET_LOCAL_AMT,Narration,NOTE,Ret_Qty,Cost_per_qty) values(" + sb5.ToString() + "");
                                //_EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Add FFM Charge", ObjList[n - 1].FF_BL001_CODE, Environment.MachineName);

                            }

                            n = n - 1;
                        }
                        #endregion

                        #region FNINV002 INSERT Header
                        //if (i > 0)
                        //{
                        StringBuilder sb4 = new StringBuilder();

                        sb4.Append("'" + FNINV.FNINV001_CODE + "',");
                        sb4.Append("'" + FNINV.cmpycode + "',");
                        sb4.Append("'" + FNINV.BRANCHCODE + "',");
                        sb4.Append("'" + FNINV.INV_TYPE + "',");
                        sb4.Append("'" + FNINV.INV_STATUS + "',");
                        sb4.Append("'" + dtstr4 + "',");
                        sb4.Append("'" + dtstr3 + "',");
                        sb4.Append("'" + FNINV.NOTES + "',");
                        sb4.Append("'" + FNINV.NARRATION + "',");
                        sb4.Append("'" + FNINV.CREATED_BY + "',");
                        sb4.Append("'" + dtstr1 + "',");
                        sb4.Append("'" + FNINV.UPDATED_BY + "',");
                        sb4.Append("'" + dtstr1 + "',");
                        sb4.Append("'" + FNINV.COA_CODE + "',");
                        sb4.Append("'" + FNINV.SUBLEDGER_CODE + "',");
                        sb4.Append("'" + FNINV.CURRENCY_CODE + "',");
                        sb4.Append("'" + FNINV.CURRENCY_RATE + "',");
                        sb4.Append("'" + FNINV.VAT_CURRENCY_AMT + "',");
                        sb4.Append("'" + FNINV.VAT_LOCAL_AMT + "',");
                        sb4.Append("'" + FNINV.CURRENCY_AMT + "',");
                        sb4.Append("'" + FNINV.LOCAL_AMT + "',");
                        sb4.Append("'" + FNINV.NET_CURRENCY_AMT + "',");
                        sb4.Append("'" + FNINV.NET_LOCAL_AMT + "',");
                        sb4.Append("'" + FNINV.BILLING_ADDRESS + "',");
                        sb4.Append("'" + FNINV.SUPPLIER_JV_NO + "',");
                        sb4.Append("'" + dtstr2 + "',");
                        sb4.Append("'" + FNINV.SUPPLIER_GRN_NO + "',");
                        sb4.Append("'" + FNINV.RECEIVED_PAID_NAME + "',");
                        sb4.Append("'" + FNINV.UNPOSTED_NOTE + "',");
                        sb4.Append("'" + FNINV.Received_By + "',");
                        sb4.Append("'" + FNINV.SalesMan + "',");
                        sb4.Append("'" + FNINV.LOCATION_CODE + "',");
                        sb4.Append("'" + FNINV.vessel_code + "',");
                        sb4.Append("'" + FNINV.BL_CODE + "',");
                        sb4.Append("'" + FNINV.BL_REF_NO + "',");
                        sb4.Append("'" + FNINV.POL + "',");
                        sb4.Append("'" + FNINV.Type_Choose + "',");
                        sb4.Append("'" + FNINV.POD + "')");
                        i = _EzBusinessHelper.ExecuteNonQuery("insert into FNINV001(FNINV001_CODE,cmpycode,BRANCHCODE,INV_TYPE,INV_STATUS,INV_DATE,Post_Date,NOTES,NARRATION,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON,COA_CODE,SUBLEDGER_CODE,CURRENCY_CODE,CURRENCY_RATE,VAT_CURRENCY_AMT,VAT_LOCAL_AMT,CURRENCY_AMT,LOCAL_AMT,NET_CURRENCY_AMT,NET_LOCAL_AMT,BILLING_ADDRESS,SUPPLIER_JV_NO,SUPPLIER_JV_DATE,SUPPLIER_GRN_NO,RECEIVED_PAID_NAME,UNPOSTED_NOTE,Received_By,SalesMan,LOCATION_CODE,vessel_code,BL_CODE,BL_REF_NO,POL,Type_Choose,POD) values(" + sb4.ToString() + "");

                        #endregion

                        _EzBusinessHelper.ActivityLog(FNINV.cmpycode, FNINV.UserName, "Update FF BL", FNINV.FNINV001_CODE, Environment.MachineName);
                        FNINV.SaveFlag = true;
                        FNINV.ErrorMessage = string.Empty;
                        scope1.Complete();
                        //}
                        return FNINV;
                    }
                }
                catch (Exception ex)
                {
                    FNINV.SaveFlag = false;
                }
            }
            else
            {
                try
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select * from FNINV001 where CmpyCode='" + FNINV.cmpycode + "' and FNINV001_CODE='" + FNINV.FNINV001_CODE + "'");
                    using (TransactionScope scope1 = new TransactionScope())
                    {
                        FNINV001 FQT1 = new FNINV001();
                        dt = ds.Tables[0];
                        foreach (DataRow dr in dt.Rows)
                        {
                            FQT1.FNINV001_CODE = FNINV.FNINV001_CODE;
                            FQT1.cmpycode = FNINV.cmpycode;
                            FQT1.BRANCHCODE = FNINV.BRANCHCODE;
                            FQT1.INV_TYPE = FNINV.INV_TYPE;
                            FQT1.INV_STATUS = FNINV.INV_STATUS;
                            FQT1.INV_DATE = FNINV.INV_DATE;
                            FQT1.Post_Date = FNINV.Post_Date;
                            FQT1.NOTES = FNINV.NOTES;
                            FQT1.NARRATION = FNINV.NARRATION;
                            FQT1.CREATED_BY = FNINV.CREATED_BY;
                            FQT1.CREATED_ON = FNINV.CREATED_ON;
                            FQT1.UPDATED_BY = FNINV.UPDATED_BY;
                            FQT1.UPDATED_ON = FNINV.UPDATED_ON;
                            FQT1.COA_CODE = FNINV.COA_CODE;
                            FQT1.SUBLEDGER_CODE = FNINV.SUBLEDGER_CODE;
                            FQT1.CURRENCY_CODE = FNINV.CURRENCY_CODE;
                            FQT1.CURRENCY_RATE = FNINV.CURRENCY_RATE;
                            FQT1.VAT_CURRENCY_AMT = FNINV.VAT_CURRENCY_AMT;
                            FQT1.VAT_LOCAL_AMT = FNINV.VAT_LOCAL_AMT;
                            FQT1.CURRENCY_AMT = FNINV.CURRENCY_AMT;
                            FQT1.LOCAL_AMT = FNINV.LOCAL_AMT;
                            FQT1.NET_CURRENCY_AMT = FNINV.NET_CURRENCY_AMT;
                            FQT1.NET_LOCAL_AMT = FNINV.NET_LOCAL_AMT;
                            FQT1.BILLING_ADDRESS = FNINV.BILLING_ADDRESS;
                            FQT1.SUPPLIER_JV_NO = FNINV.SUPPLIER_JV_NO;
                            FQT1.Type_Choose = FNINV.Type_Choose;


                            _EzBusinessHelper.ExecuteNonQuery("delete from FNINV002 where CmpyCode='" + FNINV.cmpycode + "' and INV001_CODE='" + FNINV.FNINV001_CODE + "' AND BRANCHCODE ='" + FNINV.BRANCHCODE + "'");

                            // #region ObjectList
                            #region FNINV002
                            List<FNINV002> ObjList = new List<FNINV002>();
                            if (FNINV.FNINV002Detail != null)
                            {
                                ObjList.AddRange(FNINV.FNINV002Detail.Select(m => new FNINV002
                                {
                                    BRANCHCODE = m.BRANCHCODE,
                                    COA_CODE = m.COA_CODE,
                                    cmpycode = m.cmpycode,
                                    Cost_per_qty = m.Cost_per_qty,
                                    INV001_CODE = m.INV001_CODE,
                                    ITEMCODE = m.ITEMCODE,
                                    Item_Description = m.Item_Description,
                                    O_VAT_CURR_AMT = m.O_VAT_CURR_AMT,
                                    VAT_GL_CODE = m.VAT_GL_CODE,
                                    LINE_NO = m.LINE_NO,
                                    Location_Code = m.Location_Code,
                                    Narration = m.Narration,
                                    NOTE = m.NOTE,
                                    NO_OF_QTY = m.NO_OF_QTY,
                                    O_CHARGE_UID = m.O_CHARGE_UID,
                                    O_CURR_AMT = m.O_CURR_AMT,
                                    O_CURR_CODE = m.O_CURR_CODE,
                                    O_CURR_RATE = m.O_CURR_RATE,
                                    O_LOCAL_AMT = m.O_LOCAL_AMT,
                                    O_VAT_LOCAL_AMT = m.O_VAT_LOCAL_AMT,
                                    RATE_PER_QTY = m.RATE_PER_QTY,
                                    Ret_Qty = m.Ret_Qty,
                                    SUBLEDGER_CODE = m.SUBLEDGER_CODE,
                                    UNIT_TYPE = m.UNIT_TYPE,
                                    VAT_CODE = m.VAT_CODE,
                                    VAT_PER = m.VAT_PER,
                                    V_CURR_AMT = m.V_CURR_AMT,
                                    V_LOCAL_AMT = m.V_LOCAL_AMT,
                                    V_NET_CURR_AMT = m.V_NET_CURR_AMT,
                                    V_NET_LOCAL_AMT = m.V_NET_LOCAL_AMT,
                                    V_VAT_CURR_AMT = m.V_VAT_CURR_AMT,
                                    V_VAT_LOCAL_AMT = m.V_VAT_LOCAL_AMT

                                }).ToList());
                            }

                            #endregion
                            //---
                            int n, i = 0;

                            #region FNINV002 INSERT LOOP
                            n = ObjList.Count;
                            while (n > 0)
                            {

                                int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from  FNINV002 where INV001_CODE='" + FNINV.FNINV001_CODE + "' and  CmpyCode='" + FNINV.cmpycode + "' and flag=0 AND BRANCHCODE ='" + FNINV.BRANCHCODE + "' and O_CHARGE_UID='" + ObjList[n - 1].O_CHARGE_UID + "'");// CmpyCode='" + FQV.CMPYCODE + "' and
                                if (Stats1 == 0)
                                {
                                    StringBuilder sb5 = new StringBuilder();

                                    sb5.Append("'" + FNINV.cmpycode + "',");
                                    sb5.Append("'" + FNINV.BRANCHCODE + "',");
                                    sb5.Append("'" + FNINV.FNINV001_CODE + "',");
                                    sb5.Append("'" + n + "',");
                                    sb5.Append("'" + ObjList[n - 1].O_CHARGE_UID + "',");
                                    sb5.Append("'" + ObjList[n - 1].ITEMCODE + "',");
                                    sb5.Append("'" + ObjList[n - 1].Item_Description + "',");
                                    sb5.Append("'" + ObjList[n - 1].UNIT_TYPE + "',");
                                    sb5.Append("'" + ObjList[n - 1].NO_OF_QTY + "',");
                                    sb5.Append("'" + ObjList[n - 1].RATE_PER_QTY + "',");
                                    sb5.Append("'" + ObjList[n - 1].COA_CODE + "',");
                                    sb5.Append("'" + FNINV.SUBLEDGER_CODE + "',");
                                    sb5.Append("'" + ObjList[n - 1].Location_Code + "',");
                                    sb5.Append("'" + ObjList[n - 1].O_CURR_CODE + "',");
                                    sb5.Append("'" + ObjList[n - 1].O_CURR_RATE + "',");
                                    sb5.Append("'" + ObjList[n - 1].O_CURR_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].O_LOCAL_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].O_VAT_LOCAL_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].O_VAT_CURR_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].VAT_CODE + "',");
                                    sb5.Append("'" + ObjList[n - 1].VAT_PER + "',");
                                    sb5.Append("'" + ObjList[n - 1].VAT_GL_CODE + "',");
                                    sb5.Append("'" + ObjList[n - 1].V_CURR_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].V_LOCAL_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].V_VAT_CURR_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].V_VAT_LOCAL_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].V_NET_CURR_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].V_NET_LOCAL_AMT + "',");
                                    sb5.Append("'" + ObjList[n - 1].Narration + "',");
                                    sb5.Append("'" + ObjList[n - 1].NOTE + "',");
                                    sb5.Append("'" + ObjList[n - 1].Ret_Qty + "',");
                                    sb5.Append("'" + ObjList[n - 1].Cost_per_qty + "')");


                                    i = _EzBusinessHelper.ExecuteNonQuery("insert into FNINV002(cmpycode,BRANCHCODE,INV001_CODE,LINE_NO,O_CHARGE_UID,ITEMCODE,Item_Description,UNIT_TYPE,NO_OF_QTY,RATE_PER_QTY,COA_CODE,SUBLEDGER_CODE,Location_Code,O_CURR_CODE,O_CURR_RATE,O_CURR_AMT,O_LOCAL_AMT,O_VAT_LOCAL_AMT,O_VAT_CURR_AMT,VAT_CODE,VAT_PER,VAT_GL_CODE,V_CURR_AMT,V_LOCAL_AMT,V_VAT_CURR_AMT,V_VAT_LOCAL_AMT,V_NET_CURR_AMT,V_NET_LOCAL_AMT,Narration,NOTE,Ret_Qty,Cost_per_qty) values(" + sb5.ToString() + "");
                                    //_EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Add FFM Charge", ObjList[n - 1].FF_BL001_CODE, Environment.MachineName);

                                }

                                n = n - 1;
                            }
                            #endregion



                            #region FF_INV001 Update
                            StringBuilder sb9 = new StringBuilder();

                            sb9.Append("FNINV001_CODE='" + FNINV.FNINV001_CODE + "',");
                            sb9.Append("cmpycode='" + FNINV.cmpycode + "',");
                            sb9.Append("BRANCHCODE='" + FNINV.BRANCHCODE + "',");
                            sb9.Append("INV_TYPE='" + FNINV.INV_TYPE + "',");
                            sb9.Append("INV_STATUS='" + FNINV.INV_STATUS + "',");
                            sb9.Append("INV_DATE='" + dtstr4 + "',");
                            sb9.Append("Post_Date='" + dtstr3 + "',");
                            sb9.Append("NOTES='" + FNINV.NOTES + "',");
                            sb9.Append("NARRATION='" + FNINV.NARRATION + "',");
                            sb9.Append("CREATED_BY='" + FNINV.CREATED_BY + "',");
                            sb9.Append("CREATED_ON='" + dtstr1 + "',");
                            sb9.Append("UPDATED_BY='" + FNINV.UPDATED_BY + "',");
                            sb9.Append("UPDATED_ON='" + dtstr1 + "',");
                            sb9.Append("COA_CODE='" + FNINV.COA_CODE + "',");
                            sb9.Append("SUBLEDGER_CODE='" + FNINV.SUBLEDGER_CODE + "',");
                            sb9.Append("CURRENCY_CODE='" + FNINV.CURRENCY_CODE + "',");
                            sb9.Append("CURRENCY_RATE='" + FNINV.CURRENCY_RATE + "',");
                            sb9.Append("VAT_CURRENCY_AMT='" + FNINV.VAT_CURRENCY_AMT + "',");
                            sb9.Append("VAT_LOCAL_AMT='" + FNINV.VAT_LOCAL_AMT + "',");
                            sb9.Append("CURRENCY_AMT='" + FNINV.CURRENCY_AMT + "',");
                            sb9.Append("LOCAL_AMT='" + FNINV.LOCAL_AMT + "',");
                            sb9.Append("NET_CURRENCY_AMT='" + FNINV.NET_CURRENCY_AMT + "',");
                            sb9.Append("NET_LOCAL_AMT='" + FNINV.NET_LOCAL_AMT + "',");
                            sb9.Append("BILLING_ADDRESS='" + FNINV.BILLING_ADDRESS + "',");
                            sb9.Append("SUPPLIER_JV_NO='" + FNINV.SUPPLIER_JV_NO + "',");
                            sb9.Append("SUPPLIER_JV_DATE='" + dtstr2 + "',");
                            sb9.Append("SUPPLIER_GRN_NO='" + FNINV.SUPPLIER_GRN_NO + "',");
                            sb9.Append("RECEIVED_PAID_NAME='" + FNINV.RECEIVED_PAID_NAME + "',");
                            sb9.Append("UNPOSTED_NOTE='" + FNINV.UNPOSTED_NOTE + "',");
                            sb9.Append("Received_By='" + FNINV.Received_By + "',");
                            sb9.Append("SalesMan='" + FNINV.SalesMan + "',");
                            sb9.Append("LOCATION_CODE='" + FNINV.LOCATION_CODE + "',");
                            sb9.Append("vessel_code='" + FNINV.vessel_code + "',");
                            sb9.Append("BL_CODE='" + FNINV.BL_CODE + "',");
                            sb9.Append("BL_REF_NO='" + FNINV.BL_REF_NO + "',");
                            sb9.Append("POL='" + FNINV.POL + "',");
                            sb9.Append("POD='" + FNINV.POD + "'");
                            sb9.Append("Type_Choose='" + FNINV.Type_Choose + "'");

                            _EzBusinessHelper.ExecuteNonQuery("update FNINV001 set  " + sb9 + " where  FNINV001_CODE='" + FNINV.FNINV001_CODE + "' and  BRANCHCODE='" + FNINV.BRANCHCODE + "' and  cmpycode='" + FNINV.cmpycode + "' and Flag=0");//CmpyCode='" + FQV.CMPYCODE + "' and                         
                                                                                                                                                                                                                                                  // _EzBusinessHelper.ActivityLog(FQV.CMPYCODE, FQV.UserName, "Add FFM Voyage", ObjList[n - 1].FFM_VOYAGE01_CODE, Environment.MachineName);
                            #endregion

                            _EzBusinessHelper.ActivityLog(FNINV.cmpycode, FNINV.UserName, "Update FF FNINV001", FNINV.FNINV001_CODE, Environment.MachineName);
                        }

                        FNINV.ErrorMessage = string.Empty;
                        FNINV.SaveFlag = true;
                        scope1.Complete();
                    }
                }
                catch (Exception ex)
                {

                    FNINV.ErrorMessage = "Error occur";
                    FNINV.SaveFlag = false;

                }
            }

            return FNINV;
        }

       
        public List<ComDropTbl> GETBLNO(string CmpyCode, string Branchcode, string Customercode, string Module_Type,string Type_Choose)
        {

            SqlParameter[] param = { new SqlParameter("@CMPYCODE", CmpyCode),
                                    new SqlParameter("@Branchcode", Branchcode),
                                    new SqlParameter("@Customer_code", Customercode),
                                    new SqlParameter("@Module_Type", Module_Type)
                                    };

            if (Type_Choose == "Invoice")
            {
                ds = _EzBusinessHelper.ExecuteDataSet("Sp_FillInvoiceCode", CommandType.StoredProcedure, param);
            }else
            {
                ds = _EzBusinessHelper.ExecuteDataSet("Sp_FillBLCodeCrDr", CommandType.StoredProcedure, param);
            }
                       
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ComDropTbl> ObjList = new List<ComDropTbl>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ComDropTbl()
                {
                    CodeName = dr["CodeName"].ToString(),
                    Code = dr["Code"].ToString(),

                });
            }
            return ObjList;
        }

       

        public bool Bl_InvoiceGenerateLates(string CmpyCode, string Branchcode, string BLCode, string Customer_code, string ExCode, string ExRate, string Table_Name, string Module_Type, string UserName)
        {
            SqlParameter[] param = {    new SqlParameter("@Cmpycode", CmpyCode),
                                        new SqlParameter("@BranchCode", Branchcode),
                                        new SqlParameter("@BLCode", BLCode),
                                        new SqlParameter("@Customer_code", Customer_code),
                                        new SqlParameter("@ExCode", ExCode),
                                        new SqlParameter("@ExRate", ExRate),
                                        new SqlParameter("@Table_Name", Table_Name),
                                        new SqlParameter("@Module_Type", Module_Type),
                                        new SqlParameter("@loginid", UserName),
                                    };
            return _EzBusinessHelper.ExecuteNonQuery("BILL_CrDrGenerateLates", param);

        }

        public FNINV001 GetHeaderDetail(string CmpyCode, string FNINV001_CODE, string BRANCHCODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select SalesMan,vessel_code,POL,POD,SUPPLIER_JV_NO from FNINV001 where Flag=0 and FNINV001_CODE='" + FNINV001_CODE + "' and CMPYCODE='" + CmpyCode + "' and BRANCHCODE='" + BRANCHCODE + "'");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FNINV001 ObjList = new FNINV001();
            foreach (DataRow dr in drc)
            {
                ObjList.SUPPLIER_JV_NO = dr["SUPPLIER_JV_NO"].ToString();

                //ObjList.SUPPLIER_GRN_NO = dr["SUPPLIER_GRN_NO"].ToString();

                ObjList.SalesMan = dr["SalesMan"].ToString();

                ObjList.vessel_code = dr["vessel_code"].ToString();

                ObjList.POL = dr["POL"].ToString();
                ObjList.POD = dr["POD"].ToString();

            }
            return ObjList;
        }

        public List<ComDropTbl> GetCustSupp(string CmpyCode, string Branchcode, string Module_Type,string Type_Choose, string Prefix)
        {


            SqlParameter[] param = { new SqlParameter("@CMPYCODE", CmpyCode),
                                    new SqlParameter("@Branchcode", Branchcode),
                                    new SqlParameter("@Module_Type", Module_Type),
                                     new SqlParameter("@Prefix", Prefix),
                                    };

            if (Type_Choose == "Invoice")
            {
                ds = _EzBusinessHelper.ExecuteDataSet("SP_FillCustCodeCrDrInv", CommandType.StoredProcedure, param);
            }else
            {
                ds = _EzBusinessHelper.ExecuteDataSet("SP_FillCustCodeCrDr", CommandType.StoredProcedure, param);
            }
               
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<ComDropTbl> ObjList = new List<ComDropTbl>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new ComDropTbl()
                {
                    CodeName = dr["CodeName"].ToString(),
                    Code = dr["Code"].ToString(),

                });
            }
            return ObjList;
        }

        public bool BlCrdr_InvoiceGenerateLates(string CmpyCode, string Branchcode, string InvCode, string Table_Name, string Module_Type, string InvModule_Type, string UserName)
        {
            SqlParameter[] param = {    new SqlParameter("@Cmpycode", CmpyCode),
                                        new SqlParameter("@BranchCode", Branchcode),
                                        new SqlParameter("@InvCode", InvCode),                                       
                                        new SqlParameter("@Table_Name", Table_Name),
                                        new SqlParameter("@Module_Type", Module_Type),
                                        new SqlParameter("@InvModule_Type",InvModule_Type),
                                        new SqlParameter("@loginid", UserName),                                                                               
                                    };
            return _EzBusinessHelper.ExecuteNonQuery("Invoice_CrDrGenerateLates", param);
        }
    }
}
