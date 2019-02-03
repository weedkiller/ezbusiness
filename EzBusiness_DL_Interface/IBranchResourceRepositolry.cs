using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IBranchResourceRepository
    {
        #region Branch Master
        List<BranchTbl> GetBrch(string CmpyCode);

        BranchVM SaveBrch(BranchVM Brnc);

        List<Division> GetDivisionList(string CmpyCode);

        bool DeleteBrch(string Code, string CmpyCode,string UserName);

        #endregion
    }
}
