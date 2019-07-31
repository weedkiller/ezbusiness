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
        List<FNINV001_VM> GetFNINV(string CmpyCode, string Branchcode);
        FNINV001_VM GetFNINVDetailsEdit(string CmpyCode, string FNINV001_CODE, string Branchcode);

        FNINV001_VM GetFNINVDetailsBL(string CmpyCode, string FF_BL001_CODE, string Branchcode);
        FNINV001_VM SaveFNINV_VM(FNINV001_VM FNINV);
        List<FNINV002New> GetFNINV002DetailList(string CmpyCode, string FNINV001_CODE, string typ,string BRANCHCODE);
      
        List<CRGCodeDropTbl> GetCRG_002(string CmpyCode, string Prefix);

        bool DeleteFNINV(string CmpyCode, string FNINV001_CODE, string UserName,string BRANCHCODE);
    }

}
