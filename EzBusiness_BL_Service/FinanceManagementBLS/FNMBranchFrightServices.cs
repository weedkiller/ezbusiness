﻿using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
   public class FNMBranchFrightServices: IFNMBranchFrightService 
    {
        IFNMBranchRepository _FNMBranchRepo;
        ICodeGenRepository _CodeRep;
        public FNMBranchFrightServices()
        {
            _FNMBranchRepo = new FNMBranchRepository();
            _CodeRep=new CodeGenRepository();
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
        public bool DeleteFNMBranch(string FNMBranch_CODE, string CmpyCode, string UserName)
        {
            return _FNMBranchRepo.DeleteFNMBranch(FNMBranch_CODE, CmpyCode, UserName);
        }

        public List<FNMBranch_VM> GetFNMBranch(string CmpyCode)
        {
            return _FNMBranchRepo.GetFNMBranch(CmpyCode).Select(m => new FNMBranch_VM
            {
                CMPYCODE = m.CMPYCODE,
                FNMBRANCH_CODE =m.FNMBRANCH_CODE, //
                DESCRIPTION = m.DESCRIPTION,
                PRINTNAME = m.PRINTNAME,
                SNO = m.SNO,
                ADDRESS = m.ADDRESS,
                EMAIL = m.EMAIL,
                WEBSITE = m.WEBSITE,
                MOBILE = m.MOBILE,
                CURRENCY = m.CURRENCY,
                COUNTRY = m.COUNTRY,
                STATE = m.STATE,
                DIVISION=m.DIVISION
            }).ToList();
        }
        public List<SelectListItem> GetCountryCodes(string CmpyCode, string Prefix)
        {
            var CountryList = _FNMBranchRepo.GetNationList(CmpyCode, Prefix)
                                        .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                        .ToList();
            return CountryList;
        }
        public List<SelectListItem> GetCountryCodesList(string CmpyCode, string Prefix)
        {
            var CountryList = _FNMBranchRepo.GetNationList(CmpyCode, Prefix)
                                        .Select(m => new SelectListItem { Value = m.CodeName, Text =m.Code })
                                        .ToList();
            return CountryList;
        }
        public List<SelectListItem> GetCurrencyCodes(string Prefix)
        {
            var CurrencyList = _FNMBranchRepo.GetCurrencyList(Prefix)
                                        .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                        .ToList();
            return CurrencyList;
        }
        public FNMBranch_VM SaveFNMBranch(FNMBranch_VM FC)
        {
            return _FNMBranchRepo.SaveFNMBranch(FC);
        }
        public FNMBranch_VM EditFNMBranch(string CmpyCode,string  BranchCode)
        {
            return _FNMBranchRepo.EditFNMBranch(CmpyCode, BranchCode);
           
        }

        public List<SelectListItem> GetDivisionList(string CmpyCode, string Prefix)
        {
            var CurrencyList = _FNMBranchRepo.GetDivisionList(CmpyCode, Prefix)
                                       .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                       .ToList();
            return CurrencyList;
        }

        public string GetMasterCode(string CmpyCode)
        {
           string code=_CodeRep.GetCode(CmpyCode,"FrightBranch");
            return code;
        }

        public FNMBranch_VM AddNewFNM_Branch(string CmpyCode)
        {
            return new FNMBranch_VM
            {
              
                EditFlag = false
            };
        }
    }
}
