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
  public  interface IFNM_CURRENCYRepository
    {
        List<FNM_CURRENCY> GetFNM_CURRENCY(string CmpyCode);

        FNM_CURRENCY_VM SaveFNM_CURRENCY(FNM_CURRENCY_VM FCur);

        bool DeleteFNM_CURRENCY(string FNM_CURRENCY_CODE, string CmpyCode, string UserName);
        FNM_CURRENCY_VM EditFNM_CURRENCY(string CmpyCode, string FNM_CURRENCYCode);
    }
}
