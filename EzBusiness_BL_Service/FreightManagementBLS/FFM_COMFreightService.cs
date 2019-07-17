using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System.Web.Mvc;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FFM_COMFreightService : IFFM_COMFreightService

    { 
        IFFM_COMRepository _FFMCOMRepo;

        public FFM_COMFreightService()
        {
            _FFMCOMRepo = new FFM_COMRepository();
        }

        public bool DeleteFFM_COM(string FFM_COM_CODE, string CmpyCode, string UserName)
        {
            return _FFMCOMRepo.DeleteFFM_COM(FFM_COM_CODE, CmpyCode, UserName);
        }

        public List<FFM_COM_VM> GetFFM_COM(string CmpyCode)
        {
            return _FFMCOMRepo.GetFFM_COM(CmpyCode).Select(m => new FFM_COM_VM
            {
                CMPYCODE = m.CMPYCODE,
                FFM_COM_CODE = m.FFM_COM_CODE,
                NAME = m.NAME,
                C_TYPE=m.C_TYPE,
            }).ToList();
        }

        public List<SelectListItem> GetFFM_COM_GROUP(string CmpyCode,string Prefix)
        {
            //return _FFMCOMRepo.GetFFM_COM_GROUP(CmpyCode, Prefix).Select(m => new FFM_COM_GROUP
            //{                
            //    FFM_COM_GROUP_CODE = m.FFM_COM_GROUP_CODE,
            //    NAME = m.NAME,
            //}).ToList();

            var GroupList  = _FFMCOMRepo.GetFFM_COM_GROUP(CmpyCode, Prefix)
                                       .Select(m => new SelectListItem { Value = m.FFM_COM_GROUP_CODE, Text = string.Concat(m.FFM_COM_GROUP_CODE, " - ", m.NAME) })
                                       .ToList();
            return GroupList;
        }

        public FFM_COM_VM SaveFFM_COM(FFM_COM_VM FC)
        {
            return _FFMCOMRepo.SaveFM_COMHEAD(FC);
        }
    }
}
