﻿using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
   public interface IFNM_AC_COAService
    {
        bool DeleteFNM_Ac_COA( string CmpyCode, string FNM_AC_CODE, string UserName);
        List<FNM_AC_COA_VM> GetFNM_AC_COA(string CmpyCode);
        FNM_AC_COA_VM SaveFNM_AC_COA(FNM_AC_COA_VM ac);
        FNM_AC_COA_VM EditFNM_AC_COA(string CmpyCode, string Code);

        FNM_AC_COA_VM GetFNM_AC_COAAddNew(string Cmpycode);

        IQueryable<SelectListItem> GetFMHEAD(string Cmpycode,string Prefix);
        IQueryable<SelectListItem> Getgroup_code(string Cmpycode, string Prefix);
        IQueryable<SelectListItem> GetSUBGROUP(string Cmpycode, string Prefix);
        IQueryable<SelectListItem> GetCOA_TYPEList(string Cmpycode, string Prefix);
        IQueryable<SelectListItem> GetFNMSUBGROUP(string Cmpycode, string Prefix);

        IQueryable<SelectListItem> GetSUBLEDGER_CAT(string Cmpycode, string Prefix);
    }
}
