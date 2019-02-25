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
    public interface IPurchaseReqService
    {
        #region Purchase Request
        List<SelectListItem> GetProjects(string CmpyCode);

        List<SelectListItem> GetItemCodeList(string CmpyCode, string restyp);

        //List<SelectListItem> GetItemCodeList1(string CmpyCode, string restyp);

        PurchaseOrderDetail GetItemCodeDescription(string CmpyCode, string itemCode, string restyp);

        List<SelectListItem> GetLocationList(string CmpyCode);

        List<SelectListItem> GetRequesterList(string CmpyCode);

        PurchaseReqVM GetPOMasterDetailsNew(string CmpyCode);

        PurchaseReqVM SavePurchaseOrder(PurchaseReqVM purchaseReq);

        List<PurchaseReqVM> GetPurchaseOrderList(string CmpyCode);

        PurchaseReqVM GetPOMasterDetailsEdit(string CmpyCode, string MRCode);

        bool DeletePurchaseOrder(string CmpyCode, string MRCode);

        #endregion

    }
}
