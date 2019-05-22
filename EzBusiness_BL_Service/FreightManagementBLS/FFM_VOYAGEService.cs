﻿using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface;
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
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FFM_VOYAGEService : IFFM_VOYAGEServices
    {
        IFFM_VOYAGERepository _FFM_VOYEGERepo;
        public FFM_VOYAGEService()
        {
            _FFM_VOYEGERepo = new FFM_VOYAGERepository();

        }
        public List<FFM_VOYAGE_VM> GetFFM_VoYAGEAList(string CMPYCODE)
        {
            return _FFM_VOYEGERepo.GetFFM_VoYAGEAList(CMPYCODE).Select(m => new FFM_VOYAGE_VM
            {
                //PRSM001UID = m.PRSM001UID,
               FFM_VESSEL_CODE=m.FFM_VESSEL_CODE,
               NAME=m.NAME,
               FFM_VOYAGE01_CODE=m.FFM_VOYAGE01_CODE,
               DISPLAY_STATUS=m.DISPLAY_STATUS
               
            }).ToList();
        }
        public FFM_VOYAGE_VM SaveFFM_Voyage(FFM_VOYAGE_VM FCur)
        {
            return _FFM_VOYEGERepo.SaveFFM_Voyage(FCur);
        }

      
        public List<SelectListItem> GetVessalCode(string CmpyCode)
        {
            var CurrencyList = _FFM_VOYEGERepo.GetVessalCode(CmpyCode)
                                        .Select(m => new SelectListItem { Value = m.FFM_VESSEL_CODE, Text = string.Concat(m.FFM_VESSEL_CODE, " - ", m.NAME) })
                                        .ToList();
            return InsertFirstElementDDL(CurrencyList);
        }
        public List<SelectListItem> GetPortList(string CmpyCode)
        {
            var CurrencyList = _FFM_VOYEGERepo.GetPortList(CmpyCode)
                                        .Select(m => new SelectListItem { Value = m.FFM_PORT_CODE, Text = string.Concat(m.FFM_PORT_CODE, " - ", m.NAME) })
                                        .ToList();
            return InsertFirstElementDDL(CurrencyList);
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

        public FFM_VOYAGE_VM EditVoyagMaster(string CmpyCode, string VyogCode)
        {
          
            var poEdit = _FFM_VOYEGERepo.EditVoyagMaster(CmpyCode,VyogCode);
            poEdit.VessalCodeList = GetVessalCode(CmpyCode);
            poEdit.PortList = GetPortList(CmpyCode);
            poEdit.newdetails = GetVayogeDetailList(CmpyCode, VyogCode);   
            return poEdit;    
        }
        //public List<SelectListItem> GetVayogeDetailList(string CmpyCode)
        //{
        //    var itemCodes = _FFM_VOYEGERepo.GetDivCodeList(CmpyCode)
        //                             .Select(m => new SelectListItem { Value = m.DivisionCode, Text = string.Concat(m.DivisionCode, " - ", m.DivisionName) })
        //                             .ToList();

        //    return InsertFirstElementDDL(itemCodes);
        //}
        public List<FFM_VOYAGEA> GetVayogeDetailList(string CmpyCode, string VyogCode)
        {
            var povoyagList = _FFM_VOYEGERepo.GetVayogeDetailList(CmpyCode, VyogCode);
            return povoyagList.Select(m => new FFM_VOYAGEA
            {
                SNO = m.SNO,
                ROTATION = m.ROTATION,
                PORT = m.PORT,
                ETA = m.ETA,
                ETB = m.ETB,
                ETD = m.ETD,
                PortStayHours = m.PortStayHours,
                SailingHrs=m.SailingHrs,
               
            }).ToList();
        }
        public FFM_VOYAGE_VM AddVoyageMaster(string CmpyCode)
        {

            List<SessionListnew> list = HttpContext.Current.Session["SesDet"] as List<SessionListnew>;
            return new FFM_VOYAGE_VM
            {
                VessalCodeList = GetVessalCode(CmpyCode),
                PortList=GetPortList(CmpyCode),
            };
        }

        public bool DeleteVoyagMaster(string CmpyCode, string VoyageCode, string UserName)
        {
            return _FFM_VOYEGERepo.DeleteVoyagMaster(CmpyCode, VoyageCode, UserName);
        }

        public string GetNameByVessalCode(string VessalCode, string cmpyCode)
        {
            return _FFM_VOYEGERepo.GetNameByVessalCode(VessalCode, cmpyCode);
        }
    }
    
}
