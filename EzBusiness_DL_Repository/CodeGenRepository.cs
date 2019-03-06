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
using System.Globalization;

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

        public string GetCountry(string Cmpycode, string Empcode)
        {
            return _EzBusinessHelper.ExecuteScalarS("select Nationality from MEM001 where EmpCode='"+ Empcode +"' and Flag =0 and Cmpycode='" + Cmpycode + "' ");
        }

        public string GetCountryP(string Cmpycode, DateTime dt1)
        {
            return _EzBusinessHelper.ExecuteScalarS("select COUNTRY from PRCNF001 where FINYEARS='"+ dt1.ToString("yyyy") + "' and FINMONTH='" + dt1.ToString("MM") + "' and  Flag=0 and Cmpycode='" + Cmpycode + "' ");
        }

        public string GetDiv(string Cmpycode, string Empcode)
        {
            return _EzBusinessHelper.ExecuteScalarS("select DivisionCode from MEM001 where EmpCode='" + Empcode + "' and Flag =0 and Cmpycode='" + Cmpycode + "' ");
        }

        public bool GetSalaryLast(string CmpyCode, string Empcode, DateTime dtmonthyy, string InpAmt)
        {
            //return _EzBusinessHelper.ExecuteScalarDec("select a.TOTAL from PRSMS001 a where a.CMPYCODE ='"+ CmpyCode +"' and a.Effect_From <='"+  dtmonthyy +"' and a.EMPCODE='"+ Empcode + "' and a.Flag=0 and Effect_From =(select max(b.Effect_From) from PRSMS001 b where b.CMPYCODE =a.CMPYCODE and b.EMPCODE=a.EMPCODE and b.Effect_From <=a.Effect_From and a.Flag=b.Flag)");

            string[] Emp = Empcode.Split(',');

            string[] InpAmts = InpAmt.Split(',');
            int n = 0;
            int i = 0;
           
            foreach (string Emps in Emp)
            {
                
                if (Emps != "")
                {
                    n = 0;
                    string Monthyy = dtmonthyy.ToString("MM-yyyy");
                    //decimal k = _EzBusinessHelper.ExecuteScalarDec("select a.TOTAL from PRSMS001 a where a.CMPYCODE ='" + CmpyCode + "' and a.Effect_From <='" + dtmonthyy + "' and a.EMPCODE='" + Emps + "' and a.Flag=0 and Effect_From =(select max(b.Effect_From) from PRSMS001 b where b.CMPYCODE =a.CMPYCODE and b.EMPCODE=a.EMPCODE and b.Effect_From <=a.Effect_From and a.Flag=b.Flag)");
                    SqlParameter[] param = {new SqlParameter("@cmpyCode", CmpyCode),
                        new SqlParameter("@currDate", dtmonthyy),
            new SqlParameter("@EmpCode",Emps)};
                    decimal k = _EzBusinessHelper.ExecuteScalarDec("usp_ChecksalaryData", param);
                    decimal t = Convert.ToDecimal(InpAmts[i]);
                    if (k > t)
                    {
                        n = 1;
                    }
                }
                i++;
            }
            if (n == 1)
            {
                return true;
            }
            return false;
        }

        public bool GetSalaryProcess(string CmpyCode, string Empcode, DateTime dtmonthyy)
        {
            string[] Emp = Empcode.Split(',');
            int n = 0;
            foreach(string Emps in Emp)
            {
                if(Emps!="")
                {
                    n = 0;
                    string Monthyy = dtmonthyy.ToString("MM-yyyy");
                    int k = _EzBusinessHelper.ExecuteScalar("select count(*) from PRSPD001 where flag=0 and EmpCode='" + Emps + "'  and CmpyCode='" + CmpyCode + "' and FORMAT(Dates,'MM-yyyy') = '" + Monthyy + "'");
                    if (k == 0)
                    {
                        n = 1;
                    }
                }                              
            }
            if(n==1)
            {
                return true;
            }
            return false;

        }


    }
}
