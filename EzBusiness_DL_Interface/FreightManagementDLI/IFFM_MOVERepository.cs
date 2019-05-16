using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
   public interface IFFM_MOVERepository
    {
        List<FFM_MOVE> GetFFM_MOVE(string CmpyCode);

        FFM_MOVE_VM SaveFFM_MOVE(FFM_MOVE_VM FCur);

        bool DeleteFFM_MOVE(string FFM_MOVE_VM_CODE, string CmpyCode, string UserName);
        FFM_MOVE_VM EditFFM_MOVE(string CmpyCode, string FFM_MOVE_VM);
    }
}
