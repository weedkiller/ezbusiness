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
    public class PyrollConfiService : IPyrollConfiService
    {
        IPyrollConfiRepository _Pyroll;
        ICodeGenRepository _codeRep;
        public PyrollConfiService()
        {
            _codeRep = new CodeGenRepository();
            _Pyroll = new PyrollConfiRepository();
        }
        public bool DeletePyrollConfi(string Code, string CmpyCode, string UserName)
        {
            return _Pyroll.DeletePyrollConfi(Code, CmpyCode, UserName);
        }

        // public List<dateYm> GetMonthlist()
        // {
        //     return _Pyroll.GetMonthlist().Select(m => new dateYm
        //     {
        //         Code=m.Code,
        //         Month1=m.Month1
        //     }).ToList();
        // }

        public PyrollConfi_Vm GetPayrollNew(string CmpyCode)
        {
            return new PyrollConfi_Vm
            {
                PRCNF001_CODE = _codeRep.GetCode(CmpyCode, "PyrollConfi"),
                NationalityList = GetNationList(CmpyCode),
                EditFlag = false
            };
       }

    public List<PyrollConfi_Vm> GetPyrollConfiList(string CmpyCode)
        {
            return _Pyroll.GetPyrollConfiList(CmpyCode).Select(m => new PyrollConfi_Vm
            {
               CMPYCODE=m.CMPYCODE,
               FINMONTH=m.FINMONTH,
               FINYEAR=m.FINYEAR,
               FROM_DATE=m.FROM_DATE,
               PRCNF001_CODE=m.PRCNF001_CODE,
               SRNO=m.SRNO,  
               NOOFDAYS=m.NOOFDAYS            
            }).ToList();
        }

        public PyrollConfi_Vm GetPyrollConfiDet(string CmpyCode, string Code)
        {
            var poPyroll = _Pyroll.GetPyrollConfiDet(CmpyCode, Code);
            poPyroll.NationalityList = GetNationList(CmpyCode);
            poPyroll.EditFlag = true;
            return poPyroll;
        }

        public PyrollConfi_Vm SavePyrollConfi(PyrollConfi_Vm Lons)
        {
            if (!Lons.EditFlag)
            {
                Lons.PRCNF001_CODE = _codeRep.GetCode(Lons.CMPYCODE, "PyrollConfi");
            }
            return _Pyroll.SavePyrollConfi(Lons);
        }

        public List<SelectListItem> GetNationList(string CmpyCode)
        {
            var itemCodes = _Pyroll.GetNationList(CmpyCode)
                                    .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, "-", m.Name) })
                                    .ToList();

            return InsertFirstElementDDL(itemCodes);
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
    }
}
