using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity.MenuContext;
using EzBusiness_ViewModels.Models.MenuItem;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.Entity;//Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;

namespace EzBusiness_DL_Repository
{
    public class MasterRepository : IMasterRepository

    {


        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();
        public MenuItemsVM AddFrom(MenuItemsVM menuItem)
        {
            throw new NotImplementedException();
        }

        public MenuItemsVM EditFrom(MenuItemsVM menuItem)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> FormsDDLList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MENUITEMS016 where CmpyCode='"+CmpyCode+"' order by Levels ,sno");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MenuItem> ObjList = new List<MenuItem>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MenuItem()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    ManualCode = dr["ManualCode"].ToString(),
                    FormName = dr["FormName"].ToString(),
                    UnicodeName = dr["UnicodeName"].ToString(),
                    ModalForm =Convert.ToInt16(dr["ModalForm"].ToString()),
                    Captions=dr["Captions"].ToString(),
                    AllMasterQuery= dr["AllMasterQuery"].ToString(),
                    Fields= dr["Fields"].ToString(),
                    FormID= dr["FormID"].ToString(),
                    frmName= dr["frmName"].ToString(),
                    FunctionName= dr["FunctionName"].ToString(),
                    Levels= Convert.ToInt16(dr["Levels"].ToString()),
                    TableName= dr["TableName"].ToString(),
                    UserDefined= Convert.ToInt16(dr["UserDefined"].ToString()),
                    CheckRight= Convert.ToInt16(dr["CheckRight"].ToString()),
                    NotForUser = Convert.ToInt16(dr["NotForUser"].ToString()),
                    ParentFormID = dr["ParentFormID"].ToString(),
                    Report = Convert.ToInt16(dr["Report"].ToString()),
                    Show= Convert.ToInt16(dr["Show"].ToString()),
                    ShowType= dr["ShowType"].ToString(),
                    Sno= Convert.ToInt16(dr["Sno"].ToString()),
                    NavURL = dr["NavURL"].ToString()
                });

            }
            return ObjList;
        }

        public List<Employee> GetEmpCodes(string CmpyCode, string typ)
        {
            return drop.GetEmpCodes(CmpyCode,typ);
        }

        public MenuItem GetFormDetails(string CmpyCode, string FormId, string parentFormId)
        {
            throw new NotImplementedException();
        }

        public List<MenuItem> GetMenuData1(string CmpyCode,string user_name,string Urole,string RepYN)
        {
            string cond = "";
            
            if(Urole=="U" && RepYN=="A")
            {                              
                  ds = _EzBusinessHelper.ExecuteDataSet("select * from MENUITEMS016 a where  a.CmpyCode = '" + CmpyCode + "' and a.FormID  in ( Select formid from UserRights b where b.CmpyCode = a.CmpyCode and b.user_name='" + user_name + "' ) order by Levels ,sno");                              
            }
            else
            {
                if (RepYN == "R")
                {
                    cond = "  ParentFormID in('ID_Report','ID_Report_Master') or FormID='ID_Report' or FormID='ID_Payroll_Menu' and";
                }
                else if (RepYN == "F")
                {
                    cond = "  FormID !='ID_Report' and ";
                }

                ds = _EzBusinessHelper.ExecuteDataSet("Select * from MENUITEMS016 where " + cond + " CmpyCode='" + CmpyCode + "' order by Levels ,sno");
            }
            
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MenuItem> ObjList = new List<MenuItem>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MenuItem()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    ManualCode = dr["ManualCode"].ToString(),
                    FormName = dr["FormName"].ToString(),
                    UnicodeName = dr["UnicodeName"].ToString(),
                    ModalForm = Convert.ToInt16(dr["ModalForm"].ToString()),
                    Captions = dr["Captions"].ToString(),
                    AllMasterQuery = dr["AllMasterQuery"].ToString(),
                    Fields = dr["Fields"].ToString(),
                    FormID = dr["FormID"].ToString(),
                    frmName = dr["frmName"].ToString(),
                    FunctionName = dr["FunctionName"].ToString(),
                    Levels = Convert.ToInt16(dr["Levels"].ToString()),
                    TableName = dr["TableName"].ToString(),
                    UserDefined = Convert.ToInt16(dr["UserDefined"].ToString()),
                    CheckRight = Convert.ToInt16(dr["CheckRight"].ToString()),
                    NotForUser = Convert.ToInt16(dr["NotForUser"].ToString()),
                    ParentFormID = dr["ParentFormID"].ToString(),
                    Report = Convert.ToInt16(dr["Report"].ToString()),
                    Show = Convert.ToInt16(dr["Show"].ToString()),
                    ShowType = dr["ShowType"].ToString(),
                    Sno = Convert.ToInt16(dr["Sno"].ToString()),
                    NavURL = dr["NavURL"].ToString()
                });

            }
            return ObjList;
        }

        public List<MenuItem> GetMenuData(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from MENUITEMS016 where CmpyCode='"+CmpyCode+"' order by Levels ,sno");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<MenuItem> ObjList = new List<MenuItem>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new MenuItem()
                {
                    CmpyCode = dr["CmpyCode"].ToString(),
                    ManualCode = dr["ManualCode"].ToString(),
                    FormName = dr["FormName"].ToString(),
                    UnicodeName = dr["UnicodeName"].ToString(),
                    ModalForm = Convert.ToInt16(dr["ModalForm"].ToString()),
                    Captions = dr["Captions"].ToString(),
                    AllMasterQuery = dr["AllMasterQuery"].ToString(),
                    Fields = dr["Fields"].ToString(),
                    FormID = dr["FormID"].ToString(),
                    frmName = dr["frmName"].ToString(),
                    FunctionName = dr["FunctionName"].ToString(),
                    Levels = Convert.ToInt16(dr["Levels"].ToString()),
                    TableName = dr["TableName"].ToString(),
                    UserDefined = Convert.ToInt16(dr["UserDefined"].ToString()),
                    CheckRight = Convert.ToInt16(dr["CheckRight"].ToString()),
                    NotForUser = Convert.ToInt16(dr["NotForUser"].ToString()),
                    ParentFormID = dr["ParentFormID"].ToString(),
                    Report = Convert.ToInt16(dr["Report"].ToString()),
                    Show = Convert.ToInt16(dr["Show"].ToString()),
                    ShowType = dr["ShowType"].ToString(),
                    Sno = Convert.ToInt16(dr["Sno"].ToString()),
                    NavURL =dr["NavURL"].ToString()
                });

            }
            return ObjList;
        }

        public List<string> GetMetaSettings()
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, string> GetSelectedMetaSettings(string CmpyCode, string FormId)
        {
            throw new NotImplementedException();
        }
    }
}
