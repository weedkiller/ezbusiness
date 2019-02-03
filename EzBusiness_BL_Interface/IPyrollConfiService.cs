using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;


namespace EzBusiness_BL_Interface
{
    public interface IPyrollConfiService
    {
        // List<PayrollConfi> GetPyrollConfi(string CmpyCode);
        //// List<dateYm> GetMonthlist();
        // PyrollConfi_Vm SavePyrollConfi(PyrollConfi_Vm Lons);

        PyrollConfi_Vm GetPayrollNew(string CmpyCode);

        // PyrollConfi_Vm GetPyrollConfiList(string CmpyCode, string Code);

        // bool DeletePyrollConfi(string Code, string CmpyCode);


        List<PyrollConfi_Vm> GetPyrollConfiList(string CmpyCode);

        PyrollConfi_Vm SavePyrollConfi(PyrollConfi_Vm Lons);

        //List<dateYm> GetMonthlist();
        PyrollConfi_Vm GetPyrollConfiDet(string CmpyCode, string Code);

        bool DeletePyrollConfi(string Code, string CmpyCode, string UserName);
    }
}
