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
    }
}
