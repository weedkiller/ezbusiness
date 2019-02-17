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
    public class PurchaseMgmtOService : IPurchaseMgmtOService
    {
        IPurchaseMgmtORepository _purchaseRepo;
        IMaterialMgmtService _materialService;

        

        public PurchaseMgmtOService()
        {
            _purchaseRepo = new PurchaseMgmtORepository();
            _materialService = new MaterialMgmtService();

        }
        public bool DeletePurchaseOrder(string CmpyCode, string POCode)
        {
            return _purchaseRepo.DeletePurchaseOrder(CmpyCode, POCode);
        }

        public PurchaseOrderDetailnew GetItemCodeDescription(string CmpyCode, string itemCode, string restyp)
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
        public List<PurchaseOrderDetailnew> GetPODetailsList(string CmpyCode, string POCode)
        {
            var poDetailsList = _purchaseRepo.GetPODetailsList(CmpyCode, POCode);

            return poDetailsList.Select(m => new PurchaseOrderDetailnew
            {
                ItemCode = m.ItemCode,
                Description = m.Description,
                Quantity = m.QtyOrdered,
                Specification = m.Specification,
                Unit = m.Unit,
                ItemPrice=m.UnitPrice,
                ItemPriceTotal=m.ItemTotal,
                Discper=m.DiscountP,
                DiscAmt=m.Discount,
                NetAmt=m.NetAmount,
                LocalAmt=m.LNetAmount
                
                
            }).ToList();
        }

        public PurchaseOrderVM GetPOMasterDetailsEdit(string CmpyCode, string POCode,string resttyp)
        {

            var poEdit = _purchaseRepo.GetPOMasterDetailsEdit(CmpyCode, POCode, resttyp);
           poEdit.ItemCodeList = GetItemCodeList(CmpyCode, resttyp);
            poEdit.POfromList = GetPOFromList("POType");
            poEdit.POReqList = GetPOReqList(CmpyCode);           
           
            poEdit.ProjectList = GetProjects(CmpyCode);           
            poEdit.LocationList = GetLocationList(CmpyCode);
            poEdit.RequesterList = GetRequesterList(CmpyCode);
            poEdit.SupplierList = GetSupplierList(CmpyCode);
            poEdit.DivisionCodeList = GetDivisionList(CmpyCode);
            poEdit.CurList = GetCurList(CmpyCode);
            
            poEdit.PODetail = new PurchaseOrderDetailnew();
            poEdit.PurchaseOrderDetailsnew = GetPODetailsList(CmpyCode, POCode);
            poEdit.UnitList = GetUnits(CmpyCode);
            poEdit.IsEditMode = true;
          
           
           // poEdit.PurchaseOrderDetailsnew = GetPOItemReqList(CmpyCode, POCode);


            return poEdit;
        }

        public List<SelectListItem> GetProjects(string CmpyCode)
        {
            var projects = _purchaseRepo.GetProjects(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                       .ToList();
            return InsertFirstElementDDL(projects);
        }

        public List<PurchaseOrderVM> GetPurchaseOrderList(string CmpyCode)
        {
            return _purchaseRepo.GetPurchaseOrderList(CmpyCode).Select(m => new PurchaseOrderVM
            {
                CmpyCode = m.CmpyCode,
                PONumber = m.PONumber,
                Dates = m.Dates,
                
                LocCode = m.LocCode,
                ProjectCode = m.ProjectCode,
           
                PreparedBy = m.PreparedBy,
                ResourceType = m.ResourceType
            }).ToList();
        }

        public List<SelectListItem> GetRequesterList(string CmpyCode)
        {
            var EmpList = _purchaseRepo.GetRequesterList(CmpyCode)
                                        .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                        .ToList();
            return InsertFirstElementDDL(EmpList);
        }

        public List<SelectListItem> GetSupplierList(string Cmpycode)
        {
            var locationList = _purchaseRepo.GetSupplierList(Cmpycode)
                                      .Select(m => new SelectListItem { Value = m.Suppliercode, Text = string.Concat(m.Suppliercode, " - ", m.Name) })
                                      .ToList();
            return InsertFirstElementDDL(locationList);
        }

        public PurchaseOrderVM SavePurchaseOrder(PurchaseOrderVM purchaseOrder)
        {
            return _purchaseRepo.SavePurchaseOrder(purchaseOrder);
        }

        public PurchaseOrderVM GetPOMasterDetailsNew(string CmpyCode)
        {
            return new PurchaseOrderVM
            {
                ProjectList = GetProjects(CmpyCode),
                ItemCodeList = GetItemCodeList(CmpyCode, "M"),
                LocationList = GetLocationList(CmpyCode),
                RequesterList = GetRequesterList(CmpyCode),
                SupplierList = GetSupplierList(CmpyCode),
                DivisionCodeList = GetDivisionList(CmpyCode),
                CurList = GetCurList(CmpyCode),
                POfromList=GetPOFromList("POType"),
                POReqList=GetPOReqList(CmpyCode),
                PurchaseOrderDetailsnew = new List<PurchaseOrderDetailnew>(),
                PODetail = new PurchaseOrderDetailnew(),
                UnitList = GetUnits(CmpyCode),
                IsEditMode = false
            };
        }

       

        public List<SelectListItem> GetPOFromList(string Type)
        {
            var POfromList = _purchaseRepo.GetPOFromList(Type)
                                       .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                       .ToList();
            return InsertFirstElementDDL(POfromList);
        }

        public List<SelectListItem> GetCurList(string CmpyCode)
        {
            var CurList = _purchaseRepo.GetCurList(CmpyCode)
                                     .Select(m => new SelectListItem { Value = m.CurCode, Text = string.Concat(m.CurCode, " - ", m.CurName," - ", m.CurRate.ToString()) })
                                     .ToList();
            return InsertFirstElementDDL(CurList);
        }
       
        public List<SelectListItem> GetDivisionList(string CmpyCode)
        {
            var DivisionList = _purchaseRepo.GetDivisionList(CmpyCode)
                                     .Select(m => new SelectListItem { Value = m.DivisionCode, Text = string.Concat(m.DivisionCode, " - ", m.DivisionName) })
                                     .ToList();
            return InsertFirstElementDDL(DivisionList);
        }

      

        public List<SelectListItem> GetPOReqList(string CmpyCode)
        {
            var POReqList = _purchaseRepo.GetPOReqList(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.MRCode, Text = string.Concat(m.MRCode," - ",m.Dates," - ",m.EmpCode," - ",m.LocCode) })
                                       .ToList();
            return InsertFirstElementDDL(POReqList);
        }

        public List<MReqHeader> GetPOItemReqDetList(string CmpyCode, string MRCode)
        {
            var poDetailsList = _purchaseRepo.GetPOItemReqDetList(CmpyCode, MRCode);
            return poDetailsList.Select(m => new MReqHeader
            {
                ResourceType = m.ResourceType,
                LocCode=m.LocCode,
                EmpCode=m.EmpCode,
                ProjectCode=m.ProjectCode,
                //POReq = m.MRCode,
                //POFrom="M"

            }).ToList();


        }

        public List<PurchaseOrderDetailnew> GetPOItemReqList(string CmpyCode, string MRCode)
        {
            var poDetailsList = _purchaseRepo.GetPOItemReqList(CmpyCode, MRCode);
            return poDetailsList.Select(m => new PurchaseOrderDetailnew
            {
                ItemCode = m.ItemCode,
                Description = m.Description,
                Quantity = m.Qty,
                Specification = m.Specification,
                Unit = m.Unit
            }).ToList();
        }

        public PurchaseOrderVM GetPOItemReqListnew(string CmpyCode,string MRCode)
        {
            var poEdit = _purchaseRepo.GetPOItemReqListnew(CmpyCode, MRCode);

            poEdit.ProjectList = GetProjects(CmpyCode);
            poEdit.ItemCodeList = GetItemCodeList(CmpyCode, "M");
            poEdit.LocationList = GetLocationList(CmpyCode);
            poEdit.RequesterList = GetRequesterList(CmpyCode);
            poEdit.SupplierList = GetSupplierList(CmpyCode);
            poEdit.DivisionCodeList = GetDivisionList(CmpyCode);
            poEdit.CurList = GetCurList(CmpyCode);
            poEdit.POfromList = GetPOFromList("POType");
            poEdit.MReqDetail = new PurchaseOrderDetailnew();
            poEdit.UnitList = GetUnits(CmpyCode);




            poEdit.POReqList = GetPOReqList(CmpyCode);
            poEdit.PurchaseOrderDetailsnew = GetPOItemReqList(CmpyCode, MRCode);


            //poEdit.PurchaseOrderDetailsnew = new List<PurchaseOrderDetailnew>();

            return poEdit;
        }
    }
}
