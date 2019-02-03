using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FinaceMgmt;

namespace EzBusiness_BL_Interface
{
    public interface IPaymentMgmtService
    {
        List<PaymentTermVM> GetPayment(string CmpyCode);

        PaymentTermVM SavePayment(PaymentTermVM Payment);



        bool DeletePayment(string Code, string CmpyCode, string UserName);

    }
}
