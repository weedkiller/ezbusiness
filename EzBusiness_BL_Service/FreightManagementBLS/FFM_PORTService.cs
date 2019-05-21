using EzBusiness_BL_Interface.FreightManagementBLI;
using EzBusiness_DL_Interface.FreightManagementDLI;
using EzBusiness_DL_Repository.FreightManagementDLR;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Service
{
    public class FFM_PORTService : IFFM_PORTService
    {
        IFFM_PORTRepository _FFM_PORTRepo;
        public FFM_PORTService()
        {
            _FFM_PORTRepo = new FFM_PORTRepository();
        }
        public bool DeleteFFM_PORT(string FFM_PORT_CODE, string CmpyCode, string UserName)
        {
            return _FFM_PORTRepo.DeleteFFM_PORT(FFM_PORT_CODE, CmpyCode, UserName);
        }

        public FFM_PORT_VM EditFFM_PORT(string CmpyCode, string FFM_PORT_CODE)
        {
            return _FFM_PORTRepo.EditFFM_PORT(CmpyCode, FFM_PORT_CODE);
        }

        public List<FFM_PORT_VM> GetFFM_PORT(string CmpyCode)
        {
            return _FFM_PORTRepo.GetFFM_PORT(CmpyCode).Select(m => new FFM_PORT_VM
            {
                CMPYCODE = m.CMPYCODE,
                NAME = m.NAME,
                FFM_PORT_CODE = m.FFM_PORT_CODE,
               COUNTRY=m.COUNTRY,
               TERMINAL=m.TERMINAL,
               //UserName=m.UserName
            }).ToList();
        }

        public FFM_PORT_VM SaveFFM_PORT(FFM_PORT_VM FC)
        {
            return _FFM_PORTRepo.SaveFFM_PORT(FC);
        }
    }
}
