using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
   public interface  IFFM_CRG_GroupRepository
    {

        bool DeleteFFM_CRG_Group(string FFM_CRG_GROUP_CODE, string CmpyCode, string UserName);
        List<FFM_CRG_Group_VM> GetFFM_CRG_Group(string CmpyCode);
        FFM_CRG_Group_VM SaveFFM_CRG_Group(FFM_CRG_Group_VM ac);
        FFM_CRG_Group_VM EditFFM_CRG_Group(string CmpyCode, string FFM_CRG_GROUP_CODE);
    }
}
