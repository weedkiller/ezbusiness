using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
   public interface IFNM_CURRENCYService
    {

        List<FNM_CURRENCY_VM> GetFNM_CURRENCY(string CmpyCode);
        FNM_CURRENCY_VM SaveFNM_CURRENCY(FNM_CURRENCY_VM FC);
        bool DeleteFNM_CURRENCY(string FNM_CURRENCY_CODE, string CmpyCode, string UserName);
        FNM_CURRENCY_VM EditFNM_CURRENCY(string CmpyCode, string FNM_CURRENCYCOde);
    }
}
