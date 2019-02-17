using EzBusiness_DL_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Login;
using System.Web.Security;
using System.Security.Principal;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace EzBusiness_DL_Repository
{
    public class LoginRepository : ILoginRepository
    {

        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun DropListFill = new DropListFillFun();

        public List<Company> GetCompanyList()
        {
            return DropListFill.GetCompCode();
        }
      
        public List<Division> GetDivisionList(string CmpyCode)
        {
            return DropListFill.GetDivCode(CmpyCode);
        }

        public LoginVM Login(LoginVM LoginMaster)
        {

            try
            {
                ds = _EzBusinessHelper.ExecuteDataSet("Select user_name,Utype From Users Where user_name=N'" + LoginMaster.user_name + " 'and passwords=N'" + LoginMaster.PassW + "'");
                dt = ds.Tables[0];
                string Login1="0" ;
                string Utype = "";
                foreach (DataRow dr in dt.Rows)
                {
                    Login1 = dr["user_name"].ToString();
                    Utype = dr["Utype"].ToString();

                    List<SessionListnew> ObjList = new List<SessionListnew>();
                    

                    SessionListnew data = new SessionListnew();
                    data.user_name = Login1;
                    data.Utype = Utype;

                    data.CmpyCode = LoginMaster.CmpyCode.ToString();
                    

                    if (LoginMaster.DivCode != null)
                    {
                        data.Divcode = LoginMaster.DivCode.ToString();
                    }
                    else
                    {
                        data.Divcode = "0";
                    }
                    if (LoginMaster.BraCode != null)
                    {
                        data.BraCode = LoginMaster.BraCode.ToString();
                    }
                    else
                    {
                        data.BraCode = "0";
                    }
                    if (LoginMaster.DepCode != null)
                    {
                        data.DepCode = LoginMaster.DepCode.ToString();
                    }
                    else
                    {
                        data.DepCode = "0";
                    }

                    ObjList.Add(data);


                    HttpContext context = HttpContext.Current;



                    context.Session["SesDet"] = ObjList;

                }
                if (Login1 != "0")
                {

                    LoginMaster.IsLogInFlag = true;

                    LoginMaster.ErrorMessage = "Login Successfull";                   
                }
                else
                {
                    LoginMaster.IsLogInFlag = false;
                    LoginMaster.ErrorMessage = "Incorrect credential";
                }                    
            }
            catch (Exception ex)
            {

                LoginMaster.IsLogInFlag = false;
                LoginMaster.ErrorMessage = "Incorrect credential";
            }

            return LoginMaster;
        }

        public List<BranchTbl> GetBranchList(string CmpyCode, string DivCode)
        {
            return DropListFill.GetBranchCode1(CmpyCode, DivCode);
        }

        public List<Department> GetDepartmentList(string CmpyCode, string DivCode, string BranchCode)
        {
            return DropListFill.GetDepCode(CmpyCode, DivCode, BranchCode);
        }
    }
}
