﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Interface
{
    public interface ISalaryHeadPayrollService
    {
        List<SalaryHeadVM> GetSals(string CmpyCode);

        SalaryHeadVM SaveSals(SalaryHeadVM Sals);

        List<CommonTable> GetPayDeductOns();

        bool DeleteSals(string Code, string CmpyCode, string UserName);
    }
}
