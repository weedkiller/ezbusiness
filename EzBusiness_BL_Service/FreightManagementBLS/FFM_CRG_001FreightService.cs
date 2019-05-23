using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_ViewModels;


namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FFM_CRG_001FreightService : IFFM_CRG_001FreightService
    {
        IFFM_CRG_001Repository _FFMCRGRepo;

        public FFM_CRG_001FreightService()
        {
            _FFMCRGRepo = new FFM_CRG_001Repository();
        }
        public bool DeleteFFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE,  string UserName)
        {
            return _FFMCRGRepo.DeleteFFM_CRG_001(CmpyCode, FFM_CRG_001_CODE,  UserName);
        }

        public FFM_CRG_001_VM EditFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE)
        {
            var FFM_CRG_001Edit = _FFMCRGRepo.EditFM_CRG_001(CmpyCode, FFM_CRG_001_CODE);
            FFM_CRG_001Edit.CRG_GROUP_CODEList = GetCRG_Group(CmpyCode);
            return FFM_CRG_001Edit;
        }

        public FFM_CRG_001_VM FM_CRG_001AddNew(string CmpyCode)
        {
            return new FFM_CRG_001_VM
            {
                CRG_GROUP_CODEList = GetCRG_Group(CmpyCode),
                
                EditFlag = false
            };
        }

        public List<SelectListItem> GetCRG_Group(string Cmpycode)
        {
            var itemCodes = _FFMCRGRepo.GetCRG_Group(Cmpycode)
                                         .Select(m => new SelectListItem { Value = m.FFM_CRG_GROUP_CODE, Text = string.Concat(m.FFM_CRG_GROUP_CODE, " - ", m.NAME) })
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
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

        public List<FFM_CRG_001_VM> GetFFM_CRG_001(string CmpyCode)
        {
            return _FFMCRGRepo.GetFFM_CRG_001(CmpyCode).Select(m => new FFM_CRG_001_VM
            {
                CMPYCODE = m.CMPYCODE,
                FFM_CRG_001_CODE = m.FFM_CRG_001_CODE,
                NAME = m.NAME,
                DISPLAY_STATUS = m.DISPLAY_STATUS,
                FFM_CRG_GROUP_CODE = m.FFM_CRG_GROUP_CODE,
            }).ToList();
        }

        public FFM_CRG_001_VM SaveFFM_CRG_001(FFM_CRG_001_VM CR)
        {
            return _FFMCRGRepo.SaveFM_CRG_001(CR);
        }
    }
}
