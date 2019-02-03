using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface ITSDpayrollRepository
    {
        List<TimeSheetDetail> GetTSDList(string CmpyCode,string EmpCode,DateTime date);
        List<Employee> GetEmpCodes(string CmpyCode);

    }
}
