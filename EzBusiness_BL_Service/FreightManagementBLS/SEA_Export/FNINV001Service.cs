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
            poEdit.EditFlag = true;
            return poEdit;
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
    }
}
