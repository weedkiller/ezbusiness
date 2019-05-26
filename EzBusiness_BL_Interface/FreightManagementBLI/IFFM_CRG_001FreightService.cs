using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
    public interface IFFM_CRG_001FreightService
    {
        #region FFM_CRG_001 Master
        List<FFM_CRG_VM> GetFFM_CRG_001(string CmpyCode);
        FFM_CRG_VM SaveFFM_CRG_001(FFM_CRG_VM CR);
        bool DeleteFFM_CRG_001( string CmpyCode, string FFM_CRG_001_CODE, string UserName);
        List<FFM_CRG_Details> GetCRGDetailList(string CmpyCode, string VyogCode);
        List<SelectListItem> GetCRG_Group(string Cmpycode);

        FFM_CRG_VM EditFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE);

        FFM_CRG_VM FM_CRG_001AddNew(string CmpyCode);
        #endregion
    }
}
