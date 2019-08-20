using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
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
        List<FF_BOK_VM> GetFF_BOK(string CmpyCode, string BranchCode);
        FF_BOK_VM GetFF_BOKDetailsEdit(string CmpyCode, string FF_BOK001_CODE,string BranchCode);

        FF_BOK_VM GetFF_BOKDetailsQuot(string CmpyCode, string FF_BOK001_CODE, string BranchCode);

        FF_BOK_VM SaveFF_BOK_VM(FF_BOK_VM FQV);

        FF_BOK_VM GetFF_BOK_AddNew(string Cmpycode, string branchcode);
        List<FF_BOK002New> GetFF_BOK002DetailList(string CmpyCode, string FF_BOK001_CODE,string typ, string BRANCH_CODE);
        List<FF_BOK003New> GetFF_BOK003DetailList(string CmpyCode, string FF_BOK001_CODE, string typ, string BRANCH_CODE);
        List<FF_BOK004New> GetFF_BOK004DetailList(string CmpyCode, string FF_BOK001_CODE, string typ, string BRANCH_CODE);
        List<FF_BOK005New> GetFF_BOK005DetailList(string CmpyCode, string FF_BOK001_CODE, string typ, string BRANCH_CODE);
        List<SelectListItem> GetMoveCode(string CmpyCode);
        List<SelectListItem> GetCommodityistList(string CmpyCode);
        List<SelectListItem> GETJobTypList(string CmpyCode, string Prefix);
        List<SelectListItem> GetContTyp(string CmpyCode);
        List<SelectListItem> GetDepart(string CmpyCode);

        List<SelectListItem> GetQTNCODEbycusto(string CmpyCode, string custocode, DateTime vdate,string BranchCode);
        List<SelectListItem> GetPortList(string CmpyCode);
        List<SelectListItem> GetVESSELList(string CmpyCode);
        List<SelectListItem> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE);
        List<SelectListItem> GetSL(string CmpyCode, string Branchcode);

        List<SelectListItem> GetCLAUSE(string CmpyCode);

        List<SelectListItem> GetCRG_002(string CmpyCode);

        List<SelectListItem> GetCust(string CmpyCode);

        List<SelectListItem> GetVendor(string CmpyCode);

        List<SelectListItem> GetCurcode(string CmpyCode);

        List<SelectListItem> GetSalesman(string cmpycode, string Prefix);

        List<SelectListItem> GetQTNCODE(string CmpyCode,DateTime dte);
        List<SelectListItem> GetUnitcode(string CmpyCode);
        bool DeleteFF_BOK(string CmpyCode, string FF_BOK001_CODE, string UserName, string BRANCH_CODE);

        decimal GetCurRate(string CmpyCode, string CurCode);

        List<SelectListItem> GetSLNew(string CmpyCode, string Typ1, string Prefix);

        string Aprrove_QTN(string CmpyCode, string FF_BOK001_CODE, string UserName, string Typ, string BranchCode, string Tablename);
    }
}
