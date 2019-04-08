using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface
{
   public interface IsalaryProcessPaymentRepository
    {
        bool DeleteSalaryProcessPayment(string CmpyCode, string SalCode, DateTime currdatetime, string username);
        List<SalaryProcessDVM> GetSalaryprocessPymntDetailList(string CmpyCode);
       // SalaryProcessDVM GetNewbtnsalaryPrcesspaymentDetails(string CmpyCode);
        SalaryProcessDVM SaveSalryProcessPaymentDetails(SalaryProcessDVM sly);
        SalaryProcessDVM GetEditedsalryprocessPaymentdetails(string cmpycpode);
        List<SalaryprocesspaymentDetails> GetSalaryPrcessDetailsList(SalaryProcessDVM slrypymnt);

        List<SalaryProcessDetailsListItem> GetBankNotDetails(string CmpyCode, DateTime currDate, string divcode, string deptcode, string Visalocation1);

        SalaryProcessDVM GetsalryprocessPaymentEdit(string CmpyCode, string PRSPD001_COD);
        List<SalaryprocesspaymentDetails> GetSalaryProcessPaymentGridEdit(string cmpyCode,string salcode, string paidtype);
    }
}
