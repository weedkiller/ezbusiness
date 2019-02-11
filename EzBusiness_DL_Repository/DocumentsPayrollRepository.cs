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
    public class DocumentsPayrollRepository : IDocumentsPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteDoks(string DocCode, string CmpyCode, string username)
        {
            int Doks = _EzBusinessHelper.ExecuteScalar("Select count(*) from MDOC012 where CmpyCode='" + CmpyCode + "' and DocCode='" + DocCode + "'");
            if (Doks != 0)
            {
                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete Document Master", DocCode, Environment.MachineName);
                return _EzBusinessHelper.ExecuteNonQuery1("update MDOC012 set Flag=1 where CmpyCode='" + CmpyCode + "' and DocCode='" + DocCode + "'");
               // return true;
            }
            return false;

        }

        public List<Documents> GetDoks(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MDOC012 where CmpyCode='"+CmpyCode+"' and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<Documents> ObjList = new List<Documents>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new Documents()
                {
                    Cmpycode = dr["CmpyCode"].ToString(),
                    DocCode = dr["DocCode"].ToString(),
                    DocName = dr["DocName"].ToString(),
                    UniCodeName = dr["UniCodeName"].ToString(),
                });

            }
            return ObjList;
        }

        public DocumentsVM SaveDoks(DocumentsVM Doks)
        {
           
            try
            {
                if (!Doks.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<DocumentsDetailnew> ObjList = new List<DocumentsDetailnew>();
                    ObjList.AddRange(Doks.DocumentsDetailnew.Select(m => new DocumentsDetailnew
                    {
                        CmpyCode = m.CmpyCode,
                       DocCode= m.DocCode,
                        DocName = m.DocName,
                        UniCodeName = m.UniCodeName
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;


                    while (n > 0)
                    {
                        int Doks1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from MDOC012 where CmpyCode='" + Doks.CmpyCode + "' and DocCode='" + ObjList[n - 1].DocCode + "'");
                        if (Doks1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Doks.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].DocCode + "',");
                            sb.Append("'" + ObjList[n - 1].DocName + "',");
                            sb.Append("'" + ObjList[n - 1].UniCodeName + "')");
                            _EzBusinessHelper.ExecuteNonQuery("insert into MDOC012(CmpyCode,DocCode,DocName,UniCodeName) values(" + sb.ToString() + "");
                            Doks.SaveFlag = true;
                            Doks.ErrorMessage = string.Empty;
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].DocCode.ToString());

                            Doks.Drecord = Drecord;
                            Doks.SaveFlag = false;
                            Doks.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }


                    return Doks;
                }
                var DoksEdit = _EzBusinessHelper.ExecuteScalar("Select count(*) from MDOC012 where CmpyCode='" + Doks.CmpyCode + "' and DocCode='" + Doks.DocCode + "'");
                if (DoksEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update MDOC012 set CmpyCode='" + Doks.CmpyCode + "',DocCode='" + Doks.DocCode + "',DocName='" + Doks.DocName + "',UniCodeName='" + Doks.UniCodeName + "' where CmpyCode='" + Doks.CmpyCode + "' and DocCode='" + Doks.DocCode + "'");
                    Doks.SaveFlag = true;
                    Doks.ErrorMessage = string.Empty;
                }
                else
                {
                    Doks.SaveFlag = false;
                    Doks.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Doks.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }
  return Doks;
        }
    }
    }

