using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MenuItem;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service
{
    public class MasterService : IMasterService
    {

        public IMasterRepository repo;

        public MasterService()
        {
            repo = new MasterRepository();
        }

        public IList<MenuItemsVM> GetTreeData1(string CmpyCode, string user_name, string Urole, string RepYN)
        {

            var resultRaw = repo.GetMenuData1(CmpyCode, user_name,Urole,  RepYN);
            if (resultRaw != null && resultRaw.Count > 0)
            {
                var resultsProcessed = resultRaw.Select(m => new MenuItemsVM
                {
                    FormID = m.FormID,
                    FormName = m.FormName,
                    AllMasterQuery = m.AllMasterQuery,
                    Captions = m.Captions,
                    CmpyCode = m.CmpyCode,
                    Fields = m.Fields,
                    frmName = m.frmName,
                    FunctionName = m.FunctionName,
                    Levels = m.Levels,
                    ManualCode = m.ManualCode,
                    ParentFormID = string.IsNullOrWhiteSpace(m.ParentFormID) ? "00" : m.ParentFormID,
                    Sno = m.Sno,
                    TableName = m.TableName,
                    UnicodeName = m.UnicodeName,
                    UserDefined = m.UserDefined,
                    NavURL = m.NavURL,
                    Parent = string.IsNullOrWhiteSpace(m.ParentFormID) ? null : new MenuItemsVM { FormID = m.ParentFormID },
                    EmpCodeList = GetEmpCodes(CmpyCode, "U"),

                }).ToList();
                if (RepYN == "A")
                {
                    resultsProcessed.Insert(0, new MenuItemsVM { FormID = "00", ParentFormID = string.Empty, FormName = "EZ Business System" });
                }                
                return resultsProcessed;
            }
            return new List<MenuItemsVM>();
        }
        public IList<MenuItemsVM> GetTreeData(string CmpyCode)
        {

            var resultRaw = repo.GetMenuData(CmpyCode);
            if (resultRaw != null && resultRaw.Count > 0)
            {
                var resultsProcessed = resultRaw.Select(m => new MenuItemsVM
                {
                    FormID = m.FormID,
                    FormName = m.FormName,
                    AllMasterQuery = m.AllMasterQuery,
                    Captions = m.Captions,
                    CmpyCode = m.CmpyCode,
                    Fields = m.Fields,
                    frmName = m.frmName,
                    FunctionName = m.FunctionName,
                    Levels = m.Levels,
                    ManualCode = m.ManualCode,
                    ParentFormID = string.IsNullOrWhiteSpace(m.ParentFormID) ? "00" : m.ParentFormID,
                    Sno = m.Sno,
                    TableName = m.TableName,
                    UnicodeName = m.UnicodeName,
                    UserDefined = m.UserDefined,
                    NavURL=m.NavURL,                    
                    Parent = string.IsNullOrWhiteSpace(m.ParentFormID) ? null : new MenuItemsVM { FormID = m.ParentFormID },
                    EmpCodeList=GetEmpCodes(CmpyCode,"U"),

                }).ToList();
              //  resultsProcessed.Insert(0, new MenuItemsVM { FormID = "00", ParentFormID = string.Empty, FormName = "EZ Business System" });
                return resultsProcessed;
            }
            return new List<MenuItemsVM>();
        }


        public List<SelectListItem> FormsDDLList(string CmpyCode)
        {
            var menuItemsRaw = repo.FormsDDLList(CmpyCode);
            return menuItemsRaw != null && menuItemsRaw.Count > 0
                        ? menuItemsRaw.Select(m => new SelectListItem
                        {
                            Value = m.FormID,
                            Text = String.Concat(m.FormName, " (", m.FormID, ")")
                        }).ToList()
                        : new List<SelectListItem>();
        }

        public List<SelectListItem> FormsDDLListWithParentValue(string CmpyCode)
        {
            var menuItemsRaw = repo.FormsDDLList(CmpyCode);
            return menuItemsRaw != null && menuItemsRaw.Count > 0
                        ? menuItemsRaw.Select(m => new SelectListItem
                        {
                            Value = string.Concat(m.FormID, ",", m.ParentFormID),
                            Text = String.Concat(m.FormName, " (", m.FormID, ")")
                        }).ToList()
                        : new List<SelectListItem>();
        }


        public List<SelectListItem> GetMetaSettings()
        {
            var metaDataRaw = repo.GetMetaSettings();
            var metaData = metaDataRaw != null && metaDataRaw.Count > 0
                        ? metaDataRaw.Select(m => new SelectListItem
                        {
                            Value = m,
                            Text = m
                        }).ToList() : new List<SelectListItem>();
            metaData.Insert(0, new SelectListItem { Selected = true, Text = String.Empty, Value = "-1" });
            return metaData;
        }


        public string GetParentFormName(string CmpyCode, string ParentFormId)
        {
            var menuItemsRaw = repo.FormsDDLList(CmpyCode);
            return menuItemsRaw.FirstOrDefault(m => m.FormID == ParentFormId).FormName;
        }

        public MenuItemsVM GetFormDetails(string CmpyCode, string FormId, string parentFormId)
        {
            var fd = repo.GetFormDetails(CmpyCode, FormId, parentFormId);
            var selectedMetaSettings = repo.GetSelectedMetaSettings(CmpyCode, FormId);
            return new MenuItemsVM
            {
                FormID = fd.FormID,
                AllMasterQuery = fd.AllMasterQuery,
                Captions = fd.Captions,
                CheckRight = fd.CheckRight == 1 ? true : false,
                CmpyCode = fd.CmpyCode,
                EditMode = true,
                Fields = fd.Fields,
                FormName = fd.FormName,
                frmName = fd.frmName,
                FunctionName = fd.FunctionName,
                Levels = fd.Levels,
                ManualCode = fd.ManualCode,
                MetaDataSettings = GetMetaSettings(),
                ModalForm = fd.ModalForm == 1 ? true : false,
                NotForUser = fd.NotForUser == 1 ? true : false,
                ParentFormID = fd.ParentFormID,
                ParentFormName = GetParentFormName(CmpyCode, parentFormId),
                Report = fd.Report == 1 ? true : false,
                SelectedMetaDataSettings = selectedMetaSettings,
                Show = fd.Show == 1 ? true : false,
                ShowType = fd.ShowType,
                Sno = fd.Sno,
                TableName = fd.TableName,
                UnicodeName = fd.UnicodeName,
                UserDefined = fd.UserDefined
            };
        }


        public MenuItemsVM AddFrom(MenuItemsVM menuItem)
        {
            return repo.AddFrom(menuItem);
        }

        public MenuItemsVM EditFrom(MenuItemsVM menuItem)
        {
            return repo.EditFrom(menuItem);
        }

        public List<SelectListItem> GetEmpCodes(string CmpyCode, string typ)
        {
            var itemCodes = repo.GetEmpCodes(CmpyCode,typ)
                                           .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                           .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
        private List<SelectListItem> InsertFirstElementDDL(List<SelectListItem> items)
        {
            items.Insert(0, new SelectListItem
            {
                Value = PurchaseMgmtConstants.DDLFirstVal,
                Text = PurchaseMgmtConstants.DDLFirstText
            });
            return items;
        }
        //public MenuItemsVM AddFrom(MenuItemsVM menuItem)
        //{
        //    throw new NotImplementedException();
        //}

        //public MenuItemsVM EditFrom(MenuItemsVM menuItem)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<SelectListItem> FormsDDLList(string CmpyCode)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<SelectListItem> FormsDDLListWithParentValue(string CmpyCode)
        //{
        //    throw new NotImplementedException();
        //}

        //public MenuItemsVM GetFormDetails(string CmpyCode, string FormId, string parentFormId)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<SelectListItem> GetMetaSettings()
        //{
        //    throw new NotImplementedException();
        //}

        //public string GetParentFormName(string CmpyCode, string ParentFormId)
        //{
        //    throw new NotImplementedException();
        //}

        //public IList<MenuItemsVM> GetTreeData(string CmpyCode)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
