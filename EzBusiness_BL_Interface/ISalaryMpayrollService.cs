using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;


namespace EzBusiness_BL_Interface
{
    public interface ISalaryMpayrollService
    {
        List<SalarMpayrollVM> GetSryList(string CMPYCODE);

        List<SalaryGrid> GetSalGrid(string CmpyCode);

        // List<SalaryIncrementEarning> GetDeduct(string CmpyCode, string Code, DateTime effdate);


        SalarMpayrollVM SaveSry(SalarMpayrollVM Sry);

        SalarMpayrollVM GetSalaryEdit(string CMPYCODE, string PRSM001_CODE);

        SalarMpayrollVM GetSalaryNew(string CMPYCODE, string PRSM001_CODE);

        //SalaryMasterVM GetContractMY(string CmpyCode, string EmpCode);

        List<SelectListItem> GetEmpCodes(string CMPYCODE);

        //List<SelectListItem> GetAccountCodes(string CmpyCode);

        bool DeleteSry(string CMPYCODE, string PRSM001_CODE, string UserName);
    }
}
