using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
   public interface  IShiftMasterPayrollRepository
    {
        #region ShiftMaster
        List<ShiftMaster> GetShiftList(string CmpyCode);

        List<ShiftAlloc> GetShiftGrid(string CmpyCode, string PRSFT001_code);


        ShiftMasterVM SaveShift(ShiftMasterVM Sft);

        ShiftMasterVM GetShiftEdit(string CmpyCode, string PRSFT001_code);
   

        List<Nation> GetNationList(string CmpyCode);

        //List<Employee> GetEmpCodes(string CmpyCode);
       

        bool DeleteShift(string CmpyCode, string PRSFT001_code, string UserName);
        int UseShiftAlloc(string CmpyCode, string PRSFT001_code, string PRSFT002_code);

        #endregion
        #region ShiftMaster Request



        #endregion
    }
}
