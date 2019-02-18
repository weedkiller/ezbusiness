using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MaterialMgmt;

namespace EzBusiness_BL_Service
{
    public class MaterialMgmtService : IMaterialMgmtService
    {
        IMaterialMgmtRepository _materialRepo;
        public MaterialMgmtService()
        {
            _materialRepo = new MaterialMgmtRepository();
        }

        public bool DeleteUnit(string Code, string CmpyCode)
        {
            return _materialRepo.DeleteUnit(Code, CmpyCode);
        }

        #region Methods

        #region Public Methods 
        public List<UnitVM> GetUnits(string CmpyCode)
        {
            return _materialRepo.GetUnits(CmpyCode).Select(m => new UnitVM
            {
                CmpyCode = m.CmpyCode,
                Code = m.Code,
                Name = m.Name,
                UniCodeName = m.UniCodeName == "NULL" ? null : m.UniCodeName,
                UnitType = m.UnitType
            }).ToList();
        }

        public List<UnitType> GetUnitTypes()
        {
            var unitTypes = _materialRepo.GetUnitTypes();
            unitTypes.Insert(0, new UnitType { Code = "0", Name = "-Select-" });
            return unitTypes;
        }

        public UnitVM SaveUnit(UnitVM unit)
        {
            return _materialRepo.SaveUnit(unit);
        }

        #endregion

        #region Private Methods 

        #endregion


        #endregion
    }
}
