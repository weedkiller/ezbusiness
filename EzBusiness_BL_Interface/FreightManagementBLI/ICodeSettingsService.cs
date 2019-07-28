using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface.FreightManagementBLI
{
    public interface ICodeSettingsService
    {
        List<UTM0001_VM> GetCodeSettings(string Cmpycode, string Branchcode);
        UTM0001_VM SaveCodeSettings(UTM0001_VM UTM);
        UTM0001_VM EditCodeSettings(string Cmpycode, string Branchcode, string Tablename);
        bool DeleteCodeSettings(string Cmpycode, string Branchcode, string Tablename, string username);
        List<UTI0002New> GetUTI0002DetailList(string Cmpycode, string Branchcode, string Tablename);
        List<SelectListItem> GetTblname(string Prefix);
        List<SelectListItem> GetUsername(string CmpyCode, string Prefix);

        UTM0001_VM Get_CodeServiceAddNew();
    }
}
