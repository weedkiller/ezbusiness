using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface ILvSettlePayrollRepository 
    {
        #region Leavesettlement
        List<LeaveSettlement> GetLivlist(string CmpyCode);       
        LeaveSettlementVM SaveLiv(LeaveSettlementVM Liv);
        LeaveSettlementVM GetLivlistEdit(string CmpyCode, string PRLS001_COD);        
        List<Employee> GetEmpCodes(string CmpyCode);
        List<ComDropTbl> GetLeaveCodes(string CmpyCode, string Prefix);
        List<LeaveSettlementnew> GetLeaveDetails(string CmpyCode, string PRLR001_CODE, DateTime lvsdte);
        bool DeleteLiv(string CmpyCode, string PRLS001_COD, string UserName);

        DateTime GetJoiningdate(string CmpyCode, string EmpCode);
        #endregion




    }
}
