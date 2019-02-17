using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MaterialMgmt;


namespace EzBusiness_BL_Interface
{
    public interface IMaterialMgmtService
    {
        List<UnitVM> GetUnits(string CmpyCode);

        UnitVM SaveUnit(UnitVM unit);

        List<UnitType> GetUnitTypes();

        bool DeleteUnit(string Code, string CmpyCode);

    }
}
