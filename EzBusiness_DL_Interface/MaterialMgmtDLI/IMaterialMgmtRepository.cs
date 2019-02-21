using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MaterialMgmt;

namespace EzBusiness_DL_Interface
{
    public interface IMaterialMgmtRepository
    {
        #region Unit Master
        List<Unit> GetUnits(string CmpyCode);

        UnitVM SaveUnit(string cmpyCode,UnitVM unit);

        List<UnitType> GetUnitTypes();

        bool DeleteUnit(string Code, string CmpyCode);

        #endregion

        #region Material Request



        #endregion

    }
}
