﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_ViewModels;
using EzBusiness_EF_Entity.FreightManagementEF;
using System;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FFM_CRG_001FreightService : IFFM_CRG_001FreightService
    {
        IFFM_CRG_001Repository _FFMCRGRepo;
        ICodeGenRepository _CodeRep;
        public FFM_CRG_001FreightService()
        {
            _FFMCRGRepo = new FFM_CRG_001Repository();
            _CodeRep = new CodeGenRepository();
        }
        public bool DeleteFFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE,  string UserName)
        {
            return _FFMCRGRepo.DeleteFFM_CRG_001(CmpyCode, FFM_CRG_001_CODE,  UserName);
        }

        public FFM_CRG_VM EditFM_CRG_001(string CmpyCode, string FFM_CRG_001_CODE)
        {
            var FFM_CRG_001Edit = _FFMCRGRepo.EditFM_CRG_001(CmpyCode, FFM_CRG_001_CODE);
           // FFM_CRG_001Edit.CRG_GROUP_CODEList = GetCRG_GroupEdit(CmpyCode, FFM_CRG_001Edit.FFM_CRG_GROUP_CODE);
            //FFM_CRG_001Edit.CRG_job_CODEList = GetJobCode(CmpyCode);
            //FFM_CRG_001Edit.IncomeACTList = GetIncomeAct(CmpyCode);
            FFM_CRG_001Edit.crgnewDetails=GetCRGDetailList(CmpyCode, FFM_CRG_001_CODE);
            return FFM_CRG_001Edit;
        }
      

        public List<FFM_CRG_Details> GetCRGDetailList(string CmpyCode, string FFM_CRG_001_CODE)
        {
            var povoyagList = _FFMCRGRepo.GetCRGDetailList(CmpyCode, FFM_CRG_001_CODE);
            return povoyagList.Select(m => new FFM_CRG_Details
            {
                SNO = m.SNO,
                FFM_CRG_JOB_CODE = m.FFM_CRG_JOB_CODE,
                FFM_CRG_JOB_NAME = m.FFM_CRG_JOB_NAME,
                OPERATION_TYPE = m.OPERATION_TYPE,
                INCOME_ACT = m.INCOME_ACT,
                EXPENSE_ACGT = m.EXPENSE_ACGT,
                FFM_CRG_001_CODE = m.FFM_CRG_001_CODE,
                Arabic_Name=m.Arabic_Name,
                CRG_job_CODEList1=GetJobCodeEdit(CmpyCode,m.FFM_CRG_JOB_CODE),
                IncomeACTList1=GetIncomeActEdit(CmpyCode,m.INCOME_ACT),
                IncomeACTList2=GetIncomeActEdit(CmpyCode,m.EXPENSE_ACGT)
                //  SailingHrs = m.SailingHrs,

            }).ToList();
        }
        //hii
        public FFM_CRG_VM FM_CRG_001AddNew(string CmpyCode)
        {
            return new FFM_CRG_VM
            {
                //CRG_GROUP_CODEList = GetCRG_Group(CmpyCode),
                //CRG_job_CODEList=GetJobCode(CmpyCode),
                //IncomeACTList= GetIncomeAct(CmpyCode),
                FFM_CRG_001_CODE=_CodeRep.GetCode(CmpyCode, "CRGM_001"),
                EditFlag = false
            };
        }

        public List<SelectListItem> GetJobCode(string Cmpycode)
        {
            var itemCodes = _FFMCRGRepo.GetJobCode(Cmpycode)
                                         .Select(m => new SelectListItem { Value = m.FFM_JOB_CODE, Text = string.Concat(m.FFM_JOB_CODE, " - ", m.NAME) })
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
        public IQueryable<SelectListItem> GetCRG_Group(string Cmpycode,string Prefix)
        {
            var itemCodes = _FFMCRGRepo.GetCRG_Group(Cmpycode, Prefix)
                                         .Select(m => new SelectListItem { Value = m.CodeName, Text = m.Code})
                                         .AsQueryable();

            return itemCodes;
        }
        public List<SelectListItem> GetIncomeAct(string Cmpycode)
        {
            var itemCodes = _FFMCRGRepo.GetIncomeAct(Cmpycode)
                                         .Select(m => new SelectListItem { Value = m.CODE, Text = string.Concat(m.CODE, " - ", m.NAME) })
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetJobCodeEdit(string Cmpycode,string Code)
        {
            var itemCodes = _FFMCRGRepo.GetJobCode(Cmpycode).Where(m => m.FFM_JOB_CODE.ToString() == Code).ToList()
                                         .Select(m => new SelectListItem { Value = m.FFM_JOB_CODE, Text = string.Concat(m.FFM_JOB_CODE, " - ", m.NAME) })
                                         .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
        //public List<SelectListItem> GetCRG_GroupEdit(string Cmpycode, string Code)
        //{
        //    var itemCodes = _FFMCRGRepo.GetCRG_Group(Cmpycode).Where(m => m.FFM_CRG_GROUP_CODE.ToString() == Code).ToList()
        //                                 .Select(m => new SelectListItem { Value = m.FFM_CRG_GROUP_CODE, Text = string.Concat(m.FFM_CRG_GROUP_CODE, " - ", m.NAME) })
        //                                 .ToList();

        //    return InsertFirstElementDDL(itemCodes);
        //}
        public List<SelectListItem> GetIncomeActEdit(string Cmpycode, string Code)
        {
            var itemCodes = _FFMCRGRepo.GetIncomeAct(Cmpycode).Where(m => m.CODE.ToString() == Code).ToList()
                                         .Select(m => new SelectListItem { Value = m.CODE, Text = string.Concat(m.CODE, " - ", m.NAME) })
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

        public List<FFM_CRG_VM> GetFFM_CRG_001(string CmpyCode)
        {
            return _FFMCRGRepo.GetFFM_CRG_001(CmpyCode).Select(m => new FFM_CRG_VM
            {
                CMPYCODE = m.CMPYCODE,
                FFM_CRG_001_CODE = m.FFM_CRG_001_CODE,
                NAME = m.NAME,
                DISPLAY_STATUS = m.DISPLAY_STATUS,
                FFM_CRG_GROUP_CODE = m.FFM_CRG_GROUP_CODE,
                Name_Arabic=m.Name_Arabic
            }).ToList();
        }

        public FFM_CRG_VM SaveFFM_CRG_001(FFM_CRG_VM CR)
        {
            return _FFMCRGRepo.SaveFM_CRG_001(CR);
        }

      
    }
}
