using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.PurchaseMgmt;


namespace EzBusiness_DL_Interface
{
    public interface IPurchaseMgmtRepository
    {
        #region Purchase Request
        List<CostCenterHeader> GetProjects(string CmpyCode);
        List<Product> GetItemCodeList(string CmpyCode, string restyp);
       
        PurchaseOrderDetail GetItemCodeDescription(string CmpyCode, string itemCode, string restyp);

        List<Location> GetLocationList(string CmpyCode);

        List<Employee> GetRequesterList(string CmpyCode);

        PurchaseReqVM SavePurchaseOrder(PurchaseReqVM purchaseOrder);

        List<MReqHeader> GetPurchaseOrderList(string CmpyCode);

        PurchaseReqVM GetPOMasterDetailsEdit(string CmpyCode, string MRCode);

        List<MReqDetail> GetPODetailsList(string CmpyCode, string MRCode);



        bool DeletePurchaseOrder(string CmpyCode, string MRCode);

        #endregion


       



    }
}
