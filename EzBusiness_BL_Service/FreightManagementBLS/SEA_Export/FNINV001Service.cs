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
using EzBusiness_DL_Interface;
using EzBusiness_EF_Entity;

namespace EzBusiness_BL_Service.FreightManagementBLS.SEA_Export
{
    public class FNINV001Service : IFNINV001Service
    {

        IFNINV001Repository _FNINVRepo;
        ICodeGenRepository _CodeRep;

        public FNINV001Service()
        {
            _FNINVRepo = new FNINV001Repository();
            _CodeRep = new CodeGenRepository();

        }
        DropListFillFun drop = new DropListFillFun();

        public bool DeleteFNINV(string CmpyCode, string FNINV001_CODE, string UserName, string BRANCHCODE)
        {
            return _FNINVRepo.DeleteFNINV(CmpyCode, FNINV001_CODE, UserName, BRANCHCODE);
        }

        public List<FNINV001_VM> GetFNINV(string CmpyCode, string Branchcode)
        {
            return _FNINVRepo.GetFNINV(CmpyCode, Branchcode);
        }

        public FNINV001_VM GetFNINVDetailsBL(string CmpyCode, string FF_BL001_CODE, string Branchcode)
        {
            var poEdit = _FNINVRepo.GetFNINVDetailsBL(CmpyCode, FF_BL001_CODE, Branchcode);

            return poEdit;
        }

        public FNINV001_VM GetFNINVDetailsEdit(string CmpyCode, string FNINV001_CODE, string Branchcode)
        {
            var poEdit = _FNINVRepo.GetFNINVDetailsEdit(CmpyCode, FNINV001_CODE, Branchcode);
            poEdit.FNINV002Detail = GetFNINV002DetailList(CmpyCode, FNINV001_CODE, Branchcode);
            poEdit.EditFlag = true;
            return poEdit;
        }


        public List<FNINV002New> GetFNINV002DetailList(string CmpyCode, string FNINV001_CODE, string Branchcode)
        {
            var FNINV002DetailList = _FNINVRepo.GetFNINV002DetailList(CmpyCode, FNINV001_CODE, Branchcode);
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
                LINE_NO=m.LINE_NO,
                V_VAT_LOCAL_AMT=m.V_VAT_LOCAL_AMT,
                V_VAT_CURR_AMT=m.V_VAT_CURR_AMT,
                V_LOCAL_AMT=m.V_LOCAL_AMT,
                V_CURR_AMT=m.V_CURR_AMT,
                V_NET_CURR_AMT=m.V_NET_CURR_AMT,
                V_NET_LOCAL_AMT=m.V_NET_LOCAL_AMT,
               
            }).ToList();
        }
        public FNINV001_VM GetFNINV_AddNew(string Cmpycode, string BRANCHCODE)
        {
            return new FNINV001_VM
            {
                
                EditFlag = false
            };
        }

        public FNINV001_VM SaveFNINV_VM(FNINV001_VM FNINV)
        {
            return _FNINVRepo.SaveFNINV_VM(FNINV);
        }

        public List<SelectListItem> GetCRG_002(string CmpyCode, string Prefix)
        {
            var CRG_002List = _FNINVRepo.GetCRG_002(CmpyCode, Prefix)//.Where(m => m.FFM_CRG_JOB_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.FFM_CRG_JOB_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                           .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.CodeName, " - ", m.VAT_CODE, " - ", m.VAT_PER, " - ", m.VAT_GL_CODE," - ", m.COA_CODE) })
                                           .ToList();
            return CRG_002List;
        }

        public List<SelectListItem> GETBLNO(string CmpyCode, string Branchcode, string Customercode, string Prefix)
        {
            var CRG_002List = _FNINVRepo.GETBLNO(CmpyCode,Branchcode,Customercode, Prefix)//.Where(m => m.FFM_CRG_JOB_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.FFM_CRG_JOB_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
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

        public List<FNINV002New> GETBLNODetails(string CmpyCode, string Branchcode, string BLNO)
        {
            var FNINV002DetailList = _FNINVRepo.GETBLNODetails(CmpyCode, Branchcode, BLNO);
            return FNINV002DetailList.Select(m => new FNINV002New
            {
                O_CHARGE_UID = m.O_CHARGE_UID,
                ITEMCODE = m.ITEMCODE,
                Item_Description = m.Item_Description,
                UNIT_TYPE =m.UNIT_TYPE,
                NO_OF_QTY = m.NO_OF_QTY,
                O_CURR_CODE = m.O_CURR_CODE,
                RATE_PER_QTY = m.RATE_PER_QTY,
                O_CURR_RATE = m.O_CURR_RATE,
                O_CURR_AMT =m.O_CURR_AMT,
                O_LOCAL_AMT = m.O_LOCAL_AMT,
                COA_CODE = m.COA_CODE,
                VAT_CODE = m.VAT_CODE,
                VAT_PER = m.VAT_PER,
                VAT_GL_CODE = m.VAT_GL_CODE,
                O_VAT_LOCAL_AMT =m.O_VAT_LOCAL_AMT,
                O_VAT_CURR_AMT =m.O_VAT_CURR_AMT,
                
            }).ToList();
        }
    }
}
