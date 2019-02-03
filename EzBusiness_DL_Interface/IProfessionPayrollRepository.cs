using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IProfessionPayrollRepository
    {
        #region Profession Master
        List<Profession> GetPros(string CmpyCode);

        ProfessionVM SavePros(ProfessionVM Pros);

        //List<Commontable> GetTypes();

        bool DeletePros(string ProfCode, string CmpyCode, string UserName);

        #endregion

        #region Profession Request



        #endregion
    }
}
