using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EzBusiness_DL_Interface.FreightManagementDLI
{
  public interface IFFM_VOYAGERepository
    {
        List<FFM_VOYAGE_VM> GetFFM_VoYAGEAList(string CMPYCODE);
        FFM_VOYAGE_VM SaveFFM_Voyage(FFM_VOYAGE_VM FCur);
        List<FFM_VESSEL> GetVessalCode(string CmpyCode);
        List<FFM_PORT> GetPortList(string CmpyCode);
        FFM_VOYAGE_VM EditVoyagMaster(string CmpyCode, string vyogcode);
        List<FFM_VOYAGEA> GetVayogeDetailList(string CmpyCode, string VyogCode);
        bool DeleteVoyagMaster(string CmpyCode, string Voyage, string UserName);
        string GetNameByVessalCode(string VessalCode, string cmpyCode);
    }
}
