using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.FinaceMgmt;


namespace EzBusiness_BL_Service
{
    public class PaymentMgmtService : IPaymentMgmtService
    {
        IPaymentMgmtRepository _PaymentRepo;
        public PaymentMgmtService()
        {
            _PaymentRepo = new PaymentMgmtRepository();
        }

        public bool DeletePayment(string Code, string CmpyCode, string UserName)
        {
            return _PaymentRepo.DeletePayment(Code, CmpyCode, UserName);
        }

        public List<PaymentTermVM> GetPayment(string CmpyCode)
        {
            return _PaymentRepo.GetPayment(CmpyCode).Select(m => new PaymentTermVM
            {
                CmpyCode = m.Cmpycode,
                Code = m.Code,
                Name = m.Name,
                NoOfDays = Convert.ToString(m.NoOfDays)

            }).ToList();
        }

        public PaymentTermVM SavePayment(PaymentTermVM Payment)
        {
            return _PaymentRepo.SavePayment(Payment);
        }
    }
}
