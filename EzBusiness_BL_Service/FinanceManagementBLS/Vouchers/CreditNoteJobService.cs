using EzBusiness_BL_Interface.FinanceManagementBLI.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System.Web.Mvc;
using EzBusiness_DL_Repository;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Interface.FinanceManagementDLI.Vouchers;
using EzBusiness_DL_Repository.FinanceManagementDLR.Vouchers;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service.FinanceManagementBLS.Vouchers
{
    public class CreditNoteJobService : ICreditNoteJobService
    {

        ICreditNoteJobRepository _CrDrRepo;
        ICodeGenRepository _CodeRep;

        public CreditNoteJobService()
        {
            _CrDrRepo = new CreditNoteJobRepository();
            _CodeRep = new CodeGenRepository();

        }
        DropListFillFun drop = new DropListFillFun();

        public bool Bl_InvoiceGenerateLates(string CmpyCode, string Branchcode, string BLCode, string Customer_code, string ExCode, string ExRate, string Table_Name, string Module_Type, string UserName)
        {
            return _CrDrRepo.Bl_InvoiceGenerateLates(CmpyCode, Branchcode, BLCode, Customer_code, ExCode, ExRate, Table_Name, Module_Type, UserName);
        }

        public bool DeleteFNINV(string CmpyCode, string FNINV001_CODE, string UserName, string BRANCHCODE)
        {
            return _CrDrRepo.DeleteFNINV(CmpyCode, FNINV001_CODE, UserName, BRANCHCODE);
        }

        public List<SelectListItem> GETBLNO(string CmpyCode, string Branchcode, string Customercode, string Module_Type, string Type_Choose)
        {
            var CRG_002List = _CrDrRepo.GETBLNO(CmpyCode, Branchcode, Customercode, Module_Type, Type_Choose)//.Where(m => m.FFM_CRG_JOB_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.FFM_CRG_JOB_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                            .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName) })
                                            .ToList();
            return InsertFirstElementDDL(CRG_002List);
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

        public FNINV001_VM GetCredit_AddNew(string Cmpycode, string BRANCHCODE)
        {
            return new FNINV001_VM
            {
                FNINV001_CODE = _CodeRep.GetCodeNew(Cmpycode, BRANCHCODE, "FNINV001", "CRNTJ", "V"),

                EditFlag = false
            };
        }



        public List<SelectListItem> GetCustSupp(string CmpyCode, string BRANCHCODE, string Module_Type, string Type_Choose, string Prefix)
        {
            var CRG_002List = _CrDrRepo.GetCustSupp(CmpyCode, BRANCHCODE, Module_Type, Type_Choose, Prefix)//.Where(m => m.FFM_CRG_JOB_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.FFM_CRG_JOB_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                           .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                           .ToList();
            return CRG_002List;
        }

        public FNINV001_VM GetDebit_AddNew(string Cmpycode, string BRANCHCODE)
        {
            return new FNINV001_VM
            {
                FNINV001_CODE = _CodeRep.GetCodeNew(Cmpycode, BRANCHCODE, "FNINV001", "DBNTJ", "V"),

                EditFlag = false
            };
        }

        public List<FNINV001_VM> GetFNINV(string CmpyCode, string BRANCHCODE, string Module_Type)
        {
            return _CrDrRepo.GetFNINV(CmpyCode, BRANCHCODE, Module_Type);
        }

        public List<FNINV002New> GetFNINV002DetailList(string CmpyCode, string FNINV001_CODE, string Branchcode)
        {
            var FNINV002DetailList = _CrDrRepo.GetFNINV002DetailList(CmpyCode, FNINV001_CODE, Branchcode);
            return FNINV002DetailList.Select(m => new FNINV002New
            {
                O_CHARGE_UID = m.O_CHARGE_UID,
                ITEMCODE = m.ITEMCODE,
                Item_Description = m.Item_Description,
                UNIT_TYPE = m.UNIT_TYPE,
                NO_OF_QTY = m.NO_OF_QTY,
                O_CURR_CODE = m.O_CURR_CODE,
                RATE_PER_QTY = m.RATE_PER_QTY,
                O_CURR_RATE = m.O_CURR_RATE,
                O_CURR_AMT = m.O_CURR_AMT,
                O_LOCAL_AMT = m.O_LOCAL_AMT,
                COA_CODE = m.COA_CODE,
                VAT_CODE = m.VAT_CODE,
                VAT_PER = m.VAT_PER,
                VAT_GL_CODE = m.VAT_GL_CODE,
                O_VAT_LOCAL_AMT = m.O_VAT_LOCAL_AMT,
                O_VAT_CURR_AMT = m.O_VAT_CURR_AMT,
                LINE_NO = m.LINE_NO,
                V_VAT_LOCAL_AMT = m.V_VAT_LOCAL_AMT,
                V_VAT_CURR_AMT = m.V_VAT_CURR_AMT,
                V_LOCAL_AMT = m.V_LOCAL_AMT,
                V_CURR_AMT = m.V_CURR_AMT,
                V_NET_CURR_AMT = m.V_NET_CURR_AMT,
                V_NET_LOCAL_AMT = m.V_NET_LOCAL_AMT,

            }).ToList();
        }

        public FNINV001_VM GetFNINVDetailsBL(string CmpyCode, string FF_BL001_CODE, string BRANCHCODE)
        {
            var poEdit = _CrDrRepo.GetFNINVDetailsBL(CmpyCode, FF_BL001_CODE, BRANCHCODE);

            return poEdit;
        }

        public FNINV001_VM GetFNINVDetailsEdit(string CmpyCode, string FNINV001_CODE, string BRANCHCODE)
        {
            var poEdit = _CrDrRepo.GetFNINVDetailsEdit(CmpyCode, FNINV001_CODE, BRANCHCODE);
            poEdit.FNINV002Detail = GetFNINV002DetailList(CmpyCode, FNINV001_CODE, BRANCHCODE);
            poEdit.EditFlag = true;
            return poEdit;
        }

        public FNINV001 GetHeaderDetail(string CmpyCode, string FNINV001_CODE, string BRANCHCODE)
        {
            return _CrDrRepo.GetHeaderDetail(CmpyCode, FNINV001_CODE, BRANCHCODE);
        }

        public FNINV001_VM SaveFNINV_VM(FNINV001_VM FNINV)
        {
            if (!FNINV.EditFlag)
            {              
                FNINV.FNINV001_CODE = _CodeRep.GetCodeNew(FNINV.cmpycode, FNINV.BRANCHCODE, "FNINV001", FNINV.INV_TYPE, "I");
            }
            return _CrDrRepo.SaveFNINV_VM(FNINV);
        }

        public bool BlCrdr_InvoiceGenerateLates(string CmpyCode, string Branchcode, string InvCode, string Table_Name, string Module_Type, string InvModule_Type, string UserName)
        {
            return _CrDrRepo.BlCrdr_InvoiceGenerateLates(CmpyCode, Branchcode, InvCode, Table_Name, Module_Type, InvModule_Type, UserName);
        }

        public FNINV001_VM Credit_Debit_NoteForJob(string CmpyCode, string Branchcode, string InvCode, string Module_Type)
        {
            var poEdit = _CrDrRepo.Credit_Debit_NoteForJob(CmpyCode, Branchcode, InvCode, Module_Type);

            return poEdit;

        }
    }

    
}