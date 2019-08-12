using EzBusiness_EF_Entity;
using EzBusiness_EF_Entity.FreightManagementEF.SEA_Export;
using EzBusiness_ViewModels.Models.FreightManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface.FreightManagementDLI
{
   public interface ICodeSettingsRepository
    {

        List<UTM0001_VM> GetCodeSettings(string Cmpycode, string Branchcode);
        UTM0001_VM SaveCodeSettings(UTM0001_VM UTM);
        UTM0001_VM EditCodeSettings(string Cmpycode, string Branchcode,  string UTI0001_CODE);
        bool DeleteCodeSettings(string Cmpycode, string Branchcode, string UTI0001_CODE,  string username);

        List<UTI0002New> GetUTI0002DetailList(string Cmpycode, string Branchcode, string UTI0001_CODE);


        List<ComDropTbl> GetTblname(string Prefix);


        List<ComDropTbl> GetUsername(string CmpyCode,string Prefix);



    }
}
