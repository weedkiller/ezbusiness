using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;

namespace EzBusiness_BL_Interface
{
    public interface IFinalsettalmentService
    {

        List<SelectListItem> GetEmpCodes(string CmpyCode,string typ);
        Finalsettalment_VM GetFinalSettalmentEdit(string CmpyCode, string Code);
        Finalsettalment_VM GetFinalSettalmentNew(string CmpyCode);
        List<Finalsettalment_VM> GetFinalSettalment(string CmpyCode);
        Finalsettalment_VM SaveFinalSettalment(Finalsettalment_VM Fins);             
        List<FinalSettI> GetFinalSetI(string CmpyCode, string EmpCode);
        List<FinalSetII> GetFinalSetII(string Cmpycode, string Empcode, DateTime joiingdte, DateTime Reldate, float deducdays, string F1_type, float basicper, DateTime LLSdate, float Ldeducdays, string emptyp, float bleave, float Lbasic, float Housing, float Food, float Tele, float Transport, float Other_Allow);
        bool DeleteFinalSettalment(string Code, string CmpyCode, string UserName);
    }
}
