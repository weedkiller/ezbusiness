using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.PurchaseMgmt;

namespace EzBusiness_DL_Interface
{
    public interface IPurchaseMgmtORepository
    {
        #region Purchase order
        List<ProjectMaster> GetProjects(string CmpyCode);
        List<Product> GetItemCodeList(string CmpyCode, string restyp);

        PurchaseOrderDetailnew GetItemCodeDescription(string CmpyCode, string itemCode, string restyp);

        List<Location> GetLocationList(string CmpyCode);

        List<Employee> GetRequesterList(string CmpyCode);


        List<CommonTable> GetPOFromList(string Type);

        List<ExchangeRates> GetCurList(string CmpyCode);

        List<Division> GetDivisionList(string CmpyCode);

        List<Supplier> GetSupplierList(string Cmpycode);

        PurchaseOrderVM SavePurchaseOrder(PurchaseOrderVM purchaseOrder);

        List<POHeader> GetPurchaseOrderList(string CmpyCode);

        PurchaseOrderVM GetPOMasterDetailsEdit(string CmpyCode, string POCode,string resttyp);

        List<PODetail> GetPODetailsList(string CmpyCode, string POCode);


        List<MReqHeader> GetPOReqList(string CmpyCode);

        List<MReqDetail> GetPOItemReqList(string CmpyCode, string MRCode);

        List<MReqHeader> GetPOItemReqDetList(string CmpyCode, string MRCode);


        PurchaseOrderVM GetPOItemReqListnew(string CmpyCode, string MRCode);
        bool DeletePurchaseOrder(string CmpyCode, string POCode);
        #endregion

    }
}
