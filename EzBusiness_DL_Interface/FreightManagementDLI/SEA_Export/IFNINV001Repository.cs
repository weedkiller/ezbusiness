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
  public interface IFNINV001Repository
    {
        List<FNINV001_VM> GetFNINV(string CmpyCode, string Branchcode, string Module_Type);
        FNINV001_VM GetFNINVDetailsEdit(string CmpyCode, string FNINV001_CODE, string Branchcode);

        FNINV001_VM GetFNINVDetailsBL(string CmpyCode, string FF_BL001_CODE, string Branchcode);
        FNINV001_VM SaveFNINV_VM(FNINV001_VM FNINV);
        List<FNINV002New> GetFNINV002DetailList(string CmpyCode, string FNINV001_CODE, string BRANCHCODE);

        FNINV001 GetHeaderDetail(string CmpyCode, string FNINV001_CODE, string BRANCHCODE);

        List<CRGCodeDropTbl> GetCRG_002(string CmpyCode, string Prefix);

        List<ComDropTbl> GETBLNO(string CmpyCode, string Branchcode,string Customercode, string Module_Type);

        List<ComDropTbl> GetSupli(string CmpyCode, string Prefix);


        List<ComDropTbl> GetCustSupp(string CmpyCode,string Branchcode,string Module_Type, string Prefix);


        List<FNINV002> GETBLNODetails(string CmpyCode, string Branchcode, string BLNO);

       
        bool Bl_InvoiceGenerateLates(string CmpyCode, string Branchcode, string BLCode, string Customer_code, string ExCode, string ExRate, string Table_Name, string Module_Type, string UserName);

        bool DeleteFNINV(string CmpyCode, string FNINV001_CODE, string UserName,string BRANCHCODE);
    }

}
