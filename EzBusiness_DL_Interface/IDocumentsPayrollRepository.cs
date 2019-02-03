using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzBusiness_EF_Entity;
using EzBusiness_ViewModels.Models.Humanresourcepayroll;

namespace EzBusiness_DL_Interface
{
    public interface IDocumentsPayrollRepository
    {
        #region Documents Master
        List<Documents> GetDoks(string CmpyCode);

        DocumentsVM SaveDoks(DocumentsVM Doks);



        bool DeleteDoks(string DocCode, string CmpyCode, string UserName);

        #endregion
    }
}

