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
    public interface ITSDpayrollService
    {
        List<TimeSheetDetailVM> GetTSDList(string CmpyCode, string EmpCode, DateTime date);
        List<SelectListItem> GetEmpCodes(string CmpyCode);

        TimeSheetDetailVM GetOTVMNew(string CmpyCode);


    }
}
