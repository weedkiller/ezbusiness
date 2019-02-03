using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_DL_Interface;
using EzBusiness_DL_Repository;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_BL_Interface
{
    public interface IProfessionPayrollService
    {
        List<ProfessionVM> GetPros(string CmpyCode);

        ProfessionVM SavePros(ProfessionVM Pros);

        //List<Commontable> GetTypes();

        bool DeletePros(string ProfCode, string CmpyCode, string UserName);
    }
}
