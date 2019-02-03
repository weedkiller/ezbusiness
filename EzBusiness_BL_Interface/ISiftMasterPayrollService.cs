using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
    public interface ISiftMasterPayrollService
    {
        List<ShiftMasterVM> GetShiftList(string CmpyCode);

        List<ShiftAllocationH> GetShiftGrid(string CmpyCode, string PRSFT001_code);


        ShiftMasterVM NewShift(string CmpyCode);
        ShiftMasterVM SaveShift(ShiftMasterVM Sft);

        ShiftMasterVM GetShiftEdit(string CmpyCode, string PRSFT001_code);



        List<SelectListItem> GetCountryCodes(string CmpyCode);

       


        bool DeleteShift(string CmpyCode, string PRSFT001_code, string UserName);

        int UseShiftAlloc(string CmpyCode, string PRSFT001_code, string PRSFT002_code);
    }
}
