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
    public interface IFF_BLRepository
    {

        List<FF_BL_VM> GetFF_BL(string CmpyCode,string Branchcode);
        FF_BL_VM GetFF_BLDetailsEdit(string CmpyCode, string FF_BL001_CODE, string Branchcode);

        FF_BL_VM GetFF_BLDetailsBk(string CmpyCode, string FF_BOK001_CODE);
        FF_BL_VM SaveFF_BL_VM(FF_BL_VM FQV);
        List<FF_BL002New> GetFF_BL002DetailList(string CmpyCode, string FF_BL001_CODE, string typ, string BRANCH_CODE);
        List<FF_BL003New> GetFF_BL003DetailList(string CmpyCode, string FF_BL001_CODE, string typ, string BRANCH_CODE);
        List<FF_BL004New> GetFF_BL004DetailList(string CmpyCode, string FF_BL001_CODE, string typ, string BRANCH_CODE);
        List<FF_BL005New> GetFF_BL005DetailList(string CmpyCode, string FF_BL001_CODE, string typ, string BRANCH_CODE);
        List<ComDropTbl> GetContTyp(string CmpyCode);
        List<ComDropTbl> GetMOVEList(string CmpyCode);
        List<ComDropTbl> GetVESSELList(string CmpyCode);
        List<ComDropTbl> GetCommodityistList(string CmpyCode);

        

        List<ComDropTbl> GetPortList(string CmpyCode);
        List<ComDropTbl> GetVOYAGEList(string CmpyCode, string FFM_VESSEL_CODE);
        List<ComDropTbl> GetSL(string CmpyCode,string Typ1);
        List<ComDropTbl> GetDepart(string CmpyCode);
        List<ComDropTbl> GetCLAUSE(string CmpyCode);

        List<FFM_CRG> GetCRG_002(string CmpyCode);
        List<ComDropTbl> GETJobTypList(string CmpyCode);

        List<ComDropTbl1> GetCust(string CmpyCode);

        List<ComDropTbl1> GetVendor(string CmpyCode);


        List<ComDropTbl> GetCurcode(string CmpyCode);


        List<ComDropTbl> GetUnitcode(string CmpyCode);

        List<FFM_CRG> GetCRGINCEXP(string CmpyCode, string FFM_CRG_001_CODE);
        bool DeleteFF_BL(string CmpyCode, string FF_BL001_CODE, string UserName, string BRANCH_CODE);

        decimal GetCurRate(string CmpyCode, string CurCode);

        List<ComDropTbl> GetBOKCODE(string CmpyCode, DateTime vdate);

        List<ComDropTbl> GetBOOKCODEbycusto(string CmpyCode, string Empcode, DateTime vdate, string BranchCode);
    }
}
