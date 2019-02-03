using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Interface
{
    public interface IGroupPayrollService
    {
        List<GroupVM> GetGrs(string CmpyCode);

        GroupVM SaveGrs(GroupVM Grs);



        bool DeleteGrs(string DivisionCode, string CmpyCode, string UserName);
    }
}
