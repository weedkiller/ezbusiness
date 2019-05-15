using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFFM_JOBRepository
    {

        #region FFM_JOB Master
        List<FFM_JOB> GetFFM_JOB(string CmpyCode);
        FFM_JOB_VM SaveFM_JOBHEAD(FFM_JOB_VM FJ);
        bool DeleteFFM_JOB(string FFM_JOB_CODE, string CmpyCode, string UserName);

        #endregion



    }
}
