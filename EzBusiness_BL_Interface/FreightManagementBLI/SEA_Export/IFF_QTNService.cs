using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI.SEA_Export
{
    public interface IFF_QTNService
    {
        List<FF_QTN_VM> GetFF_QTN(string CmpyCode,string branchcode);
        FF_QTN_VM GetFF_QTNDetailsEdit(string CmpyCode, string FF_QTN001_CODE,string BranchCode);
        FF_QTN_VM SaveFF_QTN_VM(FF_QTN_VM FQV);

        FF_QTN_VM GetFF_QTN_AddNew(string Cmpycode, string branchcode);

        FF_QTN_VM GetFF_QuotCopy(string CmpyCode, string FF_QTN001_CODE, string BranchCode);

        List<FF_QTN002New> GetFF_QTN002DetailList(string CmpyCode, string FF_QTN001_CODE, string BRANCH_CODE);
        List<FF_QTN003New> GetFF_QTN003DetailList(string CmpyCode, string FF_QTN001_CODE, string BRANCH_CODE);
        List<FF_QTN004New> GetFF_QTN004DetailList(string CmpyCode, string FF_QTN001_CODE, string BRANCH_CODE);
        List<FF_QTN005New> GetFF_QTN005DetailList(string CmpyCode, string FF_QTN001_CODE, string BRANCH_CODE);
        List<SelectListItem> GetMoveCode(string CmpyCode, string Prefix);

        List<SelectListItem> GetCommodityistList(string CmpyCode, string Prefix);
        List<SelectListItem> GetCommodityistListT(string CmpyCode, string Prefix);
        List<SelectListItem> GetDepart(string CmpyCode, string Prefix);
        List<SelectListItem> GetContTyp(string CmpyCode, string Prefix);
        IQueryable<SelectListItem> GetPortList(string CmpyCode, string Prefix);
        List<SelectListItem> GetVESSELList(string CmpyCode, string Prefix);
        List<SelectListItem> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE, string Prefix);
        List<SelectListItem> GetSL(string CmpyCode, string Prefix);
       
        List<SelectListItem> GetCLAUSE(string CmpyCode, string Prefix);

        List<SelectListItem> GetCRG_002(string CmpyCode, string Prefix);

        List<SelectListItem> GetCust(string CmpyCode, string BRANCHCODE, string Prefix);
        List<SelectListItem> GetCustT(string CmpyCode, string BRANCHCODE, string Prefix);

        List<SelectListItem> GetVendor(string CmpyCode, string BRANCHCODE, string Prefix);

        List<SelectListItem> GetCurcode(string CmpyCode, string Prefix);


        List<SelectListItem> GetUnitcode(string CmpyCode, string Prefix);
        bool DeleteFF_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName, string BRANCH_CODE);
        string Aprrove_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName, string Typ, string BranchCode,string Tablename);
        decimal GetCurRate(string CmpyCode, string CurCode);

      //  List<ComDropTbl> GetApproveRej(string CmpyCode, string BranchCode, string FF_QTN001_CODE);
        List<SelectListItem> GetBranchListN(string CmpyCode, string Prefix);


        List<SelectListItem> GetCurCodebranch(string CmpyCode, string BranchCode);
    }
}
