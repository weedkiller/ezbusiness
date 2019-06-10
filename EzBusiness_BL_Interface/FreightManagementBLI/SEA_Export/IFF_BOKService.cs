﻿using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI.SEA_Export
{
    public interface IFF_BOKService
    {
        List<FF_BOK_VM> GetFF_BOK(string CmpyCode);
        FF_BOK_VM GetFF_BOKDetailsEdit(string CmpyCode, string FF_BOK001_CODE);
        FF_BOK_VM SaveFF_BOK_VM(FF_BOK_VM FQV);

        FF_BOK_VM GetFF_BOK_AddNew(string Cmpycode);
        List<FF_BOK002New> GetFF_BOK002DetailList(string CmpyCode, string FF_BOK001_CODE);
        List<FF_BOK003New> GetFF_BOK003DetailList(string CmpyCode, string FF_BOK001_CODE);
        List<FF_BOK004New> GetFF_BOK004DetailList(string CmpyCode, string FF_BOK001_CODE);
        List<FF_BOK005New> GetFF_BOK005DetailList(string CmpyCode, string FF_BOK001_CODE);
        List<SelectListItem> GetMoveCode(string CmpyCode);

        List<SelectListItem> GETJobTypList(string CmpyCode);
        List<SelectListItem> GetContTyp(string CmpyCode);
        List<SelectListItem> GetDepart(string CmpyCode);

        List<SelectListItem> GetPortList(string CmpyCode);
        List<SelectListItem> GetVESSELList(string CmpyCode);
        List<SelectListItem> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE);
        List<SelectListItem> GetSL(string CmpyCode, string typ1);

        List<SelectListItem> GetCLAUSE(string CmpyCode);

        List<SelectListItem> GetCRG_002(string CmpyCode);

        List<SelectListItem> GetCust(string CmpyCode);

        List<SelectListItem> GetVendor(string CmpyCode);

        List<SelectListItem> GetCurcode(string CmpyCode);


        List<SelectListItem> GetUnitcode(string CmpyCode);
        bool DeleteFF_BOK(string CmpyCode, string FF_BOK001_CODE, string UserName);

        decimal GetCurRate(string CmpyCode, string CurCode);
    }
}
