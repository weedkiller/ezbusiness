using EzBusiness_BL_Interface.FreightManagementBLI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_ViewModels.Models.FreightManagement;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;

namespace EzBusiness_BL_Service.FreightManagementBLS
{
    public class FFM_COM_groupService : IFFM_COM_groupService
    {

        IFFM_COM_GROUPRepository _FFMCOMGROUPRepo;

        public FFM_COM_groupService()
        {
            _FFMCOMGROUPRepo = new FFM_COM_GROUPRepository();
        }
        public bool DeleteFFM_COM_group(string FFM_COM_group_CODE, string CmpyCode, string UserName)
        {
            return _FFMCOMGROUPRepo.DeleteFFM_COM_GROUP(FFM_COM_group_CODE, CmpyCode, UserName);
        }

        public List<FFM_COM_GROUP_VM> GetFFM_COM_group(string CmpyCode)
        {
            return _FFMCOMGROUPRepo.GetFFM_COM_GROUP(CmpyCode).Select(m => new FFM_COM_GROUP_VM
            {
                CMPYCODE = m.CMPYCODE,
                FFM_COM_GROUP_CODE = m.FFM_COM_GROUP_CODE,
                NAME = m.NAME,
            }).ToList();
        }

        public FFM_COM_GROUP_VM SaveFFM_COM_GROUP(FFM_COM_GROUP_VM FC)
        {
            return _FFMCOMGROUPRepo.SaveFFM_COM_GROUP(FC);
        }
    }
}
