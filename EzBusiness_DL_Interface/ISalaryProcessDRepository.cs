﻿using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzBusiness_DL_Interface
{
    public interface ISalaryProcessDRepository
    {
        List<SalaryProcessDetailsVM> GetSalaryDetailsList(string CmpyCode);
        List<SalaryProcessDetailsListItem> GetSalaryProcessGrid(string CmpyCode,DateTime CurrDate);
        SalaryProcessDetailsVM SaveSalaryProcessD(SalaryProcessDetailsVM salary);
        SalaryProcessDetailsVM GetSalaryProcessEdit(string CmpyCode, string PRSPD001_code);

        List<SalaryProcessDetailsListItem> GetTimeSheetDetailsByMonth(string CmpyCode, DateTime currDate);
        List<SalaryProcessDetailsListItem> GetSalaryProcessGridEdit(string CmpyCode, string PRSPD001_code);
        bool DeleteSalaryProcess(string CmpyCode, string Code, DateTime CurrDate, string UserName);
        string GetSalaryProcessId(string CmpyCode);
        bool CheckslryDataCalculated(string CmpyCode, DateTime CurrDate);
        #region SalaryProcess Request

        #endregion

    }
}
