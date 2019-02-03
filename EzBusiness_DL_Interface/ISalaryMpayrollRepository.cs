using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface ISalaryMpayrollRepository
    {
        #region SalaryMaster
        List<SalaryM> GetSryList(string CMPYCODE);

        List<SalaryMGrid> GetSalGrid(string CmpyCode);

        // List<SalaryIncrementEarning> GetDeduct(string CmpyCode, string Code, DateTime effdate);


        SalarMpayrollVM SaveSry(SalarMpayrollVM Sry);

        SalarMpayrollVM GetSalaryEdit(string CMPYCODE, string PRSM001_CODE);

        //SalaryMasterVM GetContractMY(string CmpyCode, string EmpCode);

        List<Employee> GetEmpCodes(string CMPYCODE);

        //List<SalaryMGrid> GetAccountCodes(string CmpyCode);

        bool DeleteSry(string CMPYCODE, string PRSM001_CODE, string UserName);

        #endregion

        #region SalaryMaster Request



        #endregion
    }
}
