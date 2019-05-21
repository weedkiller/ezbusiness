using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFFM_CRG_002Repository
    {
        bool DeleteFFM_CRG_002(string FFM_CRG_JOB_CODE, string CmpyCode, string UserName);
        List<FFM_CRG_002_VM> GetFFM_CRG_002(string CmpyCode);
        FFM_CRG_002_VM SaveFFM_CRG_002(FFM_CRG_002_VM ac);
        FFM_CRG_002_VM EditFFM_CRG_002(string CmpyCode, string FFM_CRG_JOB_CODE);
    }
}
