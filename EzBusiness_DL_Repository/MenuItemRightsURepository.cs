using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MenuItem;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Repository
{
   public  class MenuItemRightsURepository : IMenuItemRightsURepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public List<MenuItemRUVM> GetUsers(string CmpyCode, string userid)
        {
            SqlParameter[] param = { new SqlParameter("@cmpycode", CmpyCode), new SqlParameter("@username",userid) };
            //ds = _EzBusinessHelper.ExecuteDataSet("Select * from users where CmpyCode='" + CmpyCode + "' ");
            ds = _EzBusinessHelper.ExecuteDataSet("viewusers_sp", CommandType.StoredProcedure, param);

            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MenuItemRUVM> ObjList = new List<MenuItemRUVM>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MenuItemRUVM()
                {
                    user_name = dr["user_name"].ToString(),
                    EmpCode = dr["EmpCode"].ToString(), 
                    Utype=dr["Utype"].ToString()               
                });
            }
            return ObjList;
        }

        public MenuItemRUVM SaveUsers(MenuItemRUVM Users)
        {
            int n;

            if (!Users.EditFlag)
            {
                users pt = new users();
                
                List<UserRights> ObjList = new List<UserRights>();
                ObjList.AddRange(Users.UserRightsnews.Select(m => new UserRights
                {

                   FormId=m.FormId,
                   FormName=m.FormName,
                   PostIt=m.PostIt,
                   SelAll=m.SelAll,
                   NewIt=m.NewIt,
                   DeleteIt=m.DeleteIt,
                   EditIt=m.EditIt,
                   ViewIt=m.ViewIt
                                      
                }).ToList());

                Users.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("insert into users(CmpyCode,user_name,passwords,EmpCode,Utype) values('" + Users.CmpyCode + "','" + Users.user_name + "','" + Users.passwords + "','" + Users.EmpCode + "','" + Users.Utype + "')");
                n = ObjList.Count;


                while (n > 0 && Users.SaveFlag == true)
                {
                    _EzBusinessHelper.ExecuteNonQuery("insert into UserRights(CmpyCode,user_name,FormId,FormName,PostIt,SelAll,NewIt,DeleteIt,EditIt,ViewIt) values('" + Users.CmpyCode + "','" + Users.user_name + "','" + ObjList[n - 1].FormId + "','" + ObjList[n - 1].FormName + "','" + ObjList[n - 1].PostIt + "','" + ObjList[n - 1].SelAll + "','" + ObjList[n - 1].NewIt + "','" + ObjList[n - 1].DeleteIt + "','" + ObjList[n - 1].EditIt + "','" + ObjList[n - 1].ViewIt+"')");
                    n = n - 1;
                }

                _EzBusinessHelper.ActivityLog(Users.CmpyCode, Users.UserName, "Add User Rights", Environment.MachineName, Users.user_name);
               

                Users.SaveFlag = true;
                Users.ErrorMessage = string.Empty;
            }
            else
            {
                int k = 0;
                k = _EzBusinessHelper.ExecuteScalar("Select count(*) from users where CmpyCode='" + Users.CmpyCode + "' and user_name='" + Users.user_name + "'");
                n = _EzBusinessHelper.ExecuteScalar("Select count(*) from UserRights where CmpyCode='" + Users.CmpyCode + "' and user_name='" + Users.user_name + "' ");

                if (n != 0 && k != 0)
                {


                    _EzBusinessHelper.ExecuteNonQuery("delete from users where CmpyCode='" + Users.CmpyCode + "' and user_name='" + Users.user_name + "'");
                    _EzBusinessHelper.ExecuteNonQuery("delete from UserRights where CmpyCode='" + Users.CmpyCode + "' and user_name='" + Users.user_name + "'");

                    users pt = new users();
                    List<UserRights> ObjList = new List<UserRights>();
                    ObjList.AddRange(Users.UserRightsnews.Select(m => new UserRights
                    {
                        FormId = m.FormId,
                        FormName = m.FormName,
                        PostIt = m.PostIt,
                        SelAll = m.SelAll,
                        NewIt = m.NewIt,
                        DeleteIt = m.DeleteIt,
                        EditIt = m.EditIt,
                        ViewIt = m.ViewIt

                    }).ToList());

                    Users.SaveFlag = _EzBusinessHelper.ExecuteNonQuery1("insert into users(CmpyCode,user_name,passwords,EmpCode,Utype) values('" + Users.CmpyCode + "','" + Users.user_name + "','" + Users.passwords + "','" + Users.EmpCode + "','" + Users.Utype + "')");
                    n = ObjList.Count;


                    while (n > 0 && Users.SaveFlag == true)
                    {
                        _EzBusinessHelper.ExecuteNonQuery("insert into UserRights(CmpyCode,user_name,FormId,FormName,PostIt,SelAll,NewIt,DeleteIt,EditIt,ViewIt) values('" + Users.CmpyCode + "','" + Users.user_name + "','" + ObjList[n - 1].FormId + "','" + ObjList[n - 1].FormName + "','" + ObjList[n - 1].PostIt + "','" + ObjList[n - 1].SelAll + "','" + ObjList[n - 1].NewIt + "','" + ObjList[n - 1].DeleteIt + "','" + ObjList[n - 1].EditIt + "','" + ObjList[n - 1].ViewIt + "')");
                        n = n - 1;
                    }

                    _EzBusinessHelper.ActivityLog(Users.CmpyCode, Users.user_name, "Update User Rights",  Users.UserName,Environment.MachineName);
                    

                    Users.SaveFlag = true;
                    Users.ErrorMessage = string.Empty;

                }
                else
                {
                    Users.SaveFlag = true;
                    Users.ErrorMessage = "Error occur";
                }



            }

            return Users;
        }

        public List<Employee> GetEmpCodes(string CmpyCode,string typ)
        {
            return drop.GetEmpCodes(CmpyCode, typ);
        }

        public List<UserRights> GetUsersRights(string CmpyCode, string username,string typ)
        {
            string qur;
            
                qur = "Select * from UserRights where CmpyCode = '" + CmpyCode + "' and user_name = '" + username + "'";
            
          
            ds = _EzBusinessHelper.ExecuteDataSet(qur);
            
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<UserRights> ObjList = new List<UserRights>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new UserRights()
                {
                    FormId = dr["FormId"].ToString(),
                    FormName = dr["FormName"].ToString(),
                    SelAll = Convert.ToInt32(dr["SelAll"].ToString()),
                    NewIt = Convert.ToInt32(dr["NewIt"].ToString()),
                    ViewIt = Convert.ToInt32(dr["ViewIt"].ToString()),
                    EditIt = Convert.ToInt32(dr["EditIt"].ToString()),
                    DeleteIt = Convert.ToInt32(dr["DeleteIt"].ToString()),
                    PrintIt = Convert.ToInt32(dr["PrintIt"].ToString()),
                    Froms = Convert.ToInt32(dr["Froms"].ToString()),
                    PostIt = Convert.ToInt32(dr["PostIt"].ToString()),

                    //ParentFormId=dr["ParentFormId"].ToString(),
                });
            }
            return ObjList;
        }

        public bool DeleteUsers(string CmpyCode,  string username, string user_name)
        {
            int k = _EzBusinessHelper.ExecuteScalar("Select count(*) from users where CmpyCode='" + CmpyCode + "' and user_name='" + username + "'");
            int Bns = _EzBusinessHelper.ExecuteScalar("Select count(*) from UserRights where CmpyCode='" + CmpyCode + "' and user_name='" + username + "'");
            if (Bns != 0 && k != 0)
            {
                _EzBusinessHelper.ExecuteNonQuery("delete from users where CmpyCode='" + CmpyCode + "' and user_name='" + username + "'");
                _EzBusinessHelper.ExecuteNonQuery("delete from UserRights where CmpyCode='" + CmpyCode + "' and user_name='" + username + "'");

                _EzBusinessHelper.ActivityLog(CmpyCode, user_name, "Delete User Rights", username,Environment.MachineName);
                return true;
            }
            return false;
        }

        public MenuItemRUVM GetUsersRightsEdit(string CmpyCode, string user_name)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from Users where CmpyCode='" + CmpyCode + "' and user_name='" + user_name + "' ");

            dt = ds.Tables[0];
            MenuItemRUVM UMenu = new MenuItemRUVM();
            foreach (DataRow dr in dt.Rows)
            {
                UMenu.EmpCode = dr["EmpCode"].ToString();
                UMenu.user_name = dr["user_name"].ToString();
                UMenu.passwords = dr["passwords"].ToString();
                UMenu.Utype = dr["Utype"].ToString();
                
             
            }
            return UMenu;
        }

        public bool GetAuthority(string CmpyCode, string username, string Rpath)
        {
            string qur;
            int t=0;
            qur = "select count(*) from MENUITEMS016 a where a.NavURL = '" + Rpath + "' and a.CmpyCode = '" + CmpyCode + "' and a.FormID  in ( Select formid from UserRights b where b.CmpyCode = a.CmpyCode and b.user_name='" + username + "' )";
            t = _EzBusinessHelper.ExecuteScalar(qur);
            if(t==0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
           
        }

        public List<UserRights> GetUsersRightsAuth(string CmpyCode, string navurl, string userid)
        {
            SqlParameter[] param = { new SqlParameter("@cmpname", CmpyCode),
                                    new SqlParameter("@navurl", navurl),
                                    new SqlParameter("@userid",userid)};

            ds = _EzBusinessHelper.ExecuteDataSet("sp_user_authentication", CommandType.StoredProcedure, param);
            if (ds.Tables.Count != 0)
            {
                dt = ds.Tables[0];
            }
         
            DataRowCollection drc = dt.Rows;
            List<UserRights> ObjList = new List<UserRights>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new UserRights()
                {                   
                    SelAll =Convert.ToInt32(dr["SelAll"].ToString()),
                    NewIt = Convert.ToInt32(dr["NewIt"].ToString()),
                    ViewIt = Convert.ToInt32(dr["ViewIt"].ToString()),
                    EditIt = Convert.ToInt32(dr["EditIt"].ToString()),
                    DeleteIt = Convert.ToInt32(dr["DeleteIt"].ToString()),
                    PrintIt = Convert.ToInt32(dr["PrintIt"].ToString()),
                    Froms = Convert.ToInt32(dr["Froms"].ToString()),
                    PostIt = Convert.ToInt32(dr["PostIt"].ToString()),
                    user_name=dr["user_name"].ToString()
                });
            }
            return ObjList;
        }
    }
}
