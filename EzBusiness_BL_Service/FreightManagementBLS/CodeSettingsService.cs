using EzBusiness_BL_Interface.FreightManagementBLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Web.Mvc;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_DL_Repository;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class CodeSettingsService : ICodeSettingsService
    {
        ICodeSettingsRepository _CodeSettingsRepo;
        ICodeGenRepository _CodeRep;
       
        public CodeSettingsService()
        {
            _CodeSettingsRepo = new CodeSettingsRepository();
            _CodeRep = new CodeGenRepository();
            
        }

        public bool DeleteCodeSettings(string Cmpycode, string Branchcode, string Tablename, string username)
        {
            return _CodeSettingsRepo.DeleteCodeSettings(Cmpycode, Branchcode, Tablename, username);
        }

        public UTM0001_VM EditCodeSettings(string Cmpycode, string Branchcode, string Tablename)
        {
            var poEdit = _CodeSettingsRepo.EditCodeSettings(Cmpycode, Branchcode, Tablename);
            poEdit.UTI0002Detail = _CodeSettingsRepo.GetUTI0002DetailList(Cmpycode, Branchcode, Tablename);
            poEdit.EditFlag = true;
            return poEdit;
        }

        public List<UTM0001_VM> GetCodeSettings(string Cmpycode, string Branchcode)
        {
            return _CodeSettingsRepo.GetCodeSettings(Cmpycode, Branchcode);
        }

        public List<SelectListItem> GetTblname(string Prefix)
        {
            var UserList = _CodeSettingsRepo.GetTblname(Prefix)//.Where(m => m.CUSTOMER_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.CUSTOMER_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                      .Select(m => new SelectListItem { Value = m.Code, Text = m.CodeName })
                                                      .ToList();
            return UserList;
        }

        public List<UTI0002New> GetUTI0002DetailList(string Cmpycode, string Branchcode, string Tablename)
        {
            var FF_BL004DetailList = _CodeSettingsRepo.GetUTI0002DetailList(Cmpycode, Branchcode, Tablename);
            return FF_BL004DetailList.Select(m => new UTI0002New
            {
                APPROVER_ID = m.APPROVER_ID,
                APPROVER_NAME = m.APPROVER_NAME,
                Branchcode=m.Branchcode,
                Cmpycode=m.Cmpycode,
                REJECTED_ALLOW=m.REJECTED_ALLOW,
                sno=m.sno,
                Tablename=m.Tablename,
                UTI0001_CODE=m.UTI0001_CODE   ,
                APPROVE_ALLOW=m.APPROVE_ALLOW
            }).ToList();
        }

        public UTM0001_VM SaveCodeSettings(UTM0001_VM UTM)
        {
            return _CodeSettingsRepo.SaveCodeSettings(UTM);
        }

        public List<SelectListItem> GetUsername(string CmpyCode, string Prefix)
        {
            var UserList = _CodeSettingsRepo.GetUsername(CmpyCode, Prefix)//.Where(m => m.CUSTOMER_CODE.ToString().ToLower().Contains(Prefix.ToLower()) || m.CUSTOMER_NAME.ToString().ToLower().Contains(Prefix.ToLower())).ToList()
                                                      .Select(m => new SelectListItem { Value = m.Code, Text =string.Concat(m.Code+" - "+m.CodeName) })
                                                      .ToList();
            return UserList;
        }

        public UTM0001_VM Get_CodeServiceAddNew()
        {
            return new UTM0001_VM
            {
                EditFlag = false
            };
        }
    }
}
