using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FinaceMgmt;

namespace EzBusiness_DL_Interface
{
    public interface IPaymentMgmtRepository
    {
        #region Payment Master
        List<PaymentTerms> GetPayment(string CmpyCode);

        PaymentTermVM SavePayment(PaymentTermVM Payment);



        bool DeletePayment(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
