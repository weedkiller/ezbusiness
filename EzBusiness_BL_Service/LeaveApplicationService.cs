using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System.Web.Mvc;
using EzBusiness_ViewModels;
using System.IO;
using System.Web;

namespace EzBusiness_BL_Service
{
    public class LeaveApplicationService : ILeaveApplicationService
    {

        ILeaveApplicationRepository _LeaveAppRepo;
        ICodeGenRepository _CodeRep;
        public LeaveApplicationService()
        {
            _LeaveAppRepo = new LeaveApplicationRepository();
            _CodeRep = new CodeGenRepository();
        }
        public bool DeleteLeaveApp(string Cmpycode, string PRLR001_CODE, string oldLeavedays, string EmpCode, string UserName)
        {

            return _LeaveAppRepo.DeleteLeaveApp(Cmpycode,PRLR001_CODE,oldLeavedays,EmpCode, UserName);
        }

        private List<SelectListItem> InsertFirstElementDDL(List<SelectListItem> items)
        {
            items.Insert(0, new SelectListItem
            {
                Value = PurchaseMgmtConstants.DDLFirstVal,
                Text = PurchaseMgmtConstants.DDLFirstText
            });
            return items;
        }

        public List<SelectListItem> GetEmpCodeList(string CmpyCode,string typ)
        {

            var itemCodes = _LeaveAppRepo.GetEmpCodeList(CmpyCode, typ)
                                        .Select(m => new SelectListItem { Value = m.EmpCode , Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                        .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

       

        public List<Leave_App_VW> GetLeaveApp(string CmpyCode)
        {
            var poEmployeeList = _LeaveAppRepo.GetLeaveApp(CmpyCode);
            return poEmployeeList.Select(m => new Leave_App_VW
            {
                EmpCode = m.EmpCode,
               CmpyCode=m.CmpyCode,
               //TotalApplied=m.TotalApplied,
               //TotalBalance=m.TotalBalance,
               //TotalSanctioned=m.TotalSanctioned,
               //Status=m.Status,
               PRLR001_CODE=m.PRLR001_CODE,
               EmpName=m.EmpName
               //LeaveType=m.LeaveType,
               //LeaveDays=m.LeaveDays
            }).ToList();
        }

        public Leave_App_VW GetLeaveAppDetailsEdit(string CmpyCode, string Code)
        {
            var poEdit = _LeaveAppRepo.GetLeaveAppDetailsEdit(CmpyCode, Code);
            poEdit.EmpCodeList = GetEmpCodeList(CmpyCode,"A");
            poEdit.LeaveTypeList = GetLeaveTypList(CmpyCode);
           
            poEdit.LeaveDetail = new LeaveApplicationnews();
             poEdit.LeaveApplicationnews = GetLeaveAppDetailList(CmpyCode, Code);
            poEdit.IsEditMode = true;
            return poEdit;
            //throw new NotImplementedException();
        }

        public Leave_App_VW GetLeaveAppDetailsNew(string CmpyCode)
        {
          

            return new Leave_App_VW
            {
                PRLR001_CODE=_CodeRep.GetCode(CmpyCode, "LeaveApplication"),
                EmpCodeList = GetEmpCodeList(CmpyCode,"L"),
                LeaveTypeList=GetLeaveTypList(CmpyCode),
                
                LeaveApplicationnews = new List<LeaveApplicationDetail>(),
                LeaveDetail = new LeaveApplicationnews(),
                IsEditMode = false

            };

        }

        //public Leave_App_VW GetJOingDate(string CmpyCode,)
        //{



        //}
        public Leave_App_VW SaveLeaveApp(Leave_App_VW LeaveApp)
        {
            if (!LeaveApp.IsEditMode)
            {
                LeaveApp.PRLR001_CODE = _CodeRep.GetCode(LeaveApp.CmpyCode, "");
            }
            return _LeaveAppRepo.SaveLeaveApp(LeaveApp);
        }

        public List<LeaveApplicationDetail> GetLeaveAppDetailList(string CmpyCode, string EmpCode)
        {
            var poLeaveAppList = _LeaveAppRepo.GetLeaveAppDetailList(CmpyCode, EmpCode);
            return poLeaveAppList.Select(m => new LeaveApplicationDetail
            {
                PRLR001_CODE = m.PRLR001_CODE,
                EndDate = m.EndDate,
                StartDate = m.StartDate,
                LeaveDays = m.LeaveDays,

            }).ToList();
        }

        public List<SelectListItem> GetLeaveTypList(string CmpyCode)
        {
            var itemCodes = _LeaveAppRepo.GetLeaveTypList(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.Code, Text =string.Concat(m.Code,'-',m.LeaveName) })
                                       .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public decimal GetBalanceLeave(string CmpyCode, string EmpCode, string LeaveType, DateTime joiningdte)
        {
            var balanceLeave = _LeaveAppRepo.GetBalanceLeave(CmpyCode, EmpCode, LeaveType, joiningdte);
            return balanceLeave;
        }

        public DateTime GetJoiningdate(string CmpyCode, string EmpCode)
        {
            var balanceLeave = _LeaveAppRepo.GetJoiningdate(CmpyCode, EmpCode);
            return balanceLeave;
        }
    }
}
