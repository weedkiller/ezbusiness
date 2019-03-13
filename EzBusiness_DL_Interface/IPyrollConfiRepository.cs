using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IPyrollConfiRepository
    {
        #region Pay roll Master
        List<PyrollConfi_Vm> GetPyrollConfiList(string CmpyCode);

        PyrollConfi_Vm SavePyrollConfi(PyrollConfi_Vm Lons);

        //List<dateYm> GetMonthlist();
        PyrollConfi_Vm GetPyrollConfiDet(string CmpyCode, string Code);

        bool DeletePyrollConfi(string Code, string CmpyCode, string username);

        List<Nation> GetNationList(string CmpyCode);

        #endregion
    }
}
