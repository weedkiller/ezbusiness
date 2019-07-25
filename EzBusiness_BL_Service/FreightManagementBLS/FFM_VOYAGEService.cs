using EzBusiness_BL_Interface.FreightManagementBLI;
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

      
        public IQueryable<SelectListItem> GetVessalCode(string CmpyCode,string Prefix)
        {
            //var CurrencyList = _FFM_VOYEGERepo.GetVessalCode(CmpyCode,Prefix)
            //                            .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.code, " - ", m.NAME) })
            //                            .ToList(); 
            //return CurrencyList;
            var CurrencyList = _FFM_VOYEGERepo.GetVessalCode(CmpyCode, Prefix)//.Where(m => m.FFM_CRG_JOB_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.FFM_CRG_JOB_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                          .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                          .AsQueryable();
            return CurrencyList;
        }
        public List<SelectListItem> GetPortList(string CmpyCode,string Prefix)
        {
            //var CurrencyList = _FFM_VOYEGERepo.GetPortList(CmpyCode,Prefix)
            //                            .Select(m => new SelectListItem { Value = m.FFM_PORT_CODE, Text = string.Concat(m.FFM_PORT_CODE, " - ", m.NAME) })
            //                            .ToList();
            //return InsertFirstElementDDL(CurrencyList);
            var CurrencyList = _FFM_VOYEGERepo.GetPortList(CmpyCode, Prefix)//.Where(m => m.FFM_CRG_JOB_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.FFM_CRG_JOB_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                       .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                       .ToList();
            return CurrencyList;

        }

        //public List<SelectListItem> GetVessalCodeEdit(string CmpyCode, string code)
        //{
        //    var CurrencyList = _FFM_VOYEGERepo.GetVessalCode(CmpyCode,Prefix)//.Where(m => m.Code.ToString() == code).ToList()
        //                                .Select(m => new SelectListItem { Value = m.CodeName, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                .ToList();
        //    return InsertFirstElementDDL(CurrencyList);

        //}

        //public List<SelectListItem> GetPortListEdit(string CmpyCode,string code,string Prefix)
        //{
        //    var CurrencyList = _FFM_VOYEGERepo.GetPortList(CmpyCode, Prefix)//.Where(m => m.FFM_PORT_CODE.ToString() == code).ToList()
        //                                .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
        //                                .ToList();
        //    return InsertFirstElementDDL(CurrencyList);
        //}
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
          //  poEdit.VessalCodeList = GetVessalCodeEdit(CmpyCode, poEdit.FFM_VESSEL_CODE);//GetVessalCode(CmpyCode);
          //  poEdit.PortList = GetPortList(CmpyCode);
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
        public List<FFM_VOYAGEANew> GetVayogeDetailList(string CmpyCode, string VyogCode)
        {
            var povoyagList = _FFM_VOYEGERepo.GetVayogeDetailList(CmpyCode, VyogCode);
            return povoyagList.Select(m => new FFM_VOYAGEANew
            {
                SNO = m.SNO,
                ROTATION = m.ROTATION,
                PORT = m.PORT,
                ETA = m.ETA,
                ETB = m.ETB,
                ETD = m.ETD,
                PortStayHours = m.PortStayHours,
                SailingHrs=m.SailingHrs,
              // PortList1= GetPortListEdit(CmpyCode,m.PORT)
            }).ToList();
        }
        public FFM_VOYAGE_VM AddVoyageMaster(string CmpyCode)
        {

            List<SessionListnew> list = HttpContext.Current.Session["SesDet"] as List<SessionListnew>;
            return new FFM_VOYAGE_VM
            {
                //VessalCodeList = GetVessalCode(CmpyCode),
                //PortList=GetPortList(CmpyCode),
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
