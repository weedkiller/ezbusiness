using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IBankMasterPayrollRepository
    {
        #region BankMaster
        List<BankMaster> GetBnkList(string CmpyCode);

        List<BankBranchTbl> GetBnkGrid(string CmpyCode, string PRBM001_code);

        // List<SalaryIncrementEarning> GetDeduct(string CmpyCode, string Code, DateTime effdate);


        BankMasterVM SaveBnk(BankMasterVM Bnk);

        BankMasterVM GetBnkEdit(string CmpyCode, string PRBM001_code);

        //SalaryMasterVM GetContractMY(string CmpyCode, string EmpCode);

        List<Nation> GetNationList(string CmpyCode);

        //List<SalaryMGrid> GetAccountCodes(string CmpyCode);

        bool DeleteBnk(string CmpyCode, string PRBM001_code,string username);


        int UseBnkBranch(string CmpyCode, string PRBM001_code,string PRBM002_code);


        #endregion

        #region BankMaster Request



        #endregion
    }
}
