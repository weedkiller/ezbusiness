using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_EF_Entity.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFFM_PORTRepository
    {
        List<FFM_PORT> GetFFM_PORT(string CmpyCode);

        FFM_PORT_VM SaveFFM_PACKING(FFM_PORT_VM fpk);

        bool DeleteFFM_PORT(string FFM_PORT_CODE, string CmpyCode, string UserName);
        FFM_PORT_VM EditFFM_PORT(string CmpyCode, string FFM_PORT_CODE);
    }
}
