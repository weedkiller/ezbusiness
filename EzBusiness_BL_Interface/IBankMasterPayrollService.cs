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
    public interface IBankMasterPayrollService
    {
        List<BankMasterVM> GetBnkList(string CmpyCode);
        BankMasterVM SaveBnk(BankMasterVM Bnk);
        BankMasterVM GetBnkEdit(string CmpyCode, string PRBM001_code);                

        List<BankBr> GetBnkGrid(string CmpyCode, string PRBM001_code);
        BankMasterVM GetBnkNew(string CmpyCode);
        List<SelectListItem> GetCountryCodes(string CmpyCode);
        bool DeleteBnk(string CmpyCode, string PRBM001_cod,string username);

        int UseBnkBranch(string CmpyCode, string PRBM001_code, string PRBM002_code);
    }
}
