using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface
{
    public interface ILoanAppPayrollRepository
    {
        #region LoanAppMaster
        List<LoanAppliationVM> GetLoanAppList(string CmpyCode);
        LoanAppliationVM SaveLoanApp(LoanAppliationVM LoanApp);
        List<Employee> GetEmpCodes(string CmpyCode);
        List<Loan> GetPRLM001(string CmpyCode); //Loan Type    
        bool DeleteLoanApp(string CmpyCode, string PRLA001_CODE, string UserName);
        LoanAppliationVM GetLoanAppEdit(string CmpyCode, string PRLA001_CODE);

        #endregion
    }
}
