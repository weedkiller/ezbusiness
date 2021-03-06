﻿using EzBusiness_BL_Interface.FreightManagementBLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FFM_CRG_GroupService : IFFM_CRG_GroupService
    {

        IFFM_CRG_GroupRepository _FFM_CRGRepo;
        ICodeGenRepository _CodeRep; 
        public FFM_CRG_GroupService()
        {
            _FFM_CRGRepo = new FFM_CRG_GroupRepository();
            _CodeRep = new CodeGenRepository();
        }

        public bool DeleteFFM_CRG_Group(string FFM_CRG_GROUP_CODE, string CmpyCode, string UserName)
        {
            return _FFM_CRGRepo.DeleteFFM_CRG_Group(FFM_CRG_GROUP_CODE, CmpyCode, UserName);
        }

        public FFM_CRG_Group_VM EditFFM_CRG_Group(string CmpyCode, string FFM_CRG_GROUP_CODE)
        {
            var FNM_AC_COAEdit = _FFM_CRGRepo.EditFFM_CRG_Group(CmpyCode, FFM_CRG_GROUP_CODE);
            
            return FNM_AC_COAEdit;
        }

        public List<FFM_CRG_Group_VM> GetFFM_CRG_Group(string CmpyCode)
        {
            return _FFM_CRGRepo.GetFFM_CRG_Group(CmpyCode).Select(m => new FFM_CRG_Group_VM
            {
              CMPYCODE = m.CMPYCODE,
              DISPLAY_STATUS=m.DISPLAY_STATUS,
              NAME=m.NAME,
              VAT_CODE=m.VAT_CODE,
              VAT_GL_CODE=m.VAT_GL_CODE,
              FFM_CRG_GROUP_CODE=m.FFM_CRG_GROUP_CODE,
              Name_Arabic=m.Name_Arabic
            }).ToList();
        }

        public FFM_CRG_Group_VM GetFFM_CRG_GroupAddNew(string Cmpycode)
        {
            return new FFM_CRG_Group_VM
            {
                FFM_CRG_GROUP_CODE = _CodeRep.GetCode(Cmpycode,"CRG_Group"),       
                EditFlag = false
            };
        }

        public FFM_CRG_Group_VM SaveFFM_CRG_Group(FFM_CRG_Group_VM ac)
        {
            return _FFM_CRGRepo.SaveFFM_CRG_Group(ac);
        }
    }
}
