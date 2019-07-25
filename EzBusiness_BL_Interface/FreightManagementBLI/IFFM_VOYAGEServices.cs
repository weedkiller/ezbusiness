using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
  public  interface IFFM_VOYAGEServices
    {
        List<FFM_VOYAGE_VM> GetFFM_VoYAGEAList(string CMPYCODE);
        FFM_VOYAGE_VM SaveFFM_Voyage(FFM_VOYAGE_VM FCur);
        IQueryable<SelectListItem> GetVessalCode(string CmpyCode,string Prefix);

        
        FFM_VOYAGE_VM EditVoyagMaster(string CmpyCode, string VyogCode);
        FFM_VOYAGE_VM AddVoyageMaster(string CmpyCode);
        bool DeleteVoyagMaster(string CmpyCode, string VoyageCode, string UserName);

        string GetNameByVessalCode(string VessalCode,string cmpyCode);
    }
}
