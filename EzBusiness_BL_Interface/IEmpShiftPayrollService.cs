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
    public interface IEmpShiftPayrollService
    {

        List<SelectListItem> GetEmpCodes(string CmpyCode, string Prefix);
        List<SelectListItem> GetShiftCodes(string CmpyCode,string Prefix);
        List<SelectListItem> GetShiftAllocCode(string CmpyCode, string PRSFT002_code);//,string Prefix
        EmpShiftVM NewEmpShift(string CmpyCode);
        EmpShiftVM SaveEmpShift(EmpShiftVM Sft);

        EmpShiftVM GetEmpShiftEdit(string CmpyCode, string PRSFT003_code);
        List<EmpShiftVM> GetEmpShiftList(string CmpyCode);
        bool DeleteEmpShift(string CmpyCode, string PRSFT003_code, string UserName);

       
    }
}
