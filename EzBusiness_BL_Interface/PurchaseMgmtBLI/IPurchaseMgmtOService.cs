using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.PurchaseMgmt;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
    public interface IPurchaseMgmtOService
    {
        List<SelectListItem> GetProjects(string CmpyCode);
        List<SelectListItem> GetItemCodeList(string CmpyCode, string restyp);

        PurchaseOrderDetailnew GetItemCodeDescription(string CmpyCode, string itemCode, string restyp);

        List<SelectListItem> GetLocationList(string CmpyCode);

        List<SelectListItem> GetRequesterList(string CmpyCode);

        List<SelectListItem> GetPOFromList(string Type);

        List<SelectListItem> GetCurList(string CmpyCode);

        List<SelectListItem> GetDivisionList(string CmpyCode);

        List<SelectListItem> GetSupplierList(string Cmpycode);

        PurchaseOrderVM GetPOMasterDetailsNew(string CmpyCode);

        PurchaseOrderVM SavePurchaseOrder(PurchaseOrderVM purchaseReq);

        List<PurchaseOrderVM> GetPurchaseOrderList(string CmpyCode);

        PurchaseOrderVM GetPOMasterDetailsEdit(string CmpyCode, string MRCode,string resttyp);
        //List<MReqDetail> GetPOItemReqList(string CmpyCode, string MRCode);

        List<SelectListItem> GetPOReqList(string CmpyCode);
        bool DeletePurchaseOrder(string CmpyCode, string POCode);

        List<MReqHeader> GetPOItemReqDetList(string CmpyCode, string MRCode);

        PurchaseOrderVM GetPOItemReqListnew(string CmpyCode, string MRCode);

        

    }
}
