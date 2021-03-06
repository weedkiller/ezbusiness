﻿using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagement;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
   public interface IFNMBranchRepository
    {
        List<FNMBranch> GetFNMBranch(string CmpyCode);
        List<ComDropTbl> GetNationList(string CmpyCode, string Prefix);

        List<ComDropTbl> GetDivisionList(string CmpyCode, string Prefix);
        List<ComDropTbl> GetCurrencyList(string Prefix);
        FNMBranch_VM SaveFNMBranch(FNMBranch_VM FH);
        //List<Country> GetNationList(string CmpyCode);
        bool DeleteFNMBranch(string FNMBranch_CODE, string CmpyCode, string UserName);
        FNMBranch_VM EditFNMBranch(string CmpyCode, string BranchCode);
    }
}
