using EzBusiness_BL_Interface.FreightManagementBLI.SEA_Export;
using EzBusiness_DL_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System.Web.Mvc;
using EzBusiness_DL_Interface.FreightManagementDLI.SEA_Export;
using EzBusiness_DL_Repository.FreightManagementDLR.SEA_Export;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service.FreightManagementBLS.SEA_Export
{ 
    public class FF_QTNService : IFF_QTNService
    {

        IFF_QTNRepository _FF_QTNRepo;
        public FF_QTNService()
        {
            _FF_QTNRepo = new FF_QTNRepository();

        }
        DropListFillFun drop = new DropListFillFun();
        public bool DeleteFF_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName)
        {
            throw new NotImplementedException();
        }

        public List<FF_QTN001> GetFF_QTN(string CmpyCode)
        {
            throw new NotImplementedException();
        }

        public List<FF_QTN002New> GetFF_QTN002DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            throw new NotImplementedException();
        }

        public List<FF_QTN003New> GetFF_QTN003DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            throw new NotImplementedException();
        }

        public List<FF_QTN004New> GetFF_QTN004DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            throw new NotImplementedException();
        }

        public List<FF_QTN005New> GetFF_QTN005DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            throw new NotImplementedException();
        }

        public FF_QTN_VM GetFF_QTNDetailsEdit(string CmpyCode, string FF_QTN001_CODE)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetMoveCode(string CmpyCode)
        {
            var CurrencyList = _FF_QTNRepo.GetMOVEList(CmpyCode)
                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                          .ToList();
            return InsertFirstElementDDL(CurrencyList);
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

        public FF_QTN_VM SaveFF_QTN_VM(FF_QTN_VM FQV)
        {
            throw new NotImplementedException();
        }
    }
}
