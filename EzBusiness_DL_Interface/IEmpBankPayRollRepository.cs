﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IEmpBankPayRollRepository
    {


        #region EmpBankMaster
        List<EmpBankDetail> GetEmpBnkList(string CmpyCode);      
        EmpBankVM SaveEmpBnk(EmpBankVM EmpBnk);       
        List<Employee> GetEmpCodes(string CmpyCode);
        List<BankMaster> GetPRBM001_code(string CmpyCode);
        List<BankBranchTbl> GetPRBM002_code(string CmpyCode, string PRBM001_code);       
        bool DeleteEmpBnk(string CmpyCode, string PRBM003_CODE, string UserName);

        EmpBankVM GetEmpBnkEdit(string CmpyCode, string PRBM003_CODE);

        #endregion

        #region EmpBnk Request



        #endregion

    }
}
