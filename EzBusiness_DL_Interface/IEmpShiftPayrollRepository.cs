using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IEmpShiftPayrollRepository
    {

        #region EmployeeShift
        List<EmpShift> GetEmpShiftList(string CmpyCode);
        EmpShiftVM SaveEmpShift(EmpShiftVM Sft);

        EmpShiftVM GetEmpShiftEdit(string CmpyCode, string PRSFT003_code);
        List<ComDropTbl> GetEmpCodes(string CmpyCode, string Prefix);
        List<ShiftMaster> GetShiftCodes(string CmpyCode);

        List<ComDropTbl> GetShiftCodes1(string CmpyCode, string Prefix);
        List<ShiftAlloc> GetShiftAllocCode(string CmpyCode, string PRSFT002_code);
        List<ComDropTbl> GetShiftAllocCode1(string CmpyCode, string PRSFT002_code);//,string Prefix
        bool DeleteEmpShift(string CmpyCode, string PRSFT003_code, string UserName);

        #endregion
        #region EmployeeShift Request



        #endregion


        //#region EmpBankMaster
        //List<EmpBankDetail> GetEmpBnkList(string CmpyCode);
        //EmpBankVM SaveEmpBnk(EmpBankVM EmpBnk);
        //List<Employee> GetEmpCodes(string CmpyCode);
        //List<BankMaster> GetPRBM001_code(string CmpyCode);
        //List<BankBranchTbl> GetPRBM002_code(string CmpyCode, string PRBM001_code);
        //bool DeleteEmpBnk(string CmpyCode, string PRBM003_CODE);

        //EmpBankVM GetEmpBnkEdit(string CmpyCode, string PRBM003_CODE);

        //#endregion

        //#region EmpBnk Request



        //#endregion


    }
}
