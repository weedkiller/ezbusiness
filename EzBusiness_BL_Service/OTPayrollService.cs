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

        public List<TimeSheetDetail> GetLeaveAppDetailList(string CmpyCode, string EmpCode, DateTime dte, DateTime dte1, string typ)
        {
            var poEmployeeList = _OTPayrollRepository.GetOTDetailList(CmpyCode, EmpCode, dte, dte1,typ);
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
               // ReportingEmp=m.EmpCode,
               
                
            }).ToList();
        }

        public List<TimeSheetDetail> GetAPDetailList(string CmpyCode, string EmpCode, DateTime dte)
        {
            var poEmployeeList = _OTPayrollRepository.GetAPDetailList(CmpyCode, EmpCode, dte);
            return poEmployeeList.Select(m => new TimeSheetDetail
            {
                Att_Date = m.Att_Date,
                ATT = m.ATT,
                EmpCode=m.EmpCode
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
                DivCodeList = GetDivCodeList(CmpyCode),
                PrjCodeList=GetPrjCodeList(CmpyCode),
                EditFlag = false
            };
        }

        public List<Employee> GetEmpRepCodeList(string CmpyCode, string EmpCode, string DivCode, string prjCode)
        {
            // return _OTPayrollRepository.GetEmpRepCodeList(CmpyCode, EmpCode);
            //var itemCodes = _OTPayrollRepository.GetEmpRepCodeList(CmpyCode, EmpCode)
            //                            .Select(m => new SelectListItem { Value = m.EmpCode, Text = m.EmpCode })
            //                            .ToList();
            //return itemCodes;

            var poEmployeeList = _OTPayrollRepository.GetEmpRepCodeList(CmpyCode, EmpCode, DivCode, prjCode);
            return poEmployeeList.Select(m => new Employee
            {                
                EmpCode = m.EmpCode
            }).ToList();
        }

        public List<SelectListItem> GetDivCodeList(string CmpyCode)
        {
            var itemCodes = _OTPayrollRepository.GetDivCodeList(CmpyCode)
                                      .Select(m => new SelectListItem { Value = m.DivisionCode, Text = string.Concat(m.DivisionCode, " - ", m.DivisionName) })
                                      .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<SelectListItem> GetPrjCodeList(string Cmpycode)
        {
            var itemCodes = _OTPayrollRepository.GetPrjCodeList(Cmpycode)
                                       .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
                                       .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
    }
}
