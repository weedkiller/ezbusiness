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
    public interface ILvSettlePayrollService
    {

        LeaveSettlementVM GetLeaveSettlementNew(string CmpyCode);

        List<LeaveSettlementVM> GetLivlist(string CmpyCode);
        LeaveSettlementVM SaveLiv(LeaveSettlementVM Liv);
        LeaveSettlementVM GetLivlistEdit(string CmpyCode, string PRLS001_COD);
        List<SelectListItem> GetEmpCodes(string CmpyCode);
        List<SelectListItem> GetLeaveCodes(string CmpyCode, string typ);
        List<LeaveSettlementnew> GetLeaveDetails(string CmpyCode, string PRLR001_CODE, DateTime lvsdte);
        bool DeleteLiv(string CmpyCode, string PRLS001_COD, string UserName);
    }
}
