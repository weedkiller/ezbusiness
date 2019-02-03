using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using System.Data;
using System.Data.SqlClient;

using System.Configuration;


namespace EzBusiness_DL_Repository
{
    public class CommonFun
    {
        //DataSet ds = null;
        //DataTable dt = null;
        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();

        public DateTime GetJoingDate(string CmpyCode,string EmpCode)
        {
            DateTime? JoiningDte = null;
              JoiningDte = _EzBusinessHelper.ExecuteScalarDte("Select JoiningDate from MEM001 where empcode='" + CmpyCode + "' and cmpycode='" + EmpCode + "' ");
            return JoiningDte.Value;
        }
    }
}
