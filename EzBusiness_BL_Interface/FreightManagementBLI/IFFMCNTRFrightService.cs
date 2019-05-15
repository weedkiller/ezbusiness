using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
   public interface IFFMCNTRFrightService
    {
        List<FFM_CNTR_VM> GetFFM_CNTR(string CmpyCode);
        FFM_CNTR_VM SaveFFM_CNTR(FFM_CNTR_VM FC);
        bool DeleteFMM_CNTR(string FMM_CNTR_CODE, string CmpyCode, string UserName);
        FFM_CNTR_VM EditFFM_CNTR(string CmpyCode, string FMM_CNTR_CODE);
    }
}
