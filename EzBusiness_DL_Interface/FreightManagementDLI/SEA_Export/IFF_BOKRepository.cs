using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
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

        List<FF_BOK_VM> GetFF_BOK(string CmpyCode,string BranchCode);
        FF_BOK_VM GetFF_BOKDetailsEdit(string CmpyCode, string FF_BOK001_CODE, string BranchCode);

        FF_BOK_VM GetFF_BOKDetailsQuot(string CmpyCode, string FF_BOK001_CODE, string BranchCode);

        FF_BOK_VM SaveFF_BOK_VM(FF_BOK_VM FQV);
        List<FF_BOK002New> GetFF_BOK002DetailList(string CmpyCode, string FF_BOK001_CODE,string typ);
        List<FF_BOK003New> GetFF_BOK003DetailList(string CmpyCode, string FF_BOK001_CODE, string typ);
        List<FF_BOK004New> GetFF_BOK004DetailList(string CmpyCode, string FF_BOK001_CODE, string typ);
        List<FF_BOK005New> GetFF_BOK005DetailList(string CmpyCode, string FF_BOK001_CODE, string typ);
        List<ComDropTbl> GetContTyp(string CmpyCode);
        List<ComDropTbl> GetMOVEList(string CmpyCode);
        List<ComDropTbl> GetCommodityistList(string CmpyCode);
        List<ComDropTbl> GetVESSELList(string CmpyCode);
        List<ComDropTbl> GETJobTypList(string CmpyCode,string Prefix);
        List<ComDropTbl> GetPortList(string CmpyCode);
        List<ComDropTbl> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE);
        List<ComDropTbl> GetSL(string CmpyCode,string Typ1, string Prefix);

        List<ComDropTbl> GetSLNew(string CmpyCode, string Typ1, string Prefix);

        List<ComDropTbl> GetDepart(string CmpyCode);
        List<ComDropTbl> GetCLAUSE(string CmpyCode);

        List<ComDropTbl> GetQTNCODE(string CmpyCode,DateTime vdate);
        List<ComDropTbl> GetQTNCODEbucusto(string CmpyCode, string custocode);
        List<FFM_CRG> GetCRG_002(string CmpyCode);


        List<ComDropTbl1> GetCust(string CmpyCode);

        List<ComDropTbl> GetSalesman(string CmpyCode, string Prefix);

        

        List<ComDropTbl1> GetVendor(string CmpyCode);


        List<ComDropTbl> GetCurcode(string CmpyCode);


        List<ComDropTbl> GetUnitcode(string CmpyCode);

        List<FFM_CRG> GetCRGINCEXP(string CmpyCode, string FFM_CRG_001_CODE);
        bool DeleteFF_BOK(string CmpyCode, string FF_BOK001_CODE, string UserName);

        decimal GetCurRate(string CmpyCode, string CurCode);
    }
}
