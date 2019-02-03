using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Service
{
    public class SalaryHeadPayrollService : ISalaryHeadPayrollService
    {
        ISalaryHeadPayrollRepository _SalRepo;
        public SalaryHeadPayrollService()
        {
            _SalRepo = new SalaryHeadPayrollRepository();
        }

        public bool DeleteSals(string Code, string CmpyCode, string UserName)
        {
            return _SalRepo.DeleteSals(Code, CmpyCode, UserName);
        }

        public List<CommonTable> GetPayDeductOns()
        {
            var Commontable = _SalRepo.GetPayDeductOns();
            Commontable.Insert(0, new CommonTable { Code = "0", Name = "-Select-" });
            return Commontable;
        }

        public List<SalaryHeadVM> GetSals(string CmpyCode)
        {
            return _SalRepo.GetSals(CmpyCode).Select(m => new SalaryHeadVM
            {
                CmpyCode = m.CmpyCode,
                Code = m.Code,
                Name = m.Name,
                //Description = m.Description,
                //AmtType = m.AmtType,
                //PayDeductOn = m.PayDeductOn,
                //SNo = m.SNo,


            }).ToList();
        }

        public SalaryHeadVM SaveSals(SalaryHeadVM Sals)
        {
            return _SalRepo.SaveSals(Sals);
        }
    }
}
