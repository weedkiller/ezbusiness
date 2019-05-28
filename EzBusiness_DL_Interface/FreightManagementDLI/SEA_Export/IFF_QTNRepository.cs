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

        List<ComDropTbl> GetMOVEList(string CmpyCode);
        List<ComDropTbl> GetVESSELList(string CmpyCode);

        List<ComDropTbl> GetPortList(string CmpyCode);
        List<ComDropTbl> GetVOYAGEList(string CmpyCode);
        List<ComDropTbl> GetSL(string CmpyCode);
        List<ComDropTbl> GetDepart(string CmpyCode);
        List<ComDropTbl> GetCLAUSE(string CmpyCode);

        List<ComDropTbl> GetCRG_002(string CmpyCode);


        List<ComDropTbl> GetCust(string CmpyCode);

        List<ComDropTbl> GetVendor(string CmpyCode);


        List<ComDropTbl> GetCurcode(string CmpyCode);


        List<ComDropTbl> GetUnitcode(string CmpyCode);

        List<FFM_CRG> GetCRGINCEXP(string CmpyCode,string FFM_CRG_001_CODE);
        bool DeleteFF_QTN(string CmpyCode, string FF_QTN001_CODE, string UserName);
      
    }
}
