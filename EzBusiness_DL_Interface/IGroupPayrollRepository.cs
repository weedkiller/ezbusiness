using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IGroupPayrollRepository
    {
        #region Group Master
        List<Group> GetGrs(string CmpyCode);

        GroupVM SaveGrs(GroupVM Grs);



        bool DeleteGrs(string DivisionCode, string CmpyCode, string UserName);

        #endregion
    }
}
