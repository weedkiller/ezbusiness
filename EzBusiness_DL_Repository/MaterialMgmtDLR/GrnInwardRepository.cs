using EzBusiness_DL_Interface.MaterialMgmtDLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.MaterialMgmtEF;
using EzBusiness_ViewModels.Models.MaterialMgmt;
using System.Data;

namespace EzBusiness_DL_Repository.MaterialMgmtDLR
{
    public class GrnInwardRepository : IGrnInwardRepository
    {
        DataSet ds = null;
        DataTable dt = null;

        EzBusinessHelper _EzBusinessHelper = new EzBusinessHelper();
        DropListFillFun drop = new DropListFillFun();

        public bool DeleteGrnInward(string CmpyCode, string InNumber)
        {
            int unit = _EzBusinessHelper.ExecuteScalar("Select count(*) from PMGRNH001 where CmpyCode='" + CmpyCode + "' and GrnInNumber='" + InNumber + "'");
            if (unit != 0)
            {
                _EzBusinessHelper.ExecuteNonQuery("delete from PMGRND002 where CmpyCode='" + CmpyCode + "' and GrnInNumber='" + InNumber + "'");
                _EzBusinessHelper.ExecuteNonQuery("delete from PMGRNH001 where CmpyCode='" + CmpyCode + "' and GrnInNumber='" + InNumber + "'");
                return true;
            }
            return false;
        }

        public List<ExchangeRates> GetCurList(string CmpyCode)
        {
            return drop.GetCurrencyExchangeList(CmpyCode);
        }

        public List<GrnInwardHeader> GetGrnInwardList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PMGRNH001 where CmpyCode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<GrnInwardHeader> ObjList = new List<GrnInwardHeader>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new GrnInwardHeader()
                {
                    ResourceType = dr["ResourceType"].ToString(),
                    GrnInNumber=dr["GrnInNumber"].ToString(),
                    PartyCode=dr["PartyCode"].ToString(),
                    ProjectCode = dr["ProjectCode"].ToString(),
                    PartyName=dr["PartyName"].ToString()
                });
            }
            return ObjList;
        }

        public List<ProjectMaster> GetProjects(string CmpyCode)
        {
            return drop.GetProjects(CmpyCode);
        }
        public List<WorkOrderType> WONoList(string CmpyCode)
        {
            ds = _EzBusinessHelper.ExecuteDataSet("Select * from PMGRNH001 where CmpyCode='" + CmpyCode + "'");
            dt = ds.Tables[0];
            DataRowCollection drc = dt.Rows;
            List<WorkOrderType> ObjList = new List<WorkOrderType>();
            foreach (DataRow dr in drc)
            {
                ObjList.Add(new WorkOrderType()
                {
                    Code=dr["Code"].ToString(),
                    Name=dr["Name"].ToString(),
                    
                    

                });
            }
            return ObjList;
        }

        public List<Supplier> GetSupplierList(string Cmpycode)
        {
            throw new NotImplementedException();
        }

        public GrnInwardVM SaveGrnInward(GrnInwardVM purchaseOrder)
        {
            throw new NotImplementedException();
        }

        public GrnInwardVM SavePurchaseOrder(GrnInwardVM purchaseOrder)
        {
            throw new NotImplementedException();
        }
    }
}
