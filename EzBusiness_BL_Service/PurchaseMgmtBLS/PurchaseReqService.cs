using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.PurchaseMgmt;
using System.Web.Mvc;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service
{
    public class PurchaseReqService : IPurchaseReqService
    {

        IPurchaseReqRepository _purchaseRepo;
        IMaterialMgmtService _materialService;
        public PurchaseReqService()
        {
            _purchaseRepo = new PurchaseReqRepository();
            _materialService = new MaterialMgmtService();
        }

        public bool DeletePurchaseOrder(string CmpyCode, string MRCode)
        {
            return _purchaseRepo.DeletePurchaseOrder(CmpyCode, MRCode);
        }

        public PurchaseOrderDetail GetItemCodeDescription(string CmpyCode, string itemCode,string restyp)
        {
            return _purchaseRepo.GetItemCodeDescription(CmpyCode, itemCode, restyp);
        }

        public List<SelectListItem> GetItemCodeList(string CmpyCode, string restyp)
        {
            var itemCodes = _purchaseRepo.GetItemCodeList(CmpyCode, restyp)
                                        .Select(m => new SelectListItem { Value = m.ItemCode, Text = m.ItemCode })
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
       
        public List<SelectListItem> GetLocationList(string CmpyCode)
        {
            var locationList = _purchaseRepo.GetLocationList(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.LocCode, Text = string.Concat(m.LocCode, " - ", m.LocName) })
                                       .ToList();
            return InsertFirstElementDDL(locationList);
        }

        private List<SelectListItem> GetUnits(string CmpyCode)
        {
            var units = _materialService.GetUnits(CmpyCode)
                                        .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                        .ToList();
            return InsertFirstElementDDL(units);
        }
        public PurchaseReqVM GetPOMasterDetailsEdit(string CmpyCode, string MRCode)
        {         

            var poEdit = _purchaseRepo.GetPOMasterDetailsEdit(CmpyCode, MRCode);
           
            poEdit.ProjectList = GetProjects(CmpyCode);
            poEdit.ItemCodeList = GetItemCodeList(CmpyCode, "M");
            poEdit.LocationList = GetLocationList(CmpyCode);
            poEdit.RequesterList = GetRequesterList(CmpyCode);            
            poEdit.UnitList = GetUnits(CmpyCode);
            poEdit.PurchaseOrderDetails = GetPODetailsList(CmpyCode, MRCode);
            poEdit.PODetail = new PurchaseOrderDetail();
            poEdit.IsEditMode = true;
            return poEdit;
        }

        private List<PurchaseOrderDetail> GetPODetailsList(string CmpyCode, string MRCode)
        {
            var poDetailsList = _purchaseRepo.GetPODetailsList(CmpyCode, MRCode);

            return poDetailsList.Select(m => new PurchaseOrderDetail
            {
                ItemCode = m.ItemCode,
                Description = m.Description,
                Quantity = m.Qty,
                Specification = m.Specification,
                Unit = m.Unit
            }).ToList();
        }
        public PurchaseReqVM GetPOMasterDetailsNew(string CmpyCode)
        {
            return new PurchaseReqVM
            {
                ProjectList = GetProjects(CmpyCode),
                ItemCodeList = GetItemCodeList(CmpyCode, "M"),
                LocationList = GetLocationList(CmpyCode),
                RequesterList = GetRequesterList(CmpyCode),
                PurchaseOrderDetails = new List<PurchaseOrderDetail>(),
                PODetail = new PurchaseOrderDetail(),
                UnitList = GetUnits(CmpyCode),
                IsEditMode = false
            };
        }

        public List<SelectListItem> GetProjects(string CmpyCode)
        {
            var projects = _purchaseRepo.GetProjects(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                       .ToList();
            return InsertFirstElementDDL(projects);
        }

        public List<PurchaseReqVM> GetPurchaseOrderList(string CmpyCode)
        {
            return _purchaseRepo.GetPurchaseOrderList(CmpyCode).Select(m => new PurchaseReqVM
            {
                CmpyCode = m.CmpyCode,
                MRCode = m.MRCode,
                PODate = m.Dates,
                Description = m.Description,
                LocationCode = m.LocCode,
                ProjectCode = m.ProjectCode,
                RequesterCode = m.EmpCode,
                PreparedBy = m.PreparedBy,
                ResourceType = m.ResourceType
            }).ToList();
        }

        public List<SelectListItem> GetRequesterList(string CmpyCode)
        {
            var requesterList = _purchaseRepo.GetRequesterList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                      .ToList();
            return InsertFirstElementDDL(requesterList);
        }

        public PurchaseReqVM SavePurchaseOrder(PurchaseReqVM purchaseReq)
        {
            return _purchaseRepo.SavePurchaseOrder(purchaseReq);
        }
    }
}
