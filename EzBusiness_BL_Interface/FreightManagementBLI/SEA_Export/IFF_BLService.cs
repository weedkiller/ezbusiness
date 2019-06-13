using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI.SEA_Export
{
    public interface IFF_BLService
    {
        List<FF_BL_VM> GetFF_BL(string CmpyCode);
        FF_BL_VM GetFF_BLDetailsEdit(string CmpyCode, string FF_BL001_CODE);
        FF_BL_VM SaveFF_BL_VM(FF_BL_VM FQV);

        FF_BL_VM GetFF_BL_AddNew(string Cmpycode);
        List<FF_BL002New> GetFF_BL002DetailList(string CmpyCode, string FF_BL001_CODE);
        List<FF_BL003New> GetFF_BL003DetailList(string CmpyCode, string FF_BL001_CODE);
        List<FF_BL004New> GetFF_BL004DetailList(string CmpyCode, string FF_BL001_CODE);
        List<FF_BL005New> GetFF_BL005DetailList(string CmpyCode, string FF_BL001_CODE);
        List<SelectListItem> GetMoveCode(string CmpyCode);

        List<SelectListItem> GetDepart(string CmpyCode);

        List<SelectListItem> GetPortList(string CmpyCode);
        List<SelectListItem> GetVESSELList(string CmpyCode);
        List<SelectListItem> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE);
        List<SelectListItem> GetSL(string CmpyCode, string typ1);        
        List<SelectListItem> GetCommodityistList(string CmpyCode);
        List<SelectListItem> GetCLAUSE(string CmpyCode);

        List<SelectListItem> GetCRG_002(string CmpyCode);

        List<SelectListItem> GetContTyp(string CmpyCode);

        List<SelectListItem> GetCust(string CmpyCode);

        List<SelectListItem> GetVendor(string CmpyCode);

        List<SelectListItem> GetCurcode(string CmpyCode);
        List<SelectListItem> GETJobTypList(string CmpyCode);

        List<SelectListItem> GetUnitcode(string CmpyCode);
        bool DeleteFF_BL(string CmpyCode, string FF_BL001_CODE, string UserName);

        decimal GetCurRate(string CmpyCode, string CurCode);
    }
}
