using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Login;

namespace EzBusiness_DL_Interface
{
    public interface ILoginRepository
    {
        #region Login Master

       
        List<Company> GetCompanyList();

        List<Division> GetDivisionList(string CmpyCode);

        List<BranchTbl> GetBranchList(string CmpyCode,string DivCode);

        List<Department> GetDepartmentList(string CmpyCode, string DivCode,string BranchCode);


        List<ComDropTbl> GetBranchListN(string CmpyCode);


       string Divisioncode(string CmpyCode, string BranchCode);

        LoginVM Login(LoginVM LoginMaster);

        List<ComDropTbl> GetDivisionCurrency(string CmpyCode, string BranchCode);

        #endregion
    }
}
