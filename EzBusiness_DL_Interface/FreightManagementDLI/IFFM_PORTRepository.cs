using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_EF_Entity.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
    public interface IFFM_PORTRepository
    {
        List<FFM_PORT_VM> GetFFM_PORT(string CmpyCode);

        FFM_PORT_VM SaveFFM_PORT(FFM_PORT_VM fpk);
        List<Nation> GetCountryList(string CmpyCode);

        bool DeleteFFM_PORT(string FFM_PORT_CODE, string CmpyCode, string UserName);
        FFM_PORT_VM EditFFM_PORT(string CmpyCode, string FFM_PORT_CODE);
    }
}
