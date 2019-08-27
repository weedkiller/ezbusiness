using EzBusiness_BL_Interface.FreightManagementBLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Web.Mvc;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FNM_CURR_RATEService : IFNM_CURR_RATEService
    {

        IFNM_CURR_RATERepository _FNM_CURR_RATERep;

        public FNM_CURR_RATEService()
        {
            _FNM_CURR_RATERep = new FNM_CURR_RATERepository();
        }


        public bool DeleteFNM_CURR_RATE(string CmpyCode, string FROM_CURRENCY_CODE, DateTime ENTRY_DATE, string UserName)
        {
            return _FNM_CURR_RATERep.DeleteFNM_CURR_RATE(CmpyCode,FROM_CURRENCY_CODE, ENTRY_DATE, UserName);
        }

        public FNM_CURR_RATE_VM EditFNM_CURR_RATE(string CmpyCode, string FROM_CURRENCY_CODE, DateTime ENTRY_DATE)
        {
            var FNM_AC_COAEdit = _FNM_CURR_RATERep.EditFNM_CURR_RATE(CmpyCode, FROM_CURRENCY_CODE,ENTRY_DATE);
            //FNM_AC_COAEdit.FROM_CURRENCY_CODEList   = GetFNMCURRENCY();
            FNM_AC_COAEdit.FROM_CURRENCY_CODEList = GetFNMCURRENCYEDIT(FNM_AC_COAEdit.FROM_CURRENCY_CODE);
            FNM_AC_COAEdit.TO_CURRENCY_CODEList = GetFNMCURRENCYEDIT(FNM_AC_COAEdit.TO_CURRENCY_CODE);
            FNM_AC_COAEdit.FNM_CURRENCYRateDetailNew = GetCURRENCYRateDetailList1(CmpyCode,FROM_CURRENCY_CODE, ENTRY_DATE);  
            return FNM_AC_COAEdit;
        }

        public List<SelectListItem> GetFNMCURRENCY()
        {
            var itemCodes = _FNM_CURR_RATERep.GetFNMCURRENCY()
                                          .Select(m => new SelectListItem { Value = m.CURRENCY_CODE, Text = string.Concat(m.CURRENCY_CODE, " - ", m.CURRENCY_NAME) })
                                          .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetFNMCURRENCYEDIT(string Code)
        {
            var itemCodes = _FNM_CURR_RATERep.GetFNMCURRENCY().Where(m => m.CURRENCY_CODE.ToString() == Code).ToList()
                                          .Select(m => new SelectListItem { Value = m.CURRENCY_CODE, Text = string.Concat(m.CURRENCY_CODE, " - ", m.CURRENCY_NAME) })
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
        public List<FNM_CURR_RATE_VM> GetFNM_CURR_RATE(string CmpyCode)
        {
            return _FNM_CURR_RATERep.GetFNM_CURR_RATE(CmpyCode).Select(m => new FNM_CURR_RATE_VM
            {
                CMPYCODE = m.CMPYCODE,
                BUY_RATE = m.BUY_RATE,
                FROM_CURRENCY_CODE = m.FROM_CURRENCY_CODE,
                TO_CURRENCY_CODE = m.TO_CURRENCY_CODE,
                Note = m.Note,
                SELL_RATE = m.SELL_RATE,
                MASTER_STATUS = m.MASTER_STATUS,
                ENTRY_DATE=m.ENTRY_DATE,
                Branch_code = m.Branch_code
               
            }).ToList();
        }

        public FNM_CURR_RATE_VM GetFNM_CURR_RATEAddNew(string Cmpycode)
        {
            return new FNM_CURR_RATE_VM
            {
                FROM_CURRENCY_CODEList = GetFNMCURRENCY(),
               
                EditFlag = false
            };
        }

        public FNM_CURR_RATE_VM SaveFNM_CURR_RATE(FNM_CURR_RATE_VM ac)
        {
            return _FNM_CURR_RATERep.SaveFNM_CURR_RATE(ac);
        }

        public List<FNM_CURRENCYRateDetailNew> GetCURRENCYRateDetailList(string CmpyCode, string FROM_CURRENCY_CODE)
        {
            return _FNM_CURR_RATERep.GetCURRENCYRateDetailList(CmpyCode,FROM_CURRENCY_CODE).Select(m => new FNM_CURRENCYRateDetailNew
            {
                BUY_RATE=m.BUY_RATE,
                SELL_RATE=m.SELL_RATE,
                ENTRY_DATE=m.ENTRY_DATE
            }).ToList();
        }

        public List<FNM_CURRENCYRateDetailNew> GetCURRENCYRateDetailList1(string CmpyCode, string FROM_CURRENCY_CODE,DateTime ENTRY_DATE1)
        {
            return _FNM_CURR_RATERep.GetCURRENCYRateDetailList(CmpyCode, FROM_CURRENCY_CODE).Where(x => x.ENTRY_DATE.ToString("d/M/yyyy") != ENTRY_DATE1.ToString("d/M/yyyy")).Select(m => new FNM_CURRENCYRateDetailNew
            {
                BUY_RATE = m.BUY_RATE,
                SELL_RATE = m.SELL_RATE,
                ENTRY_DATE = m.ENTRY_DATE
            }).ToList();
        }
    }
}
