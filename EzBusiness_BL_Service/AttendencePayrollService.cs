using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EzBusiness_BL_Interface;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

using EzBusiness_ViewModels;
namespace EzBusiness_BL_Service
{
    public class AttendencePayrollService : IAttendencePayrollService
    {
        IAttendencePayrollRepository _AtenRepo;
        public AttendencePayrollService()
        {
            _AtenRepo = new AttendencePayrollRepository();
        }

        public bool DeleteAtens(string Code, string CmpyCode, string username)
        {
            return _AtenRepo.DeleteAtens(Code, CmpyCode,  username);
        }

        public List<AttendenceVM> GetAtens(string CmpyCode)
        {
            return _AtenRepo.GetAtens(CmpyCode).Select(m => new AttendenceVM
            {
                CmpyCode = m.CmpyCode,
                Code = m.Code,
                LeaveName = m.LeaveName,
                CountryCode = m.CountryCode,
                
                
            }).ToList();
        }

        
        
        public List<Country> GetCountryCodes(string CmpyCode)
        {
            var Cou = _AtenRepo.GetCountryCodes(CmpyCode);
            Cou.Insert(0, new Country { Code = "0", Name = "-Select-" });
            return Cou;
            //var CountryList = _AtenRepo.GetCountryCodes(CmpyCode)
            //                         .Select(m => new SelectListItem { Value = m.Code, Text = string.Concat(m.Code, " - ", m.Name) })
            //                         .ToList();
            //return InsertFirstElementDDL(CountryList);
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
        public AttendenceVM SaveAtens(AttendenceVM Atens)
        {
            return _AtenRepo.SaveAtens(Atens);
        }
    }
}
