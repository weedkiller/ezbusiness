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
    public class OTPayrollService : IOTPayrollService
    {


        IOTPayrollRepository _OTPayrollRepository;
        public OTPayrollService()
        {
            _OTPayrollRepository = new OTPayrollRepository();
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

        public List<SelectListItem> GetEmpCodeList(string CmpyCode)
        {
            var itemCodes = _OTPayrollRepository.GetEmpCodeList(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                       .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
        public List<Attendence> GetLeaveTypList(string CmpyCode)
        {
            var Attendence = _OTPayrollRepository.GetLeaveTypList(CmpyCode);
            Attendence.Insert(0, new Attendence { Code = "0", LeaveName = "-Select Leave Code-" });
            return Attendence;
        }

        public List<TimeSheetDetail> GetLeaveAppDetailList(string CmpyCode, string EmpCode, DateTime dte)
        {
            var poEmployeeList = _OTPayrollRepository.GetOTDetailList(CmpyCode, EmpCode, dte);
            return poEmployeeList.Select(m => new TimeSheetDetail
            {
                Att_Date = m.Att_Date,
                ExtraHrs = m.ExtraHrs,
                EmpCode = m.EmpCode,
                FOTHrs = m.FOTHrs,
                HOTHrs = m.HOTHrs,
                NHrs = m.NHrs,
                OTHrs = m.OTHrs,
                ATT = m.ATT,
                ReportingEmp=m.ReportingEmp
            }).ToList();
        }

        public List<TimeSheetDetail> GetAPDetailList(string CmpyCode, string EmpCode, DateTime dte)
        {
            var poEmployeeList = _OTPayrollRepository.GetAPDetailList(CmpyCode, EmpCode, dte);
            return poEmployeeList.Select(m => new TimeSheetDetail
            {
                Att_Date = m.Att_Date,
                ATT = m.ATT,
            }).ToList();
        }

        public OTVM SaveOT(OTVM OT)
        {
            return _OTPayrollRepository.SaveOT(OT);
        }

        public OTVM SaveAP(OTVM OT)
        {
            return _OTPayrollRepository.SaveAP(OT);
        }

        public OTVM GetOTVMNew(string CmpyCode)
        {
            return new OTVM
            {

                EmpCodeList = GetEmpCodeList(CmpyCode),
                EditFlag = false
            };
        }
    }
}
