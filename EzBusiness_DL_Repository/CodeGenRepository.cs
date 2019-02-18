using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace EzBusiness_DL_Repository
{
    public class CodeGenRepository : ICodeGenRepository
    {
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        public string GetCode(string CmpyCode, string LocCode)
        {
            SqlParameter[] param1 = {
                        new SqlParameter("@LocCode",LocCode),
                        new SqlParameter("@Cmpycode",CmpyCode)
                       };
            string GetCode = _EzBusinessHelper.ExecuteScalarS("Sp_codeGen", param1);
            return GetCode;
        }

        public decimal GetSalaryLast(string CmpyCode, string Empcode, DateTime dtmonthyy)
        {
            return _EzBusinessHelper.ExecuteScalarDec("select a.TOTAL from PRSMS001 a where a.CMPYCODE ='"+ CmpyCode +"' and a.Effect_From <='"+  dtmonthyy +"' and a.EMPCODE='"+ Empcode + "' and a.Flag=0 and Effect_From =(select max(b.Effect_From) from PRSMS001 b where b.CMPYCODE =a.CMPYCODE and b.EMPCODE=a.EMPCODE and b.Effect_From <=a.Effect_From and a.Flag=b.Flag)");
        }

        public bool GetSalaryProcess(string CmpyCode, string Empcode, DateTime dtmonthyy)
        {
            string Monthyy = dtmonthyy.ToString("MM-yyyy");
           int k= _EzBusinessHelper.ExecuteScalar("select count(*) from PRSPD001 where flag=0 and EmpCode='" +  Empcode + "'  and CmpyCode='"+ CmpyCode +"' and FORMAT(Dates,'MM-yyyy') = '" + Monthyy + "'");
            if (k == 0){
                return true;
            }
            return false;
        }


    }
}
