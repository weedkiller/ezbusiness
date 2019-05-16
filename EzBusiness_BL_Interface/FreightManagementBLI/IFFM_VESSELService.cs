using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
   public interface  IFFM_VESSELService
    {

        bool DeleteFFM_VESSEL(string FFM_VESSEL_CODE, string CmpyCode, string UserName);
        List<FFM_VESSEL_VM> GetFFM_VESSEL(string CmpyCode);
        FFM_VESSEL_VM SaveFFM_VESSEL(FFM_VESSEL_VM ac);
        FFM_VESSEL_VM EditFFM_VESSEL(string CmpyCode, string FFM_VESSEL_CODE);
        FFM_VESSEL_VM GetFFM_VESSELAddNew(string Cmpycode);

        List<SelectListItem> GetNationList(string CmpyCode);

    }
}
