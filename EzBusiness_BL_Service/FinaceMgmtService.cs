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
    public class FinaceMgmtService : IFinaceMgmtService
    {

        IFinaceMgmtRepository _finaceRepo;

        public FinaceMgmtService()
        {
            _finaceRepo = new FinaceMgmtRepository();
        }

       

        public bool DeleteExchange(string CurCode, string CmpyCode, string UserName)
        {
            return _finaceRepo.DeleteExchange(CurCode, CmpyCode, UserName);
        }

        public List<ExchangeRateVM> GetExchange(string CmpyCode)
        {
            return _finaceRepo.GetExchange(CmpyCode).Select(m => new ExchangeRateVM
            {
                CmpyCode = m.CmpyCode,
                CurCode = m.CurCode,
                CurName = m.CurName,
                CurRate = Convert.ToString(m.CurRate)
                
            }).ToList();
        }

        public ExchangeRateVM SaveExchange(ExchangeRateVM Exchange)
        {
            return _finaceRepo.SaveExchange(Exchange);
        }
    }
}
