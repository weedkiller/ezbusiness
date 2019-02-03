using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IDisciplinePayrollRepository
    {
        #region Discipline Master
        List<Discipline> GetDis(string CmpyCode);

        DisciplineVM SaveDis(DisciplineVM Dis);



        bool DeleteDis(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
