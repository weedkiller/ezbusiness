using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using System.Web.Mvc;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Interface
{
    public interface IEmpBankPayRollService
    {
        List<EmpBankVM> GetEmpBnkList(string CmpyCode);        
        EmpBankVM SaveEmpBnk(EmpBankVM EmpBnk);      
        List<SelectListItem> GetEmpCodes(string CmpyCode, string typ);
        List<SelectListItem> GetPRBM001_code(string CmpyCode,string Prefix);
        List<SelectListItem> GetPRBM002_code(string CmpyCode, string PRBM001_code,string Prefix);     
        bool DeleteEmpBnk(string CmpyCode, string PRBM003_CODE, string UserName);
        EmpBankVM GetEmpBankPayRollEdit(string CmpyCode, string PRBM003_CODE);
        EmpBankVM GetEmpBankPayRollNew(string CmpyCode);
    }
}
