using EzBusiness_ViewModels.Models.FreightManagement.SEA_Export;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface.FreightManagementBLI.SEA_Export
{
    public interface IFNINV001Service
    {

        List<FNINV001_VM> GetFNINV(string CmpyCode, string Branchcode);
        FNINV001_VM GetFNINVDetailsEdit(string CmpyCode, string FNINV001_CODE, string Branchcode);

        FNINV001_VM GetFNINVDetailsBL(string CmpyCode, string FF_BL001_CODE, string Branchcode);
        FNINV001_VM SaveFNINV_VM(FNINV001_VM FNINV);
        FNINV001_VM GetFNINV_AddNew(string Cmpycode, string branchcode);

        bool DeleteFNINV(string CmpyCode, string FNINV001_CODE, string UserName);
    }

}
