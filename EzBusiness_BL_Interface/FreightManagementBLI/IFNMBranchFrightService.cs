using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
   public interface IFNMBranchFrightService
    {
        List<FNMBranch_VM> GetFNMBranch(string CmpyCode);
        FNMBranch_VM SaveFNMBranch(FNMBranch_VM FC);
        bool DeleteFNMBranch(string FNMBranch_CODE, string CmpyCode, string UserName);
        List<FNMBranch> EditFNMBranch(string CmpyCode, string FNMBranchCOde);
    }
}


