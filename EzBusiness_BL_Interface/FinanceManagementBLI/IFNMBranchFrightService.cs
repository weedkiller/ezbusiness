﻿using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
   public interface IFNMBranchFrightService
    {
        string GetMasterCode(string CmpyCode);
        List<FNMBranch_VM> GetFNMBranch(string CmpyCode);
        FNMBranch_VM SaveFNMBranch(FNMBranch_VM FC);
        bool DeleteFNMBranch(string FNMBranch_CODE, string CmpyCode, string UserName);
        List<SelectListItem> GetCountryCodes(string CmpyCode, string Prefix);
        List<SelectListItem> GetCountryCodesList(string Cmpy, string Prefix);
        List<SelectListItem> GetCurrencyCodes(string  Prefix);
        FNMBranch_VM AddNewFNM_Branch(string CmpyCode);
        List<SelectListItem> GetDivisionList(string CmpyCode, string Prefix);
        FNMBranch_VM EditFNMBranch(string CmpyCode, string FNMBranchCOde);
        //List<SelectListItem> GetCountryCodes(string CmpyCode);
    }
}


