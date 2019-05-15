using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
   public interface IFFM_CLAUSERepository
    {
        List<FFM_CLAUSE> GetFFM_CLAUSE(string CmpyCode);

        FFM_CLAUSE_VM SaveFFM_CLAUSE(FFM_CLAUSE_VM FCur);
        FFM_CLAUSE_VM EditFFM_CLAUSE(string CmpyCode, string FFM_CLAUSE_VM);
        bool DeleteFFM_CLAUSE(string FFM_CLAUSE_VM_CODE, string CmpyCode, string UserName);
    }
}
