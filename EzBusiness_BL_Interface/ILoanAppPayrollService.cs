using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
   public interface ILoanAppPayrollService
    {
        #region LoanAppMaster
        List<LoanAppliationVM> GetLoanAppList(string CmpyCode);
        LoanAppliationVM SaveLoanApp(LoanAppliationVM LoanApp);
        List<SelectListItem> GetEmpCodes(string CmpyCode);
        List<SelectListItem> GetPRLM001(string CmpyCode); //Loan Type    
        bool DeleteLoanApp(string CmpyCode, string PRLA001_CODE, string UserName);
        LoanAppliationVM GetLoanAppEdit(string CmpyCode, string PRLA001_CODE);
        LoanAppliationVM GetLoanAppNew(string CmpyCode);

        #endregion
    }
}
