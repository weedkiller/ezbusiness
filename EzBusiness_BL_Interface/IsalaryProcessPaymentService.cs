using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_BL_Interface
{
   public interface IsalaryProcessPaymentService
    {
        bool DeleteSalaryProcessPayment(string CmpyCode,string SalCode,DateTime currdatetime,string username);
        List<SalaryProcessDVM> GetSalaryprocessPymntDetailList(string CmpyCode);
        SalaryProcessDVM GetNewbtnsalaryPrcesspaymentDetails(string CmpyCode);
        SalaryProcessDVM SaveSalryProcessPaymentDetails(SalaryProcessDVM sly);
        SalaryProcessDVM GetEditedsalryprocessPaymentdetails(string cmpycpode);


        SalaryProcessDVM GetsalryprocessPaymentEdit(string CmpyCode, string PRSPD001_COD);

        List<SalaryprocesspaymentDetails> GetSalaryPrcessDetailsList(SalaryProcessDVM slrypymnt);

        List<SalaryProcessDetailsListItem> GetBankNotDetails(string CmpyCode, DateTime CurrentDate, string divcode, string Deptcode, string VisaLocation1);
        List<SalaryprocesspaymentDetails> GetSalaryProcessPaymentGridEdit(string salcode, string paidtype);
    }
}
