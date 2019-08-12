using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI.SEA_Export
{
    public interface IFNINV001Service
    {

        List<FNINV001_VM> GetFNINV(string CmpyCode, string BRANCHCODE, string Module_Type);
        FNINV001_VM GetFNINVDetailsEdit(string CmpyCode, string FNINV001_CODE, string BRANCHCODE);

        FNINV001_VM GetFNINVDetailsBL(string CmpyCode, string FF_BL001_CODE, string BRANCHCODE);
        FNINV001_VM SaveFNINV_VM(FNINV001_VM FNINV);
        FNINV001_VM GetFNINV_AddNew(string Cmpycode, string BRANCHCODE);

        List<SelectListItem> GetCRG_002(string CmpyCode, string Prefix);

        List<SelectListItem> GETBLNO(string CmpyCode, string Branchcode, string Customercode, string Prefix);

        List<FNINV002New> GETBLNODetails(string CmpyCode, string Branchcode, string BLNO);

        bool DeleteFNINV(string CmpyCode, string FNINV001_CODE, string UserName,string BRANCHCODE);

        List<FNINV002New> GetFNINV002DetailList(string CmpyCode, string FNINV001_CODE, string Branchcode);
    }

}
