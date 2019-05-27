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
            return _FF_QTNRepo.DeleteFF_QTN(CmpyCode, FF_QTN001_CODE, UserName);
        }

        public List<FF_QTN001> GetFF_QTN(string CmpyCode)
        {
            return _FF_QTNRepo.GetFF_QTN(CmpyCode);
        }

        public List<FF_QTN002New> GetFF_QTN002DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            var FF_QTN002DetailList = _FF_QTNRepo.GetFF_QTN002DetailList(CmpyCode, FF_QTN001_CODE);
            return FF_QTN002DetailList.Select(m => new FF_QTN002New
            {
                CBM = m.CBM,
                CFT = m.CFT,
                Container=m.Container,
                Contents=m.Contents,
                Cont_Type=m.Cont_Type,
                KG=m.KG,
                LBS=m.LBS,
                No_of_qty=m.No_of_qty,
                Seal1=m.Seal1,
                sno=m.sno

            }).ToList();
        }

        public List<FF_QTN003New> GetFF_QTN003DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            var FF_QTN003DetailList = _FF_QTNRepo.GetFF_QTN003DetailList(CmpyCode, FF_QTN001_CODE);
            return FF_QTN003DetailList.Select(m => new FF_QTN003New
            {
               Act_LBS=m.Act_LBS,
               Dime_weight=m.Dime_weight,
               Height=m.Height,
               inside_Unit=m.inside_Unit,
               No_of_qty=m.No_of_qty,
               Pkg_No=m.Pkg_No,
               Sno=m.Sno,
               unit_type=m.unit_type,
               Volume=m.Volume,
               Width=m.Width

            }).ToList();
        }

        public List<FF_QTN004New> GetFF_QTN004DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            var FF_QTN004DetailList = _FF_QTNRepo.GetFF_QTN004DetailList(CmpyCode, FF_QTN001_CODE);
            return FF_QTN004DetailList.Select(m => new FF_QTN004New
            {
            CLUASE_CODE=m.CLUASE_CODE,
            CLUASE_NAME=m.CLUASE_NAME

            }).ToList();
        }

        public List<FF_QTN005New> GetFF_QTN005DetailList(string CmpyCode, string FF_QTN001_CODE)
        {
            var FF_QTN005DetailList = _FF_QTNRepo.GetFF_QTN005DetailList(CmpyCode, FF_QTN001_CODE);
            return FF_QTN005DetailList.Select(m => new FF_QTN005New
            {
                Crg_code = m.Crg_code,
                Crg_name = m.Crg_name,
                Cust_code=m.Cust_code,
                Cust_Ctrl_Act=m.Cust_Ctrl_Act,
                Cust_Curr_Code=m.Cust_Curr_Code,
                Cust_Curr_Rate=m.Cust_Curr_Rate,
                Cust_Local_amt=m.Cust_Local_amt,
                Cust_name=m.Cust_name,
                Cust_Net_Amt=m.Cust_Net_Amt,
                Cust_Rate=m.Cust_Rate,
                Cust_Total_amt=m.Cust_Total_amt,
                Cust_Var_Amt=m.Cust_Var_Amt,
                Expense_GL_Code=m.Expense_GL_Code,
                Income_GL_Code=m.Income_GL_Code,
                PAY_MODE=m.PAY_MODE,
                Sno=m.Sno,
                Unit_Code=m.Unit_Code,
                VendVar_Amt=m.VendVar_Amt,
                Vend_code=m.Vend_code,
                Vend_Ctrl_Act=m.Vend_Ctrl_Act,
                Vend_Curr_Code=m.Vend_Curr_Code,
                Vend_Curr_Rate=m.Vend_Curr_Rate,
                Vend_Local_amt=m.Vend_Local_amt,
                Vend_name=m.Vend_name,
                Vend_Net_Amt=m.Vend_Net_Amt,
                Vend_Rate=m.Vend_Rate,
                Vend_Total_amt=m.Vend_Total_amt

            }).ToList();
        }

        public FF_QTN_VM GetFF_QTNDetailsEdit(string CmpyCode, string FF_QTN001_CODE)
        {
            var poEdit = _FF_QTNRepo.GetFF_QTNDetailsEdit(CmpyCode, FF_QTN001_CODE);
            poEdit.FF_QTN002Detail = GetFF_QTN002DetailList(CmpyCode, FF_QTN001_CODE);
            poEdit.FF_QTN003Detail = GetFF_QTN003DetailList(CmpyCode, FF_QTN001_CODE);
            poEdit.FF_QTN004Detail = GetFF_QTN004DetailList(CmpyCode, FF_QTN001_CODE);
            poEdit.FF_QTN005Detail = GetFF_QTN005DetailList(CmpyCode, FF_QTN001_CODE);
            poEdit.DEPARTMENTList = GetDepart(CmpyCode);
            poEdit.MoveCodeList = GetMoveCode(CmpyCode);
            poEdit.CLAUSEList = GetCLAUSE(CmpyCode);
            poEdit.CRG_002List = GetCRG_002(CmpyCode);
            poEdit.SLList = GetSL(CmpyCode);
            poEdit.VESSELList = GetVESSELList(CmpyCode);
            poEdit.VOYAGEList = GetVOYAGEList(CmpyCode);
            poEdit.EditFlag = true;
            return poEdit;
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
            return _FF_QTNRepo.SaveFF_QTN_VM(FQV);
        }

        public List<SelectListItem> GetDepart(string CmpyCode)
        {
            var DepartList = _FF_QTNRepo.GetDepart(CmpyCode)
                                          .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                          .ToList();
            return InsertFirstElementDDL(DepartList);
        }

        public List<SelectListItem> GetVESSELList(string CmpyCode)
        {
            var VESSELList = _FF_QTNRepo.GetVESSELList(CmpyCode)
                                                 .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                 .ToList();
            return InsertFirstElementDDL(VESSELList);
        }

        public List<SelectListItem> GetVOYAGEList(string CmpyCode)
        {
            var VOYAGEList = _FF_QTNRepo.GetVOYAGEList(CmpyCode)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(VOYAGEList);
        }

        public List<SelectListItem> GetSL(string CmpyCode)
        {
            var SLList = _FF_QTNRepo.GetCLAUSE(CmpyCode)
                                                  .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                  .ToList();
            return InsertFirstElementDDL(SLList);
        }

        public List<SelectListItem> GetCLAUSE(string CmpyCode)
        {
            var CLAUSEList = _FF_QTNRepo.GetCLAUSE(CmpyCode)
                                                .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                                .ToList();
            return InsertFirstElementDDL(CLAUSEList);
        }

        public List<SelectListItem> GetCRG_002(string CmpyCode)
        {
            var CRG_002List = _FF_QTNRepo.GetCRG_002(CmpyCode)
                                           .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                           .ToList();
            return InsertFirstElementDDL(CRG_002List);
        }

        public FF_QTN_VM GetFF_QTN_AddNew(string Cmpycode)
        {
            return new FF_QTN_VM
            {
                VOYAGEList=GetVESSELList(Cmpycode),
                SLList=GetVESSELList(Cmpycode),
                CLAUSEList=GetCLAUSE(Cmpycode),
                CRG_002List=GetCRG_002(Cmpycode),
                DEPARTMENTList=GetDepart(Cmpycode),
                MoveCodeList=GetMoveCode(Cmpycode),
                VESSELList=GetVESSELList(Cmpycode),
                EditFlag = false
            };
        }
    }
}
