using EzBusiness_BL_Interface.FinanceManagementBLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_ViewModels.Models.FinaceMgmt;
using System.Web.Mvc;
using EzBusiness_DL_Interface.FinanceManagementDLI;
using EzBusiness_DL_Repository.FinanceManagementDLR;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service.FinanceManagementBLS
{
    public class FNM_SL1001Service : IFNM_SL1001Service
    {

        IFNM_SL1001Repository _FNM_SL1001Rep;

        public FNM_SL1001Service()
        {
            _FNM_SL1001Rep = new FNM_SL1001Repository();
        }

        public bool DeleteFNM_SL1001(string CmpyCode, string FNM_SL1001_CODE, string UserName)
        {
            return _FNM_SL1001Rep.DeleteFNM_SL1001(CmpyCode, FNM_SL1001_CODE, UserName);
        }

        public FNM_SL_VM EditFNM_SL(string CmpyCode, string FNM_SL1001_CODE)
        {
            var FNM_SLEdit = _FNM_SL1001Rep.EditFNM_SL(CmpyCode, FNM_SL1001_CODE);
            FNM_SLEdit.Currency_codeList = GetFNMCURRENCY();
            //FNM_SLEdit.SUBLEDGER_TYPE = FNM_SLEdit.SUBLEDGER_TYPE;
            FNM_SLEdit.SUBLEDGER_TYPEList = GetFNMCAT(CmpyCode, FNM_SLEdit.SUBLEDGER_TYPE);
            FNM_SLEdit.FNM_SL1002Details = GetFNMSL002DetailList(CmpyCode, FNM_SL1001_CODE);
            return FNM_SLEdit;
        }

        public List<SelectListItem> GetFNMCAT(string CmpyCode, string type1)
        {
            var itemCodes = _FNM_SL1001Rep.GetFNMCAT(CmpyCode, type1)
                                         .Select(m => new SelectListItem { Value = m.FNMSLCAT_CODE, Text = string.Concat(m.FNMSLCAT_CODE, " - ", m.DESCRIPTION) })
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetFNMCURRENCY()
        {
            var itemCodes = _FNM_SL1001Rep.GetCURRENCYList()
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

        public List<FNM_SL1002DetailNew> GetFNMSL002DetailList(string CmpyCode, string FNM_SL1001_CODE)
        {
            return _FNM_SL1001Rep.GetFNM_SL1002(CmpyCode,FNM_SL1001_CODE).Select(m => new FNM_SL1002DetailNew
            {
                CMPYCODE = m.CMPYCODE,
               NAME=m.NAME,
               COA_CODE=m.COA_CODE,
               FNM_SL1002_CODE=m.FNM_SL1002_CODE,
               FNM_SL1001_CODE=m.FNM_SL1001_CODE,
               DIVISION=m.DIVISION,
               COA_NAME=m.COA_NAME

            }).ToList();
        }

        public List<FNM_SL_VM> GetFNM_SL(string CmpyCode, string SubledgerType)
        {
            return _FNM_SL1001Rep.GetFNM_SL(CmpyCode, SubledgerType).Select(m => new FNM_SL_VM
            {
                CMPYCODE = m.CMPYCODE,
               Address=m.Address,
               Contact1=m.Contact1,
               Contact2=m.Contact2,
               Contact3=m.Contact3,
               credit_limit=m.credit_limit,
               Currency_code=m.Currency_code,
               Email=m.Email,
               Name=m.Name,
               Print_Name=m.Print_Name,
               Fax=m.Fax,
               Web_site=m.Web_site,
               SUBLEDGER_TYPE=m.SUBLEDGER_TYPE,
               Tel=m.Tel,               
                FNM_SL1001_CODE = m.FNM_SL1001_CODE,
                DIVISION = m.DIVISION
            }).ToList();
        }

        public FNM_SL_VM GetFNM_SLAddNew(string Cmpycode)
        {
            return new FNM_SL_VM
            {
                Currency_codeList = GetFNMCURRENCY(),
                SUBLEDGER_TYPEList= GetFNMCAT(Cmpycode,"FM"),

                EditFlag = false
            };
        }

        public FNM_SL_VM SaveFNM_SL(FNM_SL_VM ac)
        {
            return _FNM_SL1001Rep.SaveFNM_SL(ac);
        }

        public List<FNM_SL1002DetailNew> GetFNM_SL1002Add(string CmpyCode, string FNMCAT_CODE)
        {
            return _FNM_SL1001Rep.GetFNM_SL1002Add(CmpyCode, FNMCAT_CODE).Select(m => new FNM_SL1002DetailNew
            {
                CMPYCODE = m.CMPYCODE,
                NAME = m.NAME,
                COA_CODE = m.COA_CODE,
                FNM_SL1002_CODE = m.FNM_SL1002_CODE,
                FNM_SL1001_CODE = m.FNM_SL1001_CODE,
                DIVISION = m.DIVISION,
                COA_NAME=m.COA_NAME

            }).ToList();
        }

        //public List<FNM_SL1002DetailNew> GetCatDropDetailListFilter(string CmpyCode, string FNMCAT_CODE)
        //{
        //    if (FNMCAT_CODE == "FM")
        //    {
        //        return _FNM_SL1001Rep.GetFNM_SL1002(CmpyCode, FNMCAT_CODE).Where(x => x.FNM_SL1002_CODE.ToString() == "ARP" || x.FNM_SL1002_CODE.ToString() == "AAP").Select(m => new FNM_SL1002DetailNew
        //        {
        //            CMPYCODE = m.CMPYCODE,
        //            NAME = m.NAME,
        //            COA_CODE = m.COA_CODE,
        //            FNM_SL1002_CODE = m.FNM_SL1002_CODE,
        //            FNM_SL1001_CODE = m.FNM_SL1001_CODE,
        //            DIVISION = m.DIVISION

        //        }).ToList();
        //    }
        //    else
        //    {
        //        return _FNM_SL1001Rep.GetFNM_SL1002(CmpyCode, FNMCAT_CODE).Where(x => x.FNM_SL1002_CODE.ToString() != "ARP" || x.FNM_SL1002_CODE.ToString() != "AAP").Select(m => new FNM_SL1002DetailNew
        //        {
        //            CMPYCODE = m.CMPYCODE,
        //            NAME = m.NAME,
        //            COA_CODE = m.COA_CODE,
        //            FNM_SL1002_CODE = m.FNM_SL1002_CODE,
        //            FNM_SL1001_CODE = m.FNM_SL1001_CODE,
        //            DIVISION = m.DIVISION

        //        }).ToList();
        //    }
           
        //}
    }
}
