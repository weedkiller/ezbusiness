using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
   public interface IFMM_CLAUSE_FrightService
    {
        List<FFM_CLAUSE_VM> GetFFM_CLAUSE(string CmpyCode);

        FFM_CLAUSE_VM SaveFFM_CLAUSE(FFM_CLAUSE_VM FCur);

        bool DeleteFFM_CLAUSE(string FFM_CLAUSE_CODE, string CmpyCode, string UserName);
        FFM_CLAUSE_VM EditFFM_CLAUSE(string CmpyCode, string FFM_CLAUSE_VM);
    }
}
