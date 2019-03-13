using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll ;
using System.Web.Mvc;
using EzBusiness_ViewModels;

namespace EzBusiness_BL_Service
{
    public class DutyResumePayrollService : IDutyResumePayrollService
    {
        IDutyResumePayrollRepository _DrRepo;
        ICodeGenRepository _codeRep;
        public DutyResumePayrollService()
        {
            _DrRepo = new DutyResumePayrollRepository();
            _codeRep = new CodeGenRepository();
        }
        public bool DeleteDrs(string Cmpycode, string PRDR001_CODE, string oldLeavedays, string EmpCode, string UserName)
        {
            return _DrRepo.DeleteDrs(Cmpycode, PRDR001_CODE,oldLeavedays,EmpCode, UserName);
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
        public List<DutyResumeVM> GetDrs(string Cmpycode)
        {
            return _DrRepo.GetDrs(Cmpycode).Select(m => new DutyResumeVM
            {
                Cmpycode = m.Cmpycode,
                PRDR001_CODE = m.PRDR001_CODE,
                EmpCode = m.EmpCode,
                ResumeDate = m.ResumeDate,
                Approve_Days_in_full=m.Approve_Days_in_full,
                Actual_Leave_Type=m.Actual_Leave_Type,
                Approve_Days=m.Approve_Days


            }).ToList();
        }

        public DutyResumeVM GetDutyAddNew(string Cmpycode)
        {
            return new DutyResumeVM
            {
                
               EmpCodeList= GetEmpCodes(Cmpycode),
               LsNoList = GetLsNo(Cmpycode, "Ntyp"),

                Rm_TypeList = GetLeaveTypList(Cmpycode),
                EditFlag = false
            };
        }

        public DutyResumeVM GetDutyEdit(string Cmpycode,string lsno)
        {
            var DrEdit = _DrRepo.GetDutyEdit(Cmpycode, lsno);
            DrEdit.LsNoList = GetLsNo(Cmpycode, "Etyp");
            DrEdit.Rm_TypeList = GetLeaveTypList(Cmpycode);
            DrEdit.EmpCodeList = GetEmpCodes(Cmpycode);
         
            return DrEdit;
        }

        public List<SelectListItem> GetEmpCodes(string Cmpycode)
        {
            var EmpCodes = _DrRepo.GetEmpCodes(Cmpycode)
                                        .Select(m => new SelectListItem { Value = m.EmpCode, Text = string.Concat(m.EmpCode, " - ", m.Empname) })
                                        .ToList();
            return InsertFirstElementDDL(EmpCodes);
        }
        public List<SelectListItem> GetLeaveTypList(string CmpyCode)
        {
            var itemCodes = _DrRepo.GetLeaveTypList(CmpyCode)
                                       .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code," - ",m.LeaveName) })
                                       .ToList();

            return InsertFirstElementDDL(itemCodes);
        }

        public List<LeaveApplication> GetLeaveData(string cmpycode, string LanNo)
        {
            return _DrRepo.GetLeaveData(cmpycode,LanNo).Select(m => new LeaveApplication
            {
                PRLR001_CODE=m.PRLR001_CODE,
                StartDate=m.StartDate,
                EndDate=m.EndDate,
                EmpCode=m.EmpCode,
                LeaveType=m.LeaveType,
                TotalSanctioned=m.TotalSanctioned,
                DIVISION=m.DIVISION,
                COUNTRY=m.COUNTRY,
                JoiningDate=m.JoiningDate,    
                TotalBalance=m.TotalBalance                       
            }).ToList();
        }

        public List<SelectListItem> GetLsNo(string Cmpycode, string typ)
        {
            var LsNo = _DrRepo.GetLsNo(Cmpycode,typ)
                                        .Select(m => new SelectListItem { Value = m.PRLR001_CODE, Text =string.Concat(m.PRLR001_CODE , "-",m.Entry_Dates,"-", m.EmpCode) })
                                        .ToList();
            return InsertFirstElementDDL(LsNo);
        }
        public DutyResumeVM SaveDrs(DutyResumeVM Drs)
        {          
            Drs.division = _codeRep.GetDiv(Drs.Cmpycode, Drs.EmpCode);
            Drs.country = _codeRep.GetCountryP(Drs.Cmpycode, Drs.ResumeDate);
            if (Drs.country == null)
            {
                Drs.SaveFlag = false;
                Drs.ErrorMessage = "PayRoll Config not Generated";
                return Drs;
            }
            else
            {
                return _DrRepo.SaveDrs(Drs);
            }

           // return _DrRepo.SaveDrs(Drs);
        }
        

      
    }
}
