using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IFinalsettalmentRepository
    {

        #region Final Settalment
        List<FinalSettalment> GetFinalSettalment(string CmpyCode);
        List<Employee> GetEmpCodes(string CmpyCode,string typ);


        List<FinalSettI> GetFinalSetI(string CmpyCode, string EmpCode);

        List<FinalSetII> GetFinalSetII(string Cmpycode, string Empcode, DateTime joiingdte, DateTime Reldate, float deducdays, string F1_type, float basicper, DateTime LLSdate, float Ldeducdays, string emptyp, float bleave, float Lbasic, float Housing, float Food, float Tele, float Transport, float Other_Allow);

        Finalsettalment_VM SaveFinalSettalment(Finalsettalment_VM Fins);
                
        bool DeleteFinalSettalment(string Code, string CmpyCode, string UserName);
        Finalsettalment_VM GetFinalsettalmentEdit(string CmpyCode, string PRFSET001_code);

       
        #endregion
    }
}
