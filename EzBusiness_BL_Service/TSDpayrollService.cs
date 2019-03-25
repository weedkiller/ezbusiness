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

namespace EzBusiness_BL_Service
{
    public class TSDpayrollService : ITSDpayrollService
    {
        ITSDpayrollRepository _TSDPayrollRepo;
        ICodeGenRepository _CodeRep;
        IOTPayrollRepository _OTPayrollRepository;
        public TSDpayrollService()
        {
            _TSDPayrollRepo = new TSDpayrollRepository();
            _CodeRep = new CodeGenRepository();
            _OTPayrollRepository = new OTPayrollRepository();
        }

        public List<SelectListItem> GetEmpCodes(string CmpyCode)
        {
            var EmpList = _TSDPayrollRepo.GetEmpCodes(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                       .ToList();
            return InsertFirstElementDDL(EmpList);
        }
        private List<SelectListItem> InsertFirstElementDDL(List<SelectListItem> items)
        {
            items.Insert(0, new SelectListItem
            {
                Value = PurchaseMgmtConstants.DDLFirstVal,
                Text = PurchaseMgmtConstants.DDLFirstText
            });
            //items.Insert(1, new SelectListItem
            //{
            //    Value= "All",
            //    Text ="All"
            //});
            
            return items;
        }

        public List<TimeSheetDetailVM> GetTSDList(string CmpyCode, string EmpCode, string Divcode, DateTime date)
        {
            return _TSDPayrollRepo.GetTSDList(CmpyCode, EmpCode,Divcode, date).Select(m => new TimeSheetDetailVM
            {
                //PRSM001UID = m.PRSM001UID,
                Cmpycode = m.Cmpycode,
                EmpCode = m.EmpCode,
                Tmonth = m.Tmonth,
                Tyear = m.Tyear,
              //  SrNo = m.SrNo,
                Attendance = m.ATT,
                Dates = m.Att_Date,
                ExtraHrs = m.ExtraHrs,
                FOThrs = m.FOTHrs,
                Hhrs = m.HOTHrs,
                Nhrs = m.NHrs,
                Ohrs = m.OTHrs,
                ReportingEmp=m.ReportingEmp,
                Project_code=m.Project_code

            }).ToList();
        }

        public TimeSheetDetailVM GetOTVMNew(string CmpyCode)
        {
            return new TimeSheetDetailVM
            {

                EmpCodeList = GetEmpCodes(CmpyCode),
                DivCodeList = GetDivCodeList(CmpyCode),
               // PrjCodeList = GetPrjCodeList(CmpyCode),
                EditFlag = false
            };
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

        public string GetCountryP(string CmpyCode, DateTime dt)
        {
            return _CodeRep.GetCountryP(CmpyCode, dt);
        }
    }
    
}
