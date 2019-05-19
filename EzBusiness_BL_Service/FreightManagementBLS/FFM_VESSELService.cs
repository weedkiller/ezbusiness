using EzBusiness_BL_Interface.FreightManagementBLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Web.Mvc;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FFM_VESSELService : IFFM_VESSELService
    {

        IFFM_VESSELRepository _FFM_VESSELRepo;

        public FFM_VESSELService()
        {
            _FFM_VESSELRepo = new FFM_VESSELRepository();
        }

        public bool DeleteFFM_VESSEL(string FFM_VESSEL_CODE, string CmpyCode, string UserName)
        {
            return _FFM_VESSELRepo.DeleteFFM_VESSEL(FFM_VESSEL_CODE, CmpyCode, UserName);
        }

        public FFM_VESSEL_VM EditFFM_VESSEL(string CmpyCode, string FFM_VESSEL_CODE)
        {           
            var FFM_VESSELEdit = _FFM_VESSELRepo.EditFFM_VESSEL(CmpyCode, FFM_VESSEL_CODE);
            FFM_VESSELEdit.COUNTRYList = GetNationList(CmpyCode);
            FFM_VESSELEdit.ContainerList = GetContainer(CmpyCode);
           return FFM_VESSELEdit;
        }

        public List<SelectListItem> GetContainer(string CmpyCode)
        {
            var itemCodes = _FFM_VESSELRepo.GetContainer(CmpyCode)
                                           .Select(m => new SelectListItem { Value = m.FFM_CNTR_CODE, Text = string.Concat(m.FFM_CNTR_CODE, " - ", m.NAME) })
                                           .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<FFM_VESSEL_VM> GetFFM_VESSEL(string CmpyCode)
        {
            return _FFM_VESSELRepo.GetFFM_VESSEL(CmpyCode).Select(m => new FFM_VESSEL_VM
            {
                FFM_VESSEL_CODE = m.FFM_VESSEL_CODE,
                NAME = m.NAME,
                CARRIER=m.CARRIER,
                COUNTRY=m.COUNTRY,
                FLAG=m.FLAG,
                SCACCODE=m.SCACCODE,
                VESSEL_TYPE=m.VESSEL_TYPE,                
            }).ToList();
        }

        public FFM_VESSEL_VM GetFFM_VESSELAddNew(string Cmpycode)
        {
            return new FFM_VESSEL_VM
            {
                COUNTRYList=GetNationList(Cmpycode),
                ContainerList=GetContainer(Cmpycode),
               EditFlag = false
            };
        }

        public List<SelectListItem> GetNationList(string CmpyCode)
        {
            var itemCodes = _FFM_VESSELRepo.GetNationList(CmpyCode)
                                         .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public FFM_VESSEL_VM SaveFFM_VESSEL(FFM_VESSEL_VM ac)
        {
            return _FFM_VESSELRepo.SaveFFM_VESSEL(ac);
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

    }
}
