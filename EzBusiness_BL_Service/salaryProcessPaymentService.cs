using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EzBusiness_BL_Service
{
 public  class salaryProcessPaymentService: IsalaryProcessPaymentService
  {
        IsalaryProcessPaymentRepository _slpay;
        IOTPayrollRepository _OTPayrollRepository;
        ICodeGenRepository _CodeRep;

        public salaryProcessPaymentService()
        {
            _slpay = new SalaryProcessPaymentRepository();
            _CodeRep = new CodeGenRepository();
            _OTPayrollRepository = new OTPayrollRepository();
        }
        public bool DeleteSalaryProcessPayment(string CmpyCode, string SalCode, DateTime CurrDate, string username)
        {
            return _slpay.DeleteSalaryProcessPayment(CmpyCode, SalCode,CurrDate,username);
        }
        public List<SalaryProcessDVM> GetSalaryprocessPymntDetailList(string CmpyCode)
        {
            var PosalryPaymnt = _slpay.GetSalaryprocessPymntDetailList(CmpyCode);
            return PosalryPaymnt.Select(m => new SalaryProcessDVM
            {
                PRSPD001_CODE = m.PRSPD001_CODE,
                CMPYCODE = m.CMPYCODE,
                COUNTRY = m.COUNTRY,
                DIVISION = m.DIVISION,
                WORKLOCATION = m.WORKLOCATION,
                TYEAR = m.TYEAR,
                TMONTH = m.TMONTH,
                PAIDTYPE = m.PAIDTYPE,
                DivisionName=m.DivisionName,
                Flag = m.Flag

            }).ToList();
           
        }
        public SalaryProcessDVM GetNewbtnsalaryPrcesspaymentDetails(string CmpyCode)
        {
            List<SessionListnew> list = HttpContext.Current.Session["SesDet"] as List<SessionListnew>;

            return new SalaryProcessDVM
            {
                // AccNoList = GetAccList(CmpyCode, "EXP"),
                PRSPD001_CODE = _CodeRep.GetCode(CmpyCode, "SalryProcessDetail"),
              //  DivisionList = GetDivCodeList(CmpyCode),
               // DIVISION = list[0].Divcode.ToString(),
               // VisaLocationList = GetVisLocList(CmpyCode),
               // DepartmentList = GetDepartmentList(CmpyCode, list[0].Divcode)

            };
        }
        public List<SelectListItem> GetDivCodeList(string CmpyCode)
        {
            var itemCodes = _OTPayrollRepository.GetDivCodeList(CmpyCode)
                                     .Select(m => new SelectListItem { Value = m.DivisionCode, Text = string.Concat(m.DivisionCode, " - ", m.DivisionName) })
                                     .ToList();

            return InsertFirstElementDDL(itemCodes);
        }
        public List<SelectListItem> GetDivCodeListLatest(string CmpyCode,string Prefix)
        {
            var itemCodes = _slpay.GetDivCodeListLatest(CmpyCode,Prefix)
                                     .Select(m => new SelectListItem { Value = m.CodeName, Text =m.Code })
                                     .ToList();

            return itemCodes;
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

        public SalaryProcessDVM GetEditedsalryprocessPaymentdetails(string cmpycode)
        {
            return _slpay.GetEditedsalryprocessPaymentdetails(cmpycode);
        }
        public List<SalaryprocesspaymentDetails> GetSalaryPrcessDetailsList(SalaryProcessDVM slypymnt)
        {
            return _slpay.GetSalaryPrcessDetailsList(slypymnt);
        }
        public SalaryProcessDVM SaveSalryProcessPaymentDetails(SalaryProcessDVM sly)
        {
            return _slpay.SaveSalryProcessPaymentDetails(sly);
        }
        public List<SalaryProcessDetailsListItem> GetBankNotDetails(string CmpyCode, DateTime currDate, string divcode, string Deptcode, string VisaLocation1)
        {
            //return _salaryrepo.GetSalaryDetailsList(CmpyCode);


            return _slpay.GetBankNotDetails(CmpyCode, currDate, divcode, Deptcode, VisaLocation1);
            //return poEmployeeList.Select(m => new SalaryProcessDetailsVM
            //{
            //    em = m.Code,
            //    CurrentDate = m.CurrentDate,

            //}).ToList();
        }

        public SalaryProcessDVM GetsalryprocessPaymentEdit(string CmpyCode, string PRSPD001_COD)
        {
            var poedit = _slpay.GetsalryprocessPaymentEdit(CmpyCode, PRSPD001_COD);
            poedit.DivisionList = GetDivCodeList(CmpyCode);
           
            //   poedit.salaryList = GetSalaryProcessGridEdit(poedit.year,poedit.Month,poedit.CmpyCode);

            return poedit;
        }
       public List<SalaryprocesspaymentDetails> GetSalaryProcessPaymentGridEdit(string cmpyCode,string salcode, string paidtype)
        {
             
            var poEmployeeList = _slpay.GetSalaryProcessPaymentGridEdit(cmpyCode,salcode, paidtype);
            return poEmployeeList.Select(m => new SalaryprocesspaymentDetails
            {
                srno = m.srno,
                EMPCODE = m.EMPCODE,
                EMPNAME = m.EMPNAME,
                PRSPD001_CODE=m.PRSPD001_CODE,
                BANKCODE = m.BANKCODE,
                BRANCHCODE = m.BRANCHCODE,
                ACCOUNTNO = m.ACCOUNTNO,
                AMOUNT = m.AMOUNT,
                PAID_TYPE = m.PAID_TYPE,
            }).ToList();
            return _slpay.GetSalaryProcessPaymentGridEdit(cmpyCode, salcode, paidtype);
    }
    }
}
