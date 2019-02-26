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
    public class VisaLocationPayrollRepository : IVisaLocationPayrollRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public bool DeleteVls(string Code, string CmpyCode, string UserName)
        {
            int Vls = _EzBusinessHelper.ExecuteScalar("Select count(*) from VLOC001 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "' and Flag=0");
            int EmpV = _EzBusinessHelper.ExecuteScalar("select count(*)  from MEM001 where VisaLocation='" + Code + "' and cmpycode='" + CmpyCode + "' and Flag=0 ");
            if (Vls != 0 && EmpV==0)
            {
                _EzBusinessHelper.ActivityLog(CmpyCode, UserName, "Delete Visa Location", Code, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("update VLOC001 set Flag=1 where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
                //return true;
            }
            return false;
        }

        public List<VisaLocation> GetVls(string CmpyCode)
         {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from VLOC001 where CmpyCode='" + CmpyCode + "'and Flag=0");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<VisaLocation> ObjList = new List<VisaLocation>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new VisaLocation()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),                
                    CompanyMolID = dr["CompanyMolID"].ToString(),

                });

            }
            return ObjList;
        }

        public VisaLocationVM SaveVls(VisaLocationVM Vls)
        {
            try
            {
                if (!Vls.EditFlag)
                {
                    var Drecord = new List<string>();
                    List<VisaLocNew> ObjList = new List<VisaLocNew>();
                    ObjList.AddRange(Vls.VisaLocNew.Select(m => new VisaLocNew
                    {
                        CmpyCode = m.CmpyCode,
                        Code = m.Code,
                        Name = m.Name,                      
                        CompanyMolID = m.CompanyMolID
                        
                    }).ToList());
                    int n = 0;
                    n = ObjList.Count;

                    while (n > 0)
                    {
                        int Bbs1 = _EzBusinessHelper.ExecuteScalar("Select count(*) as [count1] from VLOC001 where CmpyCode='" + Vls.CmpyCode + "' and Code='" + ObjList[n - 1].Code + "'");
                        if (Bbs1 == 0)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("'" + Vls.CmpyCode + "',");
                            sb.Append("'" + ObjList[n - 1].Code + "',");
                            sb.Append("'" + ObjList[n - 1].Name + "',");
                            sb.Append("'" +""+"',");
                            sb.Append("'" + ObjList[n - 1].CompanyMolID + "')");

                            using (TransactionScope scope1 = new TransactionScope())
                            {
                               int i= _EzBusinessHelper.ExecuteNonQuery("insert into VLOC001(CmpyCode,Code,Name,UniCodeName,CompanyMolID) values(" + sb.ToString() + "");
                                _EzBusinessHelper.ActivityLog(Vls.CmpyCode, Vls.UserName, "Add Visa Location Master", Vls.Code, Environment.MachineName);
                                if(i>0)
                                {
                                    scope1.Complete();
                                    Vls.SaveFlag = true;
                                    Vls.ErrorMessage = string.Empty;
                                }
                               
                            }
                           
                        }
                        else
                        {

                            Drecord.Add(ObjList[n - 1].Code.ToString());
                            Vls.Drecord = Drecord;
                            Vls.SaveFlag = false;
                            Vls.ErrorMessage = "Duplicate Record";
                        }
                        n = n - 1;
                    }
                    
                    return Vls;
                }
                var VlsEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from VLOC001 where CmpyCode='" +  Vls.CmpyCode + "' and Code='" + Vls.Code + "'");
                if (VlsEdit != 0)
                {

                    using (TransactionScope scope = new TransactionScope())
                    {
                        Vls.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("update VLOC001 set CmpyCode='" + Vls.CmpyCode + "',Code='" + Vls.Code + "',Name='" + Vls.Name + "',CompanyMolID='" + Vls.CompanyMolID + "' where CmpyCode='" + Vls.CmpyCode + "' and Code='" + Vls.Code + "'");

                        _EzBusinessHelper.ActivityLog(Vls.CmpyCode, Vls.UserName, "Update Visa Location Master", Vls.Code, Environment.MachineName);
                        // Vls.SaveFlag = true;
                        scope.Complete();
                    }
                    Vls.ErrorMessage = string.Empty;
                }
                else
                {
                    Vls.SaveFlag = false;
                    Vls.ErrorMessage = "Record not available";
                }

            }
            catch (Exception ex)
            {
                Vls.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Vls;
        }
    }
}
