using EzBusiness_EF_Entity;
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
    public interface IFFM_CRG_001Repository
    {
        #region FFM_CRG_001 Master
        List<FFM_CRG> GetFFM_CRG_001(string CmpyCode);
        FFM_CRG_VM SaveFM_CRG_001(FFM_CRG_VM CR);

        List<FFM_CRG_Group> GetCRG_Group(string Cmpycode);

        List<FFM_CRG_Details> GetCRGDetailList(string CmpyCode, string CRGCode);

        FFM_CRG_VM EditFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE);

        bool DeleteFFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE,  string UserName);
        #endregion
    }
}
