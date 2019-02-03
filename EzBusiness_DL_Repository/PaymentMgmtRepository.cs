using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FinaceMgmt;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EzBusiness_DL_Repository
{
    public class PaymentMgmtRepository : IPaymentMgmtRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public bool DeletePayment(string Code, string CmpyCode, string username)
        {
            int Payment = _EzBusinessHelper.ExecuteScalar("Select count(*) from PaymentTerms where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
            if (Payment != 0)
            {

                _EzBusinessHelper.ActivityLog(CmpyCode, username, "Delete PaymentTerms", Code, Environment.MachineName);

                return _EzBusinessHelper.ExecuteNonQuery1("delete from PaymentTerms where CmpyCode='" + CmpyCode + "' and Code='" + Code + "'");
               // return true;
            }
            return false;
        }

        public List<PaymentTerms> GetPayment(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PaymentTerms where CmpyCode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<PaymentTerms> ObjList = new List<PaymentTerms>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new PaymentTerms()
                {
                    Cmpycode = dr["CmpyCode"].ToString(),
                    Code = dr["Code"].ToString(),
                    Name = dr["Name"].ToString(),
                    NoOfDays = Convert.ToDecimal(dr["NoOfDays"])
                    


                });

            }
            return ObjList;
        }

        public PaymentTermVM SavePayment(PaymentTermVM Payment)
        {
            try
            {
                if (!Payment.EditFlag)
                {
                    ds = _EzBusinessHelper.ExecuteDataSet("Select count(*) as [count1] from PaymentTerms where CmpyCode='" + Payment.CmpyCode + "' and Code='" + Payment.Code + "'");
                    dt = ds.Tables[0];


                    int Payment1 = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        Payment1 = int.Parse(dr["count1"].ToString());
                    }

                    if (Payment1 == 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("'" + Payment.CmpyCode + "',");
                        sb.Append("'" + Payment.Code + "',");
                        sb.Append("'" + Payment.Name + "',");
                        sb.Append("'" + Payment.NoOfDays + "')");
                        _EzBusinessHelper.ExecuteNonQuery("insert into PaymentTerms(CmpyCode,Code,Name,NoOfDays) values(" + sb.ToString() + "");

                        _EzBusinessHelper.ActivityLog(Payment.CmpyCode, Payment.UserName, "Add Payment", Payment.Code, Environment.MachineName);

                        Payment.SaveFlag = true;
                        Payment.ErrorMessage = string.Empty;
                    }
                    else
                    {
                        Payment.SaveFlag = false;
                        Payment.ErrorMessage = "Duplicate Record";
                    }
                    return Payment;
                }
                var PaymentEdit = _EzBusinessHelper.ExecuteNonQuery("Select * from PaymentTerms where CmpyCode='" + Payment.CmpyCode + "' and Code='" + Payment.Code + "'");
                if (PaymentEdit != 0)
                {
                    _EzBusinessHelper.ExecuteNonQuery("update PaymentTerms set CmpyCode='" + Payment.CmpyCode + "',Code='" + Payment.Code + "',Name='" + Payment.Name + "',NoOfDays='" + Payment.NoOfDays + "' where CmpyCode='" + Payment.CmpyCode + "' and Code='" + Payment.Code + "'");

                    _EzBusinessHelper.ActivityLog(Payment.CmpyCode, Payment.UserName, "Update Payment", Payment.Code, Environment.MachineName);

                    Payment.SaveFlag = true;
                    Payment.ErrorMessage = string.Empty;
                }
                else
                {
                    Payment.SaveFlag = false;
                    Payment.ErrorMessage = "Record not available";
                }

            }
            catch
            {
                Payment.SaveFlag = false;
                //  unit.ErrorMessage = exceptionMessage;

            }

            return Payment;
        }
    }
}
