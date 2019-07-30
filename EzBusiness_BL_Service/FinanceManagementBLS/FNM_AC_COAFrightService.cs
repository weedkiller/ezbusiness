using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_EF_Entity.FreightManagement;
using EzBusiness_ViewModels;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
   public class FNM_AC_COAFrightService: IFNM_AC_COAService
    {
        IFNM_AC_COARepository _FNM_AC_COARep;
        ICodeGenRepository _CodeRep;
        public FNM_AC_COAFrightService()
        {
            _FNM_AC_COARep = new FNM_AC_COARepository();
            _CodeRep = new CodeGenRepository();
        }

        public bool DeleteFNM_Ac_COA( string CmpyCode, string FNM_AC_CODE, string UserName)
        {
            return _FNM_AC_COARep.DeleteFNM_Ac_COA(CmpyCode, FNM_AC_CODE, UserName);
        }

        public List<FNM_AC_COA_VM> GetFNM_AC_COA(string CmpyCode)
        {
            return _FNM_AC_COARep.GetFNM_AC_COA(CmpyCode).Select(m => new FNM_AC_COA_VM
            {
                COMPANY_UID = m.COMPANY_UID,
                FNM_AC_COAID = m.FNM_AC_COAID,
                CODE = m.CODE,
                NAME = m.NAME,
                Head_code = m.Head_code,
                group_code = m.group_code,
                SUBGROUP_code = m.SUBGROUP_code,
                COA_TYPE = m.COA_TYPE,
                SUBLEDGER_TYPE = m.SUBLEDGER_TYPE,
                MASTER_STATUS = m.MASTER_STATUS,
                SUBLEDGER_CAT=m.SUBLEDGER_CAT,
                NOTE = m.NOTE,
                NATURE = m.NATURE,
                PL_BS = m.PL_BS
            }).ToList();
        }
        public FNM_AC_COA_VM SaveFNM_AC_COA(FNM_AC_COA_VM FC)
        {
            return _FNM_AC_COARep.SaveFNM_AC_COA(FC);
        }
        public FNM_AC_COA_VM EditFNM_AC_COA(string CmpyCode, string Code)
        {           
            var FNM_AC_COAEdit = _FNM_AC_COARep.EditFNM_AC_COA(CmpyCode, Code);
            //FNM_AC_COAEdit.COA_TYPEList = GetCOA_TYPEList(CmpyCode);
           // FNM_AC_COAEdit.COA_TYPEList = GetCOA_TYPEListEDIT(CmpyCode, FNM_AC_COAEdit.COA_TYPE);
            //FNM_AC_COAEdit.group_codeList = Getgroup_code(CmpyCode);
           // FNM_AC_COAEdit.group_codeList = Getgroup_codeEDIT(CmpyCode, FNM_AC_COAEdit.group_code);
            //FNM_AC_COAEdit.SUBLEDGER_TYPEList = GetSUBGROUP(CmpyCode);
          //  FNM_AC_COAEdit.SUBLEDGER_TYPEList = GetFNMSUBGROUPEDIT(CmpyCode, FNM_AC_COAEdit.SUBLEDGER_TYPE);
            //FNM_AC_COAEdit.SUBGROUP_codeList = GetFNMSUBGROUP(CmpyCode);
          //  FNM_AC_COAEdit.SUBGROUP_codeList = GetSUBGROUPEDIT(CmpyCode, FNM_AC_COAEdit.SUBGROUP_code);
            //FNM_AC_COAEdit.Head_codeList = GetFMHEAD(CmpyCode);
            FNM_AC_COAEdit.Head_codeList = GetFMHEADEDITdata(CmpyCode,FNM_AC_COAEdit.Head_code);
          //  FNM_AC_COAEdit.SUBLEDGER_CATList = GetSUBLEDGER_CATEDIT(CmpyCode,FNM_AC_COAEdit.SUBLEDGER_CAT);
            //FNM_AC_COAEdit.SUBLEDGER_CATList = GetSUBLEDGER_CAT(CmpyCode);
            return FNM_AC_COAEdit;
        }

        public IQueryable<SelectListItem> GetFMHEAD(string Cmpycode,string Prefix)
        {
            var itemCodes = _FNM_AC_COARep.GetFMHEAD(Cmpycode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).AsQueryable()
                                                 .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                 .AsQueryable();

            return itemCodes;
        }

        public List<SelectListItem> GetFMHEADEDITdata(string Cmpycode, string Code)
        {
            var itemCodes = _FNM_AC_COARep.GetFMHEAD1(Cmpycode).Where(m => m.FNMHEAD_CODE.ToString() == Code).ToList()
                                          .Select(m => new SelectListItem { Value = m.FNMHEAD_CODE, Text = string.Concat(m.FNMHEAD_CODE, " - ", m.DESCRIPTION) })
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

        public IQueryable<SelectListItem> Getgroup_code(string Cmpycode,string Prefix)
        {
            var itemCodes = _FNM_AC_COARep.Getgroup_code(Cmpycode, Prefix)//.Where(m => m.CodeName.ToString().ToLower().Contains(Prefix.ToLower()) || m.Code.ToString().ToLower().Contains(Prefix.ToLower())).AsQueryable()
                                                .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                                .AsQueryable();

            return itemCodes;
        }

        //public List<SelectListItem> Getgroup_codeEDIT(string Cmpycode, string Code)
        //{
        //    var itemCodes = _FNM_AC_COARep.Getgroup_code1(Cmpycode).Where(m => m.FNMGROUP_CODE.ToString() == Code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.FNMGROUP_CODE, Text = string.Concat(m.FNMGROUP_CODE, " - ", m.DESCRIPTION) })
        //                                  .ToList();

        //    return InsertFirstElementDDL(itemCodes);
        //}
        public IQueryable<SelectListItem> GetSUBGROUP(string Cmpycode, string Prefix)
        {
            var itemCodes = _FNM_AC_COARep.GetSUBGROUP(Cmpycode, Prefix)
                                        .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code})
                                        .AsQueryable();

            return itemCodes;
        }

        //public List<SelectListItem> GetSUBGROUPEDIT(string Cmpycode, string Code)
        //{
        //    var itemCodes = _FNM_AC_COARep.GetSUBGROUP(Cmpycode).Where(m => m.FNMSUBGROUP_CODE.ToString() == Code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.FNMSUBGROUP_CODE, Text = string.Concat(m.FNMSUBGROUP_CODE, " - ", m.DESCRIPTION) })
        //                                  .ToList();

        //    return InsertFirstElementDDL(itemCodes);
        //}
        public IQueryable<SelectListItem> GetCOA_TYPEList(string Cmpycode,string Prefix)
        {
            var itemCodes = _FNM_AC_COARep.GetCOA_TYPEList(Cmpycode, Prefix)
                                        .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                        .AsQueryable();

            return itemCodes;
        }

        //public List<SelectListItem> GetCOA_TYPEListEDIT(string Cmpycode, string Code)
        //{
        //    var itemCodes = _FNM_AC_COARep.GetCOA_TYPEList(Cmpycode).Where(m => m.FNMTYPE_CODE.ToString() == Code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.FNMTYPE_CODE, Text = string.Concat(m.FNMTYPE_CODE, " - ", m.DESCRIPTION) })
        //                                  .ToList();

        //    return InsertFirstElementDDL(itemCodes);
        //}
        public IQueryable<SelectListItem> GetFNMSUBGROUP(string Cmpycode,string Prefix)
        {
            var itemCodes = _FNM_AC_COARep.GetFNMSUBGROUP(Cmpycode, Prefix)
                                       .Select(m => new SelectListItem { Value = m.CodeName, Text =m.Code })
                                       .AsQueryable();

            return itemCodes;
        }

        //public List<SelectListItem> GetFNMSUBGROUPEDIT(string Cmpycode,string Code)
        //{
        //    var itemCodes = _FNM_AC_COARep.GetFNMSUBGROUP(Cmpycode).Where(m => m.FNMSUBGROUP_CODE.ToString() == Code).ToList()
        //                               .Select(m => new SelectListItem { Value = m.FNMSUBGROUP_CODE, Text = string.Concat(m.FNMSUBGROUP_CODE, " - ", m.DESCRIPTION) })
        //                               .ToList();

        //    return InsertFirstElementDDL(itemCodes);
        //}
        public FNM_AC_COA_VM GetFNM_AC_COAAddNew(string Cmpycode)
        {
            return new FNM_AC_COA_VM
            {
                // Head_codeList=GetFMHEAD(Cmpycode),
                //SUBGROUP_codeList=GetSUBGROUP(Cmpycode),
                //COA_TYPEList=GetCOA_TYPEList(Cmpycode),
                //group_codeList = Getgroup_code(Cmpycode),
                //SUBLEDGER_TYPEList=GetSUBGROUP(Cmpycode),
                //SUBLEDGER_CATList=GetSUBLEDGER_CAT(Cmpycode),
               // CODE = _CodeRep.GetCode(Cmpycode,"ChartAcccount"),
                EditFlag = false
            };
        }

        public IQueryable<SelectListItem> GetSUBLEDGER_CAT(string Cmpycode,string Prefix)
        {
            var itemCodes = _FNM_AC_COARep.GetSUBLEDGER_CAT(Cmpycode, Prefix)
                                        .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code })
                                        .AsQueryable();

            return itemCodes;
        }

        //public List<SelectListItem> GetSUBLEDGER_CATEDIT(string Cmpycode, string Code)
        //{
        //    var itemCodes = _FNM_AC_COARep.GetSUBLEDGER_CAT(Cmpycode).Where(m => m.FNMSLCAT_CODE.ToString() == Code).ToList()
        //                                  .Select(m => new SelectListItem { Value = m.FNMSLCAT_CODE, Text = string.Concat(m.FNMSLCAT_CODE, " - ", m.DESCRIPTION) })
        //                                  .ToList();

        //    return InsertFirstElementDDL(itemCodes);
        //}
    }
}
