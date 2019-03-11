using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.MaterialMgmt;
using EzBusiness_EF_Entity.MaterialMgmtEF;

namespace EzBusiness_DL_Interface.MaterialMgmtDLI
{
    public interface IGrnInwardRepository
    {

        List<ProjectMaster> GetProjects(string CmpyCode);
        List<Supplier> GetSupplierList(string Cmpycode);

        List<WorkOrderType> WONoList (string Cmpycode);

        List<ExchangeRates> GetCurList(string CmpyCode);

        GrnInwardVM SavePurchaseOrder(GrnInwardVM purchaseOrder);

        List<GrnInwardHeader> GetGrnInwardList(string CmpyCode);

        bool DeleteGrnInward(string CmpyCode, string POCode);

        GrnInwardVM SaveGrnInward(GrnInwardVM purchaseOrder);
    }
}
