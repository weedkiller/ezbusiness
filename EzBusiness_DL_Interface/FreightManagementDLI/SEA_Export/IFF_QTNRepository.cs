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
    public interface IFF_QTNRepository
    {
        List<FF_QTN_VM> GetFF_QTN(string CmpyCode);
        FF_QTN_VM GetFF_QTNDetailsEdit(string CmpyCode, string FF_QTN001_CODE);
        FF_QTN_VM SaveFF_QTN_VM(FF_QTN_VM FQV);       
        List<FF_QTN002New> GetFF_QTN002DetailList(string CmpyCode, string FF_QTN001_CODE);
        List<FF_QTN003New> GetFF_QTN003DetailList(string CmpyCode, string FF_QTN001_CODE);
        List<FF_QTN004New> GetFF_QTN004DetailList(string CmpyCode, string FF_QTN001_CODE);     
        List<FF_QTN005New> GetFF_QTN005DetailList(string CmpyCode, string FF_QTN001_CODE);

        List<ComDropTbl> GetMOVEList(string CmpyCode, string Prefix);
        List<ComDropTbl> GetCommodityistList(string CmpyCode, string Prefix);
        List<ComDropTbl> GetVESSELList(string CmpyCode, string Prefix);

        List<ComDropTbl> GetPortList(string CmpyCode, string Prefix);
        List<ComDropTbl> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE, string Prefix);
        List<ComDropTbl> GetSL(string CmpyCode, string Prefix);
        List<ComDropTbl> GetDepart(string CmpyCode, string Prefix);
        List<ComDropTbl> GetCLAUSE(string CmpyCode, string Prefix);

        List<FFM_CRG> GetCRG_002(string CmpyCode, string Prefix);


        List<ComDropTbl1> GetCust(string CmpyCode, string Prefix);

        List<ComDropTbl1> GetVendor(string CmpyCode, string Prefix);


        List<ComDropTbl> GetCurcode(string CmpyCode, string Prefix);


        List<ComDropTbl> GetUnitcode(string CmpyCode, string Prefix);


        List<ComDropTbl> GetContTyp(string CmpyCode, string Prefix);

        List<FFM_CRG> GetCRGINCEXP(string CmpyCode,string FFM_CRG_001_CODE, string Prefix);
        bool DeleteFF_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName);

        decimal GetCurRate(string CmpyCode, string CurCode);

    }
}
