using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IVisaLocationPayrollRepository
    {
        #region VisaLocation Master
        List<VisaLocation> GetVls(string CmpyCode);

        VisaLocationVM SaveVls(VisaLocationVM Vls);



        bool DeleteVls(string Code, string CmpyCode, string UserName);

        #endregion
    }
}
