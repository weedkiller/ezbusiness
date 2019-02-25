using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace EzBusiness_DL_Repository
{
    
    public class EzBusinessHelper
    {
        SqlConnection cn = null;
        string connStr;
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        SqlTransaction trans = null;
        Boolean rowaffected = false;

        DataSet ds = null;
        CommandType commandType;
        string errormsg;
        public EzBusinessHelper()
        {
            try
            {
                connStr = ConfigurationManager.ConnectionStrings["UMNIAHConn"].ToString();
                //using (SqlConnection cn = new SqlConnection())
                //{
                //    cn.Open();
                //}
                //    if (cn.State == ConnectionState.Open)
                //{
                //    cn.Close();
                //}
                //else
                //{
                //    cn.Open();
                   

                //}
            }
            catch (Exception ex)
            {
                errormsg=ex.Message;
            }           
        }
      
        public DataSet ExecuteDataSet(string sqlCommandText)
        {
           
                try
                {
                using (SqlConnection cn = new SqlConnection(connStr))
                {

                    //if (cn.State != ConnectionState.Open)
                    cn.Open();

                    da = new SqlDataAdapter(sqlCommandText, cn);
                    da.SelectCommand.CommandTimeout = 0;
                    ds = new DataSet();
                    da.Fill(ds);
                }
            }
                catch (Exception ex)
                {
                    errormsg = ex.Message;
                }
          
            return ds;
           

        }
        public DataSet ExecuteDataSet(string SqlCommandText,CommandType cmd,SqlParameter[] p)
        {
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                try
                {
                    //if (cn.State != ConnectionState.Open)
                    cn.Open();
                    da = new SqlDataAdapter(SqlCommandText, cn);
                    da.SelectCommand.CommandTimeout = 0;
                    da.SelectCommand.CommandType = cmd;

                    da.SelectCommand.Parameters.AddRange(p);
                    ds = new DataSet();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    errormsg = ex.Message;
                }
            }
           
            return ds;
        }
        public int ExecuteScalar(string sqlCommandText)
        {
            int numrows=0;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                try
                {
                    //if (cn.State != ConnectionState.Open)
                    cn.Open();
                    cmd = new SqlCommand(sqlCommandText, cn);
                    numrows = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    errormsg = ex.Message;
                }
            }
            return numrows;
        }
        public string ExecuteScalarS(string sqlCommandText)
        {
            string numrows="";
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                try
                {
                    //if (cn.State != ConnectionState.Open)
                        cn.Open();
                    cmd = new SqlCommand(sqlCommandText, cn);
                    numrows = (string)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    errormsg = ex.Message;
                }
            }  
            return numrows;

        }
        public DateTime ExecuteScalarDte(string sqlCommandText)
        {
            DateTime? numrows = null;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                try
                {
                    //if (cn.State != ConnectionState.Open)
                    cn.Open();
                    cmd = new SqlCommand(sqlCommandText, cn);
                    numrows = (DateTime)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    errormsg = ex.Message;
                }
            }          
            return numrows.Value;
        }

        public decimal ExecuteScalarDec(string sqlCommandText, SqlParameter[] p)
        {
            decimal numrows = 0;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                cn.Open();
                using (cmd = new SqlCommand(sqlCommandText, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    int k = p.Length;
                    int j = 0;
                    while (j < k)
                    {
                        cmd.Parameters.AddWithValue(p[j].ParameterName, p[j].Value);
                        j = j + 1;
                    }
                    try
                    {
                        object o = cmd.ExecuteScalar();
                        if (o != null)
                        {
                            numrows = Convert.ToDecimal(o.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        errormsg = ex.Message;
                    }
                }
            }
            return numrows;
        }
        public decimal ExecuteScalarDec(string sqlCommandText)
        {
            decimal numrows = 0;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                try
                {
                    //if (cn.State != ConnectionState.Open)
                    cn.Open();
                    cmd = new SqlCommand(sqlCommandText, cn);

                    //(decimal)cmd.ExecuteScalar();

                    object o = cmd.ExecuteScalar();
                    if (o != null)
                    {
                        numrows = Convert.ToDecimal(o.ToString());
                    }
                }
                catch (Exception ex)
                {
                    errormsg = ex.Message;
                }
            }
            return numrows;
        }
        public int ExecuteNonQuery(string SqlCommondText)
        {
          
            int rowaffected = 0;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                try
                {
                    //if (cn.State != ConnectionState.Open)
                        cn.Open();
                    trans = cn.BeginTransaction();
                    cmd = new SqlCommand(SqlCommondText, cn, trans);
                    rowaffected = cmd.ExecuteNonQuery();
                    trans.Commit();
                    cn.Close();
                }
                catch (Exception ex)
                {
                    if (trans != null)
                        trans.Rollback();
                    throw;
                }
            }
            return rowaffected;
        }

        public bool ExecuteNonQuery1(string SqlCommondText)
        {
            string err;
            rowaffected = false;
            using(SqlConnection cn = new SqlConnection(connStr))
            {
                cn.Open(); 
            trans = cn.BeginTransaction();
            using (cmd = new SqlCommand(SqlCommondText, cn, trans))
            {
                try
                {
                    //if (cn.State != ConnectionState.Open)
                    //    cn.Open();
                  
                 //   cmd = new SqlCommand(SqlCommondText, cn, trans);
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                    rowaffected = true;
                    cn.Close();
                }
                catch (Exception ex)
                {
                    rowaffected = false;
                    if (trans != null)
                        trans.Rollback();
                    err = ex.Message;

                }
                finally
                {
                    trans.Dispose();
                   // cmd.Dispose();
                }
            }
            }

            return rowaffected;
        }

        public bool ActivityLog(string cmpycode, string User_Name, string Activity,string Refno, string Machine)
        {
            bool t = false;
            SqlParameter[] param1 = {new SqlParameter("@CmpyCode",cmpycode),
                        new SqlParameter("@User_Name",User_Name),
                        new SqlParameter("@Activity", Activity),
                        new SqlParameter("@RefNo",Refno),
                         new SqlParameter("@Machine",Machine)};

           t= ExecuteNonQuery("usp_ins_userLog", param1);

            return t;
        }
        public string ExecuteScalarS(string sqlCommandText, SqlParameter[] p)
        {            
            string numrows = "";
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                cn.Open();
                using (cmd = new SqlCommand(sqlCommandText, cn))
                    {                       
                        cmd.CommandType = CommandType.StoredProcedure;
                        int k = p.Length;
                        int j = 0;
                        while (j < k)
                        {
                            cmd.Parameters.AddWithValue(p[j].ParameterName, p[j].Value);
                            j = j + 1;
                        }
                    try
                    {
                        numrows = (string)cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        numrows = ex.Message;
                    }
                }                
            }
            return numrows;
        }
        public bool ExecuteNonQuery(string SqlCommondText, SqlParameter[] p)
        {
            string err;
            bool t=false;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                cn.Open();
                trans = cn.BeginTransaction();
                using (cmd = new SqlCommand(SqlCommondText, cn, trans))
                {
                    // cmd.CommandText is a stored procedure name, not a plain text SQL 
                    cmd.CommandType = CommandType.StoredProcedure;
                    int k = p.Length;
                    int j = 0;
                    while (j < k)
                    {
                        try
                        {
                            cmd.Parameters.AddWithValue(p[j].ParameterName, p[j].Value);
                            j = j + 1;
                        }
                        catch(Exception ex)
                        {

                        }
                    }

                    try
                    {
                        //if (cn.State != ConnectionState.Open)
                        //    cn.Open();                        
                       int i= cmd.ExecuteNonQuery();
                       
                      if (i > 0)
                        {
                            trans.Commit();

                            t = true;
                        };
                       // 
                    }
                    
                    catch (Exception ex)
                    {
                        err = ex.Message;
                        trans.Rollback();
                    // cn.Close();
                
                        t = false;
                    }
                    finally
                    {

                   // cmd.Dispose();
                    trans.Dispose();
                        
                    }
                }

            }
            return t;
        }       
    }

}
