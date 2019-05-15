using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
    public interface IFFM_JOBFreightService
    {
        #region FFM_JOB Master
        List<FFM_JOB_VM> GetFFM_JOB(string CmpyCode);
        FFM_JOB_VM SaveFFM_JOB(FFM_JOB_VM FJ);
        bool DeleteFFM_JOB(string FFM_JOB_CODE, string CmpyCode, string UserName);
        #endregion
    }
}
