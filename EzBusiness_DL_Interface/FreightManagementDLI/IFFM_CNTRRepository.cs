using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
   public interface IFFM_CNTRRepository
    {
          List<FFM_CNTR> GetFFM_CNTR(string CmpyCode);

        FFM_CNTR_VM SaveFFM_CNTR(FFM_CNTR_VM FCur);

        bool DeleteFMM_CNTR(string FNM_CURRENCY_CODE, string CmpyCode, string UserName);
        FFM_CNTR_VM EditFFM_CNTR(string CmpyCode, string FNM_CURRENCYCode);
    }
}
