using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
   public class FNMBranchFrightServices: IFNMBranchFrightService 
    {
        IFNMBranchRepository _FNMBranchRepo;

        public FNMBranchFrightServices()
        {
            _FNMBranchRepo = new FNMBranchRepository();
        }
      
        private List<SelectListItem> InsertFirstElementDDL(List<SelectListItem> items)
        {
            items.Insert(0, new SelectListItem
            {
                Value = PurchaseMgmtConstants.DDLFirstVal,
                Text = PurchaseMgmtConstants.DDLFirstText
            });
            return items;
        }
        public bool DeleteFNMBranch(string FNMBranch_CODE, string CmpyCode, string UserName)
        {
            return _FNMBranchRepo.DeleteFNMBranch(FNMBranch_CODE, CmpyCode, UserName);
        }

        public List<FNMBranch_VM> GetFNMBranch(string CmpyCode)
        {
            return _FNMBranchRepo.GetFNMBranch(CmpyCode).Select(m => new FNMBranch_VM
            {
                CMPYCODE = m.CMPYCODE,
                FNMBRANCH_CODE = m.FNMBRANCH_CODE,
                DESCRIPTION = m.DESCRIPTION,
                PRINTNAME = m.PRINTNAME,
                SNO = m.SNO,
                ADDRESS = m.ADDRESS,
                EMAIL = m.EMAIL,
                WEBSITE = m.WEBSITE,
                MOBILE = m.MOBILE,
                CURRENCY = m.CURRENCY,
                COUNTRY = m.COUNTRY,
                STATE = m.STATE
            }).ToList();
        }
        public List<SelectListItem> GetCountryCodes(string CmpyCode)
        {
            var CountryList = _FNMBranchRepo.GetNationList(CmpyCode)
                                        .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                        .ToList();
            return InsertFirstElementDDL(CountryList);
        }
        public List<SelectListItem> GetCurrencyCodes(string CmpyCode)
        {
            var CurrencyList = _FNMBranchRepo.GetCurrencyCodes(CmpyCode)
                                        .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                        .ToList();
            return InsertFirstElementDDL(GetCurrencyCodes);
        }
        public FNMBranch_VM SaveFNMBranch(FNMBranch_VM FC)
        {
            return _FNMBranchRepo.SaveFNMBranch(FC);
        }
        public FNMBranch_VM EditFNMBranch(string CmpyCode,string  BranchCode)
        {
            return _FNMBranchRepo.EditFNMBranch(CmpyCode, BranchCode);
           
        }
      
    }
}
