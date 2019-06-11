using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI.SEA_Export
{
    public interface IFF_BOKRepository
    {

        List<FF_BOK_VM> GetFF_BOK(string CmpyCode);
        FF_BOK_VM GetFF_BOKDetailsEdit(string CmpyCode, string FF_BOK001_CODE);
        FF_BOK_VM SaveFF_BOK_VM(FF_BOK_VM FQV);
        List<FF_BOK002New> GetFF_BOK002DetailList(string CmpyCode, string FF_BOK001_CODE);
        List<FF_BOK003New> GetFF_BOK003DetailList(string CmpyCode, string FF_BOK001_CODE);
        List<FF_BOK004New> GetFF_BOK004DetailList(string CmpyCode, string FF_BOK001_CODE);
        List<FF_BOK005New> GetFF_BOK005DetailList(string CmpyCode, string FF_BOK001_CODE);
        List<ComDropTbl> GetContTyp(string CmpyCode);
        List<ComDropTbl> GetMOVEList(string CmpyCode);
        List<ComDropTbl> GetVESSELList(string CmpyCode);
        List<ComDropTbl> GETJobTypList(string CmpyCode);
        List<ComDropTbl> GetPortList(string CmpyCode);
        List<ComDropTbl> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE);
        List<ComDropTbl> GetSL(string CmpyCode,string Typ1);
        List<ComDropTbl> GetDepart(string CmpyCode);
        List<ComDropTbl> GetCLAUSE(string CmpyCode);

        List<ComDropTbl> GetCRG_002(string CmpyCode);


        List<ComDropTbl> GetCust(string CmpyCode);

        List<ComDropTbl> GetVendor(string CmpyCode);


        List<ComDropTbl> GetCurcode(string CmpyCode);


        List<ComDropTbl> GetUnitcode(string CmpyCode);

        List<FFM_CRG> GetCRGINCEXP(string CmpyCode, string FFM_CRG_001_CODE);
        bool DeleteFF_BOK(string CmpyCode, string FF_BOK001_CODE, string UserName);

        decimal GetCurRate(string CmpyCode, string CurCode);
    }
}
