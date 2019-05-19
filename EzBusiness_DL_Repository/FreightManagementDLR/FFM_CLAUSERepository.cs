using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Repository.FreightManagementDLR
{
  public  class FFM_CLAUSERepository: IFFM_CLAUSERepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteFFM_CLAUSE(string FFM_CLAUSE_CODE, string CmpyCode, string UserName)
        {
            int Grs = _EzBusinessHelper.ExecuteScalar("Select count(*) from FFM_CLAUSE where  FFM_CLAUSE_CODE='" + FFM_CLAUSE_CODE + "' and cmpycode='"+ CmpyCode + "'  and Flag=0");// CMPYCODE='" + CmpyCode + "' and
            if (Grs != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete FFM_CLAUSE", FFM_CLAUSE_CODE, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update FFM_CLAUSE set Flag=1 where  FFM_CLAUSE_CODE='" + FFM_CLAUSE_CODE + "' and cmpycode='" + CmpyCode + "'   and Flag=0");//CMPYCODE='" + CmpyCode + "' and

            }
            return false;
        }

        public FFM_CLAUSE_VM EditFFM_CLAUSE(string CmpyCode, string FFM_CLAUSE_CODE)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_CLAUSE_CODE,NAME from FFM_CLAUSE where FFM_CLAUSE_CODE='" + FFM_CLAUSE_CODE + "' and Flag=0");// CMPYCODE='" + CmpyCode + "' and 
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            FFM_CLAUSE_VM ObjList = new FFM_CLAUSE_VM();
            foreach (DataRow dr in drc)
            {

                ObjList.FFM_CLAUSE_CODE = dr["FFM_CLAUSE_CODE"].ToString();
                ObjList.NAME = dr["NAME"].ToString();
            }
            return ObjList;
        }

        public List<FFM_CLAUSE> GetFFM_CLAUSE(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select FFM_CLAUSE_CODE,NAME from FFM_CLAUSE where Flag=0");//  CMPYCODE='" + CmpyCode + "' and
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<FFM_CLAUSE> ObjList = new List<FFM_CLAUSE>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new FFM_CLAUSE()
                {
                    FFM_CLAUSE_CODE = dr["FFM_CLAUSE_CODE"].ToString(),
                    NAME = dr["NAME"].ToString(),


                });
            }
            return ObjList;
        }

        public FFM_CLAUSE_VM SaveFFM_CLAUSE(FFM_CLAUSE_VM FCur)
        {
            try
            {

                DateTime dte;
                string dtstr1;
                dte = Convert.ToDateTime(DateTime.Now.ToString());
                dtstr1 = dte.ToString("yyyy-MM-dd hh:mm:ss tt");

                if (!FCur.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<FFM_CLAUSE_NewDetails> ObjList = new List<FFM_CLAUSE_NewDetails>();
                    ObjList.AddRange(FCur.FFM_CLAUSE_Detail.Select(m => new FFM_CLAUSE_NewDetails
                    {
                        FFM_CLAUSE_CODE = m.FFM_CLAUSE_CODE,
                        NAME = m.NAME,
                        CMPYCODE = m.CMPYCODE,
                        //UserName=m.UserName,
                        //MASTER_STATUS = m.MASTER_STATUS
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;
                    while (n > 0)
                    {
                        int Stats1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from FFM_CLAUSE where FFM_CLAUSE_CODE='" + ObjList[n - 1].FFM_CLAUSE_CODE + "' and  CmpyCode='" + ObjList[n - 1].CMPYCODE + "' and flag=0");// CmpyCode='" + FCur.CMPYCODE + "' and
                        if (Stats1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();

                            sb.Append("'" + ObjList[n - 1].FFM_CLAUSE_CODE + "',");

                            sb.Append("'" + ObjList[n - 1].NAME + "',");
                            sb.Append("'" + FCur.CMPYCODE + "',");

                            sb.Append("'" + FCur.UserName + "',");
                            sb.Append("'" + dtstr1 + "',");
                            //sb.Append("'" + FCur.UserName + "',");
                            sb.Append("'" + FCur.UserName + "',");
                            sb.Append("'" + dtstr1 + "')");

                            int i = _EzBusinessHelper.ExecuteNonQuery("insert into FFM_CLAUSE(FFM_CLAUSE_CODE,NAME,CMPYCODE,CREATED_BY,CREATED_ON,UPDATED_BY,UPDATED_ON) values(" + sb.ToString() + "");
                            _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Add FFM CNTR", ObjList[n - 1].FFM_CLAUSE_CODE, Environment.MachineName);
                            FCur.SaveFlag = true;
                            FCur.ErrorMessage = string.Empty;
                        }
                        else
                        {
                            Drecord.Add(FCur.FFM_CLAUSE_CODE.ToString());
                            //  branch.Drecord = Drecord;
                            FCur.SaveFlag = false;
                            FCur.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    return FCur;
                }
                var StatsEdit = _EzBusinessHelper.ExecuteScalarDec("Select count(*) from FFM_CLAUSE where FFM_CLAUSE_CODE='" + FCur.FFM_CLAUSE_CODE + "' and  cmpycode='" + FCur.CMPYCODE + "' and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and 
                if (StatsEdit != 0)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("FFM_CLAUSE_CODE='" + FCur.FFM_CLAUSE_CODE + "',");
                    sb.Append("NAME='" + FCur.NAME + "',");
                    //sb.Append("MASTER_STATUS='" + FCur.MASTER_STATUS + "',");
                    //sb.Append("Note='" + FCur.Note + "',");
                    sb.Append("UPDATED_BY='" + FCur.UserName + "',");
                    sb.Append("UPDATED_ON='" + dtstr1 + "'");

                    _EzBusinessHelper.ExecuteNonQuery("update FFM_CLAUSE set  " + sb + " where  FFM_CLAUSE_CODE='" + FCur.FFM_CLAUSE_CODE + "' and  cmpycode='" + FCur.CMPYCODE + " and Flag=0");//CmpyCode='" + FCur.CMPYCODE + "' and

                    _EzBusinessHelper.ActivityLog(FCur.CMPYCODE, FCur.UserName, "Update Currency", FCur.FFM_CLAUSE_CODE, Environment.MachineName);

                    FCur.SaveFlag = true;
                    FCur.ErrorMessage = string.Empty;
                }
                else
                {
                    FCur.SaveFlag = false;
                    FCur.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                FCur.SaveFlag = false;


            }

            return FCur;
        }
    }
}
