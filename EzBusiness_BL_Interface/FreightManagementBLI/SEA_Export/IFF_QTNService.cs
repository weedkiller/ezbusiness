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
        List<FF_QTN_VM> GetFF_QTN(string CmpyCode);
        FF_QTN_VM GetFF_QTNDetailsEdit(string CmpyCode, string FF_QTN001_CODE);
        FF_QTN_VM SaveFF_QTN_VM(FF_QTN_VM FQV);

        FF_QTN_VM GetFF_QTN_AddNew(string Cmpycode);
        List<FF_QTN002New> GetFF_QTN002DetailList(string CmpyCode, string FF_QTN001_CODE);
        List<FF_QTN003New> GetFF_QTN003DetailList(string CmpyCode, string FF_QTN001_CODE);
        List<FF_QTN004New> GetFF_QTN004DetailList(string CmpyCode, string FF_QTN001_CODE);
        List<FF_QTN005New> GetFF_QTN005DetailList(string CmpyCode, string FF_QTN001_CODE);
        List<SelectListItem> GetMoveCode(string CmpyCode);

        List<SelectListItem> GetDepart(string CmpyCode);

        List<SelectListItem> GetPortList(string CmpyCode);
        List<SelectListItem> GetVESSELList(string CmpyCode);
        List<SelectListItem> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE);
        List<SelectListItem> GetSL(string CmpyCode);
       
        List<SelectListItem> GetCLAUSE(string CmpyCode);

        List<SelectListItem> GetCRG_002(string CmpyCode);

        List<SelectListItem> GetCust(string CmpyCode);

        List<SelectListItem> GetVendor(string CmpyCode);

        List<SelectListItem> GetCurcode(string CmpyCode);


        List<SelectListItem> GetUnitcode(string CmpyCode);
        bool DeleteFF_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName);

        decimal GetCurRate(string CmpyCode, string CurCode);
    }
}
