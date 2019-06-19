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
    public interface IFFM_PORTService
    {
        List<FFM_PORT_VM> GetFFM_PORT(string CmpyCode);
        FFM_PORT_VM SaveFFM_PORT(FFM_PORT_VM FC);
        bool DeleteFFM_PORT(string FFM_PORT_CODE, string CmpyCode, string UserName);
        FFM_PORT_VM EditFFM_PORT(string CmpyCode, string FFM_PORT_CODE);
        FFM_PORT_VM NewFFM_PORT(string CmpyCode);
        List<SelectListItem> GetCountryList(string CmpyCode);

        List<SelectListItem> CountryEdit(string CmpyCode, string code);
        List<SelectListItem> GetCountryList1(string CmpyCode,string Prefix);
    }
}
